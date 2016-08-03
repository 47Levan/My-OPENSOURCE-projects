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
using System.Windows.Threading;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using MusicTagger;
namespace MusicSorter
{
    /// <summary>
    /// Interaction logic for AskReplace.xaml
    /// </summary>
    public partial class AskReplace : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        private string FileToReplace;
        private string viewNameofFile;
        public string ViewNameOfFile
        {
            get
            {
                return viewNameofFile;
            }
            set
            {
                viewNameofFile = value;
                RunProperty("ViewNameOfFile");
               
            }
        }
        public AskReplace()
        {
            InitializeComponent();
        }
    
        public AskReplace(string userFileToReplace,Button buttonToCancel)
        {
          
                InitializeComponent();
                FileToReplace = userFileToReplace;
                ViewNameOfFile = "File " + userFileToReplace.Substring(userFileToReplace.LastIndexOf(@"\") + 1) + " is exist" + "\n" + "do you want to replace it";
                buttonToCancel.Click += CancelOperation;
           
        }
        private void CancelOperation(object sender,RoutedEventArgs e)
        {
            if (this!=null)
            {
                this.Close();
            }
        }      
        private void RunProperty(string propertyName)
        {
            PropertyChanged +=OnPropertyChanged;
            var handler = PropertyChanged;
            if (handler!=null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FileText.Text = ViewNameOfFile;
        }
        private void ReplaceFile(object sender,RoutedEventArgs e)
        {           
                MusicTag.toReplace = true;
               
                this.Close();
        }
        private void SkipFile(object sender, RoutedEventArgs e)
        {
            MusicTag.toReplace = false;      
            this.Close();
        }
        private void ProceedAll(object sender,RoutedEventArgs e)
        {
            if((sender as Button)==ReplaceAllButton)
            {
                MusicTag.toReplaceOrSkipAll = true;
            }
            else if((sender as Button) == SkipAllButton)
            {
                MusicTag.toReplaceOrSkipAll = false;
            }
            this.Close();
        }
    }
}
