using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Auth
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
                System.Data.Entity.Core.Objects.ObjectParameter loggedin = null;
                db.SP_CHECKLOGIN(username, password, loggedin);
                string sloggedin = loggedin.Value.ToString();
                if (sloggedin == "T")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
