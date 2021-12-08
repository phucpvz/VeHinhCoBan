using D18CQCN01N_Nhom17.ThuVienDoHoa;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Windows.Forms;

namespace VeHinhCoBan.View
{
    public partial class DrawRectangle : UserControl
    {
        private FBaiTap main;
        public FBaiTap Main { get => main; set => main = value; }

        public DrawRectangle(FBaiTap main)
        {
            InitializeComponent();
            Main = main;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int x1 = (int)numericX1.Value;
            int y1 = (int)numericY1.Value;
            int x2 = (int)numericX2.Value;
            int y2 = (int)numericY2.Value;

            Main.Shapes.Add(new HinhChuNhat(x1, y1, x2, y2, Main.Color1));
            Main.Refresh();
        }
    }
}
