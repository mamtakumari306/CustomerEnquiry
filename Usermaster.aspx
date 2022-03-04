
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usermaster.aspx.cs" Inherits="Customer_Details.Usermaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</cc1:ToolkitScriptManager> 


    <section class="content">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" >
        <ContentTemplate>
      <div class="container-fluid">
           <div class="row">
                       <div class="col-md-12">

                  
             <div class="card card-primary">
            <asp:Panel ID="pHeader" runat="server" CssClass= "card-header">
               
                <h3 class="card-title">
                  <i class="far fa-chart-bar"></i>
                Add/Update usermaster
                     
                </h3>

               <div class="card-tools">
                       <asp:Label ID="lblText" runat="server" Text="" > <i class="fas fa-minus"></i></asp:Label>
                  
                </div>
              </asp:Panel>
              <!-- /.card-header -->
               <asp:Panel ID="pBody" runat="server" CssClass="card-body" >
           


           
              
              <div class="card-body">
                <div class="row">
                     <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Name</label>
                       <asp:TextBox ID="txtname" runat="server" MaxLength="45" Text="" CssClass="form-control" style="text-transform:uppercase" ></asp:TextBox>  
                      </div>
                         </div>
                     <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Login ID</label>
                       <asp:TextBox ID="txtuseremail" runat="server" MaxLength="45" Text="" CssClass="form-control" ></asp:TextBox>  
                      </div>
                         </div>
                 <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Password</label>
                       <asp:TextBox ID="txtpassword" runat="server" MaxLength="45" TextMode="Password" Text="" CssClass="form-control" ></asp:TextBox>  
                      </div>
                         </div>
                     <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Role</label>
                        <asp:DropDownList ID="ddllevel" runat="server" CssClass="form-control" >
                         
                               <asp:ListItem Value="L1">Sales Representative</asp:ListItem>
                              <asp:ListItem Value="L2">TeleMarketing Executive</asp:ListItem>
                              
                       </asp:DropDownList>   
                      </div>
                         </div>
                                    <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Is Active</label>
                         <asp:CheckBox ID="chkactive" Text="" runat="server" />
                      </div>
                         </div>
                     <div class="col-sm-6">
                      <!-- text input -->
                       <div class="form-group">
                        <label class="knob-label">Reason</label>
                       <asp:TextBox ID="txtreason" runat="server" MaxLength="245" Text="" CssClass="form-control" style="text-transform:uppercase" ></asp:TextBox>  
                      </div>
                         </div>
                   
                  <div class="col-sm-2">
                      <!-- text input -->
                      <div class="form-group align-baseline">
                          
                          <label class="knob-label">.</label>
                         <asp:Button ID="btnadd" runat="server" Text="ADD" CssClass="btn btn-primary btn-block" OnClick="btnadd_Click"  />
                    
                  
                  </div>


                          </div>
                           <div class="col-sm-1">
                      <!-- text input -->
                      <div class="form-group align-baseline">
                          
                          <label class="knob-label">.</label>
                         <asp:Button ID="btnclear" runat="server" Text="CLEAR" CssClass="btn btn-info btn-block" OnClick="btnclear_Click"  />
                    
                  
                  </div>


                          </div>
                
                  <!-- ./col -->
                </div>
                    
         
              </div>

                    <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Size="14px" Text=""></asp:Label>
             <asp:Label ID="lblbuildingid" runat="server" ForeColor="Red" Font-Size="14px" Text="" Visible="false"></asp:Label>


                   </asp:Panel>

                 
            <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pBody" CollapseControlID="pHeader" ExpandControlID="pHeader"
Collapsed="true" TextLabelID="lblText" CollapsedText="Click to Show.." ExpandedText="Click to Hide.."
> </cc1:CollapsiblePanelExtender>
                 </div>
              <!-- /.card-body -->

            
              


           
            
            <!-- /.card -->
          </div>

 
         <asp:LinkButton ID="srcid1" runat="server" Text="." Visible="true" />
           <cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server" 
    PopupControlID="pnlPopup" TargetControlID="srcid1" BackgroundCssClass="modalBackground" CancelControlID = "btnHide">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlPopup" runat="server" CssClass="modal-content bg-success card" Width="50%" >
    <div class="modal-title">
      <h4 class="modal-title">Success</h4>
    </div>
    <div class="modal-body">

        <asp:Label ID="lblsuccess" runat="server" ForeColor="Green" Font-Size="14px" Text=""></asp:Label>
       <div style="user-select:none;border:1px">
                   <asp:Button ID="btnHide" runat="server" Text="OK" CssClass="button" />

           </div>
    </div>
</asp:Panel> 


        


              
   
      
        
         </div>
           <div class="row">

          <div class="col-12">
            <!-- interactive chart -->
            <div class="card card-primary card-outline">
              <div class="card-header">
                <h3 class="card-title">
                  <i class="far fa-chart-bar"></i>
                 View Usermaster
                </h3>
                   

                
              </div>
              <div class="card-body">
                  <div class="row">

                     <div class="col-sm-6">
                      <!-- text input -->
                     
                         </div>
                      
                     </div>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" onselctstart="return false;" 
                   AlternatingRowStyle-BackColor="WhiteSmoke"  OnRowDeleting="gv1_RowDeleting" 
    OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" Width="100%" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered table-striped">

    <Columns>
         <asp:BoundField ItemStyle-Width="1%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center"  DataField="idusermaster" HeaderText="idusermaster" />
         <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" DataField="name" HeaderText="Name" />
       <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" DataField="username" HeaderText="LoginID" />
        
        <asp:BoundField ItemStyle-Width="25%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" DataField="role" HeaderText="Role" /> 
        <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" DataField="isactive" HeaderText="Isactive" />
       
   


       
        
       
       <asp:TemplateField>
                    <ItemTemplate>

                        <asp:LinkButton ID="srcid" runat="server" Text='EDIT' CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
           
                      
                    </ItemTemplate>


                </asp:TemplateField>
         
        
    </Columns>
</asp:GridView>
                <div id="interactive" style="height: 300px;"></div>
              </div>
              <!-- /.card-body-->
            </div>
            <!-- /.card -->

          </div>
          <!-- /.col -->
        </div>
      </div>
         <!-- /.card -->
      </ContentTemplate>
                 </asp:UpdatePanel>
      <!-- /.container-fluid -->
    </section>
</asp:Content>
