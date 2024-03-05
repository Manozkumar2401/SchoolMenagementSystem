<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="EmpAttendanceDetails.aspx.cs" Inherits="schoolmenagementsystem.admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div><center>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>     

        </div>
        <h3 class="text-center "> Teacher Attendance details </h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <asp:Label ID="ddlteacher" runat="server" Text="Label">Teacher</asp:Label>
            <asp:DropDownList ID="ddlteacher1" runat="server" CssClass="form-control"  ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlteacher1" Display="Dynamic" ForeColor="Red" InitialValue="seclect subject" SetFocusOnError="True"></asp:RequiredFieldValidator>   
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtmonth" runat="server" Text="Label">Month</asp:Label>
<%--                <asp:TextBox ID="txtmonth1" runat="server" CssClass="form-control" TextMode="" required></asp:TextBox>--%>
                <asp:TextBox ID="txtmonth1" runat="server" CssClass="form-control" TextMode="Month"></asp:TextBox>
            </div>        
        </div>  
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
         
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btncheckattendance" runat="server"  Text="Attendance Details" BackColor="#50409A"  CssClass="btn btn-primary btn-block" OnClick="btncheckattendance_Click"  />
            </div> 
              </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="col-md-12">
          <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"  EmptyDataText="no recored found" AutoGenerateColumns="False"   >
               <Columns>
                   <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>    
                   <asp:BoundField DataField="teacher_name" HeaderText="name" ReadOnly="True">
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                    
                 <asp:TemplateField  HeaderText="status" >
                     <ItemTemplate>
                           <asp:Label runat="server" id="Label1" text='<%#Boolean.Parse( Eval("status").ToString()) ? "present": "Absent"%>'  >  </asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>                   
                   <asp:BoundField DataField="date"  HeaderText="Date" DataFormatString="{0:dd MMMM yyyy}" >
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                                 
               </Columns>
              <HeaderStyle  BackColor="teal" ForeColor="white"/>
           </asp:GridView>
           </div>
            </div>
        
    </div>

   
</asp:Content>
