using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace GameBauCua
{
    class UserManagement
    {
        public List<User> lstUser { get; set; }

        public UserManagement()
        {
            lstUser = new List<User>();
        }

        // thêm một người chơi vào danh sách
        public void addUser(User user)  
        {
            this.lstUser.Add(user);
        }

        // ghi ra file.
        public  void SaveFile()
        {
            #region In danh sách người chơi ra file 
            string path = @"D:\WriteFile.empl";
            FileStream fs;
            if (File.Exists(path))
            { // kiem tra file ton tai chua
                fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            }
            else // neu chua ton tai thi tao file moi
            {
                fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
            }

            StreamWriter wter = new StreamWriter(fs, UTF8Encoding.UTF8);
            foreach (var user in lstUser)
            {
                string s = user.Name + '#' + user.PassWord + '#' + user.Money;
                wter.WriteLine(s);
            }
            // Ghi và đóng file
            wter.Flush();
            wter.Close();
            fs.Close();
            #endregion
        }

        //Mở file ra đọc
        public int OpenFIle()
        {
            #region Đọc file người chơi và thêm vào mảng
            string path = @"D:\WriteFile.empl";
            FileStream fs;
           
            if(File.Exists(path))
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(fs, UTF8Encoding.UTF8);
                string[] kq = File.ReadAllLines(path);
                string text;
                for (int i = 0; i < kq.Length; i++)
                {
                    text = read.ReadLine();
                    string[] value = text.Split(new char[] { '#' });
                    User user = new User(value[0], value[1], int.Parse(value[2]));

                    this.lstUser.Add(user);
                }
                read.Close(); // close streamreader
                fs.Close();  //    #endregion
                return 1;
            }
            else
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            }    
            return 0;
            #endregion
        }
    }
}
