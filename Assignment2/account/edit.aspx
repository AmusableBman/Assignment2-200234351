<%@ Page Title="Edit Account" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Assignment2.account.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Edit Account Information</h1>

    <div class="form-group">
        <label for="txtAccountName" class="col-sm-3">Full Name:</label>
        <asp:TextBox ID="txtAccountName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtBudget" class="col-sm-3">Budget Allowance:</label>
        <asp:TextBox ID="txtBudget" runat="server" required="true" MaxLength="22" />
        <asp:RangeValidator runat="server" ControlToValidate="txtBudget"
             CssClass="label label-danger" ErrorMessage="Budget must be a value between $0 and $1,000,000"
         MinimumValue="0" MaximumValue="1000000" Type="Currency" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnSave" runat="server" Text="Save Info" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>
