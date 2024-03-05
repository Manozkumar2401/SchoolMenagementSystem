<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="ExpenseDetails.aspx.cs" Inherits="schoolmenagementsystem.ExpenseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
<link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID%>').prepend($("<thead></thead> ").append($(this).find("tr:first"))).DataTable({ "paging":true,"ordering":true,"searching":true});
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div><center>
       <div class="container p-md-4 p-sm-4">  
        <h3 class="text-center ">ExpenseDetails</h3>
       
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="col-md-12">
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"  EmptyDataText="no recored found" AutoGenerateColumns="False"   >
               <Columns>
                   <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>    
                   <asp:BoundField DataField="class_name" HeaderText="class" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                    <asp:BoundField DataField="subject_name" HeaderText="subject" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                    <asp:BoundField DataField="amount" HeaderText="Charge amt(perlecture)">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>                                 
               </Columns>
              <HeaderStyle  BackColor="teal" ForeColor="white"/>
           </asp:GridView>
               
           </div>
            </div>
         </div>
   </div>
</asp:Content>
