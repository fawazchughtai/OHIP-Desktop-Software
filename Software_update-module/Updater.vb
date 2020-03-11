Imports System.IO
Imports System.Net
Imports System.Text

Public Class Updater
    Public Downuri As String
    Private Sub Updater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load





    End Sub
    Public Sub check()



        Dim URI As String



        URI = "http://www.ohip-billing.info/v7/version.htm"

        'Edit URI to your Program.zip-file. 


        Try
            Dim request As WebRequest = WebRequest.Create(URI)
            Dim hasinternet As Boolean
            'Create new WebResponse for checking the response
            'from our WebRequest
            Label1.Text = "Checking for internet connection"
            OOFSL_main.status_bar_txt.Text = "Checking for internet connection"
            Application.DoEvents()

            Dim response As WebResponse
            Try
                'If we get a response then we are successful
                response = request.GetResponse()
                Application.DoEvents()
                'Close and dispose
                response.Close()
                request = Nothing

                response.Close()
                request = Nothing

                'Return true and a connection was made
                hasinternet = True
            Catch ex As Exception
                'Whoops, got an error so no connection is present
                Label1.Text = "No internet connection found"
                hasinternet = False
            End Try

            If hasinternet Then


                Try
                    Label1.Text = "checking for updates"
                    OOFSL_main.status_bar_txt.Text = "checking for updates"
                    Application.DoEvents()

                    Dim wr As HttpWebRequest = CType(WebRequest.Create(URI.ToString), HttpWebRequest)
                    Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
                    Dim str As Stream = ws.GetResponseStream()
                    Dim inBuf(100000) As Byte
                    Dim bytesToRead As Integer = CInt(inBuf.Length)
                    Dim bytesRead As Integer = 0
                    While bytesToRead > 0
                        Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)
                        If n = 0 Then
                            Exit While
                        End If
                        bytesRead += n
                        bytesToRead -= n

                    End While
                    Dim fstr As New FileStream("version.txt", FileMode.OpenOrCreate, FileAccess.Write)
                    fstr.Write(inBuf, 0, bytesRead)
                    str.Close()
                    fstr.Close()
                    Dim sr As StreamReader = New System.IO.StreamReader("version.txt")
                    Dim version As Integer = CInt(sr.ReadToEnd.Replace(".", "").Substring(0, 4))
                    sr.Close()
                    If version > CInt(Application.ProductVersion.Replace(".", "")) Then

                        OOFSL_main.status_bar_txt.Text = "Click here to download updates"
                        Application.DoEvents()

                        OOFSL_main.update_avail = True

                    Else
                        Label1.Text = "System up-to-date"
                        OOFSL_main.status_bar_txt.Text = "System up-to-date"
                        'MsgBox("System up-to-date")
                        Application.DoEvents()
                    End If

                Catch ex As Exception

                End Try

            Else
                OOFSL_main.status_bar_txt.Text = "No Internet"
                Application.DoEvents()
            End If
        Catch ex As Exception

        End Try
        Close()
    End Sub


    Public Sub check_status()



        Dim URI As String

        Dim objPhysician As New PhysicianClass
        objPhysician.load_Physician()


        URI = "http://www.ohip-billing.info/dr/" & PhysicianInfo.OHIPBillingNumbertxt.Text & "/service_date.htm"

        Try
            Dim request As WebRequest = WebRequest.Create(URI)
            Dim hasinternet As Boolean
           

            Dim response As WebResponse
            Try
                'If we get a response then we are successful
                response = request.GetResponse()

                'Close and dispose
                response.Close()
                request = Nothing

                response.Close()
                request = Nothing

                'Return true and a connection was made
                hasinternet = True
            Catch ex As Exception
                'Whoops, got an error so no connection is present

                hasinternet = False
            End Try

            If hasinternet Then


                Try

                    Dim wr As HttpWebRequest = CType(WebRequest.Create(URI.ToString), HttpWebRequest)
                    Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
                    Dim str As Stream = ws.GetResponseStream()
                    Dim data As String
                  

                    Dim reader As New StreamReader(ws.GetResponseStream())
                    data = reader.ReadToEnd()
    
                    If Today.ToString("yyyyMMdd") >= data Then
                        OOFSL_main.service_expire = True
                    Else
                        OOFSL_main.service_expire = False
                    End If



                Catch ex As Exception

                End Try

            Else
               
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        check_status()
        check()

    End Sub
End Class