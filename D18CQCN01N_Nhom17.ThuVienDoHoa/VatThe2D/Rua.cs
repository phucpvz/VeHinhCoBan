using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.VatThe2D
{
    public class Rua : Hinh2D
    {
        private HinhTron c1;
        private HinhTron c2;
        private HinhTron c3;
        private HinhTron c4;
        private HinhTron dau;
        private TamGiac duoi;
        private HinhTron than;

        public HinhTron C1 { get => c1; set => c1 = value; }
        public HinhTron C2 { get => c2; set => c2 = value; }
        public HinhTron C3 { get => c3; set => c3 = value; }
        public HinhTron C4 { get => c4; set => c4 = value; }
        public HinhTron Dau { get => dau; set => dau = value; }
        public TamGiac Duoi { get => duoi; set => duoi = value; }
        public HinhTron Than { get => than; set => than = value; }

        public Rua(HinhTron c1, HinhTron c2, HinhTron c3, HinhTron c4, HinhTron dau, TamGiac duoi, HinhTron than)
        {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            Dau = dau;
            Duoi = duoi;
            Than = than;

            CacBoPhan = new List<Hinh2D>() { C1, C2, C3, C4, Dau, Duoi, Than };

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

        public static Rua TaoHinh()
        {
           return new Rua(new HinhTron(-7, -42, 2, Color.Black, Color.Wheat),
           new HinhTron(-7, -58, 2, Color.Black, Color.Wheat),
           new HinhTron(7, -42, 2, Color.Black, Color.Wheat),
           new HinhTron(7, -58, 2, Color.Black, Color.Wheat),
           new HinhTron(14, -50, 4, Color.Black, Color.Wheat),
           new TamGiac(-10, -51, -15, -50, -10, -49, Color.Black, Color.Wheat),
           new HinhTron(0, -50, 10, Color.Black, Color.SeaGreen));
        }

    }
}
