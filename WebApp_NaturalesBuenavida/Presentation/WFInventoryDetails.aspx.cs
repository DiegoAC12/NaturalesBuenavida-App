using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFInventoryDetails : System.Web.UI.Page
    {

        InventoryLog objInv = new InventoryLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int inventoryId = Convert.ToInt32(Request.QueryString["inventoryId"]);
                LoadInventoryDetails(inventoryId);

            }
        }

        private void LoadInventoryDetails(int inventoryId)
        {
            // Llamar al método de la capa lógica para obtener los detalles del inventario
            DataSet inventoryDetails = objInv.ShowInventoryDetails(inventoryId);

            // Verificar si hay datos y asignarlos a los controles de la página
            if (inventoryDetails != null && inventoryDetails.Tables[0].Rows.Count > 0)
            {
                DataRow row = inventoryDetails.Tables[0].Rows[0];
                LblInventoryId.Text = row["id_inventario"].ToString();
                LblFecha.Text = Convert.ToDateTime(row["fecha"]).ToString("yyyy-MM-dd");
                //LblProducto.Text = row["nombre_producto"].ToString();
                //LblCantidad.Text = row["cantidad_nueva"].ToString();
                LblObservacion.Text = row["observacion"].ToString();
                LblEmpleado.Text = row["responsable"].ToString();
            }
        }
    }
}