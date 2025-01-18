<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFtypeDocument.aspx.cs" Inherits="Presentation.WFtypeDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--Estilos--%>
    <link href="resources/css/dataTables.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <%--Id Tipo de  documento--%>
        <asp:HiddenField ID="HFTypeDocID" runat="server" />
        <br />
        <%--Nombre del tipo de documento--%>
        <asp:Label ID="Label1" runat="server" Text="Ingrese el Codigo"></asp:Label>
        <asp:TextBox ID="TBTypeDocName" runat="server"></asp:TextBox>
        <br />

        <%--Botones Guardar y Actualizar--%>
        <div>
            <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
            <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
        </div>
        <br />

    <%--Lista de Tipos de documento--%>
    <h2>Lista de tipos de documento</h2>
    <table id="typesDocTable" class="display" style="width: 100%">
        <thead>
            <tr>
                <th>Id</th>
                <th>NombreDocumento</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>

    <%--Datatables--%>
    <script src="resources/js/datatables.min.js" type="text/javascript"></script>

    <%--Tipos de documento--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#typesDocTable').DataTable({
                "processing": true,
                "serverSide": false,
                "ajax": {
                    "url": "WFtypeDocument.aspx/ListTypeDoc",// Se invoca el WebMethod Listar los tipos de documento                    "type": "POST",
                    "type": "POST",
                    "contentType": "application/json",
                    "data": function (d) {
                        return JSON.stringify(d);// Convierte los datos a JSON
                    },
                    "dataSrc": function (json) {
                        return json.d.data;// Obtiene la lista de tipos de documento del resultado
                    }
                },
                "columns": [
                    { "data": "Id" },
                    { "data": "NombreDocumento" },
                    {
                        "data": null,
                        "render": function (data, type, row) {
                            return `<button class="edit-btn" data-id="${row.Id}">Editar</button>
                                 <button class="delete-btn" data-id="${row.Id}">Eliminar</button>`;
                        }
                    }
                ],
                "language": {
                    "lengthMenu": "Mostrar _MENU_ registros por pÃ¡gina",
                    "zeroRecords": "No se encontraron resultados",
                    "info": "Mostrando pÃ¡gina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay registros disponibles",
                    "infoFiltered": "(filtrado de _MAX_ registros totales)",
                    "search": "Buscar:",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ãšltimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }

            });

            // Editar un tipo de documento
            $('#typesDocTable').on('click', '.edit-btn', function () {
                //const id = $(this).data('id');
                const rowData = $('#typesDocTable').DataTable().row($(this).parents('tr')).data();
                //alert(JSON.stringify(rowData, null, 2));
                loadTypeDocData(rowData);
            });

            // Eliminar un producto
            $('#typesDocTable').on('click', '.delete-btn', function () {
                const id = $(this).data('id');// Obtener el ID del tipo de documento
                if (confirm("Â¿EstÃ¡s seguro de que deseas eliminar este tipo de documento?")) {
                    deleteTypeDocument(id);// Invoca a la función para eliminar el tipo de documento
                }
            });
        });

        // Cargar los datos en los TextBox y DDL para actualizar
        function loadTypeDocData(rowData) {
            $('#<%= HFTypeDocID.ClientID %>').val(rowData.Id);
            $('#<%= TBTypeDocName.ClientID %>').val(rowData.NombreDocumento);
        }

        // FunciÃ³n para eliminar un producto
        function deleteTypeDocument(id) {
            $.ajax({
                type: "POST",
                url: "WFtypeDocument.aspx/DeleteTypeDocument",// Se invoca el WebMethod Eliminar un Producto
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ id: id }),
                success: function (response) {
                    $('#typesDocTable').DataTable().ajax.reload();// Recargar la tabla despuÃ©s de eliminar
                    alert("Tipo de documento eliminado exitosamente.");
                },
                error: function () {
                    alert("Error al eliminar el tipo de documento.");
                }
            });
        }
    </script>


</asp:Content>
