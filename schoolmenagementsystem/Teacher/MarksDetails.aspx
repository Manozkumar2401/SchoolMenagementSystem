<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="MarksDetails.aspx.cs" Inherits="schoolmenagementsystem.Teacher.MarksDetails" %>

<%@ Register Src="~/MarksDetailusercontrol.ascx" TagPrefix="uc1" TagName="MarksDetailusercontrol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <center>  
      <uc1:MarksDetailusercontrol runat="server" id="MarksDetailusercontrol" />
</asp:Content>
