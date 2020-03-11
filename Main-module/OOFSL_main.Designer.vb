<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class OOFSL_main
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents patient As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents OHIP As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Aboutus As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents useguide As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Help As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Quit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OOFSL_main))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.patient = New System.Windows.Forms.ToolStripMenuItem()
        Me.OHIP = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubmissionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Send2moh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReconciliationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClaimEntryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClaimManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EDTReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BatchReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MOHMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SummaryOfPaymentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PhysicianReferalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PhysicianInfoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReferralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivationCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilePathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiagnosisCodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanDuplicatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReprocessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchivefoldersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Help = New System.Windows.Forms.ToolStripMenuItem()
        Me.Aboutus = New System.Windows.Forms.ToolStripMenuItem()
        Me.useguide = New System.Windows.Forms.ToolStripMenuItem()
        Me.OHIPAssistantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TechSupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Quit = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status_bar_txt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.USBHID1 = New AxctlUSBHID.AxUSBHID()
        Me.BackupOnServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenu1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.USBHID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.patient, Me.OHIP, Me.EDTReportsToolStripMenuItem, Me.PhysicianReferalToolStripMenuItem, Me.SystemToolStripMenuItem, Me.Help, Me.Quit})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(1018, 24)
        Me.MainMenu1.TabIndex = 1
        '
        'patient
        '
        Me.patient.MergeAction = System.Windows.Forms.MergeAction.Remove
        Me.patient.Name = "patient"
        Me.patient.Size = New System.Drawing.Size(56, 20)
        Me.patient.Text = "Patient"
        '
        'OHIP
        '
        Me.OHIP.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SubmissionToolStripMenuItem, Me.Send2moh, Me.ReconciliationToolStripMenuItem, Me.ClaimEntryToolStripMenuItem1, Me.ClaimManagementToolStripMenuItem})
        Me.OHIP.MergeAction = System.Windows.Forms.MergeAction.Remove
        Me.OHIP.Name = "OHIP"
        Me.OHIP.Size = New System.Drawing.Size(47, 20)
        Me.OHIP.Text = "OHIP"
        '
        'SubmissionToolStripMenuItem
        '
        Me.SubmissionToolStripMenuItem.Name = "SubmissionToolStripMenuItem"
        Me.SubmissionToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SubmissionToolStripMenuItem.Text = "Submission"
        '
        'Send2moh
        '
        Me.Send2moh.Name = "Send2moh"
        Me.Send2moh.Size = New System.Drawing.Size(179, 22)
        Me.Send2moh.Text = "Send to MOH"
        Me.Send2moh.Visible = False
        '
        'ReconciliationToolStripMenuItem
        '
        Me.ReconciliationToolStripMenuItem.Name = "ReconciliationToolStripMenuItem"
        Me.ReconciliationToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ReconciliationToolStripMenuItem.Text = "Reconciliation"
        '
        'ClaimEntryToolStripMenuItem1
        '
        Me.ClaimEntryToolStripMenuItem1.Name = "ClaimEntryToolStripMenuItem1"
        Me.ClaimEntryToolStripMenuItem1.Size = New System.Drawing.Size(179, 22)
        Me.ClaimEntryToolStripMenuItem1.Text = "Claim Entry"
        '
        'ClaimManagementToolStripMenuItem
        '
        Me.ClaimManagementToolStripMenuItem.Name = "ClaimManagementToolStripMenuItem"
        Me.ClaimManagementToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ClaimManagementToolStripMenuItem.Text = "Claim Management"
        '
        'EDTReportsToolStripMenuItem
        '
        Me.EDTReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransactionHistoryToolStripMenuItem, Me.BatchReportToolStripMenuItem, Me.MOHMessageToolStripMenuItem, Me.ErrorReportsToolStripMenuItem, Me.SummaryOfPaymentsToolStripMenuItem})
        Me.EDTReportsToolStripMenuItem.Name = "EDTReportsToolStripMenuItem"
        Me.EDTReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.EDTReportsToolStripMenuItem.Text = "Reports"
        '
        'TransactionHistoryToolStripMenuItem
        '
        Me.TransactionHistoryToolStripMenuItem.Name = "TransactionHistoryToolStripMenuItem"
        Me.TransactionHistoryToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.TransactionHistoryToolStripMenuItem.Text = "Transaction/History"
        '
        'BatchReportToolStripMenuItem
        '
        Me.BatchReportToolStripMenuItem.Name = "BatchReportToolStripMenuItem"
        Me.BatchReportToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.BatchReportToolStripMenuItem.Text = "Batch Report"
        '
        'MOHMessageToolStripMenuItem
        '
        Me.MOHMessageToolStripMenuItem.Name = "MOHMessageToolStripMenuItem"
        Me.MOHMessageToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.MOHMessageToolStripMenuItem.Text = "Reconciliation Report"
        '
        'ErrorReportsToolStripMenuItem
        '
        Me.ErrorReportsToolStripMenuItem.Name = "ErrorReportsToolStripMenuItem"
        Me.ErrorReportsToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ErrorReportsToolStripMenuItem.Text = "Error Reports"
        '
        'SummaryOfPaymentsToolStripMenuItem
        '
        Me.SummaryOfPaymentsToolStripMenuItem.Name = "SummaryOfPaymentsToolStripMenuItem"
        Me.SummaryOfPaymentsToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.SummaryOfPaymentsToolStripMenuItem.Text = "Summary of Payments"
        '
        'PhysicianReferalToolStripMenuItem
        '
        Me.PhysicianReferalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PhysicianInfoToolStripMenuItem1, Me.ReferralToolStripMenuItem})
        Me.PhysicianReferalToolStripMenuItem.Name = "PhysicianReferalToolStripMenuItem"
        Me.PhysicianReferalToolStripMenuItem.Size = New System.Drawing.Size(114, 20)
        Me.PhysicianReferalToolStripMenuItem.Text = "Physician/Referral"
        '
        'PhysicianInfoToolStripMenuItem1
        '
        Me.PhysicianInfoToolStripMenuItem1.Name = "PhysicianInfoToolStripMenuItem1"
        Me.PhysicianInfoToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.PhysicianInfoToolStripMenuItem1.Text = "Physician Info"
        '
        'ReferralToolStripMenuItem
        '
        Me.ReferralToolStripMenuItem.Name = "ReferralToolStripMenuItem"
        Me.ReferralToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ReferralToolStripMenuItem.Text = "Referral"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivationCodeToolStripMenuItem, Me.BackupToolStripMenuItem1, Me.FilePathToolStripMenuItem, Me.ServiceToolStripMenuItem, Me.DiagnosisCodesToolStripMenuItem, Me.CheckForUpdatesToolStripMenuItem, Me.CleanDuplicatesToolStripMenuItem, Me.ReprocessToolStripMenuItem, Me.ArchivefoldersToolStripMenuItem, Me.BackupOnServerToolStripMenuItem})
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.SystemToolStripMenuItem.Text = "System"
        '
        'ActivationCodeToolStripMenuItem
        '
        Me.ActivationCodeToolStripMenuItem.Name = "ActivationCodeToolStripMenuItem"
        Me.ActivationCodeToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ActivationCodeToolStripMenuItem.Text = "Activation"
        '
        'BackupToolStripMenuItem1
        '
        Me.BackupToolStripMenuItem1.Name = "BackupToolStripMenuItem1"
        Me.BackupToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.BackupToolStripMenuItem1.Text = "Backup"
        '
        'FilePathToolStripMenuItem
        '
        Me.FilePathToolStripMenuItem.Name = "FilePathToolStripMenuItem"
        Me.FilePathToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.FilePathToolStripMenuItem.Text = "File Path"
        '
        'ServiceToolStripMenuItem
        '
        Me.ServiceToolStripMenuItem.Name = "ServiceToolStripMenuItem"
        Me.ServiceToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ServiceToolStripMenuItem.Text = "Service Codes"
        '
        'DiagnosisCodesToolStripMenuItem
        '
        Me.DiagnosisCodesToolStripMenuItem.Name = "DiagnosisCodesToolStripMenuItem"
        Me.DiagnosisCodesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.DiagnosisCodesToolStripMenuItem.Text = "Diagnosis Codes"
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check for updates"
        '
        'CleanDuplicatesToolStripMenuItem
        '
        Me.CleanDuplicatesToolStripMenuItem.Name = "CleanDuplicatesToolStripMenuItem"
        Me.CleanDuplicatesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.CleanDuplicatesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.CleanDuplicatesToolStripMenuItem.Text = "Clean"
        '
        'ReprocessToolStripMenuItem
        '
        Me.ReprocessToolStripMenuItem.Name = "ReprocessToolStripMenuItem"
        Me.ReprocessToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
        Me.ReprocessToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ReprocessToolStripMenuItem.Text = "Re-process"
        '
        'ArchivefoldersToolStripMenuItem
        '
        Me.ArchivefoldersToolStripMenuItem.Name = "ArchivefoldersToolStripMenuItem"
        Me.ArchivefoldersToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ArchivefoldersToolStripMenuItem.Text = "Archive folders"
        '
        'Help
        '
        Me.Help.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Aboutus, Me.useguide, Me.OHIPAssistantToolStripMenuItem, Me.TechSupportToolStripMenuItem})
        Me.Help.MergeAction = System.Windows.Forms.MergeAction.Remove
        Me.Help.Name = "Help"
        Me.Help.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.Help.Size = New System.Drawing.Size(44, 20)
        Me.Help.Text = "Help"
        '
        'Aboutus
        '
        Me.Aboutus.Name = "Aboutus"
        Me.Aboutus.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.Aboutus.Size = New System.Drawing.Size(227, 22)
        Me.Aboutus.Text = "About OHIP-BILLING"
        '
        'useguide
        '
        Me.useguide.Name = "useguide"
        Me.useguide.Size = New System.Drawing.Size(227, 22)
        Me.useguide.Text = "User guide"
        '
        'OHIPAssistantToolStripMenuItem
        '
        Me.OHIPAssistantToolStripMenuItem.Name = "OHIPAssistantToolStripMenuItem"
        Me.OHIPAssistantToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.OHIPAssistantToolStripMenuItem.Text = "Show OHIP Assistant"
        Me.OHIPAssistantToolStripMenuItem.Visible = False
        '
        'TechSupportToolStripMenuItem
        '
        Me.TechSupportToolStripMenuItem.Name = "TechSupportToolStripMenuItem"
        Me.TechSupportToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.TechSupportToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.TechSupportToolStripMenuItem.Text = "Tech support"
        '
        'Quit
        '
        Me.Quit.MergeAction = System.Windows.Forms.MergeAction.Remove
        Me.Quit.Name = "Quit"
        Me.Quit.Size = New System.Drawing.Size(48, 20)
        Me.Quit.Text = "Close"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status_bar_txt})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 600)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1018, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status_bar_txt
        '
        Me.status_bar_txt.Name = "status_bar_txt"
        Me.status_bar_txt.Size = New System.Drawing.Size(0, 17)
        '
        'USBHID1
        '
        Me.USBHID1.Enabled = True
        Me.USBHID1.Location = New System.Drawing.Point(28, 54)
        Me.USBHID1.Name = "USBHID1"
        Me.USBHID1.OcxState = CType(resources.GetObject("USBHID1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.USBHID1.Size = New System.Drawing.Size(56, 54)
        Me.USBHID1.TabIndex = 128
        '
        'BackupOnServerToolStripMenuItem
        '
        Me.BackupOnServerToolStripMenuItem.Name = "BackupOnServerToolStripMenuItem"
        Me.BackupOnServerToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.BackupOnServerToolStripMenuItem.Text = "Backup on server"
        '
        'OOFSL_main
        '
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(1018, 622)
        Me.Controls.Add(Me.USBHID1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "OOFSL_main"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OHIP Billing System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.USBHID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SubmissionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReconciliationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivationCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilePathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PhysicianReferalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PhysicianInfoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReferralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EDTReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BatchReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MOHMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents status_bar_txt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CheckForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Send2moh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiagnosisCodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SummaryOfPaymentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CleanDuplicatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClaimEntryToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OHIPAssistantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReprocessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClaimManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TechSupportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArchivefoldersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents USBHID1 As AxctlUSBHID.AxUSBHID
    Friend WithEvents BackupOnServerToolStripMenuItem As ToolStripMenuItem
#End Region
End Class