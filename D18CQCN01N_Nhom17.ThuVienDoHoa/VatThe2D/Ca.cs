using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.VatThe2D
{
    public class Ca : Hinh2D
    {
        private TuGiac than;

        private TamGiac vay1;
        private TamGiac vay2;

        private TamGiac duoi;

        private HinhTron mat;

        public TuGiac Than { get => than; set => than = value; }
        public TamGiac Vay1 { get => vay1; set => vay1 = value; }
        public TamGiac Vay2 { get => vay2; set => vay2 = value; }
        public TamGiac Duoi { get => duoi; set => duoi = value; }
        public HinhTron Mat { get => mat; set => mat = value; }
        public Ca(TuGiac than, TamGiac vay1, TamGiac vay2, TamGiac duoi, HinhTron mat)
        {
            Than = than;
            Vay1 = vay1;
            Vay2 = vay2;
            Duoi = duoi;
            Mat = mat;

            CacBoPhan = new List<Hinh2D>() { Vay1, Vay2, Duoi, Than, Mat };

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

        public static Ca TaoHinh()
        {
            return new Ca(new TuGiac(0, -18, 10, -8, 20, -18, 10, -28, Color.Black, Color.Gray),
            new TamGiac(12, -11, 15, -14, 18, -11, Color.Black, Color.Gray),
            new TamGiac(12, -26, 16, -22, 18, -26, Color.Black, Color.Gray),
            new TamGiac(18, -18, 24, -12, 24, -24, Color.Black, Color.Gray),
            new HinhTron(5, -18, 2, Color.Black, Color.Black));
        }
    }
}
