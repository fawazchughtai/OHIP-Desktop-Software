Option Strict Off
Option Explicit On
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration

Friend Class OOFSL_main
    Inherits System.Windows.Forms.Form
    Private OutputPath As String = currPath & "\OutputFiles\Activation"
    Public sdbname As String = "\Db\oofsl.mdb"
    Public update_avail As Boolean = False
    Public service_expire As Boolean = False

    'Public sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & sdbname
    'Public sConnectionString As String = "server=localhost;user=root;database=ohip_access;port=3306;password=;"
    Public sConnectionString As String = ConfigurationManager.ConnectionStrings("appCs").ConnectionString
    'Private myCommand As New System.Data.OleDb.OleDbCommand
    'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
    Private myCommand As New MySqlCommand
    Private myAdapter As MySqlDataAdapter
    Private myData As DataSet = New DataSet
    Public patient_reader As New patient_obj

    Public unlock_app As Boolean
    Dim Client As New Net.WebClient() ' used for updater
    Public ftp_acc As String
    Public ftp_pwd As String
    Public ftp_provider As String

    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
    Private objConn As MySqlConnection = New MySqlConnection(sConnectionString)
    Private objDataAdapter As MySqlDataAdapter
    Public Sub Aboutus_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Aboutus.Click
        about_frm.MdiParent = Me
        about_frm.Show()
        about_frm.Focus()

    End Sub

    Private Sub OOFSL_main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try


            Dim res As String = MsgBox("Would you like to backup now?", vbYesNo)
            If res = vbYes Then
                backup_db()

            End If
        Catch ex As Exception
            MsgBox("Error in backup module")
        End Try
        Application.Exit()
    End Sub

    Private Sub OOFSL_main_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim objact As New ActivationClass
        Try
            Me.unlock_app = objact.unlock_app()

            'MsgBox(ftp_acc & " :" & ftp_pwd)
            'ftp uid And password available
            If unlock_app = True Then

            Else

            End If

        Catch ex As Exception

        End Try

        Try
            USBHID1.PortOpen = True
            If Not (USBHID1.PortOpen) Then
                ' MsgBox("Could not enable Health Card Reader")

            End If
        Catch ex As Exception
            ' MsgBox("Error with Health Card Reader")
        End Try
        load_app()

    End Sub

    Public Sub load_app()
        Dim objVerifySQLScript As New VerifySQLScript
        objVerifySQLScript.RunScript()

        load_config()

        'need to change this only if there is an update completed? how to determine

        'If MsgBox("Would you like to check for OHIP-BILLING Update now?", vbYesNo) = vbYes Then

        '    Updater.ShowDialog()


        '    msg_update()
        'End If







        Application.EnableVisualStyles()
        current_patient = -1

        current_service = -1

        Dim objPhysician As New PhysicianClass
        If objPhysician.IsNewInstall Then
            PhysicianInfo.ShowDialog()
            If objPhysician.IsNewInstall Then
                Application.Exit()
            End If




        Else
            PhysicianInfo.Show()
            PhysicianInfo.Hide()
            Me.Text = "OHIP Billing System for Dr." & PhysicianInfo.LastNametxt.Text
            ftp_provider = PhysicianInfo.OHIPBillingNumbertxt.Text

            If strBackupFolder = vbNullString Then
                strBackupFolder = currPath & "\Backup\"
            End If
            If strReturnFileFolder = vbNullString Then
                strReturnFileFolder = currPath & "\InputFiles\"
            End If
            If strSubmissionFileFolder = vbNullString Then
                strSubmissionFileFolder = currPath & "\OutputFiles\"
            End If







        End If



        Claim_Entry.MdiParent = Me
        Claim_management.MdiParent = Me
        Claim_management.Show()
        Claim_Entry.Show()
        Claim_Entry.Focus()



    End Sub
    Public Sub patient_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles patient.Click
        patient_entry.MdiParent = Me
        patient_entry.clear_patient()
        patient_entry.Show()
        patient_entry.Focus()
    End Sub



    Private Sub SubmissionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmissionToolStripMenuItem.Click
        Dim objCreateOHIPFile As New CreateOHIPFile
        objCreateOHIPFile.CreateUnsubmitedServiceList()
        objCreateOHIPFile.CreateSubmitedServiceList()
        Submission.MdiParent = Me
        Submission.Show()
        Submission.Focus()
    End Sub




    Private Sub PhysicianInfoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhysicianInfoToolStripMenuItem1.Click
        PhysicianInfo.MdiParent = Me
        PhysicianInfo.Show()
        PhysicianInfo.Focus()
    End Sub

    Private Sub ReferralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferralToolStripMenuItem.Click
        Referral.MdiParent = Me
        Referral.Show()
        Referral.Focus()
    End Sub






    Private Sub FilePathToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilePathToolStripMenuItem.Click
        SystemFilePaths.MdiParent = Me
        SystemFilePaths.Show()
        SystemFilePaths.Focus()
    End Sub

    Private Sub BackupToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem1.Click
        backup_db()

    End Sub
    Private Sub ReconciliationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReconciliationToolStripMenuItem.Click
        Reconciliation.MdiParent = Me
        Reconciliation.Show()
        Reconciliation.Focus()
    End Sub



    Private Sub MOHMessagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MOHMessages.MdiParent = Me
        MOHMessages.Show()
        MOHMessages.Focus()
    End Sub



    Private Sub useguide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles useguide.Click
        System.Diagnostics.Process.Start("http://www.ohip-billing.info/v7/v7manual.pdf")
    End Sub



    Private Sub MOHMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MOHMessages.MdiParent = Me
        MOHMessages.Show()
        MOHMessages.Focus()
    End Sub



    Private Sub ServiceLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TransactionHistory.MdiParent = Me
        TransactionHistory.Show()
        TransactionHistory.Focus()
    End Sub

    Private Sub BatchReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchReportToolStripMenuItem.Click
        Dim objEDTFileClass As New EDTFileClass
        objEDTFileClass.GetBatchReportFileList()
    End Sub


    Private Sub ErrorReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorReportsToolStripMenuItem.Click
        Dim objEDTFileClass As New EDTFileClass
        objEDTFileClass.GetErrorReportFileList()
    End Sub







    Private Sub TransactionHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TransactionHistory.MdiParent = Me
        TransactionHistory.Show()
        TransactionHistory.Focus()
    End Sub



    Private Sub Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quit.Click
        'Try


        'Dim res As String = MsgBox("Would you like to backup now?", vbYesNo)
        'If res = vbYes Then
        '    backup_db()
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error in backup module")
        'End Try
        Application.Exit()
    End Sub








    Private Sub ActivationCodeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ActivationCodeToolStripMenuItem.Click
        Dim objact As New ActivationClass
        objact.activate()
    End Sub


    Private Sub TransactionHistoryToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionHistoryToolStripMenuItem.Click
        'Claim_management.MdiParent = Me
        'Claim_management.Show()
        'Claim_management.Focus()
        TransactionHistory.patient_id.Text = ""
        TransactionHistory.Date_frm_open.Value = "1-jan-2010"
        TransactionHistory.Date_to_open.Value = Today()
        TransactionHistory.MdiParent = Me
        TransactionHistory.Show()
        TransactionHistory.Focus()

    End Sub

    Private Sub MOHMessageToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MOHMessageToolStripMenuItem.Click
        MOHMessages.MdiParent = Me
        MOHMessages.Show()
        MOHMessages.Focus()
    End Sub


    Private Sub CheckForUpdatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        Updater.ShowDialog()

        msg_update()

    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            msg_update()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub msg_update()


        If service_expire = False Then
            Dim downuri As String

            downuri = "http://www.ohip-billing.info/v7/latest_patch.exe"
            Updater.Downuri = downuri

            Updater.Visible = False
            Updater.check()

            Dim r As String
            Try
                If update_avail Then



                    r = MsgBox("Updates available, would you like to update now?", vbYesNo)
                    If r = vbYes Then
                        Client.DownloadFile(downuri,
                   My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "\Update-ohipbilling.exe")
                        Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp.ToString &
                        "\Update-ohipbilling.exe")
                        Application.Exit()
                    End If



                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Dim rp As String
            rp = MsgBox("Your annual maintenance has expired, would you like to purchase a renewal to continue receiving software and technical support?", vbYesNoCancel)

            If rp = vbYes Then
                System.Diagnostics.Process.Start("http://www.ohip-billing.com/annual_payment.htm")
                'open webpage to purchase annual maintenance

            End If

        End If

    End Sub

    Private Sub load_config()
        Dim sql As String
        'Dim dbread As OleDb.OleDbDataReader
        Dim dbread As MySqlDataReader

        Try
            objConn.Open()

            sql = "select config.fieldvalue from config where config.fieldname='backup_path'"

            myCommand.Connection = objConn
            myCommand.CommandText = sql
            dbread = myCommand.ExecuteReader()
            dbread.Read()
            If dbread.GetValue(0).ToString = "" Then
                strBackupFolder = currPath & "\backup\BackupFolder\"
            Else
                strBackupFolder = dbread.GetValue(0)
            End If

            dbread.Close()

        Catch ex As Exception
            MsgBox("Error Occured in load config module: " + ex.Message + "Default backup folder has been assigned")
            strBackupFolder = currPath & "\backup\BackupFolder\"
        Finally
            objConn.Close()
        End Try
    End Sub

    Public Function backup_db() As Boolean
        Try
            Dim Backuppath As String
            If strSubmissionFileFolder = "" Then
                Backuppath = currPath & "\Backup\"
            Else
                Backuppath = strBackupFolder & "\"
            End If

            Dim FileToCopy As String
            Dim NewCopy As String

            FileToCopy = currPath & sdbname

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-d-yyyy HH-mm"


            Dim BackupPathTimeDate As String
            BackupPathTimeDate = Backuppath & time.ToString(format)

            If Not System.IO.Directory.Exists(BackupPathTimeDate) Then
                System.IO.Directory.CreateDirectory(BackupPathTimeDate)
            End If

            NewCopy = BackupPathTimeDate & "\oofsl.mdb"

            If System.IO.File.Exists(FileToCopy) = True Then
                System.IO.File.Copy(FileToCopy, NewCopy, True)

                Dim FTPBackup As New FTPBackup(Me.ftp_acc, Me.ftp_pwd, Me.ftp_provider)
                FTPBackup.ShowDialog()
                '      MsgBox("Backup Complete", , "Backup")
                Return True
            Else
                Return False
            End If




        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Sub ServiceToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ServiceToolStripMenuItem.Click



        Services.MdiParent = Me
        Services.Show()
        Services.Focus()

    End Sub

    Private Sub DiagnosisCodesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DiagnosisCodesToolStripMenuItem.Click
        Diagnosis.MdiParent = Me
        Diagnosis.Show()
        Diagnosis.Focus()
    End Sub

    Private Sub SummaryOfPaymentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummaryOfPaymentsToolStripMenuItem.Click
        Dim sql As String
        '' deposit amounts query rpt1
        'sql = "SELECT reconciliationheaderrecord.FileName, left(reconciliationheaderrecord.PaymentDate,4) AS paydate_yr,mid(reconciliationheaderrecord.PaymentDate,5,2) AS paydate_m,right(reconciliationheaderrecord.PaymentDate,2) AS paydate_d, CDbl(Left(reconciliationheaderrecord.TotalAmountPpayable,7)+'.'+Right(reconciliationheaderrecord.TotalAmountPpayable,2)) AS payamt"
        sql = "SELECT reconciliationheaderrecord.FileName, left(reconciliationheaderrecord.PaymentDate,4) AS paydate_yr,mid(reconciliationheaderrecord.PaymentDate,5,2) AS paydate_m,right(reconciliationheaderrecord.PaymentDate,2) AS paydate_d, Cast(Left(reconciliationheaderrecord.TotalAmountPpayable,7)+'.'+Right(reconciliationheaderrecord.TotalAmountPpayable,2) AS Decimal(10,2)) AS payamt"
        sql = sql + " FROM reconciliationheaderrecord"

        TransactionHistory.print_reports(sql, 1)
    End Sub

    Private Sub CleanDuplicatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CleanDuplicatesToolStripMenuItem.Click

        Dim objVerifySQLScript As New VerifySQLScript
        objVerifySQLScript.clean_duplicates()


        MsgBox("Clean completed")


    End Sub


    Private Sub ClaimEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClaimEntryToolStripMenuItem1.Click
        Claim_Entry.MdiParent = Me
        Claim_Entry.Show()
        Claim_Entry.Focus()


    End Sub

    Private Sub OHIPAssistantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OHIPAssistantToolStripMenuItem.Click
        Claim_Entry.show_helper()
    End Sub

    Private Sub ReprocessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprocessToolStripMenuItem.Click
        Dim objVerifySQLScript As New VerifySQLScript
        objVerifySQLScript.process_reconciliation_all()

        MsgBox("All Reconciliation completed")

    End Sub


    Private Sub ClaimManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClaimManagementToolStripMenuItem.Click
        Claim_management.MdiParent = Me
        Claim_management.Show()
        Claim_management.Focus()
    End Sub



    Public Sub update_status()
        sys_update_status.MdiParent = Me
        sys_update_status.Show()
        sys_update_status.Focus()

        sys_update_status.ProgressBar1.Style = ProgressBarStyle.Marquee
        sys_update_status.ProgressBar1.Visible = True
    End Sub



    Private Sub TechSupportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TechSupportToolStripMenuItem.Click

        Try
            Process.Start(currPath & "\tech.exe")

        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub archive_folders()
        Dim IF_ac_Folder As String
        Dim OF_ac_Folder As String
        Dim IF_Folder As String
        Dim OF_folder As String
        IF_Folder = currPath & "\inputfiles\"
        OF_folder = currPath & "\outputfiles\"
        IF_ac_Folder = currPath & "\backup\IF_archive-" & Today()
        IF_ac_Folder = IF_ac_Folder.Replace("/", "-")


        OF_ac_Folder = currPath & "\backup\OF_archive-" & Today()
        OF_ac_Folder = OF_ac_Folder.Replace("/", "-")


        If System.IO.Directory.Exists(IF_Folder) Then
            Dim dir1 As New System.IO.DirectoryInfo(IF_Folder)
            If System.IO.Directory.Exists(IF_ac_Folder) Then
            Else
                dir1.MoveTo(IF_ac_Folder)
            End If



        End If
        If System.IO.Directory.Exists(OF_folder) Then
            Dim dir2 As New System.IO.DirectoryInfo(OF_folder)
            If System.IO.Directory.Exists(OF_ac_Folder) Then
            Else
                dir2.MoveTo(OF_ac_Folder)
            End If

        End If

        If System.IO.Directory.Exists(IF_Folder) Then
        Else
            System.IO.Directory.CreateDirectory(IF_Folder)
        End If
        If System.IO.Directory.Exists(OF_folder) Then
        Else
            System.IO.Directory.CreateDirectory(OF_folder)
        End If



    End Sub

    Private Sub ArchivefoldersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchivefoldersToolStripMenuItem.Click
        archive_folders()
    End Sub


    Private Sub USBHID1_CardDataChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub USBHID1_CardDataChanged_1(sender As Object, e As EventArgs) Handles USBHID1.CardDataChanged
        Try


            Me.patient_reader.clear()
            With USBHID1
                If (.GetTrack(1) <> "") Then


                    patient_reader.health_num = Mid(.GetTrack(1), 9, 10)
                    patient_reader.version_code = Mid(.GetTrack(1), 63, 2)
                    'patient_reader.health_exp = Mid(.GetTrack(1), 47, 4)
                    patient_reader.sex = Mid(.GetTrack(1), 54, 1)
                    patient_reader.dob = CDate(Mid(.GetTrack(1), 55, 4) + "-" + Mid(.GetTrack(1), 59, 2) + "-" + Mid(.GetTrack(1), 61, 2))

                    ' patient_reader.health_issue = Mid(.GetTrack(1), 70, 6)
                    patient_reader.lang_pref = Mid(.GetTrack(1), 76, 2)
                    Dim name(2) As String
                    name = Split(Mid(.GetTrack(1), 20, 26), "/", , CompareMethod.Text)
                    patient_reader.firstname = name(1)
                    patient_reader.lastname = name(0)

                    If patient_entry.health_num.Text = "" Then
                        'patient_entry.health_num.Text = patient_reader.health_num
                        Claim_Entry.Health_num.Text = patient_reader.health_num
                    End If
                End If

            End With

            'patient_entry.search_patient()
            Claim_Entry.search_patient()

        Catch ex As Exception
            MsgBox("Error with reader")
        End Try
    End Sub

    Private Sub BackupOnServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupOnServerToolStripMenuItem.Click
        Dim FTPBackup As New FTPBackup(Me.ftp_acc, Me.ftp_pwd, Me.ftp_provider)
        FTPBackup.ShowDialog()
    End Sub


End Class