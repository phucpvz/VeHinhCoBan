using VeHinhCoBan.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using D18CQCN01N_Nhom17.ThuVienDoHoa;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using D18CQCN01N_Nhom17.ThuVienDoHoa.VatThe2D;

namespace VeHinhCoBan
{
    public partial class FBaiTap : Form
    {
        private DoHoa2D dh2D;
        private List<Hinh2D> shapes;

        private DrawPoint pointInfo;
        private DrawLine lineInfo;
        private DrawDashedLine dashedLineInfo;
        private Draw1DottedLine oneDottedInfo;
        private Draw2DottedLine twoDottedInfo;
        private DrawArrow arrowInfo;
        private DrawRectangle rectangleInfo;
        private DrawCircle circleInfo;
        private DrawDashedCircle dashedCircleInfo;
        private DrawEllipse ellipseInfo;
        private DrawDashedEllipse dashedEllipseInfo;
        private DrawHalfDashedEllipse halfDashedEllipseInfo;

        public DrawPoint PointInfo { get => pointInfo; set => pointInfo = value; }
        public DrawLine LineInfo { get => lineInfo; set => lineInfo = value; }
        public DrawDashedLine DashedLineInfo { get => dashedLineInfo; set => dashedLineInfo = value; }
        public Draw1DottedLine OneDottedInfo { get => oneDottedInfo; set => oneDottedInfo = value; }
        public Draw2DottedLine TwoDottedInfo { get => twoDottedInfo; set => twoDottedInfo = value; }
        public DrawArrow ArrowInfo { get => arrowInfo; set => arrowInfo = value; }
        public DrawRectangle RectangleInfo { get => rectangleInfo; set => rectangleInfo = value; }
        public DrawCircle CircleInfo { get => circleInfo; set => circleInfo = value; }
        public DrawDashedCircle DashedCircleInfo { get => dashedCircleInfo; set => dashedCircleInfo = value; }
        public DrawEllipse EllipseInfo { get => ellipseInfo; set => ellipseInfo = value; }
        public DrawDashedEllipse DashedEllipseInfo { get => dashedEllipseInfo; set => dashedEllipseInfo = value; }
        public DrawHalfDashedEllipse HalfDashedEllipseInfo { get => halfDashedEllipseInfo; set => halfDashedEllipseInfo = value; }
        public List<Hinh2D> Shapes { get => shapes; set => shapes = value; }
        public Color Color1
        {
            get => pbColor1.BackColor;
            set => pbColor1.BackColor = value;
        }

        public FBaiTap()
        {
            InitializeComponent();

            dh2D = new DoHoa2D(pbHomework);
            Shapes = new List<Hinh2D>();

            PointInfo = new DrawPoint(this);
            LineInfo = new DrawLine(this);
            DashedLineInfo = new DrawDashedLine(this);
            OneDottedInfo = new Draw1DottedLine(this);
            TwoDottedInfo = new Draw2DottedLine(this);
            ArrowInfo = new DrawArrow(this);
            RectangleInfo = new DrawRectangle(this);
            CircleInfo = new DrawCircle(this);
            DashedCircleInfo = new DrawDashedCircle(this);
            EllipseInfo = new DrawEllipse(this);
            DashedEllipseInfo = new DrawDashedEllipse(this);
            HalfDashedEllipseInfo = new DrawHalfDashedEllipse(this);

            panelInfo.Controls.Add(PointInfo);
        }

        private void FBaiTap_Load(object sender, EventArgs e)
        {
            tabControlPaint2D.SelectedTab = tabPageHome;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            pbHomework.Refresh();
        }

        private void pictureBoxColors_Click(object sender, EventArgs e)
        {
            dh2D.MauNetVe = pbColor1.BackColor = (sender as PictureBox).BackColor;
        }

        private void checkBoxShowGridlines_CheckedChanged(object sender, EventArgs e)
        {
            pbHomework.Refresh();
        }

        private void checkBoxShowAxis_CheckedChanged(object sender, EventArgs e)
        {
            pbHomework.Refresh();
        }

        private void SwitchMode(Control control)
        {
            panelInfo.Controls.Clear();
            panelInfo.Controls.Add(control);
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            SwitchMode(PointInfo);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            SwitchMode(LineInfo);
        }

        private void btnDashedLine_Click(object sender, EventArgs e)
        {
            SwitchMode(DashedLineInfo);
        }

        private void btn1DottedLine_Click(object sender, EventArgs e)
        {
            SwitchMode(OneDottedInfo);
        }

        private void btn2DottedLine_Click(object sender, EventArgs e)
        {
            SwitchMode(TwoDottedInfo);
        }

        private void btnArrow_Click(object sender, EventArgs e)
        {
            SwitchMode(ArrowInfo);
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            SwitchMode(RectangleInfo);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            SwitchMode(CircleInfo);
        }

        private void btnDashedCircle_Click(object sender, EventArgs e)
        {
            SwitchMode(DashedCircleInfo);
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            SwitchMode(EllipseInfo);
        }

        private void btnDashedEllipse_Click(object sender, EventArgs e)
        {
            SwitchMode(DashedEllipseInfo);
        }

        private void btnHalfDashedEllipse_Click(object sender, EventArgs e)
        {
            SwitchMode(HalfDashedEllipseInfo);
        }

        private void pictureEditColors_Click(object sender, EventArgs e)
        {
            if (editColorsDialog.ShowDialog() == DialogResult.OK)
            {
               dh2D.MauNetVe = pbColor1.BackColor = editColorsDialog.Color;
            }
        }

        private void pbHomework_Paint(object sender, PaintEventArgs e)
        {
            dh2D.G = e.Graphics;

            if (cbShowGridlines.Checked)
            {
                dh2D.VeLuoiToaDo(Color.Silver);
            }

            if (cbShowAxis.Checked)
            {
                dh2D.VeTrucToaDo(Color.Red);
            }

            foreach (Hinh2D hinh in Shapes)
            {
                hinh.VeHinh(dh2D);
            }
        }

        private void pbHomework_MouseMove(object sender, MouseEventArgs e)
        {
            Diem2D diem = dh2D.TuMaySang2D(e.X, e.Y);

            tsslMouse.Text = string.Format("{0}, {1}", diem.X, diem.Y);
        }
    }

}
