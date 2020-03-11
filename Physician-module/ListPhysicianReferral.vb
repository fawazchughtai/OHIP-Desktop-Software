
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class ListPhysicianReferral
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
    Private Sub ListPhysicianReferral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_ref_dr()
    End Sub
    Private Sub OKbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKbtn.Click
        Claim_Entry.Referring.Text = Me.PhysicianReferralListBox.SelectedValue.ToString()
        Me.Close()
    End Sub

    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        Me.Close()
    End Sub
    Private Sub ServiceCodeListBox_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PhysicianReferralListBox.DoubleClick
        Claim_Entry.Referring.Text = Me.PhysicianReferralListBox.SelectedValue.ToString()
        Me.Close()
    End Sub


    Public Sub select_item()
        Claim_Entry.Referring.Text = Me.ref_list.SelectedValue.ToString

        Me.Close()
    End Sub


    Public Sub load_ref_dr()
        Dim sql As String
        Dim objDataset As New DataSet
        Dim PhysicianReferralList As New System.Collections.Generic.List(Of FillReferralListBoxClass)


        Try
            objConn.Open()
            sql = "select Name,OHIP_Referral from referral order by Name"

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)


            objDataAdapter.Fill(objDataset, "tblphysicianreferral")

            If objDataset.Tables(0).Rows.Count > 0 Then

                Dim CodeList As New ArrayList()
                CodeList.Clear()



                CodeList.Add(New FillReferralListBoxClass("None", ""))
                For Each rs As DataRow In objDataset.Tables("tblphysicianreferral").Rows 'Loops through Rows
                    CodeList.Add(New FillReferralListBoxClass(rs.Item("Name").ToString, rs.Item("OHIP_Referral").ToString))





                Next
                ref_list.DataSource = CodeList
                ref_list.DisplayMember = "listPhysicianName"
                ref_list.ValueMember = "listReferralCode"

                Claim_Entry.ref_dr_list.DataSource = CodeList
                Claim_Entry.ref_dr_list.DisplayMember = "listPhysicianName"
                Claim_Entry.ref_dr_list.ValueMember = "listReferralCode"

                Claim_Entry.ref_dr_list.SelectedValue = ""

                Me.PhysicianReferralListBox.DataSource = CodeList
                Me.PhysicianReferralListBox.DisplayMember = "listPhysicianName"
                Me.PhysicianReferralListBox.ValueMember = "listReferralCode"
            Else
                Me.OKbtn.Enabled = False
            End If


        Catch ex As Exception
            MsgBox("Error Occured in ListServiceCodes.ListServiceCodes_Load : " & ex.ToString)
        Finally
            objConn.Close()
            objDataAdapter.Dispose()
        End Try

    End Sub






End Class