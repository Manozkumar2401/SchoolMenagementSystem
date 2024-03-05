<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="StudentAttendanceDetails.aspx.cs" Inherits="schoolmenagementsystem.Teacher.StudentAttendanceDetails" %>

<%@ Register Src="~/StudentAttendancedetailuc.ascx" TagPrefix="uc1" TagName="StudentAttendancedetailuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StudentAttendancedetailuc runat="server" id="StudentAttendancedetailuc" />
</asp:Content>
