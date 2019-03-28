using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class ThanhVienDAO
    {
        /// <summary>
        /// Thêm thành viên mới
        /// </summary>
        /// <param name="n">Thành viên cần thêm</param>
        public void Insert(THANH_VIEN n)
        {
            using (Entities db = new Entities())
            {
                db.SP_THANH_VIEN_INSERT(n.HO, n.TEN, n.NGAY_SINH, n.THANG_SINH, n.NAM_SINH, n.GIOI_TINH, n.DIA_CHI, n.NGAY_THAM_GIA, n.MA_KHU_PHO);
            }
        }

        /// <summary>
        /// Cập nhật TT thành viên
        /// </summary>
        /// <param name="n">TT mới của thành viên</param>
        public void Update(THANH_VIEN n)
        {
            using (Entities db = new Entities())
            {
                db.SP_THANH_VIEN_UPDATE(n.MA_THANH_VIEN, n.HO, n.TEN, n.NGAY_SINH, n.THANG_SINH, n.NAM_SINH, n.GIOI_TINH, n.DIA_CHI, n.MA_KHU_PHO);
            }
        }

        /// <summary>
        /// Xóa thành viên
        /// </summary>
        /// <param name="o">Thành viên cần xóa</param>
        public void Delete(THANH_VIEN o)
        {
            using (Entities db = new Entities())
            {
                db.SP_THANH_VIEN_DELETE(o.MA_THANH_VIEN);
            }
        }
    }
}
