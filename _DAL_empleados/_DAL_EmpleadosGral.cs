using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _ACL_empleados;
using System.Data.SqlClient;
using System.Data;

namespace _DAL_empleados
{
    public class _DAL_EmpleadosGral
    {
        #region Variables
        //Clase conexion
        protected static _DAL_Conexion objConn;

        //Mensaje
        protected static string strMsj = string.Empty;

        //Lista de empleados
        protected static List<_ACL_EmpleadosGral> lstEmpleadosGral;

        //Clase empleados
        protected static _ACL_EmpleadosGral objEmpleadosGral;
        #endregion

        //Regresa empleado
        public static List<_ACL_EmpleadosGral> DAL_spSelect_Empleados(_ACL_EmpleadosGral objEmp)
        {
            objConn = new _DAL_Conexion();
            using (SqlConnection objSqlConnection = new SqlConnection(objConn.strSqlConnection()))
            {
                try
                {
                    #region Instancias de los parametros
                    SqlParameter objSqlParameter_1 = new SqlParameter();
                    SqlParameter objSqlParameter_2 = new SqlParameter();
                    SqlParameter objSqlParameter_3 = new SqlParameter();
                    #endregion

                    #region Nombre de los parametros
                    objSqlParameter_1.ParameterName = "i_vNombreEmpleado";
                    objSqlParameter_2.ParameterName = "i_vPuesto";
                    objSqlParameter_3.ParameterName = "i_vDepartamento";
                    #endregion

                    #region Tipo de variable de los parametros
                    objSqlParameter_1.SqlDbType = SqlDbType.VarChar;
                    objSqlParameter_2.SqlDbType = SqlDbType.VarChar;
                    objSqlParameter_3.SqlDbType = SqlDbType.VarChar;
                    #endregion

                    #region Tamaño del parametro
                    objSqlParameter_1.Size = 256;
                    objSqlParameter_2.Size = 256;
                    objSqlParameter_3.Size = 256;
                    #endregion

                    #region Dirección del parametro
                    objSqlParameter_1.Direction = ParameterDirection.Input;
                    objSqlParameter_2.Direction = ParameterDirection.Input;
                    objSqlParameter_3.Direction = ParameterDirection.Input;
                    #endregion

                    #region Asignacion de los valores
                    objSqlParameter_1.Value = objEmp.NombreEmpleado != null ? objEmp.NombreEmpleado : objSqlParameter_1.Value = DBNull.Value;
                    objSqlParameter_2.Value = objEmp.Puesto != null ? objEmp.Puesto : objSqlParameter_2.Value = DBNull.Value;
                    objSqlParameter_3.Value = objEmp.Departamento != null ? objEmp.Departamento : objSqlParameter_3.Value = DBNull.Value;
                    #endregion

                    #region Creación de arreglo de parametros
                    SqlParameter[] arrParametros = new SqlParameter[]
                    {
                            objSqlParameter_1, objSqlParameter_2, objSqlParameter_3
                    };
                    #endregion

                    //Abrir conexion
                    objSqlConnection.Open();

                    //Ejecuta la sentencia y recupera los datos
                    using (SqlCommand objSqlCommand = new SqlCommand("spSelect_Empleados", objSqlConnection))
                    {
                        strMsj = string.Empty;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.Parameters.AddRange(arrParametros);

                        //DataAdapter
                        SqlDataAdapter objSqlDataAdapter;
                        objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);

                        //DataSet
                        DataSet objDS = new DataSet();
                        objSqlDataAdapter.Fill(objDS);

                        //Objeto de la lista
                        lstEmpleadosGral = new List<_ACL_EmpleadosGral>();

                        //Llena la lista con la clase
                        foreach (DataRow item in objDS.Tables[0].Rows)
                        {
                            objEmpleadosGral = new _ACL_EmpleadosGral();

                            if (!string.IsNullOrEmpty(item["IdEmpleado"].ToString()))
                                objEmpleadosGral.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                            else
                                objEmpleadosGral.IdEmpleado = 0;

                            if (!string.IsNullOrEmpty(item["FechaIngreso"].ToString()))
                                objEmpleadosGral.FechaIngreso = DateTime.Parse(item["FechaIngreso"].ToString());
                            else
                                objEmpleadosGral.FechaIngreso = null;

                            if (!string.IsNullOrEmpty(item["IdPuesto"].ToString()))
                                objEmpleadosGral.IdPuesto = int.Parse(item["IdPuesto"].ToString());
                            else
                                objEmpleadosGral.IdPuesto = null;

                            if (!string.IsNullOrEmpty(item["FechaIngreso"].ToString()))
                                objEmpleadosGral.IdDepartamento = int.Parse(item["IdDepartamento"].ToString());
                            else
                                objEmpleadosGral.IdDepartamento = null;

                            if (objEmpleadosGral.FechaIngreso != null)
                            {
                                TimeSpan ts = DateTime.Now - Convert.ToDateTime(objEmpleadosGral.FechaIngreso);
                                objEmpleadosGral.DiasTrabajados = ts.Days;
                            }
                            else
                                objEmpleadosGral.DiasTrabajados = null;

                            objEmpleadosGral.NombreEmpleado = item["NombreEmpleado"].ToString();
                            objEmpleadosGral.Situacion = item["Situacion"].ToString();
                            objEmpleadosGral.Puesto = item["Puesto"].ToString();
                            objEmpleadosGral.Departamento = item["Departamento"].ToString();

                            //Se va agregando cada objeto de la clase _ACL_Usuario a la instancia de lista de la clase _ACL_Usuario
                            lstEmpleadosGral.Add(objEmpleadosGral);
                        }
                    }
                    //Se cierra conexcion
                    objSqlConnection.Close();
                }
                catch (Exception exc)
                {
                    objSqlConnection.Close();
                    strMsj = string.Empty;
                    strMsj = exc.Message.ToString();
                }
            }
            //Devuelve la lista
            return lstEmpleadosGral;
        }

