using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using D18CQCN01N_Nhom17.ThuVienDoHoa;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe3D;
using D18CQCN01N_Nhom17.ThuVienDoHoa.TienIch;
using D18CQCN01N_Nhom17.ThuVienDoHoa.VatThe2D;

namespace VeHinhCoBan
{
    public partial class FDoAn : Form
    {
        private DoHoa2D dh2D;
        private DoHoa3D dh3D;
        public FDoAn()
        {
            InitializeComponent();
            // Đồ họa 2D
            dh2D = new DoHoa2D(pb2D);
            Start();

            // Đồ họa 3D
            dh3D = new DoHoa3D(pb3D);
        }

        #region Đồ họa 2D
        //============================================================= Đồ họa 2D =============================================================
        private TuGiac bien;

        private MatTroi matTroi;

        private HaiDang haiDang;

        private CauVong cauVong;

        private Thuyen thuyen;

        private Ca ca;

        private Rua rua;

        private static List<Diem2D> diems = new List<Diem2D>();

        private void HienThiThongTin_2D()
        {
            // Thuyền
            thuyen.Than.HienThiThongTin(new List<Label>() { lbThanA_thuyen, lbThanB_thuyen, lbThanC_thuyen, lbThanD_thuyen });
            thuyen.CanhBuom1.HienThiThongTin(new List<Label>() { lbCBTA_thuyen, lbCBTB_thuyen, lbCBTC_thuyen });
            thuyen.CanhBuom2.HienThiThongTin(new List<Label>() { lbCBPA_thuyen, lbCBPB_thuyen, lbCBPC_thuyen });
            thuyen.Cot1.HienThiThongTin(new List<Label>() { lbctA_thuyen, lbctB_thuyen });
            thuyen.Cot2.HienThiThongTin(new List<Label>() { lbcpA_thuyen, lbcpB_thuyen });

            // Mặt trời
            matTroi.HienThiThongTin(new List<Label>()
            {lb1_mt, lb2_mt, lb3_mt, lb4_mt, lb5_mt, lb6_mt, lb7_mt, lb8_mt, lb9_mt, lb_10mt,
                lb11_mt, lb12_mt, lb13_mt, lb14_mt, lb15_mt, lb16_mt, lb0_mt });
            lbR_mt.Text = matTroi.S.BanKinh.ToString();

            // Cá
            ca.Than.HienThiThongTin(new List<Label>() { lbThanA_ca, lbThanB_ca, lbThanC_ca, lbThanD_ca });
            ca.Vay1.HienThiThongTin(new List<Label>() { lbVayTrenA_ca, lbVayTrenB_ca, lbVayTrenC_ca });
            ca.Vay2.HienThiThongTin(new List<Label>() { lbVayDuoiA_ca, lbVayDuoiB_ca, lbVayDuoiC_ca });
            ca.Duoi.HienThiThongTin(new List<Label>() { lbDuoiA_ca, lbDuoiB_ca, lbDuoiC_ca });
            ca.Mat.HienThiThongTin(new List<Label>() { lbMatO_ca });
            lbMatR_ca.Text = ca.Mat.BanKinh.ToString();

            // Rùa
            rua.Dau.HienThiThongTin(new List<Label>() { lbDauO_rua });
            rua.Than.HienThiThongTin(new List<Label>() { lbThanO_rua });
            rua.C1.HienThiThongTin(new List<Label>() { lbC1O_rua });
            rua.C2.HienThiThongTin(new List<Label>() { lbC2O_rua });
            rua.C3.HienThiThongTin(new List<Label>() { lbC3O_rua });
            rua.C4.HienThiThongTin(new List<Label>() { lbC4O_rua });
            rua.Duoi.HienThiThongTin(new List<Label>() { lbDuoiA_rua, lbDuoiB_rua, lbDuoiC_rua });
            lbDauR_rua.Text = rua.Dau.BanKinh.ToString();
            lbThanR_rua.Text = rua.Than.BanKinh.ToString();
            lbC1R_rua.Text = rua.C1.BanKinh.ToString();
            lbC2R_rua.Text = rua.C2.BanKinh.ToString();
            lbC3R_rua.Text = rua.C3.BanKinh.ToString();
            lbC4R_rua.Text = rua.C4.BanKinh.ToString();

            // Hải đăng
            haiDang.Mai.HienThiThongTin(new List<Label>() { lbMaiA_hd, lbMaiB_hd, lbMaiC_hd });
            haiDang.T4.HienThiThongTin(new List<Label>() { lbNgonA_hd, lbNgonB_hd, lbNgonC_hd, lbNgonD_hd });
            haiDang.T3.HienThiThongTin(new List<Label>() { lbTrenA_hd, lbTrenB_hd, lbTrenC_hd, lbTrenD_hd });
            haiDang.T2.HienThiThongTin(new List<Label>() { lbGiuaA_hd, lbGiuaB_hd, lbGiuaC_hd, lbGiuaD_hd });
            haiDang.T1.HienThiThongTin(new List<Label>() { lbDuoiA_hd, lbDuoiB_hd, lbDuoiC_hd, lbDuoiD_hd });
            haiDang.Cua.HienThiThongTin(new List<Label>() { lbCuaA_hd, lbCuaB_hd, lbCuaC_hd, lbCuaD_hd });
            haiDang.Dat.HienThiThongTin(new List<Label>() { lbDatA_hd, lbDatB_hd, lbDatC_hd, lbDatD_hd });

            // Cầu vồng
            cauVong.V1.HienThiThongTin(new List<Label>() { lbTam_cv });
            lbDo_cv.Text = cauVong.V1.BanKinh.ToString();
            lbCam_cv.Text = cauVong.V2.BanKinh.ToString();
            lbVang_cv.Text = cauVong.V3.BanKinh.ToString();
            lbLuc_cv.Text = cauVong.V4.BanKinh.ToString();
            lbLam_cv.Text = cauVong.V5.BanKinh.ToString();
            lbCham_cv.Text = cauVong.V6.BanKinh.ToString();
            lbTim_cv.Text = cauVong.V7.BanKinh.ToString();
            lbTrang_cv.Text = cauVong.V8.BanKinh.ToString();
        }

