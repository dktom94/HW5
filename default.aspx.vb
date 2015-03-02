'Be sure to import system.data so you can create datatables on the fly.
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    'Adapted from the loan calculator found at www.dreamincode.net/forums/topic/237228-looping-issues-using-a-grid-for-mortgage-calculator-amortization/
    Protected Sub btnCalcPmt_Click(sender As Object, e As EventArgs) Handles btnCalcPmt.Click
        Dim loanAmount As Double
        Dim annualRate As Double
        Dim interestRate As Double
        Dim term As Integer
        Dim loanTerm As Integer
        Dim monthlyPayment As Double

        'This section is declaring the variables for loan amortization.
        Dim interestPaid As Double
        Dim nBalance As Double
        Dim principal As Double

        'Declaring a table to hold the payment information.
        Dim table As DataTable = New DataTable("ParentTable")
        Dim loanAmortTbl As DataTable = New DataTable("AmortizationTable")
        Dim tRow As DataRow

        'This section adds default values to the variables.  
        interestPaid = 0.0

        'This section converts each input string to the appropriate variable assigned.


        loanAmount = CDbl(tbLoanAmt.Text)
        annualRate = CDbl(tbAnnualInterest.Text)
        term = CDbl(tbLoanTerm.Text)

        'This section formats the loan input to currency.
        tbLoanAmt.Text = FormatCurrency(loanAmount)

        'Converting the annual rate to a monthly rate by dividing by 100 * 12 (months in a year)
        interestRate = annualRate / (100 * 12)

        'Converting the years (term) into months (loan term) by multipling the years by 12.
        loanTerm = term * 12

        'Calculating the monthly payment using the converted interest rate and loan term.
        monthlyPayment = loanAmount * interestRate / (1 - Math.Pow((1 + interestRate), (-loanTerm)))

        'Displaying the monthly payment in the textbox and converts the variable to currency.
        lblMonthlyPmt.Text = FormatCurrency(monthlyPayment)


        'Adds items to list box, formats them for currency and adds pad spacing for each item.
        loanAmortTbl.Columns.Add("Payment Number", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("Principal Paid", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("Interest Paid", System.Type.GetType("System.String"))


        'This section uses the for loop to display the loan balance and interest paid over the term of the loan.
        Dim counterStart As Integer

        For counterStart = 1 To loanTerm

            'Performs calculations for amortization of loan.
            interestPaid = loanAmount * interestRate
            principal = monthlyPayment - interestPaid
            nBalance = loanAmount - principal
            loanAmount = nBalance

            'Writes the data to a new row in the gridview.
            tRow = loanAmortTbl.NewRow()
            tRow("Payment Number") = String.Format(counterStart)
            tRow("Principal Paid") = String.Format("{0:C}", principal) ' String.Format("{0:C},principal) formats the variable "prinicpal" as currency (C).
            tRow("Interest Paid") = String.Format("{0:C}", interestPaid)
            loanAmortTbl.Rows.Add(tRow)

            'Loops to next counterStart (Continues loop until counterStart requirements are met (loanTerm)).
        Next counterStart


        loanGridView.DataSource = loanAmortTbl
        loanGridView.DataBind()


    End Sub

End Class
