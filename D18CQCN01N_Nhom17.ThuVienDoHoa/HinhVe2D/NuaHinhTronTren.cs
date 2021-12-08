using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class NuaHinhTronTren : Hinh2D
    {
        private Diem2D tam;
        private int banKinh = 0;

        public Diem2D Tam
        {
            get => tam;
            set => tam = value;
        }
        public int BanKinh
        {
            get => banKinh;
            set => banKinh = value;
        }

        public NuaHinhTronTren(Diem2D tam, int banKinh, Color? foreColor = null, Color? backColor = null)
        {
            Tam = tam;
            BanKinh = banKinh;

            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }

            if (backColor != null)
            {
                BackColor = (Color)backColor;
            }

            CacDiemDacTrung = new List<Diem2D>() { Tam }; // Không đủ với phép tỷ lệ
            CacBoPhan.Add(this);
        }

        public NuaHinhTronTren(int xO, int yO, int banKinh, Color? foreColor = null, Color? backColor = null)
            : this(new Diem2D(xO, yO), banKinh, foreColor, backColor)
        {
        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.MauNuoc = BackColor;
            dh.VeNuaHinhTronTren(Tam, BanKinh);
        }
    }
}
