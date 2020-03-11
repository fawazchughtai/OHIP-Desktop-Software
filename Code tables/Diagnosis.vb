Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Diagnosis
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
    Private current_servicecode As Integer = -1
    Private Sub Services_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        Dim objServiceCode As New DiagnosisClass
        objServiceCode.SetDefaults()
        objServiceCode.Reset()
        objServiceCode.load_Diagnosis()
    End Sub
    Private Sub NewService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewService.Click
        Dim objServiceCode As New DiagnosisClass
        objServiceCode.Reset()
        objServiceCode.load_Diagnosis()
    End Sub
    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        Dim objServiceCode As New DiagnosisClass
        If objServiceCode.IsValid Then
            objServiceCode.Save()
            objServiceCode.load_Diagnosis()
        End If
    End Sub
    Private Sub ServicesDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DiagnosisDataGridView.CellClick
        Dim resp As Object
        Dim objServiceCode As New DiagnosisClass
        Dim cancelServiceCodechange As Boolean = False
        If Diagnosis_frm_m = True Then
            resp = MsgBox("Would you like to save changes", MsgBoxStyle.YesNo)
            If resp = MsgBoxResult.Yes Then
                If objServiceCode.IsValid Then
                    objServiceCode.Save()
                    objServiceCode.load_Diagnosis()
                Else
                    cancelServiceCodechange = True
                End If
            End If
            Diagnosis_frm_m = False
        End If
        If Not cancelServiceCodechange Then
            If e.RowIndex <> -1 Then


                current_servicecode = DiagnosisDataGridView.Rows(e.RowIndex).Cells("id").Value
                objServiceCode.ID = DiagnosisDataGridView.Rows(e.RowIndex).Cells("id").Value
                objServiceCode.GetServiceCode()
            End If
        End If

    End Sub
    Private Sub DeleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click
        Dim intResponse As Object
        intResponse = MsgBox("Are you sure you want to delete?", vbYesNo + vbQuestion, "Delete Diagnosis")

        If intResponse = vbYes Then
            Dim objServiceCode As New DiagnosisClass
            objServiceCode.delete()
            objServiceCode.Reset()
            objServiceCode.load_Diagnosis()
        End If
    End Sub
    Private Sub AnyServiceFormChangeEvent() Handles DescriptionTxt.KeyUp, ServiceCodeTxt.KeyUp
        Diagnosis_frm_m = True
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub
End Class