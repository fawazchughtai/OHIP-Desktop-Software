<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionHistory
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Open_search_radio = New System.Windows.Forms.RadioButton()
        Me.show_all_open = New System.Windows.Forms.Button()
        Me.Date_frm_open = New System.Windows.Forms.DateTimePicker()
        Me.pr_unsub = New System.Windows.Forms.Button()
        Me.refresh_open = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Date_to_open = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tot_claims = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TOTAL1 = New System.Windows.Forms.Label()
        Me.unsubmit_history = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Select_claims_btn = New System.Windows.Forms.Button()
        Me.resubmit_btn = New System.Windows.Forms.Button()
        Me.Archive_btn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radio_search_date = New System.Windows.Forms.RadioButton()
        Me.Radio_search_sub = New System.Windows.Forms.RadioButton()
        Me.Show_all_Sub = New System.Windows.Forms.Button()
        Me.Date_frm_sub = New System.Windows.Forms.DateTimePicker()
        Me.Refresh_sub = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Date_to_sub = New System.Windows.Forms.DateTimePicker()
        Me.pr_sub = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.archived_cl = New System.Windows.Forms.RadioButton()
        Me.Open_cl = New System.Windows.Forms.RadioButton()
        Me.All_radio = New System.Windows.Forms.RadioButton()
        Me.Paid_Radio = New System.Windows.Forms.RadioButton()
        Me.Error_radio = New System.Windows.Forms.RadioButton()
        Me.Unpaid_radio = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Totals_txt = New System.Windows.Forms.Label()
        Me.Totalp_txt = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tot_claims2 = New System.Windows.Forms.Label()
        Me.filename_lbl = New System.Windows.Forms.Label()
        Me.Filename_txt = New System.Windows.Forms.TextBox()
        Me.ServiceHistoryDataGrid = New System.Windows.Forms.DataGridView()
        Me.patient_id = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.total_units_lbl = New System.Windows.Forms.Label()
        Me.Total_units_v = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Total_units_v2 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.unsubmit_history, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ServiceHistoryDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(16, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(997, 541)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightGray
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.unsubmit_history)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(989, 515)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Open Claims"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Open_search_radio)
        Me.GroupBox4.Controls.Add(Me.show_all_open)
        Me.GroupBox4.Controls.Add(Me.Date_frm_open)
        Me.GroupBox4.Controls.Add(Me.pr_unsub)
        Me.GroupBox4.Controls.Add(Me.refresh_open)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Date_to_open)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 382)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(315, 126)
        Me.GroupBox4.TabIndex = 42
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Search Criteria"
        '
        'Open_search_radio
        '
        Me.Open_search_radio.AutoSize = True
        Me.Open_search_radio.Checked = True
        Me.Open_search_radio.Location = New System.Drawing.Point(6, 19)
        Me.Open_search_radio.Name = "Open_search_radio"
        Me.Open_search_radio.Size = New System.Drawing.Size(102, 17)
        Me.Open_search_radio.TabIndex = 39
        Me.Open_search_radio.TabStop = True
        Me.Open_search_radio.Text = "By Service Date"
        Me.Open_search_radio.UseVisualStyleBackColor = True
        '
        'show_all_open
        '
        Me.show_all_open.Location = New System.Drawing.Point(151, 96)
        Me.show_all_open.Name = "show_all_open"
        Me.show_all_open.Size = New System.Drawing.Size(75, 23)
        Me.show_all_open.TabIndex = 37
        Me.show_all_open.Text = "Show ALL"
        Me.show_all_open.UseVisualStyleBackColor = True
        '
        'Date_frm_open
        '
        Me.Date_frm_open.Location = New System.Drawing.Point(42, 42)
        Me.Date_frm_open.Name = "Date_frm_open"
        Me.Date_frm_open.Size = New System.Drawing.Size(200, 20)
        Me.Date_frm_open.TabIndex = 35
        Me.Date_frm_open.Value = New Date(2013, 1, 21, 0, 0, 0, 0)
        '
        'pr_unsub
        '
        Me.pr_unsub.Location = New System.Drawing.Point(232, 96)
        Me.pr_unsub.Name = "pr_unsub"
        Me.pr_unsub.Size = New System.Drawing.Size(75, 23)
        Me.pr_unsub.TabIndex = 7
        Me.pr_unsub.Text = "Print"
        Me.pr_unsub.UseVisualStyleBackColor = True
        '
        'refresh_open
        '
        Me.refresh_open.Location = New System.Drawing.Point(70, 96)
        Me.refresh_open.Name = "refresh_open"
        Me.refresh_open.Size = New System.Drawing.Size(75, 24)
        Me.refresh_open.TabIndex = 32
        Me.refresh_open.Text = "Refresh"
        Me.refresh_open.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "To:"
        '
        'Date_to_open
        '
        Me.Date_to_open.Location = New System.Drawing.Point(42, 66)
        Me.Date_to_open.Name = "Date_to_open"
        Me.Date_to_open.Size = New System.Drawing.Size(200, 20)
        Me.Date_to_open.TabIndex = 36
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "From:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Tot_claims)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.TOTAL1)
        Me.Panel2.Location = New System.Drawing.Point(591, 382)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(392, 119)
        Me.Panel2.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "TOTAL COUNT"
        '
        'Tot_claims
        '
        Me.Tot_claims.AutoSize = True
        Me.Tot_claims.Location = New System.Drawing.Point(16, 39)
        Me.Tot_claims.Name = "Tot_claims"
        Me.Tot_claims.Size = New System.Drawing.Size(13, 13)
        Me.Tot_claims.TabIndex = 5
        Me.Tot_claims.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(216, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "TOTAL AMOUNT"
        '
        'TOTAL1
        '
        Me.TOTAL1.AutoSize = True
        Me.TOTAL1.Location = New System.Drawing.Point(226, 42)
        Me.TOTAL1.Name = "TOTAL1"
        Me.TOTAL1.Size = New System.Drawing.Size(13, 13)
        Me.TOTAL1.TabIndex = 2
        Me.TOTAL1.Text = "$"
        '
        'unsubmit_history
        '
        Me.unsubmit_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.unsubmit_history.Location = New System.Drawing.Point(6, 6)
        Me.unsubmit_history.Name = "unsubmit_history"
        Me.unsubmit_history.Size = New System.Drawing.Size(976, 370)
        Me.unsubmit_history.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LightGray
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.filename_lbl)
        Me.TabPage1.Controls.Add(Me.Filename_txt)
        Me.TabPage1.Controls.Add(Me.ServiceHistoryDataGrid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(989, 515)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Submitted Claims"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Select_claims_btn)
        Me.GroupBox3.Controls.Add(Me.resubmit_btn)
        Me.GroupBox3.Controls.Add(Me.Archive_btn)
        Me.GroupBox3.Location = New System.Drawing.Point(327, 383)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox3.TabIndex = 42
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Claims control"
        '
        'Select_claims_btn
        '
        Me.Select_claims_btn.Location = New System.Drawing.Point(6, 19)
        Me.Select_claims_btn.Name = "Select_claims_btn"
        Me.Select_claims_btn.Size = New System.Drawing.Size(75, 23)
        Me.Select_claims_btn.TabIndex = 25
        Me.Select_claims_btn.Text = "Select All"
        Me.Select_claims_btn.UseVisualStyleBackColor = True
        '
        'resubmit_btn
        '
        Me.resubmit_btn.Location = New System.Drawing.Point(119, 19)
        Me.resubmit_btn.Name = "resubmit_btn"
        Me.resubmit_btn.Size = New System.Drawing.Size(75, 23)
        Me.resubmit_btn.TabIndex = 24
        Me.resubmit_btn.Text = "Re-Submit"
        Me.resubmit_btn.UseVisualStyleBackColor = True
        '
        'Archive_btn
        '
        Me.Archive_btn.Location = New System.Drawing.Point(119, 48)
        Me.Archive_btn.Name = "Archive_btn"
        Me.Archive_btn.Size = New System.Drawing.Size(75, 23)
        Me.Archive_btn.TabIndex = 26
        Me.Archive_btn.Text = "Archive"
        Me.Archive_btn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radio_search_date)
        Me.GroupBox2.Controls.Add(Me.Radio_search_sub)
        Me.GroupBox2.Controls.Add(Me.Show_all_Sub)
        Me.GroupBox2.Controls.Add(Me.Date_frm_sub)
        Me.GroupBox2.Controls.Add(Me.Refresh_sub)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Date_to_sub)
        Me.GroupBox2.Controls.Add(Me.pr_sub)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 383)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(315, 126)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Criteria"
        '
        'radio_search_date
        '
        Me.radio_search_date.AutoSize = True
        Me.radio_search_date.Location = New System.Drawing.Point(6, 19)
        Me.radio_search_date.Name = "radio_search_date"
        Me.radio_search_date.Size = New System.Drawing.Size(102, 17)
        Me.radio_search_date.TabIndex = 39
        Me.radio_search_date.Text = "By Service Date"
        Me.radio_search_date.UseVisualStyleBackColor = True
        '
        'Radio_search_sub
        '
        Me.Radio_search_sub.AutoSize = True
        Me.Radio_search_sub.Location = New System.Drawing.Point(120, 18)
        Me.Radio_search_sub.Name = "Radio_search_sub"
        Me.Radio_search_sub.Size = New System.Drawing.Size(119, 17)
        Me.Radio_search_sub.TabIndex = 40
        Me.Radio_search_sub.Text = "By Submission Date"
        Me.Radio_search_sub.UseVisualStyleBackColor = True
        Me.Radio_search_sub.Visible = False
        '
        'Show_all_Sub
        '
        Me.Show_all_Sub.Location = New System.Drawing.Point(151, 96)
        Me.Show_all_Sub.Name = "Show_all_Sub"
        Me.Show_all_Sub.Size = New System.Drawing.Size(75, 23)
        Me.Show_all_Sub.TabIndex = 37
        Me.Show_all_Sub.Text = "Show ALL"
        Me.Show_all_Sub.UseVisualStyleBackColor = True
        '
        'Date_frm_sub
        '
        Me.Date_frm_sub.Location = New System.Drawing.Point(42, 42)
        Me.Date_frm_sub.Name = "Date_frm_sub"
        Me.Date_frm_sub.Size = New System.Drawing.Size(200, 20)
        Me.Date_frm_sub.TabIndex = 35
        Me.Date_frm_sub.Value = New Date(2013, 1, 21, 0, 0, 0, 0)
        '
        'Refresh_sub
        '
        Me.Refresh_sub.Location = New System.Drawing.Point(70, 96)
        Me.Refresh_sub.Name = "Refresh_sub"
        Me.Refresh_sub.Size = New System.Drawing.Size(75, 24)
        Me.Refresh_sub.TabIndex = 32
        Me.Refresh_sub.Text = "Refresh"
        Me.Refresh_sub.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "To:"
        '
        'Date_to_sub
        '
        Me.Date_to_sub.Location = New System.Drawing.Point(42, 66)
        Me.Date_to_sub.Name = "Date_to_sub"
        Me.Date_to_sub.Size = New System.Drawing.Size(200, 20)
        Me.Date_to_sub.TabIndex = 36
        '
        'pr_sub
        '
        Me.pr_sub.Location = New System.Drawing.Point(232, 96)
        Me.pr_sub.Name = "pr_sub"
        Me.pr_sub.Size = New System.Drawing.Size(75, 23)
        Me.pr_sub.TabIndex = 7
        Me.pr_sub.Text = "Print"
        Me.pr_sub.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "From:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.archived_cl)
        Me.GroupBox1.Controls.Add(Me.Open_cl)
        Me.GroupBox1.Controls.Add(Me.All_radio)
        Me.GroupBox1.Controls.Add(Me.Paid_Radio)
        Me.GroupBox1.Controls.Add(Me.Error_radio)
        Me.GroupBox1.Controls.Add(Me.Unpaid_radio)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 31)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Claims"
        '
        'archived_cl
        '
        Me.archived_cl.AutoSize = True
        Me.archived_cl.Location = New System.Drawing.Point(440, 11)
        Me.archived_cl.Name = "archived_cl"
        Me.archived_cl.Size = New System.Drawing.Size(67, 17)
        Me.archived_cl.TabIndex = 44
        Me.archived_cl.Text = "Archived"
        Me.archived_cl.UseVisualStyleBackColor = True
        '
        'Open_cl
        '
        Me.Open_cl.AutoSize = True
        Me.Open_cl.Location = New System.Drawing.Point(369, 11)
        Me.Open_cl.Name = "Open_cl"
        Me.Open_cl.Size = New System.Drawing.Size(51, 17)
        Me.Open_cl.TabIndex = 43
        Me.Open_cl.Text = "Open"
        Me.Open_cl.UseVisualStyleBackColor = True
        '
        'All_radio
        '
        Me.All_radio.AutoSize = True
        Me.All_radio.Location = New System.Drawing.Point(50, 11)
        Me.All_radio.Name = "All_radio"
        Me.All_radio.Size = New System.Drawing.Size(36, 17)
        Me.All_radio.TabIndex = 1
        Me.All_radio.Text = "All"
        Me.All_radio.UseVisualStyleBackColor = True
        '
        'Paid_Radio
        '
        Me.Paid_Radio.AutoSize = True
        Me.Paid_Radio.Location = New System.Drawing.Point(291, 11)
        Me.Paid_Radio.Name = "Paid_Radio"
        Me.Paid_Radio.Size = New System.Drawing.Size(46, 17)
        Me.Paid_Radio.TabIndex = 4
        Me.Paid_Radio.Text = "Paid"
        Me.Paid_Radio.UseVisualStyleBackColor = True
        '
        'Error_radio
        '
        Me.Error_radio.AutoSize = True
        Me.Error_radio.Location = New System.Drawing.Point(118, 11)
        Me.Error_radio.Name = "Error_radio"
        Me.Error_radio.Size = New System.Drawing.Size(47, 17)
        Me.Error_radio.TabIndex = 2
        Me.Error_radio.Text = "Error"
        Me.Error_radio.UseVisualStyleBackColor = True
        '
        'Unpaid_radio
        '
        Me.Unpaid_radio.AutoSize = True
        Me.Unpaid_radio.Location = New System.Drawing.Point(197, 11)
        Me.Unpaid_radio.Name = "Unpaid_radio"
        Me.Unpaid_radio.Size = New System.Drawing.Size(62, 17)
        Me.Unpaid_radio.TabIndex = 3
        Me.Unpaid_radio.Text = "Un-paid"
        Me.Unpaid_radio.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Total_units_v2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Totals_txt)
        Me.Panel1.Controls.Add(Me.Totalp_txt)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Tot_claims2)
        Me.Panel1.Location = New System.Drawing.Point(591, 382)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 120)
        Me.Panel1.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "TOTAL SUBMITTED"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(310, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TOTAL PAID"
        '
        'Totals_txt
        '
        Me.Totals_txt.AutoSize = True
        Me.Totals_txt.Location = New System.Drawing.Point(182, 40)
        Me.Totals_txt.Name = "Totals_txt"
        Me.Totals_txt.Size = New System.Drawing.Size(13, 13)
        Me.Totals_txt.TabIndex = 5
        Me.Totals_txt.Text = "$"
        '
        'Totalp_txt
        '
        Me.Totalp_txt.AutoSize = True
        Me.Totalp_txt.Location = New System.Drawing.Point(310, 40)
        Me.Totalp_txt.Name = "Totalp_txt"
        Me.Totalp_txt.Size = New System.Drawing.Size(13, 13)
        Me.Totalp_txt.TabIndex = 6
        Me.Totalp_txt.Text = "$"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "TOTAL COUNT"
        '
        'Tot_claims2
        '
        Me.Tot_claims2.AutoSize = True
        Me.Tot_claims2.Location = New System.Drawing.Point(16, 39)
        Me.Tot_claims2.Name = "Tot_claims2"
        Me.Tot_claims2.Size = New System.Drawing.Size(13, 13)
        Me.Tot_claims2.TabIndex = 9
        Me.Tot_claims2.Text = "0"
        '
        'filename_lbl
        '
        Me.filename_lbl.AutoSize = True
        Me.filename_lbl.Location = New System.Drawing.Point(734, 19)
        Me.filename_lbl.Name = "filename_lbl"
        Me.filename_lbl.Size = New System.Drawing.Size(49, 13)
        Me.filename_lbl.TabIndex = 23
        Me.filename_lbl.Text = "Filename"
        '
        'Filename_txt
        '
        Me.Filename_txt.Location = New System.Drawing.Point(789, 19)
        Me.Filename_txt.Name = "Filename_txt"
        Me.Filename_txt.ReadOnly = True
        Me.Filename_txt.Size = New System.Drawing.Size(193, 20)
        Me.Filename_txt.TabIndex = 22
        '
        'ServiceHistoryDataGrid
        '
        Me.ServiceHistoryDataGrid.AllowUserToAddRows = False
        Me.ServiceHistoryDataGrid.AllowUserToDeleteRows = False
        Me.ServiceHistoryDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ServiceHistoryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ServiceHistoryDataGrid.Location = New System.Drawing.Point(6, 45)
        Me.ServiceHistoryDataGrid.Name = "ServiceHistoryDataGrid"
        Me.ServiceHistoryDataGrid.ReadOnly = True
        Me.ServiceHistoryDataGrid.Size = New System.Drawing.Size(976, 331)
        Me.ServiceHistoryDataGrid.TabIndex = 2
        '
        'patient_id
        '
        Me.patient_id.Location = New System.Drawing.Point(177, -14)
        Me.patient_id.Name = "patient_id"
        Me.patient_id.Size = New System.Drawing.Size(100, 20)
        Me.patient_id.TabIndex = 43
        Me.patient_id.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "0"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.total_units_lbl)
        Me.Panel3.Controls.Add(Me.Total_units_v)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Location = New System.Drawing.Point(-1, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(392, 119)
        Me.Panel3.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "TOTAL COUNT"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(216, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "TOTAL AMOUNT"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(226, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "$"
        '
        'total_units_lbl
        '
        Me.total_units_lbl.AutoSize = True
        Me.total_units_lbl.Location = New System.Drawing.Point(16, 71)
        Me.total_units_lbl.Name = "total_units_lbl"
        Me.total_units_lbl.Size = New System.Drawing.Size(108, 13)
        Me.total_units_lbl.TabIndex = 6
        Me.total_units_lbl.Text = "TOTAL Service Units"
        '
        'Total_units_v
        '
        Me.Total_units_v.AutoSize = True
        Me.Total_units_v.Location = New System.Drawing.Point(19, 96)
        Me.Total_units_v.Name = "Total_units_v"
        Me.Total_units_v.Size = New System.Drawing.Size(13, 13)
        Me.Total_units_v.TabIndex = 7
        Me.Total_units_v.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "TOTAL Service Units"
        '
        'Total_units_v2
        '
        Me.Total_units_v2.AutoSize = True
        Me.Total_units_v2.Location = New System.Drawing.Point(19, 98)
        Me.Total_units_v2.Name = "Total_units_v2"
        Me.Total_units_v2.Size = New System.Drawing.Size(13, 13)
        Me.Total_units_v2.TabIndex = 11
        Me.Total_units_v2.Text = "0"
        '
        'TransactionHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 559)
        Me.Controls.Add(Me.patient_id)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TransactionHistory"
        Me.Text = "Transaction History"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.unsubmit_history, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ServiceHistoryDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ServiceHistoryDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents unsubmit_history As System.Windows.Forms.DataGridView
    Friend WithEvents TOTAL1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Totalp_txt As System.Windows.Forms.Label
    Friend WithEvents Totals_txt As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pr_sub As System.Windows.Forms.Button
    Friend WithEvents Tot_claims As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tot_claims2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents filename_lbl As System.Windows.Forms.Label
    Friend WithEvents Filename_txt As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Archive_btn As System.Windows.Forms.Button
    Friend WithEvents Select_claims_btn As System.Windows.Forms.Button
    Friend WithEvents resubmit_btn As System.Windows.Forms.Button
    Friend WithEvents Unpaid_radio As System.Windows.Forms.RadioButton
    Friend WithEvents Error_radio As System.Windows.Forms.RadioButton
    Friend WithEvents Paid_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents All_radio As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Open_search_radio As System.Windows.Forms.RadioButton
    Friend WithEvents show_all_open As System.Windows.Forms.Button
    Friend WithEvents Date_frm_open As System.Windows.Forms.DateTimePicker
    Friend WithEvents refresh_open As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Date_to_open As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pr_unsub As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radio_search_date As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_search_sub As System.Windows.Forms.RadioButton
    Friend WithEvents Show_all_Sub As System.Windows.Forms.Button
    Friend WithEvents Date_frm_sub As System.Windows.Forms.DateTimePicker
    Friend WithEvents Refresh_sub As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Date_to_sub As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Open_cl As System.Windows.Forms.RadioButton
    Friend WithEvents archived_cl As System.Windows.Forms.RadioButton
    Friend WithEvents patient_id As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents total_units_lbl As System.Windows.Forms.Label
    Friend WithEvents Total_units_v As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Total_units_v2 As System.Windows.Forms.Label
End Class
