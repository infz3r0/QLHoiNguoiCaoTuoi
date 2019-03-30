using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class Auth
    {
        public void ChangeEmail(TV_BAN_CHAP_HANH n)
        {
            using (Entities db = new Entities())
            {
                db.SP_AUTH_CHANGEEMAIL(n.MA_BCH, n.EMAIL);
            }
        }

        public void ChangePassword(TV_BAN_CHAP_HANH n)
        {
            using (Entities db = new Entities())
            {
                db.SP_AUTH_CHANGEPASSWORD(n.MA_BCH, n.PASSWORD);
            }
        }

        public bool Login(string username, string password)
        {
            using (Entities db = new Entities())
            {
                ObjectParameter v_loggedinParameter =  new ObjectParameter("V_LOGGEDIN", typeof(string));
                db.SP_CHECKLOGIN(username, password, v_loggedinParameter);
                string sloggedin = v_loggedinParameter.Value.ToString();
                if (sloggedin == "T")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
