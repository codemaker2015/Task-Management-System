<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogInUI.aspx.cs" Inherits="UI_LogInUI" %>

<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- Main CSS-->
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <!-- Font-icon css-->
    <link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>Task Management System</title>
  </head>
  <body>
    <section class="material-half-bg">
      <div class="cover"></div>
    </section>
    <section class="login-content">
      <div class="logo">
        <h1>Task Management System</h1>
      </div>
      <div class="login-box">
        <form id="Form1" class="login-form" runat="server">
          <h3 class="login-head"><i class="fa fa-lg fa-fw fa-user"></i>SIGN IN</h3>
          <div class="form-group">
            <label class="control-label">EMPLOYEE ID</label>
            <asp:DropDownList ID="employeeIdDropDownList" runat="server" cssClass="form-control"> </asp:DropDownList>
          </div>
          <div class="form-group">
            <label class="control-label">PASSWORD</label>
			<asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="form-group">
            <div class="utility">
              <div class="animated-checkbox">
                <label>
                  <asp:CheckBox ID="CheckBox1" runat="server" /><span class="label-text">Stay Signed in</span>
                </label>
              </div>
              <p class="semibold-text mb-2"><a href="#" data-toggle="flip">Forgot Password ?</a></p>
            </div>
          </div>
          <div class="form-group btn-container">
			<asp:Button ID="logInButton" runat="server" OnClick="logInButton_Click" Text="SIGN IN" cssClass="btn btn-primary btn-block"/>
          </div>
        </form>
        <form class="forget-form">
          <h3 class="login-head"><i class="fa fa-lg fa-fw fa-lock"></i>Forgot Password ?</h3>
          <div class="form-group">
            <label class="control-label">EMAIL</label>
            <input class="form-control" type="text" placeholder="Email">
          </div>
          <div class="form-group btn-container">
            <button class="btn btn-primary btn-block"><i class="fa fa-unlock fa-lg fa-fw"></i>RESET</button>
          </div>
          <div class="form-group mt-3">
            <p class="semibold-text mb-0"><a href="#" data-toggle="flip"><i class="fa fa-angle-left fa-fw"></i> Back to Login</a></p>
          </div>
        </form>
      </div>
	  <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red" Width="247px"></asp:Label>
    </section>
    <!-- Essential javascripts for application to work-->
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
    <!-- The javascript plugin to display page loading on top-->
    <script src="js/plugins/pace.min.js"></script>
    <script type="text/javascript">
        // Login Page Flipbox control
        $('.login-content [data-toggle="flip"]').click(function () {
            $('.login-box').toggleClass('flipped');
            return false;
        });
    </script>
  </body>
</html>