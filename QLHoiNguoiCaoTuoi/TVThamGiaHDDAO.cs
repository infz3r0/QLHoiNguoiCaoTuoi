using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class TVThamGiaHDDAO
    {
        /// <summary>
        /// Thêm thành viên tham gia hoạt động
        /// </summary>
        /// <param name="hd">Hoạt động</param>
        /// <param name="tv">Thành viên</param>
        public void Insert(HOAT_DONG hd, THANH_VIEN tv)
        {
            using (Entities db = new Entities())
            {
                db.SP_THANH_VIEN_THAM_GIA_HD_INSERT(hd.MA_HOAT_DONG, tv.MA_THANH_VIEN);
            }
        }

        /// <summary>
        /// Xóa thành viên tham gia hoạt động
        /// </summary>
        /// <param name="hd">Hoạt động</param>
        /// <param name="tv">Thành viên</param>
        public void Delete(HOAT_DONG hd, THANH_VIEN tv)
        {
            using (Entities db = new Entities())
            {
                db.SP_THANH_VIEN_THAM_GIA_HD_DELETE(hd.MA_HOAT_DONG, tv.MA_THANH_VIEN);
            }
        }
    }
}
