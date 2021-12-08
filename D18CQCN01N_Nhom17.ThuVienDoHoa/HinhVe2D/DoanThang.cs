using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class DoanThang : Hinh2D
    {
        private Diem2D a;
        private Diem2D b;
        private int[] doDaiCacNet;

        public Diem2D A { get => a; set => a = value; }
        public Diem2D B { get => b; set => b = value; }
        public int[] DoDaiCacNet { get => doDaiCacNet; set => doDaiCacNet = value; }

        public DoanThang(Diem2D a, Diem2D b, Color? foreColor = null, int[] doDaiCacNet = null)
        {
            A = a;
            B = b;
            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }

            DoDaiCacNet = doDaiCacNet;

            CacDiemDacTrung = new List<Diem2D>() { A, B };
        }

        public DoanThang(int xA, int yA, int xB, int yB, Color? foreColor = null, int[] doDaiCacNet = null) 
            : this(new Diem2D(xA, yA), new Diem2D(xB, yB), foreColor, doDaiCacNet)
        {
        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.VeDoanThang(A, B, DoDaiCacNet);
        }

    }
}
