using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe3D
{
    public class HinhCau : Hinh3D
    {
        private Diem3D tam;
        private int banKinh;

        public Diem3D Tam { get => tam; set => tam = value; }
        public int BanKinh { get => banKinh; set => banKinh = value; }

        public HinhCau(Diem3D tam, int banKinh, Color? foreColor = null)
        {
            Tam = tam;
            BanKinh = banKinh;

            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }
        }

        public HinhCau(int xO, int yO, int zO, int banKinh, Color? foreColor = null, Color? backColor = null)
            : this(new Diem3D(xO, yO, zO), banKinh, foreColor)
        {
        }

        public override void VeHinh(DoHoa3D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.VeHinhCau(Tam, BanKinh);
        }
    }
}
