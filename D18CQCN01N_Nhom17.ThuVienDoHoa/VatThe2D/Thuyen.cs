using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.VatThe2D
{
    public class Thuyen : Hinh2D
    {
        private TuGiac than;

        private DoanThang cot1;
        private DoanThang cot2;

        private TamGiac canhBuom1;
        private TamGiac canhBuom2;

        public TuGiac Than { get => than; set => than = value; }
        public DoanThang Cot1 { get => cot1; set => cot1 = value; }
        public DoanThang Cot2 { get => cot2; set => cot2 = value; }
        public TamGiac CanhBuom1 { get => canhBuom1; set => canhBuom1 = value; }
        public TamGiac CanhBuom2 { get => canhBuom2; set => canhBuom2 = value; }
        
        public Thuyen(TuGiac than, DoanThang cot1, DoanThang cot2, TamGiac canhBuom1, TamGiac canhBuom2)
        {
            Than = than;
            Cot1 = cot1;
            Cot2 = cot2;
            CanhBuom1 = canhBuom1;
            CanhBuom2 = canhBuom2;

            CacBoPhan = new List<Hinh2D>() { Cot1, Cot2, CanhBuom1, CanhBuom2, Than };

            CacDiemDacTrung = new List<Diem2D>();
            foreach (Hinh2D hinh in CacBoPhan)
            {
                foreach (Diem2D diem in hinh.CacDiemDacTrung)
                {
                    CacDiemDacTrung.Add(diem);
                }
            }
        }

        public override void VeHinh(DoHoa2D dh)
        {
            foreach (Hinh2D hinh in CacBoPhan)
            {
                hinh.VeHinh(dh);
            }
        }

        public static Thuyen TaoHinh()
        {
            return new Thuyen(
            new TuGiac(10, 0, 0, 10, 50, 10, 40, 0, Color.Black, Color.Maroon),
            new DoanThang(24, 10, 24, 14, Color.Black), new DoanThang(30, 10, 30, 14, Color.Black),
            new TamGiac(24, 14, 24, 40, 10, 14, Color.Black, Color.Yellow),
            new TamGiac(30, 14, 30, 34, 40, 14, Color.Black, Color.Pink));
        }

    }
}
