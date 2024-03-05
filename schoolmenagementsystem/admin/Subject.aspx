<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="schoolmenagementsystem.admin.Subject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><center>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>     
        </div>
        <h3 class="text-center ">New Fees </h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">  
            <div class="col-md-6">
                <asp:Label ID="ddlclass" runat="server" Text="Label"> Add Class</asp:Label>
                <asp:DropDownList ID="ddlclass1" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlclass1" Display="Dynamic" ForeColor="Red" InitialValue="seclect class" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtsubject" runat="server" Text="Label">Subject</asp:Label>
                <asp:TextBox ID="txtsubject1" runat="server" CssClass="form-control" placeholder="Enter subject name" ></asp:TextBox>
            </div>
        </div>
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server"  Text="Addsubject" BackColor="#5558C9"  CssClass="btn btn-primary btn-block" OnClick="btnAdd_Click1" />
            </div> 
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="auto-style1; alert alert-success;">
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"  EmptyDataText="no recored found" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="10" DataKeyNames="subject_id">
               <Columns>
                   <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                   <asp:TemplateField HeaderText="Class">
                       <EditItemTemplate>
                           <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="class_name" DataValueField="class_id" SelectedValue='<%# Eval("class_id") %>'>
                           </asp:DropDownList>
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sclsConnectionString %>" SelectCommand="SELECT * FROM [class]"></asp:SqlDataSource>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Eval("class_name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Subject">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("subject_name") %>' CssClass="form-control"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("subject_name") %>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle Wrap="True" />
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                   <asp:CommandField CausesValidation="false" HeaderText="Manage" ShowDeleteButton="false" ShowEditButton="True">
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:CommandField>
                   
               </Columns>
                             <HeaderStyle  BackColor="teal" ForeColor="white"/>

           </asp:GridView>
        
           </div>
            </div>
              </div>
   </div>
</asp:Content>
