using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SequenceEncoding
{
    public class ConversionVM : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Drawing { get; private set; }

        BipolarPulseCoding bipolarPulseCoding;
        NotReturnToZero notReturnToZero;
        BipolarAMI bipolarAMI;
        ManchesterCode manchester;
        Potential2B1Q potentialTBOQ;

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
        private string selectedAMI;

        public string SelectedAMI
        {
            get { return selectedAMI; }
            set 
            { 
                selectedAMI = value;
                OnPropertyChanged("SelectedAMI");
            }
        }
        private string selectedManchester;

        public string SelectedManchester
        {
            get { return selectedManchester; }
            set 
            { selectedManchester = value;
                OnPropertyChanged("SelectedManchester");
            }
        }
        private string selected2B1Q;

        public string  Selected2B1Q
        {
            get { return selected2B1Q; }
            set 
            { 
                selected2B1Q = value;
                OnPropertyChanged("Selected2B1Q");
            }
        }

        private List<string> binaryCup;
        public List<string> BinaryCup
        {
            get { return binaryCup; }
            set
            {
                binaryCup = value;
                OnPropertyChanged("BinaryCup");
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
                            //also add to drawing diagram with the startest binary code which inserted in binary code box and then it will be converted to decimal code
                             
                            if (selectedNRZ == "True")
                            {
                                notReturnToZero = new NotReturnToZero();
                                //Drawing NRZ diagram
                                notReturnToZero.DrawDiagram(BinaryCup, Drawing);
                                if (notReturnToZero.TempX > 350)
                                {
                                    CanvasWidth = notReturnToZero.TempX;
                                }   
                            }
                            else if (selectedBPC == "True")
                            {
                                bipolarPulseCoding = new BipolarPulseCoding();
                                //Drawing BPC diagram
                                bipolarPulseCoding.DrawDiagram(BinaryCup, Drawing);
                                if (bipolarPulseCoding.TempX > 350)
                                {
                                    CanvasWidth = bipolarPulseCoding.TempX;
                                }
                                
                            }
                            else if(SelectedAMI == "True")
                            {
                                bipolarAMI = new BipolarAMI();
                                //Drawing AMI diagram
                                bipolarAMI.DrawDiagram(BinaryCup, Drawing);
                                if(bipolarAMI.TempX > 350)
                                {
                                    CanvasWidth = bipolarAMI.TempX;
                                }
                            }
                            else if(SelectedManchester == "True")
                            {
                                manchester = new ManchesterCode();
                                //Drawing manchester diagram
                                manchester.DrawDiagram(BinaryCup, Drawing);
                                if(manchester.TempX > 350)
                                {
                                    CanvasWidth = manchester.TempX;
                                }
                            }else if(Selected2B1Q == "True")
                            {
                                potentialTBOQ = new Potential2B1Q();
                                //Drawing potential 2B1Q diagram
                                potentialTBOQ.DrawDiagram(BinaryCup, Drawing);
                                if(potentialTBOQ.TempX > 350)
                                {
                                    CanvasWidth = potentialTBOQ.TempX;
                                }
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
        //get the binary code without space 
        private async Task getBinaryCup()
        {
            BinaryCup.Clear();

            await Task.Run(() =>
            {
                for (int i = 0; i < BinaryString.Length; i++)
                {
                    if (BinaryString[i] != ' ')
                    {
                        BinaryCup.Add(BinaryString[i].ToString());
                    }
                }
            });  
        }
        //execute conversion from text to binary code
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
