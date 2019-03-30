using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi
{
    public class Test
    {
        public async Task<bool> DBConnected()
        {
            //String strConn = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
            string strConn = "DATA SOURCE=localhost:1521/orcl;PASSWORD=qlnct;PERSIST SECURITY INFO=True;USER ID=C##QLNCT";
            OracleConnection con = new OracleConnection(strConn);
            try
            {
                await con.OpenAsync();             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                con.Close();
            }

            return true; ;
        }
    }
}
