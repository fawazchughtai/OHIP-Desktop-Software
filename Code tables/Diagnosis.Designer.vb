<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Diagnosis
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
        Me.DiagnosisDataGridView = New System.Windows.Forms.DataGridView()
        Me.DeleteBtn = New System.Windows.Forms.Button()
        Me.NewService = New System.Windows.Forms.Button()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.Descriptionlbl = New System.Windows.Forms.Label()
        Me.DescriptionTxt = New System.Windows.Forms.TextBox()
        Me.ServiceCodelbl = New System.Windows.Forms.Label()
        Me.ServiceCodeTxt = New System.Windows.Forms.TextBox()
        Me.DescriptionIsValidLabel = New System.Windows.Forms.Label()
        Me.ServiceCodeIsValidLabel = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        CType(Me.DiagnosisDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DiagnosisDataGridView
        '
        Me.DiagnosisDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DiagnosisDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DiagnosisDataGridView.Location = New System.Drawing.Point(13, 13)
        Me.DiagnosisDataGridView.Name = "DiagnosisDataGridView"
        Me.DiagnosisDataGridView.Size = New System.Drawing.Size(617, 182)
        Me.DiagnosisDataGridView.TabIndex = 0
        '
        'DeleteBtn
        '
        Me.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.DeleteBtn.Location = New System.Drawing.Point(545, 244)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.Size = New System.Drawing.Size(85, 23)
        Me.DeleteBtn.TabIndex = 1
        Me.DeleteBtn.Text = "Delete"
        Me.DeleteBtn.UseVisualStyleBackColor = True
        '
        'NewService
        '
        Me.NewService.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.NewService.Location = New System.Drawing.Point(545, 216)
        Me.NewService.Name = "NewService"
        Me.NewService.Size = New System.Drawing.Size(85, 23)
        Me.NewService.TabIndex = 2
        Me.NewService.Text = "New "
        Me.NewService.UseVisualStyleBackColor = True
        '
        'SaveBtn
        '
        Me.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.SaveBtn.Location = New System.Drawing.Point(287, 274)
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
        Me.DescriptionTxt.Location = New System.Drawing.Point(16, 218)
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
        Me.ServiceCodelbl.Size = New System.Drawing.Size(81, 13)
        Me.ServiceCodelbl.TabIndex = 6
        Me.ServiceCodelbl.Text = "Diagnosis Code"
        '
        'ServiceCodeTxt
        '
        Me.ServiceCodeTxt.Location = New System.Drawing.Point(16, 262)
        Me.ServiceCodeTxt.MaxLength = 50
        Me.ServiceCodeTxt.Name = "ServiceCodeTxt"
        Me.ServiceCodeTxt.Size = New System.Drawing.Size(100, 20)
        Me.ServiceCodeTxt.TabIndex = 7
        '
        'DescriptionIsValidLabel
        '
        Me.DescriptionIsValidLabel.AutoSize = True
        Me.DescriptionIsValidLabel.ForeColor = System.Drawing.Color.Red
        Me.DescriptionIsValidLabel.Location = New System.Drawing.Point(79, 202)
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
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(545, 274)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(85, 23)
        Me.CloseButton.TabIndex = 64
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Diagnosis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 307)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.ServiceCodeIsValidLabel)
        Me.Controls.Add(Me.DescriptionIsValidLabel)
        Me.Controls.Add(Me.ServiceCodeTxt)
        Me.Controls.Add(Me.ServiceCodelbl)
        Me.Controls.Add(Me.DescriptionTxt)
        Me.Controls.Add(Me.Descriptionlbl)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.NewService)
        Me.Controls.Add(Me.DeleteBtn)
        Me.Controls.Add(Me.DiagnosisDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Diagnosis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diagnosis"
        CType(Me.DiagnosisDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DiagnosisDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DeleteBtn As System.Windows.Forms.Button
    Friend WithEvents NewService As System.Windows.Forms.Button
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents Descriptionlbl As System.Windows.Forms.Label
    Friend WithEvents DescriptionTxt As System.Windows.Forms.TextBox
    Friend WithEvents ServiceCodelbl As System.Windows.Forms.Label
    Friend WithEvents ServiceCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionIsValidLabel As System.Windows.Forms.Label
    Friend WithEvents ServiceCodeIsValidLabel As System.Windows.Forms.Label
    Friend WithEvents CloseButton As System.Windows.Forms.Button
End Class