        //Insertar usuario
        public static string DAL_spInsert_Empleados(_ACL_EmpleadosGral objEmpleado)
        {
            objConn = new _DAL_Conexion();

            using (SqlConnection objSqlConn = new SqlConnection(objConn.strSqlConnection()))
            {
                try
                {
                    #region Instancia de los parametros

                    SqlParameter SqlP_1 = new SqlParameter();
                    SqlParameter SqlP_2 = new SqlParameter();
                    SqlParameter SqlP_3 = new SqlParameter();
                    SqlParameter SqlP_4 = new SqlParameter();
                    #endregion

                    #region Nombre de los parametros
                    SqlP_1.ParameterName = "@i_vNombreEmpleado";
                    SqlP_2.ParameterName = "@i_dFechaIngreso";
                    SqlP_3.ParameterName = "@i_vIdDepartamento";
                    SqlP_4.ParameterName = "@i_vIdPuesto";
                    #endregion

                    #region Tipo de variable de los parametros
                    SqlP_1.SqlDbType = SqlDbType.VarChar;
                    SqlP_2.SqlDbType = SqlDbType.Int;
                    SqlP_3.SqlDbType = SqlDbType.Int;
                    SqlP_4.SqlDbType = SqlDbType.Int;
                    #endregion

                    #region Tamaño del parametro
                    SqlP_1.Size = 50;
                    SqlP_2.Size = 10;
                    SqlP_3.Size = 1;
                    SqlP_4.Size = 1;
                    #endregion

                    #region Dirección del parametro
                    SqlP_1.Direction = ParameterDirection.Input;
                    SqlP_2.Direction = ParameterDirection.Input;
                    SqlP_3.Direction = ParameterDirection.Input;
                    SqlP_4.Direction = ParameterDirection.Input;
                    #endregion

                    #region Asignacion de los valores
                    string strFecha = Convert.ToDateTime(objEmpleado.FechaIngreso).ToString("yyyy/MM/dd");
                    strFecha = strFecha.Replace("/", "");

                    SqlP_1.Value = objEmpleado.NombreEmpleado;
                    SqlP_2.Value = Convert.ToInt32(strFecha);
                    SqlP_3.Value = objEmpleado.IdDepartamento;
                    SqlP_4.Value = objEmpleado.IdPuesto;
                    #endregion

                    #region Creación de arreglo de parametros
                    SqlParameter[] SQLParametros = new SqlParameter[]
                    {
                        SqlP_1, SqlP_2, SqlP_3, SqlP_4
                    };
                    #endregion

                    //Abrir conexion
                    objSqlConn.Open();

                    //Ejecuta la sentencia
                    using (SqlCommand objSqlCommand = new SqlCommand("spInsert_Empleados", objSqlConn))
                    {
                        strMsj = string.Empty;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.Parameters.AddRange(SQLParametros);
                        object result = objSqlCommand.ExecuteNonQuery();
                        strMsj = result.ToString();
                    }
                    objSqlConn.Close();

                }
                catch (Exception exc)
                {
                    objSqlConn.Close();
                    strMsj = string.Empty;
                    strMsj = exc.Message.ToString();
                }
            }
            //_DAL_Conexion.stConn();
            return strMsj;
        }

