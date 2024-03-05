<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="schoolmenagementsystem.admin.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image:url('../Image/image2.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed; ">
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>
        </div>
        <h2 class="text-center ">Admin Home Page </h2>

    </div>
    <%--<img src="../Image/image2.jpg" class="auto-style1" />--%>
</asp:Content>
