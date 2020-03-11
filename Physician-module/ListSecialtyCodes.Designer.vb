<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListSpecialtyCodes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SpecialtyCodeListBox = New System.Windows.Forms.ListBox()
        Me.OKbtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SpecialtyCodeListBox
        '
        Me.SpecialtyCodeListBox.FormattingEnabled = True
        Me.SpecialtyCodeListBox.Location = New System.Drawing.Point(13, 13)
        Me.SpecialtyCodeListBox.Name = "SpecialtyCodeListBox"
        Me.SpecialtyCodeListBox.Size = New System.Drawing.Size(691, 199)
        Me.SpecialtyCodeListBox.TabIndex = 0
        '
        'OKbtn
        '
        Me.OKbtn.Location = New System.Drawing.Point(53, 227)
        Me.OKbtn.Name = "OKbtn"
        Me.OKbtn.Size = New System.Drawing.Size(75, 23)
        Me.OKbtn.TabIndex = 1
        Me.OKbtn.Text = "OK"
        Me.OKbtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Location = New System.Drawing.Point(145, 227)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.CancelBtn.TabIndex = 2
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'ListSpecialtyCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 262)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKbtn)
        Me.Controls.Add(Me.SpecialtyCodeListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListSpecialtyCodes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Specialty Codes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpecialtyCodeListBox As System.Windows.Forms.ListBox
    Friend WithEvents OKbtn As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
End Class
