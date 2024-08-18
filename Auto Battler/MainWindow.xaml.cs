using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Auto_Battler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random dice = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Power(object sender, RoutedEventArgs e)
        {
            int randomNum1 = dice.Next(1,7);
            int randomNum2 = dice.Next(1,7);
            
            switch (randomNum1)
            {
                case 1:
                    DiceOne.Text = "1";
                    break;
                case 2:
                    DiceOne.Text = "2";
                    break;
                case 3:
                    DiceOne.Text = "3";
                    break;
                case 4:
                    DiceOne.Text = "4";
                    break;
                case 5:
                    DiceOne.Text = "5";
                    break;
                case 6:
                    DiceOne.Text = "6";
                    break;
                default:
                    DiceOne.Text = "1";
                    break;
            }

            switch (randomNum2)
            {
                case 1:
                    DiceTwo.Text = "1";
                    break;
                case 2:
                    DiceTwo.Text = "2";
                    break;
                case 3:
                    DiceTwo.Text = "3";
                    break;
                case 4:
                    DiceTwo.Text = "4";
                    break;
                case 5:
                    DiceTwo.Text = "5";
                    break;
                case 6:
                    DiceTwo.Text = "6";
                    break;
                default:
                    DiceTwo.Text = "1";
                    break;
            }
        }
    }
}