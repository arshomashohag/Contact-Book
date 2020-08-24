<%@ Page Title="" Language="C#" MasterPageFile="~/Demo.Master" AutoEventWireup="true" CodeBehind="show-contacts.aspx.cs" Inherits="Demo_Application.show_contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="jumbotron">
            <h4>All contacts</h4>
            <asp:Table ID="ContactTable" CssClass="table table-secondary" runat="server">
                
                <asp:TableRow>
                    <asp:TableHeaderCell>
                        <asp:TableCell>Name</asp:TableCell>
                    </asp:TableHeaderCell>

                    <asp:TableHeaderCell>
                        <asp:TableCell>Phone</asp:TableCell>
                    </asp:TableHeaderCell>

                    <asp:TableHeaderCell>
                        <asp:TableCell>Email</asp:TableCell>
                    </asp:TableHeaderCell>

                    <asp:TableHeaderCell>
                        <asp:TableCell>Address</asp:TableCell>
                    </asp:TableHeaderCell>

                    <asp:TableHeaderCell>
                        <asp:TableCell>Actions</asp:TableCell>
                    </asp:TableHeaderCell>
                    
                    
                </asp:TableRow>

            </asp:Table>
        </div>
    </div>
</asp:Content>
