using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class PhieuThuDAO
    {
        /// <summary>
        /// Lập phiếu thu
        /// </summary>
        /// <param name="n">TT phiếu thu</param>
        public void Create(PHIEU_THU n)
        {
            using (Entities db = new Entities())
            {
                db.SP_PHIEU_THU_INSERT(n.NGAY_LAP_PHIEU_THU.ToString("dd/MM/yyyy"), n.NOI_DUNG_PHIEU_THU, n.SO_TIEN_THU, n.MA_BCH, n.MA_THANH_VIEN);
            }
        }

        /// <summary>
        /// Xóa phiếu thu
        /// </summary>
        /// <param name="o">TT phiếu thu</param>
        public void Delete(PHIEU_THU o)
        {
            using (Entities db = new Entities())
            {
                db.SP_PHIEU_THU_DELETE(o.MA_PHIEU_THU);
            }
        }


    }
}
