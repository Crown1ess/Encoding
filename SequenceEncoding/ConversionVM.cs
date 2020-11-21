using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;


namespace SequenceEncoding
{
    public class ConversionVM : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Drawing { get; private set; }

        BipolarPulseCoding bipolarPulseCoding;

        NotReturnToZero notReturnToZero;

        private int canvasWidth;

        public int CanvasWidth
        {
            get { return canvasWidth; }
            set
            { 
                canvasWidth = value;
                OnPropertyChanged("CanvasWidth");
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

        private string selectedNRZ;

        public string SelectedNRZ
        {
            get { return selectedNRZ; }
            set 
            { 
                if(value != null)
                    selectedNRZ = value;
                OnPropertyChanged("SelectedNRZ");
            }
        }

        private string selectedBPC;

        public string SelectedBPC
        {
            get { return selectedBPC; }
            set
            { 
                selectedBPC = value;
                OnPropertyChanged("SelectedBPC");

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
                           
                            MessageBox.Show("You didn't enter text to Decimal Code box. Please try again!", "Display", MessageBoxButton.OK);
                        }
                        else
                        {
                            makeConversion();

                            getBinaryCup();

                            Drawing.Clear();

                            CanvasWidth = 350;
                            //some method is returning null value so that doesn't work.
                            //also add to drawing diagram/ with the startest binary code which inserted in binary code box and then it will be converted to decimal code
                             
                            if (selectedNRZ == "True")
                            {
                                notReturnToZero = new NotReturnToZero();

                                notReturnToZero.DrawDiagram(BinaryCup, Drawing);
                                if (notReturnToZero.TempX > 350)
                                {
                                    CanvasWidth = notReturnToZero.TempX;
                                }   
                                MessageBox.Show(canvasWidth.ToString(), "Display");
                            }
                            else if (selectedBPC == "True")//change code at the BipolarPulseCode like a NRZ
                            {
                                bipolarPulseCoding = new BipolarPulseCoding();

                                bipolarPulseCoding.DrawDiagram(BinaryCup, Drawing);
                                if (bipolarPulseCoding.TempX > 350)
                                {
                                    CanvasWidth = bipolarPulseCoding.TempX;
                                }
                                MessageBox.Show(canvasWidth.ToString(), "Display");
                            }
                            else
                            {
                                MessageBox.Show("You didn't choose encoding variants, please try again", "Display", MessageBoxButton.OK);

                            }
                        }
                    }));
            }
        }
        public ConversionVM()
        {            
            BinaryCup = new List<string>();
            Drawing = new ObservableCollection<Item>();
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
