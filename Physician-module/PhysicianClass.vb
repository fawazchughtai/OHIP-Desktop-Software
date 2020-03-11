Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class PhysicianClass
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
    Public Sub load_Physician()
        Dim sql As String
        Dim objDataset As New DataSet

        Try
            objConn.Open()

            sql = "select ProvName from cdprovince Order by ProvName"
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblProv")
            'PatientInput.prov_txt.Items.Clear()

            For Each rs As DataRow In objDataset.Tables("tblProv").Rows 'Loops through Rows
                PhysicianInfo.Provincetxt.Items.Add(rs.Item("ProvName").ToString)
            Next


            sql = "select * from physicianinformation"

            'MSAccess
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblphysicianinformation")
            PhysicianInfo.FirstNametxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("firstname")
            PhysicianInfo.LastNametxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("LastName")
            PhysicianInfo.Addresstxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("Address")
            PhysicianInfo.Citytxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("City")
            PhysicianInfo.Provincetxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("Province")
            PhysicianInfo.Postaltxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("PostalCode")
            PhysicianInfo.OHIPBillingNumbertxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("OHIPBillingNumber")
            PhysicianInfo.LocationCodetxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("LocationCode")
            PhysicianInfo.MOHOfficeCodetxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("MOHOfficeCode")
            PhysicianInfo.PhoneNumbertxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("PhoneNumber")
            PhysicianInfo.Emailtxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("Email")
            ' PhysicianInfo.GroupNumbertxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("GroupNumber")
            PhysicianInfo.Specialtytxt.Text = objDataset.Tables("tblphysicianinformation").Rows(0).Item("Specialty")
            If objDataset.Tables("tblphysicianinformation").Rows(0).Item("OptIn") = "P" Then
                PhysicianInfo.OptIn.Checked = True
            Else
                PhysicianInfo.OptOut.Checked = True
            End If

            objConn.Close()

        Catch ex As Exception
            objConn.Close()
        End Try
    End Sub
    Public Sub save()
        Dim sql As String
        Dim objDataset As New DataSet
        Dim cancelSave As Boolean = False
        Dim optinout As String
        Try

            If PhysicianInfo.FirstNametxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.FirstNameIsValid.Visible = True
            End If
            If PhysicianInfo.LastNametxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.LastNameIsValid.Visible = True
            End If
            If PhysicianInfo.Addresstxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.AddresstxtIsValid.Visible = True
            End If
            If PhysicianInfo.Citytxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.CityIsValid.Visible = True
            End If
            If PhysicianInfo.Provincetxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.ProvinceIsValid.Visible = True
            End If
            If PhysicianInfo.Postaltxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.PostalIsValid.Visible = True
            End If
            If PhysicianInfo.OHIPBillingNumbertxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.OHIPBillingNumberIsValid.Visible = True
            End If
            'If PhysicianInfo.LocationCodetxt.Text.Length = 0 Then
            '    cancelSave = True
            '    PhysicianInfo.LocationCodeIsValid.Visible = True
            'End If
            If PhysicianInfo.MOHOfficeCodetxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.MOHOfficeCodeIsValid.Visible = True
            End If
            If PhysicianInfo.GroupNumbertxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.GroupNumberIsValid.Visible = True
            End If
            If PhysicianInfo.Specialtytxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.SpecialtyIsValid.Visible = True
            End If
            If PhysicianInfo.PhoneNumbertxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.PhoneIsValid.Visible = True
            End If
            If PhysicianInfo.Emailtxt.Text.Length = 0 Then
                cancelSave = True
                PhysicianInfo.EmailIsValid.Visible = True
            End If

            If PhysicianInfo.OptIn.Checked Then
                optinout = "P"
            Else
                optinout = "S"
            End If

            If Not cancelSave Then

                objConn.Open()

                sql = "update physicianinformation set "
                sql = sql & "firstname ='" & PhysicianInfo.FirstNametxt.Text & "',"
                sql = sql & "LastName ='" & PhysicianInfo.LastNametxt.Text & "',"
                sql = sql & "Address ='" & PhysicianInfo.Addresstxt.Text & "',"
                sql = sql & "City ='" & PhysicianInfo.Citytxt.Text & "',"
                sql = sql & "Province ='" & PhysicianInfo.Provincetxt.Text & "',"
                sql = sql & "PostalCode ='" & PhysicianInfo.Postaltxt.Text.Replace(" ", "") & "',"
                sql = sql & "OHIPBillingNumber ='" & PhysicianInfo.OHIPBillingNumbertxt.Text & "',"
                sql = sql & "LocationCode ='" & PhysicianInfo.LocationCodetxt.Text & "',"
                sql = sql & "MOHOfficeCode ='" & PhysicianInfo.MOHOfficeCodetxt.Text & "',"
                sql = sql & "GroupNumber ='" & PhysicianInfo.GroupNumbertxt.Text.ToString & "',"
                sql = sql & "Specialty ='" & PhysicianInfo.Specialtytxt.Text & "',"
                sql = sql & "OptIn ='" & optinout & "',"
                sql = sql & "PhoneNumber ='" & PhysicianInfo.PhoneNumbertxt.Text & "',"
                sql = sql & "Email ='" & PhysicianInfo.Emailtxt.Text & "'"

                myCommand.Connection = objConn
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()

                objConn.Close()

                PhysicianInfo.FirstNameIsValid.Visible = False
                PhysicianInfo.LastNameIsValid.Visible = False
                PhysicianInfo.AddresstxtIsValid.Visible = False
                PhysicianInfo.CityIsValid.Visible = False
                PhysicianInfo.ProvinceIsValid.Visible = False
                PhysicianInfo.PostalIsValid.Visible = False
                PhysicianInfo.OHIPBillingNumberIsValid.Visible = False
                PhysicianInfo.LocationCodeIsValid.Visible = False
                PhysicianInfo.MOHOfficeCodeIsValid.Visible = False
                PhysicianInfo.GroupNumberIsValid.Visible = False
                PhysicianInfo.SpecialtyIsValid.Visible = False
                PhysicianInfo.PhoneIsValid.Visible = False
                PhysicianInfo.EmailIsValid.Visible = False
                PhysicianInfo.Hide()
            End If
            cancelSave = False
        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in PhysicianInfo.Save : " & ex.ToString)
        End Try

    End Sub
    Public Function IsNewInstall() As Boolean
        Dim sql As String
        Dim objDataset As New DataSet
        objConn.Open()
        sql = "select * from physicianinformation"
        'MSAccess
        objDataAdapter = New MySqlDataAdapter(sql, objConn)
        objDataAdapter.Fill(objDataset, "tblphysicianinformation")

        If objDataset.Tables("tblphysicianinformation").Rows(0).Item("firstname") = "Install" Or objDataset.Tables("tblphysicianinformation").Rows(0).Item("firstname") = "" Then



            sql = "update physicianinformation set "
            sql = sql & "firstname ='',"
            sql = sql & "LastName ='',"
            sql = sql & "Address ='',"
            sql = sql & "City ='',"
            sql = sql & "Province ='',"
            sql = sql & "PostalCode ='',"
            sql = sql & "OHIPBillingNumber ='',"
            sql = sql & "LocationCode ='',"
            sql = sql & "MOHOfficeCode ='',"
            sql = sql & "GroupNumber ='',"
            sql = sql & "Specialty ='',"
            sql = sql & "OptIn ='P',"
            sql = sql & "PhoneNumber ='',"
            sql = sql & "Email ='',"
            sql = sql & "ActivationCode ='T" & CInt(Today.Day.ToString() & Today.Month.ToString.PadLeft(2, "0") & Today.Year.ToString) * 31 & "'"


            myCommand.Connection = objConn
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()

            objConn.Close()
            Return True
        Else
            objConn.Close()
            Return False
        End If
    End Function
End Class
