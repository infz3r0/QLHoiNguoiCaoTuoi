using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class CLBDAO
    {
        /// <summary>
        /// Thêm CLB mới
        /// </summary>
        /// <param name="n">CLB cần thêm</param>
        public void Insert(CLB n)
        {
            using (Entities db = new Entities())
            {
                db.SP_CLB_INSERT(n.TEN_CLB, n.NGAY_THANH_LAP_CLB.ToString("dd/MM/yyyy"), n.MA_QUAN_LY);
            }
        }

        /// <summary>
        /// Cập nhật TT CLB
        /// </summary>
        /// <param name="n">TT mới của CLB</param>
        public void Update(CLB n)
        {
            using (Entities db = new Entities())
            {
                db.SP_CLB_UPDATE(n.MA_CLB, n.TEN_CLB, n.MA_QUAN_LY);
            }
        }

        /// <summary>
        /// Xóa CLB
        /// </summary>
        /// <param name="o">CLB cần xóa</param>
        public void Delete(CLB o)
        {
            using (Entities db = new Entities())
            {
                db.SP_CLB_DELETE(o.MA_CLB);
            }
        }
    }
}
