using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basics.Files;
using Basics.Formats;

namespace UI
{
    
    public partial class Videos_UserControl : UserControl
    {
        public List<Video_file> files = new List<Video_file>();

        public string Chosen_format;

        public string Chosen_type;

        public string Chosen_quality;

        private bool CheckIfFormatAndTypeIs(string format, string type, List<string> items)
        {
            if (items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type)).Count == 0 || items.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void VideoChoosing()
        {
            var boxes = from DataGridViewRow row in VideoGridView.Rows
                        select (DataGridViewComboBoxCell)row.Cells[4];
            foreach (var box in boxes)
            {
                List<string> items;
                items = box.Items.Cast<string>().ToList();
                switch (Chosen_quality)
                {
                    case "best":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                             box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type)).First();

                        }
                        else
                        {
                            goto default; 
                        }
                        break;
                    case "high":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.Find(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type) && (x.ToLower().Contains("1080p") || x.ToLower().Contains("720p") || x.ToLower().Contains("1080p60") || x.ToLower().Contains("720p60")));
                        }
                        else
                        {  
                            goto default;
                        }
                        break;
                    case "medium":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.Find(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type) && (x.ToLower().Contains("480p") || x.ToLower().Contains("360p")));
                        }
                        else
                        {
                            
                            goto default;
                        }
                        break;
                    case "low":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.Find(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type) && (x.ToLower().Contains("240p") || x.ToLower().Contains("144p")));
                        }
                        else
                        {
                            goto default;
                        }
                        break;
                    case "worst":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type)).Last();
                        }
                        else
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_type)).Last();

                        }
                        break;
                    default:
                        box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_type)).First();
                        break;


                }

            }
        }

        private void AudioChoosing()
        {
            var boxes = from DataGridViewRow row in VideoGridView.Rows
                        select (DataGridViewComboBoxCell)row.Cells[4];
            foreach (var box in boxes)
            {
                List<string> items;
                items = box.Items.Cast<string>().ToList();
                switch (Chosen_quality)
                {
                    case "best":
                        if(CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type)).First();
                        }
                        else
                        {
                            
                            goto default;
                        }
                        break;
                    case "high":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type))[1];
                        }
                        else
                        {
                            goto default;
                        }
                        break;
                    case "medium":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                             box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type))[2];
                        }
                        else
                        {
                           goto default;
                        }
                        break;
                    case "low":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type))[3];
                        }
                        else
                        {
                            goto default;
                        }
                        break;
                    case "worst":
                        if (CheckIfFormatAndTypeIs(Chosen_format,Chosen_type,items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_type) && x.ToLower().Contains(Chosen_format)).Last();
                        }
                        else
                        {
                            box.Value = items.FindAll(x=>x.ToLower().Contains(Chosen_type)).Last();
                        }
                        break;
                    default:
                        if (items.Count != 0)
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_type)).First();
                        }
      
                        break;
                }

            }
        }

        private void MixedChoosing()
        {
            var boxes = from DataGridViewRow row in VideoGridView.Rows
                        select (DataGridViewComboBoxCell)row.Cells[4];
            foreach (var box in boxes)
            {
                List<string> items;
                items = box.Items.Cast<string>().ToList();
                switch (Chosen_quality)
                {
                    case "best":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type)).First();
                        }
                        else
                        {

                            goto default;
                        }
                        break;

                    case "high":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type) && x.ToLower().Contains("hd720")).First();
                        }
                        else
                        {

                            goto default;
                        }
                        break;
                    case "medium":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type)&& x.ToLower().Contains("medium")).First();
                        }
                        else
                        {

                            goto default;
                        }
                        break;
                    case "low":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type)).First();
                        }
                        else
                        {

                            goto default;
                        }
                        break;
                    case "worst":
                        if (CheckIfFormatAndTypeIs(Chosen_format, Chosen_type, items))
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_format) && x.ToLower().Contains(Chosen_type)).Last();
                        }
                        else
                        {
                            box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_type)).Last();
                        }
                        break;
                    default:
                        box.Value = items.FindAll(x => x.ToLower().Contains(Chosen_type)).First();
                        break;
                }

            }
        }

        private void ChangeComboBoxes()
        {
            if (Chosen_format != null  && Chosen_quality != null)
            {
                switch (Chosen_type)
                {
                    case "video":
                        VideoChoosing();
                        break;
                    case "audio":
                        AudioChoosing();
                        break;
                    case "mixed":
                        MixedChoosing();
                        break;
                }
              

            }
        }

        public Videos_UserControl()
        {
            InitializeComponent();


        }

        public class RowComparer : System.Collections.IComparer
        {
            private static int sortOrderModifier = 1;

            public RowComparer(SortOrder sortOrder)
            {
                if (sortOrder == SortOrder.Descending)
                {
                    sortOrderModifier = -1;
                }
                else if (sortOrder == SortOrder.Ascending)
                {
                    sortOrderModifier = 1;
                }
            }
            public int Compare(object x, object y)
            {
                DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;
                int CompareResult;
                if (Int32.Parse(DataGridViewRow1.Cells[1].Value.ToString()) > Int32.Parse(DataGridViewRow2.Cells[1].Value.ToString()))
                {
                    CompareResult = 1;

                }
                else if (Int32.Parse(DataGridViewRow1.Cells[1].Value.ToString()) < Int32.Parse(DataGridViewRow2.Cells[1].Value.ToString()))
                {
                    CompareResult = -1;

                }
                else
                {
                    CompareResult = 0;
                }

                return CompareResult * sortOrderModifier;
            }
        }

        private void VideoGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (VideoGridView.Columns[1].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                {

                    VideoGridView.Sort(new RowComparer(SortOrder.Descending));
                    VideoGridView.Columns[1].HeaderCell.SortGlyphDirection = SortOrder.Descending;

                }
                else if (VideoGridView.Columns[1].HeaderCell.SortGlyphDirection == SortOrder.Descending)
                {

                    VideoGridView.Sort(new RowComparer(SortOrder.Ascending));
                    VideoGridView.Columns[1].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
    
                }
                else
                {

                    VideoGridView.Sort(new RowComparer(SortOrder.Descending));
                    VideoGridView.Columns[1].HeaderCell.SortGlyphDirection = SortOrder.Descending;

                }

            }
            else
            {
                VideoGridView.Columns[1].HeaderCell.SortGlyphDirection = SortOrder.None;
            }




        }

        private void VideoGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 4)
                {
                    VideoGridView.BeginEdit(true);
                    ((ComboBox)VideoGridView.EditingControl).DroppedDown = true;
                }
            }
        }

        private void AllBox_Click(object sender, EventArgs e)
        {
            if(AllBox.Checked == false)
            {
                AllBox.Checked = true;
                foreach (DataGridViewRow row in VideoGridView.Rows)
                {
                    DataGridViewCheckBoxCell a = (DataGridViewCheckBoxCell)row.Cells[0];
                    a.Value = true;
                }
            }
            else
            {
                AllBox.Checked = false;
                foreach (DataGridViewRow row in VideoGridView.Rows)
                {
                    DataGridViewCheckBoxCell a = (DataGridViewCheckBoxCell)row.Cells[0];
                    a.Value = false;
                }

            }
        }

        private void VideoGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {

                    DataGridViewCheckBoxCell c = (DataGridViewCheckBoxCell)VideoGridView.Rows[e.RowIndex].Cells[0];
                    if (c.Value != null)
                    {
                        if (AllBox.Checked)
                        {
                            AllBox.Checked = false;

                        }

                    }

                }

            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            VideoGridView.Rows.Clear();
            VideoGridView.Refresh();
        }

        private void Type_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Format_box.Enabled = true;
            Chosen_type = Type_box.SelectedItem.ToString().ToLower();
            ChangeComboBoxes();



        }

        private void Format_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Quality_Box.Enabled = true;
            Chosen_format = Format_box.SelectedItem.ToString().ToLower();
            ChangeComboBoxes();

        }

        private void Quality_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chosen_quality = Quality_Box.SelectedItem.ToString().ToLower();
            ChangeComboBoxes();
        }

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, Task> download_tasks = new Dictionary<string, Task>();
            var checkedRows = from DataGridViewRow row in VideoGridView.Rows
                              where Convert.ToBoolean(row.Cells[0].Value) == true
                              select row;
            var NrValues = from DataGridViewRow row in checkedRows
                           select Int32.Parse((string)row.Cells[1].Value);
            var cellValues = from DataGridViewRow row in checkedRows
                             select (string)row.Cells[4].Value;
            var  files_selected = from Video_file file in files
                                              where NrValues.Contains(file.video_info.info.positsion)
                                              select file;

            var files_Selected_with_streams = from Video_file stream in files_selected
                                              select new KeyValuePair<Video_file, Format_Stream>(stream, stream.video_info.streams.Find(x => cellValues.Contains(x.info.label)));

            await Task.Run(() =>
            {
                foreach (var file in files_Selected_with_streams.Where(x=>x.Value!=null))
                {

                        download_tasks.Add(file.Key.video_info.info.id, file.Key.Download_file(file.Value));

                    
                }
                Task.WaitAll(download_tasks.Values.ToArray());


            });

            if (TagBox.Checked)
            {
                await Task.Run(() =>
                {
                    foreach (var file in files_selected.Where(x=>x.video_info.info.title != "Unavailable video"))
                    {
                        file.Tagger();
                    }
                });
                MessageBox.Show("Done downloading and tagging the files!", "Action complete");

            }
            else
            {
                MessageBox.Show("Done downloading files!", "Action complete");
            }

        }

        private void TagBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TagBox.Checked)
            {
                var result = MessageBox.Show("Are you sure you want to tag the files?\nChecking this option means you might not get your wanted format", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    TagBox.Checked = true;
                }
                else
                {
                    TagBox.Checked = false;
                }
            }
          
        }

        private void Change_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderBrowser.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                var checkedRows = from DataGridViewRow row in VideoGridView.Rows
                                  where Convert.ToBoolean(row.Cells[0].Value) == true
                                  select row;
                var NrValues = from DataGridViewRow row in checkedRows
                               select Int32.Parse((string)row.Cells[1].Value);

                var files_selected = from Video_file file in files
                                     where NrValues.Contains(file.video_info.info.positsion)
                                     select file;
                foreach (var file in files_selected)
                {
                    file.path = FolderBrowser.SelectedPath + "\\";
                }
                MessageBox.Show("Done changing paths!", "Action complete");
            }
        }

      

    }
}
