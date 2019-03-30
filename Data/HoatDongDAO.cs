using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HoatDongDAO
    {
        /// <summary>
        /// Thêm Hoạt động mới
        /// </summary>
        /// <param name="n">Hoạt động cần thêm</param>
        public void Insert(HOAT_DONG n)
        {
            using (Entities db = new Entities())
            {
                db.SP_HOAT_DONG_INSERT(n.NOI_DUNG_HOAT_DONG, n.NGAY_BAT_DAU, n.NGAY_KET_THUC, n.DIEM_TOI_DA, n.DIEM_DAT_DUOC);
            }
        }

        /// <summary>
        /// Cập nhật TT Hoạt động
        /// </summary>
        /// <param name="n">TT mới của Hoạt động</param>
        public void Update(HOAT_DONG n)
        {
            using (Entities db = new Entities())
            {
                db.SP_HOAT_DONG_UPDATE(n.MA_HOAT_DONG, n.NOI_DUNG_HOAT_DONG, n.NGAY_BAT_DAU, n.NGAY_KET_THUC, n.DIEM_TOI_DA, n.DIEM_DAT_DUOC);
            }
        }

        /// <summary>
        /// Xóa Hoạt động
        /// </summary>
        /// <param name="o">Hoạt động cần xóa</param>
        public void Delete(HOAT_DONG o)
        {
            using (Entities db = new Entities())
            {
                db.SP_HOAT_DONG_DELETE(o.MA_HOAT_DONG);
            }
        }
    }
}
