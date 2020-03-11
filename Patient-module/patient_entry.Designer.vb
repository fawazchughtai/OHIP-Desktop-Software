<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class patient_entry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(patient_entry))
        Me.Cancelbtn = New System.Windows.Forms.Button()
        Me.Savebtn = New System.Windows.Forms.Button()
        Me.prov = New System.Windows.Forms.ComboBox()
        Me.DOB = New System.Windows.Forms.DateTimePicker()
        Me.Sex_f = New System.Windows.Forms.RadioButton()
        Me.Sex_m = New System.Windows.Forms.RadioButton()
        Me.plan_lbl = New System.Windows.Forms.Label()
        Me.prov_lbl = New System.Windows.Forms.Label()
        Me.Sex_lbl = New System.Windows.Forms.Label()
        Me.DOB_lbl = New System.Windows.Forms.Label()
        Me.ver_lbl = New System.Windows.Forms.Label()
        Me.ohip_lbl = New System.Windows.Forms.Label()
        Me.Lname_lbl = New System.Windows.Forms.Label()
        Me.Fname_lbl = New System.Windows.Forms.Label()
        Me.Plan = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dob_err = New System.Windows.Forms.PictureBox()
        Me.plan_err = New System.Windows.Forms.PictureBox()
        Me.prov_err = New System.Windows.Forms.PictureBox()
        Me.gender_err = New System.Windows.Forms.PictureBox()
        Me.fname_err = New System.Windows.Forms.PictureBox()
        Me.lname_err = New System.Windows.Forms.PictureBox()
        Me.Health_err = New System.Windows.Forms.PictureBox()
        Me.fname = New System.Windows.Forms.TextBox()
        Me.lname = New System.Windows.Forms.TextBox()
        Me.version = New System.Windows.Forms.TextBox()
        Me.health_num = New System.Windows.Forms.TextBox()
        Me.chart_id = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.email = New System.Windows.Forms.TextBox()
        Me.cell_tel = New System.Windows.Forms.TextBox()
        Me.home_Tel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Address = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Notes = New System.Windows.Forms.TextBox()
        Me.Delete_patient = New System.Windows.Forms.Button()
        Me.Find = New System.Windows.Forms.Button()
        Me.go_claims = New System.Windows.Forms.Button()
        Me.pat_history = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dob_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.plan_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.prov_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gender_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fname_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lname_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Health_err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancelbtn
        '
        Me.Cancelbtn.Location = New System.Drawing.Point(522, 578)
        Me.Cancelbtn.Name = "Cancelbtn"
        Me.Cancelbtn.Size = New System.Drawing.Size(75, 23)
        Me.Cancelbtn.TabIndex = 100
        Me.Cancelbtn.Text = "Clear form"
        Me.Cancelbtn.UseVisualStyleBackColor = True
        '
        'Savebtn
        '
        Me.Savebtn.Location = New System.Drawing.Point(360, 578)
        Me.Savebtn.Name = "Savebtn"
        Me.Savebtn.Size = New System.Drawing.Size(75, 23)
        Me.Savebtn.TabIndex = 1
        Me.Savebtn.Text = "Save"
        Me.Savebtn.UseVisualStyleBackColor = True
        '
        'prov
        '
        Me.prov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.prov.FormattingEnabled = True
        Me.prov.Items.AddRange(New Object() {"Alberta", "British Columbia", "Manitoba", "Newfoundland", "New Brunswick", "Northwest Territories", "Nova Scotia", "Ontario", "Prince Edward Island", "Saskatchewan", "Territory of Nunavut", "Yukon"})
        Me.prov.Location = New System.Drawing.Point(17, 306)
        Me.prov.Name = "prov"
        Me.prov.Size = New System.Drawing.Size(137, 21)
        Me.prov.TabIndex = 7
        '
        'DOB
        '
        Me.DOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DOB.Location = New System.Drawing.Point(138, 233)
        Me.DOB.Name = "DOB"
        Me.DOB.Size = New System.Drawing.Size(105, 20)
        Me.DOB.TabIndex = 6
        '
        'Sex_f
        '
        Me.Sex_f.BackColor = System.Drawing.SystemColors.Control
        Me.Sex_f.Cursor = System.Windows.Forms.Cursors.Default
        Me.Sex_f.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Sex_f.Location = New System.Drawing.Point(17, 250)
        Me.Sex_f.Name = "Sex_f"
        Me.Sex_f.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Sex_f.Size = New System.Drawing.Size(97, 25)
        Me.Sex_f.TabIndex = 5
        Me.Sex_f.TabStop = True
        Me.Sex_f.Text = "Female"
        Me.Sex_f.UseVisualStyleBackColor = False
        '
        'Sex_m
        '
        Me.Sex_m.BackColor = System.Drawing.SystemColors.Control
        Me.Sex_m.Cursor = System.Windows.Forms.Cursors.Default
        Me.Sex_m.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Sex_m.Location = New System.Drawing.Point(17, 228)
        Me.Sex_m.Name = "Sex_m"
        Me.Sex_m.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Sex_m.Size = New System.Drawing.Size(105, 25)
        Me.Sex_m.TabIndex = 4
        Me.Sex_m.TabStop = True
        Me.Sex_m.Text = "Male"
        Me.Sex_m.UseVisualStyleBackColor = False
        '
        'plan_lbl
        '
        Me.plan_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.plan_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.plan_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.plan_lbl.Location = New System.Drawing.Point(161, 285)
        Me.plan_lbl.Name = "plan_lbl"
        Me.plan_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.plan_lbl.Size = New System.Drawing.Size(129, 17)
        Me.plan_lbl.TabIndex = 110
        Me.plan_lbl.Text = "Plan"
        '
        'prov_lbl
        '
        Me.prov_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.prov_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.prov_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prov_lbl.Location = New System.Drawing.Point(14, 286)
        Me.prov_lbl.Name = "prov_lbl"
        Me.prov_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prov_lbl.Size = New System.Drawing.Size(129, 17)
        Me.prov_lbl.TabIndex = 109
        Me.prov_lbl.Text = "Province"
        '
        'Sex_lbl
        '
        Me.Sex_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Sex_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Sex_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Sex_lbl.Location = New System.Drawing.Point(14, 208)
        Me.Sex_lbl.Name = "Sex_lbl"
        Me.Sex_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Sex_lbl.Size = New System.Drawing.Size(51, 17)
        Me.Sex_lbl.TabIndex = 108
        Me.Sex_lbl.Text = "Gender"
        '
        'DOB_lbl
        '
        Me.DOB_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.DOB_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DOB_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DOB_lbl.Location = New System.Drawing.Point(137, 208)
        Me.DOB_lbl.Name = "DOB_lbl"
        Me.DOB_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DOB_lbl.Size = New System.Drawing.Size(40, 22)
        Me.DOB_lbl.TabIndex = 107
        Me.DOB_lbl.Text = "D.O.B "
        '
        'ver_lbl
        '
        Me.ver_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.ver_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ver_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ver_lbl.Location = New System.Drawing.Point(161, 62)
        Me.ver_lbl.Name = "ver_lbl"
        Me.ver_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ver_lbl.Size = New System.Drawing.Size(57, 17)
        Me.ver_lbl.TabIndex = 106
        Me.ver_lbl.Text = "Version"
        '
        'ohip_lbl
        '
        Me.ohip_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.ohip_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ohip_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ohip_lbl.Location = New System.Drawing.Point(17, 62)
        Me.ohip_lbl.Name = "ohip_lbl"
        Me.ohip_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ohip_lbl.Size = New System.Drawing.Size(129, 17)
        Me.ohip_lbl.TabIndex = 105
        Me.ohip_lbl.Text = "Health Registration #"
        '
        'Lname_lbl
        '
        Me.Lname_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Lname_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Lname_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lname_lbl.Location = New System.Drawing.Point(17, 114)
        Me.Lname_lbl.Name = "Lname_lbl"
        Me.Lname_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lname_lbl.Size = New System.Drawing.Size(129, 17)
        Me.Lname_lbl.TabIndex = 104
        Me.Lname_lbl.Text = "Last Name"
        '
        'Fname_lbl
        '
        Me.Fname_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Fname_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Fname_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Fname_lbl.Location = New System.Drawing.Point(17, 161)
        Me.Fname_lbl.Name = "Fname_lbl"
        Me.Fname_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Fname_lbl.Size = New System.Drawing.Size(129, 17)
        Me.Fname_lbl.TabIndex = 103
        Me.Fname_lbl.Text = "First name"
        '
        'Plan
        '
        Me.Plan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Plan.FormattingEnabled = True
        Me.Plan.Items.AddRange(New Object() {"HCP", "WCB", "RMB"})
        Me.Plan.Location = New System.Drawing.Point(164, 305)
        Me.Plan.Name = "Plan"
        Me.Plan.Size = New System.Drawing.Size(121, 21)
        Me.Plan.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dob_err)
        Me.GroupBox1.Controls.Add(Me.plan_err)
        Me.GroupBox1.Controls.Add(Me.prov_err)
        Me.GroupBox1.Controls.Add(Me.gender_err)
        Me.GroupBox1.Controls.Add(Me.fname_err)
        Me.GroupBox1.Controls.Add(Me.lname_err)
        Me.GroupBox1.Controls.Add(Me.Health_err)
        Me.GroupBox1.Controls.Add(Me.fname)
        Me.GroupBox1.Controls.Add(Me.lname)
        Me.GroupBox1.Controls.Add(Me.version)
        Me.GroupBox1.Controls.Add(Me.health_num)
        Me.GroupBox1.Controls.Add(Me.chart_id)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ohip_lbl)
        Me.GroupBox1.Controls.Add(Me.Plan)
        Me.GroupBox1.Controls.Add(Me.Fname_lbl)
        Me.GroupBox1.Controls.Add(Me.Lname_lbl)
        Me.GroupBox1.Controls.Add(Me.ver_lbl)
        Me.GroupBox1.Controls.Add(Me.DOB_lbl)
        Me.GroupBox1.Controls.Add(Me.Sex_lbl)
        Me.GroupBox1.Controls.Add(Me.prov_lbl)
        Me.GroupBox1.Controls.Add(Me.plan_lbl)
        Me.GroupBox1.Controls.Add(Me.prov)
        Me.GroupBox1.Controls.Add(Me.DOB)
        Me.GroupBox1.Controls.Add(Me.Sex_m)
        Me.GroupBox1.Controls.Add(Me.Sex_f)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 345)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Patient Information Mandatory fields"
        '
        'dob_err
        '
        Me.dob_err.Image = CType(resources.GetObject("dob_err.Image"), System.Drawing.Image)
        Me.dob_err.InitialImage = CType(resources.GetObject("dob_err.InitialImage"), System.Drawing.Image)
        Me.dob_err.Location = New System.Drawing.Point(183, 198)
        Me.dob_err.Name = "dob_err"
        Me.dob_err.Size = New System.Drawing.Size(39, 32)
        Me.dob_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.dob_err.TabIndex = 129
        Me.dob_err.TabStop = False
        Me.dob_err.Visible = False
        '
        'plan_err
        '
        Me.plan_err.Image = CType(resources.GetObject("plan_err.Image"), System.Drawing.Image)
        Me.plan_err.InitialImage = CType(resources.GetObject("plan_err.InitialImage"), System.Drawing.Image)
        Me.plan_err.Location = New System.Drawing.Point(204, 270)
        Me.plan_err.Name = "plan_err"
        Me.plan_err.Size = New System.Drawing.Size(39, 32)
        Me.plan_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.plan_err.TabIndex = 128
        Me.plan_err.TabStop = False
        Me.plan_err.Visible = False
        '
        'prov_err
        '
        Me.prov_err.Image = CType(resources.GetObject("prov_err.Image"), System.Drawing.Image)
        Me.prov_err.InitialImage = CType(resources.GetObject("prov_err.InitialImage"), System.Drawing.Image)
        Me.prov_err.Location = New System.Drawing.Point(83, 271)
        Me.prov_err.Name = "prov_err"
        Me.prov_err.Size = New System.Drawing.Size(39, 32)
        Me.prov_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.prov_err.TabIndex = 127
        Me.prov_err.TabStop = False
        Me.prov_err.Visible = False
        '
        'gender_err
        '
        Me.gender_err.Image = CType(resources.GetObject("gender_err.Image"), System.Drawing.Image)
        Me.gender_err.InitialImage = CType(resources.GetObject("gender_err.InitialImage"), System.Drawing.Image)
        Me.gender_err.Location = New System.Drawing.Point(71, 221)
        Me.gender_err.Name = "gender_err"
        Me.gender_err.Size = New System.Drawing.Size(39, 32)
        Me.gender_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.gender_err.TabIndex = 126
        Me.gender_err.TabStop = False
        Me.gender_err.Visible = False
        '
        'fname_err
        '
        Me.fname_err.Image = CType(resources.GetObject("fname_err.Image"), System.Drawing.Image)
        Me.fname_err.InitialImage = CType(resources.GetObject("fname_err.InitialImage"), System.Drawing.Image)
        Me.fname_err.Location = New System.Drawing.Point(83, 146)
        Me.fname_err.Name = "fname_err"
        Me.fname_err.Size = New System.Drawing.Size(39, 32)
        Me.fname_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.fname_err.TabIndex = 125
        Me.fname_err.TabStop = False
        Me.fname_err.Visible = False
        '
        'lname_err
        '
        Me.lname_err.Image = CType(resources.GetObject("lname_err.Image"), System.Drawing.Image)
        Me.lname_err.InitialImage = CType(resources.GetObject("lname_err.InitialImage"), System.Drawing.Image)
        Me.lname_err.Location = New System.Drawing.Point(83, 99)
        Me.lname_err.Name = "lname_err"
        Me.lname_err.Size = New System.Drawing.Size(39, 32)
        Me.lname_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.lname_err.TabIndex = 124
        Me.lname_err.TabStop = False
        Me.lname_err.Visible = False
        '
        'Health_err
        '
        Me.Health_err.Image = CType(resources.GetObject("Health_err.Image"), System.Drawing.Image)
        Me.Health_err.InitialImage = CType(resources.GetObject("Health_err.InitialImage"), System.Drawing.Image)
        Me.Health_err.Location = New System.Drawing.Point(119, 62)
        Me.Health_err.Name = "Health_err"
        Me.Health_err.Size = New System.Drawing.Size(39, 32)
        Me.Health_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Health_err.TabIndex = 123
        Me.Health_err.TabStop = False
        Me.Health_err.Visible = False
        '
        'fname
        '
        Me.fname.Location = New System.Drawing.Point(20, 181)
        Me.fname.Name = "fname"
        Me.fname.Size = New System.Drawing.Size(244, 20)
        Me.fname.TabIndex = 3
        '
        'lname
        '
        Me.lname.Location = New System.Drawing.Point(20, 132)
        Me.lname.Name = "lname"
        Me.lname.Size = New System.Drawing.Size(244, 20)
        Me.lname.TabIndex = 2
        '
        'version
        '
        Me.version.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.version.Location = New System.Drawing.Point(164, 77)
        Me.version.MaxLength = 2
        Me.version.Name = "version"
        Me.version.Size = New System.Drawing.Size(35, 20)
        Me.version.TabIndex = 1
        '
        'health_num
        '
        Me.health_num.Location = New System.Drawing.Point(17, 77)
        Me.health_num.MaxLength = 12
        Me.health_num.Name = "health_num"
        Me.health_num.Size = New System.Drawing.Size(100, 20)
        Me.health_num.TabIndex = 0
        '
        'chart_id
        '
        Me.chart_id.Location = New System.Drawing.Point(17, 39)
        Me.chart_id.MaxLength = 16
        Me.chart_id.Name = "chart_id"
        Me.chart_id.ReadOnly = True
        Me.chart_id.Size = New System.Drawing.Size(100, 20)
        Me.chart_id.TabIndex = 122
        Me.chart_id.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(17, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(48, 18)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Chart #"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.email)
        Me.GroupBox2.Controls.Add(Me.cell_tel)
        Me.GroupBox2.Controls.Add(Me.home_Tel)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(327, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 106)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contact information Optional"
        '
        'email
        '
        Me.email.Location = New System.Drawing.Point(55, 74)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(270, 20)
        Me.email.TabIndex = 2
        '
        'cell_tel
        '
        Me.cell_tel.Location = New System.Drawing.Point(225, 45)
        Me.cell_tel.Name = "cell_tel"
        Me.cell_tel.Size = New System.Drawing.Size(100, 20)
        Me.cell_tel.TabIndex = 1
        '
        'home_Tel
        '
        Me.home_Tel.Location = New System.Drawing.Point(55, 45)
        Me.home_Tel.Name = "home_Tel"
        Me.home_Tel.Size = New System.Drawing.Size(100, 20)
        Me.home_Tel.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(15, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(34, 20)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Email"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(222, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(75, 17)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Mobile #"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(52, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Home #"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Address)
        Me.GroupBox3.Location = New System.Drawing.Point(327, 124)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(360, 233)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Address"
        '
        'Address
        '
        Me.Address.Location = New System.Drawing.Point(7, 20)
        Me.Address.Multiline = True
        Me.Address.Name = "Address"
        Me.Address.Size = New System.Drawing.Size(345, 207)
        Me.Address.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Notes)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 363)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(675, 209)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Notes"
        '
        'Notes
        '
        Me.Notes.Location = New System.Drawing.Point(7, 20)
        Me.Notes.Multiline = True
        Me.Notes.Name = "Notes"
        Me.Notes.Size = New System.Drawing.Size(660, 174)
        Me.Notes.TabIndex = 0
        '
        'Delete_patient
        '
        Me.Delete_patient.Location = New System.Drawing.Point(604, 578)
        Me.Delete_patient.Name = "Delete_patient"
        Me.Delete_patient.Size = New System.Drawing.Size(75, 23)
        Me.Delete_patient.TabIndex = 124
        Me.Delete_patient.Text = "Delete"
        Me.Delete_patient.UseVisualStyleBackColor = True
        '
        'Find
        '
        Me.Find.Location = New System.Drawing.Point(441, 578)
        Me.Find.Name = "Find"
        Me.Find.Size = New System.Drawing.Size(75, 23)
        Me.Find.TabIndex = 2
        Me.Find.Text = "Find"
        Me.Find.UseVisualStyleBackColor = True
        '
        'go_claims
        '
        Me.go_claims.Enabled = False
        Me.go_claims.Location = New System.Drawing.Point(12, 578)
        Me.go_claims.Name = "go_claims"
        Me.go_claims.Size = New System.Drawing.Size(101, 23)
        Me.go_claims.TabIndex = 125
        Me.go_claims.Text = "Claim Entry"
        Me.go_claims.UseVisualStyleBackColor = True
        '
        'pat_history
        '
        Me.pat_history.Location = New System.Drawing.Point(119, 578)
        Me.pat_history.Name = "pat_history"
        Me.pat_history.Size = New System.Drawing.Size(92, 23)
        Me.pat_history.TabIndex = 126
        Me.pat_history.Text = "View History"
        Me.pat_history.UseVisualStyleBackColor = True
        '
        'patient_entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 613)
        Me.Controls.Add(Me.pat_history)
        Me.Controls.Add(Me.go_claims)
        Me.Controls.Add(Me.Find)
        Me.Controls.Add(Me.Delete_patient)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Cancelbtn)
        Me.Controls.Add(Me.Savebtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "patient_entry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patient Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dob_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.plan_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.prov_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gender_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fname_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lname_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Health_err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancelbtn As System.Windows.Forms.Button
    Friend WithEvents Savebtn As System.Windows.Forms.Button
    Friend WithEvents prov As System.Windows.Forms.ComboBox
    Friend WithEvents DOB As System.Windows.Forms.DateTimePicker
    Public WithEvents Sex_f As System.Windows.Forms.RadioButton
    Public WithEvents Sex_m As System.Windows.Forms.RadioButton
    Public WithEvents plan_lbl As System.Windows.Forms.Label
    Public WithEvents prov_lbl As System.Windows.Forms.Label
    Public WithEvents Sex_lbl As System.Windows.Forms.Label
    Public WithEvents DOB_lbl As System.Windows.Forms.Label
    Public WithEvents ver_lbl As System.Windows.Forms.Label
    Public WithEvents ohip_lbl As System.Windows.Forms.Label
    Public WithEvents Lname_lbl As System.Windows.Forms.Label
    Public WithEvents Fname_lbl As System.Windows.Forms.Label
    Friend WithEvents Plan As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Address As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Notes As System.Windows.Forms.TextBox
    Friend WithEvents Delete_patient As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fname As System.Windows.Forms.TextBox
    Friend WithEvents lname As System.Windows.Forms.TextBox
    Friend WithEvents version As System.Windows.Forms.TextBox
    Friend WithEvents health_num As System.Windows.Forms.TextBox
    Friend WithEvents chart_id As System.Windows.Forms.TextBox
    Friend WithEvents email As System.Windows.Forms.TextBox
    Friend WithEvents cell_tel As System.Windows.Forms.TextBox
    Friend WithEvents home_Tel As System.Windows.Forms.TextBox
    Friend WithEvents Find As System.Windows.Forms.Button
    Friend WithEvents go_claims As System.Windows.Forms.Button
    Friend WithEvents dob_err As System.Windows.Forms.PictureBox
    Friend WithEvents plan_err As System.Windows.Forms.PictureBox
    Friend WithEvents prov_err As System.Windows.Forms.PictureBox
    Friend WithEvents gender_err As System.Windows.Forms.PictureBox
    Friend WithEvents fname_err As System.Windows.Forms.PictureBox
    Friend WithEvents lname_err As System.Windows.Forms.PictureBox
    Friend WithEvents Health_err As System.Windows.Forms.PictureBox
    Friend WithEvents pat_history As System.Windows.Forms.Button
End Class
