Public Class ClaimFileViewer
    Public filename As String
    Private filePath As String = currPath & "\OutputFiles\"
    Private Sub ClaimFileViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        Dim FullFilePath As String = filePath & filename
        Dim objReader As New System.IO.StreamReader(FullFilePath)
        TextBox1.Text = objReader.ReadToEnd
        TextBox1.ReadOnly = True
        Me.ActiveControl = Closebtn

    End Sub

    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Closebtn.Click
        Me.Hide()
    End Sub
End Class