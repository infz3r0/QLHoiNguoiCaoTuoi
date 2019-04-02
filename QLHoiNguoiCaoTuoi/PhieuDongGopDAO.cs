using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class PhieuDongGopDAO
    {
        /// <summary>
        /// Lập phiếu đóng góp
        /// </summary>
        /// <param name="n">TT phiếu</param>
        public void Create(PHIEU_DONG_GOP n)
        {
            using (Entities db = new Entities())
            {
                db.SP_PHIEU_DONG_GOP_INSERT(n.NGAY_DONG_GOP.ToString("dd/MM/yyyy"), n.SO_TIEN_DONG_GOP, n.MA_DON_VI);
            }
        }

        /// <summary>
        /// Xóa phiếu
        /// </summary>
        /// <param name="o">TT phiếu</param>
        public void Delete(PHIEU_DONG_GOP o)
        {
            using (Entities db = new Entities())
            {
                db.SP_PHIEU_DONG_GOP_DELETE(o.MA_PHIEU_DONG_GOP);
            }
        }
    }
}
