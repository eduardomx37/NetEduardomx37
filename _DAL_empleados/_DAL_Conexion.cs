using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _DAL_empleados
{
    public class _DAL_Conexion    
    {
        private string strConnect = string.Empty;

        //Conexion
        public string strSqlConnection()
        {
            strConnect = System.Configuration.ConfigurationManager.ConnectionStrings["strConx"].ToString().Trim();

            return strConnect;
        }

    }
}
