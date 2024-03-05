
<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Addclass1.aspx.cs" Inherits="schoolmenagementsystem.admin.Addclass1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
   <center>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>
        </div>
        <h3 class="text-center ">Admin Home Page </h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <asp:Label ID="txtclass" runat="server" Text="Label"> Add Class</asp:Label>
                <asp:TextBox ID="txtclass1" runat="server" CssClass="form-control" placeholder="Enter Class Name" ></asp:TextBox>
            </div>
        </div>
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server"  Text="AddClass" BackColor="#5558C9"  CssClass="btn btn-primary btn-block" OnClick="btnAdd_Click" />
            </div> 
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
        
       <div class="col-md-6" ">
          
       <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover; table-bordered;" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
           <Columns >
               <asp:BoundField DataField="class_id" HeaderText="classid" ReadOnly="True" />
               <asp:BoundField DataField="class_name" HeaderText="classname" />
               
               <asp:CommandField ShowEditButton="True" Headertext="manage" />
      
               <asp:CommandField ShowDeleteButton="True"  />
           </Columns>
              <HeaderStyle  BackColor="teal" ForeColor="white"/>
       </asp:GridView>
           </div>
   </div>
</asp:Content>
