using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class CaiDatDAO
    {
        /// <summary>
        /// Cập nhật giá trị tham số
        /// </summary>
        /// <param name="n">TT tham số, giá trị</param>
        public void Update(CAI_DAT n)
        {
            using (Entities db = new Entities())
            {
                db.SP_CAI_DAT_UPDATE(n.TEN_THAM_SO, n.GIA_TRI);
            }
        }
    }
}
