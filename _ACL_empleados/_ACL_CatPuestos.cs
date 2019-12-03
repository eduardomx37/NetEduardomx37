using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _ACL_empleados
{
    public class _ACL_CatPuestos   
    {
        #region Vareiables
        //Enteros
        private int intIdPuesto;

        //Cadenas
        private string strPuesto;
        #endregion

        #region Propiedades
        public int IdPuesto
        {
            get { return intIdPuesto; }
            set { intIdPuesto = value; }
        }
        //Cadenas
        public string Puesto
        {
            get { return strPuesto; }
            set { strPuesto = value; }
        }
        #endregion
    }
}
