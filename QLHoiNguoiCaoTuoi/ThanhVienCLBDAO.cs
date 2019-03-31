using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class ThanhVienCLBDAO
    {
        /// <summary>
        /// Thêm thành viên vào CLB
        /// </summary>
        /// <param name="n">Thành viên CLB</param>
        public void Insert(THANH_VIEN_CLB n)
        {
            using (Entities db = new Entities())
            {
                db.SP_THANH_VIEN_CLB_INSERT(n.MA_CLB, n.MA_THANH_VIEN, n.NGAY_THAM_GIA_CLB.ToString("dd/MM/yyyy"));
            }
        }

        /// <summary>
        /// Xóa thành viên trong CLB
        /// </summary>
        /// <param name="o">Thành viên CLB</param>
        public void Delete(THANH_VIEN_CLB o)
        {
            using (Entities db = new Entities())
            {
                db.SP_THANH_VIEN_CLB_DELETE(o.MA_CLB, o.MA_THANH_VIEN);
            }
        }
    }
}
