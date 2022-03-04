<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Customer_Details.Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Enquiry</title>
   <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css"/>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css"/>
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css"/>
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
      <div class="login-box">
  <div class="login-logo">
   <a href="../../index2.html"><b>Customer Enquiry</a>
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg">Sign in to start your session</p>

    
        <div class="input-group mb-3">
          
             <asp:TextBox ID="txtemail" runat="server" placeholder="Username" Text="" style="text-transform:lowercase;"  CssClass="form-control" ></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          
          <asp:TextBox ID="txtpassword" runat="server"  TextMode="Password" placeholder="Password" Text="" CssClass="form-control" ></asp:TextBox>
            <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            
          </div>
          <!-- /.col -->
          <div class="col-4">
            
              <asp:Button ID="btnsubmit" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block"  OnClick="btnsubmit_Click"/>
          </div>
          <!-- /.col -->
        </div>
    

     
      <!-- /.social-auth-links -->
        <p class="mb-0">

           
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Size="14px" Text=""></asp:Label>
        </p>
    <%--  <p class="mb-1">
        <a href="Defaultforgetpwd.aspx">I forgot my password</a>
      </p>
      <p class="mb-0">
        <a href="register.aspx" class="text-center">Register a new membership</a>
      </p>--%>
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
    </form>
    <script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
</body>
</html>
