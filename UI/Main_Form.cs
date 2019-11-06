using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basics.Formats;
using Basics.Files;
using Basics;
namespace UI
{

    public partial class UserI : Form
    {


        public UserI()
        {
            InitializeComponent();

        }

        public void VideoInfoDoneHandler(Video_file file)
        {
            
            Console.WriteLine("Event triggred");
            object[] Row;
            if (Videos_control.AllBox.Checked == true)
            {
                Row = new object[] { true, file.video_info.info.positsion.ToString(), file.video_info.info.id, file.video_info.info.title};
            }
            else
            {
                Row = new object[] { null, file.video_info.info.positsion.ToString(), file.video_info.info.id, file.video_info.info.title   };
            }
            Videos_control.VideoGridView.Rows.Add(Row);
            if (file.video_info.streams.Count != 0)
            {
                DataGridViewComboBoxCell a = (DataGridViewComboBoxCell)Videos_control.VideoGridView.Rows[Videos_control.VideoGridView.Rows.Count - 1].Cells[4];
                List<string> formats = new List<string>();
                foreach (var stream in file.video_info.streams)
                {
                    if (!formats.Contains(stream.info.file.Remove(0, 1)))
                    {
                        formats.Add(stream.info.file.Remove(0, 1));
                    }

                    a.Items.Add(stream.info.label);
                }
                a.Value = a.Items[0];
                Videos_control.Format_box.Items.AddRange(formats.ToArray());
                List<string> items = Videos_control.Format_box.Items.Cast<string>().ToList();
                List<string> distinct = items.Distinct().ToList();
                foreach (var stringuh in distinct)
                {
                    items.Remove(stringuh);
                }
                foreach (var stringuh in items)
                {
                    Videos_control.Format_box.Items.Remove(stringuh);
                }
            }

            Videos_control.files.Add(file);
            


            

            

        }

