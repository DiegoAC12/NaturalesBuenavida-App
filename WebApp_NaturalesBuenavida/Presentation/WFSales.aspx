<%@ Page Title="Gestión de Ventas" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFSales.aspx.cs" Inherits="Presentation.WFSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="resources/css/dataTables.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center main-title">Lista de Ventas</h2>
    <div class="container mt-4 bg-white border rounded p-3">

        <asp:HiddenField ID="HFSaleID" runat="server" />

        <div class="mt-3 text-center">
            <asp:Label ID="LblMsg" runat="server" Text="" CssClass=""></asp:Label>
        </div>

        <!-- Fila para la fecha de venta -->
        <div class="mb-3 row">
            <div class="col-md-6">
                <asp:Label ID="LabelDate" runat="server" CssClass="form-label fw-bold" Text="Fecha de la venta"></asp:Label>
                <asp:TextBox ID="TBDate" runat="server" TextMode="Date" CssClass="form-control" ReadOnly="true"></asp:TextBox>

            </div>
        </div>

        <!-- Fila para el empleado y cliente -->
        <div class="mb-3 row">
            <div class="col-md-6">
                <asp:Label ID="LabelEmployee" runat="server" CssClass="form-label fw-bold" Text="Empleado"></asp:Label>
                <asp:DropDownList ID="DDLEmployee" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Label ID="LabelClient" runat="server" CssClass="form-label fw-bold" Text="Cliente"></asp:Label>
                <asp:DropDownList ID="DDLClient" CssClass="form-select" runat="server"></asp:DropDownList>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WFClient.aspx">¿Agregar Cliente?</asp:HyperLink>
            </div>
        </div>

        <!-- Fila para el producto y cantidad -->
        <div class="mb-3 row">
            <div class="col-md-6">
                <asp:Label ID="LabelProducto" runat="server" CssClass="form-label fw-bold" Text="Producto"></asp:Label>
                <asp:DropDownList ID="DDLProduct" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Label ID="LabelCantidad" runat="server" CssClass="form-label fw-bold" Text="Cantidad Vendida"></asp:Label>
                <asp:TextBox ID="TBQuantity" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <!-- Fila para la descripción -->
        <div class="mb-3 row">
            <div class="col-md-12">
                <asp:Label ID="LabelDescription" runat="server" CssClass="form-label fw-bold" Text="Descripción"></asp:Label>
                <asp:TextBox ID="TBDescription" runat="server" TextMode="MultiLine" Rows="3" Columns="30" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <!-- Botones Guardar, Actualizar, Limpiar -->
        <div class="d-flex flex-column flex-md-row gap-2 mt-3">
            <asp:Button ID="BtnSave" runat="server" Text="Realizar Venta" CssClass="btn" OnClick="BtnSave_Click" />
            <%--<asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" CssClass="btn" OnClick="BtnUpdate_Click" />--%>
            <asp:Button ID="BtnClear" runat="server" Text="Limpiar" CssClass="btn" OnClick="BtnClear_Click" />
        </div>
    </div>



    <div class="container table-responsive mt-4 bg-white border rounded">
        <table id="salesTable" class="table display" style="width: 100%">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Fecha</th>
                    <th>Numero Factura</th>
                    <th>IdProducto</th>
                    <th>Producto</th>
                    <th>Precio Unidad</th>
                    <th>Cantidad Vendida</th>
                    <th>Total</th>
                    <th>cliente_id</th>
                    <th>Identificacion Cliente</th>
                    <th>Nombre Cliente</th>
                    <th>empleado_id</th>
                    <th>Identificacion Empleado</th>
                    <th>Nombre Empleado</th>
                    <th>Descripción</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <%-- Scripts --%>
    <script src="resources/js/datatables.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#salesTable').DataTable({
                "processing": true,
                "serverSide": false,
                "ajax": {
                    "url": "WFSales.aspx/ListSales",
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
                    { "data": "ID", "visible": false },
                    { "data": "Fecha" },
                    { "data": "NumeroFactura" },
                    { "data": "IdProducto", "visible": false },
                    { "data": "Producto" },
                    { "data": "PrecioUnidad" },
                    { "data": "CantidadVendida" },
                    { "data": "Total" },
                    { "data": "cliente_id", "visible": false },
                    { "data": "IdentificacionCliente" },
                    { "data": "NombreCliente" },
                    { "data": "empleado_id", "visible": false },
                    { "data": "IdentificacionEmpleado" },
                    { "data": "NombreEmpleado" },
                    { "data": "Descripcion" },
                    {
                        "data": null,
                        "render": function (data, type, row) {
                            return `<button class="edit-btn"  type="button" data-id="${row.ID}">Editar</button>
                                    <button class="delete-btn"  type="button" data-id="${row.ID}">Eliminar</button>`;
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
            // Manejar clic en el botón de eliminar
            $('#salesTable').on('click', '.delete-btn', function () {
                const saleId = $(this).data('id');  // Obtiene el ID de la venta

                if (confirm("¿Estás seguro de que deseas eliminar esta venta?")) {
                    $.ajax({
                        url: 'WFSales.aspx/DeleteSale',
                        type: 'POST',
                        data: JSON.stringify({ saleId: saleId }), // Pasa el ID de la venta
                        contentType: 'application/json',
                        success: function (response) {
                            if (response.d.Success) {
                                alert('Venta eliminada correctamente.');
                                $('#salesTable').DataTable().ajax.reload(); // Recarga los datos de la tabla
                            } else {
                                alert('Error al eliminar la venta.');
                            }
                        },
                        error: function () {
                            alert("Hubo un error al eliminar la venta.");
                        }
                    });
                }
            });

            // Manejar clic en el botón de Editar
            $('#salesTable').on('click', '.edit-btn', function () {
                const rowData = $('#salesTable').DataTable().row($(this).parents('tr')).data();
                loadSalesData(rowData);
            });
        });

        function loadSalesData(rowData) {
            $('#<%= HFSaleID.ClientID %>').val(rowData.ID);
            $('#<%= TBDate.ClientID %>').val(rowData.Fecha);
            $('#<%= TBQuantity.ClientID %>').val(rowData.Cantidad);
            $('#<%= TBDescription.ClientID %>').val(rowData.Descripción);
            $('#<%= DDLClient.ClientID %>').val(rowData.cliente_id);
            $('#<%= DDLEmployee.ClientID %>').val(rowData.empleado_id);
            $('#<%= DDLProduct.ClientID %>').val(rowData.IdProducto);
        }
    </script>
</asp:Content>
