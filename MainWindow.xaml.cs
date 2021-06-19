using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;


namespace BioDNA2mRNA {
    
    public partial class MainWindow : Window {

        string DNAinput;
        string DNAoutput;
        string mRNAinput;
        string mRNAoutput;
        string tRNAinput;
        string tRNAoutput;

        enum Convert2 {DNA,mRNA,tRNA};

        Dictionary<string, string> CodeSonne = new Dictionary<string, string>();
        Dictionary<string, string> Aminosäuren = new Dictionary<string, string>();

        public MainWindow() {
            InitializeComponent();
            FromDNAcheckbox.Click += FromDNAcheckbox_Click;
            FrommRNAcheckbox.Click += FrommRNAcheckbox_Click;
            FromtRNAcheckbox.Click += FromtRNAcheckbox_Click;
            DNAinputBox.IsEnabled = false;
            mRNAinputBox.IsEnabled = false;
            tRNAinputBox.IsEnabled = false;
            AddAminosäuren();
        }

        

        void resetValues() {
            DNAinput = null;
            DNAoutput = null;
            mRNAinput = null;
            mRNAoutput = null;
            tRNAinput = null;
            tRNAoutput = null;
        }

        void AddAminosäuren() {
            //Alle mit A
            CodeSonne.Add("AGG", "Arg");
            CodeSonne.Add("AGA", "Arg");
            CodeSonne.Add("AGC", "Ser");
            CodeSonne.Add("AGU", "Ser");
            CodeSonne.Add("AAA", "Lys");
            CodeSonne.Add("AAG", "Lys");
            CodeSonne.Add("AAC", "Asn");
            CodeSonne.Add("AAG", "Asn");
            CodeSonne.Add("ACG", "Thr");
            CodeSonne.Add("ACA", "Thr");
            CodeSonne.Add("ACC", "Thr");
            CodeSonne.Add("ACU", "Thr");
            CodeSonne.Add("AUG", "Met");
            CodeSonne.Add("AUA", "Ile");
            CodeSonne.Add("AUC", "Ile");
            CodeSonne.Add("AUU", "Ile");
            //alle mit C
            CodeSonne.Add("CGG", "Arg");
            CodeSonne.Add("CGA", "Arg");
            CodeSonne.Add("CGC", "Arg");
            CodeSonne.Add("CGU", "Arg");
            CodeSonne.Add("CAG", "Gln");
            CodeSonne.Add("CAA", "Gln");
            CodeSonne.Add("CAC", "His");
            CodeSonne.Add("CAU", "His");
            CodeSonne.Add("CCG", "Pro");
            CodeSonne.Add("CCA", "Pro");
            CodeSonne.Add("CCC", "Pro");
            CodeSonne.Add("CCU", "Pro");
            CodeSonne.Add("CUG", "Leu");
            CodeSonne.Add("CUA", "Leu");
            CodeSonne.Add("CUU", "Leu");
            CodeSonne.Add("CUC", "Leu");
            //Alle mit U
            CodeSonne.Add("UGG", "Trp");
            CodeSonne.Add("UGA", "Stopp");
            CodeSonne.Add("UGC", "Cys");
            CodeSonne.Add("UGU", "Cys");
            CodeSonne.Add("UAG", "Stopp");
            CodeSonne.Add("UAA", "Stopp");
            CodeSonne.Add("UAC", "Tyr");
            CodeSonne.Add("UAU", "Tyr");
            CodeSonne.Add("UCG", "Ser");
            CodeSonne.Add("UCA", "Ser");
            CodeSonne.Add("UCC", "Ser");
            CodeSonne.Add("UCU", "Ser");
            CodeSonne.Add("UUA", "Leu");
            CodeSonne.Add("UUG", "Leu");
            CodeSonne.Add("UUU", "Phe");
            CodeSonne.Add("UUC", "Phe");
            //Alle mit G
            CodeSonne.Add("GUU", "Val");
            CodeSonne.Add("GUC", "Val");
            CodeSonne.Add("GUA", "Val");
            CodeSonne.Add("GUG", "Val");
            CodeSonne.Add("GCU", "Ala");
            CodeSonne.Add("GCA", "Ala");
            CodeSonne.Add("GCC", "Ala");
            CodeSonne.Add("GCG", "Ala");
            CodeSonne.Add("GAU", "Glu");
            CodeSonne.Add("GAC", "Asp");
            CodeSonne.Add("GAA", "Glu");
            CodeSonne.Add("GAG", "Asp");
            CodeSonne.Add("GGU", "Gly");
            CodeSonne.Add("GGC", "Gly");
            CodeSonne.Add("GGA", "Gly");
            CodeSonne.Add("GGG", "Gly");
            //Amiosäuren translation
            Aminosäuren.Add("Gly", "Glycin");
            Aminosäuren.Add("Val", "Valin");
            Aminosäuren.Add("Ile", "Isoleucin");
            Aminosäuren.Add("Phe", "Phenylalanin");
            Aminosäuren.Add("Cys", "Cystein");
            Aminosäuren.Add("Ser", "Serin");
            Aminosäuren.Add("Asn", "Asparagin");
            Aminosäuren.Add("Tyr", "Tyrosin");
            Aminosäuren.Add("Asp", "Aspartat");
            Aminosäuren.Add("Glu", "Glutamat");
            Aminosäuren.Add("Lys", "Lysin");
            Aminosäuren.Add("His", "Histidin");
            Aminosäuren.Add("Ala", "Alanin");
            Aminosäuren.Add("Leu", "Leucin");
            Aminosäuren.Add("Pro", "Prolin");
            Aminosäuren.Add("Met", "Methionin");
            Aminosäuren.Add("Thr", "Threonin");
            Aminosäuren.Add("Gln", "Glutamin");
            Aminosäuren.Add("Trp", "Tryptophan");
            Aminosäuren.Add("Arg", "Arginin");


        }

