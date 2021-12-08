using D18CQCN01N_Nhom17.ThuVienDoHoa;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeHinhCoBan.View
{
    public partial class Draw2DottedLine : UserControl
    {
        private FBaiTap main;
        public FBaiTap Main { get => main; set => main = value; }

        public Draw2DottedLine(FBaiTap main)
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

            Main.Shapes.Add(new DoanThang(x1, y1, x2, y2, Main.Color1, new int[] { 4, 1, 1, 1, 1, 1 }));
            Main.Refresh();
        }
    }
}
