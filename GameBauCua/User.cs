using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBauCua
{
    public class User
    {
        // Thông tin người chơi
        public string Name { get; set; }
        public string PassWord { get; set; }
        public int Money { get; set; }

        public User(string name, string password, int money)
        {
            this.Name = name;
            this.PassWord = password;
            this.Money = money;
        }

        public User()
        {
        }

    }
}