        //Borrado Logico
        public static string DAL_spUpDate_Empleados(_ACL_EmpleadosGral objEmp)
        {
            objConn = new _DAL_Conexion();

            using (SqlConnection objSqlConn = new SqlConnection(objConn.strSqlConnection()))
            {
                try
                {
                    #region Instancia de los parametros
                    SqlParameter SqlP_1 = new SqlParameter();
                    SqlParameter SqlP_2 = new SqlParameter();
                    #endregion

                    #region Nombre de los parametros
                    SqlP_1.ParameterName = "i_vIdEmpleado";
                    SqlP_2.ParameterName = "i_vSituacion";
                    #endregion

                    #region Tipo de variable de los parametros
                    SqlP_1.SqlDbType = SqlDbType.Int;
                    SqlP_2.SqlDbType = SqlDbType.VarChar;
                    #endregion

                    #region Tamaño del parametro
                    #endregion

                    #region Dirección del parametro
                    SqlP_1.Direction = ParameterDirection.Input;
                    SqlP_2.Direction = ParameterDirection.Input;
                    #endregion

                    #region Asignacion de los valores
                    SqlP_1.Value = objEmp.IdEmpleado;
                    SqlP_2.Value = objEmp.Situacion != null ? objEmp.Situacion : SqlP_1.Value = DBNull.Value;
                    #endregion

                    #region Creación de arreglo de parametros
                    SqlParameter[] SQLParametros = new SqlParameter[]
                    {
                        SqlP_1, SqlP_2
                    };
                    #endregion

                    //Abrir conexion
                    objSqlConn.Open();

                    //Ejecuta la sentencia
                    using (SqlCommand objSqlCommand = new SqlCommand("spUpDate_Empleados", objSqlConn))
                    {
                        strMsj = string.Empty;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.Parameters.AddRange(SQLParametros);
                        object result = objSqlCommand.ExecuteNonQuery();
                        strMsj = result.ToString();
                    }
                    objSqlConn.Close();

                }
                catch (Exception exc)
                {
                    objSqlConn.Close();
                    strMsj = string.Empty;
                    strMsj = exc.Message.ToString();
                }
            }
            //_DAL_Conexion.stConn();
            return strMsj;
        }

