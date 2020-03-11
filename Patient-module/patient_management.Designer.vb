<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class patient_management
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(patient_management))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.New_btn = New System.Windows.Forms.Button()
        Me.patients_list = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.patients_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.New_btn)
        Me.GroupBox1.Controls.Add(Me.patients_list)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 588)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Patients List"
        '
        'New_btn
        '
        Me.New_btn.Location = New System.Drawing.Point(161, 565)
        Me.New_btn.Name = "New_btn"
        Me.New_btn.Size = New System.Drawing.Size(145, 23)
        Me.New_btn.TabIndex = 1
        Me.New_btn.Text = "Create New patient"
        Me.New_btn.UseVisualStyleBackColor = True
        '
        'patients_list
        '
        Me.patients_list.AllowUserToAddRows = False
        Me.patients_list.AllowUserToDeleteRows = False
        Me.patients_list.AllowUserToResizeColumns = False
        Me.patients_list.AllowUserToResizeRows = False
        Me.patients_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.patients_list.Location = New System.Drawing.Point(8, 19)
        Me.patients_list.MultiSelect = False
        Me.patients_list.Name = "patients_list"
        Me.patients_list.ReadOnly = True
        Me.patients_list.Size = New System.Drawing.Size(298, 540)
        Me.patients_list.TabIndex = 0
        '
        'patient_management
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 613)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "patient_management"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patient Selector"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.patients_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents New_btn As System.Windows.Forms.Button
    Friend WithEvents patients_list As System.Windows.Forms.DataGridView
End Class
