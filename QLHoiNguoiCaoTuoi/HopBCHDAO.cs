using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class HopBCHDAO
    {
        /// <summary>
        /// Thêm cuộc họp bch
        /// </summary>
        /// <param name="n">TT cuộc họp</param>
        public void Insert(HOP_BCH n)
        {
            using (Entities db = new Entities())
            {
                db.SP_HOP_BCH_INSERT(n.NGAY_GIO_HOP, n.NOI_DUNG_HOP, n.DIA_DIEM_HOP);
            }
        }

        /// <summary>
        /// Cập nhật TT cuộc họp
        /// </summary>
        /// <param name="n">TT cuộc họp</param>
        public void Update(HOP_BCH n)
        {
            using (Entities db = new Entities())
            {
                db.SP_HOP_BCH_UPDATE(n.MA_CUOC_HOP_BCH, n.NGAY_GIO_HOP, n.NOI_DUNG_HOP, n.DIA_DIEM_HOP);
            }
        }

        /// <summary>
        /// Xóa cuộc họp
        /// </summary>
        /// <param name="o">TT cuộc họp</param>
        public void Delete(HOP_BCH o)
        {
            using (Entities db = new Entities())
            {
                db.SP_HOP_BCH_DELETE(o.MA_CUOC_HOP_BCH);
            }
        }
    }
}
