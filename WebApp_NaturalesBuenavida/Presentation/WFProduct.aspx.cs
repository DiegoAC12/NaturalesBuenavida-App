using Logic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Presentation
{
    public partial class WFProduct : System.Web.UI.Page
    {
        ProductLog objPro = new ProductLog();
        UnitMeasureLog objUnit = new UnitMeasureLog();
        PresentationLog objPres = new PresentationLog();
        CategoryLog objCategory = new CategoryLog();
        SupplierLog objSupplier = new SupplierLog();

        private int _id, _cantidadInventario, _medida, _fkcategoria, _fkproveedor, _fkunidadmedida, _fkpresentacion;
        private string _codigoProducto, _nombreProducto, _descripcionProducto, _numeroLote;
        private double _precioVenta, _precioCompra;
        private DateTime _date;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //showProduct();
                showCategoryDDL();
                showSupplierDDL();
                showUnitMeasureDDL();
                showPresentationDDL();
                TBDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        [WebMethod]
        public static object ListProducts()
        {
            ProductLog objPro = new ProductLog();

            // Se obtiene un DataSet que contiene la lista de clientes desde la base de datos.
            var dataSet = objPro.showProducts();

            // Se crea una lista para almacenar los productos que se van a devolver.
            var productsList = new List<object>();

            // Se itera sobre cada fila del DataSet (que representa un cliente).
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                productsList.Add(new
                {
                    ProductID = row["ProductID"],
                    Codigo = row["Codigo"],
                    Nombre = row["Nombre"],
                    Descripcion = row["Descripcion"],
                    Medida = row["Medida"],
                    fkunidadmedida = row["fkunidadmedida"],
                    UnidadMedida = row["UnidadMedida"],
                    fkpresentacion = row["fkpresentacion"],                  
                    Presentacion = row["Presentacion"],
                    fkcategory = row["fkcategory"],
                    Categoria = row["Categoria"],
                    Cantidad = row["Cantidad"],
                    NumeroLote = row["NumeroLote"],
                    FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]).ToString("yyyy-MM-dd"),
                    PrecioVenta = row["PrecioVenta"],
                    PrecioCompra = row["PrecioCompra"],
                    fkproveedor = row["fkproveedor"],
                    NombreProveedor = row["NombreProveedor"],
                    ApellidoProveedor = row["ApellidoProveedor"]
                });
            }

            // Devuelve un objeto en formato JSON que contiene la lista de productos.
            return new { data = productsList };
        }

        [WebMethod]
        public static bool DeleteProduct(int id)
        {
            // Crear una instancia de la clase de lógica de productos
            ProductLog objProd = new ProductLog();

            // Invocar al método para eliminar el producto y devolver el resultado
            return objProd.deleteProduct(id);
        }

        //private void showProduct()
        //{
        //    DataSet objData = new DataSet();
        //    objData = objPro.showProducts();
        //    GVProduct.DataSource = objData;
        //    GVProduct.DataBind();
        //}


        private void showPresentationDDL()
        {
            DDLPresentation.DataSource = objPres.ShowPresentationsDDL();
            DDLPresentation.DataValueField = "pres_id";//Nombre de la llave primaria
            DDLPresentation.DataTextField = "pres_descripcion";
            DDLPresentation.DataBind();
            DDLPresentation.Items.Insert(0, "---- Seleccione una persona ----");
        }

        private void showUnitMeasureDDL()
        {
            DDLUnitMeasure.DataSource = objUnit.ShowDDLUnitMeasure();
            DDLUnitMeasure.DataValueField = "und_id";//Nombre de la llave primaria
            DDLUnitMeasure.DataTextField = "und_descripcion";
            DDLUnitMeasure.DataBind();
            DDLUnitMeasure.Items.Insert(0, "---- Seleccione una persona ----");
        }

        private void showCategoryDDL()
        {
            DDLCategory.DataSource = objCategory.ShowCategoriesDDL();
            DDLCategory.DataValueField = "Id";//Nombre de la llave primaria
            DDLCategory.DataTextField = "Descripcion";
            DDLCategory.DataBind();
            DDLCategory.Items.Insert(0, "---- Seleccione una persona ----");
        }
        private void showSupplierDDL()
        {
            DDLSupplier.DataSource = objSupplier.ShowSupplierDDL();
            DDLSupplier.DataValueField = "Id";//Nombre de la llave primaria
            DDLSupplier.DataTextField = "Razon social";
            DDLSupplier.DataBind();
            DDLSupplier.Items.Insert(0, "---- Seleccione una persona ----");
        }

        protected void GVProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GVProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(TBDate.Text, out DateTime parsedDate))
            {
                LblMsg.Text = "Formato de fecha inválido";
                return;
            }
            _date = DateTime.Parse(TBDate.Text);
            _codigoProducto = TBCode.Text;
            _nombreProducto = TBNameProduct.Text;
            _descripcionProducto = TBDescription.Text;
            _cantidadInventario = Convert.ToInt32(TBQuantityP.Text);
            _numeroLote = TBNumberLote.Text;
            _precioVenta = Convert.ToDouble(TBSalePrice.Text);
            _precioCompra = Convert.ToDouble(TBPurchasePrice.Text);
            _medida = Convert.ToInt32(TBMedida.Text);

            _fkcategoria = Convert.ToInt32(DDLCategory.SelectedValue);
            _fkproveedor = Convert.ToInt32(DDLSupplier.SelectedValue);
            _fkunidadmedida = Convert.ToInt32(DDLUnitMeasure.SelectedValue);
            _fkpresentacion = Convert.ToInt32(DDLPresentation.SelectedValue);


            executed = objPro.saveProducts(_codigoProducto, _nombreProducto, _descripcionProducto,
                _cantidadInventario, _numeroLote, _date, _precioVenta, _precioCompra, _medida, 
                _fkcategoria, _fkproveedor, _fkunidadmedida, _fkpresentacion);

            
            if (executed)
            {
                //MessageBox.Show("La compra se guardo exitosamente!");
                LblMsg.Text = "La compra se guardo exitosamente!";
                clear();//Se invoca el metodo para limpiar los campos 
            }
            else
            {
                LblMsg.Text = "Error al guardar";
            }
        }
        private void clear()
        {
            HFProductID.Value = "";
            TBCode.Text = "";
            TBNameProduct.Text = "";
            TBDescription.Text = "";
            TBQuantityP.Text = "";
            TBNumberLote.Text = "";
            TBDate.Text = "";
            TBSalePrice.Text = "";
            TBPurchasePrice.Text = "";
            TBMedida.Text = "";
            DDLCategory.SelectedIndex = 0;
            DDLSupplier.SelectedIndex = 0;
            DDLUnitMeasure.SelectedIndex = 0;
            DDLPresentation.SelectedIndex = 0;
            //LblMsg.Text = "";
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado un usuario para actualizar
            if (string.IsNullOrEmpty(HFProductID.Value))
            {
                LblMsg.Text = "No se ha seleccionado la compra para actualizar.";
                return;
            }

            _id = Convert.ToInt32(HFProductID.Value);
            _date = DateTime.Parse(TBDate.Text);
            _codigoProducto = TBCode.Text;
            _nombreProducto = TBNameProduct.Text;
            _descripcionProducto = TBDescription.Text;
            _cantidadInventario = Convert.ToInt32(TBQuantityP.Text);
            _numeroLote = TBNumberLote.Text;
            _precioVenta = Convert.ToDouble(TBSalePrice.Text);
            _precioCompra = Convert.ToDouble(TBPurchasePrice.Text);
            _medida = Convert.ToInt32(TBMedida.Text);

            _fkcategoria = Convert.ToInt32(DDLCategory.SelectedValue);
            _fkproveedor = Convert.ToInt32(DDLSupplier.SelectedValue);
            _fkunidadmedida = Convert.ToInt32(DDLUnitMeasure.SelectedValue);
            _fkpresentacion = Convert.ToInt32(DDLPresentation.SelectedValue);

            executed = objPro.updateProducts(_id,_codigoProducto, _nombreProducto, _descripcionProducto,
                _cantidadInventario, _numeroLote, _date, _precioVenta, _precioCompra, _medida,
                _fkcategoria, _fkproveedor, _fkunidadmedida, _fkpresentacion);

            if (executed)
            {
                LblMsg.Text = "La compra se actualizo exitosamente!";
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
        }
    }
}