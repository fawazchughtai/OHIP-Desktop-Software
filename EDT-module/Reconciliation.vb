Imports System.IO
Imports System.Drawing
Public Class Reconciliation

    Private Sub Reconciliation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        ReconciliationDataGrid.Columns.Add("filename", "Un-Reconciled Files")
        ReconciliationDataGrid.Columns("filename").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ReconciliationDataGrid.RowHeadersVisible = False
        ReconciliationDataGrid.Rows.Clear()
        ReconciliationDataGrid.ReadOnly = True
        ReconciliationDataGrid.AllowUserToAddRows = False
        ReconciliationDataGrid.BackgroundColor = Color.LightGray
        ReconciliationDataGrid.BorderStyle = BorderStyle.Fixed3D
        ReconciliationDataGrid.AllowUserToAddRows = False
        ReconciliationDataGrid.AllowUserToDeleteRows = False
        ReconciliationDataGrid.AllowUserToOrderColumns = True
        ReconciliationDataGrid.ReadOnly = True
        ReconciliationDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ReconciliationDataGrid.MultiSelect = False
        ReconciliationDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        ReconciliationDataGrid.AllowUserToResizeColumns = False
        ReconciliationDataGrid.AllowUserToResizeRows = False
        ReconciliationDataGrid.DefaultCellStyle.SelectionBackColor = Color.White
        ReconciliationDataGrid.DefaultCellStyle.SelectionForeColor = Color.Black
        ReconciliationDataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        show_files()

       

    End Sub

 


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub


    Private Sub show_files()
        If strReturnFileFolder = vbNullString Then
            strReturnFileFolder = currPath & "\InputFiles\"
        End If

        Dim dir As New DirectoryInfo(strReturnFileFolder)
        Dim i As Integer = 0

        For Each f As FileInfo In dir.GetFiles("P*.*")
            ReconciliationDataGrid.Rows.Add()
            ReconciliationDataGrid.Rows(i).Cells("filename").Value = f.Name
            i = i + 1
        Next f

        Dim btn As New DataGridViewButtonColumn()
        btn.HeaderText = ""
        btn.Text = "Process Now"
        btn.Name = "Processbtn"
        btn.UseColumnTextForButtonValue = True
        If ReconciliationDataGrid.ColumnCount = 1 Then
            ReconciliationDataGrid.Columns.Add(btn)
        End If
    End Sub

    Private Sub ReconciliationDataGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReconciliationDataGrid.CellClick
        Try
            ProcessingProgressBar.Visible = True
            ProcessingProgressBar.Style = ProgressBarStyle.Marquee
            ProcessingProgressBar.MarqueeAnimationSpeed = 50

            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()
            If strReturnFileFolder = vbNullString Then
                strReturnFileFolder = currPath & "\InputFiles\"
            End If
            Dim ProcessFile As String
            Dim objReconciliation As New ReconciliationClass
            objReconciliation.ImportPath = strReturnFileFolder
            If e.ColumnIndex = 1 Then
                ProcessFile = sender.Rows(e.RowIndex).Cells("filename").Value
                objReconciliation.Process(ProcessFile)
            End If
            ProcessingProgressBar.Visible = False
            Me.Cursor = Cursors.Arrow

           
            show_files()

        Catch ex As Exception

        End Try
    End Sub

End Class