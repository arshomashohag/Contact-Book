<%@ Page Title="" Language="C#" MasterPageFile="~/Demo.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Demo_Application.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header justify-content-center">
                        <h3>Signup</h3>
                    </div>
                    <div class="card-body">

                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                First name
                            </div>

                            <div class="col-sm-9">
                                <asp:TextBox ID="SignupFirstNameBox" type="text" CssClass="form-control" placeholder="First name" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                Last name
                            </div>

                            <div class="col-sm-9">
                                <asp:TextBox ID="SignupLastName" type="text" CssClass="form-control" placeholder="Last name" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         

                         
                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                Email
                            </div>

                            <div class="col-sm-9">
                                <asp:TextBox ID="SignupEmailBox" type="email" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                Password
                            </div>

                            <div class="col-sm-9">
                                <asp:TextBox ID="SignupPasswordBox" type="password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                Confirm
                            </div>

                            <div class="col-sm-9">
                                <asp:TextBox ID="SignupConfirmPassword" type="password" CssClass="form-control" placeholder="Confirm password" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-form-label col-sm-3 text-right">
                                 
                            </div>

                            <div class="col-sm-9"> 
                                <asp:Button ID="SignupSubmitButon" type="submit"  runat="server" Text="Signup"  CssClass="btn form-control btn-la btn-success" OnClick="SignupSubmitButon_Click" />
                            </div>
                        </div>

                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
