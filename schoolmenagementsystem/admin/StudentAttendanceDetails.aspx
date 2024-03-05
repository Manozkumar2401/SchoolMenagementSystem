<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="StudentAttendanceDetails.aspx.cs" Inherits="schoolmenagementsystem.admin.StudentAttendanceDetails" %>

<%@ Register Src="~/StudentAttendancedetailuc.ascx" TagPrefix="uc1" TagName="StudentAttendancedetailuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center> <%--<div style="background-image:url('../Image/image1.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed; ">--%>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>

        </div>
        
        <h3 class="text-center ">Student Attendance </h3>      
        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <asp:Label ID="ddlclass" runat="server" Text="Label"> Class</asp:Label>
                <asp:DropDownList ID="ddlclass1" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlclass1_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlclass1" Display="Dynamic" ForeColor="Red" InitialValue="seclect class" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="ddlsubject" runat="server" Text="Label">Teacher</asp:Label>
                <asp:DropDownList ID="ddlsubject1" runat="server" CssClass="form-control" ></asp:DropDownList>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlsubject1" Display="Dynamic" ForeColor="Red" InitialValue="seclect subject" SetFocusOnError="True"></asp:RequiredFieldValidator>   --%>
            </div>        
        </div>  
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <asp:Label ID="txtroll" runat="server" Text="Label"> Class</asp:Label>
                <asp:TextBox ID="txtroll1" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Roll no" ControlToValidate="txtroll1" Display="Dynamic" ForeColor="Red" InitialValue="seclect class" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtmonth" runat="server" Text="Label">Teacher</asp:Label>
                <asp:TextBox ID="txtmonth1" runat="server" CssClass="form-control" TextMode="Month" ></asp:TextBox>

            </div>        
        </div>  

        <div class="row mb-3 mr-lg-5 ml-lg-5 ">   
                    <div class="col-md-6 col-md-offset-2 col-lg-4 col-xl-3 mb-3">
                        <asp:Button ID="btnattendance" runat="server" Text="Submit" CssClass="btn btn-primary btn-block " BackColor="#5558C9" OnClick="btnattendance_Click"/>

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
                   <asp:BoundField DataField="student_name" HeaderText="Student Name" ReadOnly="True">
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
</asp:Content>
