using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class HinhTron : Hinh2D
    {
        private Diem2D tam;
        private int banKinh = 0;
        private int[] doDaiCacNet;

        public Diem2D Tam 
        { 
            get => tam;
            set
            {
                tam = value;
            }
        }

        public int BanKinh 
        {
            get => banKinh;
            set 
            { 
                banKinh = value;
            }
        }

        public int[] DoDaiCacNet { get => doDaiCacNet; set => doDaiCacNet = value; }

        public HinhTron(Diem2D tam, int banKinh, Color? foreColor = null, Color? backColor = null, int[] doDaiCacNet = null)
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

            DoDaiCacNet = doDaiCacNet;

            CacDiemDacTrung = new List<Diem2D>() { Tam }; // Không đủ với phép tỷ lệ
        }

        public HinhTron(int xO, int yO, int banKinh, Color? foreColor = null, Color? backColor = null, int[] doDaiCacNet = null) 
            : this(new Diem2D(xO, yO), banKinh, foreColor, backColor, doDaiCacNet)
        {
        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.MauNuoc = BackColor;
            dh.VeHinhTron(Tam, BanKinh, DoDaiCacNet);
        }
    }
}
