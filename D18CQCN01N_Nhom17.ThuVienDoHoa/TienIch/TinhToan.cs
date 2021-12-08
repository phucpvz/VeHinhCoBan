using D18CQCN01N_Nhom17.ThuVienDoHoa.HinhVe2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D18CQCN01N_Nhom17.ThuVienDoHoa.TienIch
{
    static class TinhToan
    {
        // Tìm ước chung lớn nhất
        public static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            int tmp;
            while (b != 0)
            {
                tmp = a % b;
                a = b;
                b = tmp;
            }
            return a;
        }

        // Tìm số gần nhất với n và chia hết cho k
        public static int LayGiaTriGanDung(int n, int k)
        {
            int mod = n % k;

            if (mod == 0)
            {
                return n;
            }

            // Ưu tiên lấy số nhỏ hơn
            if (mod > k / 2)
            {
                n = n - mod + k;
            }
            else
            {
                n -= mod;
            }

            return n;
        }

        // Tính tổng các phần tử từ chỉ số bắt đầu đến chỉ số kết thúc trong mảng
        public static int TongCacPhanTuTrongMang(int[] mang, int chiSoBD, int chiSoKT)
        {
            int tong = 0;
            for (int i = chiSoBD; i <= chiSoKT; i++)
            {
                tong += mang[i];
            }
            return tong;
        }

        // Kiểm tra nên vẽ nét liền hay nét đứt
        public static bool LaNetLien(int dem, int[] doDaiNet)
        {
            int tong = doDaiNet.Sum();
            int soDu = dem % tong;

            for (int i = 0; i < doDaiNet.Length; i++)
            {
                if (soDu < TongCacPhanTuTrongMang(doDaiNet, 0, i))
                {
                    // Chỉ số chẵn vẽ nét liền, chỉ số lẻ vẽ nét đứt
                    return i % 2 == 0;
                }
            }

            return true;
        }
    }

    public enum DonVi
    {
        DEGREES,
        RADIANS
    }
}
