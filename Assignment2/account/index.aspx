<%@ Page Title="Account Information" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Assignment2.account.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Account Info</h1>
    <asp:Label ID="lblUsername" runat="server"></asp:Label>
    <div class="row">
        <div class="col-md-6">
            Name: 
        </div>
        <div class="col-md-6 pull-right">
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            Budget: 
        </div>
        <div class="col-md-6 pull-right">
            <asp:Label ID="lblBudget" runat="server"></asp:Label>
        </div>
    </div>
    <asp:Button ID="btnEdit" runat="server" Text="Edit Account Information" CssClass="btn btn-primary"
             OnClick="btnEdit_Click" />
</asp:Content>
