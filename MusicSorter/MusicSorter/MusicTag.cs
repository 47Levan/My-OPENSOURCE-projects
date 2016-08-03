using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using TagLib;
using FileCommander = System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Data;
using System.ComponentModel;
using WData = System.Windows.Data;
using Controls = System.Windows.Controls;
using MusicSorter;
namespace MusicTagger
{
    public class MusicTag
    {
        #region Initialize commonFields
        public static bool dontCreateWindow=false;
        public static string DestinationPath;      
        Regex replacePattern;
     //   private string[] ListOfFiles;
        private string SelectedPath;
        private string PathToCopy;
        private TextBlock ViewProgress;
        private Controls.ProgressBar SortProgress;
        public static bool? toReplace=null;
        public static bool? toReplaceOrSkipAll = null;
        #endregion
        public MusicTag(string UserSelectedPath, string UserPathToCopy,int userCount,TextBlock UserViewProgress, Controls.ProgressBar UserSortProgress,Controls.Button UserCancel)
        {
           
        
           // ButtonToCancel.Click +=CancelClick;
            SelectedPath = UserSelectedPath;
            PathToCopy = UserPathToCopy;
            replacePattern = new Regex("[|]");
            //ListOfFiles = Directory.GetFiles(SelectedPath, "*.mp3");
            ViewProgress = UserViewProgress;
            SortProgress = UserSortProgress;
           
        }
        //private void CancelClick(object sender,RoutedEventArgs e)
        //{
        //    if (Genreworker!=null)
        //        Genreworker.CancelAsync();
        //    if (Yearworker != null)
        //        Yearworker.CancelAsync();
        //    if (Artistworker!=null)
        //        Artistworker.CancelAsync();
        //}

        #region sort methods
        internal void sortByCustomCriteria(string criteria)
        {
            TagLib.File fileTag = TagLib.File.Create(SelectedPath);
            Tag tag = fileTag.Tag;
            string getTag = "";
            getTag = (string)tag.GetType().GetProperty(criteria).GetValue(tag);
            if (getTag != null)
            {
                getTag = replacePattern.Replace(getTag, " ");
            }
            DirectoryInfo dirinfo = Directory.CreateDirectory(PathToCopy + @"\" + getTag);
            DestinationPath = dirinfo.FullName + @"\" + SelectedPath.Substring(SelectedPath.LastIndexOf(@"\") + 1);
        }
      
        internal void sortByYear()
        {
           
            TagLib.File fileTag = TagLib.File.Create(SelectedPath);
            Tag tag = fileTag.Tag;
            string Year = "";
           
            if (tag.Year != 0)
            {
                Year = replacePattern.Replace(tag.Year.ToString(), " ");
            }
            DirectoryInfo dirinfo = Directory.CreateDirectory(PathToCopy + @"\" + Year);
            DestinationPath = dirinfo.FullName + @"\" + SelectedPath.Substring(SelectedPath.LastIndexOf(@"\") + 1);
          
        }
        
     

     
        #endregion

    }
}
