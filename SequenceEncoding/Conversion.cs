using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;


namespace SequenceEncoding
{
    delegate void Action();
   
    public class Conversion : INotifyPropertyChanged
    {

        //web site where can you help with canvas https://stackoverflow.com/questions/24026193/bind-collection-of-lines-to-canvas-in-wpf
        public ObservableCollection<DrawItem> Drawing { get; private set; }

        private int tempX;
        private int tempY;
        private int width;

        public int Width
        {
            get { return width; }
            set
            { 
                width = value;
                OnPropertyChanged("Width");
            }
        }


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

        public List<string> BinaryCup;

        private RelayCommand executeConversion;
        public RelayCommand ExecuteConversion
        {
            get
            {
                return executeConversion ??
                    (executeConversion = new RelayCommand(c =>
                    {
                        
                        if (decimalString == null || decimalString == "")
                        {
                           
                            MessageBox.Show("You didn't enter text to Decimal Code box. Please try again!", "Display error", MessageBoxButton.OK);
                        }
                        else
                        {
                            makeConversion();
                            getBinaryCup();
                            someMethod();
                        }
                    }));
            }
        }
        public Conversion()
        {            
            BinaryCup = new List<string>();
            Drawing = new ObservableCollection<DrawItem>();
        }
        private void getBinaryCup()
        {
            BinaryCup.Clear();

            for(int i = 0; i<BinaryString.Length; i++)
            {
                if(BinaryString[i] != ' ')
                {
                    BinaryCup.Add(BinaryString[i].ToString());
                }
            }
        }
        private void someMethod()
        {
            tempX = 0;
            tempY = 100;
            
            Drawing.Clear();

            Drawing.Add(new DrawItem
            {
                From = new System.Drawing.Point(tempX, tempY),
                To = new System.Drawing.Point(tempX += 10, tempY)

            });

            for (int i = 1; i < BinaryCup.Count; i++)
            { 
                if (BinaryCup[i] == "0" && BinaryCup[i - 1] == "0")
                {
                    Drawing.Add(new DrawItem
                    {
                        From = new System.Drawing.Point(tempX, tempY),
                        To = new System.Drawing.Point(tempX += 10, tempY)

                    });

                }
                else if (BinaryCup[i] == "0" && BinaryCup[i - 1] == "1")
                {
                    Drawing.Add(new DrawItem
                    {
                        From = new System.Drawing.Point(tempX, tempY),
                        To = new System.Drawing.Point(tempX , tempY -= 10)
                    });
                    Drawing.Add(new DrawItem
                    {
                        From = new System.Drawing.Point(tempX, tempY),
                        To = new System.Drawing.Point(tempX+=10, tempY)
                    });
                }
                else if (BinaryCup[i] == "1" && BinaryCup[i - 1] == "1")
                {
                    Drawing.Add(new DrawItem
                    {
                        From = new System.Drawing.Point(tempX, tempY),
                        To = new System.Drawing.Point(tempX += 10, tempY)
                    });
                }
                else if (BinaryCup[i] == "1" && BinaryCup[i-1] == "0")
                {
                    Drawing.Add(new DrawItem
                    {
                        From = new System.Drawing.Point(tempX, tempY),
                        To = new System.Drawing.Point(tempX, tempY += 10)
                    });
                    Drawing.Add(new DrawItem
                    {
                        From = new System.Drawing.Point(tempX, tempY),
                        To = new System.Drawing.Point(tempX+=10, tempY)
                    });
                }
            }
        }
        private void makeConversion()
        {
            byte[] temp = Encoding.UTF8.GetBytes(decimalString);
            StringBuilder stringBuilder = new StringBuilder(temp.Length * 8);

            foreach (byte b in temp)
            {
                stringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0').PadLeft(9, ' '));
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
