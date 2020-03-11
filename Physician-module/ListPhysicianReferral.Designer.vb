<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListPhysicianReferral
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
        Me.PhysicianReferralListBox = New System.Windows.Forms.ListBox()
        Me.OKbtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.ref_list = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'PhysicianReferralListBox
        '
        Me.PhysicianReferralListBox.FormattingEnabled = True
        Me.PhysicianReferralListBox.Location = New System.Drawing.Point(12, 51)
        Me.PhysicianReferralListBox.Name = "PhysicianReferralListBox"
        Me.PhysicianReferralListBox.Size = New System.Drawing.Size(259, 225)
        Me.PhysicianReferralListBox.TabIndex = 0
        '
        'OKbtn
        '
        Me.OKbtn.Location = New System.Drawing.Point(59, 292)
        Me.OKbtn.Name = "OKbtn"
        Me.OKbtn.Size = New System.Drawing.Size(75, 23)
        Me.OKbtn.TabIndex = 1
        Me.OKbtn.Text = "OK"
        Me.OKbtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Location = New System.Drawing.Point(151, 292)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.CancelBtn.TabIndex = 2
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'ref_list
        '
        Me.ref_list.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ref_list.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ref_list.FormattingEnabled = True
        Me.ref_list.Location = New System.Drawing.Point(12, 13)
        Me.ref_list.Name = "ref_list"
        Me.ref_list.Size = New System.Drawing.Size(259, 21)
        Me.ref_list.TabIndex = 3
        '
        'ListPhysicianReferral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 327)
        Me.Controls.Add(Me.ref_list)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKbtn)
        Me.Controls.Add(Me.PhysicianReferralListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListPhysicianReferral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Physician "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PhysicianReferralListBox As System.Windows.Forms.ListBox
    Friend WithEvents OKbtn As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents ref_list As System.Windows.Forms.ComboBox
End Class
