using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class card
    {
        public int id { get; set; }
        public int id_type;
        public int id_arena;
        public int id_rarity;
        public int id_target;
        public int id_movement;
        public double id_attack_range;
        public double id_speed;
        public string name;
        public int cost;
        public double recharge_speed;
        public double disembarkation_time;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Id_type
        {
            get { return id_type; }
            set { id_type = value; }
        }
        public int Id_arena
        {
            get { return id_arena; }
            set { id_arena = value; }
        }
        public int Id_rarity
        {
            get { return id_rarity; }
            set { id_rarity = value; }
        }
        public int Id_target
        {
            get { return id_target; }
            set { id_target = value; }
        }
        public int Id_movement
        {
            get { return id_movement; }
            set { id_movement = value; }
        }
        public double Id_attack_range
        {
            get { return id_attack_range; }
            set { id_attack_range = value; }
        }
        public double Id_speed
        {
            get { return id_speed; }
            set { id_speed = value; }
        }
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public double Recharge_speed
        {
            get { return recharge_speed; }
            set { recharge_speed = value; }
        }
        public double Disembarkation_time
        {
            get { return disembarkation_time; }
            set { disembarkation_time = value; }
        }
        public card() { }
        public card(int id, int id_type, int id_arena, int id_rarity, int id_target, int id_movement, double id_attack_range, double id_speed, string name, int cost, double recharge_speed, double disembarkation_time)
                {
                    this.id = id;
                    Id_type = id_type;
                    Id_arena = id_arena;
                    Id_rarity = id_rarity;
                    Id_target = id_target;
                    Id_movement = id_movement;
                    Id_attack_range = id_attack_range;
                    Id_speed = id_speed;
                    Name = name;
                    Cost = cost;
                    Recharge_speed = recharge_speed;
                    Disembarkation_time = disembarkation_time;
                }
            }
}
