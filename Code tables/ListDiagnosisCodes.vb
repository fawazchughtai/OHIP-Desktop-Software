Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class ListDiagnosisCodes
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


    Private Sub ListDiagnosisCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim objDataset As New DataSet
        Dim DiagnosisCodeList As New System.Collections.Generic.List(Of FillReferralListBoxClass)

        Try
            objConn.Open()
            sql = "select * from diagnosis order by description"

            'mySQL
            objDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, objConn)

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblDiagnosisCode")

            Dim CodeList As New ArrayList()
            CodeList.Clear()

            For Each rs As DataRow In objDataset.Tables("tblDiagnosisCode").Rows 'Loops through Rows
                CodeList.Add(New FillDiagnosisListBoxClass(rs.Item("code").ToString, rs.Item("description").ToString))
            Next

            Me.DiagnosisCodeListBox.DataSource = CodeList
            Me.DiagnosisCodeListBox.DisplayMember = "listDiagnosisCode"
            Me.DiagnosisCodeListBox.ValueMember = "listDiagnosisDescription"

        Catch ex As Exception
            MsgBox("Error Occured in listDiagnosisCode.ListDiagnosisCodes_Load : " & ex.ToString)
        Finally
            objConn.Close()
            objDataAdapter.Dispose()
        End Try

    End Sub
    Private Sub OKbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKbtn.Click
        Claim_Entry.Diagnosis.Text = Me.DiagnosisCodeListBox.SelectedValue.ToString()
        Me.Close()
    End Sub

    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        Me.Close()
    End Sub
    Private Sub ServiceCodeListBox_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DiagnosisCodeListBox.DoubleClick

        Claim_Entry.Diagnosis.Text = Me.DiagnosisCodeListBox.SelectedValue.ToString()
        Me.Close()
    End Sub


End Class