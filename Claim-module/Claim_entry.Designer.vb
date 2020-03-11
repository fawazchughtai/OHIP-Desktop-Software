<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Claim_Entry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Claim_Entry))
        Me.patient_grp = New System.Windows.Forms.GroupBox()
        Me.DOB = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.version = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.search_btn = New System.Windows.Forms.Button()
        Me.Chart_id = New System.Windows.Forms.TextBox()
        Me.Edit_patient = New System.Windows.Forms.Button()
        Me.Fname = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Lname = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Health_num = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Another_patient = New System.Windows.Forms.Button()
        Me.service_grp = New System.Windows.Forms.GroupBox()
        Me.ref_dr_list = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.sv_find = New System.Windows.Forms.Button()
        Me.Archive_cl = New System.Windows.Forms.Button()
        Me.ref_find = New System.Windows.Forms.Button()
        Me.dx_find = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lab_num = New System.Windows.Forms.TextBox()
        Me.adm_err = New System.Windows.Forms.PictureBox()
        Me.mr_chkbox = New System.Windows.Forms.CheckBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Adm_picker = New System.Windows.Forms.DateTimePicker()
        Me.fee_err = New System.Windows.Forms.PictureBox()
        Me.Tot_err = New System.Windows.Forms.PictureBox()
        Me.SLI_err = New System.Windows.Forms.PictureBox()
        Me.fac_err = New System.Windows.Forms.PictureBox()
        Me.ref_err = New System.Windows.Forms.PictureBox()
        Me.diag_err = New System.Windows.Forms.PictureBox()
        Me.num_srv_err = New System.Windows.Forms.PictureBox()
        Me.srv_code_err = New System.Windows.Forms.PictureBox()
        Me.Diagnosis = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SLI = New System.Windows.Forms.ComboBox()
        Me.Service_code = New System.Windows.Forms.ComboBox()
        Me.date_format2 = New System.Windows.Forms.Label()
        Me.Total_fee = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Delete_Service = New System.Windows.Forms.Button()
        Me.Update_service = New System.Windows.Forms.Button()
        Me.Add_service = New System.Windows.Forms.Button()
        Me.Unit_fee = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dxLBL = New System.Windows.Forms.Label()
        Me.ServiceCodeLBL = New System.Windows.Forms.Label()
        Me.ServiceLBL = New System.Windows.Forms.Label()
        Me.Num_services = New System.Windows.Forms.TextBox()
        Me.Facility_num = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Referring = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Services_grid = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Status = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Claim_id = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Total_paid = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Total_sub = New System.Windows.Forms.Label()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Confirm_date = New System.Windows.Forms.Button()
        Me.date_grp = New System.Windows.Forms.GroupBox()
        Me.plan_lbl = New System.Windows.Forms.Label()
        Me.ch_date = New System.Windows.Forms.Button()
        Me.ser_enter = New System.Windows.Forms.Button()
        Me.date_format = New System.Windows.Forms.Label()
        Me.Service_picker = New System.Windows.Forms.DateTimePicker()
        Me.helper_grp = New System.Windows.Forms.GroupBox()
        Me.assistant_f_img = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.help_txt = New System.Windows.Forms.TextBox()
        Me.assistant_m_img = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.unsubmit = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ch_date_ctr = New System.Windows.Forms.Button()
        Me.Plan = New System.Windows.Forms.ComboBox()
        Me.USBHD1_claim = New AxctlUSBHID.AxUSBHID()
        Me.patient_grp.SuspendLayout()
        Me.service_grp.SuspendLayout()
        CType(Me.adm_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fee_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tot_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLI_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fac_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ref_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.diag_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_srv_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.srv_code_err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Services_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.date_grp.SuspendLayout()
        Me.helper_grp.SuspendLayout()
        CType(Me.assistant_f_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.assistant_m_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USBHD1_claim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'patient_grp
        '
        Me.patient_grp.Controls.Add(Me.DOB)
        Me.patient_grp.Controls.Add(Me.Label11)
        Me.patient_grp.Controls.Add(Me.Button3)
        Me.patient_grp.Controls.Add(Me.version)
        Me.patient_grp.Controls.Add(Me.Label10)
        Me.patient_grp.Controls.Add(Me.search_btn)
        Me.patient_grp.Controls.Add(Me.Chart_id)
        Me.patient_grp.Controls.Add(Me.Edit_patient)
        Me.patient_grp.Controls.Add(Me.Fname)
        Me.patient_grp.Controls.Add(Me.Label14)
        Me.patient_grp.Controls.Add(Me.Lname)
        Me.patient_grp.Controls.Add(Me.Label13)
        Me.patient_grp.Controls.Add(Me.Health_num)
        Me.patient_grp.Controls.Add(Me.Label12)
        Me.patient_grp.Controls.Add(Me.Label7)
        Me.patient_grp.Location = New System.Drawing.Point(5, 28)
        Me.patient_grp.Name = "patient_grp"
        Me.patient_grp.Size = New System.Drawing.Size(600, 110)
        Me.patient_grp.TabIndex = 1
        Me.patient_grp.TabStop = False
        Me.patient_grp.Text = "Select Patient"
        '
        'DOB
        '
        Me.DOB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.DOB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.DOB.Location = New System.Drawing.Point(338, 74)
        Me.DOB.Name = "DOB"
        Me.DOB.ReadOnly = True
        Me.DOB.Size = New System.Drawing.Size(106, 20)
        Me.DOB.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(290, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "DOB"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(499, 79)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(91, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "View History"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'version
        '
        Me.version.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.version.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.version.Location = New System.Drawing.Point(338, 49)
        Me.version.Name = "version"
        Me.version.ReadOnly = True
        Me.version.Size = New System.Drawing.Size(52, 20)
        Me.version.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(290, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Version"
        '
        'search_btn
        '
        Me.search_btn.Location = New System.Drawing.Point(499, 17)
        Me.search_btn.Name = "search_btn"
        Me.search_btn.Size = New System.Drawing.Size(91, 23)
        Me.search_btn.TabIndex = 3
        Me.search_btn.Text = "Find Patient"
        Me.search_btn.UseVisualStyleBackColor = True
        '
        'Chart_id
        '
        Me.Chart_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Chart_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Chart_id.Location = New System.Drawing.Point(74, 25)
        Me.Chart_id.Name = "Chart_id"
        Me.Chart_id.Size = New System.Drawing.Size(98, 20)
        Me.Chart_id.TabIndex = 0
        '
        'Edit_patient
        '
        Me.Edit_patient.Enabled = False
        Me.Edit_patient.Location = New System.Drawing.Point(499, 49)
        Me.Edit_patient.Name = "Edit_patient"
        Me.Edit_patient.Size = New System.Drawing.Size(91, 23)
        Me.Edit_patient.TabIndex = 4
        Me.Edit_patient.Text = "Edit Patient"
        Me.Edit_patient.UseVisualStyleBackColor = True
        '
        'Fname
        '
        Me.Fname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Fname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Fname.Location = New System.Drawing.Point(73, 79)
        Me.Fname.Name = "Fname"
        Me.Fname.Size = New System.Drawing.Size(186, 20)
        Me.Fname.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "First name"
        '
        'Lname
        '
        Me.Lname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Lname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Lname.Location = New System.Drawing.Point(73, 51)
        Me.Lname.Name = "Lname"
        Me.Lname.Size = New System.Drawing.Size(186, 20)
        Me.Lname.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Last name"
        '
        'Health_num
        '
        Me.Health_num.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Health_num.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Health_num.Location = New System.Drawing.Point(293, 20)
        Me.Health_num.Name = "Health_num"
        Me.Health_num.Size = New System.Drawing.Size(187, 20)
        Me.Health_num.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(180, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Health Registration #"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Chart #"
        '
        'Another_patient
        '
        Me.Another_patient.Location = New System.Drawing.Point(5, 547)
        Me.Another_patient.Name = "Another_patient"
        Me.Another_patient.Size = New System.Drawing.Size(91, 23)
        Me.Another_patient.TabIndex = 5
        Me.Another_patient.Text = "Another Patient"
        Me.Another_patient.UseVisualStyleBackColor = True
        '
        'service_grp
        '
        Me.service_grp.Controls.Add(Me.ref_dr_list)
        Me.service_grp.Controls.Add(Me.Button4)
        Me.service_grp.Controls.Add(Me.sv_find)
        Me.service_grp.Controls.Add(Me.Archive_cl)
        Me.service_grp.Controls.Add(Me.ref_find)
        Me.service_grp.Controls.Add(Me.dx_find)
        Me.service_grp.Controls.Add(Me.Label6)
        Me.service_grp.Controls.Add(Me.lab_num)
        Me.service_grp.Controls.Add(Me.adm_err)
        Me.service_grp.Controls.Add(Me.mr_chkbox)
        Me.service_grp.Controls.Add(Me.Label36)
        Me.service_grp.Controls.Add(Me.Adm_picker)
        Me.service_grp.Controls.Add(Me.fee_err)
        Me.service_grp.Controls.Add(Me.Tot_err)
        Me.service_grp.Controls.Add(Me.SLI_err)
        Me.service_grp.Controls.Add(Me.fac_err)
        Me.service_grp.Controls.Add(Me.ref_err)
        Me.service_grp.Controls.Add(Me.diag_err)
        Me.service_grp.Controls.Add(Me.num_srv_err)
        Me.service_grp.Controls.Add(Me.srv_code_err)
        Me.service_grp.Controls.Add(Me.Diagnosis)
        Me.service_grp.Controls.Add(Me.Label3)
        Me.service_grp.Controls.Add(Me.SLI)
        Me.service_grp.Controls.Add(Me.Service_code)
        Me.service_grp.Controls.Add(Me.date_format2)
        Me.service_grp.Controls.Add(Me.Total_fee)
        Me.service_grp.Controls.Add(Me.Label5)
        Me.service_grp.Controls.Add(Me.Delete_Service)
        Me.service_grp.Controls.Add(Me.Update_service)
        Me.service_grp.Controls.Add(Me.Add_service)
        Me.service_grp.Controls.Add(Me.Unit_fee)
        Me.service_grp.Controls.Add(Me.Label9)
        Me.service_grp.Controls.Add(Me.dxLBL)
        Me.service_grp.Controls.Add(Me.ServiceCodeLBL)
        Me.service_grp.Controls.Add(Me.ServiceLBL)
        Me.service_grp.Controls.Add(Me.Num_services)
        Me.service_grp.Controls.Add(Me.Facility_num)
        Me.service_grp.Controls.Add(Me.Label37)
        Me.service_grp.Controls.Add(Me.Referring)
        Me.service_grp.Controls.Add(Me.Label38)
        Me.service_grp.Controls.Add(Me.Services_grid)
        Me.service_grp.Enabled = False
        Me.service_grp.Location = New System.Drawing.Point(5, 190)
        Me.service_grp.Name = "service_grp"
        Me.service_grp.Size = New System.Drawing.Size(600, 351)
        Me.service_grp.TabIndex = 3
        Me.service_grp.TabStop = False
        Me.service_grp.Text = "Enter Services"
        '
        'ref_dr_list
        '
        Me.ref_dr_list.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ref_dr_list.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ref_dr_list.FormattingEnabled = True
        Me.ref_dr_list.Location = New System.Drawing.Point(333, 51)
        Me.ref_dr_list.Name = "ref_dr_list"
        Me.ref_dr_list.Size = New System.Drawing.Size(129, 21)
        Me.ref_dr_list.TabIndex = 140
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 322)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 23)
        Me.Button4.TabIndex = 139
        Me.Button4.Text = "Re-submit"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'sv_find
        '
        Me.sv_find.Location = New System.Drawing.Point(110, 47)
        Me.sv_find.Name = "sv_find"
        Me.sv_find.Size = New System.Drawing.Size(37, 23)
        Me.sv_find.TabIndex = 138
        Me.sv_find.Text = "Find"
        Me.sv_find.UseVisualStyleBackColor = True
        '
        'Archive_cl
        '
        Me.Archive_cl.Location = New System.Drawing.Point(128, 322)
        Me.Archive_cl.Name = "Archive_cl"
        Me.Archive_cl.Size = New System.Drawing.Size(104, 23)
        Me.Archive_cl.TabIndex = 17
        Me.Archive_cl.Text = "Archive"
        Me.Archive_cl.UseVisualStyleBackColor = True
        Me.Archive_cl.Visible = False
        '
        'ref_find
        '
        Me.ref_find.Enabled = False
        Me.ref_find.Location = New System.Drawing.Point(508, 4)
        Me.ref_find.Name = "ref_find"
        Me.ref_find.Size = New System.Drawing.Size(37, 23)
        Me.ref_find.TabIndex = 137
        Me.ref_find.Text = "Find"
        Me.ref_find.UseVisualStyleBackColor = True
        Me.ref_find.Visible = False
        '
        'dx_find
        '
        Me.dx_find.Enabled = False
        Me.dx_find.Location = New System.Drawing.Point(286, 49)
        Me.dx_find.Name = "dx_find"
        Me.dx_find.Size = New System.Drawing.Size(37, 23)
        Me.dx_find.TabIndex = 136
        Me.dx_find.Text = "Find"
        Me.dx_find.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(467, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Lab #"
        '
        'lab_num
        '
        Me.lab_num.Location = New System.Drawing.Point(469, 109)
        Me.lab_num.MaxLength = 4
        Me.lab_num.Name = "lab_num"
        Me.lab_num.Size = New System.Drawing.Size(100, 20)
        Me.lab_num.TabIndex = 12
        '
        'adm_err
        '
        Me.adm_err.Image = CType(resources.GetObject("adm_err.Image"), System.Drawing.Image)
        Me.adm_err.InitialImage = CType(resources.GetObject("adm_err.InitialImage"), System.Drawing.Image)
        Me.adm_err.Location = New System.Drawing.Point(395, 76)
        Me.adm_err.Name = "adm_err"
        Me.adm_err.Size = New System.Drawing.Size(39, 32)
        Me.adm_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.adm_err.TabIndex = 128
        Me.adm_err.TabStop = False
        Me.adm_err.Visible = False
        '
        'mr_chkbox
        '
        Me.mr_chkbox.AutoSize = True
        Me.mr_chkbox.Location = New System.Drawing.Point(465, 71)
        Me.mr_chkbox.Name = "mr_chkbox"
        Me.mr_chkbox.Size = New System.Drawing.Size(100, 17)
        Me.mr_chkbox.TabIndex = 11
        Me.mr_chkbox.Text = "Manual Review"
        Me.mr_chkbox.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(315, 91)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(80, 13)
        Me.Label36.TabIndex = 36
        Me.Label36.Text = "Admission Date"
        '
        'Adm_picker
        '
        Me.Adm_picker.Checked = False
        Me.Adm_picker.Enabled = False
        Me.Adm_picker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Adm_picker.Location = New System.Drawing.Point(318, 109)
        Me.Adm_picker.Name = "Adm_picker"
        Me.Adm_picker.ShowCheckBox = True
        Me.Adm_picker.Size = New System.Drawing.Size(96, 20)
        Me.Adm_picker.TabIndex = 5
        '
        'fee_err
        '
        Me.fee_err.Image = CType(resources.GetObject("fee_err.Image"), System.Drawing.Image)
        Me.fee_err.InitialImage = CType(resources.GetObject("fee_err.InitialImage"), System.Drawing.Image)
        Me.fee_err.Location = New System.Drawing.Point(65, 68)
        Me.fee_err.Name = "fee_err"
        Me.fee_err.Size = New System.Drawing.Size(39, 32)
        Me.fee_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.fee_err.TabIndex = 132
        Me.fee_err.TabStop = False
        Me.fee_err.Visible = False
        '
        'Tot_err
        '
        Me.Tot_err.Image = CType(resources.GetObject("Tot_err.Image"), System.Drawing.Image)
        Me.Tot_err.InitialImage = CType(resources.GetObject("Tot_err.InitialImage"), System.Drawing.Image)
        Me.Tot_err.Location = New System.Drawing.Point(172, 76)
        Me.Tot_err.Name = "Tot_err"
        Me.Tot_err.Size = New System.Drawing.Size(39, 32)
        Me.Tot_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Tot_err.TabIndex = 131
        Me.Tot_err.TabStop = False
        Me.Tot_err.Visible = False
        '
        'SLI_err
        '
        Me.SLI_err.Enabled = False
        Me.SLI_err.Image = CType(resources.GetObject("SLI_err.Image"), System.Drawing.Image)
        Me.SLI_err.InitialImage = CType(resources.GetObject("SLI_err.InitialImage"), System.Drawing.Image)
        Me.SLI_err.Location = New System.Drawing.Point(551, 7)
        Me.SLI_err.Name = "SLI_err"
        Me.SLI_err.Size = New System.Drawing.Size(39, 32)
        Me.SLI_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.SLI_err.TabIndex = 130
        Me.SLI_err.TabStop = False
        Me.SLI_err.Visible = False
        '
        'fac_err
        '
        Me.fac_err.Image = CType(resources.GetObject("fac_err.Image"), System.Drawing.Image)
        Me.fac_err.InitialImage = CType(resources.GetObject("fac_err.InitialImage"), System.Drawing.Image)
        Me.fac_err.Location = New System.Drawing.Point(267, 71)
        Me.fac_err.Name = "fac_err"
        Me.fac_err.Size = New System.Drawing.Size(39, 32)
        Me.fac_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.fac_err.TabIndex = 129
        Me.fac_err.TabStop = False
        Me.fac_err.Visible = False
        '
        'ref_err
        '
        Me.ref_err.Image = CType(resources.GetObject("ref_err.Image"), System.Drawing.Image)
        Me.ref_err.InitialImage = CType(resources.GetObject("ref_err.InitialImage"), System.Drawing.Image)
        Me.ref_err.Location = New System.Drawing.Point(460, -3)
        Me.ref_err.Name = "ref_err"
        Me.ref_err.Size = New System.Drawing.Size(39, 32)
        Me.ref_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ref_err.TabIndex = 127
        Me.ref_err.TabStop = False
        Me.ref_err.Visible = False
        '
        'diag_err
        '
        Me.diag_err.Image = CType(resources.GetObject("diag_err.Image"), System.Drawing.Image)
        Me.diag_err.InitialImage = CType(resources.GetObject("diag_err.InitialImage"), System.Drawing.Image)
        Me.diag_err.Location = New System.Drawing.Point(267, 0)
        Me.diag_err.Name = "diag_err"
        Me.diag_err.Size = New System.Drawing.Size(39, 32)
        Me.diag_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.diag_err.TabIndex = 126
        Me.diag_err.TabStop = False
        Me.diag_err.Visible = False
        '
        'num_srv_err
        '
        Me.num_srv_err.Image = CType(resources.GetObject("num_srv_err.Image"), System.Drawing.Image)
        Me.num_srv_err.InitialImage = CType(resources.GetObject("num_srv_err.InitialImage"), System.Drawing.Image)
        Me.num_srv_err.Location = New System.Drawing.Point(172, 0)
        Me.num_srv_err.Name = "num_srv_err"
        Me.num_srv_err.Size = New System.Drawing.Size(39, 32)
        Me.num_srv_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.num_srv_err.TabIndex = 125
        Me.num_srv_err.TabStop = False
        Me.num_srv_err.Visible = False
        '
        'srv_code_err
        '
        Me.srv_code_err.Image = CType(resources.GetObject("srv_code_err.Image"), System.Drawing.Image)
        Me.srv_code_err.InitialImage = CType(resources.GetObject("srv_code_err.InitialImage"), System.Drawing.Image)
        Me.srv_code_err.Location = New System.Drawing.Point(87, 0)
        Me.srv_code_err.Name = "srv_code_err"
        Me.srv_code_err.Size = New System.Drawing.Size(39, 32)
        Me.srv_code_err.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.srv_code_err.TabIndex = 124
        Me.srv_code_err.TabStop = False
        Me.srv_code_err.Visible = False
        '
        'Diagnosis
        '
        Me.Diagnosis.Location = New System.Drawing.Point(229, 50)
        Me.Diagnosis.MaxLength = 4
        Me.Diagnosis.Name = "Diagnosis"
        Me.Diagnosis.ReadOnly = True
        Me.Diagnosis.Size = New System.Drawing.Size(51, 20)
        Me.Diagnosis.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(465, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Service Location Indicator"
        '
        'SLI
        '
        Me.SLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SLI.Enabled = False
        Me.SLI.FormattingEnabled = True
        Me.SLI.Items.AddRange(New Object() {"", "HDS", "HED ", "HIP", "HOP", "HRP", "IHF", "OFF", "OTN"})
        Me.SLI.Location = New System.Drawing.Point(468, 50)
        Me.SLI.Name = "SLI"
        Me.SLI.Size = New System.Drawing.Size(95, 21)
        Me.SLI.TabIndex = 10
        '
        'Service_code
        '
        Me.Service_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Service_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Service_code.FormattingEnabled = True
        Me.Service_code.Location = New System.Drawing.Point(21, 49)
        Me.Service_code.Name = "Service_code"
        Me.Service_code.Size = New System.Drawing.Size(83, 21)
        Me.Service_code.TabIndex = 0
        '
        'date_format2
        '
        Me.date_format2.AutoSize = True
        Me.date_format2.Location = New System.Drawing.Point(315, 78)
        Me.date_format2.Name = "date_format2"
        Me.date_format2.Size = New System.Drawing.Size(16, 13)
        Me.date_format2.TabIndex = 58
        Me.date_format2.Text = "..."
        '
        'Total_fee
        '
        Me.Total_fee.Location = New System.Drawing.Point(113, 109)
        Me.Total_fee.Name = "Total_fee"
        Me.Total_fee.ReadOnly = True
        Me.Total_fee.Size = New System.Drawing.Size(83, 20)
        Me.Total_fee.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(110, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(101, 18)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Total Fee"
        '
        'Delete_Service
        '
        Me.Delete_Service.Location = New System.Drawing.Point(510, 322)
        Me.Delete_Service.Name = "Delete_Service"
        Me.Delete_Service.Size = New System.Drawing.Size(75, 23)
        Me.Delete_Service.TabIndex = 8
        Me.Delete_Service.Text = "Delete"
        Me.Delete_Service.UseVisualStyleBackColor = True
        '
        'Update_service
        '
        Me.Update_service.Location = New System.Drawing.Point(429, 322)
        Me.Update_service.Name = "Update_service"
        Me.Update_service.Size = New System.Drawing.Size(75, 23)
        Me.Update_service.TabIndex = 7
        Me.Update_service.Text = "Update"
        Me.Update_service.UseVisualStyleBackColor = True
        '
        'Add_service
        '
        Me.Add_service.Location = New System.Drawing.Point(348, 322)
        Me.Add_service.Name = "Add_service"
        Me.Add_service.Size = New System.Drawing.Size(75, 23)
        Me.Add_service.TabIndex = 6
        Me.Add_service.Text = "Add"
        Me.Add_service.UseVisualStyleBackColor = True
        '
        'Unit_fee
        '
        Me.Unit_fee.Location = New System.Drawing.Point(19, 109)
        Me.Unit_fee.MaxLength = 7
        Me.Unit_fee.Name = "Unit_fee"
        Me.Unit_fee.ReadOnly = True
        Me.Unit_fee.Size = New System.Drawing.Size(83, 20)
        Me.Unit_fee.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(101, 18)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Unit Service Fee"
        '
        'dxLBL
        '
        Me.dxLBL.BackColor = System.Drawing.SystemColors.Control
        Me.dxLBL.Cursor = System.Windows.Forms.Cursors.Default
        Me.dxLBL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dxLBL.Location = New System.Drawing.Point(226, 29)
        Me.dxLBL.Name = "dxLBL"
        Me.dxLBL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dxLBL.Size = New System.Drawing.Size(67, 18)
        Me.dxLBL.TabIndex = 49
        Me.dxLBL.Text = "Diagnosis"
        '
        'ServiceCodeLBL
        '
        Me.ServiceCodeLBL.BackColor = System.Drawing.SystemColors.Control
        Me.ServiceCodeLBL.Cursor = System.Windows.Forms.Cursors.Default
        Me.ServiceCodeLBL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ServiceCodeLBL.Location = New System.Drawing.Point(18, 29)
        Me.ServiceCodeLBL.Name = "ServiceCodeLBL"
        Me.ServiceCodeLBL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ServiceCodeLBL.Size = New System.Drawing.Size(74, 18)
        Me.ServiceCodeLBL.TabIndex = 48
        Me.ServiceCodeLBL.Text = "Service Code"
        '
        'ServiceLBL
        '
        Me.ServiceLBL.BackColor = System.Drawing.SystemColors.Control
        Me.ServiceLBL.Cursor = System.Windows.Forms.Cursors.Default
        Me.ServiceLBL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ServiceLBL.Location = New System.Drawing.Point(158, 29)
        Me.ServiceLBL.Name = "ServiceLBL"
        Me.ServiceLBL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ServiceLBL.Size = New System.Drawing.Size(62, 18)
        Me.ServiceLBL.TabIndex = 50
        Me.ServiceLBL.Text = "# Services"
        '
        'Num_services
        '
        Me.Num_services.AcceptsReturn = True
        Me.Num_services.BackColor = System.Drawing.SystemColors.Window
        Me.Num_services.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Num_services.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Num_services.Location = New System.Drawing.Point(173, 49)
        Me.Num_services.MaxLength = 2
        Me.Num_services.Name = "Num_services"
        Me.Num_services.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Num_services.Size = New System.Drawing.Size(38, 20)
        Me.Num_services.TabIndex = 1
        '
        'Facility_num
        '
        Me.Facility_num.Location = New System.Drawing.Point(215, 109)
        Me.Facility_num.MaxLength = 4
        Me.Facility_num.Name = "Facility_num"
        Me.Facility_num.ReadOnly = True
        Me.Facility_num.Size = New System.Drawing.Size(83, 20)
        Me.Facility_num.TabIndex = 4
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(217, 91)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(49, 13)
        Me.Label37.TabIndex = 34
        Me.Label37.Text = "Facility #"
        '
        'Referring
        '
        Me.Referring.Location = New System.Drawing.Point(333, 29)
        Me.Referring.MaxLength = 6
        Me.Referring.Name = "Referring"
        Me.Referring.ReadOnly = True
        Me.Referring.Size = New System.Drawing.Size(126, 20)
        Me.Referring.TabIndex = 3
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(330, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(98, 13)
        Me.Label38.TabIndex = 32
        Me.Label38.Text = "Referring Physician"
        '
        'Services_grid
        '
        Me.Services_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Services_grid.Location = New System.Drawing.Point(6, 145)
        Me.Services_grid.Name = "Services_grid"
        Me.Services_grid.Size = New System.Drawing.Size(588, 171)
        Me.Services_grid.TabIndex = 20
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Location = New System.Drawing.Point(696, 447)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(93, 59)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Claim Information"
        Me.GroupBox4.Visible = False
        '
        'Status
        '
        Me.Status.Location = New System.Drawing.Point(504, 7)
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Size = New System.Drawing.Size(100, 20)
        Me.Status.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(467, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Status"
        '
        'Claim_id
        '
        Me.Claim_id.Location = New System.Drawing.Point(60, 4)
        Me.Claim_id.Name = "Claim_id"
        Me.Claim_id.ReadOnly = True
        Me.Claim_id.Size = New System.Drawing.Size(100, 20)
        Me.Claim_id.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Claim #"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Total_paid)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Total_sub)
        Me.GroupBox5.Location = New System.Drawing.Point(337, 547)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(257, 54)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(139, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Total Amount Paid"
        '
        'Total_paid
        '
        Me.Total_paid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Total_paid.AutoSize = True
        Me.Total_paid.Location = New System.Drawing.Point(139, 27)
        Me.Total_paid.Name = "Total_paid"
        Me.Total_paid.Size = New System.Drawing.Size(0, 13)
        Me.Total_paid.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Total Amount Submitted"
        '
        'Total_sub
        '
        Me.Total_sub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Total_sub.AutoSize = True
        Me.Total_sub.Location = New System.Drawing.Point(15, 27)
        Me.Total_sub.Name = "Total_sub"
        Me.Total_sub.Size = New System.Drawing.Size(0, 13)
        Me.Total_sub.TabIndex = 11
        '
        'Close_btn
        '
        Me.Close_btn.Location = New System.Drawing.Point(5, 578)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(91, 23)
        Me.Close_btn.TabIndex = 6
        Me.Close_btn.Text = "Close"
        Me.Close_btn.UseVisualStyleBackColor = True
        Me.Close_btn.Visible = False
        '
        'Confirm_date
        '
        Me.Confirm_date.Location = New System.Drawing.Point(102, 547)
        Me.Confirm_date.Name = "Confirm_date"
        Me.Confirm_date.Size = New System.Drawing.Size(120, 23)
        Me.Confirm_date.TabIndex = 1
        Me.Confirm_date.Text = "Another Date"
        Me.Confirm_date.UseVisualStyleBackColor = True
        '
        'date_grp
        '
        Me.date_grp.Controls.Add(Me.plan_lbl)
        Me.date_grp.Controls.Add(Me.ch_date)
        Me.date_grp.Controls.Add(Me.ser_enter)
        Me.date_grp.Controls.Add(Me.date_format)
        Me.date_grp.Controls.Add(Me.Service_picker)
        Me.date_grp.Enabled = False
        Me.date_grp.Location = New System.Drawing.Point(5, 144)
        Me.date_grp.Name = "date_grp"
        Me.date_grp.Size = New System.Drawing.Size(600, 40)
        Me.date_grp.TabIndex = 2
        Me.date_grp.TabStop = False
        Me.date_grp.Text = "Select Service Date"
        '
        'plan_lbl
        '
        Me.plan_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.plan_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.plan_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.plan_lbl.Location = New System.Drawing.Point(176, 19)
        Me.plan_lbl.Name = "plan_lbl"
        Me.plan_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.plan_lbl.Size = New System.Drawing.Size(44, 18)
        Me.plan_lbl.TabIndex = 130
        Me.plan_lbl.Text = "Plan"
        Me.plan_lbl.Visible = False
        '
        'ch_date
        '
        Me.ch_date.Location = New System.Drawing.Point(362, 14)
        Me.ch_date.Name = "ch_date"
        Me.ch_date.Size = New System.Drawing.Size(105, 23)
        Me.ch_date.TabIndex = 12
        Me.ch_date.Text = "Correct Date"
        Me.ch_date.UseVisualStyleBackColor = True
        Me.ch_date.Visible = False
        '
        'ser_enter
        '
        Me.ser_enter.Location = New System.Drawing.Point(473, 14)
        Me.ser_enter.Name = "ser_enter"
        Me.ser_enter.Size = New System.Drawing.Size(121, 23)
        Me.ser_enter.TabIndex = 11
        Me.ser_enter.Text = "Enter Service"
        Me.ser_enter.UseVisualStyleBackColor = True
        '
        'date_format
        '
        Me.date_format.AutoSize = True
        Me.date_format.Location = New System.Drawing.Point(101, 19)
        Me.date_format.Name = "date_format"
        Me.date_format.Size = New System.Drawing.Size(16, 13)
        Me.date_format.TabIndex = 10
        Me.date_format.Text = "..."
        '
        'Service_picker
        '
        Me.Service_picker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Service_picker.Location = New System.Drawing.Point(7, 19)
        Me.Service_picker.Name = "Service_picker"
        Me.Service_picker.Size = New System.Drawing.Size(88, 20)
        Me.Service_picker.TabIndex = 0
        '
        'helper_grp
        '
        Me.helper_grp.BackColor = System.Drawing.Color.White
        Me.helper_grp.Controls.Add(Me.assistant_f_img)
        Me.helper_grp.Controls.Add(Me.PictureBox1)
        Me.helper_grp.Controls.Add(Me.help_txt)
        Me.helper_grp.Controls.Add(Me.assistant_m_img)
        Me.helper_grp.Location = New System.Drawing.Point(620, 72)
        Me.helper_grp.Name = "helper_grp"
        Me.helper_grp.Size = New System.Drawing.Size(340, 335)
        Me.helper_grp.TabIndex = 13
        Me.helper_grp.TabStop = False
        Me.helper_grp.Text = "OHIP-BILLING Assistant"
        Me.helper_grp.Visible = False
        '
        'assistant_f_img
        '
        Me.assistant_f_img.Image = CType(resources.GetObject("assistant_f_img.Image"), System.Drawing.Image)
        Me.assistant_f_img.Location = New System.Drawing.Point(203, 36)
        Me.assistant_f_img.Name = "assistant_f_img"
        Me.assistant_f_img.Size = New System.Drawing.Size(122, 291)
        Me.assistant_f_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.assistant_f_img.TabIndex = 3
        Me.assistant_f_img.TabStop = False
        Me.assistant_f_img.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'help_txt
        '
        Me.help_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.help_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help_txt.Location = New System.Drawing.Point(76, 36)
        Me.help_txt.Multiline = True
        Me.help_txt.Name = "help_txt"
        Me.help_txt.Size = New System.Drawing.Size(119, 291)
        Me.help_txt.TabIndex = 1
        '
        'assistant_m_img
        '
        Me.assistant_m_img.Image = CType(resources.GetObject("assistant_m_img.Image"), System.Drawing.Image)
        Me.assistant_m_img.Location = New System.Drawing.Point(201, 36)
        Me.assistant_m_img.Name = "assistant_m_img"
        Me.assistant_m_img.Size = New System.Drawing.Size(122, 284)
        Me.assistant_m_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.assistant_m_img.TabIndex = 0
        Me.assistant_m_img.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(806, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Hide assistant"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(696, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Change assistant"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'unsubmit
        '
        Me.unsubmit.Location = New System.Drawing.Point(229, 578)
        Me.unsubmit.Name = "unsubmit"
        Me.unsubmit.Size = New System.Drawing.Size(104, 23)
        Me.unsubmit.TabIndex = 16
        Me.unsubmit.Text = "Unlock claim"
        Me.unsubmit.UseVisualStyleBackColor = True
        Me.unsubmit.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(235, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(50, 23)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Next"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(175, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(50, 23)
        Me.Button6.TabIndex = 18
        Me.Button6.Text = "Prev"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ch_date_ctr
        '
        Me.ch_date_ctr.Location = New System.Drawing.Point(225, 547)
        Me.ch_date_ctr.Name = "ch_date_ctr"
        Me.ch_date_ctr.Size = New System.Drawing.Size(105, 23)
        Me.ch_date_ctr.TabIndex = 13
        Me.ch_date_ctr.Text = "Correct Date"
        Me.ch_date_ctr.UseVisualStyleBackColor = True
        '
        'Plan
        '
        Me.Plan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Plan.FormattingEnabled = True
        Me.Plan.Items.AddRange(New Object() {"HCP", "WCB", "RMB"})
        Me.Plan.Location = New System.Drawing.Point(225, 161)
        Me.Plan.Name = "Plan"
        Me.Plan.Size = New System.Drawing.Size(121, 21)
        Me.Plan.TabIndex = 129
        Me.Plan.Visible = False
        '
        'USBHD1_claim
        '
        Me.USBHD1_claim.Enabled = True
        Me.USBHD1_claim.Location = New System.Drawing.Point(823, 458)
        Me.USBHD1_claim.Name = "USBHD1_claim"
        Me.USBHD1_claim.OcxState = CType(resources.GetObject("USBHD1_claim.OcxState"), System.Windows.Forms.AxHost.State)
        Me.USBHD1_claim.Size = New System.Drawing.Size(56, 54)
        Me.USBHD1_claim.TabIndex = 130
        '
        'Claim_Entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 613)
        Me.Controls.Add(Me.USBHD1_claim)
        Me.Controls.Add(Me.Plan)
        Me.Controls.Add(Me.ch_date_ctr)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.patient_grp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.unsubmit)
        Me.Controls.Add(Me.Claim_id)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.helper_grp)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Confirm_date)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Another_patient)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.service_grp)
        Me.Controls.Add(Me.date_grp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(277, 0)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Claim_Entry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Claims Entry/Review"
        Me.patient_grp.ResumeLayout(False)
        Me.patient_grp.PerformLayout()
        Me.service_grp.ResumeLayout(False)
        Me.service_grp.PerformLayout()
        CType(Me.adm_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fee_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tot_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLI_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fac_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ref_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.diag_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_srv_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.srv_code_err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Services_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.date_grp.ResumeLayout(False)
        Me.date_grp.PerformLayout()
        Me.helper_grp.ResumeLayout(False)
        Me.helper_grp.PerformLayout()
        CType(Me.assistant_f_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.assistant_m_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USBHD1_claim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents patient_grp As System.Windows.Forms.GroupBox
    Friend WithEvents Fname As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Lname As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Health_num As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents service_grp As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Claim_id As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Services_grid As System.Windows.Forms.DataGridView
    Friend WithEvents Another_patient As System.Windows.Forms.Button
    Friend WithEvents Delete_Service As System.Windows.Forms.Button
    Friend WithEvents Update_service As System.Windows.Forms.Button
    Friend WithEvents Add_service As System.Windows.Forms.Button
    Friend WithEvents Unit_fee As System.Windows.Forms.TextBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents dxLBL As System.Windows.Forms.Label
    Public WithEvents ServiceCodeLBL As System.Windows.Forms.Label
    Public WithEvents ServiceLBL As System.Windows.Forms.Label
    Public WithEvents Num_services As System.Windows.Forms.TextBox
    Friend WithEvents Status As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Total_paid As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Total_sub As System.Windows.Forms.Label
    Friend WithEvents Total_fee As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Adm_picker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Facility_num As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Referring As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Edit_patient As System.Windows.Forms.Button
    Friend WithEvents Chart_id As System.Windows.Forms.TextBox
    Friend WithEvents search_btn As System.Windows.Forms.Button
    Friend WithEvents date_format2 As System.Windows.Forms.Label
    Friend WithEvents Service_code As System.Windows.Forms.ComboBox
    Friend WithEvents Confirm_date As System.Windows.Forms.Button
    Friend WithEvents date_grp As System.Windows.Forms.GroupBox
    Friend WithEvents date_format As System.Windows.Forms.Label
    Friend WithEvents Service_picker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SLI As System.Windows.Forms.ComboBox
    Friend WithEvents Diagnosis As System.Windows.Forms.TextBox
    Friend WithEvents fee_err As System.Windows.Forms.PictureBox
    Friend WithEvents Tot_err As System.Windows.Forms.PictureBox
    Friend WithEvents SLI_err As System.Windows.Forms.PictureBox
    Friend WithEvents fac_err As System.Windows.Forms.PictureBox
    Friend WithEvents adm_err As System.Windows.Forms.PictureBox
    Friend WithEvents ref_err As System.Windows.Forms.PictureBox
    Friend WithEvents diag_err As System.Windows.Forms.PictureBox
    Friend WithEvents num_srv_err As System.Windows.Forms.PictureBox
    Friend WithEvents srv_code_err As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lab_num As System.Windows.Forms.TextBox
    Friend WithEvents mr_chkbox As System.Windows.Forms.CheckBox
    Friend WithEvents helper_grp As System.Windows.Forms.GroupBox
    Friend WithEvents help_txt As System.Windows.Forms.TextBox
    Friend WithEvents assistant_m_img As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents assistant_f_img As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents unsubmit As System.Windows.Forms.Button
    Friend WithEvents ser_enter As System.Windows.Forms.Button
    Friend WithEvents ref_find As System.Windows.Forms.Button
    Friend WithEvents dx_find As System.Windows.Forms.Button
    Friend WithEvents sv_find As System.Windows.Forms.Button
    Friend WithEvents version As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Archive_cl As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ch_date As System.Windows.Forms.Button
    Friend WithEvents ch_date_ctr As System.Windows.Forms.Button
    Friend WithEvents DOB As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ref_dr_list As System.Windows.Forms.ComboBox
    Public WithEvents plan_lbl As System.Windows.Forms.Label
    Friend WithEvents Plan As System.Windows.Forms.ComboBox
    Friend WithEvents USBHD1_claim As AxctlUSBHID.AxUSBHID
End Class
