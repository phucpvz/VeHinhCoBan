using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe3D
{
    public class HinhHopChuNhat : Hinh3D
    {
        private Diem3D goc;
        private int dai, rong, cao;

        public Diem3D Goc { get => goc; set => goc = value; }
        public int Dai { get => dai; set => dai = value; }
        public int Rong { get => rong; set => rong = value; }
        public int Cao { get => cao; set => cao = value; }

        public HinhHopChuNhat(Diem3D goc, int dai, int rong, int cao, Color? foreColor = null)
        {
            Goc = goc;
            Dai = dai;
            Rong = rong;
            Cao = cao;

            if (foreColor != null)
            {
                ForeColor = (Color)foreColor;
            }
        }

        public HinhHopChuNhat(int x, int y, int z, int dai, int rong, int cao, Color? foreColor = null)
            : this(new Diem3D(x, y, z), dai, rong, cao, foreColor)
        {
        }

        public override void VeHinh(DoHoa3D dh)
        {
            dh.MauNetVe = ForeColor;
            dh.VeHinhHopChuNhat(Goc, Dai, Rong, Cao);
        }
    }
}
