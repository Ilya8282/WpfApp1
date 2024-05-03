using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для adminWindow.xaml
    /// </summary>
    public partial class adminWindow : Window
    {
        public ObservableCollection<_Card> Items { get; set; } = new ObservableCollection<_Card>();
        public List<_Card> _Cards = new List<_Card>();
        private void myListBox_Loader(object sender, RoutedEventArgs e)
        {
            using (var db = new AppContext())
            {

                db.Configuration.LazyLoadingEnabled = false;
                List<card> entities = db.cards.ToList();

                foreach (var entity in entities)
                {
                    _Card temp = new _Card
                    {
                        id_arena = entity.id_arena,
                        id_attack_range = Convert.ToString(entity.id_attack_range),
                        id_movement = entity.id_movement,
                        id_rarity = entity.id_rarity,
                        id_speed = Convert.ToString(entity.id_speed),
                        id_target = entity.id_target,
                        id_type = entity.id_type,
                        name = entity.name,
                        cost = Convert.ToString(entity.cost),
                        recharge_speed = Convert.ToString(entity.recharge_speed),
                        disembarkation_time = Convert.ToString(entity.disembarkation_time)
                    };

                    _Cards.Add(temp);
                }
            }
            foreach (var entity in _Cards)
               Items.Add(entity);
            myListBox.ItemsSource = Items;
        }
        public class _Card
        {

            public string name { get; set; }
            public int id_rarity { get; set; }
            public int id_arena { get; set; }
            public int id_type { get; set; }
            public int id_target { get; set; }
            public int id_movement { get; set; }
            public string id_attack_range { get; set; }
            public string id_speed { get; set; }
            public string cost { get; set; }
            public string recharge_speed { get; set; }
            public string disembarkation_time { get; set; }
        }

        public adminWindow()
        {
            List<_Card> _Cards = new List<_Card>();
            using (var db = new AppContext())
            {

                db.Configuration.LazyLoadingEnabled = false;
                List<card> entities = db.cards.ToList();

                foreach (var entity in entities)
                {
                    _Card temp = new _Card
                    {
                        id_arena = entity.id_arena,
                        id_attack_range = Convert.ToString(entity.id_attack_range),
                        id_movement = entity.id_movement,
                        id_rarity = entity.id_rarity,
                        id_speed = Convert.ToString(entity.id_speed),
                        id_target = entity.id_target,
                        id_type = entity.id_type,
                        name = entity.name,
                        cost = Convert.ToString(entity.cost),
                        recharge_speed = Convert.ToString(entity.recharge_speed),
                        disembarkation_time = Convert.ToString(entity.disembarkation_time)
                    };

                    _Cards.Add(temp);
                }
            }
            InitializeComponent();
            myListBox.ItemsSource = _Cards;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            
            _Card item = (_Card)button.DataContext;
            using (var db = new AppContext())
            {
                card temp = new card();
                temp.id_arena = item.id_arena;
                temp.id_attack_range = Convert.ToDouble(item.id_attack_range);
                temp.id_movement = item.id_movement;
                temp.id_rarity = item.id_rarity;
                temp.id_speed = Convert.ToDouble(item.id_speed);
                temp.id_target = item.id_target;
                temp.id_type = item.id_type;
                temp.name = item.name;
                temp.cost = Convert.ToInt32(item.cost);
                temp.recharge_speed = Convert.ToDouble(value: item.recharge_speed);
                temp.disembarkation_time = Convert.ToDouble(item.disembarkation_time);
                var allCards = db.cards.ToList(); // Загрузить все карточки в память

                card card = allCards.FirstOrDefault(b => b.name == temp.name); // Выполнить фильтрацию в памяти
                db.cards.Remove(card);
                db.cards.Add(temp);
                db.SaveChanges();
                //_Cards.Remove(item);
                //_Cards.Add(temp);

            }
            using (var db = new AppContext())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<card> entities = db.cards.ToList();
                myListBox.ItemsSource = entities;
            }
            myListBox.Items.Refresh();
            // Закрыть текущее окно


            // Открыть новое окно
            var newWindow = new adminWindow();
            newWindow.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            _Card item = (_Card)button.DataContext;
            card temp = new card();
            temp.id_arena = item.id_arena;
            temp.id_attack_range = Convert.ToDouble(item.id_attack_range);
            temp.id_movement = item.id_movement;
            temp.id_rarity = item.id_rarity;
            temp.id_speed = Convert.ToDouble(item.id_speed);
            temp.id_target = item.id_target;
            temp.id_type = item.id_type;
            temp.name = item.name;
            temp.cost = Convert.ToInt32(item.cost);
            temp.recharge_speed = Convert.ToDouble(value: item.recharge_speed);
            temp.disembarkation_time = Convert.ToDouble(item.disembarkation_time);
            using (var db = new AppContext())
            {
                var allCards = db.cards.ToList(); // Загрузить все карточки в память

                card card = allCards.FirstOrDefault(b => b.name == temp.name); // Выполнить фильтрацию в памяти
                db.cards.Remove(card);
                db.SaveChanges();
            }
            var newWindow = new adminWindow();
            newWindow.Show();
            this.Close();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NewWindow uw = new NewWindow();
            uw.Show();
            this.Close();
        }
        
    }
}
