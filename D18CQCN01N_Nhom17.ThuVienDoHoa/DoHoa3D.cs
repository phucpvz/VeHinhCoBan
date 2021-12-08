using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe3D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa
{
    public sealed class DoHoa3D
    {
        private static readonly double HE_SO_CABINET = Math.Sqrt(2) / 4;
        private static Font font3D = new Font("Arial", 14);

        private DoHoa2D tool2D;
        public DoHoa2D Tool2D { get => tool2D; set => tool2D = value; }

        public Graphics G { get => Tool2D.G; set => Tool2D.G = value; }

        // Số pixel màn hình ứng với một đơn vị trong hệ tọa độ người dùng
        public const int PIXELS = DoHoa2D.PIXELS;

        public Control KhungVe
        {
            get => Tool2D.KhungVe;
            set
            {
                Tool2D.KhungVe = value;
            }
        }

        public Color MauNetVe
        {
            get => Tool2D.MauNetVe;
            set
            {
                Tool2D.MauNetVe = value;
            }
        }

        public Color MauNuoc
        {
            get => Tool2D.MauNuoc;
            set => Tool2D.MauNuoc = value;
        }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="khungVe">Là một Control bất kỳ để vẽ hình lên đó, ví dụ: Panel</param>
        public DoHoa3D(Control khungVe)
        {
            Tool2D = new DoHoa2D(khungVe);
        }

        public void VeHeTrucToaDo(Color? mau = null)
        {
            Pen p = new Pen(Color.Black);
            p.Color = (mau == null) ? MauNetVe : (Color)mau;

            // Vẽ trục Ox
            G.DrawLine(p, 0, KhungVe.Height / 2, KhungVe.Width, KhungVe.Height / 2);
            // Vẽ trục Oz
            G.DrawLine(p, KhungVe.Width / 2, 0, KhungVe.Width / 2, KhungVe.Height);

            // Vẽ đầu mũi tên trục Ox
            G.DrawLine(p, KhungVe.Width, KhungVe.Height / 2, KhungVe.Width - PIXELS, KhungVe.Height / 2 - PIXELS);
            G.DrawLine(p, KhungVe.Width, KhungVe.Height / 2, KhungVe.Width - PIXELS, KhungVe.Height / 2 + PIXELS);
            G.DrawString("x", font3D, new SolidBrush(Color.Red), KhungVe.Width - 5 * PIXELS, KhungVe.Height / 2 + 3 * PIXELS);

            // Vẽ đầu mũi tên trục Oz
            G.DrawLine(p, KhungVe.Width / 2, 0, KhungVe.Width / 2 - PIXELS, PIXELS);
            G.DrawLine(p, KhungVe.Width / 2, 0, KhungVe.Width / 2 + PIXELS, PIXELS);
            G.DrawString("z", font3D, new SolidBrush(Color.Red), KhungVe.Width / 2 - 5 * PIXELS, 0);

            // Vẽ trục Oy
            int min = Math.Min(KhungVe.Width, KhungVe.Height);
            Point gocToaDo = Tool2D.Tu2DSangMay(0, 0).ToPoint();
            Point d1 = new Point(gocToaDo.X - min / 2, gocToaDo.Y + min / 2);
            Point d2 = new Point(gocToaDo.X + min / 2, gocToaDo.Y - min / 2);
            G.DrawLine(p, d1.X, d1.Y, d2.X, d2.Y);

            // Vẽ đầu mũi tên trục Oy
            G.DrawLine(p, d1.X, d1.Y, d1.X, d1.Y - 2 * PIXELS);
            G.DrawLine(p, d1.X, d1.Y, d1.X + 2 * PIXELS, d1.Y - PIXELS);
            G.DrawString("y", font3D, new SolidBrush(Color.Red), d1.X + 5 * PIXELS, d1.Y - 5 * PIXELS);

            // Vẽ gốc tọa độ O
            G.DrawString("O", font3D, new SolidBrush(Color.Red), KhungVe.Width / 2 + 2 * PIXELS, KhungVe.Height / 2 + 2 * PIXELS);
        }

        // Dùng phép chiếu Cabinet, khử trục Oy
        public Diem2D Tu3DSang2D(int x, int y, int z)
        {
            Diem2D diem2D = new Diem2D();
            diem2D.X = (int)Math.Round(x - y * HE_SO_CABINET);
            diem2D.Y = (int)Math.Round(z - y * HE_SO_CABINET);

            return diem2D;
        }

        public Diem2D Tu3DSang2D(Diem3D diem3D)
        {
            return Tu3DSang2D(diem3D.X, diem3D.Y, diem3D.Z);
        }

        public void PutPixel(int x, int y, int z)
        {
            Diem2D diem2D = Tu3DSang2D(x, y, z);
            tool2D.PutPixel(diem2D.X, diem2D.Y);
        }

        public void VeHinhCau(int x, int y, int z, int r)
        {
            Diem2D diem2D = Tu3DSang2D(x, y, z);
            int x0 = diem2D.X;
            int y0 = diem2D.Y;
            // Trục bé của elip
            int b = (int)Math.Round(r * HE_SO_CABINET);

            tool2D.VeHinhTron(x0, y0, r);
            tool2D.VeHinhElip_NuaKhuatTren(x0, y0, r, b, new int[] { 2, 2 });
            tool2D.VeDoanThang(x0, y0, x0 + r, y0, new int[] { 2, 2 });
        }

        public void VeHinhCau(Diem3D diem3D, int r)
        {
            int x = diem3D.X;
            int y = diem3D.Y;
            int z = diem3D.Z;

            VeHinhCau(x, y, z, r);
        }

        public void VeHinhTru(int x, int y, int z, int r, int h)
        {
            Diem2D diem2D = Tu3DSang2D(x, y, z);
            int x0 = diem2D.X;
            int y0 = diem2D.Y;

            // Trục bé của elip
            int b = (int)Math.Round(r * HE_SO_CABINET);

            // Vẽ đáy dưới
            tool2D.VeHinhElip_NuaKhuatTren(x0, y0, r, b, new int[] { 2, 2 });

            // Vẽ đáy trên
            tool2D.VeHinhElip(x0, y0 + h, r, b);

            // Vẽ 2 cạnh bên
            tool2D.VeDoanThang(x0 - r, y0, x0 - r, y0 + h);
            tool2D.VeDoanThang(x0 + r, y0, x0 + r, y0 + h);

            // Đoạn thẳng nối 2 tâm đáy
            tool2D.VeDoanThang(x0, y0, x0, y0 + h, new int[] { 2, 2 });

            // Vẽ bán kính dưới
            tool2D.VeDoanThang(x0, y0, x0 + r, y0, new int[] { 2, 2 });

            // Vẽ bán kính trên
            tool2D.VeDoanThang(x0, y0 + h, x0 + r, y0 + h);
        }

        public void VeHinhTru(Diem3D tamDay, int r, int h)
        {
            int x = tamDay.X;
            int y = tamDay.Y;
            int z = tamDay.Z;

            VeHinhTru(x, y, z, r, h);
        }

        public void VeHinhNon(int x, int y, int z, int r, int h)
        {
            Diem2D diem2D = Tu3DSang2D(x, y, z);
            int x0 = diem2D.X;
            int y0 = diem2D.Y;

            // Trục bé của elip
            int b = (int)Math.Round(r * HE_SO_CABINET);

            // Vẽ đáy
            tool2D.VeHinhElip_NuaKhuatTren(x0, y0, r, b, new int[] { 2, 2 });

            // Vẽ các đoạn thẳng
            tool2D.VeDoanThang(x0, y0, x0, y0 + h, new int[] { 2, 2 });
            tool2D.VeDoanThang(x0, y0, x0 + r, y0, new int[] { 2, 2 });
            tool2D.VeDoanThang(x0 - r, y0, x0, y0 + h);
            tool2D.VeDoanThang(x0 + r, y0, x0, y0 + h);
        }

        public void VeHinhNon(Diem3D tamDay, int r, int h)
        {
            int x = tamDay.X;
            int y = tamDay.Y;
            int z = tamDay.Z;

            VeHinhNon(x, y, z, r, h);
        }

        public void VeHinhHopChuNhat(Diem3D B1, int dai, int rong, int cao)
        {
            int x0 = B1.X;
            int y0 = B1.Y;
            int z0 = B1.Z;

            Diem3D A1 = new Diem3D(x0, y0 + rong, z0);
            Diem3D C1 = new Diem3D(x0 + dai, y0, z0);
            Diem3D D1 = new Diem3D(x0 + dai, y0 + rong, z0);
            Diem3D A = new Diem3D(x0, y0 + rong, z0 + cao);
            Diem3D B = new Diem3D(x0, y0, z0 + cao);
            Diem3D C = new Diem3D(x0 + dai, y0, z0 + cao);
            Diem3D D = new Diem3D(x0 + dai, y0 + rong, z0 + cao);

            Diem2D a1 = Tu3DSang2D(A1);
            Diem2D b1 = Tu3DSang2D(B1);
            Diem2D c1 = Tu3DSang2D(C1);
            Diem2D d1 = Tu3DSang2D(D1);
            Diem2D a = Tu3DSang2D(A);
            Diem2D b = Tu3DSang2D(B);
            Diem2D c = Tu3DSang2D(C);
            Diem2D d = Tu3DSang2D(D);

            // Vẽ 3 đoạn thẳng nét khuất
            Tool2D.VeDoanThang(a1, b1, new int[] { 2, 2 });
            Tool2D.VeDoanThang(b1, c1, new int[] { 2, 2 });
            Tool2D.VeDoanThang(b1, b, new int[] { 2, 2 });

            // Vẽ 9 đoạn thẳng nét liền
            Tool2D.VeTuGiac(a, b, c, d);
            Tool2D.VeDoanThang(a, a1);
            Tool2D.VeDoanThang(d, d1);
            Tool2D.VeDoanThang(c, c1);
            Tool2D.VeDoanThang(a1, d1);
            Tool2D.VeDoanThang(d1, c1);
        }

        public void VeHinhHopChuNhat(int x, int y, int z, int d, int r, int h)
        {
            Diem3D B1 = new Diem3D(x, y, z);

            VeHinhHopChuNhat(B1, d, r, h);
        }
    }
}
