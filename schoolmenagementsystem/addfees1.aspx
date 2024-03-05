<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addfees1.aspx.cs" Inherits="schoolmenagementsystem.addfees1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <div><center>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>
        </div>
        <h3 class="text-center ">Admin Home Page </h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
           <div class="col-md-6">
                <asp:Label ID="ddlclass" runat="server" Text="Label">Class</asp:Label>

               <asp:DropDownList ID="ddlclass1" runat="server" CssClass="form-control"></asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="class is required" ControlToValidate="ddlclass1" Display="Dynamic" ForeColor="#FF3300" InitialValue="select class" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="feeamounts" runat="server" Text="Label"> Add Class</asp:Label>
                <asp:TextBox ID="feeamounts1" runat="server" CssClass="form-control" placeholder="Enter fee amount" ></asp:TextBox>
            </div>
        </div>
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btadd" runat="server"  Text="Addfees" BackColor="#5558C9"  CssClass="btn btn-primary btn-block" OnClick="btnAdd_Click" />
            </div> 
              </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="col-md-6" ">
           <asp:GridView ID="GridView1" runat="server"></asp:GridView>
          
                    </div>    
         </div>
   </div>





</asp:Content>
