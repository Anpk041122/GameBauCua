using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;

namespace GameBauCua
{
    public partial class frmMain : Form
    {
        string path, pathMusic;// dẫn link hình ảnh
        int nDice;// xúc xắc ngẫu nhiên.
        int nMusic;
        Random rd = new Random(); // random số ngẫu nhiên
        PlayGame Play = null;
        UserManagement um = null;
        Music m = null;
        Music m1 = null; // nhạc quay xí ngầu.
        Music m2 = null; // nhạc thắng thua.
        public frmMain()
        {
            InitializeComponent();
        }

        // Hàm khởi tạo.
        private void Init()
        {
             #region Hình xúc xắc mặc định khi khởi tạo form
            // gán hình ngẫu nhiên cho xúc xắc 1
            nDice = rd.Next(0, 5);
            picDice1.Image = Image.FromFile(path + nDice + ".jpg"); // gán hình ngẫu nhiên khi khởi tạo
            // gán hình ngẫu nhiên cho xúc xắc 2
            nDice = rd.Next(0, 5);
            picDice2.Image = Image.FromFile(path + nDice + ".jpg"); // gán hình ngẫu nhiên khi khởi tạo
            // gán hình ngẫu nhiên cho xúc xắc 3
            nDice = rd.Next(0, 5);
            picDice3.Image = Image.FromFile(path + nDice + ".jpg"); // gán hình ngẫu nhiên khi khởi tạo
            #endregion

            #region Đặt điểm mặc định

            Play = new PlayGame(Convert.ToInt32(frmLogin.userLogin.Money));
            lbMoney.Text = Play.Money.ToString();
            lbName.Text = frmLogin.userLogin.Name.ToString();
            m = new Music();
            #endregion

            #region Gán nhạc ngẫu nhiên
            nMusic = rd.Next(1, 10);
            m.LinkFileMusic(pathMusic + "nhac_nen_" + nMusic + ".mp3");
            m.Play();
            #endregion
        }



        // Load form
        private void frmMain_Load(object sender, EventArgs e)
        {
            path = Application.StartupPath + @"\Images\"; // gán địa chỉ thư mục lấy hình
            pathMusic = Application.StartupPath + @"\Music\"; // gán địa chỉ thư mục lấy hình
            Init();
        }


        // Xu lý tiền cược không hợp lệ
        private void InvalidBetProcessing(ref NumericUpDown TienCuoc)
        {
            #region Xử lý ô đặt cược bị bỏ trống
            if (string.IsNullOrEmpty(TienCuoc.Text))
                TienCuoc.Text = "0";
            #endregion
        }

        // Đặt lại tiền cược thành 0
        private void ResetBet(ref NumericUpDown TienCuoc)
        {
            #region Trả về tiền cược thành 0
            if (TienCuoc.Text != "0")
                TienCuoc.Text = "0";
            #endregion
        }

        // Đặt tất cả tiền các ô về 0 
        private void ResetAllBet()
        {
            #region đặt tất cả về 0
            ResetBet(ref nrGa);
            ResetBet(ref nrCua);
            ResetBet(ref nrNai);
            ResetBet(ref nrCa);
            ResetBet(ref nrBau);
            ResetBet(ref nrTom);
            #endregion
        }

