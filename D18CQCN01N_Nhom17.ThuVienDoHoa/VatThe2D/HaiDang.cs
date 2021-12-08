using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.VatThe2D
{
    public class HaiDang : Hinh2D
    {
        private TuGiac dat;
        private TuGiac t1;
        private TuGiac t2;
        private TuGiac t3;
        private TuGiac t4;
        private TamGiac maiNha;
        private TuGiac cuaNha;

        public TuGiac Dat { get => dat; set => dat = value; }
        public TuGiac T1 { get => t1; set => t1 = value; }
        public TuGiac T2 { get => t2; set => t2 = value; }
        public TuGiac T3 { get => t3; set => t3 = value; }
        public TuGiac T4 { get => t4; set => t4 = value; }
        public TamGiac Mai { get => maiNha; set => maiNha = value; }
        public TuGiac Cua { get => cuaNha; set => cuaNha = value; }

        public HaiDang(TuGiac dat, TuGiac t1, TuGiac t2, TuGiac t3, TuGiac t4, TamGiac mai, TuGiac cua)
        {
            Dat = dat;
            T1 = t1;
            T2 = t2;
            T3 = t3;
            T4 = t4;
            Mai = mai;
            Cua = cua;

            CacBoPhan = new List<Hinh2D>() { Dat, T1, T2, T3, T4, Mai, Cua };

            CacDiemDacTrung = new List<Diem2D>();
            foreach (Hinh2D hinh in CacBoPhan)
            {
                foreach (Diem2D diem in hinh.CacDiemDacTrung)
                {
                    CacDiemDacTrung.Add(diem);
                }
            }
        }
        public override void VeHinh(DoHoa2D dh)
        {
            foreach (Hinh2D hinh in CacBoPhan)
            {
                hinh.VeHinh(dh);
            }
        }

        public static HaiDang TaoHinh()
        {
            return new HaiDang(
            new TuGiac(-120, 0, -70, 0, -70, 5, -120, 5, Color.Brown, Color.Brown),
            new TuGiac(-111, 5, -89, 5, -93, 20, -107, 20, Color.Black, Color.Red),
            new TuGiac(-93, 20, -107, 20, -107, 35, -93, 35, Color.Black, Color.White),
            new TuGiac(-107, 35, -93, 35, -96, 50, -104, 50, Color.Black, Color.Red),
            new TuGiac(-96, 50, -104, 50, -104, 58, -96, 58, Color.Black, Color.Yellow),
            new TamGiac(-107, 58, -93, 58, -100, 62, Color.Black, Color.Red),
            new TuGiac(-103, 5, -97, 5, -97, 9, -103, 9, Color.Black, Color.Black));
        }
    }
}
