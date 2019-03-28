using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class ChiTietHopTN
    {
        /// <summary>
        /// Thêm tv tham gia họp
        /// </summary>
        /// <param name="h">TT cuộc họp</param>
        /// <param name="bch">TT tv</param>
        public void Insert(HOP_BCH h, THANH_VIEN tv)
        {
            using (Entities db = new Entities())
            {
                db.SP_CHI_TIET_HOP_TN_INSERT(h.MA_CUOC_HOP_BCH, tv.MA_THANH_VIEN);
            }
        }

        /// <summary>
        /// Xóa tv tham gia họp
        /// </summary>
        /// <param name="h">TT cuộc họp</param>
        /// <param name="bch">TT tv</param>
        public void Delete(HOP_BCH h, THANH_VIEN tv)
        {
            using (Entities db = new Entities())
            {
                db.SP_CHI_TIET_HOP_TN_DELETE(h.MA_CUOC_HOP_BCH, tv.MA_THANH_VIEN);
            }
        }
    }
}
