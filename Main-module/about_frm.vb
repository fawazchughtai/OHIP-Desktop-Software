Option Strict Off
Option Explicit On
Friend Class about_frm
	Inherits System.Windows.Forms.Form

    Private Sub about_frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        Label3.Text = "Version:" & Application.ProductVersion

        If OOFSL_main.unlock_app Then
            Label2.Text = "System Activated"
        Else
            Label2.Text = "System Requires Activation code"
        End If


    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim objact As New ActivationClass
        objact.activate()
    End Sub


End Class