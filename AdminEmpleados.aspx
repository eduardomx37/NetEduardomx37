<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminEmpleados.aspx.cs"
    Inherits="AdminEmpleados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Baja de Empleados :.</title>
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="Tabla1">
                <tr>
                    <td class="Center">Admintrador de Empleados
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td colspan="6" class="Subtitulos">Busqueda Empleados
                                </td>
                            </tr>
                            <tr>
                                <td class="TD1">Nombre empleado
                                </td>
                                <td class="TD1">
                                    <asp:TextBox ID="txtNombreEmpleado" runat="server" CssClass="CajaDeTextoNormal" MaxLength="50"
                                        TabIndex="1"></asp:TextBox>
                                </td>
                                <td class="TD1">Puesto
                                </td>
                                <td class="TD1">
                                    <asp:TextBox ID="txtPuesto" runat="server" CssClass="CajaDeTextoNormal" MaxLength="50"
                                        TabIndex="2"></asp:TextBox>
                                </td>
                                <td class="TD1">Departamento
                                </td>
                                <td class="TD1">
                                    <asp:TextBox ID="txtDepartamento" runat="server" CssClass="CajaDeTextoNormal" MaxLength="50"
                                        TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="TD1"></td>
                                <td class="TD1">
                                    <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="button100 white"
                                        OnClick="btnAlta_Click" TabIndex="4" />
                                </td>
                                <td class="TD1"></td>
                                <td class="TD1">
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button100 white"
                                        OnClick="btnBuscar_Click" TabIndex="4" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="TD1">
                                    <div runat="server" id="divTablausuario" visible="false">
                                        <table>
                                            <tr>
                                                <td colspan="2">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="Subtitulos">Alta Empleados
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TD1">Nombre Empleado</td>
                                                <td class="TD1">
                                                    <asp:TextBox ID="txtNomEmpleado" runat="server" MaxLength="50" Width="350px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                                                        ControlToValidate="txtNomEmpleado" Display="Dynamic" 
                                                        ErrorMessage="*" ForeColor="Red" ToolTip="Ingrese nombre" Font-Bold="True"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TD1">Fecha Ingreso</td>
                                                <td class="TD1">
                                                    <asp:Calendar ID="clFechaI" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                                                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                        <OtherMonthDayStyle ForeColor="#999999" />
                                                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                                        <TodayDayStyle BackColor="#CCCCCC" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Puesto</td>
                                                <td class="auto-style1">
                                                    <asp:DropDownList ID="ddlPuesto" runat="server" Width="350px"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvPuesto" runat="server" 
                                                        ControlToValidate="ddlPuesto" Display="Dynamic" 
                                                        ErrorMessage="*" ForeColor="Red" ToolTip="Seleccione puesto" Font-Bold="True"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TD1">Departamento</td>
                                                <td class="TD1">
                                                    <asp:DropDownList ID="ddlDepartamento" runat="server" Width="350px"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvDepartamento" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ToolTip="Seleccione departamento"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TD1">Guardar Empleado</td>
                                                <td class="TD1">
                                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar " CssClass="button100 white"
                                                        OnClick="btnGuardar_Click" TabIndex="4" Width="350px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TD1">&nbsp;</td>
                                                <td class="TD1">
                                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button100 white"
                                                        OnClick="btnCancelar_Click" TabIndex="4" Width="350px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TD1">&nbsp;</td>
                                                <td class="TD1">
                                                    &nbsp;<br />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="TD1">
                                    <asp:GridView ID="gvEmpleados" runat="server" CellPadding="4" CssClass="gview" ForeColor="#333333"
                                        GridLines="None" AutoGenerateColumns="False" Width="100%" OnDataBound="gvEmpleados_DataBound">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="NombreEmpleado" HeaderText="Nombre Empleado">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" DataFormatString="{0:yyyy-MM-dd}">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Puesto" HeaderText="Puesto">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Departamento" HeaderText="Departamento">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Situacion" HeaderText="Situación">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DiasTrabajados" HeaderText="Días Trabajados">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Selec.">
                                                <ItemTemplate>
                                                    <asp:Label Visible="false" ID="lblIdEmpleado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IdEmpleado") %>'></asp:Label>
                                                    <asp:CheckBox ID="chkSeleccion" Checked="false" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#03A9F4" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" class="TD1">&nbsp;</td>
                                <td class="TD1">
                                    <asp:Button ID="btnGenerar" runat="server" Text="Generar Baja" CssClass="button100 white"
                                        TabIndex="5" OnClick="btnGenerar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" class="TD1">&nbsp;</td>
                                <td class="TD1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="6" class="TD1">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
