using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.VatThe2D
{
    public class MatTroi : Hinh2D
    {
        private DoanThang t1;
        private DoanThang t2;
        private DoanThang t3;
        private DoanThang t4;
        private DoanThang t5;
        private DoanThang t6;
        private DoanThang t7;
        private DoanThang t8;
        private HinhTron s;

        public HinhTron S { get => s; set => s = value; }
        public DoanThang T1 { get => t1; set => t1 = value; }
        public DoanThang T2 { get => t2; set => t2 = value; }
        public DoanThang T3 { get => t3; set => t3 = value; }
        public DoanThang T4 { get => t4; set => t4 = value; }
        public DoanThang T5 { get => t5; set => t5 = value; }
        public DoanThang T6 { get => t6; set => t6 = value; }
        public DoanThang T7 { get => t7; set => t7 = value; }
        public DoanThang T8 { get => t8; set => t8 = value; }

        public MatTroi(DoanThang t1, DoanThang t2, DoanThang t3, DoanThang t4, DoanThang t5, DoanThang t6, DoanThang t7, DoanThang t8, HinhTron s)
        {
            T1 = t1;
            T2 = t2;
            T3 = t3;
            T4 = t4;
            T5 = t5;
            T6 = t6;
            T6 = t6;
            T7 = t7;
            T8 = t8;
            S = s;

            CacBoPhan = new List<Hinh2D>() { T1, T2, T3, T4, T5, T6, T7, T8, S };

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

        public static MatTroi TaoHinh()
        {
            return new MatTroi(
            new DoanThang(-60, 62, -60, 38, Color.Firebrick),
            new DoanThang(-64, 60, -56, 40, Color.Firebrick),
            new DoanThang(-68, 58, -52, 42, Color.Firebrick),
            new DoanThang(-70, 54, -50, 46, Color.Firebrick),
            new DoanThang(-72, 50, -48, 50, Color.Firebrick),
            new DoanThang(-70, 46, -50, 54, Color.Firebrick),
            new DoanThang(-68, 42, -52, 58, Color.Firebrick),
            new DoanThang(-64, 40, -56, 60, Color.Firebrick),
            new HinhTron(-60, 50, 8, Color.Crimson, Color.Crimson)
            );
        }
    }
}
