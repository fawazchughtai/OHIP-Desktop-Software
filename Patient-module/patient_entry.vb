Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class patient_entry

    Dim patient As New DataSet

    'Private myCommand As New System.Data.OleDb.OleDbCommand
    'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objConn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
    Private myCommand As New MySqlCommand
    Private myAdapter As MySqlDataAdapter
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objConn2 As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objDataAdapter As MySqlDataAdapter



    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        ' save new and update exisitng records

        If Me.prov.Text = "Ontario" Then
            Dim objOHIPValidator As New OHIPValidation
            objOHIPValidator.OHIPNumber = Me.health_num.Text
            If objOHIPValidator.isValid Then
                Health_err.Visible = False
                If check_mandatory() = 0 Then
                    Save()
                    MsgBox("Save completed")
                End If

            Else
                Health_err.Visible = True
                MsgBox("Invalid OHIP #")


            End If
        Else
            Health_err.Visible = False
            If check_mandatory() = 0 Then
                Save()
                MsgBox("Save completed")
            End If

        End If



    End Sub

    Public Function check_mandatory() As Integer
        check_mandatory = 0

        If lname.Text = "" Then
            lname_err.Visible = True
            check_mandatory = check_mandatory + 1

        Else
            lname_err.Visible = False
        End If

        If fname.Text = "" Then
            check_mandatory = check_mandatory + 1
            fname_err.Visible = True
        Else
            fname_err.Visible = False
        End If

        If Sex_f.Checked = False And Sex_m.Checked = False Then
            check_mandatory = check_mandatory + 1
            gender_err.Visible = True
        Else
            gender_err.Visible = False
        End If
        If prov.Text = "" Then
            check_mandatory = check_mandatory + 1
            prov_err.Visible = True
        Else
            prov_err.Visible = False

        End If

        If Plan.Text = "" Then
            check_mandatory = check_mandatory + 1
            plan_err.Visible = True
        Else
            plan_err.Visible = False
        End If
        Return check_mandatory
    End Function

    Public Sub clear_validation()

        lname_err.Visible = False

        fname_err.Visible = False

        gender_err.Visible = False

        prov_err.Visible = False

        plan_err.Visible = False
        Health_err.Visible = False

    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete_patient.Click
        ' delete patient and associated services
        ' or Archive patient?
        Dim sql As String
        Dim objDataset As New DataSet
        Dim rl As String
        rl = MsgBox("Are you sure you want to Delete this patient and all associated service records?", vbYesNo)
        If rl = vbYes Then


            Try
                objConn.Open()
                If chart_id.Text <> "" Then

                    sql = "delete * from processed_service_record where patient_id = " & chart_id.Text


                    myCommand.Connection = objConn
                    myCommand.CommandText = sql
                    myCommand.ExecuteNonQuery()

                    sql = "delete * from patients where id = " & chart_id.Text


                    myCommand.Connection = objConn
                    myCommand.CommandText = sql
                    myCommand.ExecuteNonQuery()
                End If

            Catch ex As Exception
                objConn.Close()
                MsgBox("Error Occured in PatientClass.delete: " & ex.ToString)
            Finally
                objConn.Close()
            End Try
            clear_patient()
        End If

    End Sub

    Public Sub Save()
        Dim sql As String
        Dim objDataset As New DataSet

        Try
            objConn.Open()




            If chart_id.Text = "" Then

                If is_ohip_unique(health_num.Text) Then


                    sql = "Insert into patients"
                    sql = sql & " ("
                    sql = sql & "fname,"
                    sql = sql & "lname,"
                    sql = sql & "ohip,"
                    sql = sql & "version,"
                    sql = sql & "dob,"
                    sql = sql & "sexe,"
                    sql = sql & "province,"
                    sql = sql & "plan,"
                    sql = sql & "home_tel,"
                    sql = sql & "mobile_tel,"
                    sql = sql & "email,"
                    sql = sql & "address,"
                    sql = sql & "notes"
                    sql = sql & ")"
                    sql = sql & " Values("

                    sql = sql & "'" & fname.Text.Replace("'", "''") & "',"

                    sql = sql & "'" & lname.Text.Replace("'", "''") & "',"
                    sql = sql & "'" & health_num.Text & "',"
                    sql = sql & "'" & UCase(version.Text) & "',"
                    'sql = sql & "'" & Format(DOB.Value, "dd/MMM/yyyy") & "'," ' Patient_frm.DOB_txt.Value.Date
                    sql = sql & "'" & Format(DOB.Value, "yyyy-MM-dd") & "'," ' Patient_frm.DOB_txt.Value.Date
                    If Sex_f.Checked Then
                        sql = sql & "'F',"
                    ElseIf Sex_m.Checked Then
                        sql = sql & "'M',"
                    End If

                    sql = sql & "'" & prov.Text & "',"
                    sql = sql & "'" & Plan.Text & "',"
                    sql = sql & "'" & home_Tel.Text & "',"
                    sql = sql & "'" & cell_tel.Text & "',"
                    sql = sql & "'" & email.Text & "',"


                    sql = sql & "'" & Address.Text.Replace("'", "''") & "',"


                    sql = sql & "'" & Notes.Text.Replace("'", "''") & "'"
                    sql = sql & ")"

                    'MSAccess
                    'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                    myCommand = New MySqlCommand(sql, objConn)
                    myCommand.ExecuteNonQuery()
                    objConn.Close()
                    search_patient()
                Else
                    MsgBox("Patient already exists")
                    objConn.Close()
                    search_patient()

                End If


            Else

                sql = "update patients set "


                sql = sql & "fname ='" & fname.Text.Replace("'", "''") & "',"


                sql = sql & "lname ='" & lname.Text.Replace("'", "''") & "',"
                sql = sql & "ohip ='" & health_num.Text & "',"
                sql = sql & "version ='" & UCase(version.Text) & "',"
                'sql = sql & "dob = '" & Format(DOB.Value, "dd/MMM/yyyy") & "',"
                sql = sql & "dob = '" & Format(DOB.Value, "yyyy-MM-dd") & "',"
                If Sex_f.Checked Then
                    sql = sql & "sexe ='F',"
                ElseIf Sex_m.Checked Then
                    sql = sql & "sexe ='M',"
                End If

                sql = sql & "province ='" & prov.Text & "',"
                sql = sql & "plan ='" & Plan.Text & "', "
                sql = sql & "home_tel ='" & home_Tel.Text & "' ,"
                sql = sql & "mobile_tel ='" & cell_tel.Text & "', "
                sql = sql & "email ='" & email.Text & "', "

                sql = sql & "address ='" & Address.Text.Replace("'", "''") & "', "


                sql = sql & "notes ='" & Notes.Text.Replace("'", "''") & "' "
                sql = sql & "where id = " & chart_id.Text


                myCommand.Connection = objConn
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()


            End If




        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in PatientClass.Save : " & ex.ToString)
        Finally
            objConn.Close()


        End Try

    End Sub
    Public Sub search_patient()
        ' search for patient based on ID,OHIP,LName,Fname 
        ' IF 0 found ask to add new patient - yes show Add patient form
        ' If 1 found select and go to service date
        ' If > 1 found then display search_list and allow to select/Add new/Delete
        Try
            Dim sql As String
            Dim objDataset As New DataSet
            Dim x
            objConn.Open()

            If chart_id.Text = "" Then
                sql = "select * from patients where lname like '" & lname.Text.Replace("'", "''") & "%'"
                sql = sql & " and fname like '" & fname.Text.Replace("'", "''") & "%'"
                sql = sql & " and ohip like '" & health_num.Text & "%'"
                sql = sql & " order by lname,fname"
            Else
                sql = "select * from patients where "
                sql = sql & " id = " & chart_id.Text

            End If



            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblpatients")


            Select Case objDataset.Tables("tblpatients").Rows.Count

                Case 0



                    x = MsgBox("Patient does not exist, Do you want to add a new patient", vbYesNo)
                    If x = vbYes Then
                        With OOFSL_main.patient_reader

                            Me.clear_patient()

                            Me.health_num.Text = .health_num
                            Me.version.Text = .version_code
                            Me.DOB.Value = .dob
                            Me.fname.Text = .firstname
                            Me.lname.Text = .lastname

                            If .sex = 1 Then
                                Me.Sex_m.Checked = True
                            ElseIf .sex = 2 Then
                                Me.Sex_f.Checked = True
                            End If
                        End With

                    Else

                    End If




                Case 1

                    show_patient(objDataset.Tables("tblpatients").Rows(0))

                    If Me.health_num.Text = "" Or Me.health_num.Text = OOFSL_main.patient_reader.health_num Then


                        If OOFSL_main.patient_reader.health_num <> Nothing Then

                            With OOFSL_main.patient_reader



                                'Me.health_num.Text = .health_num
                                Me.version.Text = .version_code
                                Me.DOB.Value = .dob
                                Me.fname.Text = .firstname
                                Me.lname.Text = .lastname

                                If .sex = 1 Then
                                    Me.Sex_m.Checked = True
                                ElseIf .sex = 2 Then
                                    Me.Sex_f.Checked = True
                                End If
                            End With
                        End If

                    End If

                Case Is > 1


                    patient_management.load_patient(objDataset)
                    objConn.Close()
                    patient_management.ShowDialog()



            End Select


        Catch ex As Exception
            MsgBox("Error Occured in Patient search")
        Finally
            objConn.Close()
            objDataAdapter.Dispose()
            Save()
        End Try





    End Sub


    Public Sub selected_patient(x As Integer)
        clear_patient()
        chart_id.Text = x
        search_patient()
    End Sub


    Public Sub show_patient(d As DataRow)
        chart_id.Text = d.Item("id")
        lname.Text = d.Item("lname")
        health_num.Text = d.Item("ohip")
        fname.Text = d.Item("fname")
        version.Text = CStr("" & d.Item("version"))
        prov.Text = d.Item("province")
        Plan.Text = d.Item("plan")
        DOB.Value = d.Item("DOB")

        If d.Item("sexe") = "F" Then
            Sex_f.Checked = True
        ElseIf d.Item("sexe") = "M" Then
            Sex_m.Checked = True
        End If

        home_Tel.Text = CStr("" & d.Item("home_tel"))
        cell_tel.Text = CStr("" & d.Item("mobile_tel"))
        email.Text = CStr("" & d.Item("email"))
        Address.Text = CStr("" & d.Item("address"))
        Notes.Text = CStr("" & d.Item("notes"))

        Savebtn.Enabled = True
        go_claims.Enabled = True
        pat_history.Enabled = True
        Find.Enabled = False
        Delete_patient.Enabled = True

    End Sub

    Public Sub clear_patient()
        chart_id.Text = ""
        lname.Text = ""
        health_num.Text = ""
        fname.Text = ""
        version.Text = ""
        prov.SelectedIndex = 7
        Plan.SelectedIndex = 0
        DOB.Value = Today()

        Sex_f.Checked = False

        Sex_m.Checked = False


        home_Tel.Text = ""
        cell_tel.Text = ""
        email.Text = ""
        Address.Text = ""
        Notes.Text = ""

        Savebtn.Enabled = True
        go_claims.Enabled = False
        pat_history.Enabled = False


        Find.Enabled = True
        Delete_patient.Enabled = False
        health_num.Focus()
        clear_validation()
    End Sub





    Private Sub Find_Click(sender As Object, e As EventArgs) Handles Find.Click
        search_patient()

    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        clear_patient()
    End Sub

    Private Sub go_claims_Click(sender As Object, e As EventArgs) Handles go_claims.Click
        If chart_id.Text <> "" Then
            Claim_Entry.Claim_id.Text = ""
            Claim_Entry.Show()
            Claim_Entry.selected_patient(chart_id.Text)
            Claim_Entry.Focus()
        End If

    End Sub


    Public Function is_ohip_unique(ByVal ohip_num As String) As Boolean
        Dim sql As String

        Dim objDataset As New DataSet
        Try
            objConn2.Open()

            sql = "select * from patients where ohip = '" & ohip_num & "'"

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn2)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            Try
                Dim x As Integer = objDataAdapter.Fill(objDataset)

                If x = 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch e As Exception
                MsgBox("error in Unique module")
                Return False
            End Try

        Catch ex As Exception
            objConn2.Close()
            MsgBox("Error Occured in Patient.GetPatient : " & ex.ToString)
        Finally
            objConn2.Close()
        End Try

    End Function




    Private Sub pat_history_Click(sender As Object, e As EventArgs) Handles pat_history.Click
        If chart_id.Text <> "" Then
            Dim sql As String

            sql = "select distinct pat.fname,pat.lname,pat.ohip,pat.version,srv.id,srv.service_date,srv.service_code,srv.num_serv,srv.service_fee,cDbl(srv.num_serv*srv.service_fee) as Total_Fee "
            sql = sql & ", srv.referral as ref,srv.facility_num as inst,srv.adm_date as adm_dt,pat.dob as dob, pat.sexe as sex, cDbl('0' & srv.amountpaid) as amt_paid, srv.ExplanatoryCode as error"
            sql = sql & " from processed_service_record srv, patients pat "
            sql = sql & " where srv.patient_id = pat.id"
            sql = sql & " and srv.patient_id=" & chart_id.Text
            sql = sql & " order by srv.service_date desc, srv.id asc "

            TransactionHistory.print_reports(sql, 5)
        End If

    End Sub

    Private Sub patient_entry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If chart_id.Text <> "" Then
            Claim_Entry.selected_patient(chart_id.Text)
            Claim_Entry.Focus()
        End If
    End Sub

    Private Sub patient_entry_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub





End Class