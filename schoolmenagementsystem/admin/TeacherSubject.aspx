


<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="TeacherSubject.aspx.cs" Inherits="schoolmenagementsystem.admin.TeacherSubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><center>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>     
        </div>
        <h3 class="text-center "> Add Teacher subject</h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">  
            <div class="col-md-6">
                <asp:Label ID="ddlclass" runat="server" Text="Label"> Class</asp:Label>
                <asp:DropDownList ID="ddlclass1" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlclass1_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlclass1" Display="Dynamic" ForeColor="Red" InitialValue="seclect class" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="ddlsubject" runat="server" Text="Label">Teacher</asp:Label>
            <asp:DropDownList ID="ddlsubject1" runat="server" CssClass="form-control"  ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlsubject1" Display="Dynamic" ForeColor="Red" InitialValue="seclect subject" SetFocusOnError="True"></asp:RequiredFieldValidator>   
            </div>
            <div class="col-md-6">
                <asp:Label ID="ddlTeacher" runat="server" Text="Label">Teacher</asp:Label>
            <asp:DropDownList ID="ddlteacher1" runat="server" CssClass="form-control"  ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlteacher1" Display="Dynamic" ForeColor="Red" InitialValue="seclect teacher" SetFocusOnError="True"></asp:RequiredFieldValidator>   
            </div>
        </div>  
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server"  Text="Assign Subject" BackColor="#5558C9"  CssClass="btn btn-primary btn-block" OnClick="btnAdd_Click"  />
            </div> 
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="auto-style1; alert alert-success;">
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"  EmptyDataText="no recored found" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="4" DataKeyNames="teachersubject" OnRowDeleting="GridView1_RowDeleting1" OnRowDataBound="GridView1_RowDataBound">
               <Columns>
                   <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>

                   <asp:TemplateField HeaderText="Class">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlclassg" CssClass="form-control" runat="server"  DataSourceID="SqlDataSource1" DataTextField="class_name" DataValueField="class_id" AutoPostBack="true" SelectedValue='<%# Eval("class_id") %>' OnSelectedIndexChanged="ddlclassg_SelectedIndexChanged">
                               <asp:ListItem>Select Class</asp:ListItem>
                           </asp:DropDownList>
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sclsConnectionString %>" SelectCommand="SELECT * FROM [class]"></asp:SqlDataSource>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Eval("class_name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Subject">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlsubjectg" runat="server" CssClass="form-control" >
                           </asp:DropDownList>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("subject_name") %>'></asp:Label>
                       </ItemTemplate>

                        
                  <%-- <asp:TemplateField HeaderText="Teacher">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlteacherg" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="teacher_name" DataValueField="class_id" SelectedValue='<%# Eval("teacher_id") %>'>
                           </asp:DropDownList>
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sclsConnectionString %>" SelectCommand="SELECT * FROM [class]"></asp:SqlDataSource>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Eval("class_name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField--%>

                       <HeaderStyle Wrap="True" />
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                   <asp:CommandField CausesValidation="false" HeaderText="Manage" ShowDeleteButton="true" ShowEditButton="True"   >
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:CommandField>
                   
                   <asp:TemplateField HeaderText="Teacher">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlteacherg" runat="server"  CssClass="form-control"  DataSourceID="SqlDataSource2" DataTextField="teacher_name" DataValueField="teacher_id" SelectedValue='<%# Eval("teacher_id") %>' >
                           </asp:DropDownList>
                           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sclsConnectionString %>" SelectCommand="SELECT [teacher_id], [teacher_name] FROM [teacher]"></asp:SqlDataSource>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label3" runat="server" Text='<%# Eval("teacher_name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   
               </Columns>
                             <HeaderStyle  BackColor="teal" ForeColor="white"/>

           </asp:GridView>
           
        
           </div>
            </div>
         </div>
   </div>
    
</asp:Content>
      