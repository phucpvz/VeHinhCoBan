using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using D18CQCN01N_Nhom17.ThuVienDoHoa.TienIch;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa
{
    // Thư viện đồ họa chứa các phương thức để vẽ các hình học cơ bản trong không gian 2 chiều
    public sealed class DoHoa2D
    {
        private static Font font2D = new Font("Arial", 14);

        private Graphics g;
        public Graphics G { get => g; set => g = value; }

        // Số pixel màn hình ứng với một đơn vị trong hệ tọa độ người dùng
        public const int PIXELS = 5;

        private Control khungVe;

        private Pen butVe1;
        private SolidBrush butVe2;
        private SolidBrush coVe;

        public Control KhungVe
        {
            get => khungVe;
            set
            {
                khungVe = value;
            }
        }

        public Color MauNetVe
        {
            get => butVe1.Color;
            set
            {
                butVe1.Color = butVe2.Color = value;
            }
        }

        public Color MauNuoc { get => coVe.Color; set => coVe.Color = value; }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="khungVe">Là một Control bất kỳ để vẽ hình lên đó, ví dụ: Panel</param>
        public DoHoa2D(Control khungVe)
        {
            KhungVe = khungVe;
            butVe1 = new Pen(Color.Black);
            butVe2 = new SolidBrush(Color.Black);
            coVe = new SolidBrush(Color.Transparent);

            MauNetVe = Color.Black;
        }

        public void VeLuoiToaDo(Color? mau = null)
        {
            Pen p = new Pen(Color.Black);
            p.Color = (mau == null) ? butVe1.Color : (Color)mau;

            // Vẽ lưới dọc
            for (int i = 0; i <= KhungVe.Width / PIXELS; i++)
            {
                G.DrawLine(p, PIXELS * i, 0, PIXELS * i, KhungVe.Height);
            }
            // Vẽ lưới ngang
            for (int j = 0; j <= KhungVe.Height / PIXELS; j++)
            {
                G.DrawLine(p, 0, PIXELS * j, KhungVe.Width, PIXELS * j);
            }
        }

        public void VeTrucToaDo(Color? mau = null)
        {
            Pen p = new Pen(Color.Black, 3);
            p.Color = (mau == null) ? butVe1.Color : (Color)mau;

            // Vẽ trục Ox
            G.DrawLine(p, 0, KhungVe.Height / 2, KhungVe.Width, KhungVe.Height / 2);
            // Vẽ trục Oy
            G.DrawLine(p, KhungVe.Width / 2, 0, KhungVe.Width / 2, KhungVe.Height);

            // Vẽ đầu mũi tên trục Ox
            G.DrawLine(p, KhungVe.Width, KhungVe.Height / 2, KhungVe.Width - PIXELS, KhungVe.Height / 2 - PIXELS);
            G.DrawLine(p, KhungVe.Width, KhungVe.Height / 2, KhungVe.Width - PIXELS, KhungVe.Height / 2 + PIXELS);
            G.DrawString("x", font2D, new SolidBrush(Color.Red), KhungVe.Width - 5 * PIXELS, KhungVe.Height / 2 + 3 * PIXELS);
            // Vẽ đầu mũi tên trục Oy
            G.DrawLine(p, KhungVe.Width / 2, 0, KhungVe.Width / 2 - PIXELS, PIXELS);
            G.DrawLine(p, KhungVe.Width / 2, 0, KhungVe.Width / 2 + PIXELS, PIXELS);
            G.DrawString("y", font2D, new SolidBrush(Color.Red), KhungVe.Width / 2 - 5 * PIXELS, 0);

            // Vẽ gốc tọa độ O
            G.DrawString("O", font2D, new SolidBrush(Color.Red), KhungVe.Width / 2 + 2 * PIXELS, KhungVe.Height / 2 + 2 * PIXELS);
        }

        public Diem2D Tu2DSangMay(int x, int y)
        {
            Diem2D may = new Diem2D();
            may.X = x * PIXELS + KhungVe.Width / 2;
            may.Y = KhungVe.Height / 2 - y * PIXELS;

            return may;
        }

        public Diem2D TuMaySang2D(int x0, int y0)
        {
            x0 = TinhToan.LayGiaTriGanDung(x0, PIXELS);
            y0 = TinhToan.LayGiaTriGanDung(y0, PIXELS);

            Diem2D thuc = new Diem2D();
            thuc.X = (x0 - KhungVe.Width / 2) / PIXELS;
            thuc.Y = (KhungVe.Height / 2 - y0) / PIXELS;

            return thuc;
        }

        public Diem2D Tu2DSangMay(Diem2D diem)
        {
            return Tu2DSangMay(diem.X, diem.Y);
        }

        public Diem2D TuMaySang2D(Diem2D diem)
        {
            return TuMaySang2D(diem.X, diem.Y);
        }

        // x, y theo hệ tọa độ người dùng
        public void PutPixel(int x, int y)
        {
            Diem2D may = Tu2DSangMay(x, y);
            int x0 = may.X;
            int y0 = may.Y;

            if (x0 < 0 || x0 > KhungVe.Width || y0 < 0 || y0 > KhungVe.Height)
            {
                return;
            }

            int size = 2;

            G.DrawRectangle(butVe1, x0 - size, y0 - size, size, size);
            G.FillRectangle(butVe2, x0 - size, y0 - size, size, size);

            G.DrawRectangle(butVe1, x0, y0 - size, size, size);
            G.FillRectangle(butVe2, x0, y0 - size, size, size);

            G.DrawRectangle(butVe1, x0 - size, y0, size, size);
            G.FillRectangle(butVe2, x0 - size, y0, size, size);

            G.DrawRectangle(butVe1, x0, y0, size, size);
            G.FillRectangle(butVe2, x0, y0, size, size);
        }

        public void PutPixel(Diem2D diem)
        {
            PutPixel(diem.X, diem.Y);
        }

        // Vẽ 1/8 đường tròn và lấy đối xứng qua Ox, Oy, O đường thẳng và x = y (nếu x0 = 0 và y0 = 0)
        public void Put8Pixel(int x0, int y0, int x, int y)
        {
            PutPixel(x0 + x, y0 + y);

            PutPixel(x0 - x, y0 + y);

            PutPixel(x0 + x, y0 - y);

            PutPixel(x0 - x, y0 - y);

            PutPixel(x0 + y, y0 + x);

            PutPixel(x0 - y, y0 + x);

            PutPixel(x0 + y, y0 - x);

            PutPixel(x0 - y, y0 - x);
        }

        public void Put4Pixel_Top(int x0, int y0, int x, int y)
        {
            PutPixel(x0 + x, y0 + y);

            PutPixel(x0 - x, y0 + y);

            PutPixel(x0 + y, y0 + x);

            PutPixel(x0 - y, y0 + x);

        }

        public void Put4Pixel(int xc, int yc, int x, int y)
        {
            PutPixel(xc + x, yc + y);
            PutPixel(xc - x, yc + y);
            PutPixel(xc + x, yc - y);
            PutPixel(xc - x, yc - y);
        }

        public void Put2Pixel_Top(int xc, int yc, int x, int y)
        {
            PutPixel(xc + x, yc + y);
            PutPixel(xc - x, yc + y);
        }

        public void Put2Pixel_Bottom(int xc, int yc, int x, int y)
        {
            PutPixel(xc + x, yc - y);
            PutPixel(xc - x, yc - y);
        }

        // Các phương thức vẽ đoạn thẳng áp dụng thuật toán Bresenham
        // Tham số theo hệ tọa độ người dùng
        // Trong đó có biến mảng doDaiNet lưu độ dài của các nét liền và đứt trong một chu kỳ
        // Chỉ số chẵn là độ dài nét liền, chỉ số lẻ là độ dài nét đứt
        public void VeDoanThang(int x1, int y1, int x2, int y2, int[] doDaiCacNet = null)
        {
            int dem = 0;
            if (doDaiCacNet == null)
            {
                doDaiCacNet = new int[] { 1 };
            }

            int x, y, Dx, Dy;
            Dx = Math.Abs(x2 - x1);
            Dy = Math.Abs(y2 - y1);

            x = x1;
            y = y1;

            int x_unit = 1, y_unit = 1;

            // Xét trường hợp để cho y_unit và x_unit để vẽ tăng lên hay giảm xuống
            if (x2 - x1 < 0)
                x_unit = -x_unit;
            if (y2 - y1 < 0)
                y_unit = -y_unit;

            // Luôn vẽ điểm đầu tiên
            PutPixel(x, y);
            ++dem;

            if (x1 == x2)   // trường hợp vẽ đường thẳng đứng
            {
                while (y != y2)
                {
                    y += y_unit;
                    if (TinhToan.LaNetLien(dem, doDaiCacNet))
                    {
                        PutPixel(x, y);
                    }
                    ++dem;
                }
            }

            else if (y1 == y2)  // trường hợp vẽ đường ngang
            {
                while (x != x2)
                {
                    x += x_unit;
                    if (TinhToan.LaNetLien(dem, doDaiCacNet))
                    {
                        PutPixel(x, y);
                    }
                    ++dem;
                }
            }
            // trường hợp vẽ các đường xiên
            else if (Dx >= Dy)
            {
                int p = 2 * Dy - Dx;
                while (x != x2)
                {
                    if (p < 0) p += 2 * Dy;
                    else
                    {
                        p += 2 * (Dy - Dx);
                        y += y_unit;
                    }
                    x += x_unit;
                    if (TinhToan.LaNetLien(dem, doDaiCacNet))
                    {
                        PutPixel(x, y);
                    }
                    ++dem;
                }
            }
            else
            {
                int p = 2 * Dx - Dy;
                while (y != y2)
                {
                    if (p < 0) p += 2 * Dx;
                    else
                    {
                        p += 2 * (Dx - Dy);
                        x += x_unit;
                    }
                    y += y_unit;
                    if (TinhToan.LaNetLien(dem, doDaiCacNet))
                    {
                        PutPixel(x, y);
                    }
                    ++dem;
                }
            }
        }

        public void VeDoanThang(Diem2D p1, Diem2D p2, int[] doDaiCacNet = null)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            VeDoanThang(x1, y1, x2, y2, doDaiCacNet);
        }

        public void VeMuiTen(MuiTen t)
        {
            if (t.Ben1 == null || t.Ben2 == null)
            {
                return;
            }

            // Vẽ đoạn thẳng tương ứng với mũi tên
            VeDoanThang(t.Dau, t.Cuoi);

            // 2 đỉnh bên của đầu mũi tên
            Diem2D m = t.Ben1;
            Diem2D n = t.Ben2;

            // Vẽ đầu mũi tên là hình tam giác
            VeDoanThang(m, t.Cuoi);
            VeDoanThang(n, t.Cuoi);
            VeDoanThang(m, n);
        }

        public void VeMuiTen(int x1, int y1, int x2, int y2)
        {
            // Tạo một đối tượng mũi tên
            MuiTen t = new MuiTen(x1, y1, x2, y2);
            VeMuiTen(t);
        }

        public void VeMuiTen(Diem2D first, Diem2D last)
        {
            // Tạo một đối tượng mũi tên
            MuiTen t = new MuiTen(first, last);
            VeMuiTen(t);
        }

        public void VeHinhChuNhat(int x1, int y1, int x4, int y4)
        {
            // Tô màu trước
            G.FillRectangle(coVe, x1, y1, x4, y4);

            Diem2D p1 = new Diem2D(x1, y1);
            Diem2D p2 = new Diem2D(x4, y1);
            Diem2D p3 = new Diem2D(x1, y4);
            Diem2D p4 = new Diem2D(x4, y4);

            VeDoanThang(p1, p2);
            VeDoanThang(p2, p4);
            VeDoanThang(p4, p3);
            VeDoanThang(p3, p1);
        }

        public void VeHinhChuNhat(Diem2D p1, Diem2D p4)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x4 = p4.X;
            int y4 = p4.Y;

            VeHinhChuNhat(x1, y1, x4, y4);
        }

        public void VeTamGiac(int xA, int yA, int xB, int yB, int xC, int yC)
        {
            Diem2D A = new Diem2D(xA, yA);
            Diem2D B = new Diem2D(xB, yB);
            Diem2D C = new Diem2D(xC, yC);
            VeTamGiac(A, B, C);
        }

        public void VeTamGiac(Diem2D A, Diem2D B, Diem2D C)
        {
            // Tô màu trước
            G.FillPolygon(coVe, new PointF[]
                {
                    Tu2DSangMay(A).ToPoint(),
                    Tu2DSangMay(B).ToPoint(),
                    Tu2DSangMay(C).ToPoint()
                });

            VeDoanThang(A, B);
            VeDoanThang(A, C);
            VeDoanThang(B, C);
        }

        public void VeTuGiac(int xA, int yA, int xB, int yB, int xC, int yC, int xD, int yD)
        {
            Diem2D A = new Diem2D(xA, yA);
            Diem2D B = new Diem2D(xB, yB);
            Diem2D C = new Diem2D(xC, yC);
            Diem2D D = new Diem2D(xD, yD);
            VeTuGiac(A, B, C, D);
        }

        public void VeTuGiac(Diem2D A, Diem2D B, Diem2D C, Diem2D D)
        {
            // Tô màu trước
            G.FillPolygon(coVe, new PointF[]
                {
                    Tu2DSangMay(A).ToPoint(),
                    Tu2DSangMay(B).ToPoint(),
                    Tu2DSangMay(C).ToPoint(),
                    Tu2DSangMay(D).ToPoint()
                });

            VeDoanThang(A, B);
            VeDoanThang(B, C);
            VeDoanThang(C, D);
            VeDoanThang(D, A);
        }

        public void VeHinhTron(int xO, int yO, int r, int[] doDaiCacNet = null)
        {
            // Tô màu trước
            Point point = Tu2DSangMay(xO - r, yO + r).ToPoint();
            int d = 2 * r * PIXELS;
            G.FillEllipse(coVe, point.X, point.Y, d, d);

            int dem = 0;
            if (doDaiCacNet == null)
            {
                doDaiCacNet = new int[] { 1 };
            }

            int dung = (int)Math.Floor(r * Math.Sqrt(2) / 2);
            int x = 0;
            int y = r;
            int p = 3 - 2 * r;

            // Vẽ điểm bắt đầu và các điểm đối xứng với nó
            Put8Pixel(xO, yO, x, y);

            while (x < dung)
            {
                if (p < 0)
                {
                    p = p + 4 * x + 6;
                }
                else
                {
                    --y;
                    p = p + 4 * (x - y) + 10;
                }
                ++x;
                ++dem;
                if (TinhToan.LaNetLien(dem, doDaiCacNet))
                {
                    Put8Pixel(xO, yO, x, y);
                }
            }
        }

        public void VeHinhTron(Diem2D O, int r, int[] doDaiCacNet = null)
        {
            VeHinhTron(O.X, O.Y, r, doDaiCacNet);
        }

        public void VeNuaHinhTronTren(int xO, int yO, int r, int[] doDaiCacNet = null)
        {
            // Tô màu trước
            Point point = Tu2DSangMay(xO - r, yO + r).ToPoint();
            int d = 2 * r * PIXELS;
            G.FillPie(coVe, point.X, point.Y, d, d, 180, 180);

            int dem = 0;
            if (doDaiCacNet == null)
            {
                doDaiCacNet = new int[] { 1 };
            }

            int dung = (int)Math.Floor(r * Math.Sqrt(2) / 2);
            int x = 0;
            int y = r;
            int p = 3 - 2 * r;

            // Vẽ điểm bắt đầu và các điểm đối xứng với nó
            Put4Pixel_Top(xO, yO, x, y);

            while (x < dung)
            {
                if (p < 0)
                {
                    p = p + 4 * x + 6;
                }
                else
                {
                    --y;
                    p = p + 4 * (x - y) + 10;
                }
                ++x;
                ++dem;
                if (TinhToan.LaNetLien(dem, doDaiCacNet))
                {
                    Put4Pixel_Top(xO, yO, x, y);
                }
            }

            // Vẽ đoạn thẳng đáy
            VeDoanThang(xO - r, yO, xO + r, yO);
        }

        public void VeNuaHinhTronTren(Diem2D diem, int r, int[] doDaiCacNet = null)
        {
            int x = diem.X;
            int y = diem.Y;

            VeNuaHinhTronTren(x, y, r, doDaiCacNet);
        }

        public void VeHinhElip(int x_center, int y_center, int a, int b, int[] doDaiCacNet = null)
        {
            // Tô màu Elip
            Point point = Tu2DSangMay(x_center - a, y_center + b).ToPoint();
            G.FillEllipse(coVe, point.X, point.Y, 2 * a * PIXELS, 2 * b * PIXELS);

            int dem = 0;
            if (doDaiCacNet == null)
            {
                doDaiCacNet = new int[] { 1 };
            }

            float p, a2, b2;
            int x, y;
            a2 = a * a;
            b2 = b * b;
            x = 0;
            y = b;

            p = 2 * ((float)b2 / a2) - (2 * b) + 1;

            // Vẽ nhánh thứ nhất (từ trên xuống)
            while ((float)b2 / a2 * x <= y)
            {
                if (TinhToan.LaNetLien(dem, doDaiCacNet))
                {
                    Put4Pixel(x_center, y_center, x, y);
                }

                if (p < 0)
                {
                    p = p + 2 * ((float)b2 / a2) * (2 * x + 3);
                }
                else
                {
                    p = p - 4 * y + 2 * ((float)b2 / a2) * (2 * x + 3);
                    --y;
                }
                ++x;
                ++dem;
            }

            // Vẽ nhánh thứ hai (từ dưới lên)
            y = 0;
            x = a;
            p = 2 * ((float)a2 / b2) - 2 * a + 1;
            while ((float)a2 / b2 * y <= x)
            {
                if (TinhToan.LaNetLien(dem, doDaiCacNet))
                {
                    Put4Pixel(x_center, y_center, x, y);
                }

                if (p < 0)
                {
                    p = p + 2 * ((float)a2 / b2) * (2 * y + 3);
                }
                else
                {
                    p = p - 4 * x + 2 * ((float)a2 / b2) * (2 * y + 3);
                    --x;
                }
                ++y;
                ++dem;
            }
        }

        public void VeHinhElip(Diem2D tam, int a, int b, int[] doDaiCacNet = null)
        {
            VeHinhElip(tam.X, tam.Y, a, b, doDaiCacNet);
        }

        public void VeHinhElip_NuaKhuatTren(int x_center, int y_center, int a, int b, int[] doDaiCacNet = null)
        {
            // Tô màu Elip
            Point point = Tu2DSangMay(x_center - a, y_center + b).ToPoint();
            G.FillEllipse(coVe, point.X, point.Y, 2 * a * PIXELS, 2 * b * PIXELS);

            int dem = 0;
            if (doDaiCacNet == null)
            {
                doDaiCacNet = new int[] { 1 };
            }

            float p, a2, b2;
            int x, y;
            a2 = a * a;
            b2 = b * b;
            x = 0;
            y = b;

            p = 2 * ((float)b2 / a2) - (2 * b) + 1;

            // Vẽ nhánh thứ nhất (từ trên xuống)
            while ((float)b2 / a2 * x <= y)
            {
                if (TinhToan.LaNetLien(dem, doDaiCacNet))
                {
                    Put2Pixel_Top(x_center, y_center, x, y);
                }
                Put2Pixel_Bottom(x_center, y_center, x, y);

                if (p < 0)
                {
                    p = p + 2 * ((float)b2 / a2) * (2 * x + 3);
                }
                else
                {
                    p = p - 4 * y + 2 * ((float)b2 / a2) * (2 * x + 3);
                    --y;
                }
                ++x;
                ++dem;
            }

            // Vẽ nhánh thứ hai (từ dưới lên)
            y = 0;
            x = a;
            p = 2 * ((float)a2 / b2) - 2 * a + 1;
            while ((float)a2 / b2 * y <= x)
            {
                if (TinhToan.LaNetLien(dem, doDaiCacNet))
                {
                    Put2Pixel_Top(x_center, y_center, x, y);
                }
                Put2Pixel_Bottom(x_center, y_center, x, y);

                if (p < 0)
                {
                    p = p + 2 * ((float)a2 / b2) * (2 * y + 3);
                }
                else
                {
                    p = p - 4 * x + 2 * ((float)a2 / b2) * (2 * y + 3);
                    --x;
                }
                ++y;
                ++dem;
            }
        }

        public void VeHinhElip_NuaKhuatTren(Diem2D tam, int a, int b, int[] doDaiCacNet = null)
        {
            VeHinhElip_NuaKhuatTren(tam.X, tam.Y, a, b, doDaiCacNet);
        }
    }
}
