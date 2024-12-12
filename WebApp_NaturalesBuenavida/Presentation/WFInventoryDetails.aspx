﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFInventoryDetails.aspx.cs" Inherits="Presentation.WFInventoryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Estilos --%>
    <link href="resources/css/dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalles del Inventario</h2>

    <asp:Label ID="LabelInventoryId" runat="server" Text="ID Inventario: "></asp:Label><br />
    <asp:Label ID="LblInventoryId" runat="server"></asp:Label><br />

    <asp:Label ID="LabelFecha" runat="server" Text="Fecha Inventario: "></asp:Label><br />
    <asp:Label ID="LblFecha" runat="server"></asp:Label><br />

    <asp:Label ID="LabelProducto" runat="server" Text="Producto: "></asp:Label><br />
    <asp:Label ID="LblProducto" runat="server"></asp:Label><br />

    <asp:Label ID="LabelCantidad" runat="server" Text="Cantidad Inventariada: "></asp:Label><br />
    <asp:Label ID="LblCantidad" runat="server"></asp:Label><br />

    <asp:Label ID="LabelObservacion" runat="server" Text="Observaciones: "></asp:Label><br />
    <asp:Label ID="LblObservacion" runat="server"></asp:Label><br />

    <asp:Label ID="LabelEmpleado" runat="server" Text="Empleado: "></asp:Label><br />
    <asp:Label ID="LblEmpleado" runat="server"></asp:Label><br />
</asp:Content>
