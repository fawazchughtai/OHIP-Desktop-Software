Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class DiagnosisClass
    Private class_DiagnosisID As String
    Private class_DiagnosisDescription As String
    Private class_DiagnosisServiceCode As String
    Private class_DiagnosisServiceFee As String
    Private class_DiagnosisReferalRequired As String
    Private class_DiagnosisDefaultCode As String
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

    ' mySQL
    'Private conn As New MySql.Data.MySqlClient.MySqlConnection
    'Private myCommand As New MySql.Data.MySqlClient.MySqlCommand
    'Private myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
    'Private myData As New DataTable
    'Private objConn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection("server=localhost;userid=root;password=boomer;database=oofsl")
    'Private objDataAdapter As MySql.Data.MySqlClient.MySqlDataAdapter
    Public Property ID() As String
        Set(ByVal value As String)
            class_DiagnosisID = value.ToString
        End Set
        Get
            Return class_DiagnosisID
        End Get
    End Property
    Public Property Description() As String
        Set(ByVal value As String)
            class_DiagnosisDescription = value.ToString
        End Set
        Get
            Return class_DiagnosisDescription
        End Get
    End Property
    Public Sub SetDefaults()
        Diagnosis.DiagnosisDataGridView.Columns.Add("code", "Code")
        '       Diagnosis.DiagnosisDataGridView.Columns("code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Diagnosis.DiagnosisDataGridView.Columns.Add("description", "Description")
        Diagnosis.DiagnosisDataGridView.Columns("description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Diagnosis.DiagnosisDataGridView.Columns.Add("id", "ID")
        Diagnosis.DiagnosisDataGridView.Columns("id").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Diagnosis.DiagnosisDataGridView.RowHeadersVisible = False
        current_diagnosiscode = -1
    End Sub
    Public Sub Save()
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            If current_diagnosiscode = -1 Then

                sql = "Insert into diagnosis"
                sql = sql & " ("
                sql = sql & "description,"
                sql = sql & "code"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & Diagnosis.DescriptionTxt.Text & "',"
                sql = sql & "'" & Diagnosis.ServiceCodeTxt.Text & "'"
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
                sql = "select MAX(ID) from diagnosis"
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                current_diagnosiscode = myCommand.ExecuteScalar()
                objConn.Close()
                Diagnosis_frm_m = False

            Else

                sql = "update diagnosis set "
                sql = sql & "description ='" & Diagnosis.DescriptionTxt.Text & "',"
                sql = sql & "code ='" & Diagnosis.ServiceCodeTxt.Text & "'"
                sql = sql & "where id = " & current_diagnosiscode

                myCommand.Connection = objConn
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
                objConn.Close()
                Diagnosis_frm_m = False
            End If

        Catch ex As Exception
            MsgBox("Error Occured in PatientClass.Save : " & ex.ToString)
        Finally

        End Try

    End Sub
    Public Sub Reset()
        Try
            Diagnosis.DescriptionTxt.Text = ""
            Diagnosis.ServiceCodeTxt.Text = ""
            Diagnosis.DescriptionIsValidLabel.Visible = False
            Diagnosis.ServiceCodeIsValidLabel.Visible = False
            Diagnosis.DiagnosisDataGridView.Rows.Clear()
            current_diagnosiscode = -1
            Diagnosis_frm_m = False
        Catch ex As Exception
            MsgBox("Error Occured in DiagnosisCodeClass.Reset : " & ex.ToString)
        End Try

    End Sub
    Public Sub load_Diagnosis()
        Dim sql As String
        Dim objDataset As New DataSet
        Dim i As Integer
        Diagnosis_frm_m = False
        Try
            objConn.Open()

            sql = "select * from diagnosis "

            'mySQL
            'objDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, objConn)

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblDiagnosis")
            Diagnosis.DiagnosisDataGridView.Rows.Clear()

            Diagnosis.DiagnosisDataGridView.ReadOnly = True
            Diagnosis.DiagnosisDataGridView.AllowUserToAddRows = False

            Diagnosis.DiagnosisDataGridView.BackgroundColor = Color.LightGray
            Diagnosis.DiagnosisDataGridView.BorderStyle = BorderStyle.Fixed3D

            ' Set property values appropriate for read-only display and 
            ' limited interactivity. 
            Diagnosis.DiagnosisDataGridView.AllowUserToAddRows = False
            Diagnosis.DiagnosisDataGridView.AllowUserToDeleteRows = False
            Diagnosis.DiagnosisDataGridView.AllowUserToOrderColumns = True
            Diagnosis.DiagnosisDataGridView.ReadOnly = True
            Diagnosis.DiagnosisDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Diagnosis.DiagnosisDataGridView.MultiSelect = False
            Diagnosis.DiagnosisDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            Diagnosis.DiagnosisDataGridView.AllowUserToResizeColumns = False
            'Patient_frm.PatientServiceHistoryDataGrid.ColumnHeadersHeightSizeMode = _
            '    DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Diagnosis.DiagnosisDataGridView.AllowUserToResizeRows = False
            'Patient_frm.PatientServiceHistoryDataGrid.RowHeadersWidthSizeMode = _
            '    DataGridViewRowHeadersWidthSizeMode.DisableResizing

            ' Set the selection background color for all the cells.
            Diagnosis.DiagnosisDataGridView.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            Diagnosis.DiagnosisDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black

            ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            Diagnosis.DiagnosisDataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

            For i = 0 To objDataset.Tables("tblDiagnosis").Rows.Count - 1
                Diagnosis.DiagnosisDataGridView.Rows.Add()
                Diagnosis.DiagnosisDataGridView.Rows(i).Cells("id").Value = objDataset.Tables("tblDiagnosis").Rows(i).Item("id")
                Diagnosis.DiagnosisDataGridView.Rows(i).Cells("description").Value = objDataset.Tables("tblDiagnosis").Rows(i).Item("description")
                Diagnosis.DiagnosisDataGridView.Rows(i).Cells("code").Value = objDataset.Tables("tblDiagnosis").Rows(i).Item("code")
            Next
            Diagnosis.DiagnosisDataGridView.ReadOnly = True
            Diagnosis.DiagnosisDataGridView.AllowUserToAddRows = False
            Diagnosis.DiagnosisDataGridView.Columns("id").Visible = False

            objConn.Close()

        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in ServiceCodeClass.load_Diagnosis : " & ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub GetServiceCode()

        Try

            Dim sql As String
            Dim objDataset As New DataSet

            objConn.Open()

            sql = "select * from diagnosis where id = " & class_DiagnosisID

            'mySQL
            'objDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, objConn)

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tbldiagnosis")

            current_diagnosiscode = objDataset.Tables(0).Rows(0).Item("id")
            Diagnosis.DescriptionTxt.Text = objDataset.Tables(0).Rows(0).Item("description")
            Diagnosis.ServiceCodeTxt.Text = objDataset.Tables(0).Rows(0).Item("code")
            objConn.Close()


        Catch ex As Exception
            MsgBox("Error Occured in ServiceDatesClass.GetServiceInfo : " & ex.ToString)
        Finally
            objDataAdapter.Dispose()
        End Try

    End Sub
    Public Sub delete()
        Dim sql As String
        Try
            objConn.Open()
            sql = "delete from diagnosis where id = " & current_diagnosiscode
            myCommand.Connection = objConn
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
            current_diagnosiscode = -1
            objConn.Close()
            Diagnosis_frm_m = False
            Reset()
            load_Diagnosis()
        Catch ex As Exception
            MsgBox("Error Occured in ServiceDatesClass.Delete : " & ex.ToString)
        Finally

        End Try


    End Sub

    Public Function IsValid() As Boolean

        Dim class_IsValid As Boolean = True

        If Diagnosis.DescriptionTxt.Text = "" Then
            Diagnosis.DescriptionIsValidLabel.Visible = True
            class_IsValid = False
        Else
            Diagnosis.DescriptionIsValidLabel.Visible = False
        End If

        If Diagnosis.ServiceCodeTxt.Text = "" Then
            Diagnosis.ServiceCodeIsValidLabel.Visible = True
            class_IsValid = False
        Else
            Diagnosis.ServiceCodeIsValidLabel.Visible = False
        End If

        Return class_IsValid

    End Function


End Class
