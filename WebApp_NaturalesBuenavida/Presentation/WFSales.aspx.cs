using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Web.Services;

namespace Presentation
{
    public partial class WFSales : System.Web.UI.Page
    {
        private static SalesLog objSales = new SalesLog();
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdowns();
                TBDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            Usuario usuario = Session["Usuario"] as Usuario;
            if (usuario == null || usuario.Privilegios != null && !usuario.Privilegios.Contains(((int)Privilegios.Ventas).ToString()))
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }

        [WebMethod]
        public static object ListSales()
        {
            DataSet salesData = objSales.ShowSales();

            List<object> salesList = new List<object>();
            foreach (DataRow row in salesData.Tables[0].Rows)
            {
                salesList.Add(new
                {
                    ID = row["ID"],
                    Fecha = Convert.ToDateTime(row["Fecha"]).ToString("yyyy-MM-dd"),
                    NumeroFactura = row["NumeroFactura"],
                    IdProducto = row["IdProducto"],
                    Producto = row["Producto"],
                    PrecioUnidad = row["PrecioUnidad"],
                    CantidadVendida = row["CantidadVendida"],
                    Total = row["Total"],
                    cliente_id = row["cliente_id"],
                    IdentificacionCliente = row["IdentificacionCliente"],
                    NombreCliente = row["NombreCliente"],
                    empleado_id = row["empleado_id"],
                    IdentificacionEmpleado = row["IdentificacionEmpleado"],
                    NombreEmpleado = row["NombreEmpleado"],
                    Descripcion = row["Descripcion"],
                });
            }

            return new
            {
                draw = 1, // Esto es útil para las paginaciones
                recordsTotal = salesList.Count, // Número total de registros
                recordsFiltered = salesList.Count, // Número total de registros después de aplicar filtros (si los hay)
                data = salesList // Los datos reales de las filas
            };
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(TBDate.Text, out DateTime parsedDate))
            {
                LblMsg.Text = "Formato de fecha invalido";
                return;
            }
            DateTime _date = DateTime.Parse(TBDate.Text);
            int clientId = Convert.ToInt32(DDLClient.SelectedValue);
            int employeeId = Convert.ToInt32(DDLEmployee.SelectedValue);
            int productId = Convert.ToInt32(DDLProduct.SelectedValue);
            int cantidad = Convert.ToInt32(TBQuantity.Text);
            string description = TBDescription.Text;

            executed = objSales.SaveSale(description, clientId, employeeId, productId, cantidad);
            if (executed)
            {
                LblMsg.Text = "La Venta se guardó exiitosamente";
                LblMsg.CssClass = "text-success fw-bold";
                ClearFields();
            }
            else
            {
                LblMsg.Text = "venta no guardada.";
                LblMsg.CssClass = "text-danger fw-bold";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(HFSaleID.Value, out int saleId) && DateTime.TryParse(TBDate.Text, out DateTime saleDate))
            {
                DateTime _date = DateTime.Parse(TBDate.Text);
                int clientId = Convert.ToInt32(DDLClient.SelectedValue);
                int employeeId = Convert.ToInt32(DDLEmployee.SelectedValue);
                int productId = Convert.ToInt32(DDLProduct.SelectedValue);
                int cantidad = Convert.ToInt32(TBQuantity.Text);
                string description = TBDescription.Text;

                bool success = objSales.UpdateSale(saleId, description, clientId, employeeId, productId, cantidad);

                LblMsg.Text = success ? "Venta actualizada exitosamente" : "Error al actualizar la venta";
                LblMsg.CssClass = success ? "text-success fw-bold" : "text-danger fw-bold";
            }
            else
            {
                LblMsg.Text = "Por favor, seleccione una venta válida.";
                LblMsg.CssClass = "text-danger fw-bold";
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void LoadDropdowns()
        {
            ClientLog clientLog = new ClientLog();
            DataSet clients = clientLog.showClientDDL(); // Cargar clientes

            // Configura el DataSource del DropDownList
            DDLClient.DataSource = clients.Tables[0];
            DDLClient.DataValueField = "Id";  // Se define el nombre del campo
            DDLClient.DataTextField = "NombreCompleto"; // Se define el nombre del campo
            DDLClient.DataBind();
            DDLClient.Items.Insert(0, "---- Seleccione un cliente ----");

            EmployeeLog employeeLog = new EmployeeLog();
            DataSet employees = employeeLog.ShowEmployeesDDL(); // Cargar empleados

            DDLEmployee.DataSource = employees.Tables[0];
            DDLEmployee.DataValueField = "Id";  // Se define el nombre del campo
            DDLEmployee.DataTextField = "NombreCompleto"; // Se define el nombre del campo
            DDLEmployee.DataBind();
            DDLEmployee.Items.Insert(0, "---- Seleccione un empleado ----");

            ProductLog productLog = new ProductLog();
            DataSet products = productLog.showProductsDDL();
            
            // Configura el DataSource del DropDownList
            DDLProduct.DataSource = products.Tables[0];
            DDLProduct.DataValueField = "Id";  // Se define el nombre del campo
            DDLProduct.DataTextField = "Producto"; // Se define el nombre del campo
            DDLProduct.DataBind();
            DDLProduct.Items.Insert(0, "---- Seleccione un producto ----");

        }

        [WebMethod]
        public static AjaxResponse DeleteSale(int saleId)
        {
            AjaxResponse response = new AjaxResponse();
            try
            {
                // Creo un objeto de respuesta para devolver al cliente.
                bool executed = objSales.DeleteSale(saleId);

                if (executed) // Verifico si la eliminación fue exitosa
                {
                    response.Success = true;
                    response.Message = "Venta eliminada correctamente.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error al eliminar la venta.";
                }
            }
            catch (Exception ex)// En caso de error, configuro la respuesta con el mensaje de error.
            {
                response.Success = false;
                response.Message = "Ocurrió un error: " + ex.Message;
            }

            return response;
        }

        private void ClearFields()
        {
            HFSaleID.Value = string.Empty;
            //TBDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //TBQuantity.Text = string.Empty;
            //TBDescription.Text = string.Empty;
            DDLClient.SelectedIndex = 0;
            DDLEmployee.SelectedIndex = 0;
            DDLProduct.SelectedIndex = 0;
            TBQuantity.Text = "";
            TBDescription.Text = "";
        }
    }
}
