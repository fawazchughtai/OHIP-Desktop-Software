<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reconciliation
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
        Me.ReconciliationDataGrid = New System.Windows.Forms.DataGridView()
        Me.ProcessingProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.ReconciliationDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReconciliationDataGrid
        '
        Me.ReconciliationDataGrid.AllowUserToAddRows = False
        Me.ReconciliationDataGrid.AllowUserToDeleteRows = False
        Me.ReconciliationDataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReconciliationDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReconciliationDataGrid.Location = New System.Drawing.Point(13, 13)
        Me.ReconciliationDataGrid.Name = "ReconciliationDataGrid"
        Me.ReconciliationDataGrid.ReadOnly = True
        Me.ReconciliationDataGrid.Size = New System.Drawing.Size(582, 226)
        Me.ReconciliationDataGrid.TabIndex = 0
        '
        'ProcessingProgressBar
        '
        Me.ProcessingProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ProcessingProgressBar.Location = New System.Drawing.Point(13, 246)
        Me.ProcessingProgressBar.Name = "ProcessingProgressBar"
        Me.ProcessingProgressBar.Size = New System.Drawing.Size(582, 23)
        Me.ProcessingProgressBar.TabIndex = 2
        Me.ProcessingProgressBar.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.Location = New System.Drawing.Point(244, 275)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Reconciliation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 306)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProcessingProgressBar)
        Me.Controls.Add(Me.ReconciliationDataGrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Reconciliation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reconciliation"
        CType(Me.ReconciliationDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReconciliationDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ProcessingProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
