<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="schoolmenagementsystem.admin.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div><center>
        <div class=" container p-md-4 p-sm-4">
     
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>     
        </div>
        <h3 class="text-center ">New Teacher </h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5" >    
            <div class="col-md-6">
                <asp:Label ID="txtname"  runat="server" Text="Label">student Name</asp:Label>
                <asp:TextBox ID="txtname1" runat="server" CssClass="form-control" placeholder="Enter student  name" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name Should be in Characters" ControlToValidate="txtname1" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="[A-Za-z]*$" SetFocusOnError="True" ></asp:RegularExpressionValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtdob" runat="server" Text="Label">Date of Birth </asp:Label>
                <asp:TextBox ID="txtdob1" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

        </div>                   
          <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5" >    
            <div class="col-md-6">
                <asp:Label ID="txtfather"  runat="server" Text="Label"> Fathers Name</asp:Label>
                <asp:TextBox ID="txtfather1" runat="server" CssClass="form-control" placeholder="Enter Fathers  name" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Name Should be in Characters" ControlToValidate="txtname1" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="[A-Za-z]*$" SetFocusOnError="True" ></asp:RegularExpressionValidator>
            </div>
           <div class="col-md-6" >
                <asp:Label ID="ddlgender" runat="server" Text="Label">Gender</asp:Label>
                <asp:DropDownList ID="ddlgender1" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Select Gender</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Fe-male</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Gender is Required" ControlToValidate="ddlgender1" SetFocusOnError="True" Display="Dynamic" InitialValue="Select Gender "></asp:RequiredFieldValidator>
             
            </div>

        </div>                   
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">  
           <div class="col-md-6">
                <asp:Label ID="txtrollno" runat="server" Text="Label">Roll No</asp:Label>
                <asp:TextBox ID="txtrollno1" runat="server" CssClass="form-control" placeholder="Enter Rollno"  required="" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtmobile" runat="server" Text="Label">Mobile Number</asp:Label>
                <asp:TextBox ID="txtmobile1" runat="server" CssClass="form-control" placeholder="10 Disit Mobile no" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Mb. no" ControlToValidate="txtmobile1" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="[0-9]{10}" SetFocusOnError="True" ></asp:RegularExpressionValidator>
            </div>
           </div>
                
                
             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">  
            
            <div class="col-md-6">
                <asp:Label ID="txtclass" runat="server" Text="Class"></asp:Label>
                <asp:DropDownList ID="ddlclass1" CssClass="form-control" runat="server"></asp:DropDownList>       

            </div>
                   <div class="col-md-6">
                <asp:Label ID="txtaddress" runat="server" Text="Label"> Address</asp:Label>
                <asp:TextBox ID="txtaddress1" runat="server" CssClass="form-control"  TextMode="MultiLine"></asp:TextBox>
            </div>

        </div>
       
           
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="auto-style1">
                <asp:Button ID="btnAdd" runat="server"  Text="AddTeacher" BackColor="#5558C9"  CssClass="btn btn-primary btn-block" OnClick="btnAdd_Click"/>
            </div> 
              </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="auto-style1; alert alert-success; col-md-12;">
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"  EmptyDataText="no recored found" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="4" DataKeyNames="student_id" OnRowDeleting="GridView1_RowDeleting" Height="253px" Width="1059px">
               <Columns>
                   <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                   <asp:TemplateField HeaderText="Teacher Name">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server"   CssClass="form-control" Text='<%# Eval("student_name") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("student_name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fathers Name">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Text='<%# Eval("student_father_name") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Eval("student_father_name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Date of Birth">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control"  Text='<%# Eval("dob") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label3" runat="server" Text='<%# Eval("dob") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Monile no.">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox4" runat="server"  CssClass="form-control"  Text='<%# Eval("mobile") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label4" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Roll no">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox5" runat="server"  CssClass="form-control"  Text='<%# Eval("roll_no") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label5" runat="server" Text='<%# Eval("roll_no") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="class">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlclassg" CssClass="form-control" Width="120px" runat="server"></asp:DropDownList>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label5" runat="server" CssClass="form-control" Text='<%# Eval("class_name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Address">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox6" runat="server"  CssClass="form-control"  Width="100px" Text='<%# Eval("address") %>' TextMode="MultiLine"></asp:TextBox>
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
