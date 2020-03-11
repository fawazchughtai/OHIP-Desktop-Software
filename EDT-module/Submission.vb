Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Submission
    ' MSAccess
    ' Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
    'Private myCommand As New System.Data.OleDb.OleDbCommand
    'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
    'Private myData As DataSet = New DataSet
    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter

    Private myCommand As New MySqlCommand
    Private myAdapter As MySqlDataAdapter
    Private myData As DataSet = New DataSet
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objDataAdapter As MySqlDataAdapter


    Private Sub Submission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim objCreateOHIPFile As New CreateOHIPFile
            objCreateOHIPFile.CreateDataViewHeaders()
            objCreateOHIPFile.CreateUnsubmitedServiceList()
            objCreateOHIPFile.CreateSubmitedServiceList()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UnSubmitedDataGridView_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles UnSubmitedDataGridView.CellClick
        Try
            Dim objCreateOHIPFile As New CreateOHIPFile
            Dim filename As String
            If e.ColumnIndex = 4 Then



                If OOFSL_main.unlock_app = True Then

                    objCreateOHIPFile.Month = sender.Rows(e.RowIndex).Cells("month").Value
                    objCreateOHIPFile.Year = sender.Rows(e.RowIndex).Cells("year").Value

                    ProgressBar1.Visible = True
                    ProgressBar1.Style = ProgressBarStyle.Marquee
                    filename = objCreateOHIPFile.CreateFile()
                    ProgressBar1.Visible = False

                    MessageBox.Show(filename & " has been created ", "Submission File",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information,
                                       MessageBoxDefaultButton.Button1)
                    'MsgBox(filename & " has been created ")

                End If
            Else

                TransactionHistory.TabControl1.SelectedTab = TransactionHistory.TabPage2
                TransactionHistory.patient_id.Text = ""
                TransactionHistory.Date_frm_open.Value = "1-jan-2010"
                TransactionHistory.Date_to_open.Value = Today()
                TransactionHistory.Visible = True
                TransactionHistory.MdiParent = OOFSL_main
                TransactionHistory.ShowDialog()




            End If
            Application.DoEvents()
            Claim_management.Refresh_tree()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close.Click
        Me.Hide()
    End Sub

    Private Sub SubmitedDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SubmitedDataGridView.CellClick
        Try

            If e.ColumnIndex < 4 Then
                TransactionHistory.TabControl1.SelectedTab = TransactionHistory.TabPage1
                TransactionHistory.patient_id.Text = ""
                TransactionHistory.Filename_txt.Text = sender.Rows(e.RowIndex).Cells("filename").Value
                TransactionHistory.refresh_sub_grid()
                TransactionHistory.Visible = True
                TransactionHistory.MdiParent = OOFSL_main
                TransactionHistory.ShowDialog()
            ElseIf e.ColumnIndex = 4 Then
                'send2moh(sender.Rows(e.RowIndex).Cells("filename").Value)
                unsubmit_claim(sender.Rows(e.RowIndex).Cells("filename").Value)

            ElseIf e.ColumnIndex = 5 Then
                send2moh(sender.Rows(e.RowIndex).Cells("filename").Value)
            End If

            Claim_management.Refresh_tree()

        Catch ex As Exception

        End Try
    End Sub




    Private Sub send2moh(ByVal pfile As String)
        Try



            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)

            Dim myCommand As New MySqlCommand
            Dim objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)

            Dim sql As String


            sql = ""

            sql = sql + " UPDATE processed_service_record SET processed_service_record.status=2"
            sql = sql + " where processed_service_record.status=1 and processed_service_record.processed_file='" & pfile & "'"


            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            sql = ""

            sql = sql + " UPDATE claims SET claims.status=2"
            sql = sql + " where claims.status=1 and claims.filename='" & pfile & "'"


            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            Dim objCreateOHIPFile As New CreateOHIPFile

            objCreateOHIPFile.CreateUnsubmitedServiceList()
            objCreateOHIPFile.CreateSubmitedServiceList()


        Catch ex As Exception
            MsgBox("Error in File Send module Error 1")
        End Try

    End Sub
    Private Sub unsubmit_claim(ByVal pfile As String)
        Try

            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)

            Dim myCommand As New MySqlCommand
            Dim objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)

            Dim sql As String


            sql = ""

            sql = sql + " UPDATE processed_service_record SET processed_service_record.status=0"
            sql = sql + " where processed_service_record.processed_file='" & pfile & "'"
            sql = sql + " and status<6"



            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            sql = ""

            sql = sql + " UPDATE claims SET claims.status=0"
            sql = sql + " where filename='" & pfile & "'"
            sql = sql + " and status<6"



            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()


            Dim objCreateOHIPFile As New CreateOHIPFile

            objCreateOHIPFile.CreateUnsubmitedServiceList()
            objCreateOHIPFile.CreateSubmitedServiceList()


        Catch ex As Exception
            MsgBox("Error in File Send module Error 1")
        End Try

    End Sub


End Class