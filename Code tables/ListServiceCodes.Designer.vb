<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListServiceCodes
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
        Me.ServiceCodeListBox = New System.Windows.Forms.ListBox()
        Me.OKbtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ServiceCodeListBox
        '
        Me.ServiceCodeListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ServiceCodeListBox.FormattingEnabled = True
        Me.ServiceCodeListBox.Location = New System.Drawing.Point(13, 13)
        Me.ServiceCodeListBox.Name = "ServiceCodeListBox"
        Me.ServiceCodeListBox.Size = New System.Drawing.Size(539, 199)
        Me.ServiceCodeListBox.TabIndex = 0
        '
        'OKbtn
        '
        Me.OKbtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.OKbtn.Location = New System.Drawing.Point(190, 227)
        Me.OKbtn.Name = "OKbtn"
        Me.OKbtn.Size = New System.Drawing.Size(75, 23)
        Me.OKbtn.TabIndex = 1
        Me.OKbtn.Text = "OK"
        Me.OKbtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CancelBtn.Location = New System.Drawing.Point(286, 227)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.CancelBtn.TabIndex = 2
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'ListServiceCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 262)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKbtn)
        Me.Controls.Add(Me.ServiceCodeListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListServiceCodes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Service Code"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ServiceCodeListBox As System.Windows.Forms.ListBox
    Friend WithEvents OKbtn As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
End Class