        // Xóc
        private void btPlay_Click(object sender, EventArgs e)
        {
            // Thông báo quên đặt cược
            if (GetMoney().Sum() == 0)
            {
                #region Hiện thông báo quên đặt cược
                MessageBox.Show("Bạn quên đặt cược kìa đồ đáng ghét! (^_^)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                #endregion
            }

            // Gọi hàm xóc dĩa
            Play.Play();

            // Kiểm tra số tiền đặt cược có lớn hơn số tiền đang có
            if (Play.Money < GetMoney().Sum())
            {
                #region Hiện thông báo không đủ tiền
                MessageBox.Show("Bạn ơi! Tiền của bạn không đủ để đặt cược! Xách cái đít lên đặt lại đi!! <3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetAllBet();
                return;
                #endregion
            }

            // Bật hiệu ứng lắc xúc xắc
            timerDice.Enabled = true;
            btOpen.Visible = true;
            btPlay.Visible = false;
            // Tạo nhạc quay xí ngầu
            m1 = new Music();
            m1.LinkFileMusic(Application.StartupPath + @"\Theme_Music\random.m4a");
            m1.Play();
        }

        // Mở
        private void btOpen_Click(object sender, EventArgs e)
        {
            // Dừng nhạc quay xí ngầu
            m1.Stop();
            // Tắt hiệu ứng lắc xúc xắc
            timerDice.Enabled = false;

            // Đặt lại hình quay ra lên form
            #region Hình quay ra
            picDice1.Image = Play.ResultImage(1);
            picDice2.Image = Play.ResultImage(2);
            picDice3.Image = Play.ResultImage(3);
            #endregion

            // Gọi hàm mở
            Play.Open(GetMoney());
            MusicTheme();
            // Hiện thông báo và đặt lại tiền cược
            if (MessageBox.Show(Play.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information).Equals(DialogResult.OK))
            {
                #region Đặt lại các ô đặt cược về 0
                ResetAllBet();
                #endregion
            }
            // Cập nhật lại tiền sau khi xóc
            lbMoney.Text = Play.Money.ToString();
            // mở nút mở
            btOpen.Visible = false;
            btPlay.Visible = true;
            // Thông báo người chơi hết tiền
            if (Play.Money == 0)
            {
                #region Hiện thông báo hết tiền
                MessageBox.Show("Bạn đã hết tiền!! Chúng tôi xin biếu bạn 5000, để lấy thảo!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Play.Money = 5000;
                lbMoney.Text = Play.Money.ToString();
                return;
                #endregion       
            }
        }

        // Lấy giá trị người chơi đặt
        private int[] GetMoney()
        {

            // Đặt về bằng 0 tránh lỗi chương trình.
            #region Xử lý các ô đặt cược bị để trống
            InvalidBetProcessing(ref nrGa);
            InvalidBetProcessing(ref nrCua);
            InvalidBetProcessing(ref nrNai);
            InvalidBetProcessing(ref nrCa);
            InvalidBetProcessing(ref nrBau);
            InvalidBetProcessing(ref nrTom);
            #endregion

            #region Lấy tiền người chơi đặt
            int[] BetMoney =
            {
                Convert.ToInt32(nrNai.Text),
                Convert.ToInt32(nrBau.Text),
                Convert.ToInt32(nrGa.Text),
                Convert.ToInt32(nrCa.Text),
                Convert.ToInt32(nrCua.Text),
                Convert.ToInt32(nrTom.Text),
            };
            return BetMoney;
            #endregion
        }

        // Hiệu ứng chuyển ảnh của xúc xắc
        private void timerDice_Tick(object sender, EventArgs e)
        {
            #region Rán hình ngẫu nhiên tạo hiệu ứng quay xúc xắc
            // gán hình ngẫu nhiên cho xúc xắc 1
            nDice = rd.Next(0, 5);
            picDice1.Image = Image.FromFile(path + nDice + ".jpg"); // gán hình ngẫu nhiên khi khởi tạo
            // gán hình ngẫu nhiên cho xúc xắc 2
            nDice = rd.Next(0, 5);
            picDice2.Image = Image.FromFile(path + nDice + ".jpg"); // gán hình ngẫu nhiên khi khởi tạo
            // gán hình ngẫu nhiên cho xúc xắc 3
            nDice = rd.Next(0, 5);
            picDice3.Image = Image.FromFile(path + nDice + ".jpg"); // gán hình ngẫu nhiên khi khởi tạo
            #endregion
        }

        // cập nhật điểm của người chơi.
        private void UpdateMoney()
        {
            #region Cập nhật điểm của người chơi
            string str = lbMoney.Text.Trim();
            int money;
            if (str != null)
            {
                money = int.Parse(str);
            }
            else
            {
                MessageBox.Show("Lỗi kết nối dữ liệu!!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                money = 0;
            }
            um = new UserManagement();
            if (um.OpenFIle() == 1)
            {
                // tiến hành cập nhật điểm người chơi
                foreach (User user in um.lstUser)
                {
                    if (user.Name == frmLogin.userLogin.Name)
                    {
                        user.Money = money;
                    }
                }
                // mở file và ghi điểm người chơi 
                string path = @"D:\WriteFile.empl";
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter wter = new StreamWriter(fs, UTF8Encoding.UTF8);
                foreach (var user in um.lstUser)
                {
                    string s = user.Name + '#' + user.PassWord + '#' + user.Money;
                    wter.WriteLine(s);
                }
                // Ghi và đóng file
                wter.Flush();
                wter.Close();
                fs.Close();
            }
            #endregion
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát game!!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            e.Cancel = true;
            UpdateMoney();
        }

        private void phátNhạcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m.Play();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            m.Stop();
            ComboBox cb = (ComboBox)sender;
            string str = cb.Text.Trim();
            cbMusic.Focus();
            m.LinkFileMusic(pathMusic + str + ".mp3");
            m.Play();
        }

        private void tạmDừngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m.Pause();
        }

        private void MusicTheme()
        {
            m2 = new Music();
            if(Play.TotalMoney > 0)
            {
                m2.LinkFileMusic(Application.StartupPath + @"\Theme_Music\win.mp3");
                m2.Play();
            } 
            if(Play.TotalMoney < 0) {
                m2.LinkFileMusic(Application.StartupPath + @"\Theme_Music\fail.mp3");
                m2.Play();
            }
                
        }
    }
}
