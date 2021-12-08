using System;
using System.Windows.Forms;
using D18CQCN01N_Nhom17.ThuVienDoHoa;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;

namespace VeHinhCoBan.View
{
    public partial class DrawPoint : UserControl
    {
        private FBaiTap main;
        public FBaiTap Main { get => main; set => main = value; }

        public DrawPoint(FBaiTap main)
        {
            InitializeComponent();
            Main = main;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int x = (int)numericX.Value;
            int y = (int)numericY.Value;

            Main.Shapes.Add(new Diem2D(x, y, Main.Color1));
            Main.Refresh();
        }
    }
}
