Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class ServiceCodes
    Private class_ServicesID As String
    Private class_ServicesDescription As String
    Private class_ServicesServiceCode As String
    Private class_ServicesServiceFee As String
    Private class_ServicesReferalRequired As String
    Private class_ServicesDefaultCode As String
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

    Public Property ID() As String
        Set(ByVal value As String)
            class_ServicesID = value.ToString
        End Set
        Get
            Return class_ServicesID
        End Get
    End Property
    Public Property Description() As String
        Set(ByVal value As String)
            class_ServicesDescription = value.ToString
        End Set
        Get
            Return class_ServicesDescription
        End Get
    End Property
    Public Property ServiceCode() As String
        Set(ByVal value As String)
            class_ServicesServiceCode = value.ToString
        End Set
        Get
            Return class_ServicesServiceCode
        End Get
    End Property
    Public Property ServiceFee() As String
        Set(ByVal value As String)
            class_ServicesServiceFee = value.ToString
        End Set
        Get
            Return class_ServicesServiceFee
        End Get
    End Property
    Public Property ReferalRequired() As String
        Set(ByVal value As String)
            class_ServicesReferalRequired = value.ToString
        End Set
        Get
            Return class_ServicesReferalRequired
        End Get
    End Property
    Public Property ServicesDefaultCode() As String
        Set(ByVal value As String)
            class_ServicesDefaultCode = value.ToString
        End Set
        Get
            Return class_ServicesDefaultCode
        End Get
    End Property
    Public Sub SetDefaults()
        Services.ServicesDataGridView.AllowUserToOrderColumns = True

        Services.ServicesDataGridView.Columns.Add("servicecode", "Service Code")
        'Services.ServicesDataGridView.Columns("servicecode").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Services.ServicesDataGridView.Columns.Add("description", "Description")
        Services.ServicesDataGridView.Columns("description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Services.ServicesDataGridView.Columns.Add("servicefee", "Service Fee")
        'Services.ServicesDataGridView.Columns("servicefee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Services.ServicesDataGridView.Columns.Add("id", "ID")
        Services.ServicesDataGridView.Columns("id").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Services.ServicesDataGridView.RowHeadersVisible = False
        Services.ServicesDataGridView.Columns("id").Visible = False


        'current_servicecode = -1
    End Sub
    Public Sub Save()
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            If current_servicecode = -1 Then

                If Services.DefaultServiceCode.Checked Then
                    sql = "update services set "
                    sql = sql & "defaultcode = '0'"
                    myCommand.Connection = objConn
                    myCommand.CommandText = sql
                    myCommand.ExecuteNonQuery()
                End If

                sql = "Insert into services"
                sql = sql & " ("
                sql = sql & "description,"
                sql = sql & "servicecode,"
                sql = sql & "servicefee"
                'sql = sql & "referalrequired,"
                'sql = sql & "defaultcode"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & class_ServicesDescription & "',"
                sql = sql & "'" & class_ServicesServiceCode & "',"
                sql = sql & "'" & FormatNumber(class_ServicesServiceFee, 2) & "'"
                'sql = sql & "'" & class_ServicesReferalRequired & "',"
                'sql = sql & "'0'"
                sql = sql & ")"

                'mySQL
                'myCommand.Connection = objConn
                'myCommand.CommandText = sql
                'myCommand.ExecuteNonQuery()
                'class_patientID = myCommand.LastInsertedId()

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                sql = "select MAX(ID) from services"
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                current_servicecode = myCommand.ExecuteScalar()
                objConn.Close()
                services_frm_m = False

            Else

                'If Services.DefaultServiceCode.Checked Then
                '    sql = "update services set "
                '    sql = sql & "defaultcode = '0'"
                '    myCommand.Connection = objConn
                '    myCommand.CommandText = sql
                '    myCommand.ExecuteNonQuery()
                'End If

                sql = "update services set "
                sql = sql & "description ='" & class_ServicesDescription & "',"
                sql = sql & "servicecode ='" & class_ServicesServiceCode & "',"
                sql = sql & "servicefee ='" & FormatNumber(class_ServicesServiceFee, 2) & "'"
                'sql = sql & "referalrequired= '" & class_ServicesReferalRequired & "',"
                'sql = sql & "defaultcode = '0'"
                sql = sql & "where id = " & current_servicecode

                myCommand.Connection = objConn
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()

                'sql = "update service_record set "
                'sql = sql & "service_fee ='" & FormatNumber(class_ServicesServiceFee, 2) & "' "
                'sql = sql & "where service_code = '" & class_ServicesServiceCode & "'"
                'myCommand.Connection = objConn
                'myCommand.CommandText = sql
                'myCommand.ExecuteNonQuery()

                objConn.Close()
                services_frm_m = False
            End If

            sql = "UPDATE services INNER JOIN available_services ON services.ServiceCode = available_services.ServiceCode SET services.Description = [available_services].[Description],  services.Referalrequired = [available_services].[Referalrequired], services.num_services = [available_services].[num_services], services.diagnosis = [available_services].[diagnosis], services.adm = [available_services].[adm], services.facility = [available_services].[facility];"
            'service_record.service_date >=format("1/12/2012",'dd/MM/yyyy');
            'MSAccess
            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()

        Catch ex As Exception
            MsgBox("Error Occured in PatientClass.Save : " & ex.ToString)
        Finally

        End Try

    End Sub
    Public Sub Reset()
        Try
            Services.DescriptionTxt.Text = ""
            Services.ServiceCodeTxt.Text = ""
            Services.ServiceFeeTxt.Text = ""
            Services.DescriptionIsValidLabel.Visible = False
            Services.ServiceCodeIsValidLabel.Visible = False
            Services.ServiceFeeIsValidLabel.Visible = False
            Services.RequiersRefferalCode.Checked = False
            Services.DefaultServiceCode.Checked = False
            Services.ServicesDataGridView.Rows.Clear()
            current_servicecode = -1
            services_frm_m = False
        Catch ex As Exception
            MsgBox("Error Occured in ServicesCodeClass.Reset : " & ex.ToString)
        End Try

    End Sub
    Public Sub load_services()
        Dim sql As String
        Dim objDataset As New DataSet
        Dim i As Integer
        services_frm_m = False
        Try
            objConn.Open()

            sql = "select * from services order by servicecode"

            'mySQL
            objDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, objConn)

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblservices")
            Services.ServicesDataGridView.Rows.Clear()

            Services.ServicesDataGridView.ReadOnly = True
            Services.ServicesDataGridView.AllowUserToAddRows = False

            Services.ServicesDataGridView.BackgroundColor = Color.LightGray
            Services.ServicesDataGridView.BorderStyle = BorderStyle.Fixed3D

            ' Set property values appropriate for read-only display and 
            ' limited interactivity. 
            Services.ServicesDataGridView.AllowUserToAddRows = False
            Services.ServicesDataGridView.AllowUserToDeleteRows = False
            Services.ServicesDataGridView.AllowUserToOrderColumns = True
            Services.ServicesDataGridView.ReadOnly = True
            Services.ServicesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Services.ServicesDataGridView.MultiSelect = False
            Services.ServicesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            Services.ServicesDataGridView.AllowUserToResizeColumns = False
            'Patient_frm.PatientServiceHistoryDataGrid.ColumnHeadersHeightSizeMode = _
            '    DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Services.ServicesDataGridView.AllowUserToResizeRows = False
            'Patient_frm.PatientServiceHistoryDataGrid.RowHeadersWidthSizeMode = _
            '    DataGridViewRowHeadersWidthSizeMode.DisableResizing

            ' Set the selection background color for all the cells.
            Services.ServicesDataGridView.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            Services.ServicesDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black

            ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            Services.ServicesDataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

            For i = 0 To objDataset.Tables("tblservices").Rows.Count - 1
                Services.ServicesDataGridView.Rows.Add()
                Services.ServicesDataGridView.Rows(i).Cells("id").Value = objDataset.Tables("tblservices").Rows(i).Item("id")
                Services.ServicesDataGridView.Rows(i).Cells("description").Value = objDataset.Tables("tblservices").Rows(i).Item("description")
                Services.ServicesDataGridView.Rows(i).Cells("servicecode").Value = objDataset.Tables("tblservices").Rows(i).Item("servicecode")
                Services.ServicesDataGridView.Rows(i).Cells("servicefee").Value = FormatCurrency(objDataset.Tables("tblservices").Rows(i).Item("servicefee"), 2)
            Next
            Services.ServicesDataGridView.ReadOnly = True
            Services.ServicesDataGridView.AllowUserToAddRows = False


            objConn.Close()

        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in ServiceCodeClass.load_services : " & ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub GetServiceCode()

        Try

            Dim sql As String
            Dim objDataset As New DataSet

            objConn.Open()

            sql = "select * from services where id = " & class_ServicesID

            'mySQL
            objDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, objConn)

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblservice")

            current_servicecode = objDataset.Tables(0).Rows(0).Item("id")
            Services.DescriptionTxt.Text = objDataset.Tables(0).Rows(0).Item("description")
            Services.ServiceCodeTxt.Text = objDataset.Tables(0).Rows(0).Item("servicecode")
            Services.ServiceFeeTxt.Text = FormatCurrency(objDataset.Tables(0).Rows(0).Item("servicefee"), 2)

            'If objDataset.Tables(0).Rows(0).Item("referalrequired") = "1" Then
            '    Services.RequiersRefferalCode.Checked = True
            'Else
            '    Services.RequiersRefferalCode.Checked = False
            'End If
            'If objDataset.Tables(0).Rows(0).Item("defaultcode") = "1" Then
            '    Services.DefaultServiceCode.Checked = True
            'Else
            '    Services.DefaultServiceCode.Checked = False
            'End If

            objConn.Close()


        Catch ex As Exception
            MsgBox("Error Occured in ServiceDatesClass.GetServiceInfo ")
        Finally
            objDataAdapter.Dispose()
        End Try

    End Sub
    Public Sub delete()
        Dim sql As String
        Try
            objConn.Open()
            sql = "delete from services where id = " & current_servicecode
            myCommand.Connection = objConn
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
            current_servicecode = -1
            objConn.Close()
            services_frm_m = False
            Reset()
            load_services()
        Catch ex As Exception
            MsgBox("Error Occured in ServiceDatesClass.Delete : " & ex.ToString)
        Finally

        End Try


    End Sub

    Public Function IsValid() As Boolean

        Dim class_IsValid As Boolean = True

        If class_ServicesDescription = "" Then
            Services.DescriptionIsValidLabel.Visible = True
            class_IsValid = False
        Else
            Services.DescriptionIsValidLabel.Visible = False
        End If

        If class_ServicesServiceCode = "" Then
            Services.ServiceCodeIsValidLabel.Visible = True
            class_IsValid = False
        Else
            Services.ServiceCodeIsValidLabel.Visible = False
        End If

        If class_ServicesServiceFee = "" Then
            Services.ServiceFeeIsValidLabel.Visible = True
            class_IsValid = False
        Else
            Dim objCommon As New CommonClass

        End If

        Return class_IsValid

    End Function


End Class
