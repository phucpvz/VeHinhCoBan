using D18CQCN01N_Nhom17.ThuVienDoHoa;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Windows.Forms;

namespace VeHinhCoBan.View
{
    public partial class DrawEllipse : UserControl
    {
        private FBaiTap main;
        public FBaiTap Main { get => main; set => main = value; }

        public DrawEllipse(FBaiTap main)
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

            Main.Shapes.Add(new HinhElip(x0, y0, a, b, Main.Color1));
            Main.Refresh();
        }
    }
}
