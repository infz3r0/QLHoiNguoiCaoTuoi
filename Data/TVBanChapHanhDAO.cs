using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TVBanChapHanhDAO
    {
        /// <summary>
        /// Thêm tv bch mới
        /// </summary>
        /// <param name="n">TV BCH cần thêm</param>
        public void Insert(TV_BAN_CHAP_HANH n)
        {
            using (Entities db = new Entities())
            {
                db.SP_TV_BAN_CHAP_HANH_INSERT(n.MA_BCH, n.DAN_TOC, n.TON_GIAO, n.NGHE_NGHIEP, n.DON_VI_CONG_TAC, n.TRINH_DO_HOC_VAN, n.TRINH_DO_CHUYEN_MON, n.TRINH_DO_LY_LUAN_CHINH_TRI, n.USERNAME, n.PASSWORD, n.EMAIL, n.MA_CHUC_VU);
            }
        }

        /// <summary>
        /// Cập nhật TT BCH
        /// </summary>
        /// <param name="n">TT mới của BCH</param>
        public void Update(TV_BAN_CHAP_HANH n)
        {
            using (Entities db = new Entities())
            {
                db.SP_TV_BAN_CHAP_HANH_UPDATE(n.MA_BCH, n.DAN_TOC, n.TON_GIAO, n.NGHE_NGHIEP, n.DON_VI_CONG_TAC, n.TRINH_DO_HOC_VAN, n.TRINH_DO_CHUYEN_MON, n.TRINH_DO_LY_LUAN_CHINH_TRI, n.MA_CHUC_VU);
            }
        }

        /// <summary>
        /// Xóa TV BCH
        /// </summary>
        /// <param name="o">TV BCH cần xóa</param>
        public void Delete(TV_BAN_CHAP_HANH o)
        {
            using (Entities db = new Entities())
            {
                db.SP_TV_BAN_CHAP_HANH_DELETE(o.MA_BCH);
            }
        }
    }
}
