using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class HinhChuNhat : Hinh2D
    {
        private int x1, y1, x4, y4;

        public int X1 { get => x1; set => x1 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int X4 { get => x4; set => x4 = value; }
        public int Y4 { get => y4; set => y4 = value; }

        public HinhChuNhat(int x1, int y1, int x4, int y4, Color? foreColor = null, Color? backColor = null)
        {
            X1 = x1;
            Y1 = y1;
            X4 = x4;
            Y4 = y4;

            if(foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }

            if (backColor != null)
            {
                BackColor = (Color)backColor;
            }
        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.MauNuoc = BackColor;
            dh.VeHinhChuNhat(X1, Y1, X4, Y4);
        }
    }
}
