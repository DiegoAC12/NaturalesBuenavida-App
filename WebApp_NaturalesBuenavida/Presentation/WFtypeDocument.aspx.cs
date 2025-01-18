using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFtypeDocument : System.Web.UI.Page
    {
        //Crear los objetos
        TypeDocumentLog objTypeDoc = new TypeDocumentLog();

        private int doc_id;
        private string doc_tipo_documento;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        [WebMethod]
        public static object ListTypeDoc()
        {
            TypeDocumentLog objTypeDoc = new TypeDocumentLog();

            // Se obtiene un DataSet que contiene la lista de productos los docuementos desde la base de datos.
            var dataSet = objTypeDoc.showTypesDocument();

            // Se crea una lista para almacenar los tipos de los docuementos que se van a devolver.
            var ListTypeDoc = new List<object>();

            // Se itera sobre cada fila del DataSet (que representa un tipo de documento).
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                ListTypeDoc.Add(new
                {
                    Id = row["doc_id"],
                    NombreDocumento = row["doc_tipo_documento"],
                });
            }
            // Devuelve un objeto en formato JSON que contiene la lista de tipos de documentos.
            return new { data = ListTypeDoc };
        }
        [WebMethod]
        public static bool DeleteTypeDocument(int id)
        {
            // Crear una instancia de la clase de lógica de tipos de documento
            TypeDocumentLog objTypeD = new TypeDocumentLog();

            // Invocar al método para eliminar el producto y devolver el resultado
            return objTypeD.deleteTypeDocument(id);
        }

        //Metodo para limpiar los TextBox y los DDL
        private void clear()
        {
            HFTypeDocID.Value = "";
            TBTypeDocName.Text = "";
        }

        //Eventos que se ejecutan cuando se da clic en los botones
        protected void BtnSave_Click(object sender, EventArgs e)
        {

            doc_tipo_documento = TBTypeDocName.Text;


            executed = objTypeDoc.saveTypeDocument(doc_tipo_documento);

            if (executed)
            {
                LblMsg.Text = "El tipo de documento se guardo exitosamente!";
                clear();//Se invoca el metodo para limpiar los campos 
            }
            else
            {
                LblMsg.Text = "Error al guardar";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado un producto para actualizar
            if (string.IsNullOrEmpty(HFTypeDocID.Value))
            {
                LblMsg.Text = "No se ha seleccionado un registro para actualizar.";
                return;
            }
            doc_id = Convert.ToInt32(HFTypeDocID.Value);
            doc_tipo_documento = TBTypeDocName.Text;

            executed = objTypeDoc.updateTypeDocument(doc_id, doc_tipo_documento);

            if (executed)
            {
                LblMsg.Text = "El tipo de documento se actualizo exitosamente!";
                clear(); //Se invoca el metodo para limpiar los campos 
            }
            else
            {
                LblMsg.Text = "Error al actualizar";
            }

        }
    }
}