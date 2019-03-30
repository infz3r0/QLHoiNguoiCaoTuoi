using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class ChucVuDAO
    {
        /// <summary>
        /// Cập nhật TT chức vụ
        /// </summary>
        /// <param name="n">TT cập nhật</param>
        public void Update(CHUC_VU n)
        {
            using (Entities db = new Entities())
            {
                db.SP_CHUC_VU_UPDATE(n.MA_CHUC_VU, n.HE_SO_LUONG);
            }
        }
    }
}
