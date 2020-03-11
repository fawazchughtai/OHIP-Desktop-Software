Public Class SelectMRICode

    Private Sub SelectOffice(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkBtn.Click
        Select Case Offices.Text
            Case "Hamilton"
                PhysicianInfo.MOHOfficeCodetxt.Text = "G"
            Case "Kingston"
                PhysicianInfo.MOHOfficeCodetxt.Text = "J"
            Case "London"
                PhysicianInfo.MOHOfficeCodetxt.Text = "P"
            Case "Mississauga"
                PhysicianInfo.MOHOfficeCodetxt.Text = "E"
            Case "Oshawa"
                PhysicianInfo.MOHOfficeCodetxt.Text = "F"
            Case "Ottawa"
                PhysicianInfo.MOHOfficeCodetxt.Text = "D"
            Case "Sudbury"
                PhysicianInfo.MOHOfficeCodetxt.Text = "R"
            Case "Thunder Bay"
                PhysicianInfo.MOHOfficeCodetxt.Text = "U"
            Case "Toronto"
                PhysicianInfo.MOHOfficeCodetxt.Text = "N"
        End Select
        Me.Hide()
    End Sub
End Class