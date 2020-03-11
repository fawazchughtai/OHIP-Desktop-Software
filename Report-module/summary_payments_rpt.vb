Imports System
Imports dbAutoTrack.DataReports

Public Class summary_payments_rpt

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
    Friend WithEvents PageHeader As dbAutoTrack.DataReports.PageHeader
    Friend WithEvents PageFooter As dbAutoTrack.DataReports.PageFooter
    Friend WithEvents DbATTextBox2 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox3 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox4 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel2 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel3 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel4 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLine1 As dbAutoTrack.DataReports.dbATLine
    Friend WithEvents DbATTextBox1 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox5 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents pg_num As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel1 As dbAutoTrack.DataReports.dbATLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Detail = New dbAutoTrack.DataReports.Detail()
        Me.DbATTextBox2 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox3 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox4 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox1 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox5 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.PageHeader = New dbAutoTrack.DataReports.PageHeader()
        Me.DbATLabel1 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel2 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel3 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel4 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLine1 = New dbAutoTrack.DataReports.dbATLine()
        Me.PageFooter = New dbAutoTrack.DataReports.PageFooter()
        Me.pg_num = New dbAutoTrack.DataReports.dbATLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATTextBox2, Me.DbATTextBox3, Me.DbATTextBox4, Me.DbATTextBox1, Me.DbATTextBox5})
        Me.Detail.Height = 23.0!
        Me.Detail.Name = "Detail"
        '
        'DbATTextBox2
        '
        Me.DbATTextBox2.DataField = "paydate_yr"
        Me.DbATTextBox2.Height = 24.0!
        Me.DbATTextBox2.Left = 288.0!
        Me.DbATTextBox2.Name = "DbATTextBox2"
        Me.DbATTextBox2.OutputFormat = ""
        Me.DbATTextBox2.Parent = Me.Detail
        Me.DbATTextBox2.Top = 0.0!
        Me.DbATTextBox2.Width = 30.0!
        '
        'DbATTextBox3
        '
        Me.DbATTextBox3.DataField = "payamt"
        Me.DbATTextBox3.Height = 24.0!
        Me.DbATTextBox3.Left = 480.0!
        Me.DbATTextBox3.Name = "DbATTextBox3"
        Me.DbATTextBox3.OutputFormat = "$#,##0.00"
        Me.DbATTextBox3.Parent = Me.Detail
        Me.DbATTextBox3.Top = 0.0!
        Me.DbATTextBox3.Width = 96.0!
        '
        'DbATTextBox4
        '
        Me.DbATTextBox4.DataField = "filename"
        Me.DbATTextBox4.Height = 24.0!
        Me.DbATTextBox4.Left = 12.0!
        Me.DbATTextBox4.Name = "DbATTextBox4"
        Me.DbATTextBox4.Parent = Me.Detail
        Me.DbATTextBox4.Top = 0.0!
        Me.DbATTextBox4.Width = 228.0!
        '
        'DbATTextBox1
        '
        Me.DbATTextBox1.DataField = "paydate_m"
        Me.DbATTextBox1.Height = 24.0!
        Me.DbATTextBox1.Left = 318.0!
        Me.DbATTextBox1.Name = "DbATTextBox1"
        Me.DbATTextBox1.Parent = Me.Detail
        Me.DbATTextBox1.Top = 0.0!
        Me.DbATTextBox1.Width = 18.0!
        '
        'DbATTextBox5
        '
        Me.DbATTextBox5.DataField = "Paydate_d"
        Me.DbATTextBox5.Height = 24.0!
        Me.DbATTextBox5.Left = 336.0!
        Me.DbATTextBox5.Name = "DbATTextBox5"
        Me.DbATTextBox5.Parent = Me.Detail
        Me.DbATTextBox5.Top = 0.0!
        Me.DbATTextBox5.Width = 18.0!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATLabel1, Me.DbATLabel2, Me.DbATLabel3, Me.DbATLabel4, Me.DbATLine1})
        Me.PageHeader.Height = 54.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'DbATLabel1
        '
        Me.DbATLabel1.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel1.Height = 30.0!
        Me.DbATLabel1.Left = 132.0!
        Me.DbATLabel1.Name = "DbATLabel1"
        Me.DbATLabel1.Parent = Me.PageHeader
        Me.DbATLabel1.Text = "Payment Summary Report"
        Me.DbATLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DbATLabel1.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATLabel1.Top = 0.0!
        Me.DbATLabel1.Width = 372.0!
        '
        'DbATLabel2
        '
        Me.DbATLabel2.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel2.Height = 24.0!
        Me.DbATLabel2.Left = 288.0!
        Me.DbATLabel2.Name = "DbATLabel2"
        Me.DbATLabel2.Parent = Me.PageHeader
        Me.DbATLabel2.Text = "Payment Date"
        Me.DbATLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DbATLabel2.Top = 30.0!
        Me.DbATLabel2.Width = 192.0!
        '
        'DbATLabel3
        '
        Me.DbATLabel3.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel3.Height = 24.0!
        Me.DbATLabel3.Left = 480.0!
        Me.DbATLabel3.Name = "DbATLabel3"
        Me.DbATLabel3.Parent = Me.PageHeader
        Me.DbATLabel3.Text = "Deposit amount"
        Me.DbATLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DbATLabel3.Top = 30.0!
        Me.DbATLabel3.Width = 96.0!
        '
        'DbATLabel4
        '
        Me.DbATLabel4.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel4.Height = 24.0!
        Me.DbATLabel4.Left = 12.0!
        Me.DbATLabel4.Name = "DbATLabel4"
        Me.DbATLabel4.Parent = Me.PageHeader
        Me.DbATLabel4.Text = "Reconciliation File"
        Me.DbATLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DbATLabel4.Top = 30.0!
        Me.DbATLabel4.Width = 138.0!
        '
        'DbATLine1
        '
        Me.DbATLine1.BorderBottomColor = System.Drawing.Color.Transparent
        Me.DbATLine1.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLine1.BorderRightColor = System.Drawing.Color.Transparent
        Me.DbATLine1.BorderTopColor = System.Drawing.Color.Transparent
        Me.DbATLine1.LineWeight = 1.0!
        Me.DbATLine1.Name = "DbATLine1"
        Me.DbATLine1.Parent = Me.PageHeader
        Me.DbATLine1.X1 = 582.0!
        Me.DbATLine1.X2 = 6.0!
        Me.DbATLine1.Y1 = 84.0!
        Me.DbATLine1.Y2 = 84.0!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.pg_num})
        Me.PageFooter.Height = 24.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'pg_num
        '
        Me.pg_num.ForeColor = System.Drawing.Color.Black
        Me.pg_num.Height = 24.0!
        Me.pg_num.Left = 624.0!
        Me.pg_num.Name = "pg_num"
        Me.pg_num.Parent = Me.PageFooter
        Me.pg_num.Top = 0.0!
        Me.pg_num.Width = 72.0!
        '
        'summary_payments_rpt
        '
        Me.DefaultPaperSize = False
        Me.MarginBottom = 0.25!
        Me.MarginLeft = 0.25!
        Me.MarginRight = 0.25!
        Me.MarginTop = 0.25!
        Me.PaperKind = System.Drawing.Printing.PaperKind.Letter
        Me.ReportWidth = 700.0!
        Me.Sections.AddRange(New dbAutoTrack.DataReports.Section() {Me.PageHeader, Me.Detail, Me.PageFooter})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
    Dim pageno As Integer = 0
    Private Sub PageFooter_Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Initialize
        Me.pageno = Me.pageno + 1
        Me.pg_num.Text = String.Format("Page: {0}", pageno) & "/" & String.Format(Me.MaxPages)

    End Sub

End Class


