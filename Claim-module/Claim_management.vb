Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Claim_management
    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)




    Public Sub add_year_to_tree(x As TreeNode, status As Integer)
        '    Dim sql As String = ""
        '    Dim objDataset As New DataSet
        '    Dim i As Integer
        '    Dim claim_type As String = "oClaims"


        '    Select Case status
        '        Case 0
        '            sql = "SELECT distinct format(service_date,'dd-mmm-yyyy') as yrs"
        '            sql = sql + " FROM service_record WHERE status=0"
        '            claim_type = "oClaims"
        '        Case 1
        '            sql = "SELECT distinct format(service_date,'dd-mmm-yyyy') as yrs"
        '            sql = sql + " FROM processed_service_record WHERE status=1"
        '            sql = sql + " and processed_file='" & x.Text & "'"
        '            claim_type = "cClaims"
        '    End Select


        '    Try

        '        objConn.Open()



        '        objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
        '        objDataAdapter.Fill(objDataset, "tblyears")

        '        x.Nodes.Clear()


        '        For i = 0 To objDataset.Tables("tblyears").Rows.Count - 1
        '            x.Nodes.Add(claim_type, objDataset.Tables("tblyears").Rows(i).Item("yrs"))
        '        Next




        '        objConn.Close()

        '    Catch ex As Exception

        '        objConn.Close()

        '    End Try


    End Sub

    Public Sub add_batch_to_tree(x As TreeNode)
        '    Dim sql As String = ""
        '    Dim objDataset As New DataSet
        '    Dim i As Integer

        '    sql = "SELECT distinct processed_file as batch"
        '    sql = sql + " FROM processed_service_record WHERE status=1"

        '    Try

        '        objConn.Open()



        '        objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
        '        objDataAdapter.Fill(objDataset, "tblbatch")

        '        x.Nodes.Clear()


        '        For i = 0 To objDataset.Tables("tblbatch").Rows.Count - 1
        '            x.Nodes.Add("cBatch", objDataset.Tables("tblbatch").Rows(i).Item("batch"))
        '        Next




        '        objConn.Close()

        '    Catch ex As Exception

        '        objConn.Close()

        '    End Try


    End Sub



    Public Sub add_claims_to_tree(x As TreeNode, status As Integer)
        '    Dim sql As String = ""
        '    Dim objDataset As New DataSet
        '    Dim i As Integer

        '    Select Case status
        '        Case 0
        '            sql = "SELECT distinct patient_id as Chart"
        '            sql = sql + " FROM service_record WHERE status=0"
        '            sql = sql + " and service_date=#" & x.Text & "#"
        '        Case 1
        '            sql = "SELECT distinct patient_id as Chart"
        '            sql = sql + " FROM processed_service_record WHERE status=1"
        '            sql = sql + " and service_date=#" & x.Text & "#"

        '    End Select




        '    Try

        '        objConn.Open()



        '        objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
        '        objDataAdapter.Fill(objDataset, "tblyears")

        '        x.Nodes.Clear()


        '        For i = 0 To objDataset.Tables("tblyears").Rows.Count - 1
        '            x.Nodes.Add("claims", objDataset.Tables("tblyears").Rows(i).Item("Chart"))
        '        Next




        '        objConn.Close()

        '    Catch ex As Exception

        '        objConn.Close()

        '    End Try


    End Sub

    Private Sub Claims_tree_MouseDown(sender As Object, e As MouseEventArgs) Handles Claims_tree.MouseDown
        'If e.Button = Windows.Forms.MouseButtons.Right Then
        '    MsgBox(Claims_tree.SelectedNode.Name)
        'End If
    End Sub

    Private Sub Claims_tree_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Claims_tree.NodeMouseDoubleClick



        'sender.selectednode.text = sender.selectednode.text & " (" & sender.SelectedNode.Nodes.Count.ToString() & ")"
        sender.selectednode.Name.ToString()

        If Mid(sender.selectednode.Name.ToString(), 1, 2) = "C-" Then
            'Claims_tree.SelectedNode.Text.ToString()
            Claim_Entry.MdiParent = OOFSL_main
            Claim_Entry.Claim_id.Text = Mid(sender.selectednode.Name.ToString(), 3, sender.selectednode.Name.ToString().Length - 2)
            Claim_Entry.retrieve_claim_id()
            Claim_Entry.Show()
        End If



    End Sub

    Public Sub create_tree()
        Claims_tree.Nodes.Clear()
        Claims_tree.Nodes.Add("oClaims", "Open Claims")
        Claims_tree.Nodes.Add("eClaims", "Requires Correction")
        Claims_tree.Nodes.Add("cClaims", "Created Claims")
        Claims_tree.Nodes.Add("sClaims", "Submitted Claims")
        Claims_tree.Nodes.Add("pClaims", "Paid Claims")
        'Claims_tree.Nodes.Add("aClaims", "Archived Claims")
        ' Claims_tree.Nodes.Add("dClaims", "Deleted Claims")

    End Sub
    Public Sub load_created()
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim objDataAdapter As MySqlDataAdapter
            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer
            Dim x, y As TreeNode
            Dim total_v As Double
            Dim total_c As Integer
            'sql = "SELECT distinct filename from claims where status=1"

            sql = "SELECT distinct processed_file as filename, Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims "
            sql = sql + " from processed_service_record,patients where processed_service_record.patient_id=patients.id"
            sql = sql + " and status=1"
            sql = sql + " GROUP BY processed_file"



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblbatch")

            x = Claims_tree.Nodes("cClaims")


            For i = 0 To objDataset.Tables("tblbatch").Rows.Count - 1
                y = x.Nodes.Add("f" & i, objDataset.Tables("tblbatch").Rows(i).Item("filename") & " " & FormatCurrency(CDbl(objDataset.Tables("tblbatch").Rows(i).Item("total")), 2) & " Claims=" & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                total_v = total_v + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("total"))
                total_c = total_c + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                load_dates(y, 1, CStr("" & objDataset.Tables("tblbatch").Rows(i).Item("filename")))

            Next
            x.Text = "Created Claims $" & total_v & " Claims=" & total_c


        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try
    End Sub

    Public Sub load_submitted()
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter


            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer
            Dim x, y As TreeNode
            Dim total_v As Double
            Dim total_c As Integer
            'sql = "SELECT distinct filename from claims where status=2"

            sql = "SELECT distinct processed_file as filename, Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims "
            sql = sql + " from processed_service_record,patients where processed_service_record.patient_id=patients.id"
            sql = sql + " and status=2"
            sql = sql + " GROUP BY processed_file"



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblbatch")

            x = Claims_tree.Nodes("sClaims")


            For i = 0 To objDataset.Tables("tblbatch").Rows.Count - 1
                y = x.Nodes.Add("f" & i, objDataset.Tables("tblbatch").Rows(i).Item("filename") & " " & FormatCurrency(CDbl(objDataset.Tables("tblbatch").Rows(i).Item("total")), 2) & " Claims=" & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                total_v = total_v + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("total"))
                total_c = total_c + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                load_dates(y, 2, CStr("" & objDataset.Tables("tblbatch").Rows(i).Item("filename")))

            Next
            x.Text = "Submitted Claims $" & total_v & " Claims=" & total_c

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try
    End Sub

    Public Sub load_paid()
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer
            Dim x, y As TreeNode
            Dim total_v As Double
            Dim total_c As Integer


            'sql = "SELECT distinct filename, Sum(Total_submitted) AS Total, sum(total_paid) as total_p, Count(ID) AS n_claims "
            'sql = sql + " FROM Claims where status=3"
            'sql = sql + " GROUP BY filename;"

            sql = "SELECT distinct processed_file as filename, Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims "
            sql = sql + " from processed_service_record,patients where processed_service_record.patient_id=patients.id"
            sql = sql + " and status=3"
            sql = sql + " GROUP BY processed_file"


            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblbatch")

            x = Claims_tree.Nodes("pClaims")

            total_c = 0
            total_v = 0

            For i = 0 To objDataset.Tables("tblbatch").Rows.Count - 1
                y = x.Nodes.Add("f" & i, objDataset.Tables("tblbatch").Rows(i).Item("filename") & " " & FormatCurrency(CDbl(objDataset.Tables("tblbatch").Rows(i).Item("total")), 2) & " Claims=" & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                total_v = total_v + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("total"))
                total_c = total_c + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                load_dates(y, 3, objDataset.Tables("tblbatch").Rows(i).Item("filename").ToString)

            Next
            x.Text = "Paid Claims $" & total_v & " Claims=" & total_c






        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try
    End Sub
    Public Sub load_archived()
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer
            Dim x, y As TreeNode
            Dim total_v As Double
            Dim total_c As Integer


            'sql = "SELECT distinct filename, Sum(Total_submitted) AS Total, sum(total_paid) as total_p, Count(ID) AS n_claims "
            'sql = sql + " FROM Claims where status=3"
            'sql = sql + " GROUP BY filename;"

            sql = "SELECT distinct processed_file as filename, Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims "
            sql = sql + " from processed_service_record,patients where processed_service_record.patient_id=patients.id"
            sql = sql + " and status =6"
            sql = sql + " GROUP BY processed_file"


            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblbatch")

            x = Claims_tree.Nodes("aClaims")

            total_c = 0
            total_v = 0

            For i = 0 To objDataset.Tables("tblbatch").Rows.Count - 1
                y = x.Nodes.Add("f" & i, objDataset.Tables("tblbatch").Rows(i).Item("filename") & " " & FormatCurrency(CDbl(objDataset.Tables("tblbatch").Rows(i).Item("total")), 2) & " Claims=" & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                total_v = total_v + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("total"))
                total_c = total_c + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                load_dates(y, 6, CStr("" & objDataset.Tables("tblbatch").Rows(i).Item("filename")))

            Next
            x.Text = "Archived Claims $" & total_v & " Claims=" & total_c






        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try
    End Sub

    Public Sub load_Deleted()
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer
            Dim x, y As TreeNode
            Dim total_v As Double
            Dim total_c As Integer


            'sql = "SELECT distinct filename, Sum(Total_submitted) AS Total, sum(total_paid) as total_p, Count(source_ID) AS n_claims "
            'sql = sql + " FROM Claims where status=3"
            'sql = sql + " GROUP BY filename;"

            sql = "SELECT processed_file as filename, Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims "
            sql = sql + " FROM processed_service_record"
            sql = sql + " where status =7"
            sql = sql + " GROUP BY processed_file"


            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblbatch")

            x = Claims_tree.Nodes("dClaims")

            total_c = 0
            total_v = 0

            For i = 0 To objDataset.Tables("tblbatch").Rows.Count - 1
                y = x.Nodes.Add("f" & i, objDataset.Tables("tblbatch").Rows(i).Item("filename") & " " & FormatCurrency(CDbl(objDataset.Tables("tblbatch").Rows(i).Item("total")), 2) & " Claims=" & CDbl(objDataset.Tables("tblbatch").Rows(i).Item("n_claims")))
                total_v = total_v + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("total"))
                total_c = total_c + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("n_claims"))
                load_dates(y, 7, objDataset.Tables("tblbatch").Rows(i).Item("filename"))

            Next
            x.Text = "Deleted Claims $" & total_v & " Claims=" & total_c






        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try
    End Sub

    Public Sub load_error()
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer
            Dim x, y As TreeNode
            Dim total_v As Double
            Dim total_c As Integer

            'sql = "SELECT distinct filename, Sum(Total_submitted) AS Total, Count(ID) AS n_claims "
            'sql = sql + " FROM Claims where status=4"
            'sql = sql + " GROUP BY filename;"

            sql = "SELECT distinct processed_file as filename, Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims "
            sql = sql + " FROM processed_service_record,patients where processed_service_record.patient_id=patients.id"
            sql = sql + " and status=4"
            sql = sql + " GROUP BY processed_file"

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblbatch")

            x = Claims_tree.Nodes("eClaims")


            For i = 0 To objDataset.Tables("tblbatch").Rows.Count - 1
                y = x.Nodes.Add("f" & i, objDataset.Tables("tblbatch").Rows(i).Item("filename").ToString & " " & FormatCurrency(CDbl(objDataset.Tables("tblbatch").Rows(i).Item("total").ToString), 2) & " Claims=" & objDataset.Tables("tblbatch").Rows(i).Item("n_claims").ToString)
                total_v = total_v + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("total").ToString)
                total_c = total_c + CDbl(0 & objDataset.Tables("tblbatch").Rows(i).Item("n_claims").ToString)
                load_dates(y, 4, objDataset.Tables("tblbatch").Rows(i).Item("filename").ToString)

            Next

            x.Text = "Requires Correction $" & total_v & " Claims=" & total_c




        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try
    End Sub

    Public Sub load_open()
        Try


            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer
            Dim y As TreeNode

            sql = "SELECT distinct Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims "
            sql = sql + " FROM processed_service_record where status=0"

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblbatch")

            y = Claims_tree.Nodes("oClaims")
            y.Text = "Open Claims " & FormatCurrency(CDbl(0 & objDataset.Tables("tblbatch").Rows(0).Item("total")), 2) & " Claims=" & objDataset.Tables("tblbatch").Rows(0).Item("n_claims")
            'y.Nodes.Add("TOTAL OPEN:", " $" & CDbl(objDataset.Tables("tblbatch").Rows(i).Item("total")) & " Claims=" & CDbl(objDataset.Tables("tblbatch").Rows(i).Item("n_claims")))

            load_dates(y, 0, "")


        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try
    End Sub

    Public Sub load_dates(x As TreeNode, st As Integer, fn As String)
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer
            Dim y As TreeNode

            'sql = "SELECT distinct processed_file as filename, Sum(Submitted_Fee) AS Total, Count(ID) AS n_claims "
            'sql = sql + " FROM processed_service_record"
            'sql = sql + " where status=4"
            'sql = sql + " GROUP BY processed_file"

            'If fn = "" Then
            '    sql = "SELECT distinct service_date, Sum(Total_submitted) AS Total, Count(ID) AS n_claims from claims where status=" & st
            'Else
            '    sql = "SELECT distinct service_date, Sum(Total_submitted) AS Total, Count(ID) AS n_claims from claims where status=" & st & " and filename='" & fn & "'"
            'End If

            'sql = sql + " GROUP BY service_date;"

            If fn = "" Then
                sql = "SELECT distinct service_date, Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims from processed_service_record,patients where processed_service_record.patient_id=patients.id and status=" & st
            Else
                sql = "SELECT distinct service_date, Sum(Submitted_Fee) AS Total, Count(source_ID) AS n_claims from processed_service_record,patients where processed_service_record.patient_id=patients.id and status=" & st & " and processed_file='" & fn & "'"
            End If

            sql = sql + " GROUP BY service_date;"


            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tbldates")




            For i = 0 To objDataset.Tables("tbldates").Rows.Count - 1
                y = x.Nodes.Add(objDataset.Tables("tbldates").Rows(i).Item("service_date"), objDataset.Tables("tbldates").Rows(i).Item("service_date") & " $" & CDbl(objDataset.Tables("tbldates").Rows(i).Item("total")) & " Claims=" & objDataset.Tables("tbldates").Rows(i).Item("n_claims"))

                load_claims(y, Format(objDataset.Tables("tbldates").Rows(i).Item("service_date"), "dd/MMM/yyyy"), st, fn)

            Next






        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try
    End Sub

    Public Sub load_claims(x As TreeNode, dt As Date, st As Integer, fn As String)
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand
            'Dim myData As DataSet = New DataSet
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql As String = ""
            Dim objDataset As New DataSet
            Dim i As Integer

            'If fn = "" Then
            '    sql = "SELECT claims.id as id,lname,fname from claims,patients where claims.p_id=patients.id and status=" & st & " and service_date=#" & Format(dt, "dd/MMM/yyyy") & "#"

            'Else
            '    sql = "SELECT claims.id as id,lname,fname from claims,patients where claims.p_id=patients.id and status=" & st & " and filename='" & fn & "' and service_date=#" & Format(dt, "dd/MMM/yyyy") & "#"

            'End If

            If fn = "" Then
                'sql = "SELECT distinct processed_service_record.source_id as id,lname,fname from processed_service_record,patients where processed_service_record.patient_id=patients.id and status=" & st & " and service_date=#" & Format(dt, "dd/MMM/yyyy") & "#"
                sql = "SELECT distinct processed_service_record.source_id as id,lname,fname from processed_service_record,patients where processed_service_record.patient_id=patients.id and status=" & st & " and service_date='" & Format(dt, "yyyy-MM-dd") & "'"

            Else
                'sql = "SELECT distinct processed_service_record.source_id as id,lname,fname from processed_service_record,patients where processed_service_record.patient_id=patients.id and status=" & st & " and processed_file='" & fn & "' and service_date=#" & Format(dt, "dd/MMM/yyyy") & "#"
                sql = "SELECT distinct processed_service_record.source_id as id,lname,fname from processed_service_record,patients where processed_service_record.patient_id=patients.id and status=" & st & " and processed_file='" & fn & "' and service_date='" & Format(dt, "yyyy-MM-dd") & "'"

            End If

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblclaims")




            For i = 0 To objDataset.Tables("tblclaims").Rows.Count - 1
                x.Nodes.Add("C-" & objDataset.Tables("tblclaims").Rows(i).Item("id"), objDataset.Tables("tblclaims").Rows(i).Item("lname") & "," & objDataset.Tables("tblclaims").Rows(i).Item("fname"))

            Next


        Catch ex As Exception
            MsgBox(ex.ToString)



        End Try
    End Sub




    Private Sub Claim_management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            objConn.Open()
            create_tree()


            load_created()
            load_submitted()
            load_paid()
            load_error()
            load_open()
            'load_archived()
            'load_Deleted()
            objConn.Close()
        Catch ex As Exception
            objConn.Close()

        End Try

    End Sub
    Public Sub Refresh_tree()
        Try
            objConn.Open()
            create_tree()

            load_created()
            load_submitted()
            load_paid()
            load_error()
            load_open()
            'load_archived()
            objConn.Close()
        Catch ex As Exception
            objConn.Close()

        End Try
    End Sub


End Class