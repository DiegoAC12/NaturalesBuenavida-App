<%@ Page Title="Gestión de inventarios" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="WFInventory.aspx.cs" Inherits="Presentation.WFInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Estilos --%>
    <link href="resources/css/dataTables.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center main-title">Lista de Inventarios</h2>
    <div class="container table-responsive mt-4 bg-white border rounded">

        <asp:HiddenField ID="HFInventoryID" runat="server" />
        <div class="mt-3 text-center">
            <asp:Label ID="LblMsg" runat="server" Text="" CssClass=""></asp:Label>
        </div>

        <!-- Fila para la fecha de inventario -->
        <div class="mb-3 row">
            <div class="col-md-6">
                <asp:Label ID="LabelDate" runat="server" CssClass="form-label fw-bold" Text="Fecha realización Inventario"></asp:Label>
                <asp:TextBox ID="TBDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="LabelEmployee" runat="server" CssClass="form-label fw-bold" Text="Empleado que realiza el inventario"></asp:Label>
                <asp:DropDownList ID="DDLEmployee" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
        </div>

        <!-- Fila para la observación -->
        <div class="mb-3 row">
            <div class="col-md-12">
                <asp:Label ID="LabelObservacion" runat="server" CssClass="form-label fw-bold" Text="Observaciones"></asp:Label>
                <asp:TextBox ID="TBObservacion" runat="server" TextMode="MultiLine" Rows="3" Columns="30" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <hr />

        <div class="mb-3 row">
            <div class="col-md-6">
                <asp:Label ID="LabelProducto" runat="server" CssClass="form-label fw-bold" Text="Producto"></asp:Label>
                <asp:DropDownList ID="DDLProduct" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Label ID="LabelQuantity" runat="server" CssClass="form-label fw-bold" Text="Cantidad nueva"></asp:Label>
                <asp:TextBox ID="TBQuantity" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3 row">
            <div class="col-md-6">
                <asp:Button ID="btnAddRow" runat="server" Text="Añadir a la fila" CssClass="add-btn" OnClick="btnAddRow_Click" />
            </div>
        </div>
        <hr />

        <div>
            <asp:GridView ID="GVProduct" runat="server" AutoGenerateColumns="False" OnRowDeleting="GVProduct_RowDeleting" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" HeaderStyle-CssClass="table-header" />
                    <asp:BoundField DataField="Nombre" HeaderText="Producto" HeaderStyle-CssClass="table-header" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="table-header" />
                    <asp:CommandField ShowDeleteButton="true" HeaderText="Acciones" HeaderStyle-CssClass="table-header" ControlStyle-CssClass="delete-btn" ButtonType="Button" />
                </Columns>
            </asp:GridView>
        </div>
        <hr />

        <div class="d-flex flex-column flex-md-row gap-2 mt-3">
            <asp:Button ID="BtnSave" runat="server" Text="Guardar Inventario" CssClass="btn" OnClick="BtnSave_Click" />
            <asp:Button ID="BtbClear" runat="server" Text="Limpiar" CssClass="btn" OnClick="BtbClear_Click" /><br />
        </div>

        <table id="inventorysTable" class="table display" style="width: 100%">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Fecha</th>
                    <th>Observación</th>
                    <th>Empleado</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <%-- Datatables Script --%>
    <script src="resources/js/datatables.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //const baseUrl = "https://localhost:44352/WFInventoryDetails.aspx";
            // Inicializar DataTable
            $('#inventorysTable').DataTable({
                "processing": true,
                "serverSide": false,
                "ajax": {
                    "url": "WFInventory.aspx/ListInventorys",
                    "type": "POST",
                    "contentType": "application/json",
                    "data": function (d) {
                        return JSON.stringify(d);
                    },
                    "dataSrc": function (json) {
                        return json.d.data;
                    }
                },
                "columns": [
                    { "data": "InventoryID", "visible": false },
                    { "data": "FechaInventario" },
                    { "data": "Observacion" },
                    { "data": "NombreResponsable" },
                    {
                        "data": null,
                        "render": function (data, type, row) {
                            return `
                                    <button type="button" class="view-btn" data-id="${row.InventoryID}">Ver Detalles</button>
                                    <button type="button" class="delete-btn" data-id="${row.InventoryID}">Eliminar</button>`;
                        }
                    }
                ],
                "language": {
                    "lengthMenu": "Mostrar _MENU_ registros por página",
                    "zeroRecords": "No se encontraron resultados",
                    "info": "Mostrando página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay registros disponibles",
                    "infoFiltered": "(filtrado de _MAX_ registros totales)",
                    "search": "Buscar:",
                    "paginate": {
                        "first": "Primero",
                        "last": "Último",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });

            // Ver detalles del inventario
            $('#inventorysTable').on('click', '.view-btn', function () {
                //alert("Evento detectado");
                //console.log("Evento de clic detectado."); // Depuración
                const rowData = $('#inventorysTable').DataTable().row($(this).parents('tr')).data();
                //alert("RowData" + rowData);
                //console.log("Datos de la fila:", rowData); // Depuración
                const inventoryId = rowData.InventoryID;
                //alert("ID: "+ inventoryId);
                if (inventoryId) {
                    window.location.href = `https://localhost:44352/WFInventoryDetails.aspx?inventoryId=${inventoryId}`;
                } else {
                    alert('ID de inventario no encontrado.');
                }
            });

            // Eliminar un inventario
            $('#inventorysTable').on('click', '.delete-btn', function () {
                const inventoryId = $(this).data('id');
                if (confirm("¿Estás seguro de que deseas eliminar este inventario?")) {
                    deleteInventory(inventoryId);
                }
            });
        });

        // Función para eliminar un inventario
        function deleteInventory(id) {
            $.ajax({
                type: "POST",
                url: "WFInventory.aspx/DeleteInventory",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ id: id }),
                success: function (response) {
                    if (response.d.Success) {
                        alert('Inventario eliminado correctamente.');
                        $('#inventorysTable').DataTable().ajax.reload(); // Recarga los datos de la tabla
                    } else {
                        alert('Error al eliminar el inventario.');
                    }
                },
                error: function () {
                    alert("Hubo un error al eliminar el inventario.");
                }
            });
        }
    </script>
</asp:Content>
