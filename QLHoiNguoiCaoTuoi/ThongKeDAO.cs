using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class ThongKeDAO
    {
        public List<V_THONGKETHUCHI> ThongKeThuChi()
        {
            using (Entities db = new Entities())
            {
                return db.V_THONGKETHUCHI.OrderByDescending(x=>x.NAM).ThenByDescending(x=>x.THANG).ToList();
            }
        }

        public List<V_THONGKETIENDONGGOP> ThongKeDongGop()
        {
            using (Entities db = new Entities())
            {
                return db.V_THONGKETIENDONGGOP.OrderByDescending(x=>x.NAM).ToList();
            }
        }
    }
}
