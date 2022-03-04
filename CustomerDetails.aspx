<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="Customer_Details.CustomerDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" >
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
           
        }
        function isBudget(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</asp:Content>
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
               Customer Enquiry Form - Add/Update Details
                     
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
                        <label class="knob-label">Full Name</label>
                       <asp:TextBox ID="txtname" runat="server" MaxLength="45" Text=""    CssClass="form-control"  style="text-transform:uppercase"></asp:TextBox>  
                      </div>
                         </div>
                     <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Phone </label>
                       <asp:TextBox ID="txtphone1" runat="server" Text=""  onkeypress="return isNumber(event)"  MaxLength="10" CssClass="form-control" ></asp:TextBox>  
                      </div>
                         </div>
                    
                     <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">EMAIL </label>
                       <asp:TextBox ID="txtmail" runat="server" MaxLength="45" Text="" CssClass="form-control" ></asp:TextBox>  
                      </div>
                         </div>
                     
                    
                     <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Date of birth </label>
                       <asp:TextBox ID="txtdob"   runat="server" TextMode="Date"  MaxLength="10"  CssClass="form-control"></asp:TextBox>  
                      </div>
                         </div>
                      

                    <div class="col-sm-6">
                      <!-- text input details -->
                      <div class="form-group">
                        <label class="knob-label"> Details </label>
                       <asp:TextBox ID="txtdetails" runat="server" TextMode="MultiLine" MaxLength="245" Text="" CssClass="form-control" style="text-transform:uppercase" ></asp:TextBox>  
                      </div>
                         </div>
                   
                   
                   <%-- <div class="col-sm-3">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Location </label>
                       <asp:TextBox ID="txtlocation" runat="server" MaxLength="45" Text="" style="text-transform:uppercase" CssClass="form-control" ></asp:TextBox>  
                      </div>
                         </div>--%>

                    <div class="col-sm-6">
                      <!-- text input -->
                      <div class="form-group">
                        <label class="knob-label">Address</label>
                       <asp:TextBox ID="txtaddress" runat="server" MaxLength="245" Text="" TextMode="MultiLine" style="text-transform:uppercase"  CssClass="form-control" ></asp:TextBox>  
                      </div>
                         </div>
                   
                   <div class="col-sm-2">
                      <!-- text input -->
                      <div class="form-group align-baseline">
                          
                         <asp:Button ID="btnadd" runat="server" Text="ADD" CssClass="btn btn-primary btn-block" OnClick="btnadd_Click"  />                  
                  </div>
                          </div>
                           <div class="col-sm-1">
                      <!-- text input -->
                      <div class="form-group align-baseline">
                          
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
                 View  Details
                </h3>
                   

                
              </div>
              <div class="card-body">
                  <div class="row">

                     <div class="col-sm-6">
                      <!-- text input -->
                     
                         </div>
                      
                     </div>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" onselctstart="return false;" 
                   AlternatingRowStyle-BackColor="WhiteSmoke"  OnRowDeleting="GridView1_RowDeleting" 
    OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" Width="100%" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered table-striped">

    <Columns>
         <asp:BoundField ItemStyle-Width="1%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"  DataField="id" HeaderText="Customer ID" />
       <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" DataField="fullname" HeaderText="Full Name" />
         <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" DataField="phone1" HeaderText="Phone No" />
       
        <asp:BoundField ItemStyle-Width="25%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" DataField="email" HeaderText="Email" />
        <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" DataFormatString = "{0:dd-MM-yyyy}"  DataField="dob" HeaderText="Date of birth" />

       
       <asp:TemplateField>
                    <ItemTemplate>

                        <asp:LinkButton ID="srcid" runat="server" Text='EDIT' CommandName="Select"  HeaderStyle-Width="45px"  commandargument='<%# Eval("id" )%>'  />
           
                      
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
