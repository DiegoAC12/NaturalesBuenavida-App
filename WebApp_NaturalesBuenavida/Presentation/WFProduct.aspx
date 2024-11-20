<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProduct.aspx.cs" Inherits="Presentation.WFProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--Estilos--%>
    <link href="resources/css/dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:Label ID="LBId" runat="server" Text="" Visible="true"></asp:Label><br />
    <br />

    <asp:Label ID="Label2" runat="server" Text="Codigo del producto"></asp:Label><br />
    <asp:TextBox ID="TBCode" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label3" runat="server" Text="Nombre del Producto"></asp:Label><br />
    <asp:TextBox ID="TBNameProduct" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label4" runat="server" Text="Descripción del Producto"></asp:Label><br />
    <asp:TextBox ID="TBDescription" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label5" runat="server" Text="Cantidad del producto para inventario"></asp:Label><br />
    <asp:TextBox ID="TBQuantityP" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label6" runat="server" Text="Número de Lote"></asp:Label><br />
    <asp:TextBox ID="TBNumberLote" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label7" runat="server" Text="Fecha de Vencimiento"></asp:Label><br />
    <asp:TextBox ID="TBExpirationDate" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label8" runat="server" Text="Precio de Venta"></asp:Label><br />
    <asp:TextBox ID="TBSalePrice" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label9" runat="server" Text="Precio de Compra"></asp:Label><br />
    <asp:TextBox ID="TBPurchasePrice" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label10" runat="server" Text="Dato de Medida"></asp:Label><br />
    <asp:TextBox ID="TBMedida" runat="server"></asp:TextBox><br />

    <asp:Label ID="Label1" runat="server" Text="Unidad de Medida"></asp:Label><br />
    <asp:DropDownList ID="DDLUnitMeasure" runat="server">
        <asp:ListItem Text="Seleccione una unidad de medida" Value="0"></asp:ListItem>
    </asp:DropDownList><br />
    <asp:Label ID="Label13" runat="server" Text="Presentación del producto"></asp:Label><br />
    <asp:DropDownList ID="DDLPresentation" runat="server">
        <asp:ListItem Text="Seleccione un tipo de presentación" Value="0"></asp:ListItem>
    </asp:DropDownList><br />
    <asp:Label ID="Label11" runat="server" Text="Categoria del producto"></asp:Label><br />
    <asp:DropDownList ID="DDLCategory" runat="server">
        <asp:ListItem Text="Seleccione una categoria" Value="0"></asp:ListItem>
    </asp:DropDownList><br />
    <asp:Label ID="Label12" runat="server" Text="Proveedor"></asp:Label><br />
    <asp:DropDownList ID="DDLSupplier" runat="server">
        <asp:ListItem Text="Seleccione un proveedor" Value="0"></asp:ListItem>
    </asp:DropDownList><br />
    <br />
    <br />
    <asp:GridView ID="GVProduct" runat="server" OnSelectedIndexChanged="GVProduct_SelectedIndexChanged"
        OnRowDeleting="GVProduct_RowDeleting">
        <Columns>
            <asp:CommandField ShowSelectButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>--%>


        <%--Id Cliente--%>
        <asp:HiddenField ID="HFProductID" runat="server" />
        <br />
        <%--Codigo producto--%>
        <asp:Label ID="Label2" runat="server" Text="Codigo del producto"></asp:Label><br />
        <asp:TextBox ID="TBCode" runat="server"></asp:TextBox><br />
        <%--Nombre del producto--%>
        <asp:Label ID="Label3" runat="server" Text="Nombre del Producto"></asp:Label><br />
        <asp:TextBox ID="TBNameProduct" runat="server"></asp:TextBox><br />
        <%--Descripcion del producto--%>
        <asp:Label ID="Label4" runat="server" Text="Descripción del Producto"></asp:Label><br />
        <asp:TextBox ID="TBDescription" runat="server"></asp:TextBox><br />
        <%--Cantidad del producto inicial para el inventario--%>
        <asp:Label ID="Label5" runat="server" Text="Cantidad del producto para inventario"></asp:Label><br />
        <asp:TextBox ID="TBQuantityP" runat="server"></asp:TextBox><br />
        <%-- Número de Lote --%>Q
        <asp:Label ID="Label6" runat="server" Text="Número de Lote"></asp:Label><br />
        <asp:TextBox ID="TBNumberLote" runat="server"></asp:TextBox><br />
        <%-- Fecha de vencimiento del producto --%>
        <asp:Label ID="Label7" runat="server" Text="Fecha de Vencimiento"></asp:Label><br />
        <asp:TextBox ID="TBDate" runat="server" TextMode="Date"></asp:TextBox><br />
        <%-- Precio de venta del producto --%>
        <asp:Label ID="Label8" runat="server" Text="Precio de Venta"></asp:Label><br />
        <asp:TextBox ID="TBSalePrice" runat="server"></asp:TextBox><br />
        <%-- Precio de compra del producto --%>
        <asp:Label ID="Label9" runat="server" Text="Precio de Compra"></asp:Label><br />
        <asp:TextBox ID="TBPurchasePrice" runat="server"></asp:TextBox><br />
        <%-- Medida numérica --%>
        <asp:Label ID="Label10" runat="server" Text="Dato de Medida"></asp:Label><br />
        <asp:TextBox ID="TBMedida" runat="server"></asp:TextBox><br />
        <%-- DDL Unidad de la medida --%>
        <asp:Label ID="Label1" runat="server" Text="Unidad de Medida"></asp:Label><br />
        <asp:DropDownList ID="DDLUnitMeasure" runat="server">
            <%--<asp:ListItem Text="Seleccione una unidad de medida" Value="0"></asp:ListItem>--%>
        </asp:DropDownList><br />
        <%-- DDL Presentación del producto (tetrapack, caja, bolsa, etc...) --%>
        <asp:Label ID="Label13" runat="server" Text="Presentación del producto"></asp:Label><br />
        <asp:DropDownList ID="DDLPresentation" runat="server">
            <%--<asp:ListItem Text="Seleccione un tipo de presentación" Value="0"></asp:ListItem>--%>
        </asp:DropDownList><br />
        <%-- DDL Categoria del producto --%>
        <asp:Label ID="Label11" runat="server" Text="Categoria del producto"></asp:Label><br />
        <asp:DropDownList ID="DDLCategory" runat="server">
            <%--<asp:ListItem Text="Seleccione una categoria" Value="0"></asp:ListItem>--%>
        </asp:DropDownList><br />
        <%-- DDL Proveedor --%>
        <asp:Label ID="Label12" runat="server" Text="Proveedor"></asp:Label><br />
        <asp:DropDownList ID="DDLSupplier" runat="server">
            <%--<asp:ListItem Text="Seleccione un proveedor" Value="0"></asp:ListItem>--%>
        </asp:DropDownList><br />
        <br />
        <br />

        <%--Botones Guardar y Actualizar--%>
        <div>
            <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" /><br />
            <asp:Button ID="BtbClear" runat="server" Text="Limpiar" OnClick="BtbClear_Click" /><br />
            <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
        </div>
        <br />


    <%--Lista de Productos--%>
    <h2>Lista de Productos</h2>
    <table id="productsTable" class="display" style="width: 100%">
        <thead>
            <tr>
                <th>ProductID</th>
                <th>Codigo</th>
                <th>Nombre</th>
                <th>Descripcion</th>
                <th>Medida</th>
                <th>fkunidadmedida</th>
                <th>UnidadMedida</th>
                <th>fkpresentacion</th>
                <th>Presentacion</th>
                <th>fkcategory</th>
                <th>Categoria</th>
                <th>Cantidad</th>
                <th>NumeroLote</th>
                <th>FechaVencimiento</th>
                <th>PrecioVenta</th>
                <th>PrecioCompra</th>
                <th>fkproveedor</th>
                <th>NombreProveedor</th>
                <th>ApellidoProveedor</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>

    <%--Datatables--%>
    <script src="resources/js/datatables.min.js" type="text/javascript"></script>
    <%--Productos--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#productsTable').DataTable({
                "processing": true,
                "serverSide": false,
                "ajax": {
                    "url": "WFProduct.aspx/ListProducts",// Se invoca el WebMethod Listar Compras
                    "type": "POST",
                    "contentType": "application/json",
                    "data": function (d) {
                        return JSON.stringify(d);// Convierte los datos a JSON
                    },
                    "dataSrc": function (json) {
                        return json.d.data;// Obtiene la lista de productos del resultado
                    }
                },
                "columns": [
                    { "data": "ProductID", "visible": false },
                    { "data": "Codigo" },
                    { "data": "Nombre" },
                    { "data": "Descripcion" },
                    { "data": "Medida" },
                    { "data": "fkunidadmedida", "visible": false },
                    { "data": "UnidadMedida" },
                    { "data": "fkpresentacion", "visible": false },
                    { "data": "Presentacion" },
                    { "data": "fkcategory", "visible": false },
                    { "data": "Categoria" },
                    { "data": "Cantidad" },
                    { "data": "NumeroLote" },
                    { "data": "FechaVencimiento" },
                    { "data": "PrecioVenta" },
                    { "data": "PrecioCompra" },
                    { "data": "fkproveedor", "visible": false },
                    { "data": "NombreProveedor" },
                    { "data": "ApellidoProveedor" },
                    {
                        "data": null,
                        "render": function (data, type, row) {
                            return `<button class="edit-btn" data-id="${row.ProductID}">Editar</button>
                            <button class="delete-btn" data-id="${row.ProductID}">Eliminar</button>`;
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

            // Editar un producto
            $('#productsTable').on('click', '.edit-btn', function () {
                //const id = $(this).data('id');
                const rowData = $('#productsTable').DataTable().row($(this).parents('tr')).data();

                //alert(JSON.stringify(rowData, null, 2));
                loadProductsData(rowData);
            });

            //Eliminar un producto
            $('#productsTable').on('click', '.delete-btn', function () {
                const id = $(this).data('id');// Obtener el ID del producto
                if (confirm("¿Estás seguro de que deseas eliminar este producto?")) {
                    deleteProduct(id);// Invoca a la función para eliminar el producto
                }
            });
        });

        // Cargar los datos en los TextBox y DDL para actualizar
        function loadProductsData(rowData) {
            $('#<%= HFProductID.ClientID %>').val(rowData.ProductID);
            $('#<%= TBCode.ClientID %>').val(rowData.Codigo);
            $('#<%= TBNameProduct.ClientID %>').val(rowData.Nombre);
            $('#<%= TBDescription.ClientID %>').val(rowData.Descripcion);
            $('#<%= TBQuantityP.ClientID %>').val(rowData.Cantidad);
            $('#<%= TBNumberLote.ClientID %>').val(rowData.NumeroLote);
            $('#<%= TBDate.ClientID %>').val(rowData.FechaVencimiento);
            $('#<%= TBSalePrice.ClientID %>').val(rowData.PrecioVenta);
            $('#<%= TBPurchasePrice.ClientID %>').val(rowData.PrecioCompra);
            $('#<%= TBMedida.ClientID %>').val(rowData.Medida);
            $('#<%= DDLUnitMeasure.ClientID %>').val(rowData.fkunidadmedida);
            $('#<%= DDLPresentation.ClientID %>').val(rowData.fkpresentacion);
            $('#<%= DDLCategory.ClientID %>').val(rowData.fkcategory);
            $('#<%= DDLSupplier.ClientID %>').val(rowData.fkproveedor);


        }
        // Función para eliminar un producto
        function deleteProduct(id) {
            $.ajax({
                type: "POST",
                url: "WFProduct.aspx/DeleteProduct",// Se invoca el WebMethod Eliminar un Producto
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ id: id }),
                success: function (response) {
                    $('#productsTable').DataTable().ajax.reload();// Recargar la tabla después de eliminar
                    alert("Producto eliminado exitosamente.");
                },
                error: function () {
                    alert("Error al eliminar el producto.");
                }
            });
        }

    </script>
</asp:Content>
