Imports System
Imports dbAutoTrack.DataReports

Public Class MOH_msg_Rpt
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
    Friend WithEvents ReportHeader As dbAutoTrack.DataReports.ReportHeader
    Friend WithEvents ReportFooter As dbAutoTrack.DataReports.ReportFooter
    Friend WithEvents PageHeader As dbAutoTrack.DataReports.PageHeader
    Friend WithEvents PageFooter As dbAutoTrack.DataReports.PageFooter
    Friend WithEvents DbATTextBox1 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel1 As dbAutoTrack.DataReports.dbATLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Detail = New dbAutoTrack.DataReports.Detail()
        Me.DbATTextBox1 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.ReportHeader = New dbAutoTrack.DataReports.ReportHeader()
        Me.ReportFooter = New dbAutoTrack.DataReports.ReportFooter()
        Me.PageHeader = New dbAutoTrack.DataReports.PageHeader()
        Me.DbATLabel1 = New dbAutoTrack.DataReports.dbATLabel()
        Me.PageFooter = New dbAutoTrack.DataReports.PageFooter()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATTextBox1})
        Me.Detail.Height = 19.0!
        Me.Detail.Name = "Detail"
        '
        'DbATTextBox1
        '
        Me.DbATTextBox1.DataField = "message"
        Me.DbATTextBox1.Height = 24.0!
        Me.DbATTextBox1.Left = 6.0!
        Me.DbATTextBox1.Name = "DbATTextBox1"
        Me.DbATTextBox1.OutputFormat = "?"
        Me.DbATTextBox1.Parent = Me.Detail
        Me.DbATTextBox1.TextFont = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATTextBox1.Top = 0.0!
        Me.DbATTextBox1.Width = 630.0!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 8.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 1.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATLabel1})
        Me.PageHeader.Height = 39.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'DbATLabel1
        '
        Me.DbATLabel1.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel1.Height = 30.0!
        Me.DbATLabel1.Left = 108.0!
        Me.DbATLabel1.Name = "DbATLabel1"
        Me.DbATLabel1.Parent = Me.PageHeader
        Me.DbATLabel1.Text = "Ministry Remittance Message"
        Me.DbATLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DbATLabel1.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATLabel1.Top = 6.0!
        Me.DbATLabel1.Width = 390.0!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 4.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'MOH_msg_Rpt
        '
        Me.DefaultPaperSize = False
        Me.MarginBottom = 0.25!
        Me.MarginLeft = 0.25!
        Me.MarginRight = 0.25!
        Me.MarginTop = 0.25!
        Me.PaperKind = System.Drawing.Printing.PaperKind.Letter
        Me.ReportWidth = 642.0!
        Me.Sections.AddRange(New dbAutoTrack.DataReports.Section() {Me.ReportHeader, Me.PageHeader, Me.Detail, Me.PageFooter, Me.ReportFooter})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class