        private void Start()
        {
            thuyen = Thuyen.TaoHinh();
            thuyen.TinhTien(150, 0);
            ca = Ca.TaoHinh();
            ca.TinhTien(0, -5);
            matTroi = MatTroi.TaoHinh();
            bien = TuGiac.TaoHinh();
            haiDang = HaiDang.TaoHinh();
            cauVong = CauVong.TaoHinh();
            rua = Rua.TaoHinh();
            rua.TinhTien(-180, 0);
            
            tocDoCa = -3;

            pb2D.Refresh();
        }

        private static int dem = 0;
        private static int tocDoCa;
        private static int huongThuyen;

        private void pb2D_Paint(object sender, PaintEventArgs e)
        {
            dh2D.G = e.Graphics;

            matTroi.VeHinh(dh2D);

            // Nếu trời sáng
            if (matTroi.S.Tam.Y >= 0)
            {
                if (matTroi.S.Tam.X <= 0)
                {
                    cauVong.VeHinh(dh2D);
                }
                dh2D.G.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, pb2D.Width, pb2D.Height / 2);
            }
            // Ngược lại, nếu trời tối
            else
            {
                dh2D.G.FillRectangle(new SolidBrush(Color.Black), 0, 0, pb2D.Width, pb2D.Height / 2);
            }

            bien.VeHinh(dh2D);

            haiDang.VeHinh(dh2D);

            if (ca.Mat.Tam.X <= -100 || ca.Mat.Tam.X >= 100)
            {
                ca.DoiXungQuaDiem(ca.Mat.Tam);
                tocDoCa *= -1;
            }

            ca.VeHinh(dh2D);

            thuyen.VeHinh(dh2D);
            rua.VeHinh(dh2D);

            // Hiển thị thông số của các vật thể 2D
            HienThiThongTin_2D();

            // Đang cho chạy hoạt ảnh
            if (btnPlay.Text == Constants.PAUSE)
            {
                // Điều khiển thuyền
                if (rbtnLeft_thuyen.Checked)
                {
                    huongThuyen = -1;
                }
                else if (rbtnRight_thuyen.Checked)
                {
                    huongThuyen = 1;
                }
                else
                {
                    huongThuyen = 0;
                }
                thuyen.TinhTien(huongThuyen * (int)nmrVanToc_thuyen.Value, 0);
                
                ca.TinhTien(tocDoCa, 0);
                rua.TinhTien(1, 0);

                if (rua.Dau.Tam.X > 130)
                {
                    rua.TinhTien(-300, 0);
                }

                if (dem % 10 == 0)
                {
                    matTroi.Quay(-42, 0, -Math.PI / 6, DonVi.RADIANS);
                }

                ++dem;
                if (dem == 100)
                {
                    dem = 1;
                }
            }

