using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class PhieuChiDAO
    {
        /// <summary>
        /// Lập phiếu chi
        /// </summary>
        /// <param name="n">TT phiếu chi</param>
        public void Create(PHIEU_CHI n)
        {
            using (Entities db = new Entities())
            {
                db.SP_PHIEU_CHI_INSERT(n.NGAY_LAP_PHIEU_CHI, n.NOI_DUNG_CHI, n.SO_TIEN_CHI, n.MA_HOAT_DONG, n.MA_BCH);
            }
        }

        /// <summary>
        /// Xóa phiếu chi
        /// </summary>
        /// <param name="o">TT phiếu chi</param>
        public void Delete(PHIEU_CHI o)
        {
            using (Entities db = new Entities())
            {
                db.SP_PHIEU_CHI_DELETE(o.MA_PHIEU_CHI);
            }
        }

        /// <summary>
        /// Duyệt phiếu chi
        /// </summary>
        /// <param name="n">TT phiếu chi</param>
        public void Duyet(PHIEU_CHI n)
        {
            using (Entities db = new Entities())
            {
                db.SP_PHIEU_CHI_DUYET(n.MA_PHIEU_CHI, n.NGAY_DUYET);
            }
        }
    }
}
