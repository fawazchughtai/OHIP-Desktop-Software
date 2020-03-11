Imports Microsoft.Win32
Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class ActivationClass


    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objDataAdapter As MySqlDataAdapter
    Private strProviderNumber As String
    Private strValidationCode As String
    Dim sv As New Dr_validation.Icheck_updateClient()
    Dim dr1 As New Dr_validation.dr_profile
    Dim rsp As New Dr_validation.messages
    Dim msg As New Dr_validation.message






    Public Function unlock_app() As Boolean
        Dim p_x As Integer = 1299721
        Try


            ' if activation code is valid then return true this works well

            Dim sql As String = Nothing
            Dim objDataset As New DataSet
            unlock_app = False
            sql = "select * from physicianinformation"
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblProvider")
            strProviderNumber = objDataset.Tables("tblProvider").Rows(0).Item("OHIPBillingNumber").ToString
            strValidationCode = objDataset.Tables("tblProvider").Rows(0).Item("ActivationCode").ToString
            dr1.Firstname = objDataset.Tables("tblProvider").Rows(0).Item("Firstname").ToString
            dr1.Lastname = objDataset.Tables("tblProvider").Rows(0).Item("Lastname").ToString
            dr1.provider_num = objDataset.Tables("tblProvider").Rows(0).Item("OHIPBillingNumber").ToString
            dr1.telephone = objDataset.Tables("tblProvider").Rows(0).Item("PhoneNumber").ToString
            dr1.specialty = objDataset.Tables("tblProvider").Rows(0).Item("Specialty").ToString
            dr1.postal = objDataset.Tables("tblProvider").Rows(0).Item("PostalCode").ToString
            dr1.email = objDataset.Tables("tblProvider").Rows(0).Item("Email").ToString
            dr1.city = objDataset.Tables("tblProvider").Rows(0).Item("city").ToString
            dr1.app_version = "" 'Application.ProductVersion.ToString
            dr1.Address = objDataset.Tables("tblProvider").Rows(0).Item("Address").ToString
            dr1.activation_code = objDataset.Tables("tblProvider").Rows(0).Item("ActivationCode").ToString
            ' Later add the credit card info
            objConn.Close()
            rsp = sv.Check_Account(dr1)


            msg = rsp.msgs.GetValue(0)
            If msg.message_type = "Activation Code" Then
                If msg.message_action = "No action" Then
                    unlock_app = True
                    OOFSL_main.ftp_acc = msg.ftp_uid
                    OOFSL_main.ftp_pwd = msg.ftp_pwd

                    OOFSL_main.ActivationCodeToolStripMenuItem.Visible = False
                ElseIf msg.message_action = "Purchase License" Then
                    unlock_app = prompt_payment2()
                End If
            ElseIf msg.message_type = "New Account" Then
                MsgBox(msg.message_description)


            Else


            End If

        Catch ex As Exception
            'MsgBox("Error in module activation Error 1")
            If IsNumeric(strValidationCode) Then
                If strProviderNumber <> "" Then
                    If IsNumeric(strProviderNumber) Then
                        If CDbl(strValidationCode) = CDbl(strProviderNumber) * p_x Then
                            'validation successfull 
                            unlock_app = True
                            OOFSL_main.ActivationCodeToolStripMenuItem.Visible = False
                        End If
                    End If
                End If
            End If
        End Try

    End Function



    Private Function prompt_payment2() As Boolean
        ' prompt for payment to continue using - provide redirection to payment page
        Try
            prompt_payment2 = False
            System.Diagnostics.Process.Start("http://www.ohip-billing.com/payment.htm")
        Catch ex As Exception
            MsgBox("For a Free Trial please contact us 1-877-358-7339 or info@ohip-billing.com")
        End Try
    End Function




    Private Sub old_unlock()
        'If strValidationCode = "" Then

        '    MsgBox("For a Free Trial please contact us 1-877-358-7339 or info@ohip-billing.com")
        '    activate()
        'Else

        '    If IsNumeric(strValidationCode) Then
        '        If strProviderNumber <> "" Then
        '            If IsNumeric(strProviderNumber) Then
        '                ' check activation code

        '                If CDbl(strValidationCode) = CDbl(strProviderNumber) * p_x Then
        '                    'validation successfull 
        '                    unlock_app = True
        '                    OOFSL_main.ActivationCodeToolStripMenuItem.Visible = False

        '                Else
        '                    'payment required
        '                    unlock_app = prompt_payment()
        '                End If

        '            Else
        '                'call for free trial
        '                MsgBox("For a Free Trial please contact us 1-877-358-7339 or info@ohip-billing.com")
        '            End If

        '        End If
        '    Else
        '        ' Trial period

        '        unlock_app = prompt_payment()

        '    End If

        'End If
    End Sub

    Private Function days_installed() As Integer
        'calculate days installed based on key in configuration

        Try



            Dim d, m, y, dt As String
            Dim d1, m1, y1 As Integer


            dt = Right(strValidationCode, Len(strValidationCode) - 1)

            Try
                If IsNumeric(dt) Then
                    dt = dt / 31
                    If Len(CStr(dt)) < 8 Then
                        dt = "0" & dt

                    End If
                    d = Mid(CStr(dt), 1, 2)
                    m = Mid(CStr(dt), 3, 2)
                    y = Mid(CStr(dt), 5, 4)

                    d1 = Now.Day - CInt(d)
                    m1 = Now.Month - CInt(m)
                    y1 = Now.Year - CInt(y)

                    If y1 = 0 Then
                        Return (m1 * 30 + d1)
                    Else
                        Return 9999
                    End If

                Else
                    MsgBox("For a Free Trial please contact us 1-877-358-7339 or info@ohip-billing.com")
                    Return -1
                End If


            Catch e As Exception
                MsgBox("For a Free Trial please contact us 1-877-358-7339 or info@ohip-billing.com")
                Return -1
            End Try


        Catch ex As Exception
            MsgBox("For a Free Trial please contact us 1-877-358-7339 or info@ohip-billing.com")
        End Try

    End Function

    Private Function prompt_payment() As Boolean
        ' prompt for payment to continue using - provide redirection to payment page
        Try


            Dim rp As Integer
            Dim di As Integer
            di = days_installed()
            prompt_payment = False

            If di <> -1 Then


                If di < 30 Then
                    prompt_payment = True
                    rp = MsgBox("You have " & 30 - di & " Days left before your licence expires, would you like to purchase a licence now?", vbYesNoCancel)

                    If rp = vbYes Then
                        System.Diagnostics.Process.Start("http://www.ohip-billing.com/payment.htm")
                        'open webpage to purchase licence
                        activate()
                    End If
                Else
                    rp = MsgBox("For a Free Trial please contact us 1-877-358-7339 or info@ohip-billing.com. Would you like to purchase a licence now?", vbYesNo)

                    If rp = vbYes Then
                        System.Diagnostics.Process.Start("http://www.ohip-billing.com/payment.htm")
                        'open webpage to purchase licence


                    Else
                        MsgBox("Submission to Ministry will not function - Please contact us 1-877-358-7339")

                    End If
                    activate()
                End If
            Else
                activate()
            End If

        Catch ex As Exception
            MsgBox("For a Free Trial please contact us 1-877-358-7339 or info@ohip-billing.com")
        End Try
    End Function
    Public Sub activate()
        Try


            Dim ad_key As String

            ad_key = InputBox("Enter ACTIVATION CODE:")

            If ad_key <> "" Then
                Dim sql As String
                'Dim myCommand As New OleDb.OleDbCommand
                Dim myCommand As New MySqlCommand


                objConn.Open()

                sql = "update physicianinformation set ActivationCode='" & ad_key & "'"


                myCommand.Connection = objConn
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()

                objConn.Close()

            End If
        Catch ex As Exception
            MsgBox("Activate code error - please contact us at 1-877-358-7339")
        End Try

    End Sub


End Class
