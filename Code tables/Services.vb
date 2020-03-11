Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Services
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
        Dim objServiceCode As New ServiceCodes
        objServiceCode.SetDefaults()
        objServiceCode.Reset()
        objServiceCode.load_services()
    End Sub
    Private Sub NewService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewService.Click
        Dim objServiceCode As New ServiceCodes
        objServiceCode.Reset()
        objServiceCode.load_services()
    End Sub

    Private Sub ServicesDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ServicesDataGridView.CellClick
        Dim resp As Object
        Dim objServiceCode As New ServiceCodes
        Dim cancelServiceCodechange As Boolean = False
        If services_frm_m = True Then
            resp = MsgBox("Would you like to save changes", MsgBoxStyle.YesNo)
            If resp = MsgBoxResult.Yes Then
                If objServiceCode.IsValid Then
                    objServiceCode.Save()
                    objServiceCode.load_services()
                Else
                    cancelServiceCodechange = True
                End If
            End If
            services_frm_m = False
        End If
        If Not cancelServiceCodechange Then
            Me.DescriptionIsValidLabel.Visible = False
            Me.ServiceCodeIsValidLabel.Visible = False
            Me.ServiceFeeIsValidLabel.Visible = False
            Me.RequiersRefferalCode.Checked = False
            Me.DefaultServiceCode.Checked = False


            If e.RowIndex <> -1 Then

                current_servicecode = ServicesDataGridView.Rows(e.RowIndex).Cells("id").Value
                objServiceCode.ID = ServicesDataGridView.Rows(e.RowIndex).Cells("id").Value
                objServiceCode.GetServiceCode()
            End If
        End If
        If e.ColumnIndex = 5 Then

        End If



    End Sub
    Private Sub DeleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click
        Dim intResponse As Object
        intResponse = MsgBox("Are you sure you want to delete?", vbYesNo + vbQuestion, "Delete Service")
        If intResponse = vbYes Then
            Dim objServiceCode As New ServiceCodes
            objServiceCode.delete()
            objServiceCode.Reset()
            objServiceCode.load_services()
        End If
    End Sub
    Private Sub DefaultServiceCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultServiceCode.Click
        Dim resp As Object
        If DefaultServiceCode.Checked Then
            resp = MsgBox("Setting service as Default will cancel any perviously set default service code. Do you wish to continue?", MsgBoxStyle.YesNo)
            If resp = MsgBoxResult.No Then
                DefaultServiceCode.Checked = False
            End If
        End If
    End Sub
    Private Sub AnyServiceFormChangeEvent() Handles DescriptionTxt.KeyUp, ServiceCodeTxt.KeyUp, ServiceFeeTxt.KeyUp, RequiersRefferalCode.Click, DefaultServiceCode.Click
        services_frm_m = True
    End Sub

    Private Sub ServiceFeeTxt_FormatCurrency() Handles ServiceFeeTxt.LostFocus
        If Not Me.ServiceFeeTxt.Text = vbNull Then
            Me.ServiceFeeTxt.Text = FormatCurrency(Me.ServiceFeeTxt.Text, 2)
        End If
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub


    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click

        If Me.ServiceCodeTxt.Text.Length = 5 Then



            Dim objServiceCode As New ServiceCodes
            objServiceCode.ServiceCode = Me.ServiceCodeTxt.Text
            objServiceCode.ServiceFee = Me.ServiceFeeTxt.Text
            objServiceCode.Description = Me.DescriptionTxt.Text
            ' objServiceCode.ReferalRequired = Me.RequiersRefferalCode.Checked.ToString
            objServiceCode.Save()
        Else
            MsgBox("Service codes have to be in the format of A###A - example A005A")
        End If

    End Sub


End Class