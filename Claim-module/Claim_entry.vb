Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Claim_Entry
    Dim patients As New DataSet
    Dim service_codes As New DataSet
    Dim ref_dr As New DataSet
    Dim service_claim As New DataSet


    'Private myCommand As New System.Data.OleDb.OleDbCommand
    'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
    Private myCommand As New MySqlCommand
    Private myAdapter As MySqlDataAdapter
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objDataAdapter As MySqlDataAdapter
    Dim search_enabled As Boolean = False

    Public Sub state_1()
        'patient entry state
        'date entry required
        ' in order to allow service entry - both patient and date need to be selected and locked
        patient_enabled()
        date_grp.Enabled = False
        service_grp.Enabled = False
        helper_grp.Top = patient_grp.Top
        helper_mngt("patient")
        ch_date_ctr.Visible = False
    End Sub
    Public Sub state_2()
        patient_disabled()
        date_grp.Enabled = True
        service_grp.Enabled = False
        helper_grp.Top = date_grp.Top
        helper_mngt("date")
        ser_enter.Visible = True
        ch_date.Visible = False
        ch_date_ctr.Visible = False
        Plan.SelectedIndex = 0
    End Sub
    Public Sub state_3()
        patient_disabled()
        date_grp.Enabled = False
        service_grp.Enabled = True
        helper_grp.Top = service_grp.Top
        helper_mngt("services")
        validate_service_entry()
        ch_date_ctr.Visible = True
    End Sub
    Public Sub state_4()
        'locked claim
        patient_disabled()
        date_grp.Enabled = False
        service_grp.Enabled = False
        helper_grp.Top = service_grp.Top
        helper_mngt("locked")
        ch_date_ctr.Visible = False
    End Sub
    Public Sub state_logic()
        If Chart_id.Enabled = True And date_grp.Enabled = False Then
            state_2()
        ElseIf Chart_id.Enabled = False And date_grp.Enabled = True Then
            state_3()
        ElseIf Chart_id.Enabled = False And date_grp.Enabled = False Then
            state_1()
        End If
    End Sub
    Public Sub search_patient()
        ' search for patient based on ID,OHIP,LName,Fname 
        ' IF 0 found ask to add new patient - yes show Add patient form
        ' If 1 found select and go to service date
        ' If > 1 found then display search_list and allow to select/Add new/Delete
        'Try
        Dim sql As String
            Dim objDataset As New DataSet
            Dim x As String
            objConn.Open()

            If Chart_id.Text = "" Then
                sql = "select * from patients where lname like '" & Lname.Text.Replace("'", "''") & "%'"
                sql = sql & " and fname like '" & Fname.Text.Replace("'", "''") & "%'"
                sql = sql & " and ohip like '" & Health_num.Text & "%'"
                sql = sql & " order by lname,fname"
            Else
                sql = "select * from patients where "
                sql = sql & " id = " & Chart_id.Text

            End If


        ''MSAccess
        'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
        'MySql
        objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblpatients")


            Select Case objDataset.Tables("tblpatients").Rows.Count

                Case 0
                    x = MsgBox("Do you want to add a new patient", vbYesNo)
                    If x = vbYes Then

                        If OOFSL_main.patient_reader.health_num <> Nothing Then
                            With OOFSL_main.patient_reader

                                patient_entry.health_num.Text = .health_num
                                patient_entry.version.Text = .version_code
                                patient_entry.DOB.Value = .dob
                                patient_entry.fname.Text = .firstname
                                patient_entry.lname.Text = .lastname

                                If .sex = 1 Then
                                    patient_entry.Sex_m.Checked = True
                                ElseIf .sex = 2 Then
                                    patient_entry.Sex_f.Checked = True
                                End If
                            End With
                        Else
                            With patient_entry
                                .clear_patient()
                                .lname.Text = Lname.Text
                                .fname.Text = Fname.Text
                                .chart_id.Text = Chart_id.Text
                                .health_num.Text = Health_num.Text

                            End With
                        End If


                        clear_patient()
                        patient_enabled()
                        patient_entry.Show()
                        patient_entry.Focus()


                    Else
                        patient_enabled()
                    End If

                Case 1
                    show_patient(objDataset.Tables("tblpatients").Rows(0))
                    state_2()
                    Service_picker.Focus()
                    load_defaults()
                Case Is > 1


                    patient_management.load_patient(objDataset)
                    objConn.Close()
                    patient_management.ShowDialog()



            End Select


        'Catch ex As Exception
        '    MsgBox("Error Occured in Patient search")
        'Finally
        '    objConn.Close()
        '    objDataAdapter.Dispose()

        'End Try





    End Sub

    Public Sub selected_patient(x As Integer)
        clear_patient()
        Chart_id.Text = x

        search_patient()
        patient_disabled()

    End Sub


    Public Sub load_patients()
        Try


            Dim sql As String = ""

            objConn.Open()
            sql = "select id,ohip,lname from patients order by lname asc"


            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(patients, "tblpatients")
            Chart_id.AutoCompleteCustomSource.Clear()
            Health_num.AutoCompleteCustomSource.Clear()
            Lname.AutoCompleteCustomSource.Clear()

            For Each rs As DataRow In patients.Tables("tblpatients").Rows

                Chart_id.AutoCompleteCustomSource.Add(rs("id"))
                Health_num.AutoCompleteCustomSource.Add(rs("ohip"))
                Lname.AutoCompleteCustomSource.Add(rs("lname"))

            Next



            objConn.Close()
        Catch ex As Exception

            objConn.Close()
            MsgBox(ex)
        End Try

    End Sub




    Private Sub Claim_Entry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' load_patients()

        load_service_codes()
        'load_ref()
        ListPhysicianReferral.load_ref_dr()

        date_format.Text = Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToString
        date_format2.Text = Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToString
        patient_enabled()
        clear_patient()

        state_1()
        service_grid()
        Me.Width = service_grp.Left + service_grp.Width + 20
        Me.Height = Claim_management.Height

        'hide_helper()



    End Sub



    Private Sub Another_patient_Click(sender As Object, e As EventArgs) Handles Another_patient.Click
        patient_enabled()
        clear_patient()
        patient_entry.clear_patient()
        OOFSL_main.patient_reader.clear()
        state_1()
        Claim_id.Text = ""
    End Sub



    Public Sub patient_enabled()

        Chart_id.Enabled = True
        Lname.Enabled = True
        Health_num.Enabled = True
        Fname.Enabled = True

        Chart_id.ReadOnly = False
        Lname.ReadOnly = False
        Health_num.ReadOnly = False
        Fname.ReadOnly = False
        search_enabled = True



    End Sub
    Public Sub patient_disabled()
        Chart_id.Enabled = False
        Lname.Enabled = False
        Health_num.Enabled = False
        Fname.Enabled = False

        Chart_id.ReadOnly = True
        Lname.ReadOnly = True
        Health_num.ReadOnly = True
        Fname.ReadOnly = True
        search_enabled = False

    End Sub

    Public Sub clear_patient()

        Chart_id.Text = ""
        Lname.Text = ""
        Health_num.Text = ""
        Fname.Text = ""
        version.Text = ""
        DOB.Text = ""
        Edit_patient.Enabled = False
        search_btn.Enabled = True

        clear_services()

        Lname.Focus()
    End Sub

    Public Sub show_patient(d As DataRow)
        Chart_id.Text = d.Item("id")
        Lname.Text = d.Item("lname")
        Health_num.Text = d.Item("ohip")
        Fname.Text = d.Item("fname")
        version.Text = CStr("" & d.Item("version"))
        DOB.Text = d.Item("dob")
        Edit_patient.Enabled = True
        search_btn.Enabled = False

    End Sub



    Private Sub search_Click(sender As System.Object, e As System.EventArgs) Handles search_btn.Click


        patient_disabled()
        Application.DoEvents()
        search_patient()

    End Sub


    Public Sub load_service_codes()
        Try


            Dim sql As String = ""

            objConn.Open()
            sql = "select Servicecode from Services order by servicecode"


            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(service_codes, "tblsrv_codes")
            Service_code.Items.Clear()

            For Each rs As DataRow In service_codes.Tables("tblsrv_codes").Rows

                Service_code.Items.Add(rs("servicecode"))



            Next


            objConn.Close()

        Catch ex As Exception
            objConn.Close()
            'WRITE TO DB - Errors
        End Try

    End Sub

    Public Sub load_ref()
        Try


            Dim sql As String = ""

            objConn.Open()
            sql = "select name from referral order by name"


            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(ref_dr, "tblrfr_dr")
            ref_dr_list.Items.Clear()

            For Each rs As DataRow In ref_dr.Tables("tblrfr_dr").Rows

                ref_dr_list.Items.Add(rs("name"))



            Next


            objConn.Close()

        Catch ex As Exception
            objConn.Close()
            'WRITE TO DB - Errors
        End Try

    End Sub

    Private Sub Service_code_KeyDown(sender As Object, e As KeyEventArgs)
        'check if keypressed is Quick Macro

        If e.KeyCode = 13 Then
            ' MsgBox(e.KeyCode)
        End If

    End Sub

    Private Sub Service_code_KeyDown1(sender As Object, e As KeyEventArgs) Handles Service_code.KeyDown
        'If e.KeyCode = 13 Then
        '    validate_service_entry()
        'End If
    End Sub

    Private Sub Service_code_Leave(sender As Object, e As EventArgs) Handles Service_code.Leave
        'clear_ser_info()
        validate_service_entry()
    End Sub

    Public Sub clear_ser_info()
        Diagnosis.Text = ""
        Num_services.Text = ""
        Referring.Text = ""
        Adm_picker.Value = Today()
        Adm_picker.Checked = False
        Facility_num.Text = ""
        Unit_fee.Text = ""
        Total_fee.Text = ""
        SLI.Text = ""

    End Sub
    Public Sub validate_service_entry()
        Dim sql As String
        Dim services As New DataSet



        Try
            sql = "select * from services where servicecode = '" & Service_code.Text & "'"
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(services, "tblservices")

            If services.Tables("tblservices").Rows.Count > 0 Then


                With services.Tables("tblservices").Rows(0)

                    srv_code_err.Visible = False
                    If Num_services.Text = "" Then ' if there is no default
                        Num_services.Text = .Item("num_services").ToString
                    End If

                    If .Item("servicefee").ToString > 0 Then
                        Unit_fee.Text = .Item("servicefee").ToString
                        Unit_fee.ReadOnly = True
                    Else
                        Unit_fee.ReadOnly = False
                    End If
                    'If .Item("diagnosis").ToString = "Y" Then
                    '    Diagnosis.ReadOnly = False
                    '    dx_find.Enabled = True
                    'Else
                    '    Diagnosis.ReadOnly = True
                    '    dx_find.Enabled = False
                    'End If
                    Diagnosis.ReadOnly = False
                    dx_find.Enabled = True
                    'If .Item("Referalrequired").ToString = "Y" Then
                    Referring.ReadOnly = False
                    ref_find.Enabled = True
                    'Else
                    'Referring.ReadOnly = True
                    'ref_find.Enabled = False
                    'End If

                    'If .Item("adm").ToString = "Y" Then
                    Adm_picker.Enabled = True
                    'Else
                    'Adm_picker.Enabled = False
                    'End If

                    'If .Item("facility").ToString = "Y" Then
                    Facility_num.ReadOnly = False
                    'Else
                    '    Facility_num.ReadOnly = True
                    'End If

                    SLI.Visible = True
                    SLI.Enabled = True

                    'Else
                    '    SLI.Visible = False
                    'End If

                End With
            Else
                ' MsgBox("Service Code does not Exist, Please add service code in SYSTEM Service Management")
                ' srv_code_err.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Confirm_date_Click(sender As Object, e As EventArgs) Handles Confirm_date.Click
        ' Find if Claim exist - get records
        ' required fields Chart_id and Service_Date
        ' this will retrieve all the services for this patient - status = ALL for now
        'clear_services()
        state_2()
        Claim_id.Text = ""

        load_defaults()


        ' If new then create new claim and get ID
        ' Move to Service section

    End Sub
    Public Function retrieve_claim() As Integer
        Try


            Dim sql As String = ""
            Dim i As Integer
            Dim total As Double
            Dim amt_pd As Double

            objConn.Open()
            sql = ""
            sql = "SELECT *"
            sql = sql + " from processed_service_record p_serv,status_lkup st"
            sql = sql + " WHERE p_serv.status=st.status and p_serv.patient_id = " & Chart_id.Text

            'sql = sql + " and p_serv.service_date= #" & Format(Service_picker.Value, "dd/MMM/yyyy") & "#"
            sql = sql + " and p_serv.service_date= '" & Format(Service_picker.Value, "yyyy-MM-dd") & "'"
            sql = sql + " and p_serv.status<6"


            sql = sql + " ORDER BY p_serv.id asc;"


            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            service_claim.Clear()

            Services_grid.Rows.Clear()
            objDataAdapter.Fill(service_claim, "tblclaims")

            total = 0
            amt_pd = 0


            For i = 0 To (service_claim.Tables("tblclaims").Rows.Count - 1)
                With Services_grid

                    .Rows.Add()
                    .Rows(i).Cells("service_date").Value = Format(service_claim.Tables("tblclaims").Rows(i).Item("service_date"), "yyyy/MMM/dd")
                    .Rows(i).Cells("id").Value = service_claim.Tables("tblclaims").Rows(i).Item("id")
                    .Rows(i).Cells("Status").Value = service_claim.Tables("tblclaims").Rows(i).Item("status_desc")
                    .Rows(i).Cells("service_code").Value = service_claim.Tables("tblclaims").Rows(i).Item("service_code")
                    .Rows(i).Cells("num_serv").Value = service_claim.Tables("tblclaims").Rows(i).Item("num_serv")
                    .Rows(i).Cells("service_fee").Value = service_claim.Tables("tblclaims").Rows(i).Item("service_fee")
                    .Rows(i).Cells("Total_Fee").Value = service_claim.Tables("tblclaims").Rows(i).Item("submitted_fee")
                    .Rows(i).Cells("paid").Value = service_claim.Tables("tblclaims").Rows(i).Item("AmountPaid")
                    .Rows(i).Cells("error").Value = service_claim.Tables("tblclaims").Rows(i).Item("ExplanatoryCode")

                    Claim_id.Text = service_claim.Tables("tblclaims").Rows(i).Item("source_id")
                    total = total + CDbl(0 & service_claim.Tables("tblclaims").Rows(i).Item("submitted_fee"))
                    amt_pd = amt_pd + CDbl(0 & service_claim.Tables("tblclaims").Rows(i).Item("AmountPaid"))
                End With
            Next

            Total_sub.Text = total
            Total_paid.Text = amt_pd



            If Services_grid.CurrentRow.Index >= 0 Then
                show_services(Services_grid.CurrentRow.Index)
            End If

            objConn.Close()

            retrieve_claim_status()

            Return service_claim.Tables("tblclaims").Rows.Count

        Catch ex As Exception
            objConn.Close()
            'WRITE TO DB - Errors
        End Try
    End Function

    Public Function retrieve_claim_id() As Integer
        Try


            Dim sql As String = ""
            clear_patient()


            objConn.Open()
            sql = ""
            sql = "SELECT p_id,service_date,status"
            sql = sql + " from claims"
            sql = sql + " WHERE id = " & Claim_id.Text



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            service_claim.Clear()

            Services_grid.Rows.Clear()
            objDataAdapter.Fill(service_claim, "tblclaims")

            Status.Text = service_claim.Tables("tblclaims").Rows(0).Item("status").ToString()
            Chart_id.Text = service_claim.Tables("tblclaims").Rows(0).Item("p_id").ToString()

            Service_picker.Value = Format(service_claim.Tables("tblclaims").Rows(0).Item("service_date"), "dd/MMM/yyyy")
            objConn.Close()
            search_patient()

            retrieve_claim()









            Return service_claim.Tables("tblclaims").Rows.Count

        Catch ex As Exception
            objConn.Close()
            'WRITE TO DB - Errors
        End Try
    End Function

    Public Function retrieve_claim_status() As Integer
        Try
            Dim t As New DataSet

            Dim sql As String = ""


            objConn.Open()
            sql = ""
            sql = "SELECT status"
            sql = sql + " from claims"
            sql = sql + " WHERE id = " & Claim_id.Text



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(t, "tblclaims")


            Status.Text = t.Tables("tblclaims").Rows(0).Item("status").ToString()

            objConn.Close()

            'Select Case t.Tables("tblclaims").Rows(0).Item("status").ToString()
            '    Case 0
            '        state_3()
            '        unsubmit.Enabled = False
            '    Case 1
            '        state_4()
            '        unsubmit.Enabled = True
            '    Case 2
            '        state_4()
            '        unsubmit.Enabled = True
            '    Case 3
            '        state_4()
            '        unsubmit.Enabled = True
            '    Case 4
            '        state_4()
            '        unsubmit.Enabled = True
            '    Case 5
            '        state_4()
            '        unsubmit.Enabled = True
            '    Case 6
            '        state_4()
            '        unsubmit.Enabled = True
            'End Select







            state_3()
            unsubmit.Enabled = False

            Return service_claim.Tables("tblclaims").Rows.Count

        Catch ex As Exception
            objConn.Close()
            'WRITE TO DB - Errors
        End Try
    End Function

    Public Function create_claim() As Integer
        'Dim objConn1 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        Dim objConn1 As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Try


            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            Dim myCommand As New MySqlCommand
            Dim T As New DataSet
            'Dim objDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
            Dim objDataAdapter1 As MySqlDataAdapter
            Dim sql As String

            sql = "insert into claims (p_id,service_date)"
            'sql = sql + " values(" & Chart_id.Text & ",#" & Format(Service_picker.Value, "dd/MMM/yyyy") & "#)"
            sql = sql + " values(" & Chart_id.Text & ",'" & Format(Service_picker.Value, "yyyy-MM-dd") & "')"
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn1)
            myCommand = New MySqlCommand(sql, objConn1)
            objConn1.Open()
            myCommand.ExecuteNonQuery()
            objConn1.Close()

            sql = "select max(id) as id from claims"
            objConn1.Open()
            'objDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter(sql, objConn1)
            objDataAdapter1 = New MysqlDataAdapter(sql, objConn1)
            objDataAdapter1.Fill(T, "claim_id")
            Claim_id.Text = T.Tables("claim_id").Rows(0).Item("id").ToString()

            objConn1.Close()

            Return T.Tables("claim_id").Rows(0).Item("id").ToString()
        Catch ex As Exception
            objConn1.Close()
            MsgBox(ex.ToString)

        Finally


        End Try

    End Function
    Public Sub update_claims(st As Integer)
        'Dim objConn1 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        Dim objConn1 As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Try


            Dim sql As String
            Dim x As String

            If Services_grid.SelectedRows.Count > 0 Then
                sql = "update processed_service_record set status=" & st



                sql = sql & " where id = " & Services_grid.SelectedRows(0).Cells("id").Value
                If st = 0 Then
                    x = MsgBox("Are you sure you want to Re-submit the highlighted service?", vbYesNo)
                    'ElseIf st = 6 Then
                    '   x = MsgBox("Are you sure you want to Archive the highlighted service?", vbYesNo)
                End If

                If x = vbYes Then


                    objConn1.Open()

                    myCommand.Connection = objConn1
                    myCommand.CommandText = sql
                    myCommand.ExecuteNonQuery()

                    objConn1.Close()

                    retrieve_claim()
                    Claim_management.Refresh_tree()
                End If
            End If

        Catch ex As Exception
            objConn1.Close()
        End Try




        'Try

        '    If Claim_id.Text <> "" Then


        '        Dim myCommand As New System.Data.OleDb.OleDbCommand

        '        Dim sql As String


        '        sql = "update claims set total_submitted=" & CDbl(0 & Total_sub.Text) & ","
        '        sql = sql + " status=" & st
        '        sql = sql + " where id=" & Claim_id.Text
        '        myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn1)
        '        objConn1.Open()
        '        myCommand.ExecuteNonQuery()
        '        objConn1.Close()

        '        sql = "update processed_service_record set status=" & st
        '        sql = sql + " where source_id=" & Claim_id.Text
        '        myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn1)
        '        objConn1.Open()
        '        myCommand.ExecuteNonQuery()
        '        objConn1.Close()
        '    End If
        'Catch ex As Exception
        '    objConn1.Close()
        '    MsgBox(ex.ToString)
        'End Try


    End Sub






    Public Sub service_grid()
        With Services_grid

            .Columns.Add("id", "id")
            .Columns("id").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns.Add("service_date", "Service Date")
            .Columns("service_date").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns.Add("Status", "Status")
            .Columns("Status").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns.Add("service_code", "Service code")
            .Columns("service_code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Columns.Add("num_serv", "# Services")
            .Columns("num_serv").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            .Columns.Add("service_fee", "Service Fee")
            .Columns("service_fee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Columns.Add("Total_Fee", "Amount Submitted")
            .Columns("Total_Fee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Columns.Add("paid", "Amount Paid")
            .Columns("paid").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns.Add("error", "Error")
            .Columns("error").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .RowHeadersVisible = False
            .Columns("id").Visible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True

        End With
    End Sub

    Private Sub Service_picker_KeyDown(sender As Object, e As KeyEventArgs) Handles Service_picker.KeyDown
        If ch_date.Visible = False Then
            If e.KeyCode = 13 Then
                retrieve_claim()
            End If
        End If

    End Sub



    Private Sub Services_grid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Services_grid.CellClick
        If e.RowIndex >= 0 Then
            show_services(e.RowIndex)
            If e.ColumnIndex = 8 Then
                error_msg(e.RowIndex)

            End If
        End If

    End Sub

    Private Sub error_msg(id As Integer)
        Dim sql As String
        Dim reader As New DataSet
        Try
            sql = ""
            sql = "SELECT description"
            sql = sql + " from errorcodes"
            sql = sql + " WHERE code = '" & Services_grid.SelectedRows(id).Cells("error").Value & "'"

            objConn.Open()



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(reader, "error_desc")


            For Each rs As DataRow In reader.Tables("error_desc").Rows

                MsgBox(CStr("" & Services_grid.SelectedRows(id).Cells("error").Value) & " = " & rs("description"))

            Next



            objConn.Close()



        Catch e As Exception
            'error
        End Try





    End Sub
    Public Sub show_services(x As Integer)
        With service_claim
            Service_code.Text = .Tables("tblclaims").Rows(x).Item("service_code")
            Diagnosis.Text = .Tables("tblclaims").Rows(x).Item("dx")
            Num_services.Text = .Tables("tblclaims").Rows(x).Item("num_serv")
            Referring.Text = .Tables("tblclaims").Rows(x).Item("referral")
            If IsDBNull(.Tables("tblclaims").Rows(x).Item("adm_date")) Then
                Adm_picker.Checked = False
            Else
                Adm_picker.Value = .Tables("tblclaims").Rows(x).Item("adm_date")
                Adm_picker.Checked = True
            End If
            If IsDBNull(.Tables("tblclaims").Rows(x).Item("facility_num")) Then
            Else
                Facility_num.Text = .Tables("tblclaims").Rows(x).Item("facility_num")
            End If
            If .Tables("tblclaims").Rows(x).Item("mr").ToString = "Y" Then
                mr_chkbox.Checked = True
            Else
                mr_chkbox.Checked = False
            End If
            lab_num.Text = CStr("" & .Tables("tblclaims").Rows(x).Item("lab_num"))
            Unit_fee.Text = .Tables("tblclaims").Rows(x).Item("service_fee")
            Total_fee.Text = .Tables("tblclaims").Rows(x).Item("Submitted_Fee")
            SLI.Text = .Tables("tblclaims").Rows(x).Item("lc")
        End With

    End Sub
    Public Sub clear_services()
        service_claim.Clear()
        Services_grid.Rows.Clear()


        Service_code.Text = ""
        Diagnosis.Text = ""
        Num_services.Text = ""
        Referring.Text = ""
        Adm_picker.Value = Today()
        Adm_picker.Checked = False
        Facility_num.Text = ""
        Unit_fee.Text = ""
        Total_fee.Text = ""

    End Sub

    Private Sub Edit_patient_Click(sender As Object, e As EventArgs) Handles Edit_patient.Click


        patient_entry.selected_patient(Chart_id.Text)
        patient_entry.Show()
        patient_entry.Focus()
        patient_entry.search_patient()


    End Sub

    Public Function validate_service_form() As Integer
        validate_service_form = 0
        num_srv_err.Visible = False
        diag_err.Visible = False
        ref_err.Visible = False
        adm_err.Visible = False
        fac_err.Visible = False
        SLI_err.Visible = False
        Tot_err.Visible = False
        fee_err.Visible = False



        If Service_code.Text <> "" Then
            srv_code_err.Visible = False
        Else
            srv_code_err.Visible = True
            validate_service_form = validate_service_form + 1
        End If



        If Num_services.Text <> "" Then
            If IsNumeric(Num_services.Text) Then
            Else
                MsgBox("Must be a valid # between 1-99")
                num_srv_err.Visible = True
                validate_service_form = validate_service_form + 1

            End If
        Else
            num_srv_err.Visible = True
            validate_service_form = validate_service_form + 1
        End If

        'If Referring.ReadOnly = False Then
        '    If Referring.Text <> "" Then
        '        If IsNumeric(Referring.Text) Then
        '        Else
        '            MsgBox("Must be a valid referring #")
        '            ref_err.Visible = True
        '            validate_service_form = validate_service_form + 1
        '        End If
        '    Else
        '        ref_err.Visible = True
        '        validate_service_form = validate_service_form + 1
        '    End If

        'End If

        'If Diagnosis.ReadOnly = False Then
        '    If Diagnosis.Text <> "" Then

        '    Else
        '        diag_err.Visible = True
        '        validate_service_form = validate_service_form + 1
        '    End If

        'End If

        'If Adm_picker.Enabled = True Then
        '    If Adm_picker.Checked = True Then

        '    Else
        '        adm_err.Visible = True
        '        validate_service_form = validate_service_form + 1
        '    End If

        'End If

        'If Facility_num.ReadOnly = False Then
        '    If Facility_num.Text <> "" Then
        '        If IsNumeric(Facility_num.Text) Then
        '        Else
        '            MsgBox("Must be a valid facility #")
        '            fac_err.Visible = True
        '            validate_service_form = validate_service_form + 1
        '        End If
        '    Else
        '        fac_err.Visible = True
        '        validate_service_form = validate_service_form + 1
        '    End If

        'End If
        If Unit_fee.ReadOnly = False Then
            If Unit_fee.Text <> "" Then
                If IsNumeric(Unit_fee.Text) Then
                Else
                    MsgBox("Must be a valid value")
                    fee_err.Visible = True
                    validate_service_form = validate_service_form + 1
                End If
            Else
                MsgBox("Must enter a unit fee for this service")
                fee_err.Visible = True
                validate_service_form = validate_service_form + 1
            End If

        End If



    End Function

    Private Sub Add_service_Click(sender As Object, e As EventArgs) Handles Add_service.Click
        Dim sql As String
        Dim source_id As Integer

        Try

            If validate_service_form() = 0 Then
                If Claim_id.Text = "" Then
                    source_id = create_claim()
                Else
                    source_id = Claim_id.Text

                End If
                Total_fee.Text = CDbl(Unit_fee.Text * Num_services.Text)
                sql = "Insert into processed_service_record"
                sql = sql & " ("
                sql = sql & "patient_id,"
                sql = sql & "service_code,"
                sql = sql & "service_fee,"
                sql = sql & "referral,"
                sql = sql & "num_serv,"
                sql = sql & "LC,"
                sql = sql & "DX,"
                sql = sql & "service_date,"
                sql = sql & "adm_date,"
                sql = sql & "facility_num,"
                sql = sql & "status,"
                sql = sql & "source_id,"
                sql = sql & "Submitted_Fee,"
                sql = sql & "mr,"
                sql = sql & "lab_num"

                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "" & Chart_id.Text & ","
                sql = sql & "'" & Service_code.Text & "',"
                sql = sql & "'" & Unit_fee.Text & "',"
                sql = sql & "'" & Referring.Text & "',"
                sql = sql & "'" & CInt(Num_services.Text) & "',"
                sql = sql & "'" & SLI.Text & "',"
                sql = sql & "'" & Diagnosis.Text & "',"
                'sql = sql & "'" & Format(Service_picker.Value, "dd/MMM/yyyy") & "'," 'fixed
                sql = sql & "'" & Format(Service_picker.Value, "yyyy-MM-dd") & "'," 'fixed
                If Adm_picker.Checked = True Then
                    sql = sql & "'" & Format(Adm_picker.Value, "yyyy-MM-dd") & "'," 'added
                Else
                    sql = sql & "null," 'added
                End If

                sql = sql & "'" & Facility_num.Text & "'," 'added
                sql = sql & "0," 'added status open
                sql = sql & source_id & ","
                sql = sql & Total_fee.Text & ","
                If mr_chkbox.Checked = True Then
                    sql = sql & "'Y',"
                Else
                    sql = sql & "null,"
                End If
                sql = sql & "'" & lab_num.Text & "'"
                sql = sql & ")"


                objConn.Open()

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                objConn.Close()


                retrieve_claim()

                update_defaults()
                Claim_management.Refresh_tree()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            objConn.Close()
        End Try
    End Sub

    Private Sub Update_service_Click(sender As Object, e As EventArgs) Handles Update_service.Click

        Try
            If Services_grid.RowCount > 0 Then
                If validate_service_form() = 0 Then
                    Dim sql As String
                    Total_fee.Text = CDbl(Unit_fee.Text * Num_services.Text)
                    sql = "update processed_service_record set "

                    sql = sql & "service_code ='" & Service_code.Text & "',"
                    sql = sql & "service_fee ='" & Unit_fee.Text & "',"
                    sql = sql & "submitted_fee ='" & Total_fee.Text & "',"
                    sql = sql & "referral ='" & Referring.Text & "',"
                    sql = sql & "num_serv ='" & Num_services.Text & "',"
                    sql = sql & "LC = '" & SLI.Text & "',"
                    sql = sql & "DX = '" & Diagnosis.Text & "',"
                    'sql = sql & "service_date =#" & Format(Service_picker.Value, "dd/MMM/yyyy") & "#,"
                    sql = sql & "service_date ='" & Format(Service_picker.Value, "yyyy-MM-dd") & "',"

                    If Adm_picker.Checked = True Then
                        'sql = sql & "adm_date=#" & Format(Adm_picker.Value, "dd/MMM/yyyy") & "#," 'added
                        sql = sql & "adm_date='" & Format(Adm_picker.Value, "yyyy-MM-dd") & "'," 'added
                    Else
                        sql = sql & "adm_date=null," 'added
                    End If



                    sql = sql & "facility_num='" & Facility_num.Text & "'," 'added

                    If mr_chkbox.Checked = True Then
                        sql = sql & "mr='Y',"
                    Else
                        sql = sql & "mr = null,"
                    End If
                    sql = sql & "lab_num = '" & lab_num.Text & "'"

                    sql = sql & " where id = " & Services_grid.SelectedRows(0).Cells("id").Value


                    objConn.Open()

                    myCommand.Connection = objConn
                    myCommand.CommandText = sql
                    myCommand.ExecuteNonQuery()
                    objConn.Close()
                    'update claim section

                    If Claim_id.Text <> "" Then
                        sql = "update claims set "
                        'sql = sql & "service_date =#" & Format(Service_picker.Value, "dd/MMM/yyyy") & "#"
                        sql = sql & "service_date ='" & Format(Service_picker.Value, "yyyy-MM-dd") & "'"
                        sql = sql & "where id=" & Claim_id.Text
                        objConn.Open()

                        myCommand.Connection = objConn
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()

                    End If
                    'updateclaim section end


                    objConn.Close()

                    update_defaults()
                    retrieve_claim()
                    Claim_management.Refresh_tree()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            objConn.Close()
        End Try



    End Sub

    Public Sub load_defaults()
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand

            'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim myCommand As New MySqlCommand

            Dim objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim i As Integer
            Dim ser_def As New DataSet

            objConn.Open()
            sql = ""
            sql = "SELECT *"
            sql = sql + " from patient_defaults"
            sql = sql + " WHERE patient_id = " & Chart_id.Text



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)


            objDataAdapter.Fill(ser_def, "tbldefaults")

            If ser_def.Tables("tbldefaults").Rows.Count > 0 Then

                Service_code.Text = CStr("" & ser_def.Tables("tbldefaults").Rows(i).Item("service_code"))
                Num_services.Text = CStr("" & ser_def.Tables("tbldefaults").Rows(i).Item("num_serv"))
                Diagnosis.Text = CStr("" & ser_def.Tables("tbldefaults").Rows(i).Item("dx"))
                Referring.Text = CStr("" & ser_def.Tables("tbldefaults").Rows(i).Item("referral"))
                ref_dr_list.SelectedValue = Referring.Text
                Facility_num.Text = CStr("" & ser_def.Tables("tbldefaults").Rows(i).Item("facility_num"))

                If IsDBNull(ser_def.Tables("tbldefaults").Rows(i).Item("adm_date")) Then
                    Adm_picker.Checked = False

                Else
                    Adm_picker.Checked = True
                    Adm_picker.Value = ser_def.Tables("tbldefaults").Rows(i).Item("adm_date")
                End If


            End If
            objConn.Close()



        Catch ex As Exception
            objConn.Close()
            'WRITE TO DB - Errors
        End Try
    End Sub

    Public Sub update_defaults()
        ' Update defaults for Patients

        Try


            Dim sql As String

            'Dim myCommand As New System.Data.OleDb.OleDbCommand

            'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)

            Dim myCommand As New MySqlCommand

            Dim objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)

            objConn.Open()
            sql = "delete from patient_defaults where patient_id = " & Chart_id.Text
            myCommand.Connection = objConn
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()

            sql = "Insert into patient_defaults"
            sql = sql & " ("
            sql = sql & "patient_id,"
            sql = sql & "service_code,"
            sql = sql & "referral,"
            sql = sql & "num_serv,"
            sql = sql & "LC,"
            sql = sql & "DX,"

            sql = sql & "adm_date,"

            sql = sql & "facility_num"


            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "" & Chart_id.Text & ","
            sql = sql & "'" & Service_code.Text & "',"
            sql = sql & "'" & Referring.Text & "',"
            sql = sql & "'" & Num_services.Text & "',"
            sql = sql & "'" & SLI.Text & "',"
            sql = sql & "'" & Diagnosis.Text & "',"
            If Adm_picker.Checked = True Then
                'sql = sql & "'" & Format(Adm_picker.Value, "dd/MMM/yyyy") & "'," 'added
                sql = sql & "'" & Format(Adm_picker.Value, "yyyy-MM-dd") & "'," 'added
            Else
                sql = sql & "null," 'added
            End If

            sql = sql & "'" & Facility_num.Text & "')" 'added

            myCommand.Connection = objConn
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)

        Finally
            objConn.Close()
        End Try


    End Sub

    Private Sub Delete_Service_Click(sender As Object, e As EventArgs) Handles Delete_Service.Click
        Try


            Dim sql As String
            Dim x As String

            If Services_grid.SelectedRows.Count > 0 Then
                sql = "Delete * from processed_service_record"



                sql = sql & " where id = " & Services_grid.SelectedRows(0).Cells("id").Value

                x = MsgBox("Are you sure you want to delete the highlighted service?", vbYesNo)
                If x = vbYes Then


                    objConn.Open()

                    myCommand.Connection = objConn
                    myCommand.CommandText = sql
                    myCommand.ExecuteNonQuery()

                    objConn.Close()
                    update_claims(6)
                    retrieve_claim()
                    Claim_management.Refresh_tree()
                End If
            End If

        Catch ex As Exception
            objConn.Close()
        End Try
    End Sub

    Private Sub Num_services_Leave(sender As Object, e As EventArgs) Handles Num_services.Leave
        Try
            Total_fee.Text = CDbl(Unit_fee.Text * Num_services.Text)
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Service_picker_Leave(sender As Object, e As EventArgs) Handles Service_picker.Leave

        If ch_date.Visible = False Then
            state_3()
            If retrieve_claim() = 0 Then

            End If
        End If

    End Sub






    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub helper_mngt(section As String)
        help_txt.Text = ""

        Select Case section
            Case "patient"

                help_txt.Text = help_txt.Text & "You can enter:" & vbCrLf
                help_txt.Text = help_txt.Text + "1) Health# and/or" & vbCrLf
                help_txt.Text = help_txt.Text + "2) last name and/or" & vbCrLf
                help_txt.Text = help_txt.Text + "3) first name" & vbCrLf & vbCrLf
                help_txt.Text = help_txt.Text + " Then click find to select the patient" & vbCrLf
            Case "date"

                help_txt.Text = help_txt.Text & "1) You will need to select a service date" & vbCrLf
                help_txt.Text = help_txt.Text + "2) Then tab or click on service code" & vbCrLf


            Case "services"
                help_txt.Text = help_txt.Text & "1) Select the service code and Tab" & vbCrLf
                help_txt.Text = help_txt.Text + "2) Fill in all the mandatory fields" & vbCrLf
                help_txt.Text = help_txt.Text + "3) click add/update" & vbCrLf



            Case "locked"

                help_txt.Text = help_txt.Text & "ATTENTION: This claims is currently locked - to edit you need to un-submit."


        End Select
    End Sub

    Public Sub hide_helper()

        Me.Width = Me.service_grp.Left + Me.service_grp.Width + 20
        helper_grp.Visible = True
    End Sub
    Public Sub show_helper()

        Me.Width = (Me.helper_grp.Left + Me.helper_grp.Width + 50)

        helper_grp.Visible = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        hide_helper()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        change_assistant()

    End Sub
    Public Sub change_assistant()
        If assistant_f_img.Visible = False Then
            assistant_m_img.Visible = False
            assistant_f_img.Visible = True
        Else
            assistant_m_img.Visible = True
            assistant_f_img.Visible = False
        End If


    End Sub





    Private Sub unsubmit_Click(sender As Object, e As EventArgs) Handles unsubmit.Click
        'Dim objConn1 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        Dim objConn1 As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Try

            If Claim_id.Text <> "" Then


                'Dim myCommand As New System.Data.OleDb.OleDbCommand
                Dim myCommand As New MySqlCommand

                Dim sql As String


                sql = "update claims set status=0"
                sql = sql + " where id=" & Claim_id.Text
                myCommand = New MySqlCommand(sql, objConn1)
                objConn1.Open()
                myCommand.ExecuteNonQuery()
                objConn1.Close()

                retrieve_claim()

            End If
        Catch ex As Exception
            objConn1.Close()
            MsgBox(ex.ToString)
        End Try





    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ser_enter.Click
        state_3()
        If retrieve_claim() = 0 Then

        End If

        If Service_code.Text <> "" Then
            validate_service_entry()
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles dx_find.Click
        ListDiagnosisCodes.ShowDialog(Me)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles sv_find.Click

        ListServiceCodes.ShowDialog()
        'clear_ser_info()
        validate_service_entry()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ref_find.Click
        ListPhysicianReferral.ShowDialog()
    End Sub

    Private Sub Archive_cl_Click(sender As Object, e As EventArgs) Handles Archive_cl.Click
        update_claims(6)
        retrieve_claim()


        Claim_management.Refresh_tree()
    End Sub


    Private Sub Button3_Click_2(sender As Object, e As EventArgs) Handles Button3.Click
        'If Chart_id.Text <> "" Then
        '    Dim sql As String

        '    sql = "select distinct pat.fname,pat.lname,pat.ohip,pat.version,srv.id,srv.service_date,srv.service_code,srv.num_serv,srv.service_fee,cDbl(srv.num_serv*srv.service_fee) as Total_Fee "
        '    sql = sql & ", srv.referral as ref,srv.facility_num as inst,srv.adm_date as adm_dt,pat.dob as dob, pat.sexe as sex, cDbl('0' & srv.amountpaid) as amt_paid, srv.ExplanatoryCode as error"
        '    sql = sql & " from processed_service_record srv, patients pat "
        '    sql = sql & " where srv.patient_id = pat.id"
        '    sql = sql & " and srv.patient_id=" & Chart_id.Text
        '    sql = sql & " order by srv.service_date desc, srv.id asc "

        '    TransactionHistory.print_reports(sql, 5)
        'End If
        If Chart_id.Text <> "" Then
            TransactionHistory.TabControl1.SelectedTab = TransactionHistory.TabPage1
            TransactionHistory.patient_id.Text = Chart_id.Text
            TransactionHistory.Date_frm_sub.Value = "1-jan-2010"
            TransactionHistory.Date_to_sub.Value = Today()
            TransactionHistory.Visible = True
            TransactionHistory.MdiParent = OOFSL_main
            TransactionHistory.Show()

        End If

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        update_claims(0)
        retrieve_claim()


        Claim_management.Refresh_tree()
    End Sub


    Private Sub ch_date_Click(sender As Object, e As EventArgs) Handles ch_date.Click

        Dim x

        x = MsgBox("You are changing the service date for this claim, Are you sure?", vbYesNoCancel)
        If x = vbYes Then
            Update_service_Click(sender, e)
        End If

    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles ch_date_ctr.Click
        state_2()
        ser_enter.Visible = False
        ch_date.Visible = True

    End Sub



    Private Sub ref_dr_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ref_dr_list.SelectedIndexChanged
        Referring.Text = ref_dr_list.SelectedValue.ToString()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If Claim_id.Text <> "" Then
            If Claim_id.Text < 100000 Then
                Claim_id.Text = Claim_id.Text + 1
            End If
        End If
        retrieve_claim_id()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Claim_id.Text <> "" Then
            If Claim_id.Text > 2 Then
                Claim_id.Text = Claim_id.Text - 1
            End If
        End If
        retrieve_claim_id()
    End Sub


End Class