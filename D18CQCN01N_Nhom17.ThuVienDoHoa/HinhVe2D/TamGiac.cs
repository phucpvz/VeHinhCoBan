using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class TamGiac : Hinh2D
    {
        private Diem2D a;
        private Diem2D b;
        private Diem2D c;

        public Diem2D A { get => a; set => a = value; }
        public Diem2D B { get => b; set => b = value; }
        public Diem2D C { get => c; set => c = value; }

        public TamGiac(Diem2D a, Diem2D b, Diem2D c, Color? foreColor = null, Color? backColor = null)
        {
            A = a;
            B = b;
            C = c;
            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }
            if (backColor != null)
            {
                BackColor = (Color)backColor;
            }

            CacDiemDacTrung = new List<Diem2D>() { A, B, C };
        }

        public TamGiac(int xA, int yA, int xB, int yB, int xC, int yC, Color? foreColor = null, Color? backColor = null)
            : this(new Diem2D(xA, yA), new Diem2D(xB, yB), new Diem2D(xC, yC), foreColor, backColor)
        {
        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.MauNuoc = BackColor;
            dh.VeTamGiac(A, B, C);
        }

    }
}
