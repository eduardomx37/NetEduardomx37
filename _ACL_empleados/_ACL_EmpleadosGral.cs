using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _ACL_empleados
{
    public class _ACL_EmpleadosGral     
    {
        #region Variables
        //Enteros
        private int intIdEmpleado;
        private int? intIdPuesto;
        private int? intIdDepartamento;
        private int? intDiasTrabajados;

        //Fecha

        private DateTime? dteFechaIngreso;

        //Cadenas
        private string strNombreEmpleado;
        private string strSituacion;
        private string strPuesto;
        private string strDepartamento;
        #endregion

        #region Propiedades
        //Enteros
        public int IdEmpleado
        {
            get { return intIdEmpleado; }
            set { intIdEmpleado = value; }
        }
        public int? IdPuesto
        {
            get { return intIdPuesto; }
            set { intIdPuesto = value; }
        }
        public int? IdDepartamento
        {
            get { return intIdDepartamento; }
            set { intIdDepartamento = value; }
        }
        public int? DiasTrabajados
        {
            get { return intDiasTrabajados; }
            set { intDiasTrabajados = value; }
        }

        //Fecha            
        public DateTime? FechaIngreso
        {
            get { return dteFechaIngreso; }
            set { dteFechaIngreso = value; }
        }

        //Cadenas
        public string NombreEmpleado
        {
            get { return strNombreEmpleado; }
            set { strNombreEmpleado = value; }
        }
        public string Situacion
        {
            get { return strSituacion; }
            set { strSituacion = value; }
        }
        public string Puesto
        {
            get { return strPuesto; }
            set { strPuesto = value; }
        }
        public string Departamento
        {
            get { return strDepartamento; }
            set { strDepartamento = value; }
        }
        #endregion
    }
}
