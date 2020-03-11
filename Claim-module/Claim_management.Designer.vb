<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Claim_management
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Claim_management))
        Me.Claims_tree = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'Claims_tree
        '
        Me.Claims_tree.Location = New System.Drawing.Point(0, 0)
        Me.Claims_tree.Name = "Claims_tree"
        Me.Claims_tree.Size = New System.Drawing.Size(253, 589)
        Me.Claims_tree.TabIndex = 0
        '
        'Claim_management
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 613)
        Me.Controls.Add(Me.Claims_tree)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Claim_management"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Claims Management"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Claims_tree As System.Windows.Forms.TreeView
End Class
