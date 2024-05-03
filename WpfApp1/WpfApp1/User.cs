using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class user
    {
        public int id { get; set; }
        public string login;
        public string pasword;
        public int id_role;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Pasword
        {
            get { return pasword; }
            set { pasword = value; }
        }
        public int Id_role
        {
            get { return id_role; }
            set { id_role = value; }
        }
        public user() { }
        public user( string login, string pasword, int id_role)
        {
            this.login = login;
            this.pasword = pasword;
            this.id_role = id_role;
        }
    }
}
