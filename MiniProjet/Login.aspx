<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.cs" Inherits="nouhailaMiniProjet.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container">
            <h2>Log In</h2>
            <hr />
            <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
                <p class="alert alert-danger">
                    <asp:Literal runat="server" ID="StatusText" />
                </p>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="LoginForm" Visible="False">
                <div class="mb-3">
                    <asp:Label runat="server" AssociatedControlID="UserName" CssClass="form-label">User name</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="form-label">Password</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3">
                    <div>
                        <asp:Button runat="server" OnClick="SignIn" Text="Log in" CssClass="btn btn-primary" />
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
                <div class="mb-3">
                    <div>
                        <asp:Button runat="server" OnClick="SignOut" Text="Log out" CssClass="btn btn-danger" />
                    </div>
                </div>
            </asp:PlaceHolder>
    </form>
</asp:Content>
