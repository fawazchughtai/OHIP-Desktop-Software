<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemFilePaths
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.BackupFolder = New System.Windows.Forms.TextBox()
        Me.BackupBtn = New System.Windows.Forms.Button()
        Me.Savebtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Backup Folder"
        '
        'BackupFolder
        '
        Me.BackupFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BackupFolder.Location = New System.Drawing.Point(12, 25)
        Me.BackupFolder.Name = "BackupFolder"
        Me.BackupFolder.Size = New System.Drawing.Size(386, 20)
        Me.BackupFolder.TabIndex = 7
        '
        'BackupBtn
        '
        Me.BackupBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BackupBtn.Location = New System.Drawing.Point(395, 22)
        Me.BackupBtn.Name = "BackupBtn"
        Me.BackupBtn.Size = New System.Drawing.Size(85, 23)
        Me.BackupBtn.TabIndex = 8
        Me.BackupBtn.Text = "Browse"
        Me.BackupBtn.UseVisualStyleBackColor = True
        '
        'Savebtn
        '
        Me.Savebtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Savebtn.Location = New System.Drawing.Point(195, 54)
        Me.Savebtn.Name = "Savebtn"
        Me.Savebtn.Size = New System.Drawing.Size(75, 23)
        Me.Savebtn.TabIndex = 9
        Me.Savebtn.Text = "Save "
        Me.Savebtn.UseVisualStyleBackColor = True
        '
        'SystemFilePaths
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 89)
        Me.Controls.Add(Me.Savebtn)
        Me.Controls.Add(Me.BackupBtn)
        Me.Controls.Add(Me.BackupFolder)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "SystemFilePaths"
        Me.Text = "System File Paths"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BackupFolder As System.Windows.Forms.TextBox
    Friend WithEvents BackupBtn As System.Windows.Forms.Button
    Friend WithEvents Savebtn As System.Windows.Forms.Button
End Class
