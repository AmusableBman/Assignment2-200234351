<%@ Page Title="Budget Tracker" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Assignment2.budget.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Budget Tracker</h1>
    <asp:Button ID="btnExpense" runat="server" Text="Add New Expense" CssClass="btn btn-primary"
             OnClick="btnExpense_Click" />
    <div class="row">
        <div class="col-md-6">
            <h3>Budget: </h3>
        </div>
        <div class="col-md-6 pull-right">
            <h3 class="pullitright"><asp:Label ID="lblBudgetStart" runat="server"></asp:Label></h3>
        </div>
    </div>

    <asp:GridView ID="grdExpenses" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
        DataKeyNames="ID" OnRowDeleting="grdExpenses_RowDeleting" AllowSorting="true" OnRowDataBound="grdExpenses_RowDataBound" OnSorting="grdExpenses_Sorting">
        <Columns>
            <asp:BoundField Datafield="Name" HeaderText="Name" SortExpression="Name"/>
            <asp:BoundField Datafield="Description" HeaderText="Description"/>
            <asp:BoundField Datafield="Cost" HeaderText="Cost" DataFormatString="{0:c}" SortExpression="Cost"/>
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/expense.aspx" 
                DataNavigateUrlFields="ID" DataNavigateUrlFormatString="expense.aspx?ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>

    <div class="row">
        <div class="col-md-6">
            Budget: 
        </div>
        <div class="col-md-6 pull-right">
            <asp:Label ID="lblBudgetMid" runat="server" class="pullitright"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            Expenses Total: 
        </div>
        <div class="col-md-6 pull-right">
            <asp:Label ID="lblExpenses" runat="server" class="pullitright"></asp:Label>
        </div>
    </div>
    <div class="well" runat="server" id="budgetFinal">
        <div class="row">
            <div class="col-md-6">
               <h3>Final Budget: </h3>
            </div>
            <div class="col-md-6 pull-right">
                <h3 class="pullitright"><asp:Label ID="lblFinal" runat="server"></asp:Label></h3>
            </div>
        </div>
    </div>
    

</asp:Content>
