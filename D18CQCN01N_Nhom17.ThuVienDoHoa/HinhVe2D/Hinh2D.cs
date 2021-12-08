using D18CQCN01N_Nhom17.ThuVienDoHoa.TienIch;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D
{
    public abstract class Hinh2D
    {
        private Color foreColor = Color.Black;
        public Color ForeColor { get => foreColor; set => foreColor = value; }

        private Color backColor = Color.Transparent;
        public Color BackColor { get => backColor; set => backColor = value; }

        private List<Diem2D> cacDiemDacTrung;
        public List<Diem2D> CacDiemDacTrung
        {
            get => cacDiemDacTrung;
            set => cacDiemDacTrung = value;
        }

        private List<Hinh2D> cacBoPhan;
        public List<Hinh2D> CacBoPhan { get => cacBoPhan; set => cacBoPhan = value; }

        public abstract void VeHinh(DoHoa2D dh);

        public void HienThiThongTin(List<Label> labels)
        {
            int i = 0;
            foreach (Diem2D diem in CacDiemDacTrung)
            {
                labels[i].Text = diem.ToString();
                ++i;
            }
        }

        public void TinhTien(int x, int y)
        {
            foreach (Diem2D diem in CacDiemDacTrung)
            {
                diem.X += x;
                diem.Y += y;
            }
        }

        // Mặc định quay góc với đơn vị là độ
        public void Quay(double goc, DonVi donVi = DonVi.DEGREES)
        {
            if (donVi != DonVi.RADIANS)
            {
                goc = Math.PI * goc / 180;
            }

            double cos = Math.Cos(goc);
            double sin = Math.Sin(goc);
            int x, y;

            foreach (Diem2D diem in CacDiemDacTrung)
            {
                x = diem.X;
                y = diem.Y;

                diem.X = (int)Math.Round(x * cos - y * sin);
                diem.Y = (int)Math.Round(x * sin + y * cos);
            }
        }

        public void Quay(int x_Tam, int y_Tam, double goc, DonVi donVi = DonVi.DEGREES)
        {
            TinhTien(-x_Tam, -y_Tam);
            Quay(goc, donVi);
            TinhTien(x_Tam, y_Tam);
        }

        public void DoiXungQuaGocToaDo()
        {
            foreach (Diem2D diem in CacDiemDacTrung)
            {
                diem.X = -diem.X;
                diem.Y = -diem.Y;
            }
        }

        public void DoiXungQuaDiem(int x, int y)
        {
            TinhTien(-x, -y);
            DoiXungQuaGocToaDo();
            TinhTien(x, y);
        }

        public void DoiXungQuaDiem(Diem2D diem)
        {
            DoiXungQuaDiem(diem.X, diem.Y);
        }

        public void DoiXungQuaOx()
        {
            foreach (Diem2D diem in CacDiemDacTrung)
            {
                diem.Y = -diem.Y;
            }
        }

        public void DoiXungQuaOy()
        {
            foreach (Diem2D diem in CacDiemDacTrung)
            {
                diem.X = -diem.X;
            }
        }

        public void DoiXungQuaDoanThang(int xA, int yA, int xB, int yB)
        {
            // Đoạn thẳng song song với trục tung
            if (xA == xB)
            {
                TinhTien(-xA, 0);
                DoiXungQuaOy();
                TinhTien(xA, 0);
                return;
            }

            TinhTien(-xA, -yA);
            // Tìm hệ số góc của đoạn thẳng
            double m = (yB - yA) / (xB - xA);
            Quay(-Math.Atan(m), DonVi.RADIANS);
            DoiXungQuaOx();
            Quay(Math.Atan(m), DonVi.RADIANS);

            TinhTien(xA, yA);
        }

        public void DoiXungQuaDoanThang(Diem2D A, Diem2D B)
        {
            int xA = A.X;
            int yA = A.Y;
            int xB = B.X;
            int yB = B.Y;

            DoiXungQuaDoanThang(xA, yA, xB, yB);
        }

        public void DoiXungQuaDoanThang(DoanThang AB)
        {
            int xA = AB.A.X;
            int yA = AB.A.Y;
            int xB = AB.B.X;
            int yB = AB.B.Y;

            DoiXungQuaDoanThang(xA, yA, xB, yB);
        }

        // Tâm tỷ lệ là gốc tọa độ O
        public void TyLe(double lan)
        {
            foreach (Diem2D diem in CacDiemDacTrung)
            {
                diem.X = (int)Math.Round(diem.X * lan);
                diem.Y = (int)Math.Round(diem.Y * lan);
            }

            // Nếu là hình tròn,... thì phải tỷ lệ thêm các thông số khác
            foreach (Hinh2D hinh in CacBoPhan)
            {
                if (hinh is HinhTron)
                {
                    HinhTron tr = (HinhTron)hinh;
                    tr.BanKinh = (int)Math.Round(tr.BanKinh * lan);
                }
                else if (hinh is NuaHinhTronTren)
                {
                    NuaHinhTronTren n = (NuaHinhTronTren)hinh;
                    n.BanKinh = (int)Math.Round(n.BanKinh * lan);
                }
                //...
            }
        }

        // Tâm tỷ lệ là điểm bất kỳ
        public void TyLe(int x, int y, double lan)
        {
            TinhTien(-x, -y);
            TyLe(lan);
            TinhTien(x, y);
        }

        public void TyLe(Diem2D diem, double lan)
        {
            TyLe(diem.X, diem.Y, lan);
        }
    }
}
