Imports System
Imports dbAutoTrack.DataReports

Public Class Error_rpt
    Inherits dbAutoTrack.DataReports.Design.dbATReport

#Region " DataReports Designer generated code "

    Public Sub New(Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the rpt1 Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the DataReports Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the DataReports Designer
    'It can be modified using the DataReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents Detail As dbAutoTrack.DataReports.Detail
    Friend WithEvents DbATTextBox2 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox3 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox4 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox6 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents ReportHeader As dbAutoTrack.DataReports.ReportHeader
    Friend WithEvents ReportFooter As dbAutoTrack.DataReports.ReportFooter
    Friend WithEvents GroupHeader1 As dbAutoTrack.DataReports.GroupHeader
    Friend WithEvents GroupFooter1 As dbAutoTrack.DataReports.GroupFooter
    Friend WithEvents PageHeader As dbAutoTrack.DataReports.PageHeader
    Friend WithEvents PageFooter As dbAutoTrack.DataReports.PageFooter
    Friend WithEvents DbATLabel12 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel16 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel15 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel14 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel13 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel1 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox13 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox14 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel2 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel3 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox7 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel4 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents pg_num As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox8 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox9 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox10 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel5 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel6 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel7 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox1 As dbAutoTrack.DataReports.dbATTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Detail = New dbAutoTrack.DataReports.Detail()
        Me.DbATTextBox1 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox2 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox3 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox4 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox6 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox13 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox14 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox8 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox9 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox10 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.ReportHeader = New dbAutoTrack.DataReports.ReportHeader()
        Me.ReportFooter = New dbAutoTrack.DataReports.ReportFooter()
        Me.GroupHeader1 = New dbAutoTrack.DataReports.GroupHeader()
        Me.DbATTextBox7 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATLabel4 = New dbAutoTrack.DataReports.dbATLabel()
        Me.GroupFooter1 = New dbAutoTrack.DataReports.GroupFooter()
        Me.PageHeader = New dbAutoTrack.DataReports.PageHeader()
        Me.DbATLabel16 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel15 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel14 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel13 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel12 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel1 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel2 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel3 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel5 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel6 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel7 = New dbAutoTrack.DataReports.dbATLabel()
        Me.PageFooter = New dbAutoTrack.DataReports.PageFooter()
        Me.pg_num = New dbAutoTrack.DataReports.dbATLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATTextBox1, Me.DbATTextBox2, Me.DbATTextBox3, Me.DbATTextBox4, Me.DbATTextBox6, Me.DbATTextBox13, Me.DbATTextBox14, Me.DbATTextBox8, Me.DbATTextBox9, Me.DbATTextBox10})
        Me.Detail.Height = 19.0!
        Me.Detail.Name = "Detail"
        '
        'DbATTextBox1
        '
        Me.DbATTextBox1.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox1.DataField = "lname"
        Me.DbATTextBox1.Height = 24.0!
        Me.DbATTextBox1.Left = 0.0!
        Me.DbATTextBox1.Name = "DbATTextBox1"
        Me.DbATTextBox1.Parent = Me.Detail
        Me.DbATTextBox1.Top = 0.0!
        Me.DbATTextBox1.Width = 246.0!
        '
        'DbATTextBox2
        '
        Me.DbATTextBox2.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox2.DataField = "fname"
        Me.DbATTextBox2.Height = 24.0!
        Me.DbATTextBox2.Left = 246.0!
        Me.DbATTextBox2.Name = "DbATTextBox2"
        Me.DbATTextBox2.Parent = Me.Detail
        Me.DbATTextBox2.Top = 0.0!
        Me.DbATTextBox2.Width = 222.0!
        '
        'DbATTextBox3
        '
        Me.DbATTextBox3.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox3.DataField = "service_code"
        Me.DbATTextBox3.Height = 24.0!
        Me.DbATTextBox3.Left = 594.0!
        Me.DbATTextBox3.Name = "DbATTextBox3"
        Me.DbATTextBox3.Parent = Me.Detail
        Me.DbATTextBox3.Top = 0.0!
        Me.DbATTextBox3.Width = 54.0!
        '
        'DbATTextBox4
        '
        Me.DbATTextBox4.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox4.DataField = "num_serv"
        Me.DbATTextBox4.Height = 24.0!
        Me.DbATTextBox4.Left = 648.0!
        Me.DbATTextBox4.Name = "DbATTextBox4"
        Me.DbATTextBox4.Parent = Me.Detail
        Me.DbATTextBox4.Top = 0.0!
        Me.DbATTextBox4.Width = 36.0!
        '
        'DbATTextBox6
        '
        Me.DbATTextBox6.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox6.DataField = "Errorcode1"
        Me.DbATTextBox6.Height = 24.0!
        Me.DbATTextBox6.Left = 930.0!
        Me.DbATTextBox6.Name = "DbATTextBox6"
        Me.DbATTextBox6.OutputFormat = "$#,##0.00"
        Me.DbATTextBox6.Parent = Me.Detail
        Me.DbATTextBox6.Top = 0.0!
        Me.DbATTextBox6.Width = 54.0!
        '
        'DbATTextBox13
        '
        Me.DbATTextBox13.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox13.DataField = "ohip"
        Me.DbATTextBox13.Height = 24.0!
        Me.DbATTextBox13.Left = 468.0!
        Me.DbATTextBox13.Name = "DbATTextBox13"
        Me.DbATTextBox13.Parent = Me.Detail
        Me.DbATTextBox13.Top = 0.0!
        Me.DbATTextBox13.Width = 90.0!
        '
        'DbATTextBox14
        '
        Me.DbATTextBox14.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox14.DataField = "version"
        Me.DbATTextBox14.Height = 24.0!
        Me.DbATTextBox14.Left = 558.0!
        Me.DbATTextBox14.Name = "DbATTextBox14"
        Me.DbATTextBox14.Parent = Me.Detail
        Me.DbATTextBox14.Top = 0.0!
        Me.DbATTextBox14.Width = 36.0!
        '
        'DbATTextBox8
        '
        Me.DbATTextBox8.DataField = "ref"
        Me.DbATTextBox8.Height = 24.0!
        Me.DbATTextBox8.Left = 684.0!
        Me.DbATTextBox8.Name = "DbATTextBox8"
        Me.DbATTextBox8.Parent = Me.Detail
        Me.DbATTextBox8.Top = 0.0!
        Me.DbATTextBox8.Width = 102.0!
        '
        'DbATTextBox9
        '
        Me.DbATTextBox9.DataField = "inst"
        Me.DbATTextBox9.Height = 24.0!
        Me.DbATTextBox9.Left = 786.0!
        Me.DbATTextBox9.Name = "DbATTextBox9"
        Me.DbATTextBox9.Parent = Me.Detail
        Me.DbATTextBox9.Top = 0.0!
        Me.DbATTextBox9.Width = 72.0!
        '
        'DbATTextBox10
        '
        Me.DbATTextBox10.DataField = "adm_dt"
        Me.DbATTextBox10.Height = 24.0!
        Me.DbATTextBox10.Left = 858.0!
        Me.DbATTextBox10.Name = "DbATTextBox10"
        Me.DbATTextBox10.Parent = Me.Detail
        Me.DbATTextBox10.Top = 0.0!
        Me.DbATTextBox10.Width = 72.0!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 8.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 2.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATTextBox7, Me.DbATLabel4})
        Me.GroupHeader1.Height = 29.0!
        Me.GroupHeader1.Index = 1
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'DbATTextBox7
        '
        Me.DbATTextBox7.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATTextBox7.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox7.DataField = "service_date"
        Me.DbATTextBox7.Height = 24.0!
        Me.DbATTextBox7.Left = 534.0!
        Me.DbATTextBox7.Name = "DbATTextBox7"
        Me.DbATTextBox7.OutputFormat = ""
        Me.DbATTextBox7.Parent = Me.GroupHeader1
        Me.DbATTextBox7.Top = 0.0!
        Me.DbATTextBox7.Width = 102.0!
        '
        'DbATLabel4
        '
        Me.DbATLabel4.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel4.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel4.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel4.Height = 24.0!
        Me.DbATLabel4.Left = 462.0!
        Me.DbATLabel4.Name = "DbATLabel4"
        Me.DbATLabel4.Parent = Me.GroupHeader1
        Me.DbATLabel4.Text = "Service Date"
        Me.DbATLabel4.Top = 0.0!
        Me.DbATLabel4.Width = 72.0!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 9.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATLabel16, Me.DbATLabel15, Me.DbATLabel14, Me.DbATLabel13, Me.DbATLabel12, Me.DbATLabel1, Me.DbATLabel2, Me.DbATLabel3, Me.DbATLabel5, Me.DbATLabel6, Me.DbATLabel7})
        Me.PageHeader.Height = 92.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'DbATLabel16
        '
        Me.DbATLabel16.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel16.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel16.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel16.Height = 24.0!
        Me.DbATLabel16.Left = 654.0!
        Me.DbATLabel16.Name = "DbATLabel16"
        Me.DbATLabel16.Parent = Me.PageHeader
        Me.DbATLabel16.Text = "Units"
        Me.DbATLabel16.Top = 66.0!
        Me.DbATLabel16.Width = 30.0!
        '
        'DbATLabel15
        '
        Me.DbATLabel15.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel15.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel15.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel15.Height = 24.0!
        Me.DbATLabel15.Left = 594.0!
        Me.DbATLabel15.Name = "DbATLabel15"
        Me.DbATLabel15.Parent = Me.PageHeader
        Me.DbATLabel15.Text = "Service"
        Me.DbATLabel15.Top = 66.0!
        Me.DbATLabel15.Width = 60.0!
        '
        'DbATLabel14
        '
        Me.DbATLabel14.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel14.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel14.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel14.Height = 24.0!
        Me.DbATLabel14.Left = 246.0!
        Me.DbATLabel14.Name = "DbATLabel14"
        Me.DbATLabel14.Parent = Me.PageHeader
        Me.DbATLabel14.Text = "First Name"
        Me.DbATLabel14.Top = 66.0!
        Me.DbATLabel14.Width = 222.0!
        '
        'DbATLabel13
        '
        Me.DbATLabel13.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel13.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel13.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel13.Height = 24.0!
        Me.DbATLabel13.Left = 0.0!
        Me.DbATLabel13.Name = "DbATLabel13"
        Me.DbATLabel13.Parent = Me.PageHeader
        Me.DbATLabel13.Text = "Last Name"
        Me.DbATLabel13.Top = 66.0!
        Me.DbATLabel13.Width = 246.0!
        '
        'DbATLabel12
        '
        Me.DbATLabel12.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel12.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel12.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel12.Height = 24.0!
        Me.DbATLabel12.Left = 930.0!
        Me.DbATLabel12.Name = "DbATLabel12"
        Me.DbATLabel12.Parent = Me.PageHeader
        Me.DbATLabel12.Text = "Error Code"
        Me.DbATLabel12.Top = 66.0!
        Me.DbATLabel12.Width = 60.0!
        '
        'DbATLabel1
        '
        Me.DbATLabel1.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel1.Height = 30.0!
        Me.DbATLabel1.Left = 330.0!
        Me.DbATLabel1.Name = "DbATLabel1"
        Me.DbATLabel1.Parent = Me.PageHeader
        Me.DbATLabel1.Text = "Error Report"
        Me.DbATLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DbATLabel1.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATLabel1.Top = 0.0!
        Me.DbATLabel1.Width = 390.0!
        '
        'DbATLabel2
        '
        Me.DbATLabel2.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel2.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel2.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel2.Height = 24.0!
        Me.DbATLabel2.Left = 468.0!
        Me.DbATLabel2.Name = "DbATLabel2"
        Me.DbATLabel2.Parent = Me.PageHeader
        Me.DbATLabel2.Text = "Health #"
        Me.DbATLabel2.Top = 66.0!
        Me.DbATLabel2.Width = 90.0!
        '
        'DbATLabel3
        '
        Me.DbATLabel3.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel3.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel3.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel3.Height = 24.0!
        Me.DbATLabel3.Left = 558.0!
        Me.DbATLabel3.Name = "DbATLabel3"
        Me.DbATLabel3.Parent = Me.PageHeader
        Me.DbATLabel3.Text = "VER"
        Me.DbATLabel3.Top = 66.0!
        Me.DbATLabel3.Width = 36.0!
        '
        'DbATLabel5
        '
        Me.DbATLabel5.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel5.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel5.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel5.Height = 24.0!
        Me.DbATLabel5.Left = 684.0!
        Me.DbATLabel5.Name = "DbATLabel5"
        Me.DbATLabel5.Parent = Me.PageHeader
        Me.DbATLabel5.Text = "referring DR."
        Me.DbATLabel5.Top = 66.0!
        Me.DbATLabel5.Width = 102.0!
        '
        'DbATLabel6
        '
        Me.DbATLabel6.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel6.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel6.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel6.Height = 24.0!
        Me.DbATLabel6.Left = 786.0!
        Me.DbATLabel6.Name = "DbATLabel6"
        Me.DbATLabel6.Parent = Me.PageHeader
        Me.DbATLabel6.Text = "Institution"
        Me.DbATLabel6.Top = 66.0!
        Me.DbATLabel6.Width = 72.0!
        '
        'DbATLabel7
        '
        Me.DbATLabel7.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel7.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel7.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel7.Height = 24.0!
        Me.DbATLabel7.Left = 858.0!
        Me.DbATLabel7.Name = "DbATLabel7"
        Me.DbATLabel7.Parent = Me.PageHeader
        Me.DbATLabel7.Text = "Adm Date"
        Me.DbATLabel7.Top = 66.0!
        Me.DbATLabel7.Width = 72.0!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.pg_num})
        Me.PageFooter.Height = 20.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'pg_num
        '
        Me.pg_num.ForeColor = System.Drawing.Color.Black
        Me.pg_num.Height = 24.0!
        Me.pg_num.Left = 864.0!
        Me.pg_num.Name = "pg_num"
        Me.pg_num.Parent = Me.PageFooter
        Me.pg_num.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.pg_num.Top = 0.0!
        Me.pg_num.Width = 126.0!
        '
        'Error_rpt
        '
        Me.DefaultPaperSize = False
        Me.MarginBottom = 0.25!
        Me.MarginLeft = 0.25!
        Me.MarginRight = 0.25!
        Me.MarginTop = 0.25!
        Me.Orientation = dbAutoTrack.DataReports.PageOrientation.Landscape
        Me.PaperKind = System.Drawing.Printing.PaperKind.Letter
        Me.ReportWidth = 1034.0!
        Me.Sections.AddRange(New dbAutoTrack.DataReports.Section() {Me.ReportHeader, Me.PageHeader, Me.GroupHeader1, Me.Detail, Me.GroupFooter1, Me.PageFooter, Me.ReportFooter})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
    Dim pageno As Integer = 0
    Private Sub PageFooter_Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Initialize
        Me.pageno = Me.pageno + 1
        Me.pg_num.Text = String.Format("Page: {0}", pageno) & "/" & CStr(Me.MaxPages)
    End Sub
End Class


