Imports System.IO
Imports System.Drawing
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
'Imports System.Data.OleDb
Public Class MOHMessages
    'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
    'Private myCommand As New System.Data.OleDb.OleDbCommand
    'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
    'Private myData As DataSet = New DataSet
    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objConn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter

    Private myCommand As New MySqlCommand
    Private myAdapter As MySqlDataAdapter
    Private myData As DataSet = New DataSet
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objConn2 As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objDataAdapter As MySqlDataAdapter
    Private Sub Reconciliation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()

        

        MessageDataGrid.Columns.Add("filename", "Reconciliation File")
        MessageDataGrid.Columns("filename").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        MessageDataGrid.Columns.Add("PaymentDate", "Payment Date")

        MessageDataGrid.Columns.Add("payamt", "Total Amount Payable")

        MessageDataGrid.RowHeadersVisible = False
        MessageDataGrid.Rows.Clear()
        MessageDataGrid.ReadOnly = True
        MessageDataGrid.AllowUserToAddRows = False
        MessageDataGrid.BackgroundColor = Color.LightGray
        MessageDataGrid.BorderStyle = BorderStyle.Fixed3D
        MessageDataGrid.AllowUserToAddRows = False
        MessageDataGrid.AllowUserToDeleteRows = False
        MessageDataGrid.AllowUserToOrderColumns = True
        MessageDataGrid.ReadOnly = True
        MessageDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MessageDataGrid.MultiSelect = False
        MessageDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        MessageDataGrid.AllowUserToResizeColumns = False
        MessageDataGrid.AllowUserToResizeRows = False
        MessageDataGrid.DefaultCellStyle.SelectionBackColor = Color.White
        MessageDataGrid.DefaultCellStyle.SelectionForeColor = Color.Black
        MessageDataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty


        Dim sql As String
        Dim objDataset As New DataSet


        objConn.Open()
        'sql = "select Distinct FileName,Format(ImportDate,'mm/dd/yyyy') as ProcessDate from reconciliationmessagefacility"
        sql = ""

        sql = "select distinct FileName, PaymentDate, CDbl(Left(reconciliationheaderrecord.TotalAmountPpayable,7)+'.'+Right(reconciliationheaderrecord.TotalAmountPpayable,2)) AS payamt from reconciliationheaderrecord order by paymentdate desc"


        'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
        objDataAdapter = New MySqlDataAdapter(sql, objConn)
        objDataAdapter.Fill(objDataset, "tblmessage")

        Dim i As Integer
        For i = 0 To objDataset.Tables("tblmessage").Rows.Count - 1
            MessageDataGrid.Rows.Add()
            MessageDataGrid.Rows(i).Cells("filename").Value = objDataset.Tables("tblmessage").Rows(i).Item("FileName")
            MessageDataGrid.Rows(i).Cells("PaymentDate").Value = objDataset.Tables("tblmessage").Rows(i).Item("PaymentDate")
            MessageDataGrid.Rows(i).Cells("payamt").Value = FormatCurrency(objDataset.Tables("tblmessage").Rows(i).Item("payamt"), 2)
        Next
        Dim btn As New DataGridViewButtonColumn()
        btn.HeaderText = ""
        btn.Text = "View Message"
        btn.Name = "Viewbtn"
        btn.UseColumnTextForButtonValue = True



        If MessageDataGrid.ColumnCount = 3 Then
            MessageDataGrid.Columns.Add(btn)
        End If

        Dim btn2 As New DataGridViewButtonColumn()
        btn2.HeaderText = ""
        btn2.Text = "Report"
        btn2.Name = "Rpt_btn"
        btn2.UseColumnTextForButtonValue = True
        If MessageDataGrid.ColumnCount = 4 Then
            MessageDataGrid.Columns.Add(btn2)
        End If

        MessageDataGrid.ReadOnly = True
        MessageDataGrid.AllowUserToAddRows = False

        objConn.Close()

    End Sub
    Private Sub MessageDataGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MessageDataGrid.CellClick
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Try


            If e.ColumnIndex = 3 Then

                Dim sql As String

                Dim filename As String


                If e.RowIndex <> -1 Then
                    filename = sender.Rows(e.RowIndex).Cells("filename").Value


                    sql = "select MessageText as message from reconciliationmessagefacility where FileName = '" & filename & "' order by ID"
                    TransactionHistory.print_reports(sql, 4)

                End If

            ElseIf e.ColumnIndex = 4 Then

                Dim filename As String
                Dim sql As String
                sql = ""
                filename = sender.Rows(e.RowIndex).Cells("filename").Value
                'detailed report rpt 2
                sql = "SELECT distinct patients.lname, patients.fname, reconciliationclaimheader.HealthRegistrationNumber as ohip, reconciliationclaimheader.VersionCode as ver, reconciliationclaimitem.ServiceDate AS service_date, reconciliationclaimitem.NumberOfServices AS num_serv, reconciliationclaimitem.ServiceCode AS service_code, CDbl(reconciliationclaimitem.AmountSubmitted) AS expr1, CDbl(reconciliationclaimitem.AmountPaid) AS amt_paid, reconciliationclaimitem.ExplanatoryCode AS err, reconciliationclaimitem.ClaimNumber as claim_num"

                sql = sql + " FROM (reconciliationclaimheader INNER JOIN reconciliationclaimitem ON reconciliationclaimheader.ClaimNumber = reconciliationclaimitem.ClaimNumber) left JOIN patients ON reconciliationclaimheader.HealthRegistrationNumber = patients.ohip"
                sql = sql + " where ReconciliationClaimHeader.FileName = '" & filename & "'"
                sql = sql + " ORDER BY reconciliationclaimitem.ServiceDate asc"

                process_reconciliation(filename)


                TransactionHistory.print_reports(sql, 2)






            End If
        Catch ex As Exception
        Finally
            ProgressBar1.Visible = False
        End Try
    End Sub


    Private Sub Closebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Closebtn.Click
        Me.Close()
    End Sub

    ' processes the reconciliation 
    Public Sub process_reconciliation(Filename As String)

        Try


            Dim sql2 As String = ""
            Dim sql As String = ""

            Dim mydata1 As New DataSet

            'sql to tie reconcilliation
            sql2 = "SELECT distinct processed_service_record.id as p_id,cdbl('0' & reconciliationclaimitem.AmountPaid) as amt_paid, reconciliationclaimitem.ExplanatoryCode as error, reconciliationclaimitem.claimnumber as claim_num"
            sql2 = sql2 + " FROM reconciliationheaderrecord, ReconciliationClaimHeader, ReconciliationClaimItem, processed_service_record, patients"
            sql2 = sql2 + " WHERE ReconciliationClaimHeader.ClaimNumber = [ReconciliationClaimItem].[ClaimNumber]"
            sql2 = sql2 + " and patients.id=processed_service_record.patient_id"
            sql2 = sql2 + " and processed_service_record.service_date=cdate(Left([reconciliationclaimitem.ServiceDate],4) & ' / ' & Mid([reconciliationclaimitem.ServiceDate],5,2) & ' / ' & Right([reconciliationclaimitem.ServiceDate],2) )"
            sql2 = sql2 + " and processed_service_record.service_code = ReconciliationClaimItem.ServiceCode"
            sql2 = sql2 + " and patients.ohip = ReconciliationClaimHeader.HealthRegistrationNumber"
            'sql2 = sql2 + " and patients.Version = ReconciliationClaimHeader.VersionCode"
            sql2 = sql2 + " and ReconciliationClaimItem.filename = '" & Filename & "'"
            sql2 = sql2 + " and ReconciliationClaimItem.filename = ReconciliationClaimHeader.FileName"
            sql2 = sql2 + " and reconciliationheaderrecord.filename=ReconciliationClaimHeader.FileName"
            sql2 = sql2 + " and reconciliationheaderrecord.Status is null"
            'sql2 = sql2 + " and processed_service_record.Status in (1,2)"


            objConn.Open()
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql2, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(mydata1, "tblrecon")


            For Each R1 As DataRow In mydata1.Tables("tblrecon").Rows

                'if explanatorycode="" and amt_paid>0 then paid Reconciled (Status=3)

                'SQL to update processed record - Paid R1("error").ToString <> "" Or

                If R1("error").ToString = "35" Or R1("amt_paid").ToString > 0 Then
                    sql = "UPDATE processed_service_record SET Status = 3, AmountPaid='" & R1("amt_paid").ToString & "', ExplanatoryCode='" & R1("error").ToString & "',claim_num='" & R1("claim_num").ToString & "'"
                    sql = sql + " where processed_service_record.id=" & R1("p_id").ToString
                Else
                    sql = "UPDATE processed_service_record SET Status = 4, AmountPaid='" & R1("amt_paid").ToString & "', ExplanatoryCode='" & R1("error").ToString & "',claim_num='" & R1("claim_num").ToString & "'"
                    sql = sql + " where processed_service_record.id=" & R1("p_id").ToString

                End If

                ''If R1("amt_paid").ToString > 0 Then
                ''    sql = "UPDATE processed_service_record SET Status = 3, AmountPaid='" & R1("amt_paid").ToString & "', ExplanatoryCode='" & R1("error").ToString & "',claim_num='" & R1("claim_num").ToString & "'"
                ''    sql = sql + " where processed_service_record.id=" & R1("p_id").ToString
                ''Else
                ''    sql = "UPDATE processed_service_record SET Status = 4, AmountPaid='" & R1("amt_paid").ToString & "', ExplanatoryCode='" & R1("error").ToString & "',claim_num='" & R1("claim_num").ToString & "'"
                ''    sql = sql + " where processed_service_record.id=" & R1("p_id").ToString

                ''End If

                'else possible error Error (Status=4)



                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
                myCommand = New MySqlCommand(sql, objConn)
                objConn2.Open()
                myCommand.ExecuteNonQuery()
                objConn2.Close()
                ' update processed_Record status with error(3)

            Next

            'header update
            sql = "UPDATE reconciliationheaderrecord SET Status = 1"
            sql = sql + " where reconciliationheaderrecord.filename='" & Filename & "'"

            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand = New MySqlCommand(sql, objConn)
            objConn2.Open()
            myCommand.ExecuteNonQuery()
            objConn2.Close()

            objConn.Close()
            Claim_management.Refresh_tree()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    
End Class