        private void VideosButton_Click(object sender, EventArgs e)
        {
            Youtube_downloaderLabel.Location = new Point(24, 18);
            SettingsPicture.Visible = !true;
            SettingsPanel.SendToBack();
            DownloadButton.Visible = !true;
            FormatsPanel.Visible = !true;
            URLTextBox.Visible = !true;
            Videos_control.Visible = !false;
            Videos_control.BringToFront();
            Videos_control.Focus();
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            Youtube_downloaderLabel.Location = new Point(197, 18);
            SettingsPicture.Visible = true;
            SettingsPanel.BringToFront();
            DownloadButton.Visible = true;
            FormatsPanel.Visible = true;
            URLTextBox.Visible = true;
            Videos_control.Visible = false;
            Videos_control.SendToBack();
            Focus();
        }

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            if (URLTextBox.Text == "" || URLTextBox.Text == "Insert your youtube url here...")
            {
                MessageBox.Show("Type a url!");
            }
            else
            {

                if (Regex.IsMatch(URLTextBox.Text, "\\w{34}|\\w{24}|\\w{11}"))
                {
                    
                    string video_id;
                    MatchCollection ids = Regex.Matches(URLTextBox.Text, "\\w{34}|\\w{24}|\\w{11}");
                    DialogResult result = FolderBrowser.ShowDialog();
                    if (result != DialogResult.Cancel)
                    {

                        
                        string path = FolderBrowser.SelectedPath + "\\";
                        if (ids.Count == 1)
                        {

  
                            video_id = ids.OfType<Match>().First().ToString();
                            switch (video_id.Count())
                            {
                                case 11:
                                    VideosButton.PerformClick();
                                    try
                                    {
                                        Video_file video_File = new Video_file(path, new VideoFileDoneDelegate(VideoInfoDoneHandler));

                                        await video_File.Video_fileAsync(video_id);
                                        MessageBox.Show("Done gathering info about the videos\nReady to download!", "Action complete");
                                    }
                                    catch (MetadataException)
                                    {
                                        MessageBox.Show("Video is unavailable or the url is wrong");
                                        HomeButton.PerformClick();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        MessageBox.Show("Type a valid url");
                                        HomeButton.PerformClick();
                                    }
                                    break;
                                case 24:
                                    try
                                    {
                                                         VideosButton.PerformClick();
                                        Playlist playlist = new Playlist(new VideoFileDoneDelegate(VideoInfoDoneHandler));
                                        try
                                        {
                                            await playlist.PlayListAsync(video_id, path, (int)StartNumeric.Value, (int)EndNumeric.Value);
                                            VideosButton.PerformClick();
                                            MessageBox.Show("Done gathering info about the videos\nReady to download!", "Action complete");
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            MessageBox.Show("Invald index");
                                            HomeButton.PerformClick();
                                        }
                                        catch (PrivacyException)
                                        {
                                            MessageBox.Show("Private or unavailable playlist");
                                            HomeButton.PerformClick();
                                        }
                                    }
                                    catch (NullReferenceException)
                                    {
                                        MessageBox.Show("Type a valid url");
                                        HomeButton.PerformClick();
                                    }
                                    break;
                                case 34:
                                    goto case 24;
                            }
                        }

                        else
                        {
                            if((int)StartNumeric.Value == 0 && (int)EndNumeric.Value == 0)
                            {
                                DialogResult yesorno = MessageBox.Show("Do u want to download a playlist?\nChoosing no means you download a video.\nChoosing yes means you download a playlist.", "Video or playlist", MessageBoxButtons.YesNoCancel);
                                switch (yesorno)
                                {
                                    case DialogResult.No:
                                        VideosButton.PerformClick();
                                        try
                                        {
                                            video_id = ids.OfType<Match>().ToList().Find(x => x.ToString().Count() == 11).ToString();
                                            Video_file video_File = new Video_file(path, new VideoFileDoneDelegate(VideoInfoDoneHandler));

                                            await video_File.Video_fileAsync(video_id);
                                            MessageBox.Show("Done gathering info about the videos\nReady to download!", "Action complete");
                                        }
                                        catch(MetadataException)
                                        {
                                            MessageBox.Show("Video is unavailable or the url is wrong");
                                            HomeButton.PerformClick();
                                        }
                                        catch (NullReferenceException)
                                        {
                                            MessageBox.Show("Type a valid url");
                                            HomeButton.PerformClick();
                                        }
                                        

                                        break;
                                    case DialogResult.Yes:
                                        VideosButton.PerformClick();
                                        try
                                        {
                                            video_id = ids.OfType<Match>().ToList().Find(x => x.ToString().Count() == 24 || x.ToString().Count() == 34).ToString();
          
                                            Playlist playlist = new Playlist(new VideoFileDoneDelegate(VideoInfoDoneHandler));

                                            try
                                            {
                                                await playlist.PlayListAsync(video_id, path, (int)StartNumeric.Value, (int)EndNumeric.Value);
                                                MessageBox.Show("Done gathering info about the videos\nReady to download!", "Action complete");
                                            }
                                            catch (ArgumentOutOfRangeException)
                                            {
                                                MessageBox.Show("Invald index");
                                                HomeButton.PerformClick();
                                            }
                                            catch (PrivacyException)
                                            {
                                                MessageBox.Show("Private or unavailable playlist");
                                                HomeButton.PerformClick();
                                            }
                                        }
                                        catch (NullReferenceException)
                                        {
                                            MessageBox.Show("Type a valid url");
                                            HomeButton.PerformClick();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                video_id = ids.OfType<Match>().ToList().Find(x => x.ToString().Count() == 24 || x.ToString().Count() == 34).ToString();
                                Playlist playlist = new Playlist(new VideoFileDoneDelegate(VideoInfoDoneHandler));
                                VideosButton.PerformClick();
                                try
                                {
                                    await playlist.PlayListAsync(video_id, path, (int)StartNumeric.Value, (int)EndNumeric.Value);
                                    MessageBox.Show("Done gathering info about the videos\nReady to download!", "Action complete");
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    MessageBox.Show("Invald index");
                                    HomeButton.PerformClick();
                                }
                                catch (PrivacyException)
                                {
                                    MessageBox.Show("Private or unavailable playlist");
                                    HomeButton.PerformClick();
                                }
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Type a valid url!");
                }


            }

        }

        private void URLTextBox_Leave(object sender, EventArgs e)
        {
            if (URLTextBox.Text == "")
            {
                URLTextBox.Text = "Insert your youtube url here...";
            }
        }

        private void URLTextBox_Enter(object sender, EventArgs e)
        {
            if (URLTextBox.Text == "Insert your youtube url here...")
            {
                URLTextBox.Text = "";
            }
        }

   


    }
}
