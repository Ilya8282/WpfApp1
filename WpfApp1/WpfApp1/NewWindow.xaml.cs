using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        card _card = new card();
        public NewWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && cost.Text != "" && KD.Text != "" && recharge_speed.Text != "" && speed.Text != "" && AttackRange.Text != "")
            {
                _card.Name = Name.Text;
                _card.Cost = int.Parse(cost.Text);
                _card.Id_speed = int.Parse(speed.Text);
                _card.Disembarkation_time = int.Parse(KD.Text);
                _card.Recharge_speed = int.Parse(recharge_speed.Text);
                _card.Id_attack_range = int.Parse(AttackRange.Text);
                _card.Id_arena = Arena.SelectedIndex;
                _card.Id_movement = Muvement.SelectedIndex;
                _card.Id_rarity = Rarety.SelectedIndex;
                _card.Id_target = Target.SelectedIndex;
                _card.Id_type = Type.SelectedIndex;
                using (AppContext context = new AppContext())
                {
                    context.cards.Add(_card);
                    context.SaveChanges();
                }
                adminWindow uw = new adminWindow();
                uw.Show();
                this.Close();
            }
        }
    }
    
}
