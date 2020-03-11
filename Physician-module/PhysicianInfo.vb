Public Class PhysicianInfo
    Private Sub PhysicianInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        Dim objPhysician As New PhysicianClass
        objPhysician.load_Physician()
    End Sub

    Private Sub Savebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Savebtn.Click
        Dim objPhysician As New PhysicianClass
        objPhysician.save()
    End Sub

    Private Sub OfficeCodeLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objSelectMRICode As New SelectMRICode
        objSelectMRICode.ShowDialog()
        objSelectMRICode.Focus()
    End Sub

    Private Sub SpecialtyLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListSpecialtyCodes.ShowDialog(Me)
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub SpecialtyLookup_Click_1(sender As Object, e As EventArgs) Handles SpecialtyLookup.Click
        ListSpecialtyCodes.ShowDialog(Me)

    End Sub
End Class