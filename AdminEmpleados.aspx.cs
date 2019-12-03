using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _ACL_empleados;
using _BL_empleados;

public partial class AdminEmpleados : System.Web.UI.Page
{
    #region Variables
    //Lista de la clase _ACL_Usuario
    protected List<_ACL_EmpleadosGral> objEmp;

    //Clase _ACL_EmpleadosGral
    _ACL_EmpleadosGral objClassEmp;

    protected static string strMSJ = string.Empty;

    string strNombre = string.Empty;

    //Mensaje
    protected static string strMsjUsu = string.Empty;
    #endregion

    #region Eventos

    //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MuestraEmpleados();
            MuestraDepartamentos();
            MuestraPuestos();

            txtNombreEmpleado.Focus();
        }
    }

    //Activa tabla para guardar usuarios
    protected void btnAlta_Click(object sender, EventArgs e)
    {
        divTablausuario.Visible = true;
    }

    //Guarda un usuarios
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        #region Se llena clase empleados
        objClassEmp = new _ACL_EmpleadosGral();

        //Se llena objeto
        objClassEmp.NombreEmpleado = txtNomEmpleado.Text.ToUpper().Trim();

        if (clFechaI.SelectedDate.ToString() != "1/1/0001 12:00:00 AM")
            objClassEmp.FechaIngreso = clFechaI.SelectedDate;
        else
            objClassEmp.FechaIngreso = DateTime.Now;

        objClassEmp.IdDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
        objClassEmp.IdPuesto = Convert.ToInt32(ddlPuesto.SelectedValue);
        #endregion 

        //Inserta datos usuario
        strMsjUsu = string.Empty;
        strMsjUsu = _BL_EmpleadosGral.BL_spInsert_Empleados(objClassEmp);

        if (strMsjUsu == "1")
        {
            txtNomEmpleado.Text = "";
            Response.Write("<script>alert('Se guardó correctamente el empleado: " + txtNomEmpleado.Text.ToUpper().Trim() + "')</script>");
        }
        else
            Response.Write("<script>alert('Error, no se guardó el empleado ')</script>");
    }

    //Busca usuarios
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //Lista de empleados
        objEmp = new List<_ACL_EmpleadosGral>();
        //Clase de empleados
        objClassEmp = new _ACL_EmpleadosGral();

        //Se llena objeto
        objClassEmp.NombreEmpleado = txtNombreEmpleado.Text.Trim();
        objClassEmp.Puesto = txtPuesto.Text.Trim();
        objClassEmp.Departamento = txtDepartamento.Text.Trim();

        //Se trae los datos de la lista
        objEmp = _BL_EmpleadosGral.BL_spSelect_Empleados(objClassEmp);

        if (objEmp != null)
            if (objEmp.Count > 0)
            {
                gvEmpleados.DataSource = objEmp;
                gvEmpleados.DataBind();
            }
            else
            {
                gvEmpleados.DataSource = null;
                gvEmpleados.DataBind();
                Response.Write("<script>alert('No se encontró información con los criterios introducidos')</script>");
            }

    }

    //Guarda un usuarios
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminEmpleados.aspx", false);
    }

    //Cambia campo situación a texto
    protected void gvEmpleados_DataBound(object sender, EventArgs e)
    {
        GridView grd = (GridView)sender;
        foreach (GridViewRow gvr in grd.Rows)
        {
            CheckBox check = gvr.FindControl("chkSeleccion") as CheckBox;

            if (gvr.Cells[4].Text == "A")
                gvr.Cells[4].Text = "ACTIVO";

            else if (gvr.Cells[4].Text == "B")
            {
                gvr.Cells[4].Text = "BAJA";
                check.Checked = true;
                check.Enabled = false;
            }
        }
    }

    //Recorre cada elemento para saber si esta chequeado y saca el id del empleado
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        Label lblIdEmpleado;
        foreach (GridViewRow row in gvEmpleados.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

            objClassEmp = new _ACL_EmpleadosGral();
            if (check.Checked)
            {
                //Encuentra la etiqueta
                lblIdEmpleado = (Label)(row.Cells[0].FindControl("lblIdEmpleado"));

                objClassEmp.IdEmpleado = Convert.ToInt32(lblIdEmpleado.Text);
                objClassEmp.Situacion = "B";

                //Edita el id del empleado que se fue seleccionado
                strMSJ = _BL_EmpleadosGral.BL_spUpDate_Empleados(objClassEmp);

                strNombre += row.Cells[0].Text + "\\r";
            }
        }

        if (!string.IsNullOrEmpty(strNombre))
        {
            Response.Write("<script>alert('Se dieron de baja los siguientes empleados:\\r " + strNombre + "')</script>");
            strNombre = string.Empty;
            Response.Redirect("~/AdminEmpleados.aspx", false);
        }
        else
            Response.Write("<script>alert('Seleccione un empleado')</script>");
    }

    #endregion

    #region Metodos

    //Muestra empleados
    protected void MuestraEmpleados()
    {
        //Lista de empleados
        objEmp = new List<_ACL_EmpleadosGral>();
        //Clase de empleados
        objClassEmp = new _ACL_EmpleadosGral();

        //Se llena objeto
        objClassEmp.NombreEmpleado = txtNombreEmpleado.Text.Trim();
        objClassEmp.Puesto = txtPuesto.Text.Trim();
        objClassEmp.Departamento = txtDepartamento.Text.Trim();

        //Se trae los datos de la lista
        objEmp = _BL_EmpleadosGral.BL_spSelect_Empleados(objClassEmp);

        if (objEmp != null)
            if (objEmp.Count > 0)
            {
                gvEmpleados.DataSource = objEmp;
                gvEmpleados.DataBind();
            }
            else
            {
                gvEmpleados.DataSource = null;
                gvEmpleados.DataBind();
                Response.Write("<script>alert('No Existe información para mostrar')</script>");
            }
    }

    //Muestra departamentos
    protected void MuestraDepartamentos()
    {
        //Lista de departamentos
        objEmp = new List<_ACL_EmpleadosGral>();

        //Se trae los datos de la lista
        objEmp = _BL_EmpleadosGral.BL_spSelect_Departamento();

        ddlDepartamento.DataSource = objEmp;
        ddlDepartamento.DataTextField = "Departamento";
        ddlDepartamento.DataValueField = "IdDepartamento";
        ddlDepartamento.DataBind();
    }

    //Muestra puestos
    protected void MuestraPuestos()
    {
        //Lista de Puesto
        objEmp = new List<_ACL_EmpleadosGral>();

        //Se trae los datos de la lista
        objEmp = _BL_EmpleadosGral.BL_spSelect_Puesto();

        ddlPuesto.DataSource = objEmp;
        ddlPuesto.DataTextField = "Puesto";
        ddlPuesto.DataValueField = "IdPuesto";
        ddlPuesto.DataBind();
    }
    #endregion
}