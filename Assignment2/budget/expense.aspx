<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="expense.aspx.cs" Inherits="Assignment2.budget.expense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Budget Tracker</h1>
    <div class="form-group">
        <label for="txtName" class="col-md-3">Expense Title:</label>
        <asp:TextBox ID="txtName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtDescription" class="col-md-3">Description:</label>
        <asp:TextBox ID="txtDescription" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtCost" class="col-md-3">Cost:</label>
        <asp:TextBox ID="txtCost" runat="server" required="true" MaxLength="22" />
        <asp:RangeValidator runat="server" ControlToValidate="txtCost"
             CssClass="label label-danger" ErrorMessage="Expense cost must be a value between $0 and $1,000,000"
         MinimumValue="0" MaximumValue="1000000" Type="Currency" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnSave" runat="server" Text="Save Info" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>
