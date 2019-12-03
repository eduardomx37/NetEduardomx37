using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _ACL_empleados
{
    public class _ACL_CatDepartamentos
    {
        #region Vareiables
        //Enteros
        private int intIdDepartamento;

        //Cadenas
        private string strDepartamento;
        #endregion

        #region Propiedades    
        public int IdDepartamento
        {
            get { return intIdDepartamento; }
            set { intIdDepartamento = value; }
        }
        //Cadenas
        public string Departamento
        {
            get { return strDepartamento; }
            set { strDepartamento = value; }
        }
        #endregion
    }
}
