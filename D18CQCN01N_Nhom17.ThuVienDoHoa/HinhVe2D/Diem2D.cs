using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class Diem2D : Hinh2D
    {
        private int x, y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public Diem2D() : this(0, 0)
        {
        }

        public Diem2D(int x, int y, Color? foreColor = null)
        {
            X = x;
            Y = y;

            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }

            CacDiemDacTrung = new List<Diem2D>() { this };
        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.PutPixel(X, Y);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }
    }
}
