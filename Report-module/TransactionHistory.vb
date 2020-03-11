'Imports System.Data.OleDb

Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class TransactionHistory
    Public sql_current_sub As String
    Public sql_current_unsub As String
    Public objTransactionHistoryClass As New TransactionHistoryClass

    Private Sub TransactionHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        objTransactionHistoryClass.CreateDataViewHeaders()

        objTransactionHistoryClass.CreateDataViewHeaders2()

        refresh_open_grid()
        refresh_sub_grid()
        All_radio.Checked = True
        radio_search_date.Checked = True
    End Sub
    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()

    End Sub

    Public Sub print_reports(sql As String, r_type As Integer)
        Try
            Select Case r_type
                Case 1 'Payment Summary
                    Me.Cursor = Cursors.WaitCursor
                    Dim report1 As New summary_payments_rpt
                    With report1
                        .Orientation = dbAutoTrack.DataReports.PageOrientation.Portrait
                        .PaperKind = Printing.PaperKind.Letter
                        '.MarginBottom = 0.5
                        '.MarginLeft = 0.5
                        '.MarginRight = 0.5
                        '.MarginTop = 0.5

                    End With
                    

                    report1.DataSource = Me.GetDataSetDataSource(sql)
                    report1.Generate()
                    Dim viewer1 As New frmViewer
                    viewer1.PrintViewer1.Document = report1.Document
                    viewer1.ShowDialog()
                Case 2 ' Reconciliation
                    Me.Cursor = Cursors.WaitCursor
                    Dim report1 As New Reconciliation_rpt

                    With report1
                        .Orientation = dbAutoTrack.DataReports.PageOrientation.Landscape
                        .PaperKind = Printing.PaperKind.Letter
                        .PageSetting.Margins.MarginRight = 0
                        '.MarginBottom = 0.5
                        '.MarginLeft = 0.5
                        '.MarginRight = 0.5
                        '.MarginTop = 0.5
                    End With
                    report1.DataSource = Me.GetDataSetDataSource(sql)
                    report1.Generate()
                    Dim viewer1 As New frmViewer
                    viewer1.PrintViewer1.Document = report1.Document
                    viewer1.ShowDialog()
                Case 3 ' Open Claims
                    Me.Cursor = Cursors.WaitCursor
                    Dim report1 As New open_claims_rpt

                    With report1
                        .Orientation = dbAutoTrack.DataReports.PageOrientation.Landscape
                        .PaperKind = Printing.PaperKind.Letter
                        '.MarginBottom = 0.5
                        '.MarginLeft = 0.5
                        '.MarginRight = 0.5
                        '.MarginTop = 0.5
                    End With
                    report1.DataSource = Me.GetDataSetDataSource(sql)
                    report1.Generate()
                    Dim viewer1 As New frmViewer
                    viewer1.PrintViewer1.Document = report1.Document
                    viewer1.ShowDialog()

                Case 4 ' MOH Message
                    Me.Cursor = Cursors.WaitCursor
                    Dim report1 As New MOH_msg_Rpt

                    With report1
                        .Orientation = dbAutoTrack.DataReports.PageOrientation.Portrait
                        .PaperKind = Printing.PaperKind.Letter
                        '.MarginBottom = 0.5
                        '.MarginLeft = 0.5
                        '.MarginRight = 0.5
                        '.MarginTop = 0.5
                    End With
                    report1.DataSource = Me.GetDataSetDataSource(sql)
                    report1.Generate()
                    Dim viewer1 As New frmViewer
                    viewer1.PrintViewer1.Document = report1.Document
                    viewer1.ShowDialog()
                Case 5 ' Claim detail

                    Me.Cursor = Cursors.WaitCursor
                    Dim report1 As New Claim_detail_rpt

                    With report1
                        .Orientation = dbAutoTrack.DataReports.PageOrientation.Landscape
                        .PaperKind = Printing.PaperKind.Letter
                        '.MarginBottom = 0.5
                        '.MarginLeft = 0.5
                        '.MarginRight = 0.5
                        '.MarginTop = 0.5
                    End With
                    report1.DataSource = Me.GetDataSetDataSource(sql)
                    report1.Generate()
                    Dim viewer1 As New frmViewer
                    viewer1.PrintViewer1.Document = report1.Document
                    viewer1.ShowDialog()
                Case 6 ' Error Report
                    Me.Cursor = Cursors.WaitCursor
                    Dim report1 As New Error_rpt

                    With report1
                        .Orientation = dbAutoTrack.DataReports.PageOrientation.Landscape
                        .PaperKind = Printing.PaperKind.Letter
                        '.MarginBottom = 0.5
                        '.MarginLeft = 0.5
                        '.MarginRight = 0.5
                        '.MarginTop = 0.5
                    End With
                    report1.DataSource = Me.GetDataSetDataSource(sql)
                    report1.Generate()
                    Dim viewer1 As New frmViewer
                    viewer1.PrintViewer1.Document = report1.Document
                    viewer1.ShowDialog()

            End Select
           
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


 




 

    Private Function GetDataSetDataSource(sql As String) As DataSet
        Dim set1 As New DataSet
        'Dim adapter1 As OleDbDataAdapter = Me.InitializeDataAdapter(sql)
        Dim adapter1 As MySqlDataAdapter = Me.InitializeDataAdapter(sql)
        adapter1.Fill(set1)
        adapter1.Dispose()
        Return set1
    End Function

    Private Function GetDataTableDataSource(sql As String) As DataTable
        Dim table1 As New DataTable
        'Dim adapter1 As OleDbDataAdapter = Me.InitializeDataAdapter(sql)
        Dim adapter1 As MySqlDataAdapter = Me.InitializeDataAdapter(sql)
        adapter1.Fill(table1)
        adapter1.Dispose()
        Return table1
    End Function

    Private Function GetDataViewDataSource(sql As String) As DataView
        Dim table1 As DataTable = Me.GetDataTableDataSource(sql)
        Return table1.DefaultView
    End Function

    'Private Function InitializeDataAdapter(sql As String) As OleDbDataAdapter
    '    Dim adapter1 As New OleDbDataAdapter
    '    Dim connection1 As New OleDbConnection


    '    connection1.ConnectionString = OOFSL_main.sConnectionString

    '    Dim command1 As New OleDbCommand
    '    command1.Connection = connection1
    '    command1.CommandText = sql
    '    adapter1.SelectCommand = command1
    '    Return adapter1
    'End Function
    Private Function InitializeDataAdapter(sql As String) As MySqlDataAdapter
        Dim adapter1 As New MySqlDataAdapter
        Dim connection1 As New MySqlConnection


        connection1.ConnectionString = OOFSL_main.sConnectionString

        Dim command1 As New MySqlCommand
        command1.Connection = connection1
        command1.CommandText = sql
        adapter1.SelectCommand = command1
        Return adapter1
    End Function


    Private Sub pr_unsub_Click(sender As Object, e As EventArgs) Handles pr_unsub.Click
        print_reports(sql_current_unsub, 3)

    End Sub

    Private Sub pr_sub_Click(sender As Object, e As EventArgs) Handles pr_sub.Click
        print_reports(sql_current_sub, 5)
    End Sub

    Private Sub ServiceHistoryDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ServiceHistoryDataGrid.CellClick
        ' MsgBox(e.ColumnIndex.ToString & "=" & e.RowIndex.ToString)
        'If e.ColumnIndex = 11 Then
        '    'TransactionHistory.ServiceHistoryDataGrid.Co()
        '    ' TransactionHistory.ServiceHistoryDataGrid
        'End If

    End Sub




    Private Sub show_all_open_Click(sender As Object, e As EventArgs) Handles show_all_open.Click


        objTransactionHistoryClass.GetunSubmitedServiceHistory_all()

    End Sub

    Private Sub refresh_open_Click(sender As Object, e As EventArgs) Handles refresh_open.Click

        objTransactionHistoryClass.GetunSubmitedServiceHistory()

    End Sub


    Private Sub Show_all_Sub_Click(sender As Object, e As EventArgs) Handles Show_all_Sub.Click
        objTransactionHistoryClass.GetSubmitedServiceHistory_all()
    End Sub

    Private Sub Refresh_sub_Click(sender As Object, e As EventArgs) Handles Refresh_sub.Click
        objTransactionHistoryClass.GetSubmitedServiceHistory()
    End Sub

    Public Sub refresh_open_grid()
        objTransactionHistoryClass.GetunSubmitedServiceHistory()
    End Sub
    Public Sub refresh_sub_grid()
        objTransactionHistoryClass.GetSubmitedServiceHistory()
    End Sub

    Private Sub All_radio_CheckedChanged(sender As Object, e As EventArgs) Handles All_radio.CheckedChanged
        refresh_sub_grid()
    End Sub

    Private Sub Error_radio_CheckedChanged(sender As Object, e As EventArgs) Handles Error_radio.CheckedChanged
        refresh_sub_grid()
    End Sub

    Private Sub Unpaid_radio_CheckedChanged(sender As Object, e As EventArgs) Handles Unpaid_radio.CheckedChanged
        refresh_sub_grid()
    End Sub

    Private Sub Paid_Radio_CheckedChanged(sender As Object, e As EventArgs) Handles Paid_Radio.CheckedChanged
        refresh_sub_grid()
    End Sub


    Private Sub radio_search_date_CheckedChanged(sender As Object, e As EventArgs) Handles radio_search_date.CheckedChanged
        refresh_sub_grid()
    End Sub

    Private Sub Radio_search_sub_CheckedChanged(sender As Object, e As EventArgs) Handles Radio_search_sub.CheckedChanged
        refresh_sub_grid()
    End Sub

   
    Private Sub Select_claims_btn_Click(sender As Object, e As EventArgs) Handles Select_claims_btn.Click
        Select Case Select_claims_btn.Text
            Case "Select All"
                Me.ServiceHistoryDataGrid.SelectAll()
                Select_claims_btn.Text = "De-Select All"
            Case Else
                Me.ServiceHistoryDataGrid.ClearSelection()
                Select_claims_btn.Text = "Select All"
        End Select


    End Sub

    Private Sub resubmit_btn_Click(sender As Object, e As EventArgs) Handles resubmit_btn.Click
        Dim resub_answer As String
        Dim cl_count As Integer
        Dim i As Integer
        Dim selected_Data As New ArrayList


        cl_count = Me.ServiceHistoryDataGrid.SelectedRows.Count
        If cl_count > 0 Then
            resub_answer = MsgBox("You are selecting to Re-submit " & cl_count & " claim(s) highlight - this will make claims open and ready to make necessary corrections.  Do you want to continue?", vbYesNo)

            If resub_answer = vbYes Then
                For i = 0 To Me.ServiceHistoryDataGrid.SelectedRows.Count.ToString - 1

                    selected_Data.Add(Me.ServiceHistoryDataGrid.SelectedRows(i).Cells("id").Value)

                Next


                objTransactionHistoryClass.unsubmit_claims(selected_Data)
                Claim_management.Refresh_tree()
            Else

            End If
        End If


    End Sub

    Private Sub Archive_btn_Click(sender As Object, e As EventArgs) Handles Archive_btn.Click
        Dim resub_answer As String
        Dim cl_count As Integer
        Dim i As Integer
        Dim selected_Data As New ArrayList


        cl_count = Me.ServiceHistoryDataGrid.SelectedRows.Count
        If cl_count > 0 Then
            resub_answer = MsgBox("You are selecting to Archive " & cl_count & " claim(s) highlight.  Do you want to continue?", vbYesNo)

            If resub_answer = vbYes Then
                For i = 0 To Me.ServiceHistoryDataGrid.SelectedRows.Count.ToString - 1

                    selected_Data.Add(Me.ServiceHistoryDataGrid.SelectedRows(i).Cells("id").Value)

                Next


                objTransactionHistoryClass.archive_claims(selected_Data)
                Claim_management.Refresh_tree()
            Else

            End If
        End If


    End Sub

    
    Private Sub Open_cl_CheckedChanged(sender As Object, e As EventArgs) Handles Open_cl.CheckedChanged
        refresh_sub_grid()
    End Sub

    Private Sub archived_cl_CheckedChanged(sender As Object, e As EventArgs) Handles archived_cl.CheckedChanged
        refresh_sub_grid()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Total_units_v.Click

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles total_units_lbl.Click

    End Sub
End Class