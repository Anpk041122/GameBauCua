using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace GameBauCua
{
    public partial class frmResgister : Form
    {
        Music m = null;
        UserManagement um = null;
        public frmResgister()
        {
            InitializeComponent();
        }

        private void set_background(Object sender, PaintEventArgs e)
        {
            // vẽ nền
            #region Vẽ hình nền background
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            Image imagePlate = Properties.Resources._123213;
            TextureBrush TextureBrushPlate = new TextureBrush(imagePlate);
            graphics.FillRectangle(TextureBrushPlate, rect);
            #endregion
        }

        // Hàm khởi tạo
        private void Init()
        {
            #region Khởi tạo text mặc định thành rỗng
            txtName.Text = "";
            txtPassword.Text = "";
            txtPasswordConfirm.Text = "";
            txtName.Focus();
            m = new Music();
            m.LinkFileMusic(Application.StartupPath + @"\Music\register_music.mp3");
            m.Play();
            #endregion
        }

        private void frmResgister_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(set_background); // vẽ màu lên  from
            Init();
        }

        // Sự kiện nhấn nút đăng ký ngay
        private void btnSumit_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        // Khi click quay về form đăng nhập
        private void btPrevious_Click(object sender, EventArgs e)
        {
            #region khi click quya về ô đăng nhập
            m.Stop();
            this.Hide();
            frmLogin f = new frmLogin();
            f.ShowDialog();
            this.Close();
            #endregion
        }

        private void CreateUser()
        {
            #region Biến dùng để kiểm tra và lưu trữ giá trị
            string name; // lưu tên
            string passWord; // lưu mật khẩu
            string passWordMatch; // lưu nhập lại mật khẩu

            name = txtName.Text; // lấy giá trị của tên đăng nhập
            passWord = txtPassword.Text; // lấy giá trị của mật khẩu
            passWordMatch = txtPasswordConfirm.Text; // lấy giá trị của xác nhận mật khẩu
            #endregion

            #region Tiến hành xử lý và bắt lỗi các trường hợp
            // kiểm tra xem có trường nào trống không.
            if (isEmpty(name, passWord, passWordMatch) == 1)
            {
                if (isRegex(name) == 1 && isRegex(passWord) == 1 && isRegex(passWordMatch) == 1)
                {
                    // Kiểm tra xem mật khẩu nhập lại có khớp với mật khẩu
                    if (isMatch(passWord, passWordMatch) == 1)
                    {
                        if (IsUnicode(passWord) == 1 && isExist(name) == 1)
                        {
                            MessageBox.Show("Bạn đã đăng ký thành công!!", "Great!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Init(); // gọi hàm khởi tạo để xóa tất cả các trường.
                            btPrevious.Focus();
                            AddUser(name, passWord);
                        }
                    }
                }
            }
            #endregion
        }
        // thêm người chơi vào danh sách.
        private void AddUser(string name, string passWord)
        {
            #region Khởi tạo người chơi và lưu vào danh sách người chơi.
            int money = 0;
            User user1 = new User(name, passWord, money);

            um = new UserManagement();
            um.addUser(user1);
            um.SaveFile();
            #endregion
        }
        // kiểm tra xem người dùng có để trống trường nào không
        private int isEmpty(string name, string passWord, string passWordMatch)
        {
            #region Kiểm tra trường trống
            if (name.Equals(string.Empty) || passWord.Equals(string.Empty) || passWordMatch.Equals(string.Empty))
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

        // kiểm tra khớp
        private int isMatch(string passWord, string passWordMatch)
        {
            #region kiểm tra mật khẩu nhập lại khớp hay chưa
            if (passWord != passWordMatch)
            {
                MessageBox.Show("Mật khẩu nhập lại không chính xác!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return 0;
            }
            else
                return 1;
            #endregion
        }

        // mã hóa dữ liệu và kiểm tra ký tự nhập
        private int isRegex(string input)
        {
            // kiem tra toi thieu 6 ky tu khong
            #region Kiểm tra độ dài của tên đăng nhập và mật khẩu
            if (input.Length < 6)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu ít nhất 6 ký tự!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0; // dung kiem tra luon
            }
            if (input.Length > 12)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu nhiều nhất 12 ký tự!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            #endregion

            // Regex
            #region Kiểm tra xem các ký tự có hợp lệ
            // khong phai la ky tu chu, ky tu so, _
            Regex regex = new Regex(@"\W");
            if (regex.IsMatch(input))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không được chứa ký tự đặc biệt và không chứa khoảng trắng!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return 0;
            }
            #endregion

            return 1;
        }

        // kiểm tra Unicode
        private int IsUnicode(string input)
        {
            // nếu số byte của đoạn string khác với số byte của UTF8 là unicode
            #region Kiểm tra unicode
            if (Encoding.ASCII.GetByteCount(input) != Encoding.UTF8.GetByteCount(input))
            {
                MessageBox.Show("Mật khẩu không được chứa ký tự Unicode !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            return 1;
            #endregion
        }

        // Kiểm tra xem tên đăng nhập đã tồn tại chưa
        private int isExist(string name)
        {
            #region Kiểm tra tên tài khoản người chơi đã có tồn tại hay chưa
            um = new UserManagement();
            if (um.OpenFIle() == 1)
            {    
                foreach (User user in um.lstUser)
                {
                    if (user.Name == name)
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại!! Vui lòng chọn tài khoản khác.", "Warnig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }
                }
            } 
            return 1;
            #endregion
        }
    }
}
