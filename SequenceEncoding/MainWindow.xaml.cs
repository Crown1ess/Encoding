using System.Windows;


namespace SequenceEncoding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // DrawItem drawItem = new DrawItem();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ConversionVM(); 
        }
    }
}
