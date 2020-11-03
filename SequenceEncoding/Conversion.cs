using Accessibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace SequenceEncoding
{
    //the programm doesn't works. I think all problems are staying here, so look for the bugs
    //http://csharphelper.com/blog/2014/09/draw-graph-wpf-c/
    //work with canvas
    //and I have to think about how to realize this project: OOP or functional
    
    public class Conversion : INotifyPropertyChanged
    {
        private string decimalString;

        public string DecimalString
        {
            get { return decimalString; }
            set 
            { 
                decimalString = value;
                OnPropertyChanged("DecimalString");
            }
        }
        private string binaryString;

        public string BinaryString
        {
            get { return binaryString; }
            set 
            { 
                binaryString = value;
                OnPropertyChanged("BinaryString");
            }
        }
        private RelayCommand executeConversion;
        public RelayCommand ExecuteConversion
        {
            get
            {
                return executeConversion ??
                    (executeConversion = new RelayCommand(c =>
                    {
                        makeConversion();
                    }));
            }
        }

        private void makeConversion()
        {
            byte[] temp = Encoding.UTF8.GetBytes(decimalString);
            StringBuilder stringBuilder = new StringBuilder(temp.Length * 8);

            foreach (byte b in temp)
            {
                stringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, ' '));
            }
            BinaryString = stringBuilder.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

        }
    }
    
}
