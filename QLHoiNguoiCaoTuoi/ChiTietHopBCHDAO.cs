using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class ChiTietHopBCHDAO
    {
        /// <summary>
        /// Thêm bch tham gia họp
        /// </summary>
        /// <param name="h">TT cuộc họp</param>
        /// <param name="bch">TT bch</param>
        public void Insert(HOP_BCH h, TV_BAN_CHAP_HANH bch)
        {
            using (Entities db = new Entities())
            {
                db.SP_CHI_TIET_HOP_BCH_INSERT(h.MA_CUOC_HOP_BCH, bch.MA_BCH);
            }
        }

        /// <summary>
        /// Xóa bch tham gia họp
        /// </summary>
        /// <param name="h">TT cuộc họp</param>
        /// <param name="bch">TT bch</param>
        public void Delete(HOP_BCH h, TV_BAN_CHAP_HANH bch)
        {
            using (Entities db = new Entities())
            {
                db.SP_CHI_TIET_HOP_BCH_DELETE(h.MA_CUOC_HOP_BCH, bch.MA_BCH);
            }
        }
    }
}
