  <%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addclass.aspx.cs" Inherits="schoolmenagementsystem.admin.addclass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <center> 
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>

        </div>
         <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
                     <asp:Label ID="lbltimer" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                 </ContentTemplate>
             </asp:UpdatePanel>
         </div>
        <h3 class="text-center ">Add Class</h3>
                <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">   
                    <div class="col-md-6">
                        <asp:Label ID="txtclass" runat="server" Text="Label"> Class Name</asp:Label>
                        <asp:TextBox ID="txtclass1" cssclass="form-control" runat="server" placeholder=" Enter ClassName" ></asp:TextBox>

                    </div>
                </div>
                 <div class="row mb-3 mr-lg-5 ml-lg-5 ">   
                    <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server" Text="Add Class" BackColor="#5558C9"  CssClass="btn btn-primary btn-block" OnClick="Button1_Click"/>

                    </div>         
                </div>
                   <div class="row mb-3 mr-lg-5 ml-lg-5 ">   
                    <div class="col-md-6">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover"  AutoGenerateColumns="false" Width="100%" OnRowDeleting="GridView2_RowDeleting" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating"  >
                            <Columns >
                <asp:TemplateField>
                    <HeaderTemplate>
                       <table class="table " Width="100%">
                      <tr>
                     
                          <td>CLASSID</td>
                          <td>CLASSNAME</td>
                      </tr>
                    </table>
                    </HeaderTemplate>
                   <%--  <HeaderStyle  BackColor="teal" ForeColor="white"/>--%>
                     <ItemTemplate>
                       <table class="table table-hover;" Width="100%"> 
                           <tr>
                               <td>
                                   <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("class_id") %>'></asp:Literal>
                  
                                                           <td><%#Eval("class_name") %></td>
                               <td> <asp:Button ID="Button1" runat="server" Text="delete"  CommandName="Delete" />
                                   <asp:Button ID="Button2" runat="server" CommandName="Edit" Text="Edit" />
                               </td>
                           
                             
                           </tr>
                       </table>
                       
                   </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                     <EditItemTemplate>
                            <table  >
                                <tr>
                                    <td>
                                        <asp:Literal ID="Literal2" runat="server" Text='<%#Eval("class_id") %>'></asp:Literal>
                                    </td>                                                                       
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("class_name") %>' CssClass="form-control"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:Button ID="Button3" runat="server" CommandName="Update" Text="Update" />
                                        <asp:Button ID="Button4" runat="server" CommandName="Cancel" Text="Cancel" />
                                    </td>
                                </tr>

                            </table>
                        </EditItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
                            <HeaderStyle  BackColor="teal" ForeColor="white"/>
                        </asp:GridView>
                    </div>
                </div>
    
</asp:Content>
