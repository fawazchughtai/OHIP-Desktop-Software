Public Class frmViewer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PrintViewer1 As dbAutoTrack.DataReports.Viewer.PrintViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PrintViewer1 = New dbAutoTrack.DataReports.Viewer.PrintViewer()
        Me.SuspendLayout()
        '
        'PrintViewer1
        '
        Me.PrintViewer1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PrintViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrintViewer1.Document = Nothing
        Me.PrintViewer1.HandToolState = False
        Me.PrintViewer1.Location = New System.Drawing.Point(0, 0)
        Me.PrintViewer1.Margin = New System.Windows.Forms.Padding(1)
        Me.PrintViewer1.Name = "PrintViewer1"
        Me.PrintViewer1.PagesInfoText = "1/1"
        Me.PrintViewer1.Size = New System.Drawing.Size(906, 435)
        Me.PrintViewer1.TabIndex = 0
        Me.PrintViewer1.ZoomSelectedIndex = 4
        Me.PrintViewer1.ZoomSelectedItem = "100%"
        Me.PrintViewer1.ZoomText = "100%"
        '
        'frmViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(906, 435)
        Me.Controls.Add(Me.PrintViewer1)
        Me.Name = "frmViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrintViewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
