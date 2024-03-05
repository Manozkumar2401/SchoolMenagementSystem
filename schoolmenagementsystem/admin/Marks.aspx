<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Marks.aspx.cs" Inherits="schoolmenagementsystem.admin.Marks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div><center>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>     

        </div>
        <h3 class="text-center "> Teacher Expence </h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <asp:Label ID="ddlclass" runat="server" Text="Label"> Class</asp:Label>
                <asp:DropDownList ID="ddlclass1" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlclass1_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlclass1" Display="Dynamic" ForeColor="Red" InitialValue="seclect class" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="ddlsubject" runat="server" Text="Label">Subject</asp:Label>
            <asp:DropDownList ID="ddlsubject1" runat="server" CssClass="form-control"  ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlsubject1" Display="Dynamic" ForeColor="Red" InitialValue="seclect subject" SetFocusOnError="True"></asp:RequiredFieldValidator>   
            </div>        
        </div>  
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
               <div class="col-md-12">
                <asp:Label ID="txtroll" runat="server" Text="Label">Roll Number </asp:Label>
                <asp:TextBox ID="txtroll1" runat="server"   CssClass="form-control" required="" placeholdeer=" Enter Student roll number" ></asp:TextBox>

            </div>
              </div>

          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
               <div class="col-md-6">
                <asp:Label ID="txtmarks" runat="server" Text="Label"> Total Marks</asp:Label>
                <asp:TextBox ID="txtmarks1" runat="server" textmode="Number"  CssClass="form-control" required="" placeholdeer=" Enter Total Marks">Total marks</asp:TextBox>

            </div>
              <div class="col-md-6">
                <asp:Label ID="txtoutofmarks" runat="server" Text="Label"> Out Of Marks</asp:Label>
                <asp:TextBox ID="txtoutofmarks1" runat="server" textmode="Number"  CssClass="form-control" required="" >Out of marks </asp:TextBox>

            </div>
              </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 ">

            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server"  Text="Add Marks" BackColor="#50409A"  CssClass="btn btn-primary btn-block" onclick="btnAdd_Click" />
            </div> 
                </div>
                    
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="col-md-12">
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"  EmptyDataText="no recored found" AutoGenerateColumns="False"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="4" DataKeyNames="exam_id" OnRowDeleting="GridView1_RowDeleting1" OnRowDataBound="GridView1_RowDataBound" >
               <Columns>
                   <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                   <asp:TemplateField HeaderText="Class">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlclassg" CssClass="form-control" runat="server"  DataSourceID="SqlDataSource1" DataTextField="class_name" DataValueField="class_id" AutoPostBack="true" SelectedValue='<%# Eval("class_id") %>' OnSelectedIndexChanged="ddlclassg_SelectedIndexChanged1" >
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
                           <asp:DropDownList ID="ddlsubjectg" runat="server" CssClass="auto-style1" Width="228px" >
                           </asp:DropDownList>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("subject_name") %>'></asp:Label>
                       </ItemTemplate>     
                       <HeaderStyle Wrap="True" />
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>                  
                   <asp:TemplateField HeaderText="Roll Number">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtrollnog" runat="server" CssClass="form-control" Text='<%# Eval("roll_no") %>' ></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblrollnog" runat="server" Text='<%# Eval("roll_no") %>'></asp:Label>    
                       </ItemTemplate>
                   </asp:TemplateField>      
                     <asp:TemplateField HeaderText="Total Marks">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtmarksg" runat="server" CssClass="form-control" TextMode="Number" Text='<%# Eval("total_marks") %>' ></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblmarksg" runat="server" Text='<%# Eval("total_marks") %>'></asp:Label>    
                       </ItemTemplate>
                   </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Out Of Marks">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtoutofmarksg" runat="server" CssClass="form-control" TextMode="Number" Text='<%# Eval("outof_marks") %>' ></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lbloutofmarksg" runat="server" Text='<%# Eval("outof_marks") %>'></asp:Label>    
                       </ItemTemplate>
                   </asp:TemplateField> 
                   <asp:CommandField CausesValidation="false" HeaderText="Manage" ShowDeleteButton="true" ShowEditButton="True"   >
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:CommandField>                 
               </Columns>                             <HeaderStyle  BackColor="teal" ForeColor="white"/>
           </asp:GridView>              
           </div>
            </div>
         </div>
         
   </div>
</asp:Content>
