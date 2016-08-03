using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Threading;
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;
using System.Threading;
using TagLib;
using System.Text.RegularExpressions;
using MusicTagger;
using FileCommander = System.IO;
namespace MusicSorter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {    
        SemaphoreSlim sem = new SemaphoreSlim(0,1);
        public bool toCancel = false;
        AskReplace ask;
        public MainWindow()
        {
       
            InitializeComponent();
           
        }
     
        private void BrowseButton(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.ShowDialog();
                if (sender==BrowseSort)
                {
                    SelectedPath.Text = fb.SelectedPath;
                }
                else if (sender==BrowseCopy)
                {
                    PathToCopy.Text = fb.SelectedPath;
                }
            }
           
        }
    
        private async  void OkButton(object sender,RoutedEventArgs e)
        {
           
            ButtonToOk.IsHitTestVisible = false;
            if (SelectedPath.Text != "" && PathToCopy.Text != "" && (ArtistCheckBox.IsChecked==true || YearCheckBox.IsChecked==true || GenreCheckBox.IsChecked==true) && this.IsVisible)
            {
                string[] ListOfFiles = Directory.GetFiles(SelectedPath.Text, "*.mp3");
                SortProgress.Maximum = ListOfFiles.Length - 1;
                for (int i = 0; i < ListOfFiles.Length; i++)
                {
                    string DestinationPath = PathToCopy.Text;
                    MusicTag musicTag = new MusicTag(ListOfFiles[i], DestinationPath,
                        i, ViewProgress, SortProgress, ButtonToCancel);
                    if ((bool)GenreCheckBox.IsChecked)
                    {

                        //musicTag.sortByGenre();
                        musicTag.sortByCustomCriteria("FirstGenre");
                    }
                    else if ((bool)YearCheckBox.IsChecked)
                    {
                        musicTag.sortByYear();

                    }
                    else if ((bool)ArtistCheckBox.IsChecked)
                    {
                        //  musicTag.sortByArtist();
                        musicTag.sortByCustomCriteria("FirstPerformer");
                    }
                    if (toCancel)
                    {
                        toCancel = false;
                        MusicTag.toReplaceOrSkipAll = null;
                        ButtonToOk.IsHitTestVisible = true;
                        return;
                    }
                    Dispatcher.Invoke(new Action(() =>
                    {
                        if (toCancel==false)
                        {
                            SortProgress.Value = i;
                        }
                    })
                   , DispatcherPriority.Background);
                    if (toCancel == false)
                    {
                        ViewProgress.Text = ListOfFiles[i];
                    }                   
                    CopyFile(ListOfFiles[i], MusicTag.DestinationPath);
                    await sem.WaitAsync();               
                }
                ViewProgress.Text = "Work Done";
            }
            MusicTag.toReplaceOrSkipAll = null;
            ButtonToOk.IsHitTestVisible = true;
        }
        private void CancelButton(object sender,RoutedEventArgs e)
        {         
            ViewProgress.Text ="Operation Canceled";
            toCancel = true;
           
            ButtonToOk.IsHitTestVisible = true;
            Dispatcher.Invoke(new Action(() =>
            {
                SortProgress.Value = 0;
            }));
           
        }
        private   void CopyFile(string from, string to)
        {
            if (!FileCommander.File.Exists(to))
            {
                FileCommander.File.Copy(from, to);
                sem.Release();
            }
            /**/
            else
            {
                if (MusicTag.toReplaceOrSkipAll==null)
                {
                    if (!MusicTag.dontCreateWindow)
                    {
                        ask = new AskReplace(MusicTag.DestinationPath, ButtonToCancel);
                        ask.Owner = this;
                        ask.Closed += (a, b) => { sem.Release(); };
                        ask.Show();
                    }
                }
                else
                {
                    sem.Release();
                }
                if (MusicTag.toReplace == true || MusicTag.toReplaceOrSkipAll==true)
                    {
                        FileCommander.File.Delete(to);
                        FileCommander.File.Copy(from, to);
                    }
               
                MusicTag.toReplace = null;

            }
        }
     
        #region checkBox Methods
        private void GenreCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            YearCheckBox.IsChecked = false;
            ArtistCheckBox.IsChecked = false;
        }

        private void YearCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GenreCheckBox.IsChecked = false;
            ArtistCheckBox.IsChecked = false;
        }

        private void ArtistCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GenreCheckBox.IsChecked = false;
            YearCheckBox.IsChecked = false;
        }
        #endregion

        private void window_Closed(object sender, EventArgs e)
        {
            
            MusicTag.dontCreateWindow = true;
            App.Current.Shutdown();
        }
  
    }
}
