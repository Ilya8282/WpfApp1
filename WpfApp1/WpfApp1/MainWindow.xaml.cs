using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text != "" && Password.Text != "")
            {
                user authUser = null;
                using (AppContext context = new AppContext())
                {
                    authUser = context.users.Where(b => b.Login == Login.Text).FirstOrDefault();
                }
                if (authUser == null)
                {
                    user user = new user(Login.Text, Password.Text, 1);
                    db.users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                }
                else
                    MessageBox.Show("Этот логин уже занят");
                Login.Text = "";
                Password.Text = "";
            }
            else
            {
                Eror.Content = "Введите данные";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = Login.Text;

            string str2 = Password.Text;

            if (Login.Text != "" && Password.Text != "")
            {
                user authUser = null;
                using (AppContext context = new AppContext())
                {
                    authUser = context.users.Where(b => b.Login == str && b.Pasword == str2 ).FirstOrDefault();
                }
                if (authUser != null)
                {
                    if (authUser.id_role == 2)
                    {
                        adminWindow uw = new adminWindow();
                        uw.Show();
                        this.Close();
                    }
                    else
                    {
                        userWindow aw = new userWindow();
                        aw.Show();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Введенны не верные данные");
                Login.Text = "";
                Password.Text = "";
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }
    }
}
