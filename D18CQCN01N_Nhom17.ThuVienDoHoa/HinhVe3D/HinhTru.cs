using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe3D
{
    public class HinhTru : Hinh3D
    {
        private Diem3D tamDay;
        private int banKinhDay;
        private int chieuCao;

        public Diem3D TamDay { get => tamDay; set => tamDay = value; }
        public int BanKinhDay { get => banKinhDay; set => banKinhDay = value; }
        public int ChieuCao { get => chieuCao; set => chieuCao = value; }

        public HinhTru(Diem3D tamDay, int banKinhDay, int chieuCao, Color? foreColor = null)
        {
            TamDay = tamDay;
            BanKinhDay = banKinhDay;
            ChieuCao = chieuCao;

            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }
        }

        public HinhTru(int x, int y, int z, int banKinhDay, int chieuCao, Color? foreColor = null, Color? backColor = null)
            : this(new Diem3D(x, y, z), banKinhDay, chieuCao, foreColor)
        {
        }

        public override void VeHinh(DoHoa3D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.VeHinhTru(TamDay, BanKinhDay, ChieuCao);
        }
    }
}
