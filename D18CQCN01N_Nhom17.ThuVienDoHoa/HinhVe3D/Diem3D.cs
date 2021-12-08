using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe3D
{
    public class Diem3D : Hinh3D
    {
        private int x, y, z;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }

        public Diem3D() : this(0, 0, 0)
        {
        }

        public Diem3D(int x, int y, int z, Color? foreColor = null)
        {
            X = x;
            Y = y;
            Z = z;

            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }
        }

        public override void VeHinh(DoHoa3D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.PutPixel(X, Y, Z);
        }
        
    }
}
