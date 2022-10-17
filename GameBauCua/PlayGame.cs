using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;

namespace GameBauCua
{
    class PlayGame
    {
        // Thuộc tính cơ bản của game
        #region Thuộc tính
        public int Money { get; set; } // Tiền của người chơi
        private int[] Result = new int[3]; // Kết quả trả về của 3 quả xúc xắc
        private Bitmap[] Image =
        {
            Properties.Resources._0, //Nai
            Properties.Resources._1, //Bau
            Properties.Resources._2, //Ga
            Properties.Resources._3, //Ca
            Properties.Resources._4, //Cua
            Properties.Resources._5 //Tom
        }; // Hình bầu cua tương ứng kết quả
        private string[] Name =
       {
            "Nai",
            "Bầu",
            "Gà",
            "Cá",
            "Cua",
            "Tôm"
        };
        public string Message { get; set; } // Thông báo thắng thua
        public int TotalMoney { get; set; }

        private Random rd;
        #endregion

        // Phương thức khởi tạo mặc định
        public PlayGame(Int32 PlayerMoney) // Tiền mặc định của người chơi.
        {
            #region Hàm khởi tạo game
            Money = (PlayerMoney == 0) ? 5000 : PlayerMoney;
            rd = new Random(); // dùng để sinh ra 1 số ngẫu nhiên.
            #endregion
        }    

        // Trả về hình kết quả 
        public Bitmap ResultImage(int i)
        {
            #region Trả về kết quả hình ảnh
            return Image[Result[i - 1]];
            #endregion
        }

        // Xóc bầu cua
        public void Play()
        {
            #region Lắc ra số ngẫu nhiên và đóng nắp lại
            Result[0] = rd.Next(6);
            Result[1] = rd.Next(6);
            Result[2] = rd.Next(6);
            #endregion
        }

        // Mở 
        public int Open(int [] BetMoney)// Lấy tiền đặt cược 
        {
            #region Mở nắp bầu cua ra và cộng trừ điểm người chơi dựa trên kết quả
            // Tạo một biến lưu tổng tiền người chơi đặt cược
            int SumBetMoney = BetMoney.Sum();

            // Kiểm tra tổng số tiền đặt cược có lớn hơn số tiền đang có
            if (SumBetMoney > Money || SumBetMoney.Equals(0))
                return 0;
            else 
            {
                int[] ResultPlay = new int[6]; // lưu trữ lại số xúc xắc quay ra.

                // Thêm số xúc xắc ra vào mảng 
                ResultPlay[Result[0]]++;
                ResultPlay[Result[1]]++;
                ResultPlay[Result[2]]++;

                // Đặt biến xem người chơi đặt trúng hay trật
                bool Bet = false, Prize = false;
                Message = ""; // đặt thông báo rỗng
                int TotalAdditionMoney = 0, TotalMinusMoney = 0; //  Đặt tổng số điểm cộng và tổng số điểm trừ = 0
                int Total; // dùng để xuất điểm ra màn hình
                for (int i = 0; i < ResultPlay.Length; i++)
                {
                    // Kiểm tra xem người chơi có đặt tiền hay không.            
                    Bet = BetMoney[i] != 0; 
                    if (Bet)
                    {
                        // Kiểm tra xem người chơi có đặt trúng hay không. Tiến hành cộng trừ điểm
                        Prize = ResultPlay[i] != 0;
                        if(Prize)
                        {
                            int Reward = (BetMoney[i] * ResultPlay[i]); // đặt trúng thì nhân số tiền đặt với số xúc xắc ra
                            TotalAdditionMoney += Reward; // cộng tiền thưởng vào tổng tiền cộng
                            Money += Reward;
                            Message += string.Format("Bạn nhận được (+{0} điểm) từ đặt {1}.\n", Reward, Name[i]);
                        } else
                        {
                            int Minus = BetMoney[i]; // trừ số tiền bằng số tiền đặt cược
                            TotalMinusMoney += Minus;
                            Money -= Minus;
                            Message += string.Format("Bạn bị mất (-{0} điểm) từ đặt {1}.\n", Minus, Name[i]);
                        }
                    }    
                }
                Total = TotalAdditionMoney - TotalMinusMoney; // tính xem tổng tiền dương hay âm
                TotalMoney = Total;
                Message += string.Format("\nTổng điểm: {0}{1} điểm.", (Total > 0) ? "+" : "", Total);
                return 1;
            } 
            #endregion
        }

    }
}
