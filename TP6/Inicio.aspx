<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP6.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblGrupo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Grupo N° 2"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="hlEjercicio1" runat="server" NavigateUrl="~/Ejercicio1.aspx">Ejercicio1</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="hlEjercicio2" runat="server" NavigateUrl="~/Ejercicio2-1.aspx">Ejercicio2</asp:HyperLink>
        </div>
    </form>
</body>
</html>
