using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace grouvee_gamelib_filter
{
    public partial class Form1 : Form
    {
        private struct Entry
        {
            public string game_name { get; set; }
            public int date_started { get; set; }
            public int date_finished { get; set; }
        }

        List<Entry> entries = new List<Entry>();

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add(GetDefaultFilter());
            comboBox1.SelectedIndex = 0;

            RefreshInfo();

            MinimumSize = Size;
        }

        private string GetDefaultFilter()
        {
            return "None";
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
            List<string[]> lines = new List<string[]>();
            Dictionary<string, int> headerToIndex = new Dictionary<string, int>();

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

            List<Entry> toDiskEntries = new List<Entry>();

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

                int nameIndex = -1;
                headerToIndex.TryGetValue("name", out nameIndex);

                Entry entry = new Entry();
                entry.game_name = line[nameIndex];
                entry.date_started = date_started.Year;
                entry.date_finished = date_finished.Year;

                toDiskEntries.Add(entry);
            }

            using (StreamWriter r = new StreamWriter(GetPathToTempData()))
            {
                string json = System.Text.Json.JsonSerializer.Serialize<List<Entry>>(toDiskEntries);
                r.Write(json);
            }

            RefreshInfo();
        }

        private struct Item
        {
            public string date_started { get; set; }
            public string date_finished { get; set; }
        }

        private bool IsValidDate(int dateOnly)
        {
            return dateOnly != DateOnly.MaxValue.Year;
        }

        private bool PassesFilter(int date_started, int date_finished)
        {
            if (comboBox1.SelectedIndex == 0)
                return true;

            int selectedItem = (int)comboBox1.SelectedItem;
            return selectedItem == date_started || selectedItem == date_finished;
        }

        private string GetPathToTempData()
        {
            string folderName = $@"{Path.GetTempPath()}/grouvee_gamelib_filter/";
            if (!System.IO.Directory.Exists(folderName))
            {
                System.IO.Directory.CreateDirectory(folderName);
            }

            return $@"{folderName}/entries.json";
        }

        private void LoadFromDisk()
        {
            entries.Clear();

            try
            {
                using (StreamReader r = new StreamReader(GetPathToTempData()))
                {
                    string json = r.ReadToEnd();
                    entries = System.Text.Json.JsonSerializer.Deserialize<List<Entry>>(json);
                }
            }
            catch { }
        }

        private void RefreshInfo()
        {
            LoadFromDisk();

            SortedSet<int> years = new SortedSet<int>();
            foreach (Entry entry in entries)
            {
                if (IsValidDate(entry.date_started))
                {
                    years.Add(entry.date_started);
                }
                if (IsValidDate(entry.date_finished))
                {
                    years.Add(entry.date_finished);
                }
            }

            var previousSelection = comboBox1.SelectedItem;
            comboBox1.Items.Clear();
            comboBox1.Items.Add(GetDefaultFilter());
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            foreach (int year in years)
            {
                comboBox1.Items.Add(year);
            }
            comboBox1.SelectedItem = previousSelection;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            panel2.Controls.Clear();

            foreach (Entry entry in entries)
            {
                if (!PassesFilter(entry.date_started, entry.date_finished))
                {
                    continue;
                }

                UserControl1 control = new UserControl1();
                string game_name = entry.game_name;
                string date_started = (IsValidDate(entry.date_started) ? entry.date_started.ToString() : "");
                string date_finished = (IsValidDate(entry.date_finished) ? entry.date_finished.ToString() : "");

                control.label1.Text = $"{game_name}";

                if (date_started.Length != 0 && date_finished.Length != 0 && date_started != date_finished)
                {
                    control.label2.Text = $"({date_started}-{date_finished})";
                }
                else if (date_started.Length != 0)
                {
                    control.label2.Text = $"({date_started})";
                }
                else
                {
                    control.label2.Text = $"({date_finished})";
                }

                int count = panel2.Controls.Count;
                Point location = new Point(control.Location.X, 0);
                location.Y = count * control.Size.Height;
                control.Location = location;
                panel2.Controls.Add(control);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }
    }
}