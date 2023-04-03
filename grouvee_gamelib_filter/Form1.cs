using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;

namespace grouvee_gamelib_filter
{
    public partial class Form1 : Form
    {
        List<string[]> lines = new List<string[]>();
        Dictionary<string, int> headerToIndex = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            lines.Clear();
            headerToIndex.Clear();

            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            using (TextFieldParser parser = new TextFieldParser(fileList[0]))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    lines.Add(fields);
                }
            }

            for (int i = 0; i < lines[0].Length; i++)
            {
                headerToIndex[lines[0][i]] = i;
            }

            lines.RemoveAt(0);

            RefreshInfo();
        }
        private struct Item
        {
            public string date_started { get; set; }
            public string date_finished { get; set; }
        }

        private bool IsValidDate(DateOnly dateOnly)
        {
            return dateOnly != DateOnly.MaxValue;
        }
        private bool PassesFilter(Item item, DateOnly date_started, DateOnly date_finished)
        {
            if (numericUpDown1.Value != numericUpDown1.Minimum)
            {
                if (numericUpDown1.Value != date_started.Year && numericUpDown1.Value != date_finished.Year)
                {
                    return false;
                }
            }
            return true;
        }

        private void RefreshInfo()
        {
            textBox1.Clear();

            foreach (string[] line in lines)
            {
                int datesIndex = -1;
                headerToIndex.TryGetValue("dates", out datesIndex);
                string json = line[datesIndex];

                List<Item> items = System.Text.Json.JsonSerializer.Deserialize<List<Item>>(json);
                if (items.Count == 0)
                {
                    continue;
                }

                Item item = items[0];

                DateOnly date_started;
                try
                {
                    date_started = DateOnly.Parse(item.date_started);
                }
                catch
                {
                    date_started = DateOnly.MaxValue;
                }

                DateOnly date_finished;
                try
                {
                    date_finished = DateOnly.Parse(item.date_finished);
                }
                catch
                {
                    date_finished = DateOnly.MaxValue;
                }

                if (!PassesFilter(item, date_started, date_finished))
                {
                    continue;
                }

                int nameIndex = -1;
                headerToIndex.TryGetValue("name", out nameIndex);
                textBox1.Text += line[nameIndex];

                textBox1.Text += " | Started: " + (IsValidDate(date_started) ? date_started.Year : "N/A");
                textBox1.Text += " | Finished: " + (IsValidDate(date_finished) ? date_finished.Year : "N/A");
                textBox1.Text += Environment.NewLine;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }
    }
}