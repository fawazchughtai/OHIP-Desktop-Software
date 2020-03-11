Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class patient_management

    Dim patients As New DataSet
    'Private myCommand As New System.Data.OleDb.OleDbCommand
    'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
    Private myCommand As New MySqlCommand
    Private myAdapter As MySqlDataAdapter
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objDataAdapter As MySqlDataAdapter

    Private Sub patient_management_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Public Sub load_patient(ByRef patients As DataSet)


        patients_list.Columns.Clear()
        patients_list.Columns.Add("id", "Chart #")
        patients_list.Columns.Add("name", "Last Name, First Name")
        patients_list.Columns("name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        patients_list.Columns("id").Visible = False
        patients_list.RowHeadersVisible = False
        patients_list.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'Dim sql As String = ""
        Dim i As Integer
        'objConn.Open()
        'sql = "select id,lname,fname from patients where ohip like '" & x & "%'"
        'sql = sql + " order by lname asc,fname asc"




        'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)

        'objDataAdapter.Fill(patients, "tblpatients")

        For i = 0 To patients.Tables("tblpatients").Rows.Count - 1

            patients_list.Rows.Add()
            patients_list.Rows(i).Cells("id").Value = patients.Tables("tblpatients").Rows(i).Item("id")
            patients_list.Rows(i).Cells("name").Value = patients.Tables("tblpatients").Rows(i).Item("lname") & ", " & patients.Tables("tblpatients").Rows(i).Item("fname")


        Next



        'objConn.Close()
    End Sub


    Private Sub patients_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles patients_list.CellClick



        'patients_list.Rows(e.RowIndex)
        If e.RowIndex >= 0 Then
            Claim_Entry.Claim_id.Text = ""
            Claim_Entry.selected_patient(patients_list.Rows(e.RowIndex).Cells("id").Value)

            patient_entry.selected_patient(patients_list.Rows(e.RowIndex).Cells("id").Value)
            Me.Close()
        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles New_btn.Click
        patient_entry.Show()
        patient_entry.Focus()

    End Sub

    Private Sub patients_list_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles patients_list.CellContentClick

    End Sub
End Class