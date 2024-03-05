<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendance.aspx.cs" Inherits="schoolmenagementsystem.EmployeeAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center> <%--<div style="background-image:url('../Image/image1.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed; ">--%>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>

        </div>
         <div>  
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="10000"></asp:Timer>
                     <asp:Label ID="lbltimer" runat="server" Font-Bold="true"></asp:Label>
                 </ContentTemplate>
             </asp:UpdatePanel>
         </div>
        <h3 class="text-center ">teachers Attendance </h3>
                
                 ~ 
                   <div class="row mb-3 mr-lg-5 ml-lg-5 ">   
                    <div class="col-md-12">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" >
                            <Columns>                              
                                <asp:TemplateField HeaderText="Attendance">                   
                       <ItemTemplate>
                           <div class="form-check form-check-inline">
                               <asp:RadioButton ID="RadioButton1" runat="server" text="Present" Checked="true" GroupName="attendance" CssClass="form-check-input" />
                           </div>
                           <div class="form-check form-check-inline">
                               <asp:RadioButton ID="RadioButton2" runat="server" text="absent"  GroupName="attendance" CssClass="form-check-input" />
                           </div>
                       </ItemTemplate>
                   </asp:TemplateField>
                              <%--  <asp:CommandField ShowEditButton="True" HeaderText="manage"></asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>--%>
                            </Columns>
                            <HeaderStyle  BackColor="teal" ForeColor="white"/>
                        </asp:GridView>
                    </div>
                </div>
       </center>
                <center><div class="row mb-3 mr-lg-5 ml-lg-5 ">    
                    <div class="col-md-6 col-md-offset-2 col-lg-4 col-xl-3 mb-3">
                        <asp:Button ID="btnattendance" runat="server" Text="ATTENDANCE" CssClass="btn btn-primary btn-block " BackColor="#5558C9" OnClick="btnattendance_Click" />

                    </div>
                </div>
                    </center> 
</asp:Content>
