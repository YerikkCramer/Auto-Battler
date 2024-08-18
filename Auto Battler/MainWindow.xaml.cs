using System.Windows;
using System.Windows.Controls;

namespace Auto_Battler
{

    public partial class MainWindow : Window
    {
        //Give dice a PRNG number
        private readonly Random dice = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

            private void Power(object sender, RoutedEventArgs e)
            {
                //Start hiding Hit or Miss text box
                Hit.Visibility = Visibility.Hidden;
                Miss.Visibility = Visibility.Hidden;

                //Generate 2 random dice rolls
                int randomNum1 = dice.Next(1,7);
                int randomNum2 = dice.Next(1,7);
            
                //Print the 2 dice rolls to text boxes
                DiceOne.Text=randomNum1.ToString();
                DiceTwo.Text=randomNum2.ToString();

                //Take given values in select text boxes and convert them to usable numbers for math
                var acc = parseOrDefault(TBoxAccuracy.Text);
                var ev = parseOrDefault(TBoxEvasion.Text);
                var mhp = parseOrDefault(TBoxMaxHp.Text);
                var chp = parseOrDefault(TBoxCurrent.Text);
                var pwr = parseOrDefault(TBoxPower.Text);
                var crt = parseOrDefault(TBoxCrit.Text);
                var dealt = parseOrDefault(TBoxDamage.Text);
                var bonus = parseOrDefault(TBoxBonus.Text);

                //Add 2 dice rolls and provided accuracy and check if it is higher than the monster's evasion
                //If you beat the monster's evasion - roll 2 dice for damage
                //If the damage roll is higher than your provided crit threshold - roll again until it is lower than the crit theshold
                //Print the final damage number in a text box and if it was a crit or not
                if (randomNum1 + randomNum2 + acc >= ev)
                {
                    Hit.Visibility = Visibility.Visible;
                    var (damage, didCrit) = PowerTable.GetTotalDamage(pwr, crt);
                    chp -= damage + bonus;
                    Hit.Text = didCrit ? "Crit!" : "Hit";
                    TBoxDamage.Text = (damage + bonus).ToString();
                    TBoxCurrent.Text = chp.ToString();
                }
                //If your 2 dice rolls were lower than the monster's evasion - make the 'Miss' text block visible
                else
                {
                    Miss.Visibility = Visibility.Visible;
                    TBoxDamage.Text = "0"; 
                }
            }

            //Take value in text box and try to convert it to an int - if not possible or no value given default to '0'
            private int parseOrDefault(string text, int @default=0)
            {
                return int.TryParse(text, out int result) ? result : @default;
            }

            //Take value provided in the Max HP text box and copy that initial value to the Current HP text box
            private void maxHpChanged(object sender, TextChangedEventArgs e)
            {
                var m = e.Source as TextBox;
                TBoxCurrent.Text = m.Text;
            }

            private void accChanged(object sender, TextChangedEventArgs e)
            {
                var m = e.Source as TextBox;
                plusAcc.Text = m.Text;
            }
    }
}