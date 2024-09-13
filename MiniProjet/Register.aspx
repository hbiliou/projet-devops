<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="nouhailaMiniProjet.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container">
        <div>
            <h2>Register</h2>
                        <hr />

            <div class="mb-3">
                <asp:Label ID="Label1" runat="server" Text="User Name:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="Label2" runat="server" Text="Password:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <div>
                    <asp:Button ID="Bt2" runat="server" OnClick="Bt2_Click" Text="Register" CssClass="btn btn-primary" />
                </div>
            </div>

            <asp:Label ID="Msg" runat="server"></asp:Label>
        </div>
    </form>
</asp:Content>