        private void Start_Click(object sender, RoutedEventArgs e) {
            if ((bool)FromDNAcheckbox.IsChecked) {
                DNAinput = DNAinputBox.Text.ToString();
                Debug.WriteLine(DNAinput);
                mRNAoutput = umwandeln(Convert2.mRNA, DNAinput);
                mRNAinputBox.Text = mRNAoutput;
                tRNAoutput = umwandeln(Convert2.tRNA, mRNAoutput);
                tRNAinputBox.Text = tRNAoutput;
                DNAinput = System.Text.RegularExpressions.Regex.Replace(DNAinput, ".{3}", "$0 ");
                DNAinputBox.Text = DNAinput;
            }
            if ((bool)FrommRNAcheckbox.IsChecked) {
                mRNAinput = mRNAinputBox.Text.ToString();
                Debug.WriteLine(mRNAinput);
                DNAoutput = umwandeln(Convert2.DNA, mRNAinput);
                DNAinputBox.Text = DNAoutput;
                tRNAoutput = umwandeln(Convert2.tRNA, mRNAinput);
                tRNAinputBox.Text = tRNAoutput;
                mRNAinput = System.Text.RegularExpressions.Regex.Replace(mRNAinput, ".{3}", "$0 ");
                mRNAinputBox.Text = mRNAinput;
            }
            if ((bool)FromtRNAcheckbox.IsChecked) {
                tRNAinput = tRNAinputBox.Text.ToString();
                Debug.WriteLine(tRNAinput);
                mRNAoutput = umwandeln(Convert2.mRNA, tRNAinput);
                mRNAinputBox.Text = mRNAoutput;
                DNAoutput = umwandeln(Convert2.DNA, mRNAoutput);
                DNAinputBox.Text = DNAoutput;
                tRNAinput = System.Text.RegularExpressions.Regex.Replace(tRNAinput, ".{3}", "$0 ");
                tRNAinputBox.Text = tRNAinput;
            }
        }

        string umwandeln(Convert2 target, string s) {
            List<Char> newString = new List<char>();
            
            if (target == Convert2.DNA) {
                for (int i = 0; i < s.Length; i++) {
                    char c = s[i];
                    if (c == 'U' || c == 'u') {
                        newString.Add('A');
                    }
                    if (c == 'A' || c == 'a') {
                        newString.Add('T');
                    }
                    if (c == 'G' || c == 'g') {
                        newString.Add('C');
                    }
                    if (c == 'C' || c == 'c') {
                        newString.Add('G');
                    }
                }
            }
            if (target == Convert2.mRNA) {
                for (int i = 0; i < s.Length; i++) {
                    char c = s[i];
                    if(c == 'U' || c == 'u') {
                        newString.Add('A');
                    }
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
                    if (c == 'U' || c == 'u') {
                        newString.Add('A');
                    }
                }
            } 
            
            char[] chararray = newString.ToArray();
            string _s = new String(chararray);
            Debug.WriteLine(_s);
            _s = System.Text.RegularExpressions.Regex.Replace(_s, ".{3}", "$0 ");
            Debug.WriteLine(_s);
            return _s;
        }

        #region UI Stuff
        private void FromtRNAcheckbox_Click(object sender, RoutedEventArgs e) {
            resetValues();
            if ((bool)FromtRNAcheckbox.IsChecked) {
                tRNAinputBox.Text = "";
                DNAinputBox.IsEnabled = false;
                mRNAinputBox.IsEnabled = false;
                tRNAinputBox.IsEnabled = true;
                FrommRNAcheckbox.IsChecked = false;
                FromDNAcheckbox.IsChecked = false;
            }
            else {
                tRNAinputBox.Text = "Put tRNA Tripletts in here";
                
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
                mRNAinputBox.Text = "";
                DNAinputBox.IsEnabled = false;
                mRNAinputBox.IsEnabled = true;
                tRNAinputBox.IsEnabled = false;
                FromtRNAcheckbox.IsChecked = false;
                FromDNAcheckbox.IsChecked = false;
            }
            else {
                mRNAinputBox.Text = "Put mRNA Tripletts in here";
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
                DNAinputBox.Text = "";
                DNAinputBox.IsEnabled = true;
                mRNAinputBox.IsEnabled = false;
                tRNAinputBox.IsEnabled = false;
                FrommRNAcheckbox.IsChecked = false;
                FromtRNAcheckbox.IsChecked = false;
            }
            else {
                DNAinputBox.Text = "Put DNA Tripletts in here";
                DNAinputBox.IsEnabled = true;
                mRNAinputBox.IsEnabled = true;
                tRNAinputBox.IsEnabled = true;
                FrommRNAcheckbox.IsChecked = false;
                FromtRNAcheckbox.IsChecked = false;
            }
        }

        #endregion

        private void KopierenButton1_Click(object sender, RoutedEventArgs e) {
            Clipboard.SetText(DNAinputBox.Text.ToString());
        }

        private void KopierenButton2_Click(object sender, RoutedEventArgs e) {
            Clipboard.SetText(mRNAinputBox.Text.ToString());
        }

        private void KopierenButton3_Click(object sender, RoutedEventArgs e) {
            Clipboard.SetText(tRNAinputBox.Text.ToString());
        }
    }
}
