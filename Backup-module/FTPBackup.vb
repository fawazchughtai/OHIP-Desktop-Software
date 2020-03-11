Imports System.ComponentModel
Imports System.IO
Imports WinSCP

Imports System.Net
Imports System.Net.Security
Imports System.Net.Sockets
Imports System.Text
Imports System.Collections.Generic
Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient

Imports System.Configuration

Public Class FTPBackup
    Private Const Host = "aksure.dyndns-ip.com"
    Private Const Port = 22
    Private session As Session
    Private StartTime As DateTime
    Private FTPLogin As String
    Private FTPPassword As String
    Private FTPProvider As String
    Private OutputPath As String = currPath & "\OutputFiles\Activation"
    Private sdbname As String = "\Db\oofsl.mdb"
    'Private sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & sdbname
    'Private sConnectionString As String = "server=localhost;user=root;database=ohip_access;port=3306;password=;"
    Private sConnectionString As String = ConfigurationManager.ConnectionStrings("appCs").ConnectionString


    Public Sub New(ByVal FTPLogin As String, ByVal FTPPassword As String, ByVal FTPProvider As String)

        ' This call is required by the designer.

        InitializeComponent()
        Me.FTPLogin = FTPLogin
        Me.FTPPassword = FTPPassword
        Me.FTPProvider = FTPProvider
        '    btnBackup.Enabled = False
        bWorker.RunWorkerAsync()




    End Sub

    Private Function IsBackupNecessary() As Boolean
        Dim result As Boolean = False
        'Dim command As New System.Data.OleDb.OleDbCommand
        'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(sConnectionString)
        Dim command As New MySqlCommand
        Dim objConn As MySqlConnection = New MySqlConnection(sConnectionString)
        Dim lastDate As Date
        Dim DateExists As Boolean = False
        Try
            Dim sql = "select top 1 backup_date from last_backup order by id desc"
            command = objConn.CreateCommand()
            command.CommandText = sql
            'Dim r As OleDb.OleDbDataReader
            Dim r As MySqlDataReader
            If objConn.State = ConnectionState.Closed Then
                objConn.Open()
            End If
            r = command.ExecuteReader()
            While r.Read()
                lastDate = DateTime.Parse(r("backup_date")).Date
                DateExists = True
            End While
            If DateExists = True Then
                Dim diff As TimeSpan
                diff = DateTime.Now.Date - lastDate
                If diff.Days >= 7 Then
                    Return True
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            Throw ex

        Finally
            objConn.Close()
        End Try
        Return result

    End Function

    Private Sub UpdateBackupDate()
        'Dim command As New System.Data.OleDb.OleDbCommand
        Dim command As New MySqlCommand
        'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(sConnectionString)
        Dim objConn As MySqlConnection = New MySqlConnection(sConnectionString)
        Try
            objConn.Open()
            Dim sql = "insert into last_backup (backup_date) values('" + DateTime.Now + "')"
            command = objConn.CreateCommand()
            command.CommandText = sql
            command.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex

        Finally
            If objConn.State <> ConnectionState.Closed Then
                objConn.Close()
            End If
        End Try

    End Sub

    Private Sub CancelUpload()
        Try
            If Not IsNothing(Me.session) Then
                If Me.session.Opened Then
                    Me.session.Abort()
                End If
            End If
        Catch
        End Try
        bWorker.CancelAsync()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CancelUpload()
        '     Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub WriteCommand(ByVal command As String, ByRef SSLstream As SslStream)
        Dim commandBytes() As Byte = Encoding.ASCII.GetBytes(command + Environment.NewLine)
        SSLstream.Write(commandBytes, 0, commandBytes.Length)
    End Sub

    Private Sub bWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bWorker.DoWork
        If IsBackupNecessary() = True Then

            Dim source = Application.StartupPath + "\Db\oofsl.mdb"
            Dim NameToUpload As String = Path.GetFileName(source)
            Dim now As Date = DateTime.Now
            Dim dt As String = DateTime.Now.Date.ToShortDateString.Replace("/", "-") + "-" + now.TimeOfDay.Hours.ToString() + "-" + now.TimeOfDay.Minutes.ToString() + "-" + now.TimeOfDay.Seconds.ToString()

            Dim sessionoptions As New SessionOptions
            With sessionoptions
                .Protocol = Protocol.Sftp
                '.FtpMode = FtpMode.Passive


                .HostName = Host
                .PortNumber = Port
                .UserName = FTPLogin
                .Password = FTPPassword

                .GiveUpSecurityAndAcceptAnySshHostKey = True
                .AddRawSettings("FSProtocol", "2")
                .AddRawSettings("MinTlsVersion", "3")
                .FtpSecure = FtpSecure.None

            End With
            Try
                session = New Session()
                AddHandler session.FileTransferProgress, AddressOf SessionFileTransferProgress
                session.Open(sessionoptions)
                Dim transferoptions As New TransferOptions
                transferoptions.TransferMode = TransferMode.Binary
                Dim transferResult As TransferOperationResult


                'ssh-ed25519 256 61:28:e7:7d:4f:69:4c:78:60:59:b8:92:15:d6:c4:3e
                Dim FolderName = FTPProvider + "/" + dt
                session.CreateDirectory(FolderName)
                transferResult = session.PutFiles(source, FolderName + "/", False, transferoptions)
                session.Close()
                transferResult.Check()
                UpdateBackupDate()
            Catch ex As Exception
                If ex.Message.IndexOf("Aborted") > -1 Then
                    Throw New Exception("Aborted by user")
                Else
                    Throw New Exception("Error connecting to remote backup server. Please contact support @ 1-877-358-7339")
                End If
            Finally

            End Try
        Else
            ' Throw New Exception("remote backup required")
        End If
    End Sub

    Private Sub SessionFileTransferProgress(ByVal sender As Object, ByVal e As FileTransferProgressEventArgs)
        bWorker.ReportProgress(e.FileProgress * 100)


    End Sub

    Private Sub bWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bWorker.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        ProgressBar1.Refresh()


    End Sub

    Private Sub bWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bWorker.RunWorkerCompleted

        If Not IsNothing(e.Error) Then
            MsgBox(e.Error.Message)
        Else
            MsgBox("Upload complete")

        End If
        Me.Close()
    End Sub

    Private Sub FTPBackup_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

    End Sub

    Private Sub FTPBackup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        CancelUpload()
    End Sub
End Class