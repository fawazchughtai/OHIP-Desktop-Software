<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MOHMessages
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
        Me.MessageDataGrid = New System.Windows.Forms.DataGridView()
        Me.Closebtn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.MessageDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MessageDataGrid
        '
        Me.MessageDataGrid.AllowUserToAddRows = False
        Me.MessageDataGrid.AllowUserToDeleteRows = False
        Me.MessageDataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MessageDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MessageDataGrid.Location = New System.Drawing.Point(13, 13)
        Me.MessageDataGrid.Name = "MessageDataGrid"
        Me.MessageDataGrid.ReadOnly = True
        Me.MessageDataGrid.Size = New System.Drawing.Size(870, 296)
        Me.MessageDataGrid.TabIndex = 0
        '
        'Closebtn
        '
        Me.Closebtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Closebtn.Location = New System.Drawing.Point(408, 356)
        Me.Closebtn.Name = "Closebtn"
        Me.Closebtn.Size = New System.Drawing.Size(75, 23)
        Me.Closebtn.TabIndex = 1
        Me.Closebtn.Text = "OK"
        Me.Closebtn.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 316)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProgressBar1.Size = New System.Drawing.Size(870, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'MOHMessages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 389)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Closebtn)
        Me.Controls.Add(Me.MessageDataGrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "MOHMessages"
        Me.Text = "MOH Messages"
        CType(Me.MessageDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MessageDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Closebtn As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
