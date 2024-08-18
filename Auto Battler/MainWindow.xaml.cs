using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Automation;
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
            Hit.Visibility = Visibility.Hidden;
            Miss.Visibility = Visibility.Hidden;
            int randomNum1 = dice.Next(1,7);
            int randomNum2 = dice.Next(1,7);
            
            DiceOne.Text=randomNum1.ToString();
            DiceTwo.Text=randomNum2.ToString();

            var acc = parseOrDefault(TBoxAccuracy.Text);
            var ev = parseOrDefault(TBoxEvasion.Text);
            var mhp = parseOrDefault(TBoxMaxHp.Text);
            var chp = parseOrDefault(TBoxCurrent.Text);
            var pwr = parseOrDefault(TBoxPower.Text);
            var crt = parseOrDefault(TBoxCrit.Text);
            var dealt = parseOrDefault(TBoxDamage.Text);

            if (randomNum1 + randomNum2 + acc >= ev)
            {
                Hit.Visibility = Visibility.Visible;
                var (damage, didCrit) = PowerTable.GetTotalDamage(pwr, crt);
                chp -= damage;
                Hit.Text = didCrit ? "Crit!" : "Hit";
                TBoxDamage.Text = damage.ToString();
                TBoxCurrent.Text = chp.ToString();
            }
            else
            {
                Miss.Visibility = Visibility.Visible;
            }
        }

        private int parseOrDefault(string text, int @default=0)
        {
            return int.TryParse(text, out int result) ? result : @default;
        }

        private void maxHpChanged(object sender, TextChangedEventArgs e)
        {
            var m = e.Source as TextBox;
            TBoxCurrent.Text = m.Text;
        }
    }
}