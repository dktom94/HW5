<%@ Page Language="VB" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    Dane's Mortgage Calculator
        
        <br /><br />
     
        Loan Amount:<asp:TextBox ID="tbLoanAmt" runat="server" ></asp:TextBox>
            
         <span class="errorMessage">
                <asp:RequiredFieldValidator ID="tbLoanAmntVal" runat="server"
                    ControlToValidate="tbLoanAmt"
                    ErrorMessage="** Please enter a number."
                    ValidationExpression="^\d+(\.\d\d)?$">
                </asp:RequiredFieldValidator>
            </span>
      
        <br /><br />      
        
        Annual Interest %: <asp:TextBox ID="tbAnnualInterest" runat="server" ></asp:TextBox>

         <span class="errorMessage">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="tbAnnualInterest"
                    ErrorMessage="** Please enter a number."
                    ValidationExpression="^\d+(\.\d\d)?$">
                </asp:RequiredFieldValidator>
            </span>
        
        <br /><br />

        Loan Term (Yrs): <asp:TextBox ID="tbLoanTerm" runat="server" ></asp:TextBox>

         <span class="errorMessage">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="tbLoanTerm"
                    ErrorMessage="** Please enter a number."
                    ValidationExpression="^\d+(\.\d\d)?$">
                </asp:RequiredFieldValidator>
            </span>
        
        <br /><br />

        <asp:Button ID="btnCalcPmt" runat="server" Text="Calculate" />
        
        &nbsp;<asp:Button ID="clearButton" runat="server" Text="Clear" Width="75px" />
        
        <br /><br />

        <% If Not IsPostBack Then%>

        <p> Welcome to the webpage </p>

        <%Else%>
                
        Monthly Payment: &nbsp; <asp:Label ID="lblMonthlyPmt" runat="server"></asp:Label>
        
        <br /><br />
        
        <asp:GridView ID="loanGridView" runat="server"  CssClass = "cssgridview"> 
            <AlternatingRowStyle CssClass ="alt" />
        </asp:GridView>

         <% End If%>   

        </div>
    </form>
</body>
</html>
