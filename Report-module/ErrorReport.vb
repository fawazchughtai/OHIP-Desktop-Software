
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class ErrorReport
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
    Private Sub CloseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub ErrorReportDataGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ErrorReportDataGrid.CellClick
        Try
            If e.ColumnIndex = 2 Then
                Dim ErrorReportId As Integer
                ErrorReportId = sender.Rows(e.RowIndex).Cells("ID").Value()
                Dim sql As String

                sql = " SELECT distinct patients.lname, patients.fname, errorreporthxh.HealthNumber as ohip, errorreporthxh.versioncode as version,errorreporthxt.servicedate as service_date, errorreporthxt.ServiceCode as service_code, errorreporthxt.FeeSubmitted as service_fee, errorreporthxt.NumberOfServices as num_serv, errorreporthxt.ErrorCode1 & ' ' & errorreporthxh.errorcode1 as errorcode1, errorreporthxh.ReferringProviderNumber as ref, errorreporthxh.MasterNumber as inst,errorreporthxh.PatientAdmissionDate as adm_dt "
                sql = sql + " FROM ((errorreporthxh INNER JOIN errorreporthxt ON errorreporthxh.HeaderID = errorreporthxt.HeaderID) LEFT JOIN patients ON errorreporthxh.HealthNumber = patients.ohip) "
                'LEFT JOIN errorcodes ON errorreporthxt.ErrorCode1 = errorcodes.Code"
                sql = sql + "  WHERE errorreporthxt.ErrorReportID=" & ErrorReportId

                process_error(ErrorReportId)



                TransactionHistory.print_reports(sql, 6)


                'Dim objErrorReportViewer As New EDTFileClass.ReportViewerClass
                'objErrorReportViewer.ReportViewer(ErrorReportId)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub process_error(Report_id As Integer)

        Try


            Dim sql2 As String
            Dim sql As String

            Dim mydata1 As New DataSet



            sql2 = "SELECT DISTINCT processed_service_record.id AS p_id, errorreporthxt.ErrorCode1 AS error"
            sql2 = sql2 + " FROM errorreporthxh, errorreporthxt, patients, processed_service_record, errorreporthx1"
            sql2 = sql2 + " WHERE errorreporthxt.ErrorReportID = errorreporthxh.ErrorReportID "
            sql2 = sql2 + " and errorreporthxh.HealthNumber = [patients].[ohip]"
            sql2 = sql2 + " and patients.id = processed_service_record.patient_id"
            sql2 = sql2 + " and errorreporthxt.HeaderID = errorreporthxh.HeaderID"
            sql2 = sql2 + " and processed_service_record.service_date=cdate(Left([errorreporthxt.ServiceDate],4) & ' / ' & Mid([errorreporthxt.ServiceDate],5,2) & ' / ' & Right([errorreporthxt.ServiceDate],2) )"
            sql2 = sql2 + " and processed_service_record.status<3"
            sql2 = sql2 + " and errorreporthxh.ErrorReportID = errorreporthx1.errorreportid"
            sql2 = sql2 + " and errorreporthx1.status is null"
            sql2 = sql2 + " and errorreporthxt.ErrorReportID=" & Report_id

            objConn.Open()
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql2, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(mydata1, "tblError")


            For Each R1 As DataRow In mydata1.Tables("tblError").Rows

                sql = "UPDATE processed_service_record SET Status = 4, ExplanatoryCode='" & R1("error").ToString & "',error_rpt_id=" & Report_id
                sql = sql + " where processed_service_record.id=" & R1("p_id").ToString

                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
                myCommand = New MySqlCommand(sql, objConn)
                objConn2.Open()
                myCommand.ExecuteNonQuery()
                objConn2.Close()
                ' update processed_Record status with error(4) and Error code

            Next

            sql = "UPDATE errorreporthx1 SET Status = 1"
            sql = sql + " where ErrorReportID=" & Report_id

            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand = New MySqlCommand(sql, objConn)
            objConn2.Open()
            myCommand.ExecuteNonQuery()
            objConn2.Close()

            objConn.Close()

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

End Class