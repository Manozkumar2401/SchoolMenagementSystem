 <%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="MarksDetails.aspx.cs" Inherits="schoolmenagementsystem.admin.MarksDetails" %>

<%@ Register Src="~/MarksDetailusercontrol.ascx" TagPrefix="uc1" TagName="MarksDetailusercontrol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MarksDetailusercontrol runat="server" ID="MarksDetailusercontrol" />
</asp:Content>
