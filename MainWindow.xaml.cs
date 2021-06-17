using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace BioDNA2mRNA {
    
    public partial class MainWindow : Window {

        string DNAinput;
        string DNAoutput;
        string mRNAinput;
        string mRNAoutput;
        string tRNAinput;
        string tRNAoutput;

        enum Convert2 {DNA,mRNA,tRNA};

        public MainWindow() {
            InitializeComponent();
            FromDNAcheckbox.Click += FromDNAcheckbox_Click;
            FrommRNAcheckbox.Click += FrommRNAcheckbox_Click;
            FromtRNAcheckbox.Click += FromtRNAcheckbox_Click;
            DNAinputBox.IsEnabled = false;
            mRNAinputBox.IsEnabled = false;
            tRNAinputBox.IsEnabled = false;
        }

        

        void resetValues() {
            DNAinput = null;
            DNAoutput = null;
            mRNAinput = null;
            mRNAoutput = null;
            tRNAinput = null;
            tRNAoutput = null;
        }

        private void Start_Click(object sender, RoutedEventArgs e) {
            if ((bool)FromDNAcheckbox.IsChecked) {
                DNAinput = DNAinputBox.Text.ToString();
                Debug.WriteLine(DNAinput);
                //Get mRNA fromn DNA
                mRNAoutput = umwandeln(Convert2.mRNA, DNAinput);
                //Get tRNA from 
                mRNAinputBox.Text = mRNAoutput;
                umwandeln(Convert2.tRNA, tRNAinput);
            }
            if ((bool)FrommRNAcheckbox.IsChecked) {
                mRNAinput = mRNAinputBox.Text.ToString();
                Debug.WriteLine(mRNAinput);
                umwandeln(Convert2.DNA, mRNAinput);
                umwandeln(Convert2.tRNA, tRNAinput);
            }
            if ((bool)FromtRNAcheckbox.IsChecked) {
                tRNAinput = tRNAinputBox.Text.ToString();
                Debug.WriteLine(tRNAinput);
                umwandeln(Convert2.mRNA, tRNAinput);
                umwandeln(Convert2.DNA, tRNAinput);
            }
        }

        string umwandeln(Convert2 target, string s) {
            List<Char> newString = new List<char>();
            
            if (target == Convert2.DNA) {
                
            }
            if (target == Convert2.mRNA) {
                for (int i = 0; i < s.Length; i++) {
                    char c = s[i];
                    if (c == 'A' || c == 'a') {
                        newString.Add('U');
                    }
                    if (c == 'G' || c == 'g') {
                        newString.Add('C');
                    }
                    if (c == 'C' || c == 'c') {
                        newString.Add('G');
                    }
                    if (c == 'T' || c == 't') {
                        newString.Add('A');
                    }
                }
            }
            if (target == Convert2.tRNA) {

            } 
            
            char[] chararray = newString.ToArray();
            string _s = new String(chararray);
            Debug.WriteLine(_s);
            return _s;
        }

        #region UI Stuff
        private void FromtRNAcheckbox_Click(object sender, RoutedEventArgs e) {
            resetValues();
            if ((bool)FromtRNAcheckbox.IsChecked) {
                DNAinputBox.IsEnabled = false;
                mRNAinputBox.IsEnabled = false;
                tRNAinputBox.IsEnabled = true;
                FrommRNAcheckbox.IsChecked = false;
                FromDNAcheckbox.IsChecked = false;
            }
            else {
                DNAinputBox.IsEnabled = true;
                mRNAinputBox.IsEnabled = true;
                tRNAinputBox.IsEnabled = true;
                FrommRNAcheckbox.IsChecked = false;
                FromDNAcheckbox.IsChecked = false;
            }
        }

        private void FrommRNAcheckbox_Click(object sender, RoutedEventArgs e) {
            resetValues();
            if ((bool)FrommRNAcheckbox.IsChecked) {
                DNAinputBox.IsEnabled = false;
                mRNAinputBox.IsEnabled = true;
                tRNAinputBox.IsEnabled = false;
                FromtRNAcheckbox.IsChecked = false;
                FromDNAcheckbox.IsChecked = false;
            }
            else {
                DNAinputBox.IsEnabled = true;
                mRNAinputBox.IsEnabled = true;
                tRNAinputBox.IsEnabled = true;
                FromtRNAcheckbox.IsChecked = false;
                FromDNAcheckbox.IsChecked = false;
            }

        }

        private void FromDNAcheckbox_Click(object sender, RoutedEventArgs e) {
            resetValues();
            if ((bool)FromDNAcheckbox.IsChecked) {
                DNAinputBox.IsEnabled = true;
                mRNAinputBox.IsEnabled = false;
                tRNAinputBox.IsEnabled = false;
                FrommRNAcheckbox.IsChecked = false;
                FromtRNAcheckbox.IsChecked = false;
            }
            else {
                DNAinputBox.IsEnabled = true;
                mRNAinputBox.IsEnabled = true;
                tRNAinputBox.IsEnabled = true;
                FrommRNAcheckbox.IsChecked = false;
                FromtRNAcheckbox.IsChecked = false;
            }
        }
        #endregion
    }
}
