using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class HinhElipNuaKhuat : Hinh2D
    {
        private Diem2D tam;
        private int a = 0;
        private int b = 0;
        private int[] doDaiCacNet;

        public Diem2D Tam
        {
            get => tam;
            set
            {
                tam = value;
            }
        }

        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }

        public int[] DoDaiCacNet { get => doDaiCacNet; set => doDaiCacNet = value; }

        public HinhElipNuaKhuat(Diem2D tam, int a, int b, Color? foreColor = null, Color? backColor = null, int[] doDaiCacNet = null)
        {
            Tam = tam;
            A = a;
            B = b;

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

        public HinhElipNuaKhuat(int xO, int yO, int a, int b, Color? foreColor = null, Color? backColor = null, int[] doDaiCacNet = null)
            : this(new Diem2D(xO, yO), a, b, foreColor, backColor, doDaiCacNet)
        {

        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.MauNuoc = BackColor;
            dh.VeHinhElip_NuaKhuatTren(Tam, a, b, DoDaiCacNet);
        }
    }
}
