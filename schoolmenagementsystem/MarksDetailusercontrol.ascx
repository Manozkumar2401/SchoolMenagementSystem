<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MarksDetailusercontrol.ascx.cs" Inherits="schoolmenagementsystem.WebUserControl1" %>
<div><center>
        <div class=" container p-md-4 p-sm-4">
     <asp:Label ID="LBLmsg" runat="server" ></asp:Label>     
        </div>
        <h3 class="text-center ">Marks Details</h3>
       <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">  
            <div class="col-md-6">
                <asp:Label ID="ddlclass" runat="server" Text="Label">Add class </asp:Label>
                <asp:DropDownList ID="ddlclass1" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlclass1" Display="Dynamic" ForeColor="Red" InitialValue="seclect class" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <asp:Label ID="txtroll" runat="server" Text="Label">STUDENT ROLL NO</asp:Label>
                <asp:TextBox ID="txtroll1" runat="server" CssClass="form-control" placeholder="Enter Roll No"  required="" ></asp:TextBox>
            </div>
        </div>
          <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server"  Text="Get Marks" BackColor="#5558C9"  CssClass="btn btn-primary btn-block" onclick="btnAdd_Click1" />
            </div> 
              </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5"  >
       <div class="col-md-12">
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"  EmptyDataText="no recored found" AutoGenerateColumns="False"  OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" PageSize="4" >
               <Columns>
                   <asp:BoundField DataField="Sr.no" HeaderText="Sr.No" >
                   <FooterStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                   
                   <asp:BoundField DataField="exam_id" HeaderText="Exam Id">
                   <FooterStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                  
                   
                   <asp:BoundField DataField="Roll_no" HeaderText="Roll No">
                   <FooterStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                  

                   <asp:BoundField DataField="class_name" HeaderText="Class">
                   <FooterStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                   
                   <asp:BoundField DataField="subject_name" HeaderText="Subject">
                   <FooterStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                   
                   <asp:BoundField DataField="class_name" HeaderText="Class">
                   <FooterStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                   
                   <asp:BoundField DataField="total_marks" HeaderText="Total Marks">
                   <FooterStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                  
                   <asp:BoundField DataField="outof_marks" HeaderText="Out of Marks">
                   <FooterStyle HorizontalAlign="Center" />
                   </asp:BoundField>
                  
                  
                  
                  
                   <asp:CommandField CausesValidation="false" HeaderText="Manage" ShowDeleteButton="True" ShowEditButton="True">
                   <ItemStyle HorizontalAlign="Center" />
                   </asp:CommandField>
                   
               </Columns>
                             <HeaderStyle  BackColor="teal" ForeColor="white"/>
           </asp:GridView>
           </div>
            </div>
             
   </div>