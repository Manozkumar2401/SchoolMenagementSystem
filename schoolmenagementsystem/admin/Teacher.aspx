<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="schoolmenagementsystem.admin.Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div><center>
        <div class=" container p-md-4 p-sm-4">
     
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>     
        </div>
        <h3 class="text-center ">New Teacher </h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5" >  
            <div class="col-md-6">
                <asp:Label ID="txtname"  runat="server" Text="Label">Teacher Name</asp:Label>
                <asp:TextBox ID="txtname1" runat="server" CssClass="form-control" placeholder="Enter teacher  name" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name Should be in Characters" ControlToValidate="txtname1" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="[A-Za-z]*$" SetFocusOnError="True" ></asp:RegularExpressionValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtdob" runat="server" Text="Label">Date of Birth </asp:Label>
                <asp:TextBox ID="txtdob1" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>                   
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">  
            <div class="col-md-6" >
                <asp:Label ID="ddlgender" runat="server" Text="Label">Gender</asp:Label>
                <asp:DropDownList ID="ddlgender1" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Select Gender</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Fe-male</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Gender is Required" ControlToValidate="ddlgender1" SetFocusOnError="True" Display="Dynamic" InitialValue="Select Gender "></asp:RequiredFieldValidator>
             
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtmobile" runat="server" Text="Label">Mobile Number</asp:Label>
                <asp:TextBox ID="txtmobile1" runat="server" CssClass="form-control" placeholder="10 Disit Mobile no" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Mb. no" ControlToValidate="txtmobile1" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="[0-9]{10}" SetFocusOnError="True" ></asp:RegularExpressionValidator>
            </div>
           </div>
                
                
             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">  
            <div class="col-md-6">
                <asp:Label ID="txtemail" runat="server" Text="Label">E-mail</asp:Label>
                <asp:TextBox ID="txtemail1" runat="server" CssClass="form-control" placeholder="Enter Email"  TextMode="Email"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtpassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtpassword1" runat="server" CssClass="form-control"  placeholder="Enter Password" TextMode="Password" ></asp:TextBox>
            </div>
        </div>
       
           <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
           <div class="col-md-12">
                <asp:Label ID="txtaddress" runat="server" Text="Label"> Address</asp:Label>
                <asp:TextBox ID="txtaddress1" runat="server" CssClass="form-control"  TextMode="MultiLine"></asp:TextBox>
            </div>
               </div>
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="auto-style1">
                <asp:Button ID="btnAdd" runat="server"  Text="AddTeacher" BackColor="#5558C9"  CssClass="btn btn-primary btn-block" OnClick="btnAdd_Click1" />
            </div> 
              </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="auto-style1; alert alert-success; col-md-12;">
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"  EmptyDataText="no recored found" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="4" DataKeyNames="teacher_id" OnRowDeleting="GridView1_RowDeleting" Height="253px" Width="1059px">
               <Columns>
                   <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                   <asp:TemplateField HeaderText="Teacher name">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("teacher_name") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("teacher_name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Date of Birth">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("dob") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Eval("dob") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Monile no.">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("mobile") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label3" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Email">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("email") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label4" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Password">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("password") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label5" runat="server" Text='<%# Eval("password") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Address">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("address") %>' TextMode="MultiLine"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label6" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>

                   <asp:CommandField CausesValidation="false" HeaderText="Manage" ShowDeleteButton="True" ShowEditButton="True">
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:CommandField>
                   
               </Columns>
                             <HeaderStyle  BackColor="teal" ForeColor="white"/>

           </asp:GridView>
        
           </div>
            </div>
   </div>
</asp:Content>
