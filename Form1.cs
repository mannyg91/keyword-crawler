using HtmlAgilityPack;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace KeywordCrawler
{
    public partial class Form1 : Form
    {
        // List of visited URLs
        private HashSet<string> visitedUrls = new HashSet<string>();
        private bool isCrawling = false;
        private Queue<Tuple<string, List<string>, string, string>> urlsToCrawl = new Queue<Tuple<string, List<string>, string, string>>();


        public Form1()
        {
            InitializeComponent();

            // Initialize DataGridView
            resultsDataGridView.ColumnCount = 4;
            resultsDataGridView.Columns[0].Name = "Keyword";
            resultsDataGridView.Columns[1].Name = "Source URL";
            resultsDataGridView.Columns[2].Name = "Link Text";
            resultsDataGridView.Columns[3].Name = "Destination URL";

            // Set column widths
            resultsDataGridView.Columns[0].Width = 150;
            resultsDataGridView.Columns[1].Width = 500;
            resultsDataGridView.Columns[2].Width = 300;
            resultsDataGridView.Columns[3].Width = 1200;

            resultsDataGridView.RowTemplate.Height = 36;  // Set default row height

            // Make the "Source URL" and "Destination URL" columns a hyperlink style
            var hyperlinkStyle = new DataGridViewCellStyle { ForeColor = Color.Blue, Font = new Font(DefaultFont, FontStyle.Underline) };
            resultsDataGridView.Columns[1].DefaultCellStyle = hyperlinkStyle;
            resultsDataGridView.Columns[3].DefaultCellStyle = hyperlinkStyle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
            textBox2.Clear();
        }

        private CancellationTokenSource cts = new CancellationTokenSource();

        private async void startCrawlBtn_Click(object sender, EventArgs e)
        {
            if (!isCrawling)
            {
                // Ensure any lingering tasks have had a chance to stop
                await Task.Delay(500); // or some other appropriate delay

                string url = textBox1.Text;
                var keywords = listBox1.Items.Cast<string>().ToList();

                // Start the crawl
                isCrawling = true;
                startCrawlBtn.Text = "Stop Crawl";
                cts = new CancellationTokenSource();  // Reset the cancellation token source

                if (urlsToCrawl.Count == 0)
                {
                    urlsToCrawl.Enqueue(Tuple.Create(url, keywords, "", ""));
                }

                while (urlsToCrawl.Count > 0 && isCrawling)
                {
                    var crawlTarget = urlsToCrawl.Dequeue();
                    await CrawlWebsite(crawlTarget.Item1, crawlTarget.Item2, crawlTarget.Item3, crawlTarget.Item4, cts.Token);
                }
            }
            else
            {
                // Stop the crawl
                isCrawling = false;
                startCrawlBtn.Text = "Start Crawl";
                cts.Cancel();  // Signal to cancel all tasks

                // Clear the queue of URLs to crawl
                urlsToCrawl.Clear();

                // Ensure all tasks have a chance to stop
                await Task.Delay(500); // or some other appropriate delay
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!textBox1.Text.StartsWith("https://"))
                {
                    textBox1.Text = "https://" + textBox1.Text;
                }
            }
            else
            {
                if (textBox1.Text.StartsWith("https://"))
                {
                    textBox1.Text = textBox1.Text.Substring(8);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async Task CrawlWebsite(string url, List<string> keywords, string parentUrl = "", string linkText = "", CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
                return;

            url = new Uri(url).GetLeftPart(UriPartial.Path);

            string baseUrlHost = new Uri(textBox1.Text).Host;

            try
            {
                if (!visitedUrls.Add(url))
                {
                    return;
                }

                var web = new HtmlWeb();
                var doc = await web.LoadFromWebAsync(url);
                statusDisplay.Text = $"Crawling: {linkText} on {url}";

                var statusCode = web.StatusCode;
                string errorType = GetErrorType(statusCode);
                if (!string.IsNullOrEmpty(errorType))
                {
                    resultsDataGridView.Invoke((MethodInvoker)delegate
                    {
                        resultsDataGridView.Rows.Add(errorType, parentUrl, linkText, url);
                    });
                    return;
                }

                foreach (var keyword in keywords)
                {
                    List<HtmlNode> keywordNodes;
                    if (exactMatchCheckBox.Checked)
                    {
                        keywordNodes = doc.DocumentNode.DescendantsAndSelf()
                            .Where(n => n.NodeType == HtmlNodeType.Text && n.InnerText.ToLower().Split(new[] { ' ', '\t', '\n', '\r', '.', ',' }, StringSplitOptions.RemoveEmptyEntries).Contains(keyword.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        keywordNodes = doc.DocumentNode.SelectNodes($"//*[contains(translate(text(), '{keyword.ToUpper()}', '{keyword.ToLower()}'), '{keyword.ToLower()}')]")?.ToList();
                    }

                    if (keywordNodes != null && keywordNodes.Count > 0)
                    {
                        bool rowExists = resultsDataGridView.Rows.Cast<DataGridViewRow>()
                            .Any(row => row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(keyword)
                                    && row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals(parentUrl)
                                    && row.Cells[2].Value != null && row.Cells[2].Value.ToString().Equals(linkText)
                                    && row.Cells[3].Value != null && row.Cells[3].Value.ToString().Equals(url));

                        if (!rowExists)
                        {
                            resultsDataGridView.Invoke((MethodInvoker)delegate
                            {
                                resultsDataGridView.Rows.Add(keyword, parentUrl, linkText, url);
                            });
                        }
                    }
                }

                var linkNodes = doc.DocumentNode.SelectNodes("//a[@href]");
                if (isCrawling && linkNodes != null)
                {
                    foreach (var linkNode in linkNodes)
                    {
                        string hrefValue = linkNode.GetAttributeValue("href", string.Empty);

                        string linkUrl = new Uri(new Uri(url), hrefValue).AbsoluteUri;

                        if (new Uri(linkUrl).Host == baseUrlHost)
                        {
                            string cleanedLinkText = linkNode.InnerText.TrimStart(' ', '\n', '\r').TrimEnd();
                            string quotedLinkText = $"\"{cleanedLinkText}\"";

                            await Task.Delay((int)numericUpDown1.Value);

                            statusDisplay.Invoke((MethodInvoker)delegate
                            {
                                statusDisplay.Text = $"Crawling: {quotedLinkText} on {linkUrl}";
                            });

                            urlsToCrawl.Enqueue(Tuple.Create(linkUrl, keywords, url, quotedLinkText));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while crawling: {ex.Message}");
            }
            finally
            {
                if (urlsToCrawl.Count == 0)
                {
                    statusDisplay.Text = "Crawl complete.";
                }
            }
        }



        private string GetErrorType(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    return "404 (Not Found)";
                case HttpStatusCode.InternalServerError:
                    return "500 (Internal Server Error)";
                case HttpStatusCode.MovedPermanently:
                    return "301 (Moved Permanently)";
                case HttpStatusCode.Found:
                    return "302 (Found)";
                case HttpStatusCode.Forbidden:
                    return "403 (Forbidden)";
                case HttpStatusCode.Unauthorized:
                    return "401 (Unauthorized)";
                default:
                    return null;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void resultsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resultsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // If it's the "Source URL" or "Destination URL" column
            if (e.ColumnIndex == resultsDataGridView.Columns["Source URL"].Index || e.ColumnIndex == resultsDataGridView.Columns["Destination URL"].Index)
            {
                // Open the link in a web browser when the cell is clicked
                var cellValue = resultsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (cellValue != null)
                {
                    string url = cellValue.ToString();

                    // Open the URL in the default browser
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show a SaveFileDialog to specify the file location to save the CSV file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Export Results as CSV";
            saveFileDialog.FileName = "results.csv"; // Default file name

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open the file and write the CSV content
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Write the CSV header
                        StringBuilder header = new StringBuilder();
                        foreach (DataGridViewColumn column in resultsDataGridView.Columns)
                        {
                            header.Append('"' + column.HeaderText + '"' + ",");
                        }
                        sw.WriteLine(header.ToString().TrimEnd(','));

                        // Write each row of the DataGridView as a CSV line
                        foreach (DataGridViewRow row in resultsDataGridView.Rows)
                        {
                            StringBuilder line = new StringBuilder();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                line.Append('"' + cell.Value?.ToString() + '"' + ",");
                            }
                            sw.WriteLine(line.ToString().TrimEnd(','));
                        }

                        MessageBox.Show("Results exported successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting results: " + ex.Message);
                }
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}