using D18CQCN01N_Nhom17.ThuVienDoHoa;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VeHinhCoBan.View
{
    public partial class DrawHalfDashedEllipse : UserControl
    {
        private FBaiTap main;
        public FBaiTap Main { get => main; set => main = value; }

        public DrawHalfDashedEllipse(FBaiTap main)
        {
            InitializeComponent();
            Main = main;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int x0 = (int)nmrX0.Value;
            int y0 = (int)nmrY0.Value;
            int a = (int)nmrA.Value;
            int b = (int)nmrB.Value;

            Main.Shapes.Add(new HinhElipNuaKhuat(x0, y0, a, b, Main.Color1, Color.Transparent, new int[] { 2, 2 }));
            Main.Refresh();
        }
    }
}
