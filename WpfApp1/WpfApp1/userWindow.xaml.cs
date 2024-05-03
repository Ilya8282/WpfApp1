using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для userWindow.xaml
    /// </summary>
    public partial class userWindow : Window
    {
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
        public userWindow()
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

    }
}
