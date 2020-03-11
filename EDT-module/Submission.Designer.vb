<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Submission
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
        Me.UnSubmittedClaimsGroupBox = New System.Windows.Forms.GroupBox()
        Me.UnSubmitedDataGridView = New System.Windows.Forms.DataGridView()
        Me.Close = New System.Windows.Forms.Button()
        Me.SubmitedGroupBox = New System.Windows.Forms.GroupBox()
        Me.SubmitedDataGridView = New System.Windows.Forms.DataGridView()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.UnSubmittedClaimsGroupBox.SuspendLayout()
        CType(Me.UnSubmitedDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SubmitedGroupBox.SuspendLayout()
        CType(Me.SubmitedDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UnSubmittedClaimsGroupBox
        '
        Me.UnSubmittedClaimsGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UnSubmittedClaimsGroupBox.Controls.Add(Me.UnSubmitedDataGridView)
        Me.UnSubmittedClaimsGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.UnSubmittedClaimsGroupBox.Name = "UnSubmittedClaimsGroupBox"
        Me.UnSubmittedClaimsGroupBox.Size = New System.Drawing.Size(694, 218)
        Me.UnSubmittedClaimsGroupBox.TabIndex = 0
        Me.UnSubmittedClaimsGroupBox.TabStop = False
        Me.UnSubmittedClaimsGroupBox.Text = "Open Claims"
        '
        'UnSubmitedDataGridView
        '
        Me.UnSubmitedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UnSubmitedDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnSubmitedDataGridView.Location = New System.Drawing.Point(3, 16)
        Me.UnSubmitedDataGridView.Name = "UnSubmitedDataGridView"
        Me.UnSubmitedDataGridView.Size = New System.Drawing.Size(688, 199)
        Me.UnSubmitedDataGridView.TabIndex = 0
        '
        'Close
        '
        Me.Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Close.Location = New System.Drawing.Point(334, 450)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(75, 23)
        Me.Close.TabIndex = 3
        Me.Close.Text = "Close"
        Me.Close.UseVisualStyleBackColor = True
        '
        'SubmitedGroupBox
        '
        Me.SubmitedGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SubmitedGroupBox.Controls.Add(Me.SubmitedDataGridView)
        Me.SubmitedGroupBox.Location = New System.Drawing.Point(12, 273)
        Me.SubmitedGroupBox.Name = "SubmitedGroupBox"
        Me.SubmitedGroupBox.Size = New System.Drawing.Size(694, 170)
        Me.SubmitedGroupBox.TabIndex = 4
        Me.SubmitedGroupBox.TabStop = False
        Me.SubmitedGroupBox.Text = "Created Claims"
        Me.SubmitedGroupBox.UseCompatibleTextRendering = True
        '
        'SubmitedDataGridView
        '
        Me.SubmitedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SubmitedDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubmitedDataGridView.Location = New System.Drawing.Point(3, 16)
        Me.SubmitedDataGridView.Name = "SubmitedDataGridView"
        Me.SubmitedDataGridView.Size = New System.Drawing.Size(688, 151)
        Me.SubmitedDataGridView.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(17, 236)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(688, 27)
        Me.ProgressBar1.TabIndex = 5
        '
        'Submission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 485)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.SubmitedGroupBox)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.UnSubmittedClaimsGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Submission"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Submission"
        Me.UnSubmittedClaimsGroupBox.ResumeLayout(False)
        CType(Me.UnSubmitedDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SubmitedGroupBox.ResumeLayout(False)
        CType(Me.SubmitedDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UnSubmittedClaimsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents UnSubmitedDataGridView As System.Windows.Forms.DataGridView
    Friend Shadows WithEvents Close As System.Windows.Forms.Button
    Friend WithEvents SubmitedGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SubmitedDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
