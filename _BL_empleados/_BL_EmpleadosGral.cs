using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _ACL_empleados;
using _DAL_empleados;

namespace _BL_empleados
{
    public class _BL_EmpleadosGral
    {
        #region Variables
        //Mensaje
        protected static string strMsj = string.Empty;

        //Lista de empleados
        protected static List<_ACL_EmpleadosGral> lstEmpleadosGral;

        //Clase empleados
        protected static _ACL_EmpleadosGral objEmpleadosGral;
        #endregion

        //Select Empleados
        public static List<_ACL_EmpleadosGral> BL_spSelect_Empleados(_ACL_EmpleadosGral objEmp)
        {
            return _DAL_EmpleadosGral.DAL_spSelect_Empleados(objEmp);
        }

        //Inserta Empleados
        public static string BL_spInsert_Empleados(_ACL_EmpleadosGral objEmp)
        {
            return _DAL_EmpleadosGral.DAL_spInsert_Empleados(objEmp);
        }

        //Borrado logico
        public static string BL_spUpDate_Empleados(_ACL_EmpleadosGral objEmp)
        {
            return _DAL_EmpleadosGral.DAL_spUpDate_Empleados(objEmp);
        }

        //Select departamentos
        public static List<_ACL_EmpleadosGral> BL_spSelect_Departamento()
        {
            return _DAL_EmpleadosGral.DAL_spSelect_Departamento();
        }

        //Select puestos
        public static List<_ACL_EmpleadosGral> BL_spSelect_Puesto()
        {
            return _DAL_EmpleadosGral.DAL_spSelect_Puesto();
        }
    }
}
