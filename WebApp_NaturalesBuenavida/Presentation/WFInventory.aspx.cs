using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;

namespace Presentation
{
    public partial class WFInventory : System.Web.UI.Page
    {
        InventoryLog objInv = new InventoryLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        [WebMethod]
        public static object ListInventorys()
        {
            InventoryLog objInv = new InventoryLog();
            var dataSet = objInv.ShowInventorySummary();

            // Crear una lista para almacenar los inventarios
            var inventoryList = new List<object>();

            // Iterar sobre cada fila del DataSet y agregar los datos a la lista
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

            // Retornar la lista en formato JSON
            return new { data = inventoryList };
        }

        [WebMethod]
        public static bool DeleteInventory(int id)
        {
            InventoryLog objInv = new InventoryLog();
            return objInv.DeleteInventory(id);
        }

        private void showProductDDL()
        {
            DDLProduct.DataSource = objProd.showProductsDDL();
            DDLProduct.DataValueField = "Id";//Nombre de la llave primaria
            DDLProduct.DataTextField = "Producto";
            DDLProduct.DataBind();
            DDLProduct.Items.Insert(0, "---- Seleccione un producto ----");
        }

        private void showEmployeeDDL()
        {
            DDLEmployee.DataSource = objEmp.ShowEmployeesDDL();
            DDLEmployee.DataValueField = "Id";//Nombre de la llave primaria
            DDLEmployee.DataTextField = "NombreCompleto";
            DDLEmployee.DataBind();
            DDLEmployee.Items.Insert(0, "---- Seleccione un empleado ----");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(TBDate.Text, out DateTime parsedDate))
            {
                LblMsg.Text = "Formato de fecha inválido";
                return;
            }

            _date = DateTime.Parse(TBDate.Text);
            _CantidadNueva = Convert.ToInt32(TBQuantityInv.Text);
            _Observacion = TBObservation.Text;

            _fkpersona= Convert.ToInt32(DDLEmployee.SelectedValue);
            _fkproducto = Convert.ToInt32(DDLProduct.SelectedValue);

            executed = objInv.AddInventory(_CantidadNueva, _date, _Observacion, _fkproducto, _fkpersona);


            if (executed)
            {
               // MessageBox.Show("Inventario se guardo exitosamente!");
                LblMsg.Text = "Inventario se guardó exitosamente!";
                clear();//Se invoca el metodo para limpiar los campos 
            }
            else
            {
                LblMsg.Text = "Error al guardar";
            }
        }

        private void clear()
        {
            HFInventoryId.Value = "";
            TBDate.Text = "";
            TBObservation.Text = "";
            TBQuantityInv.Text = "";
            DDLEmployee.SelectedIndex = 0;
            DDLProduct.SelectedIndex = 0;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado un usuario para actualizar
            if (string.IsNullOrEmpty(HFInventoryId.Value))
            {
                LblMsg.Text = "No se ha seleccionado el inventario para actualizar.";
                return;
            }

            _id = Convert.ToInt32(HFInventoryId.Value);
            _date = DateTime.Parse(TBDate.Text);
            _CantidadNueva = Convert.ToInt32(TBQuantityInv.Text);
            _Observacion = TBObservation.Text;

            _fkpersona = Convert.ToInt32(DDLEmployee.SelectedValue);
            _fkproducto = Convert.ToInt32(DDLProduct.SelectedValue);

            executed = objInv.UpdateInventory(_id, _CantidadNueva, _date, _Observacion, _fkproducto, _fkpersona);

            if (executed)
            {
                LblMsg.Text = "El inventario se actualizo exitosamente!";
                clear();//Se invoca el metodo para limpiar los campos 
            }
            else
            {
                LblMsg.Text = "Error al actualizar";
            }
        }

        protected void BtbClear_Click(object sender, EventArgs e)
        {
            clear();
            LblMsg.Text = "";
        }
    }
}
