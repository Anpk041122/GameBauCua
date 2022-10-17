using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameBauCua
{
    public partial class frmLogin : Form
    {
        UserManagement um = null;
        Music m = null;
        public static User userLogin = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void init()
        {
            #region hàm khởi tạo
            string path = @"D:\WriteFile.empl";
            FileStream fs;
            if (!(File.Exists(path)))
            {
                fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                fs.Close();
            }
            txtName.Text = "";
            txtPaword.Text = "";
            m = new Music();
            m.LinkFileMusic(Application.StartupPath + @"\Music\background_music.mp3");
            m.Play();
            #endregion
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            // chuyển form
            #region khi click chuyển qua form đăng ký
            m.Stop();
            this.Hide();
            frmResgister f = new frmResgister();
            f.ShowDialog();
            this.Close();
            #endregion
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            #region Đăng nhập
            string name = txtName.Text;
            string passWord = txtPaword.Text;
            bool isName = false;
            bool isPassWord = false;
            if (isEmpty(name, passWord) == 1)
            {
                if (isExistName(name, passWord, isName, isPassWord) == 1)
                {
                    GetInFormation(name, passWord);
                    m.Stop();
                    this.Hide();
                    frmMain f = new frmMain();
                    f.ShowDialog();
                    this.Close();
                }
            }
            #endregion
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            init();
            um = new UserManagement();
        }

        // kiểm tra tài khoản đã tồn tại hay chưa.
        private int isExistName(string name, string passWord, bool isName, bool isPassWord)
        {
            #region Kiểm tra xem tài khoản đã tồn tại hay chưa || mật khẩu đã chính xác hay chưa
            um.OpenFIle();
            foreach (User user in um.lstUser)
            {
                if (user.Name == name)
                {
                    isName = true;
                    if (user.PassWord == passWord)
                    {
                        isPassWord = true;
                    }
                    else
                    {
                        isPassWord = false;
                    }
                }
            }

            if (isName)
            {
                if (isPassWord)
                {
                    return 1;
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản của bạn chưa tồn tại!! Xin vui lòng đăng ký.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btRegister.Focus();
                return 0;
            }
            #endregion
        }

        private int isEmpty(string name, string passWord)
        {
            #region Kiểm tra trường trống
            if (name.Equals(string.Empty) || passWord.Equals(string.Empty))
            {
                MessageBox.Show("Bạn cần phải điển đầy đủ tất cả các trường!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return 0;
            }
            else
            {
                return 1;
            }
            #endregion
        }

        // lấy thông tin
        private void GetInFormation(string name, string passWord)
        {
            #region Lấy dữ liệu người dùng để hiện thị bên giao diện chơi game
            um.OpenFIle();
            foreach (User user in um.lstUser)
            {
                if (user.Name.Equals(name) && user.PassWord.Equals(passWord))
                {
                    userLogin = new User(user.Name, user.PassWord, user.Money);
                    break;
                }
            }
            #endregion
        }
    }
}
