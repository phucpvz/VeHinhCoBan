using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class TuGiac : Hinh2D
    {
        private Diem2D a;
        private Diem2D b;
        private Diem2D c;
        private Diem2D d;

        public Diem2D A { get => a; set => a = value; }
        public Diem2D B { get => b; set => b = value; }
        public Diem2D C { get => c; set => c = value; }
        public Diem2D D { get => d; set => d = value; }

        public TuGiac(Diem2D a, Diem2D b, Diem2D c, Diem2D d, Color? foreColor = null, Color? backColor = null)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }
            if (backColor != null)
            {
                BackColor = (Color)backColor;
            }

            CacDiemDacTrung = new List<Diem2D>() { A, B, C, D };
        }

        public TuGiac(int xA, int yA, int xB, int yB, int xC, int yC, int xD, int yD, Color? foreColor = null, Color? backColor = null)
            : this(new Diem2D(xA, yA), new Diem2D(xB, yB), new Diem2D(xC, yC), new Diem2D(xD, yD), foreColor, backColor)
        {
        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.MauNuoc = BackColor;
            dh.VeTuGiac(A, B, C, D);
        }

        public static TuGiac TaoHinh()
        {
            return new TuGiac(-150, 0, 150, 0, 150, -70, -150, -70, Color.Aqua, Color.Aqua);
        }

    }
}
