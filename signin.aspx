<%@ Page Title="" Language="C#" MasterPageFile="~/Demo.Master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="Demo_Application.signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header justify-content-center">
                        <h3>Login</h3>
                    </div>
                    <div class="card-body">
                         
                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                Email
                            </div>

                            <div class="col-sm-9">
                                <asp:TextBox ID="EmailBox" type="text" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                Password
                            </div>

                            <div class="col-sm-9">
                                <asp:TextBox ID="PasswordBox" type="password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                 
                            </div>

                            <div class="col-sm-9"> 
                                <asp:Button ID="SubmitButon" type="submit"  runat="server" Text="Login"  CssClass="btn form-control btn-la btn-success" OnClick="SubmitButon_Click"/>
                            </div>
                        </div>

                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