        //Departamento
        public static List<_ACL_EmpleadosGral> DAL_spSelect_Departamento()
        {
            objConn = new _DAL_Conexion();
            using (SqlConnection objSqlConnection = new SqlConnection(objConn.strSqlConnection()))
            {
                try
                {
                    #region Instancias de los parametros

                    #endregion

                    #region Nombre de los parametros

                    #endregion

                    #region Tipo de variable de los parametros

                    #endregion

                    #region Tamaño del parametro

                    #endregion

                    #region Dirección del parametro

                    #endregion

                    #region Asignacion de los valores

                    #endregion

                    #region Creación de arreglo de parametros

                    #endregion

                    //Abrir conexion
                    objSqlConnection.Open();

                    //Ejecuta la sentencia y recupera los datos
                    using (SqlCommand objSqlCommand = new SqlCommand("spSelect_Departamentos", objSqlConnection))
                    {
                        strMsj = string.Empty;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;

                        //DataAdapter
                        SqlDataAdapter objSqlDataAdapter;
                        objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);

                        //DataSet
                        DataSet objDS = new DataSet();
                        objSqlDataAdapter.Fill(objDS);

                        //Objeto de la lista
                        lstEmpleadosGral = new List<_ACL_EmpleadosGral>();

                        //Llena la lista con la clase
                        foreach (DataRow item in objDS.Tables[0].Rows)
                        {
                            objEmpleadosGral = new _ACL_EmpleadosGral();

                            objEmpleadosGral.IdDepartamento = Convert.ToInt32(item["IdDepartamento"]);
                            objEmpleadosGral.Departamento = item["Departamento"].ToString();

                            //Se va agregando cada objeto de la clase _ACL_Usuario a la instancia de lista de la clase _ACL_Usuario
                            lstEmpleadosGral.Add(objEmpleadosGral);
                        }
                    }
                    //Se cierra conexcion
                    objSqlConnection.Close();
                }
                catch (Exception exc)
                {
                    objSqlConnection.Close();
                    strMsj = string.Empty;
                    strMsj = exc.Message.ToString();
                }
            }
            //Devuelve la lista
            return lstEmpleadosGral;
        }

        //Puesto
        public static List<_ACL_EmpleadosGral> DAL_spSelect_Puesto()
        {
            objConn = new _DAL_Conexion();
            using (SqlConnection objSqlConnection = new SqlConnection(objConn.strSqlConnection()))
            {
                try
                {
                    #region Instancias de los parametros

                    #endregion

                    #region Nombre de los parametros

                    #endregion

                    #region Tipo de variable de los parametros

                    #endregion

                    #region Tamaño del parametro

                    #endregion

                    #region Dirección del parametro

                    #endregion

                    #region Asignacion de los valores

                    #endregion

                    #region Creación de arreglo de parametros

                    #endregion

                    //Abrir conexion
                    objSqlConnection.Open();

                    //Ejecuta la sentencia y recupera los datos
                    using (SqlCommand objSqlCommand = new SqlCommand("spSelect_Puestos", objSqlConnection))
                    {
                        strMsj = string.Empty;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;

                        //DataAdapter
                        SqlDataAdapter objSqlDataAdapter;
                        objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);

                        //DataSet
                        DataSet objDS = new DataSet();
                        objSqlDataAdapter.Fill(objDS);

                        //Objeto de la lista
                        lstEmpleadosGral = new List<_ACL_EmpleadosGral>();

                        //Llena la lista con la clase
                        foreach (DataRow item in objDS.Tables[0].Rows)
                        {
                            objEmpleadosGral = new _ACL_EmpleadosGral();

                            objEmpleadosGral.IdPuesto = Convert.ToInt32(item["IdPuesto"]);
                            objEmpleadosGral.Puesto = item["Puesto"].ToString();

                            //Se va agregando cada objeto de la clase _ACL_Usuario a la instancia de lista de la clase _ACL_Usuario
                            lstEmpleadosGral.Add(objEmpleadosGral);
                        }
                    }
                    //Se cierra conexcion
                    objSqlConnection.Close();
                }
                catch (Exception exc)
                {
                    objSqlConnection.Close();
                    strMsj = string.Empty;
                    strMsj = exc.Message.ToString();
                }
            }
            //Devuelve la lista
            return lstEmpleadosGral;
        }

    }
}
