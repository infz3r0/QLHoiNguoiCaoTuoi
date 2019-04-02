using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class TimKiemDAO
    {
        public List<SP_PKG_TIMKIEMTHANHVIEN_TIMTHEOHOTEN_Result> TimKiemThanhVien_TheoHoTen(string hoten)
        {
            List<SP_PKG_TIMKIEMTHANHVIEN_TIMTHEOHOTEN_Result> r = new List<SP_PKG_TIMKIEMTHANHVIEN_TIMTHEOHOTEN_Result>();
            using (Entities db = new Entities())
            {
                r = db.SP_PKG_TIMKIEMTHANHVIEN_TIMTHEOHOTEN(hoten).ToList();
            }

            return r;
        }
    }
}
