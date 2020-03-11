Imports System.IO
Imports System.Net

Public Class FTPClient
    Private Host As String
    Private Port As Integer
    Private Username As String
    Private Password As String
    Private Client As System.Net.FtpClient.FtpClient


    Public Sub New(ByVal host As String, ByVal username As String, ByVal password As String, Optional ByVal port As Integer = 22)

        Me.Host = host
        Me.Port = port
        Me.Username = username
        Me.Password = password


    End Sub


    Public Function UploadFile(ByVal filename As String, Optional ByVal AddDate As Boolean = False) As Boolean

        Dim toReturn = False
        Client = New System.Net.FtpClient.FtpClient()
        Dim destPath As String = Me.Username
        Dim source = filename
        Client.Host = Me.Host
        '   Client.Port = Me.Port
        Client.Credentials = New NetworkCredential(Me.Username, Me.Password)
        Try
            Dim FileStream = File.OpenRead(source)
            Client.Connect()
            Dim NameToUpload As String = Path.GetFileName(source)
            If AddDate Then
                NameToUpload = NameToUpload.Replace(".", DateTime.Now.ToShortTimeString() + ".")
            End If
            Dim FtpStream = Client.OpenWrite((String.Format("{0}/{1}", destPath, Path.GetFileName(source))))
            FileStream.CopyTo(FtpStream)

            Client.Disconnect()
            MsgBox("Upload complete")
            toReturn = True
        Catch ex As Exception
            toReturn = False
            MsgBox(ex.Message)
        Finally
            Client.Disconnect()
        End Try
        Return toReturn
    End Function
End Class
