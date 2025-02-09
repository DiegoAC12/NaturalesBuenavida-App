using Logic;
using Model;
using Newtonsoft.Json;
using Presentation.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFInventory : System.Web.UI.Page
    {
        private static InventoryLog objInv = new InventoryLog();
        private static ProductLog objProd = new ProductLog();

        // Manejo de la lista temporal en la sesión del usuario
        private List<SimpleTemporaryProduct> TemporaryProductList
        {
            get
            {
                if (Session["TemporaryProductList"] == null)
                {
                    Session["TemporaryProductList"] = new List<SimpleTemporaryProduct>();
                }
                return (List<SimpleTemporaryProduct>)Session["TemporaryProductList"];
            }
            set
            {
                Session["TemporaryProductList"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdowns();
                TBDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ShowTemporaryList();
            }

            Usuario usuario = Session["Usuario"] as Usuario;
            if (usuario == null || (usuario.Privilegios != null && !usuario.Privilegios.Contains(((int)Privilegios.Inventario).ToString())))
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }

        private void LoadDropdowns()
        {
            // Cargar empleados
            EmployeeLog employeeLog = new EmployeeLog();
            DataSet employees = employeeLog.ShowEmployeesDDL();
            DDLEmployee.DataSource = employees.Tables[0];
            DDLEmployee.DataValueField = "Id";
            DDLEmployee.DataTextField = "NombreCompleto";
            DDLEmployee.DataBind();
            DDLEmployee.Items.Insert(0, new ListItem("---- Seleccione un empleado ----", "0"));

            // Cargar productos
            ProductLog productLog = new ProductLog();
            DataSet products = productLog.showProductsDDL();
            DDLProduct.DataSource = products.Tables[0];
            DDLProduct.DataValueField = "Id";
            DDLProduct.DataTextField = "Producto";
            DDLProduct.DataBind();
            DDLProduct.Items.Insert(0, new ListItem("---- Seleccione un producto ----", "0"));
        }

        private void ShowTemporaryList()
        {
            GVProduct.DataSource = TemporaryProductList;
            GVProduct.DataBind();
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            if (DDLProduct.SelectedIndex == 0 || !int.TryParse(DDLProduct.SelectedValue, out int productId))
            {
                LblMsg.Text = "Seleccione un producto válido.";
                LblMsg.CssClass = "text-danger fw-bold my-3";
                return;
            }

            if (!int.TryParse(TBQuantity.Text, out int cantidad) || cantidad <= 0)
            {
                LblMsg.Text = "Ingrese una cantidad válida.";
                LblMsg.CssClass = "text-danger fw-bold my-3";
                return;
            }

            // Obtener y actualizar la lista temporal
            List<SimpleTemporaryProduct> productList = TemporaryProductList;
            productList.Add(new SimpleTemporaryProduct
            {
                IdProducto = productId,
                Nombre = DDLProduct.SelectedItem.Text,
                Cantidad = cantidad
            });
            clear1();
            TemporaryProductList = productList;
            ShowTemporaryList();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<SimpleTemporaryProduct> productList = TemporaryProductList;

                if (productList.Count == 0)
                {
                    LblMsg.Text = "No hay productos en la lista temporal para guardar.";
                    LblMsg.CssClass = "text-danger fw-bold my-3";
                    return;
                }

                if (!DateTime.TryParse(TBDate.Text, out DateTime fechaInventario))
                {
                    LblMsg.Text = "Formato de fecha inválido.";
                    return;
                }

                if (!int.TryParse(DDLEmployee.SelectedValue, out int empleadoId) || empleadoId <= 0)
                {
                    LblMsg.Text = "Seleccione un empleado válido.";
                    return;
                }

                string observacion = TBObservacion.Text.Trim();
                if (TemporaryProductList == null || !TemporaryProductList.Any())
                {
                    throw new Exception("No hay productos en la lista temporal para procesar.");
                }

                foreach (var p in TemporaryProductList)
                {
                    Console.WriteLine($"Producto: Id = {p.IdProducto}, Cantidad = {p.Cantidad}");
                }
                var productosParaJson = TemporaryProductList
                    .Where(p => p.IdProducto > 0 && p.Cantidad > 0) // Filtrar datos inválidos
                    .Select(p => new { id_producto = p.IdProducto, cantidad = p.Cantidad })
                    .ToList();
                //var productosParaJson = productList.Select(p => new
                //{
                //    IdProducto = p.IdProducto,
                //    Cantidad = p.Cantidad
                //}).ToList();

                string productosJson = JsonConvert.SerializeObject(productosParaJson, Formatting.Indented);
                Console.WriteLine("JSON enviado a MySQL: " + productosJson);
                bool success = objInv.SaveInventory(fechaInventario, observacion, empleadoId, productosJson);

                if (success)
                {
                    LblMsg.Text = "Inventario guardado exitosamente.";
                    LblMsg.CssClass = "text-success fw-bold my-3";

                    TemporaryProductList = new List<SimpleTemporaryProduct>();
                    ShowTemporaryList();
                }
                else
                {
                    LblMsg.Text = "Inventario guardado exitosamente.";
                    LblMsg.CssClass = "text-success fw-bold my-3";
                    ShowTemporaryList();
                }
            }
            catch (Exception ex)
            {
                LblMsg.Text = "Error: " + ex.Message;
                LblMsg.CssClass = "text-danger fw-bold my-3";
            }
        }

        protected void GVProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                List<SimpleTemporaryProduct> productList = TemporaryProductList;

                if (index >= 0 && index < productList.Count)
                {
                    productList.RemoveAt(index);
                    TemporaryProductList = productList;
                    ShowTemporaryList();
                }
            }
            catch (Exception ex)
            {
                LblMsg.Text = "Error al eliminar el producto: " + ex.Message;
                LblMsg.CssClass = "text-danger fw-bold my-3";
            }
        }

        protected void BtbClear_Click(object sender, EventArgs e)
        {
            TemporaryProductList = new List<SimpleTemporaryProduct>();
            ShowTemporaryList();
            TBObservacion.Text = "";
            DDLEmployee.SelectedIndex = 0;
            DDLProduct.SelectedIndex = 0;
            TBQuantity.Text = "";
            TBDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LblMsg.Text = "";
        }

        private void clear1()
        {
            DDLProduct.SelectedIndex = 0;
            TBQuantity.Text = "";
            
        }

        [WebMethod]
        public static object ListInventorys()
        {
            var dataSet = objInv.ShowInventorySummary();
            var inventoryList = new List<object>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                inventoryList.Add(new
                {
                    InventoryID = row["Id"],
                    FechaInventario = Convert.ToDateTime(row["FechaInventario"]).ToString("yyyy-MM-dd"),
                    Observacion = row["Observacion"],
                    NombreResponsable = row["NombreResponsable"]
                });
            }

            return new { data = inventoryList };
        }

        [WebMethod]
        public static AjaxResponse DeleteInventory(int id)
        {
            AjaxResponse response = new AjaxResponse();
            try
            {
                bool executed = objInv.DeleteInventory(id);
                response.Success = executed;
                response.Message = executed ? "Inventario eliminado correctamente." : "Error al eliminar el inventario.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ocurrió un error: " + ex.Message;
            }
            return response;
        }
    }
}
