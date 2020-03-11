Imports System
Imports dbAutoTrack.DataReports

Public Class Claim_detail_rpt
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
    Friend WithEvents DbATTextBox8 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel10 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel11 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox9 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox10 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox5 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox11 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox12 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents PageHeader As dbAutoTrack.DataReports.PageHeader
    Friend WithEvents PageFooter As dbAutoTrack.DataReports.PageFooter
    Friend WithEvents DbATLabel12 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel18 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel17 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel16 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel15 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel14 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel13 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents Claim_rpt_title As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox13 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox14 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel2 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel3 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox7 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel4 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox16 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel6 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox15 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel5 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents pg_num As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox17 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox18 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox19 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel7 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel8 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel9 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox20 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATTextBox21 As dbAutoTrack.DataReports.dbATTextBox
    Friend WithEvents DbATLabel19 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATLabel20 As dbAutoTrack.DataReports.dbATLabel
    Friend WithEvents DbATTextBox1 As dbAutoTrack.DataReports.dbATTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Detail = New dbAutoTrack.DataReports.Detail()
        Me.DbATTextBox10 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox5 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox1 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox2 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox3 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox4 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox6 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox13 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox14 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox17 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox18 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox19 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox20 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox21 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.ReportHeader = New dbAutoTrack.DataReports.ReportHeader()
        Me.ReportFooter = New dbAutoTrack.DataReports.ReportFooter()
        Me.DbATTextBox11 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATLabel11 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATTextBox9 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox16 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATLabel6 = New dbAutoTrack.DataReports.dbATLabel()
        Me.GroupHeader1 = New dbAutoTrack.DataReports.GroupHeader()
        Me.DbATTextBox7 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATLabel4 = New dbAutoTrack.DataReports.dbATLabel()
        Me.GroupFooter1 = New dbAutoTrack.DataReports.GroupFooter()
        Me.DbATTextBox12 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATTextBox8 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATLabel10 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATTextBox15 = New dbAutoTrack.DataReports.dbATTextBox()
        Me.DbATLabel5 = New dbAutoTrack.DataReports.dbATLabel()
        Me.PageHeader = New dbAutoTrack.DataReports.PageHeader()
        Me.DbATLabel18 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel17 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel16 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel15 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel14 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel13 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel12 = New dbAutoTrack.DataReports.dbATLabel()
        Me.Claim_rpt_title = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel2 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel3 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel7 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel8 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel9 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel19 = New dbAutoTrack.DataReports.dbATLabel()
        Me.DbATLabel20 = New dbAutoTrack.DataReports.dbATLabel()
        Me.PageFooter = New dbAutoTrack.DataReports.PageFooter()
        Me.pg_num = New dbAutoTrack.DataReports.dbATLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATTextBox10, Me.DbATTextBox5, Me.DbATTextBox1, Me.DbATTextBox2, Me.DbATTextBox3, Me.DbATTextBox4, Me.DbATTextBox6, Me.DbATTextBox13, Me.DbATTextBox14, Me.DbATTextBox17, Me.DbATTextBox18, Me.DbATTextBox19, Me.DbATTextBox20, Me.DbATTextBox21})
        Me.Detail.Height = 30.0!
        Me.Detail.Name = "Detail"
        '
        'DbATTextBox10
        '
        Me.DbATTextBox10.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox10.DataField = "amt_paid"
        Me.DbATTextBox10.Height = 24.0!
        Me.DbATTextBox10.Left = 876.0!
        Me.DbATTextBox10.Name = "DbATTextBox10"
        Me.DbATTextBox10.OutputFormat = "$#,##0.00"
        Me.DbATTextBox10.Parent = Me.Detail
        Me.DbATTextBox10.Top = 0.0!
        Me.DbATTextBox10.Width = 72.0!
        '
        'DbATTextBox5
        '
        Me.DbATTextBox5.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox5.DataField = "Total_Fee"
        Me.DbATTextBox5.Height = 24.0!
        Me.DbATTextBox5.Left = 792.0!
        Me.DbATTextBox5.Name = "DbATTextBox5"
        Me.DbATTextBox5.OutputFormat = "$#,##0.00"
        Me.DbATTextBox5.Parent = Me.Detail
        Me.DbATTextBox5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.DbATTextBox5.Top = 0.0!
        Me.DbATTextBox5.Width = 84.0!
        '
        'DbATTextBox1
        '
        Me.DbATTextBox1.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox1.DataField = "lname"
        Me.DbATTextBox1.Height = 24.0!
        Me.DbATTextBox1.Left = 24.0!
        Me.DbATTextBox1.Name = "DbATTextBox1"
        Me.DbATTextBox1.Parent = Me.Detail
        Me.DbATTextBox1.Top = 0.0!
        Me.DbATTextBox1.Width = 138.0!
        '
        'DbATTextBox2
        '
        Me.DbATTextBox2.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox2.DataField = "fname"
        Me.DbATTextBox2.Height = 24.0!
        Me.DbATTextBox2.Left = 162.0!
        Me.DbATTextBox2.Name = "DbATTextBox2"
        Me.DbATTextBox2.Parent = Me.Detail
        Me.DbATTextBox2.Top = 0.0!
        Me.DbATTextBox2.Width = 138.0!
        '
        'DbATTextBox3
        '
        Me.DbATTextBox3.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox3.DataField = "service_code"
        Me.DbATTextBox3.Height = 24.0!
        Me.DbATTextBox3.Left = 696.0!
        Me.DbATTextBox3.Name = "DbATTextBox3"
        Me.DbATTextBox3.Parent = Me.Detail
        Me.DbATTextBox3.Top = 0.0!
        Me.DbATTextBox3.Width = 66.0!
        '
        'DbATTextBox4
        '
        Me.DbATTextBox4.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox4.DataField = "num_serv"
        Me.DbATTextBox4.Height = 24.0!
        Me.DbATTextBox4.Left = 762.0!
        Me.DbATTextBox4.Name = "DbATTextBox4"
        Me.DbATTextBox4.Parent = Me.Detail
        Me.DbATTextBox4.Top = 0.0!
        Me.DbATTextBox4.Width = 30.0!
        '
        'DbATTextBox6
        '
        Me.DbATTextBox6.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox6.DataField = "error"
        Me.DbATTextBox6.Height = 24.0!
        Me.DbATTextBox6.Left = 948.0!
        Me.DbATTextBox6.Name = "DbATTextBox6"
        Me.DbATTextBox6.OutputFormat = "$#,##0.00"
        Me.DbATTextBox6.Parent = Me.Detail
        Me.DbATTextBox6.Top = 0.0!
        Me.DbATTextBox6.Width = 60.0!
        '
        'DbATTextBox13
        '
        Me.DbATTextBox13.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox13.DataField = "ohip"
        Me.DbATTextBox13.Height = 24.0!
        Me.DbATTextBox13.Left = 300.0!
        Me.DbATTextBox13.Name = "DbATTextBox13"
        Me.DbATTextBox13.Parent = Me.Detail
        Me.DbATTextBox13.Top = 0.0!
        Me.DbATTextBox13.Width = 72.0!
        '
        'DbATTextBox14
        '
        Me.DbATTextBox14.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox14.DataField = "version"
        Me.DbATTextBox14.Height = 24.0!
        Me.DbATTextBox14.Left = 372.0!
        Me.DbATTextBox14.Name = "DbATTextBox14"
        Me.DbATTextBox14.Parent = Me.Detail
        Me.DbATTextBox14.Top = 0.0!
        Me.DbATTextBox14.Width = 36.0!
        '
        'DbATTextBox17
        '
        Me.DbATTextBox17.DataField = "adm_dt"
        Me.DbATTextBox17.Height = 24.0!
        Me.DbATTextBox17.Left = 612.0!
        Me.DbATTextBox17.Name = "DbATTextBox17"
        Me.DbATTextBox17.OutputFormat = "dd-MMM-yyyy"
        Me.DbATTextBox17.Parent = Me.Detail
        Me.DbATTextBox17.Top = 0.0!
        Me.DbATTextBox17.Width = 84.0!
        '
        'DbATTextBox18
        '
        Me.DbATTextBox18.DataField = "inst"
        Me.DbATTextBox18.Height = 24.0!
        Me.DbATTextBox18.Left = 564.0!
        Me.DbATTextBox18.Name = "DbATTextBox18"
        Me.DbATTextBox18.Parent = Me.Detail
        Me.DbATTextBox18.Top = 0.0!
        Me.DbATTextBox18.Width = 48.0!
        '
        'DbATTextBox19
        '
        Me.DbATTextBox19.DataField = "ref"
        Me.DbATTextBox19.Height = 24.0!
        Me.DbATTextBox19.Left = 516.0!
        Me.DbATTextBox19.Name = "DbATTextBox19"
        Me.DbATTextBox19.Parent = Me.Detail
        Me.DbATTextBox19.Top = 0.0!
        Me.DbATTextBox19.Width = 48.0!
        '
        'DbATTextBox20
        '
        Me.DbATTextBox20.DataField = "dob"
        Me.DbATTextBox20.Height = 24.0!
        Me.DbATTextBox20.Left = 408.0!
        Me.DbATTextBox20.Name = "DbATTextBox20"
        Me.DbATTextBox20.OutputFormat = "dd-MMM-yyyy"
        Me.DbATTextBox20.Parent = Me.Detail
        Me.DbATTextBox20.Top = 0.0!
        Me.DbATTextBox20.Width = 90.0!
        '
        'DbATTextBox21
        '
        Me.DbATTextBox21.DataField = "sex"
        Me.DbATTextBox21.Height = 24.0!
        Me.DbATTextBox21.Left = 498.0!
        Me.DbATTextBox21.Name = "DbATTextBox21"
        Me.DbATTextBox21.Parent = Me.Detail
        Me.DbATTextBox21.Top = 0.0!
        Me.DbATTextBox21.Width = 18.0!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 8.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATTextBox11, Me.DbATLabel11, Me.DbATTextBox9, Me.DbATTextBox16, Me.DbATLabel6})
        Me.ReportFooter.Height = 19.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'DbATTextBox11
        '
        Me.DbATTextBox11.DataField = "Total_Fee"
        Me.DbATTextBox11.Height = 24.0!
        Me.DbATTextBox11.Left = 780.0!
        Me.DbATTextBox11.Name = "DbATTextBox11"
        Me.DbATTextBox11.OutputFormat = "$#,##0.00"
        Me.DbATTextBox11.Parent = Me.ReportFooter
        Me.DbATTextBox11.SummaryFunc = dbAutoTrack.DataReports.AggregateType.Sum
        Me.DbATTextBox11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.DbATTextBox11.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATTextBox11.Top = 0.0!
        Me.DbATTextBox11.Width = 84.0!
        '
        'DbATLabel11
        '
        Me.DbATLabel11.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel11.Height = 24.0!
        Me.DbATLabel11.Left = 702.0!
        Me.DbATLabel11.Name = "DbATLabel11"
        Me.DbATLabel11.Parent = Me.ReportFooter
        Me.DbATLabel11.Text = "TOTAL"
        Me.DbATLabel11.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATLabel11.Top = 0.0!
        Me.DbATLabel11.Width = 72.0!
        '
        'DbATTextBox9
        '
        Me.DbATTextBox9.DataField = "amt_paid"
        Me.DbATTextBox9.Height = 24.0!
        Me.DbATTextBox9.Left = 864.0!
        Me.DbATTextBox9.Name = "DbATTextBox9"
        Me.DbATTextBox9.OutputFormat = "$#,##0.00"
        Me.DbATTextBox9.Parent = Me.ReportFooter
        Me.DbATTextBox9.SummaryFunc = dbAutoTrack.DataReports.AggregateType.Sum
        Me.DbATTextBox9.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATTextBox9.Top = 0.0!
        Me.DbATTextBox9.Width = 84.0!
        '
        'DbATTextBox16
        '
        Me.DbATTextBox16.DataField = "ohip"
        Me.DbATTextBox16.Height = 24.0!
        Me.DbATTextBox16.Left = 612.0!
        Me.DbATTextBox16.Name = "DbATTextBox16"
        Me.DbATTextBox16.Parent = Me.ReportFooter
        Me.DbATTextBox16.SummaryFunc = dbAutoTrack.DataReports.AggregateType.Count
        Me.DbATTextBox16.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATTextBox16.Top = 0.0!
        Me.DbATTextBox16.Width = 72.0!
        '
        'DbATLabel6
        '
        Me.DbATLabel6.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel6.Height = 24.0!
        Me.DbATLabel6.Left = 534.0!
        Me.DbATLabel6.Name = "DbATLabel6"
        Me.DbATLabel6.Parent = Me.ReportFooter
        Me.DbATLabel6.Text = "Total Count"
        Me.DbATLabel6.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATLabel6.Top = 0.0!
        Me.DbATLabel6.Width = 72.0!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATTextBox7, Me.DbATLabel4})
        Me.GroupHeader1.Height = 18.0!
        Me.GroupHeader1.Index = 1
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'DbATTextBox7
        '
        Me.DbATTextBox7.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATTextBox7.DataField = "service_date"
        Me.DbATTextBox7.Height = 24.0!
        Me.DbATTextBox7.Left = 492.0!
        Me.DbATTextBox7.Name = "DbATTextBox7"
        Me.DbATTextBox7.OutputFormat = "dd-MMM-yyyy"
        Me.DbATTextBox7.Parent = Me.GroupHeader1
        Me.DbATTextBox7.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATTextBox7.Top = 0.0!
        Me.DbATTextBox7.Width = 102.0!
        '
        'DbATLabel4
        '
        Me.DbATLabel4.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel4.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel4.Height = 24.0!
        Me.DbATLabel4.Left = 414.0!
        Me.DbATLabel4.Name = "DbATLabel4"
        Me.DbATLabel4.Parent = Me.GroupHeader1
        Me.DbATLabel4.Text = "Service Date"
        Me.DbATLabel4.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATLabel4.Top = 0.0!
        Me.DbATLabel4.Width = 72.0!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATTextBox12, Me.DbATTextBox8, Me.DbATLabel10, Me.DbATTextBox15, Me.DbATLabel5})
        Me.GroupFooter1.Height = 16.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'DbATTextBox12
        '
        Me.DbATTextBox12.DataField = "Total_Fee"
        Me.DbATTextBox12.Height = 24.0!
        Me.DbATTextBox12.Left = 780.0!
        Me.DbATTextBox12.Name = "DbATTextBox12"
        Me.DbATTextBox12.OutputFormat = "$#,##0.00"
        Me.DbATTextBox12.Parent = Me.GroupFooter1
        Me.DbATTextBox12.SummaryFunc = dbAutoTrack.DataReports.AggregateType.Sum
        Me.DbATTextBox12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.DbATTextBox12.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATTextBox12.Top = 0.0!
        Me.DbATTextBox12.Width = 84.0!
        '
        'DbATTextBox8
        '
        Me.DbATTextBox8.DataField = "amt_paid"
        Me.DbATTextBox8.Height = 24.0!
        Me.DbATTextBox8.Left = 864.0!
        Me.DbATTextBox8.Name = "DbATTextBox8"
        Me.DbATTextBox8.OutputFormat = "$#,##0.00"
        Me.DbATTextBox8.Parent = Me.GroupFooter1
        Me.DbATTextBox8.SummaryFunc = dbAutoTrack.DataReports.AggregateType.Sum
        Me.DbATTextBox8.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATTextBox8.Top = 0.0!
        Me.DbATTextBox8.Width = 84.0!
        '
        'DbATLabel10
        '
        Me.DbATLabel10.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel10.Height = 24.0!
        Me.DbATLabel10.Left = 708.0!
        Me.DbATLabel10.Name = "DbATLabel10"
        Me.DbATLabel10.Parent = Me.GroupFooter1
        Me.DbATLabel10.Text = "Sub-total"
        Me.DbATLabel10.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATLabel10.Top = 0.0!
        Me.DbATLabel10.Width = 72.0!
        '
        'DbATTextBox15
        '
        Me.DbATTextBox15.DataField = "ohip"
        Me.DbATTextBox15.Height = 24.0!
        Me.DbATTextBox15.Left = 612.0!
        Me.DbATTextBox15.Name = "DbATTextBox15"
        Me.DbATTextBox15.Parent = Me.GroupFooter1
        Me.DbATTextBox15.SummaryFunc = dbAutoTrack.DataReports.AggregateType.Count
        Me.DbATTextBox15.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATTextBox15.Top = 0.0!
        Me.DbATTextBox15.Width = 72.0!
        '
        'DbATLabel5
        '
        Me.DbATLabel5.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel5.Height = 24.0!
        Me.DbATLabel5.Left = 534.0!
        Me.DbATLabel5.Name = "DbATLabel5"
        Me.DbATLabel5.Parent = Me.GroupFooter1
        Me.DbATLabel5.Text = "Count"
        Me.DbATLabel5.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DbATLabel5.Top = 0.0!
        Me.DbATLabel5.Width = 72.0!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.DbATLabel18, Me.DbATLabel17, Me.DbATLabel16, Me.DbATLabel15, Me.DbATLabel14, Me.DbATLabel13, Me.DbATLabel12, Me.Claim_rpt_title, Me.DbATLabel2, Me.DbATLabel3, Me.DbATLabel7, Me.DbATLabel8, Me.DbATLabel9, Me.DbATLabel19, Me.DbATLabel20})
        Me.PageHeader.Height = 92.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'DbATLabel18
        '
        Me.DbATLabel18.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel18.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel18.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel18.Height = 24.0!
        Me.DbATLabel18.Left = 882.0!
        Me.DbATLabel18.Name = "DbATLabel18"
        Me.DbATLabel18.Parent = Me.PageHeader
        Me.DbATLabel18.Text = "Amount Paid"
        Me.DbATLabel18.Top = 66.0!
        Me.DbATLabel18.Width = 66.0!
        '
        'DbATLabel17
        '
        Me.DbATLabel17.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel17.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel17.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel17.Height = 24.0!
        Me.DbATLabel17.Left = 798.0!
        Me.DbATLabel17.Name = "DbATLabel17"
        Me.DbATLabel17.Parent = Me.PageHeader
        Me.DbATLabel17.Text = "Total Submitted"
        Me.DbATLabel17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.DbATLabel17.Top = 66.0!
        Me.DbATLabel17.Width = 84.0!
        '
        'DbATLabel16
        '
        Me.DbATLabel16.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel16.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel16.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel16.Height = 24.0!
        Me.DbATLabel16.Left = 768.0!
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
        Me.DbATLabel15.Left = 708.0!
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
        Me.DbATLabel14.Left = 168.0!
        Me.DbATLabel14.Name = "DbATLabel14"
        Me.DbATLabel14.Parent = Me.PageHeader
        Me.DbATLabel14.Text = "First Name"
        Me.DbATLabel14.Top = 66.0!
        Me.DbATLabel14.Width = 138.0!
        '
        'DbATLabel13
        '
        Me.DbATLabel13.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel13.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel13.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel13.Height = 24.0!
        Me.DbATLabel13.Left = 24.0!
        Me.DbATLabel13.Name = "DbATLabel13"
        Me.DbATLabel13.Parent = Me.PageHeader
        Me.DbATLabel13.Text = "Last Name"
        Me.DbATLabel13.Top = 66.0!
        Me.DbATLabel13.Width = 144.0!
        '
        'DbATLabel12
        '
        Me.DbATLabel12.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel12.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel12.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel12.Height = 24.0!
        Me.DbATLabel12.Left = 948.0!
        Me.DbATLabel12.Name = "DbATLabel12"
        Me.DbATLabel12.Parent = Me.PageHeader
        Me.DbATLabel12.Text = "Error Code"
        Me.DbATLabel12.Top = 66.0!
        Me.DbATLabel12.Width = 60.0!
        '
        'Claim_rpt_title
        '
        Me.Claim_rpt_title.ForeColor = System.Drawing.Color.Black
        Me.Claim_rpt_title.Height = 30.0!
        Me.Claim_rpt_title.Left = 342.0!
        Me.Claim_rpt_title.Name = "Claim_rpt_title"
        Me.Claim_rpt_title.Parent = Me.PageHeader
        Me.Claim_rpt_title.Text = "Claim Detail Report"
        Me.Claim_rpt_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Claim_rpt_title.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Claim_rpt_title.Top = 6.0!
        Me.Claim_rpt_title.Width = 390.0!
        '
        'DbATLabel2
        '
        Me.DbATLabel2.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel2.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel2.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel2.Height = 24.0!
        Me.DbATLabel2.Left = 306.0!
        Me.DbATLabel2.Name = "DbATLabel2"
        Me.DbATLabel2.Parent = Me.PageHeader
        Me.DbATLabel2.Text = "Health #"
        Me.DbATLabel2.Top = 66.0!
        Me.DbATLabel2.Width = 72.0!
        '
        'DbATLabel3
        '
        Me.DbATLabel3.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel3.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel3.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel3.Height = 24.0!
        Me.DbATLabel3.Left = 378.0!
        Me.DbATLabel3.Name = "DbATLabel3"
        Me.DbATLabel3.Parent = Me.PageHeader
        Me.DbATLabel3.Text = "VER"
        Me.DbATLabel3.Top = 66.0!
        Me.DbATLabel3.Width = 36.0!
        '
        'DbATLabel7
        '
        Me.DbATLabel7.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel7.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel7.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel7.Height = 24.0!
        Me.DbATLabel7.Left = 522.0!
        Me.DbATLabel7.Name = "DbATLabel7"
        Me.DbATLabel7.Parent = Me.PageHeader
        Me.DbATLabel7.Text = "Ref#"
        Me.DbATLabel7.Top = 66.0!
        Me.DbATLabel7.Width = 48.0!
        '
        'DbATLabel8
        '
        Me.DbATLabel8.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel8.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel8.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel8.Height = 24.0!
        Me.DbATLabel8.Left = 570.0!
        Me.DbATLabel8.Name = "DbATLabel8"
        Me.DbATLabel8.Parent = Me.PageHeader
        Me.DbATLabel8.Text = "Instit."
        Me.DbATLabel8.Top = 66.0!
        Me.DbATLabel8.Width = 54.0!
        '
        'DbATLabel9
        '
        Me.DbATLabel9.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel9.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel9.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel9.Height = 24.0!
        Me.DbATLabel9.Left = 624.0!
        Me.DbATLabel9.Name = "DbATLabel9"
        Me.DbATLabel9.Parent = Me.PageHeader
        Me.DbATLabel9.Text = "Adm Date"
        Me.DbATLabel9.Top = 66.0!
        Me.DbATLabel9.Width = 84.0!
        '
        'DbATLabel19
        '
        Me.DbATLabel19.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel19.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel19.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel19.Height = 24.0!
        Me.DbATLabel19.Left = 414.0!
        Me.DbATLabel19.Name = "DbATLabel19"
        Me.DbATLabel19.Parent = Me.PageHeader
        Me.DbATLabel19.Text = "DOB"
        Me.DbATLabel19.Top = 66.0!
        Me.DbATLabel19.Width = 84.0!
        '
        'DbATLabel20
        '
        Me.DbATLabel20.BorderBottomStyle = dbAutoTrack.DataReports.BorderLineStyle.ExtraThickSolid
        Me.DbATLabel20.BorderLeftColor = System.Drawing.Color.Transparent
        Me.DbATLabel20.ForeColor = System.Drawing.Color.Black
        Me.DbATLabel20.Height = 24.0!
        Me.DbATLabel20.Left = 498.0!
        Me.DbATLabel20.Name = "DbATLabel20"
        Me.DbATLabel20.Parent = Me.PageHeader
        Me.DbATLabel20.Text = "Sex"
        Me.DbATLabel20.Top = 66.0!
        Me.DbATLabel20.Width = 24.0!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New dbAutoTrack.DataReports.dbATControl() {Me.pg_num})
        Me.PageFooter.Height = 22.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'pg_num
        '
        Me.pg_num.ForeColor = System.Drawing.Color.Black
        Me.pg_num.Height = 24.0!
        Me.pg_num.Left = 936.0!
        Me.pg_num.Name = "pg_num"
        Me.pg_num.Parent = Me.PageFooter
        Me.pg_num.Top = 0.0!
        Me.pg_num.Width = 72.0!
        '
        'Claim_detail_rpt
        '
        Me.DefaultPaperSize = False
        Me.MarginBottom = 0.25!
        Me.MarginLeft = 0.25!
        Me.MarginRight = 0.25!
        Me.MarginTop = 0.25!
        Me.Orientation = dbAutoTrack.DataReports.PageOrientation.Landscape
        Me.PaperKind = System.Drawing.Printing.PaperKind.Letter
        Me.ReportWidth = 1030.0!
        Me.Sections.AddRange(New dbAutoTrack.DataReports.Section() {Me.ReportHeader, Me.PageHeader, Me.GroupHeader1, Me.Detail, Me.GroupFooter1, Me.PageFooter, Me.ReportFooter})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
    Dim pageno As Integer = 0
    Private Sub PageFooter_Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Initialize
        Me.pageno = Me.pageno + 1
        Me.pg_num.Text = String.Format("Page: {0}", pageno) & "/" & String.Format(Me.MaxPages)

    End Sub
End Class


