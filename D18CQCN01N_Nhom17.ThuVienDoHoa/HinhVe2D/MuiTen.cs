using D18CQCN01N_Nhom17.ThuVienDoHoa.TienIch;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public class MuiTen : Hinh2D
    {
        private const int DO_CAO_MUI_TEN = 2;

        private Diem2D dau;
        private Diem2D cuoi;
        private Diem2D ben1;
        private Diem2D ben2;

        public Diem2D Dau
        {
            get => dau;
            set
            {
                dau = value;
                OnChanged();
            }
        }

        public Diem2D Cuoi
        {
            get => cuoi;
            set
            {
                cuoi = value;
                OnChanged();
            }
        }
        public Diem2D Ben1 { get => ben1; private set => ben1 = value; }
        public Diem2D Ben2 { get => ben2; private set => ben2 = value; }


        private void OnChanged()
        {
            if (Dau != null && Cuoi != null)
            {
                TinhToaDoCacDinhBen();
            }
        }


        public MuiTen(int x1, int y1, int x2, int y2, Color? foreColor = null)
        {
            Dau = new Diem2D(x1, y1);
            Cuoi = new Diem2D(x2, y2);
            
            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }

            CacDiemDacTrung = new List<Diem2D>() { Dau, Cuoi, Ben1, Ben2 };
        }

        public MuiTen(Diem2D dinhDau, Diem2D dinhCuoi, Color? foreColor = null)
        {
            Dau = dinhDau;
            Cuoi = dinhCuoi;

            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }

            CacDiemDacTrung = new List<Diem2D>() { Dau, Cuoi, Ben1, Ben2 };
        }

        // Xác định các đỉnh bên của mũi tên
        public void TinhToaDoCacDinhBen()
        {
            // Tìm vector pháp tuyến
            int Dx = Dau.X - Cuoi.X;
            int Dy = Dau.Y - Cuoi.Y;

            int m = TinhToan.UCLN(Dx, Dy);
            if (m == 0)
            {
                return;
            }

            int a = Dx / m;
            int b = Dy / m;

            if (a == 0 && b == 0)
            {
                return;
            }

            Diem2D vtpt = new Diem2D(b, -a);

            // Tìm vector chỉ phương
            Diem2D vecToChiPhuong = new Diem2D(-vtpt.Y, vtpt.X);
            float scale = (float)(DO_CAO_MUI_TEN / Math.Abs(Math.Sqrt(vtpt.X * vtpt.X + vtpt.Y * vtpt.Y)));

            Diem2D see = new Diem2D();
            see.X = (int)Math.Round(Cuoi.X + vecToChiPhuong.X * scale);
            see.Y = (int)Math.Round(Cuoi.Y + vecToChiPhuong.Y * scale);

            Ben2 = new Diem2D((int)Math.Round(see.X + 1.0 * vtpt.X * scale), (int)Math.Round(see.Y + 1.0 * vtpt.Y * scale));
            Ben1 = new Diem2D((int)Math.Round(see.X - 1.0 * vtpt.X * scale), (int)Math.Round(see.Y - 1.0 * vtpt.Y * scale));
        }

        public override void VeHinh(DoHoa2D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.VeMuiTen(this);
        }
    }
}
