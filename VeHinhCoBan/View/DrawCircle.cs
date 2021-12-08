using D18CQCN01N_Nhom17.ThuVienDoHoa;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Windows.Forms;

namespace VeHinhCoBan.View
{
    public partial class DrawCircle : UserControl
    {
        private FBaiTap main;
        public FBaiTap Main { get => main; set => main = value; }

        public DrawCircle(FBaiTap main)
        {
            InitializeComponent();
            Main = main;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int x0 = (int)numericX0.Value;
            int y0 = (int)numericY0.Value;
            int r = (int)numericR.Value;

            Main.Shapes.Add(new HinhTron(x0, y0, r, Main.Color1));
            Main.Refresh();
        }
    }
}
