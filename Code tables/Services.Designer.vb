<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Services
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
        Me.ServicesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DeleteBtn = New System.Windows.Forms.Button()
        Me.NewService = New System.Windows.Forms.Button()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.Descriptionlbl = New System.Windows.Forms.Label()
        Me.DescriptionTxt = New System.Windows.Forms.TextBox()
        Me.ServiceCodelbl = New System.Windows.Forms.Label()
        Me.ServiceCodeTxt = New System.Windows.Forms.TextBox()
        Me.ServiceFeelbl = New System.Windows.Forms.Label()
        Me.ServiceFeeTxt = New System.Windows.Forms.TextBox()
        Me.RequiersRefferalCode = New System.Windows.Forms.CheckBox()
        Me.DefaultServiceCode = New System.Windows.Forms.CheckBox()
        Me.DescriptionIsValidLabel = New System.Windows.Forms.Label()
        Me.ServiceCodeIsValidLabel = New System.Windows.Forms.Label()
        Me.ServiceFeeIsValidLabel = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        CType(Me.ServicesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ServicesDataGridView
        '
        Me.ServicesDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ServicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ServicesDataGridView.Location = New System.Drawing.Point(13, 13)
        Me.ServicesDataGridView.Name = "ServicesDataGridView"
        Me.ServicesDataGridView.Size = New System.Drawing.Size(667, 182)
        Me.ServicesDataGridView.TabIndex = 0
        '
        'DeleteBtn
        '
        Me.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.DeleteBtn.Location = New System.Drawing.Point(595, 245)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.Size = New System.Drawing.Size(85, 23)
        Me.DeleteBtn.TabIndex = 1
        Me.DeleteBtn.Text = "Delete"
        Me.DeleteBtn.UseVisualStyleBackColor = True
        '
        'NewService
        '
        Me.NewService.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.NewService.Location = New System.Drawing.Point(595, 216)
        Me.NewService.Name = "NewService"
        Me.NewService.Size = New System.Drawing.Size(85, 23)
        Me.NewService.TabIndex = 2
        Me.NewService.Text = "New Service"
        Me.NewService.UseVisualStyleBackColor = True
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(290, 319)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(85, 23)
        Me.SaveBtn.TabIndex = 3
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'Descriptionlbl
        '
        Me.Descriptionlbl.AutoSize = True
        Me.Descriptionlbl.Location = New System.Drawing.Point(13, 202)
        Me.Descriptionlbl.Name = "Descriptionlbl"
        Me.Descriptionlbl.Size = New System.Drawing.Size(60, 13)
        Me.Descriptionlbl.TabIndex = 4
        Me.Descriptionlbl.Text = "Description"
        '
        'DescriptionTxt
        '
        Me.DescriptionTxt.Location = New System.Drawing.Point(16, 219)
        Me.DescriptionTxt.MaxLength = 255
        Me.DescriptionTxt.Name = "DescriptionTxt"
        Me.DescriptionTxt.Size = New System.Drawing.Size(385, 20)
        Me.DescriptionTxt.TabIndex = 5
        '
        'ServiceCodelbl
        '
        Me.ServiceCodelbl.AutoSize = True
        Me.ServiceCodelbl.Location = New System.Drawing.Point(16, 245)
        Me.ServiceCodelbl.Name = "ServiceCodelbl"
        Me.ServiceCodelbl.Size = New System.Drawing.Size(71, 13)
        Me.ServiceCodelbl.TabIndex = 6
        Me.ServiceCodelbl.Text = "Service Code"
        '
        'ServiceCodeTxt
        '
        Me.ServiceCodeTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ServiceCodeTxt.Location = New System.Drawing.Point(16, 262)
        Me.ServiceCodeTxt.MaxLength = 5
        Me.ServiceCodeTxt.Name = "ServiceCodeTxt"
        Me.ServiceCodeTxt.Size = New System.Drawing.Size(100, 20)
        Me.ServiceCodeTxt.TabIndex = 7
        '
        'ServiceFeelbl
        '
        Me.ServiceFeelbl.AutoSize = True
        Me.ServiceFeelbl.Location = New System.Drawing.Point(16, 289)
        Me.ServiceFeelbl.Name = "ServiceFeelbl"
        Me.ServiceFeelbl.Size = New System.Drawing.Size(64, 13)
        Me.ServiceFeelbl.TabIndex = 8
        Me.ServiceFeelbl.Text = "Service Fee"
        '
        'ServiceFeeTxt
        '
        Me.ServiceFeeTxt.Location = New System.Drawing.Point(16, 306)
        Me.ServiceFeeTxt.MaxLength = 1000
        Me.ServiceFeeTxt.Name = "ServiceFeeTxt"
        Me.ServiceFeeTxt.Size = New System.Drawing.Size(100, 20)
        Me.ServiceFeeTxt.TabIndex = 9
        '
        'RequiersRefferalCode
        '
        Me.RequiersRefferalCode.AutoSize = True
        Me.RequiersRefferalCode.Location = New System.Drawing.Point(122, 262)
        Me.RequiersRefferalCode.Name = "RequiersRefferalCode"
        Me.RequiersRefferalCode.Size = New System.Drawing.Size(175, 17)
        Me.RequiersRefferalCode.TabIndex = 10
        Me.RequiersRefferalCode.Text = "Service Requires Referral Code"
        Me.RequiersRefferalCode.UseVisualStyleBackColor = True
        Me.RequiersRefferalCode.Visible = False
        '
        'DefaultServiceCode
        '
        Me.DefaultServiceCode.AutoSize = True
        Me.DefaultServiceCode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DefaultServiceCode.Location = New System.Drawing.Point(551, 319)
        Me.DefaultServiceCode.Name = "DefaultServiceCode"
        Me.DefaultServiceCode.Size = New System.Drawing.Size(127, 17)
        Me.DefaultServiceCode.TabIndex = 11
        Me.DefaultServiceCode.Text = "Default Service Code"
        Me.DefaultServiceCode.UseVisualStyleBackColor = True
        Me.DefaultServiceCode.Visible = False
        '
        'DescriptionIsValidLabel
        '
        Me.DescriptionIsValidLabel.AutoSize = True
        Me.DescriptionIsValidLabel.ForeColor = System.Drawing.Color.Red
        Me.DescriptionIsValidLabel.Location = New System.Drawing.Point(78, 202)
        Me.DescriptionIsValidLabel.Name = "DescriptionIsValidLabel"
        Me.DescriptionIsValidLabel.Size = New System.Drawing.Size(38, 13)
        Me.DescriptionIsValidLabel.TabIndex = 62
        Me.DescriptionIsValidLabel.Text = "Invalid"
        Me.DescriptionIsValidLabel.Visible = False
        '
        'ServiceCodeIsValidLabel
        '
        Me.ServiceCodeIsValidLabel.AutoSize = True
        Me.ServiceCodeIsValidLabel.ForeColor = System.Drawing.Color.Red
        Me.ServiceCodeIsValidLabel.Location = New System.Drawing.Point(93, 245)
        Me.ServiceCodeIsValidLabel.Name = "ServiceCodeIsValidLabel"
        Me.ServiceCodeIsValidLabel.Size = New System.Drawing.Size(38, 13)
        Me.ServiceCodeIsValidLabel.TabIndex = 63
        Me.ServiceCodeIsValidLabel.Text = "Invalid"
        Me.ServiceCodeIsValidLabel.Visible = False
        '
        'ServiceFeeIsValidLabel
        '
        Me.ServiceFeeIsValidLabel.AutoSize = True
        Me.ServiceFeeIsValidLabel.ForeColor = System.Drawing.Color.Red
        Me.ServiceFeeIsValidLabel.Location = New System.Drawing.Point(79, 289)
        Me.ServiceFeeIsValidLabel.Name = "ServiceFeeIsValidLabel"
        Me.ServiceFeeIsValidLabel.Size = New System.Drawing.Size(227, 13)
        Me.ServiceFeeIsValidLabel.TabIndex = 64
        Me.ServiceFeeIsValidLabel.Text = "Invalid (must be between $0.00 and $5000.00)"
        Me.ServiceFeeIsValidLabel.Visible = False
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.CloseButton.Location = New System.Drawing.Point(595, 274)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(85, 23)
        Me.CloseButton.TabIndex = 65
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Services
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 348)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.ServiceFeeIsValidLabel)
        Me.Controls.Add(Me.ServiceCodeIsValidLabel)
        Me.Controls.Add(Me.DescriptionIsValidLabel)
        Me.Controls.Add(Me.DefaultServiceCode)
        Me.Controls.Add(Me.RequiersRefferalCode)
        Me.Controls.Add(Me.ServiceFeeTxt)
        Me.Controls.Add(Me.ServiceFeelbl)
        Me.Controls.Add(Me.ServiceCodeTxt)
        Me.Controls.Add(Me.ServiceCodelbl)
        Me.Controls.Add(Me.DescriptionTxt)
        Me.Controls.Add(Me.Descriptionlbl)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.NewService)
        Me.Controls.Add(Me.DeleteBtn)
        Me.Controls.Add(Me.ServicesDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Services"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Services"
        CType(Me.ServicesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ServicesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DeleteBtn As System.Windows.Forms.Button
    Friend WithEvents NewService As System.Windows.Forms.Button
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents Descriptionlbl As System.Windows.Forms.Label
    Friend WithEvents DescriptionTxt As System.Windows.Forms.TextBox
    Friend WithEvents ServiceCodelbl As System.Windows.Forms.Label
    Friend WithEvents ServiceCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents ServiceFeelbl As System.Windows.Forms.Label
    Friend WithEvents ServiceFeeTxt As System.Windows.Forms.TextBox
    Friend WithEvents RequiersRefferalCode As System.Windows.Forms.CheckBox
    Friend WithEvents DefaultServiceCode As System.Windows.Forms.CheckBox
    Friend WithEvents DescriptionIsValidLabel As System.Windows.Forms.Label
    Friend WithEvents ServiceCodeIsValidLabel As System.Windows.Forms.Label
    Friend WithEvents ServiceFeeIsValidLabel As System.Windows.Forms.Label
    Friend WithEvents CloseButton As System.Windows.Forms.Button
End Class
