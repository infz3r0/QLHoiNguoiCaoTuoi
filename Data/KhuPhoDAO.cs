using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class KhuPhoDAO
    {
        /// <summary>
        /// Thêm khu phố mới
        /// </summary>
        /// <param name="n">Khu phố cần thêm</param>
        public void Insert(KHU_PHO n)
        {
            using (Entities db = new Entities())
            {
                db.SP_KHU_PHO_INSERT(n.TEN_KHU_PHO);
            }
        }

        /// <summary>
        /// Cập nhật TT khu phố
        /// </summary>
        /// <param name="n">TT mới của khu phố</param>
        public void Update(KHU_PHO n)
        {
            using (Entities db = new Entities())
            {
                db.SP_KHU_PHO_UPDATE(n.MA_KHU_PHO, n.TEN_KHU_PHO);
            }
        }

        /// <summary>
        /// Xóa khu phố
        /// </summary>
        /// <param name="o">Khu phố cần xóa</param>
        public void Delete(KHU_PHO o)
        {
            using (Entities db = new Entities())
            {
                db.SP_KHU_PHO_DELETE(o.MA_KHU_PHO);
            }
        }
    }
}
