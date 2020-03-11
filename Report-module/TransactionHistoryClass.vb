
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class TransactionHistoryClass
    ' MSAccess
    'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
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

    'submitted claims Tab
    Public Sub CreateDataViewHeaders() ' for processed services

        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("id", "id")
        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("lname", "Last Name")
        TransactionHistory.ServiceHistoryDataGrid.Columns("lname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("fname", "First Name")
        TransactionHistory.ServiceHistoryDataGrid.Columns("fname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("service_date", "Service Date")
        TransactionHistory.ServiceHistoryDataGrid.Columns("service_date").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'TransactionHistory.ServiceHistoryDataGrid.Columns.Add("total_services", "Total services")
        'TransactionHistory.ServiceHistoryDataGrid.Columns("total_services").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("service_code", "Service code")
        TransactionHistory.ServiceHistoryDataGrid.Columns("service_code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("num_serv", "# Services")
        TransactionHistory.ServiceHistoryDataGrid.Columns("num_serv").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("service_fee", "Service Fee")
        TransactionHistory.ServiceHistoryDataGrid.Columns("service_fee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("Total_Fee", "Amount Submitted")
        TransactionHistory.ServiceHistoryDataGrid.Columns("Total_Fee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("paid", "Amount Paid")
        TransactionHistory.ServiceHistoryDataGrid.Columns("paid").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        TransactionHistory.ServiceHistoryDataGrid.Columns.Add("error", "Error")
        TransactionHistory.ServiceHistoryDataGrid.Columns("error").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.ServiceHistoryDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect

       

        TransactionHistory.ServiceHistoryDataGrid.RowHeadersVisible = False
        TransactionHistory.ServiceHistoryDataGrid.Columns("id").Visible = False

    End Sub

    Public Sub GetSubmitedServiceHistory()
        Dim sql As String

        sql = "select distinct pat.fname,pat.lname,pat.ohip,pat.version,srv.id,srv.service_date,srv.service_code,srv.num_serv,srv.service_fee,Submitted_Fee as Total_Fee "
        sql = sql & ", srv.referral as ref,srv.facility_num as inst,srv.adm_date as adm_dt,pat.dob as dob, pat.sexe as sex, cDbl('0' & srv.amountpaid) as amt_paid, srv.ExplanatoryCode as error"
        sql = sql & " from processed_service_record srv, patients pat "
        sql = sql & " where  srv.patient_id = pat.id"

        Select Case True

            Case TransactionHistory.All_radio.Checked
                sql = sql + " and status <6"
            Case TransactionHistory.Error_radio.Checked
                sql = sql + " and status =4"
            Case TransactionHistory.Unpaid_radio.Checked
                sql = sql + " and status in (1,2)"
            Case TransactionHistory.Paid_Radio.Checked
                sql = sql + " and status =3"
            Case TransactionHistory.Open_cl.Checked
                sql = sql + " and status =0"
            Case TransactionHistory.archived_cl.Checked
                sql = sql + " and status in (6,7)"
            Case Else
                sql = sql + " and status in (1,2,3,4)"
        End Select

        Select Case True
            Case TransactionHistory.radio_search_date.Checked
                'sql = sql + " and srv.service_date BETWEEN Format('" & TransactionHistory.Date_frm_sub.Value & "', 'dd/mmm/yyyy') and Format('" & TransactionHistory.Date_to_sub.Value & "', 'dd/mmm/yyyy')"
                sql = sql + " and srv.service_date BETWEEN '" & Format(TransactionHistory.Date_frm_sub.Value, "yyyy-MM-dd") & "' and '" & Format(TransactionHistory.Date_to_sub.Value, "yyyy-MM-dd") & "'"
            Case TransactionHistory.Radio_search_sub.Checked
                sql = sql + " and srv.processed_date BETWEEN '" & Format(TransactionHistory.Date_frm_sub.Value, "yyyy-MM-dd") & "' and '" & Format(TransactionHistory.Date_to_sub.Value, "yyyy-MM-dd") & "'"
        End Select


        If TransactionHistory.Filename_txt.Text <> "" Then
            TransactionHistory.Filename_txt.Visible = True
            TransactionHistory.filename_lbl.Visible = True
            sql = sql + " and processed_file='" & TransactionHistory.Filename_txt.Text & "'"
        Else
            TransactionHistory.Filename_txt.Visible = False
            TransactionHistory.filename_lbl.Visible = False

        End If

        If TransactionHistory.patient_id.Text <> "" Then
            sql = sql + " and pat.id=" & TransactionHistory.patient_id.Text
        Else

        End If


        sql = sql & " order by srv.service_date asc, srv.id asc "

        TransactionHistory.sql_current_sub = sql


        ServiceHistory_processed(sql)


    End Sub
    Public Sub GetSubmitedServiceHistory_all()

        TransactionHistory.Date_frm_sub.Value = "1-Jan-2010"
        TransactionHistory.Date_to_sub.Value = Today
        GetSubmitedServiceHistory()

    End Sub
    Public Sub ServiceHistory_processed(sql As String)

        Dim objDataset As New DataSet
        Dim i As Integer
        Dim objServiceData As DateTime

        Dim total_s As Double
        Dim total_p As Double
        Dim total_units As Integer

        total_s = 0
        total_p = 0
        total_units = 0

        Try

            objConn.Open()





            '            objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblservices")
            TransactionHistory.ServiceHistoryDataGrid.Rows.Clear()
            Application.DoEvents()
            'TransactionHistory.ServiceHistoryDataGrid.ReadOnly = True
            TransactionHistory.ServiceHistoryDataGrid.AllowUserToAddRows = False

            TransactionHistory.ServiceHistoryDataGrid.BackgroundColor = Color.LightGray
            TransactionHistory.ServiceHistoryDataGrid.BorderStyle = BorderStyle.Fixed3D

            ' Set property values appropriate for read-only display and 
            ' limited interactivity. 
            TransactionHistory.ServiceHistoryDataGrid.AllowUserToAddRows = False
            TransactionHistory.ServiceHistoryDataGrid.AllowUserToDeleteRows = False
            TransactionHistory.ServiceHistoryDataGrid.AllowUserToOrderColumns = True
            ' TransactionHistory.ServiceHistoryDataGrid.ReadOnly = True
            TransactionHistory.ServiceHistoryDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            TransactionHistory.ServiceHistoryDataGrid.MultiSelect = True
            TransactionHistory.ServiceHistoryDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            TransactionHistory.ServiceHistoryDataGrid.AllowUserToResizeColumns = False
            'TransactionHistory.ServiceHistoryDataGrid.ColumnHeadersHeightSizeMode = _
            '    DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            TransactionHistory.ServiceHistoryDataGrid.AllowUserToResizeRows = False
            'TransactionHistory.ServiceHistoryDataGrid.RowHeadersWidthSizeMode = _
            '    DataGridViewRowHeadersWidthSizeMode.DisableResizing

            ' Set the selection background color for all the cells.
            'TransactionHistory.ServiceHistoryDataGrid.DefaultCellStyle.SelectionBackColor = Color.White
            TransactionHistory.ServiceHistoryDataGrid.DefaultCellStyle.SelectionForeColor = Color.Black
            TransactionHistory.ServiceHistoryDataGrid.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            TransactionHistory.ServiceHistoryDataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty
            If objDataset.Tables("tblservices").Rows.Count > 0 Then
                For i = 0 To objDataset.Tables("tblservices").Rows.Count - 1
                    objServiceData = objDataset.Tables("tblservices").Rows(i).Item("service_date")
                    ' objProcessDate = objDataset.Tables("tblservices").Rows(i).Item("processed_date")
                    TransactionHistory.ServiceHistoryDataGrid.Rows.Add()
                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("id").Value = objDataset.Tables("tblservices").Rows(i).Item("id")
                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("lname").Value = objDataset.Tables("tblservices").Rows(i).Item("lname")
                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("fname").Value = objDataset.Tables("tblservices").Rows(i).Item("fname")
                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("service_date").Value = Format(objServiceData, "yyyy/MM/dd")
                    'TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("processed_date").Value = Format(objProcessDate, "dd/MM/yyyy")
                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("service_code").Value = objDataset.Tables("tblservices").Rows(i).Item("service_code")
                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("num_serv").Value = objDataset.Tables("tblservices").Rows(i).Item("num_serv")
                    total_units = total_units + CInt(objDataset.Tables("tblservices").Rows(i).Item("num_serv"))

                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("Total_fee").Value = FormatCurrency(0 & objDataset.Tables("tblservices").Rows(i).Item("Total_fee"), 2)
                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("service_fee").Value = FormatCurrency(0 & objDataset.Tables("tblservices").Rows(i).Item("service_fee"), 2)
                    If IsDBNull(objDataset.Tables("tblservices").Rows(i).Item("amt_paid")) Then
                        TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("paid").Value = ""
                    Else
                        TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("paid").Value = FormatCurrency(objDataset.Tables("tblservices").Rows(i).Item("amt_paid"), 2)
                        total_p = total_p + TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("paid").Value
                    End If
                    TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("error").Value = CStr("" & objDataset.Tables("tblservices").Rows(i).Item("Error"))
                    total_s = total_s + CDbl(TransactionHistory.ServiceHistoryDataGrid.Rows(i).Cells("Total_fee").Value)
                Next

                'TransactionHistory.ServiceHistoryDataGrid.CurrentCell.Selected = False
                'TransactionHistory.ServiceHistoryDataGrid.CurrentRow.Selected = False
                'TransactionHistory.ServiceHistoryDataGrid.ClearSelection()
            End If
            TransactionHistory.Totals_txt.Text = FormatCurrency(total_s, 2)
            TransactionHistory.Totalp_txt.Text = FormatCurrency(total_p, 2)
            TransactionHistory.Tot_claims2.Text = i

            TransactionHistory.Total_units_v2.Text = total_units


            objConn.Close()
        Catch ex As Exception
            objConn.Close()
        End Try

    End Sub



    ' Unsubmit/open CLaim tab

    Public Sub CreateDataViewHeaders2() ' for open services


        TransactionHistory.unsubmit_history.Columns.Add("lname", "Last Name")
        TransactionHistory.unsubmit_history.Columns("lname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.unsubmit_history.Columns.Add("fname", "First Name")
        TransactionHistory.unsubmit_history.Columns("fname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.unsubmit_history.Columns.Add("service_date", "Service Date")
        TransactionHistory.unsubmit_history.Columns("service_date").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.unsubmit_history.Columns.Add("service_code", "Service code")
        TransactionHistory.unsubmit_history.Columns("service_code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.unsubmit_history.Columns.Add("num_serv", "# Services")
        TransactionHistory.unsubmit_history.Columns("num_serv").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.unsubmit_history.Columns.Add("service_fee", "Service Fee")
        TransactionHistory.unsubmit_history.Columns("service_fee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TransactionHistory.unsubmit_history.Columns.Add("Total_fee", "Total Fee")
        TransactionHistory.unsubmit_history.Columns("Total_fee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        TransactionHistory.unsubmit_history.RowHeadersVisible = False


    End Sub


    Public Sub GetunSubmitedServiceHistory() ' unsubmit query
        Dim sql As String

        sql = "SELECT pat.fname, pat.lname,pat.ohip,pat.version, srv.service_date,srv.service_code as service_code, srv.num_serv, srv.service_fee, Submitted_Fee as Total_Fee"
        sql = sql & ", srv.referral as ref,srv.facility_num as inst,srv.adm_date as adm_dt,pat.dob as dob, pat.sexe as sex"
        sql = sql & " FROM patients AS pat, processed_service_record as srv"
        sql = sql & " where srv.patient_id=pat.id"
        'sql = sql + " and srv.service_date BETWEEN Format('" & TransactionHistory.Date_frm_open.Value & "', 'mmm/dd/yyyy') and Format('" & TransactionHistory.Date_to_open.Value & "', 'mmm/dd/yyyy')"
        sql = sql + " and srv.service_date BETWEEN '" & Format(TransactionHistory.Date_frm_open.Value, "yyyy-MM-dd") & "' and '" & Format(TransactionHistory.Date_to_open.Value, "yyyy-MM-dd") & "'"
        sql = sql + " and srv.status=0"
        If TransactionHistory.patient_id.Text <> "" Then
            sql = sql + " and pat.id=" & TransactionHistory.patient_id.Text
        Else

        End If
        sql = sql & " order by srv.service_date asc, srv.id asc "

        TransactionHistory.sql_current_unsub = sql
        ServiceHistory(sql)

    End Sub
    Public Sub GetunSubmitedServiceHistory_all() ' unsubmit query
        TransactionHistory.Date_frm_open.Value = "1-jan-2010"
        TransactionHistory.Date_to_open.Value = Today()
        GetunSubmitedServiceHistory()
    End Sub
    Public Sub ServiceHistory(sql As String) ' unsubmit query

        Dim objDataset As New DataSet
        Dim i As Integer
        Dim objServiceData As DateTime
        Dim total As Double
        Dim total_units As Integer
        total_units = 0

        total = 0

        Try

            objConn.Open()



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblservices")
            TransactionHistory.unsubmit_history.Rows.Clear()
            Application.DoEvents()
            TransactionHistory.unsubmit_history.ReadOnly = True
            TransactionHistory.unsubmit_history.AllowUserToAddRows = False

            TransactionHistory.unsubmit_history.BackgroundColor = Color.LightGray
            TransactionHistory.unsubmit_history.BorderStyle = BorderStyle.Fixed3D

            ' Set property values appropriate for read-only display and 
            ' limited interactivity. 
            TransactionHistory.unsubmit_history.AllowUserToAddRows = False
            TransactionHistory.unsubmit_history.AllowUserToDeleteRows = False
            TransactionHistory.unsubmit_history.AllowUserToOrderColumns = True
            TransactionHistory.unsubmit_history.ReadOnly = True
            TransactionHistory.unsubmit_history.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            TransactionHistory.unsubmit_history.MultiSelect = False
            TransactionHistory.unsubmit_history.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            TransactionHistory.unsubmit_history.AllowUserToResizeColumns = False
            'TransactionHistory.ServiceHistoryDataGrid.ColumnHeadersHeightSizeMode = _
            '    DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            TransactionHistory.unsubmit_history.AllowUserToResizeRows = False
            'TransactionHistory.ServiceHistoryDataGrid.RowHeadersWidthSizeMode = _
            '    DataGridViewRowHeadersWidthSizeMode.DisableResizing

            ' Set the selection background color for all the cells.
            TransactionHistory.unsubmit_history.DefaultCellStyle.SelectionBackColor = Color.White
            TransactionHistory.unsubmit_history.DefaultCellStyle.SelectionForeColor = Color.Black

            ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            TransactionHistory.unsubmit_history.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty


            If objDataset.Tables("tblservices").Rows.Count > 0 Then
                For i = 0 To objDataset.Tables("tblservices").Rows.Count - 1
                    objServiceData = objDataset.Tables("tblservices").Rows(i).Item("service_date")

                    TransactionHistory.unsubmit_history.Rows.Add()

                    TransactionHistory.unsubmit_history.Rows(i).Cells("lname").Value = objDataset.Tables("tblservices").Rows(i).Item("lname")
                    TransactionHistory.unsubmit_history.Rows(i).Cells("fname").Value = objDataset.Tables("tblservices").Rows(i).Item("fname")
                    TransactionHistory.unsubmit_history.Rows(i).Cells("service_date").Value = Format(objServiceData, "dd/MM/yyyy")

                    TransactionHistory.unsubmit_history.Rows(i).Cells("service_code").Value = objDataset.Tables("tblservices").Rows(i).Item("service_code")
                    TransactionHistory.unsubmit_history.Rows(i).Cells("num_serv").Value = objDataset.Tables("tblservices").Rows(i).Item("num_serv")
                    total_units = total_units + CInt(objDataset.Tables("tblservices").Rows(i).Item("num_serv"))

                    TransactionHistory.unsubmit_history.Rows(i).Cells("service_fee").Value = objDataset.Tables("tblservices").Rows(i).Item("service_fee")
                    TransactionHistory.unsubmit_history.Rows(i).Cells("Total_Fee").Value = FormatNumber(objDataset.Tables("tblservices").Rows(i).Item("Total_Fee"), 2)


                    total = total + CDbl(TransactionHistory.unsubmit_history.Rows(i).Cells("num_serv").Value) * CDbl(TransactionHistory.unsubmit_history.Rows(i).Cells("service_fee").Value)

                Next
                TransactionHistory.TOTAL1.Text = FormatCurrency(total, 2)

                TransactionHistory.unsubmit_history.CurrentCell.Selected = False
                TransactionHistory.unsubmit_history.CurrentRow.Selected = False
                TransactionHistory.unsubmit_history.ClearSelection()
            End If
            TransactionHistory.Label13.Text = FormatCurrency(total, 2)
            TransactionHistory.Label6.Text = i
            TransactionHistory.Total_units_v.Text = total_units


            objConn.Close()
        Catch ex As Exception
            objConn.Close()
        End Try

    End Sub


    Public Sub unsubmit_claims(Claim_ids As ArrayList)
        Dim i As Integer
        Dim txt As String = ""

        For i = 0 To Claim_ids.Count - 1
            txt = txt & Claim_ids(i).ToString & ","

        Next
        txt = Left(txt, Len(txt) - 1)



        Try

            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
            Dim myCommand As New MySqlCommand
            Dim objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
            Dim sql As String




            sql = " UPDATE processed_service_record SET processed_service_record.status=0"
            sql = sql + " where processed_service_record.id in (" & txt & ")"


            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            TransactionHistory.refresh_sub_grid()


        Catch ex As Exception
            MsgBox("Error in re-submit module")
        End Try
    End Sub

    Public Sub archive_claims(Claim_ids As ArrayList)
        Dim i As Integer
        Dim txt As String = ""

        For i = 0 To Claim_ids.Count - 1
            txt = txt & Claim_ids(i).ToString & ","

        Next
        txt = Left(txt, Len(txt) - 1)



        Try

            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
            Dim myCommand As New MySqlCommand
            Dim objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
            Dim sql As String




            sql = " UPDATE processed_service_record SET processed_service_record.status=6"
            sql = sql + " where processed_service_record.id in (" & txt & ")"


            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            TransactionHistory.refresh_sub_grid()


        Catch ex As Exception
            MsgBox("Error in re-submit module")
        End Try
    End Sub

    

    
End Class
