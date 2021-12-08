using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe3D
{
    public abstract class Hinh3D
    {
        private Color foreColor = Color.Black;
        public Color ForeColor { get => foreColor; set => foreColor = value; }

        public abstract void VeHinh(DoHoa3D dh);
    }
}
