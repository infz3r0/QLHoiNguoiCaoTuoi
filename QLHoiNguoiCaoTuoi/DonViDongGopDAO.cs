using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class DonViDongGopDAO
    {
        /// <summary>
        /// Thêm đơn vị
        /// </summary>
        /// <param name="n">TT đơn vị</param>
        public void Insert(DON_VI_DONG_GOP n)
        {
            using (Entities db = new Entities())
            {
                db.SP_DON_VI_DONG_GOP_INSERT(n.TEN_DON_VI, n.DIA_CHI, n.EMAIL);   
            }
        }

        /// <summary>
        /// Cập nhật đơn vị
        /// </summary>
        /// <param name="n">TT đơn vị</param>
        public void Update(DON_VI_DONG_GOP n)
        {
            using (Entities db = new Entities())
            {
                db.SP_DON_VI_DONG_GOP_UPDATE(n.MA_DON_VI, n.TEN_DON_VI, n.DIA_CHI, n.EMAIL);
            }
        }

        /// <summary>
        /// Xóa đơn vị
        /// </summary>
        /// <param name="o">TT đơn vị</param>
        public void Delete(DON_VI_DONG_GOP o)
        {
            using (Entities db = new Entities())
            {
                db.SP_DON_VI_DONG_GOP_DELETE(o.MA_DON_VI);
            }
        }
    }
}