            // Hiển thị điểm trên màn hình khi click chuột
            foreach (Diem2D diem in diems)
            {
                dh2D.PutPixel(diem);
            }

            if (cbLuoiToaDo2D.Checked)
            {
                dh2D.VeLuoiToaDo(Color.Gray);
            }

            if (cbTrucToaDo2D.Checked)
            {
                dh2D.VeTrucToaDo(Color.Red);
            }
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            pb2D.Refresh();
        }

        private void pb2D_MouseMove(object sender, MouseEventArgs e)
        {
            Diem2D diem = dh2D.TuMaySang2D(e.X, e.Y);

            lbMouse_2D.Text = string.Format("{0}, {1}", diem.X, diem.Y);
        }

        private void pb2D_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbShowPoints.Checked)
            {
                Diem2D diem = dh2D.TuMaySang2D(e.X, e.Y);
                diems.Add(diem);
                pb2D.Refresh();
            }
        }

        private void cbShowPoints_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbShowPoints.Checked)
            {
                diems.Clear();
                pb2D.Refresh();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.Text == Constants.PLAY)
            {
                timer2D.Start();
                btnPlay.Text = Constants.PAUSE;
            }
            else
            {
                timer2D.Stop();
                btnPlay.Text = Constants.PLAY;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void cbLuoiToaDo2D_CheckedChanged(object sender, EventArgs e)
        {
            pb2D.Refresh();
        }

        private void cbTrucToaDo2D_CheckedChanged(object sender, EventArgs e)
        {
            pb2D.Refresh();
        }

        private void btndxOx_mt_Click(object sender, EventArgs e)
        {
            matTroi.DoiXungQuaOx();
            pb2D.Refresh();
        }

        private void btnPhongTo_mt_Click(object sender, EventArgs e)
        {
            matTroi.TyLe(matTroi.S.Tam, 2);
            pb2D.Refresh();
        }

        private void btnThuNho_mt_Click(object sender, EventArgs e)
        {
            matTroi.TyLe(matTroi.S.Tam, 0.5);
            pb2D.Refresh();
        }

        private void btndxOy_hd_Click(object sender, EventArgs e)
        {
            haiDang.DoiXungQuaOy();
            pb2D.Refresh();
        }

        private void btnPhongTo_hd_Click(object sender, EventArgs e)
        {
            haiDang.TyLe(haiDang.Mai.A, 2);
            pb2D.Refresh();
        }

        private void btnThuNho_hd_Click(object sender, EventArgs e)
        {
            haiDang.TyLe(haiDang.Mai.A, 0.5);
            pb2D.Refresh();
        }

        private void btndxOy_cv_Click(object sender, EventArgs e)
        {
            cauVong.DoiXungQuaOy();
            pb2D.Refresh();
        }

        private void btnPhongTo_cv_Click(object sender, EventArgs e)
        {
            cauVong.TyLe(cauVong.V1.Tam, 2);
            pb2D.Refresh();
        }

        private void btnThuNho_cv_Click(object sender, EventArgs e)
        {
            cauVong.TyLe(cauVong.V1.Tam, 0.5);
            pb2D.Refresh();
        }

        #endregion


        #region Đồ họa 3D
        //============================================================= Đồ họa 3D =============================================================

        private HinhCau cau = new HinhCau(0, 0, 0, 50, Color.Red);
        private HinhTru tru = new HinhTru(0, 0, 0, 25, 50, Color.Lime);
        private HinhNon non = new HinhNon(0, 0, 0, 25, 50, Color.Blue);
        private HinhHopChuNhat hopChuNhat = new HinhHopChuNhat(0, 0, 0, 40, 40, 20, Color.Purple);

        private void pb3D_Paint(object sender, PaintEventArgs e)
        {
            dh3D.G = e.Graphics;
            if (cbShow_Truc3D.Checked)
            {
                dh3D.VeHeTrucToaDo(Color.Black);
            }

            if (cbShow_HinhCau.Checked)
            {
                cau.VeHinh(dh3D);
            }

            if (cbShow_HinhTru.Checked)
            {
                tru.VeHinh(dh3D);
            }

            if (cbShow_HinhNon.Checked)
            {
                non.VeHinh(dh3D);
            }

            if (cbShow_HinhHopChuNhat.Checked)
            {
                hopChuNhat.VeHinh(dh3D);
            }
        }

        private void cbShow_HinhCau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow_HinhCau.Checked)
            {
                tc3D.SelectedTab = tpHinhCau;
            }
            pb3D.Refresh();
        }

        private void nmrX_HinhCau_ValueChanged(object sender, EventArgs e)
        {
            cau.Tam.X = (int)nmrX_HinhCau.Value;
            cau.Tam.Y = (int)nmrY_HinhCau.Value;
            cau.Tam.Z = (int)nmrZ_HinhCau.Value;

            cau.BanKinh = (int)nmrR_HinhCau.Value;
            pb3D.Refresh();
        }

        private void cbShow_HinhTru_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow_HinhTru.Checked)
            {
                tc3D.SelectedTab = tpHinhTru;
            }
            pb3D.Refresh();
        }

        private void nmrX_HinhTru_ValueChanged(object sender, EventArgs e)
        {
            tru.TamDay.X = (int)nmrX_HinhTru.Value;
            tru.TamDay.Y = (int)nmrY_HinhTru.Value;
            tru.TamDay.Z = (int)nmrZ_HinhTru.Value;

            tru.BanKinhDay = (int)nmrR_HinhTru.Value;
            tru.ChieuCao = (int)nmrH_HinhTru.Value;
            pb3D.Refresh();
        }

        private void cbShow_HinhNon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow_HinhNon.Checked)
            {
                tc3D.SelectedTab = tpHinhNon;
            }
            pb3D.Refresh();
        }
        private void nmrX_HinhNon_ValueChanged(object sender, EventArgs e)
        {
            non.TamDay.X = (int)nmrX_HinhNon.Value;
            non.TamDay.Y = (int)nmrY_HinhNon.Value;
            non.TamDay.Z = (int)nmrZ_HinhNon.Value;

            non.BanKinhDay = (int)nmrR_HinhNon.Value;
            non.ChieuCao = (int)nmrH_HinhNon.Value;
            pb3D.Refresh();
        }

        private void pb3D_MouseMove(object sender, MouseEventArgs e)
        {
            Diem2D diem = dh3D.Tool2D.TuMaySang2D(e.X, e.Y);

            lbMouse_3D.Text = string.Format("{0}, {1}", diem.X, diem.Y);
        }
        #endregion

        private void cbShow_Truc3D_CheckedChanged(object sender, EventArgs e)
        {
            pb3D.Refresh();
        }

        private void cbShow_HinhHopChuNhat_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow_HinhHopChuNhat.Checked)
            {
                tc3D.SelectedTab = tpHinhHopChuNhat;
            }
            pb3D.Refresh();
        }

        private void nmrX_hhcn_ValueChanged(object sender, EventArgs e)
        {
            hopChuNhat.Goc.X = (int)nmrX_hhcn.Value;
            hopChuNhat.Goc.Y = (int)nmrY_hhcn.Value;
            hopChuNhat.Goc.Z = (int)nmrZ_hhcn.Value;

            hopChuNhat.Dai = (int)nmrD_hhcn.Value;
            hopChuNhat.Rong = (int)nmrR_hhcn.Value;
            hopChuNhat.Cao = (int)nmrC_hhcn.Value;
            pb3D.Refresh();
        }

        private void tsHomework_Click(object sender, EventArgs e)
        {
            FBaiTap f = new FBaiTap();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void btnPhongTo_ca_Click(object sender, EventArgs e)
        {
            ca.TyLe(ca.Mat.Tam, 2);
            pb2D.Refresh();
        }

        private void btnThuNho_ca_Click(object sender, EventArgs e)
        {
            ca.TyLe(ca.Mat.Tam, 0.5);
            pb2D.Refresh();
        }

        private void btnPhongTo_rua_Click(object sender, EventArgs e)
        {
            rua.TyLe(rua.Than.Tam, 2);
            pb2D.Refresh();
        }

        private void btnThuNho_rua_Click(object sender, EventArgs e)
        {
            rua.TyLe(rua.Than.Tam, 0.5);
            pb2D.Refresh();
        }
    }

}
