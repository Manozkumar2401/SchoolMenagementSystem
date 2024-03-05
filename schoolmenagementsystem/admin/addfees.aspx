<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addfees.aspx.cs" Inherits="schoolmenagementsystem.admin.addfees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    



  <div>
        <center>
            <div class=" container p-md-4 p-sm-4"> 
                <asp:Label ID="LBLmsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center ">New Fees </h3>
            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <asp:Label ID="ddlclass" runat="server" Text="Label">Add class </asp:Label>
                    <asp:DropDownList ID="ddlclass1" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="class is required" ControlToValidate="ddlclass1" Display="Dynamic" ForeColor="Red" InitialValue="seclect class" SetFocusOnError="True"  ></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="txtfeeamount" runat="server" Text="Label"> fees</asp:Label>
                    <asp:TextBox ID="txtfeeamount1" runat="server" CssClass="form-control" placeholder="Enterfeeamount" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3 mr-lg-5 ml-lg-5 ">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" Text="Addfees" BackColor="#5558C9" CssClass="btn btn-primary btn-block" OnClick="btnAdd_Click" />
                </div>
                <div class="row mb-3 mr-lg-5 ml-lg-5">
                    <div class="auto-style1; alert alert-success;">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="no recored found" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="4" DataKeyNames="fees_id">
                            <Columns>
                                <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" ReadOnly="True">
                                    <FooterStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="class_name" HeaderText="Class" ReadOnly="True">
                                    <FooterStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Fees(Aanual)">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("fee_amount") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("fee_amount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--                       <HeaderStyle Wrap="True" />--%>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField CausesValidation="false" HeaderText="Manage" ShowDeleteButton="True" ShowEditButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>

                            </Columns>
                            <HeaderStyle BackColor="teal" ForeColor="white" />






                        </asp:GridView>
                    </div>
                </div>
            </div>
    </div>




</asp:Content>
