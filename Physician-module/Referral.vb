
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Referral
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
    Private current_referral As Integer = -1

    ' mySQL
    'Private conn As New MySql.Data.MySqlClient.MySqlConnection
    'Private myCommand As New MySql.Data.MySqlClient.MySqlCommand
    'Private myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
    'Private myData As New DataTable
    'Private objConn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection("server=localhost;userid=root;password=boomer;database=oofsl")
    'Private objDataAdapter As MySql.Data.MySqlClient.MySqlDataAdapter

    Private Sub Referral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReferralDataGridView.Columns.Add("name", "Physician Name")
        ReferralDataGridView.Columns("name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ReferralDataGridView.Columns.Add("OHIP_Referral", "Provider Number")
        ReferralDataGridView.Columns("OHIP_Referral").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ReferralDataGridView.Columns.Add("id", "ID")
        ReferralDataGridView.Columns("id").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ReferralDataGridView.RowHeadersVisible = False
        current_referral = -1
        load_referral()
    End Sub
    Private Sub NewService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewService.Click
        Me.PhysicianNameTxt.Text = ""
        Me.OHIPRegistrationNumberTxt.Text = ""
        current_referral = -1
    End Sub
    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            If current_referral = -1 Then
                sql = "Insert into referral"
                sql = sql & " ("
                sql = sql & "name,"
                sql = sql & "OHIP_Referral"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & Me.PhysicianNameTxt.Text & "',"
                sql = sql & "'" & Me.OHIPRegistrationNumberTxt.Text & "'"
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
                sql = "select MAX(ID) from referral"
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                current_referral = myCommand.ExecuteScalar()
                objConn.Close()
                ReferralDataGridView.Rows.Clear()
                load_referral()
                referral_frm_m = False

            Else

                sql = "update referral set "
                sql = sql & "name ='" & Me.PhysicianNameTxt.Text & "',"
                sql = sql & "OHIP_Referral ='" & Me.OHIPRegistrationNumberTxt.Text & "'"
                sql = sql & "where id = " & current_referral

                myCommand.Connection = objConn
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
                objConn.Close()
                referral_frm_m = False
                ReferralDataGridView.Rows.Clear()
                load_referral()

            End If

        Catch ex As Exception
            MsgBox("Error Occured in referral.Save : " & ex.ToString)
        Finally
        End Try

    End Sub
    Private Sub ReferralDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReferralDataGridView.CellClick

        If e.RowIndex >= 0 Then
            current_referral = ReferralDataGridView.Rows(e.RowIndex).Cells("id").Value

            Dim sql As String
            Dim objDataset As New DataSet

            objConn.Open()

            sql = "select * from referral where id = " & current_referral

            'mySQL
            objDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, objConn)

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblereferral")

            current_referral = objDataset.Tables(0).Rows(0).Item("id")
            Me.PhysicianNameTxt.Text = objDataset.Tables(0).Rows(0).Item("name")
            Me.OHIPRegistrationNumberTxt.Text = objDataset.Tables(0).Rows(0).Item("OHIP_Referral")
        End If

        Try

        Catch ex As Exception
            MsgBox("Error Occured in Referfal.ReferralDataGridView_CellContentClick : " & ex.ToString)
        Finally
            objConn.Close()
            objDataAdapter.Dispose()
        End Try
    End Sub
    Private Sub load_referral()
        Dim sql As String
        Dim objDataset As New DataSet
        Dim i As Integer

        Try
            objConn.Open()

            sql = "select * from referral"

            'mySQL
            objDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, objConn)

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblereferral")

            For i = 0 To objDataset.Tables("tblereferral").Rows.Count - 1
                ReferralDataGridView.Rows.Add()
                ReferralDataGridView.Rows(i).Cells("id").Value = objDataset.Tables("tblereferral").Rows(i).Item("id")
                ReferralDataGridView.Rows(i).Cells("name").Value = objDataset.Tables("tblereferral").Rows(i).Item("name")
                ReferralDataGridView.Rows(i).Cells("OHIP_Referral").Value = objDataset.Tables("tblereferral").Rows(i).Item("OHIP_Referral")
            Next
            ReferralDataGridView.ReadOnly = True
            ReferralDataGridView.AllowUserToAddRows = False
            ReferralDataGridView.Columns("id").Visible = False

        Catch ex As Exception
            MsgBox("Error Occured in Referral.load_referral : " & ex.ToString)
        Finally
            objConn.Close()
        End Try

    End Sub

    Private Sub DeleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click
        Dim intResponse As Object
        intResponse = MsgBox("Are you sure you want to delete?", vbYesNo + vbQuestion, "Delete Physician")

        If intResponse = vbYes Then

            Dim sql As String

            Try
                objConn.Open()
                sql = "delete from referral where id = " & current_referral
                myCommand.Connection = objConn
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
                current_referral = -1
                objConn.Close()
                referral_frm_m = False
                ReferralDataGridView.Rows.Clear()
                load_referral()

            Catch ex As Exception
                MsgBox("Error Occured in referral.Delete : " & ex.ToString)
            Finally

            End Try
        End If
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub


End Class