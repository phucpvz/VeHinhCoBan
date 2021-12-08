using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.VatThe2D
{
    public class CauVong : Hinh2D
    {
        private HinhTron v1;
        private HinhTron v2;
        private HinhTron v3;
        private HinhTron v4;
        private HinhTron v5;
        private HinhTron v6;
        private HinhTron v7;
        private HinhTron v8;

        public HinhTron V1 { get => v1; set => v1 = value; }
        public HinhTron V2 { get => v2; set => v2 = value; }
        public HinhTron V3 { get => v3; set => v3 = value; }
        public HinhTron V4 { get => v4; set => v4 = value; }
        public HinhTron V5 { get => v5; set => v5 = value; }
        public HinhTron V6 { get => v6; set => v6 = value; }
        public HinhTron V7 { get => v7; set => v7 = value; }
        public HinhTron V8 { get => v8; set => v8 = value; }

        public CauVong(HinhTron v1, HinhTron v2, HinhTron v3, HinhTron v4, HinhTron v5, HinhTron v6, HinhTron v7, HinhTron v8)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
            V5 = v5;
            V6 = v6;
            V7 = v7;
            V8 = v8;

            CacBoPhan = new List<Hinh2D>() { V1, V2, V3, V4, V5, V6, V7, V8 };

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

        public static CauVong TaoHinh()
        {
            return new CauVong(
            new HinhTron(60, 0, 70, Color.Black, Color.Red),
            new HinhTron(60, 0, 65, Color.Black, Color.Orange),
            new HinhTron(60, 0, 60, Color.Black, Color.Yellow),
            new HinhTron(60, 0, 55, Color.Black, Color.LimeGreen),
            new HinhTron(60, 0, 50, Color.Black, Color.Cyan),
            new HinhTron(60, 0, 45, Color.Black, Color.Blue),
            new HinhTron(60, 0, 40, Color.Black, Color.Purple),
            new HinhTron(60, 0, 35, Color.Black, Color.White));
        }
    }
}
