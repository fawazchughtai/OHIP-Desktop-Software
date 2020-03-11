<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Referral
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
        Me.ReferralDataGridView = New System.Windows.Forms.DataGridView()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.NewService = New System.Windows.Forms.Button()
        Me.DeleteBtn = New System.Windows.Forms.Button()
        Me.OHIPRegistrationNumberTxt = New System.Windows.Forms.TextBox()
        Me.OHIPRegistrationlbl = New System.Windows.Forms.Label()
        Me.PhysicianNameTxt = New System.Windows.Forms.TextBox()
        Me.PhysicianNamelbl = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        CType(Me.ReferralDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReferralDataGridView
        '
        Me.ReferralDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReferralDataGridView.Location = New System.Drawing.Point(12, 12)
        Me.ReferralDataGridView.Name = "ReferralDataGridView"
        Me.ReferralDataGridView.Size = New System.Drawing.Size(489, 182)
        Me.ReferralDataGridView.TabIndex = 1
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(222, 313)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(85, 23)
        Me.SaveBtn.TabIndex = 6
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'NewService
        '
        Me.NewService.Location = New System.Drawing.Point(416, 216)
        Me.NewService.Name = "NewService"
        Me.NewService.Size = New System.Drawing.Size(85, 23)
        Me.NewService.TabIndex = 5
        Me.NewService.Text = "New"
        Me.NewService.UseVisualStyleBackColor = True
        '
        'DeleteBtn
        '
        Me.DeleteBtn.Location = New System.Drawing.Point(416, 245)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.Size = New System.Drawing.Size(85, 23)
        Me.DeleteBtn.TabIndex = 4
        Me.DeleteBtn.Text = "Delete"
        Me.DeleteBtn.UseVisualStyleBackColor = True
        '
        'OHIPRegistrationNumberTxt
        '
        Me.OHIPRegistrationNumberTxt.Location = New System.Drawing.Point(12, 263)
        Me.OHIPRegistrationNumberTxt.MaxLength = 6
        Me.OHIPRegistrationNumberTxt.Name = "OHIPRegistrationNumberTxt"
        Me.OHIPRegistrationNumberTxt.Size = New System.Drawing.Size(132, 20)
        Me.OHIPRegistrationNumberTxt.TabIndex = 11
        '
        'OHIPRegistrationlbl
        '
        Me.OHIPRegistrationlbl.AutoSize = True
        Me.OHIPRegistrationlbl.Location = New System.Drawing.Point(12, 246)
        Me.OHIPRegistrationlbl.Name = "OHIPRegistrationlbl"
        Me.OHIPRegistrationlbl.Size = New System.Drawing.Size(86, 13)
        Me.OHIPRegistrationlbl.TabIndex = 10
        Me.OHIPRegistrationlbl.Text = "Provider Number"
        '
        'PhysicianNameTxt
        '
        Me.PhysicianNameTxt.Location = New System.Drawing.Point(12, 219)
        Me.PhysicianNameTxt.Name = "PhysicianNameTxt"
        Me.PhysicianNameTxt.Size = New System.Drawing.Size(385, 20)
        Me.PhysicianNameTxt.TabIndex = 9
        '
        'PhysicianNamelbl
        '
        Me.PhysicianNamelbl.AutoSize = True
        Me.PhysicianNamelbl.Location = New System.Drawing.Point(9, 203)
        Me.PhysicianNamelbl.Name = "PhysicianNamelbl"
        Me.PhysicianNamelbl.Size = New System.Drawing.Size(83, 13)
        Me.PhysicianNamelbl.TabIndex = 8
        Me.PhysicianNamelbl.Text = "Physician Name"
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(416, 274)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(85, 23)
        Me.CloseButton.TabIndex = 12
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Referral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 348)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.OHIPRegistrationNumberTxt)
        Me.Controls.Add(Me.OHIPRegistrationlbl)
        Me.Controls.Add(Me.PhysicianNameTxt)
        Me.Controls.Add(Me.PhysicianNamelbl)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.NewService)
        Me.Controls.Add(Me.DeleteBtn)
        Me.Controls.Add(Me.ReferralDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Referral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List of Physician"
        CType(Me.ReferralDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReferralDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents NewService As System.Windows.Forms.Button
    Friend WithEvents DeleteBtn As System.Windows.Forms.Button
    Friend WithEvents OHIPRegistrationNumberTxt As System.Windows.Forms.TextBox
    Friend WithEvents OHIPRegistrationlbl As System.Windows.Forms.Label
    Friend WithEvents PhysicianNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents PhysicianNamelbl As System.Windows.Forms.Label
    Friend WithEvents CloseButton As System.Windows.Forms.Button
End Class
