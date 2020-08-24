<%@ Page Title="" Language="C#" MasterPageFile="~/Demo.Master" AutoEventWireup="true" CodeBehind="add-contact.aspx.cs" Inherits="Demo_Application.add_contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header justify-content-center">
                        <h3>Add new contact</h3>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="ErrorLabel" CssClass="required" runat="server" Text=""></asp:Label>
                        <div class="form-group">
                            <label for="first_name" class="label">First name</label>
                            <asp:TextBox name="first_name" ID="FirstNameTextBox" CssClass="form-control" placeholder="First name" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="last_name" class="label">Last name</label>
                            <asp:TextBox name="last_name" ID="LastNameTextBox" CssClass="form-control" placeholder="Last name" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="email" class="label">Email</label>
                            <asp:TextBox name="email" ID="EmailTextBox" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="phone" class="label">Phone number <span class="required">*</span></label>
                            <asp:TextBox name="phone" ID="PhoneNumberBox" CssClass="form-control" placeholder="+880 ----------" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="address" class="label">Address</label>
                            <textarea id="Address" name="address" rows="5" class="form-control" ></textarea>
                        </div>

                        <div class="form-group">
                            <asp:Button runat="server" Text="Add" ID="AddContactButton" CssClass="btn btn-lg btn-success form-control" OnClick="AddContactButton_Click" />
                        </div>
                        
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
