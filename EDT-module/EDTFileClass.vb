Imports System.IO
Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class EDTFileClass
    'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
    'Private myCommand As New System.Data.OleDb.OleDbCommand
    'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
    'Private myData As DataSet = New DataSet
    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
    Private myCommand As New MySqlCommand
    Private myAdapter As MySqlDataAdapter
    Private myData As DataSet = New DataSet
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objDataAdapter As MySqlDataAdapter


    Public Sub GetBatchReportFileList()

        OOFSL_main.BatchReportToolStripMenuItem.DropDownItems.Clear()
        If strReturnFileFolder = vbNullString Then
            strReturnFileFolder = currPath & "\InputFiles\"
        End If

        Dim objBatchReportData As New BatchReportRecord
        Dim dir As New DirectoryInfo(strReturnFileFolder)
        For Each f As FileInfo In dir.GetFiles("B*.*")
            objBatchReportData.ProcessBatchFiles(f.Name)

        Next f

        If BatchReport.BatchReportDataGrid.ColumnCount = 0 Then

            BatchReport.BatchReportDataGrid.Columns.Add("EditMessate", "Message")
            BatchReport.BatchReportDataGrid.Columns.Add("BatchCreatedDate", "Batch Created Date")
            BatchReport.BatchReportDataGrid.Columns.Add("BatchProcessDate", "Batch Process Date")
            BatchReport.BatchReportDataGrid.Columns.Add("NumberOfClaims", "Number Of Claims")
            'BatchReport.BatchReportDataGrid.Columns.Add("NumberOfRecords", "Number Of Records")
            'BatchReport.BatchReportDataGrid.Columns.Add("BatchNumber", "Batch Number")
            'BatchReport.BatchReportDataGrid.Columns.Add("OperationNumber", "Operation Number")
            'BatchReport.BatchReportDataGrid.Columns.Add("BatchSequence", "Batch Sequence")
            'BatchReport.BatchReportDataGrid.Columns.Add("MicroStart", "Micro Start")
            'BatchReport.BatchReportDataGrid.Columns.Add("MicroEnd", "Micro End")
            'BatchReport.BatchReportDataGrid.Columns.Add("MicroType", "Micro Type")
            'BatchReport.BatchReportDataGrid.Columns.Add("GroupNumber", "Group Number")
            'BatchReport.BatchReportDataGrid.Columns.Add("ProviderNumber", "Provider Number")

            BatchReport.BatchReportDataGrid.Columns("EditMessate").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            BatchReport.BatchReportDataGrid.Columns("BatchCreatedDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            BatchReport.BatchReportDataGrid.Columns("BatchProcessDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            BatchReport.BatchReportDataGrid.Columns("NumberOfClaims").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'BatchReport.BatchReportDataGrid.Columns("BatchNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("OperationNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("BatchSequence").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("MicroStart").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("MicroEnd").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("MicroType").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("GroupNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("ProviderNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("NumberOfClaims").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("NumberOfRecords").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("BatchProcessDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'BatchReport.BatchReportDataGrid.Columns("EditMessate").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        End If

        objBatchReportData.GetReportData()
        BatchReport.MdiParent = OOFSL_main
        BatchReport.Show()

    End Sub

    Public NotInheritable Class BatchReportRecord
        Public Property TransactionIdentifier As String
        Public Property RecordIdentifier As String
        Public Property TechSpecReleaseIdentifier As String
        Public Property BatchNumber As String
        Public Property OperatorNumber As String
        Public Property BatchCreatedDate As String
        Public Property BatchSequenceNumber As String
        Public Property MicroStart As String
        Public Property MicroEnd As String
        Public Property MicroType As String
        Public Property GroupNumber As String
        Public Property ProviderNumber As String
        Public Property NumberOfClaims As String
        Public Property NumberOfRecords As String
        Public Property BatchProcessDate As String
        Public Property EditMessage As String
        Public Property ReservedForMOHUse As String

        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter

        Public Sub GetReportData()
            Dim sql As String
            Dim objBatchReportDataset As New DataSet

            sql = "Select "
            sql = sql & "TransID,"
            sql = sql & "RecID,"
            sql = sql & "TecSpecReleaseID,"
            sql = sql & "BatchNumber,"
            sql = sql & "OperationNumber,"
            sql = sql & "BatchCreatedDate,"
            sql = sql & "BatchSequence,"
            sql = sql & "MicroStart,"
            sql = sql & "MicroEnd,"
            sql = sql & "MicroType,"
            sql = sql & "GroupNumber,"
            sql = sql & "ProviderNumber,"
            sql = sql & "NumberOfClaims,"
            sql = sql & "NumberOfRecords,"
            sql = sql & "BatchProcessDate,"
            sql = sql & "EditMessate,"
            sql = sql & "MOHUse "
            sql = sql & "from batchedtreport "
            sql = sql & "order by BatchCreatedDate "

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objBatchReportDataset, "tblBatchItem")

            BatchReport.BatchReportDataGrid.Rows.Clear()
            BatchReport.BatchReportDataGrid.ReadOnly = True
            BatchReport.BatchReportDataGrid.AllowUserToAddRows = False
            BatchReport.BatchReportDataGrid.BackgroundColor = Color.LightGray
            BatchReport.BatchReportDataGrid.BorderStyle = BorderStyle.Fixed3D
            BatchReport.BatchReportDataGrid.AllowUserToAddRows = False
            BatchReport.BatchReportDataGrid.AllowUserToDeleteRows = False
            BatchReport.BatchReportDataGrid.AllowUserToOrderColumns = True
            BatchReport.BatchReportDataGrid.ReadOnly = True
            BatchReport.BatchReportDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            BatchReport.BatchReportDataGrid.MultiSelect = False
            BatchReport.BatchReportDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            BatchReport.BatchReportDataGrid.AllowUserToResizeColumns = True
            BatchReport.BatchReportDataGrid.AllowUserToResizeRows = False
            BatchReport.BatchReportDataGrid.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            BatchReport.BatchReportDataGrid.DefaultCellStyle.SelectionForeColor = Color.Black
            BatchReport.BatchReportDataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

            Dim i As Integer
            Dim BatchProcessDate As DateTime
            Dim BatchCreatedDate As DateTime
            Dim iyear As Integer
            Dim imonth As Integer
            Dim iday As Integer

            For i = 0 To objBatchReportDataset.Tables("tblBatchItem").Rows.Count - 1


                iyear = System.Convert.ToInt32(objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("BatchCreatedDate").Substring(0, 4))
                imonth = System.Convert.ToInt32(objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("BatchCreatedDate").Substring(4, 2))
                iday = System.Convert.ToInt32(objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("BatchCreatedDate").Substring(6, 2))
                BatchCreatedDate = New DateTime(iyear, imonth, iday)

                iyear = System.Convert.ToInt32(objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("BatchProcessDate").Substring(0, 4))
                imonth = System.Convert.ToInt32(objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("BatchProcessDate").Substring(4, 2))
                iday = System.Convert.ToInt32(objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("BatchProcessDate").Substring(6, 2))
                BatchProcessDate = New DateTime(iyear, imonth, iday)

                BatchReport.BatchReportDataGrid.Rows.Add()
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("BatchNumber").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("BatchNumber")
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("OperationNumber").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("OperationNumber")
                BatchReport.BatchReportDataGrid.Rows(i).Cells("BatchCreatedDate").Value = BatchCreatedDate.ToString("d", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("BatchSequence").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("BatchSequence")
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("MicroStart").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("MicroStart")
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("MicroEnd").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("MicroEnd")
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("MicroType").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("MicroType")
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("GroupNumber").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("GroupNumber")
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("ProviderNumber").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("ProviderNumber")
                BatchReport.BatchReportDataGrid.Rows(i).Cells("NumberOfClaims").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("NumberOfClaims")
                'BatchReport.BatchReportDataGrid.Rows(i).Cells("NumberOfRecords").Value = objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("NumberOfRecords")
                BatchReport.BatchReportDataGrid.Rows(i).Cells("BatchProcessDate").Value = BatchProcessDate.ToString("d", System.Globalization.DateTimeFormatInfo.InvariantInfo)

                If objBatchReportDataset.Tables("tblBatchItem").Rows(i).Item("EditMessate") = "     ***  BATCH TOTALS  ***             " Then
                    BatchReport.BatchReportDataGrid.Rows(i).Cells("EditMessate").Value = " Batch Accepted"
                Else
                    BatchReport.BatchReportDataGrid.Rows(i).Cells("EditMessate").Value = " Batch Rejected"
                End If
            Next
            BatchReport.BatchReportDataGrid.ReadOnly = True
            BatchReport.BatchReportDataGrid.AllowUserToAddRows = False
        End Sub

        Public Sub ProcessBatchFiles(ByVal filename As String)

            Try
                Dim TextLine As String
                Dim ImportRecordType As String
                Dim processPath As String
                Dim provider As System.Globalization.CultureInfo = System.Globalization.CultureInfo.InvariantCulture
                processPath = strReturnFileFolder & "Batch-Report-Processed-" & Today().ToString("MM/dd/yyyy", provider)
                processPath = processPath.Replace("/", "-")

                If System.IO.File.Exists(strReturnFileFolder & filename) = True Then
                    Dim objReader As New System.IO.StreamReader(strReturnFileFolder & filename)
                    Do While objReader.Peek() <> -1
                        Application.DoEvents()
                        TextLine = objReader.ReadLine()
                        If TextLine.Length >= 3 Then
                            ImportRecordType = TextLine.Substring(0, 3)

                            Select Case ImportRecordType
                                Case "HB1"
                                    Me.TransactionIdentifier = TextLine.Substring(0, 2)
                                    Me.RecordIdentifier = TextLine.Substring(2, 1)
                                    Me.TechSpecReleaseIdentifier = TextLine.Substring(3, 3)
                                    Me.BatchNumber = TextLine.Substring(6, 5)
                                    Me.OperatorNumber = TextLine.Substring(11, 6)
                                    Me.BatchCreatedDate = TextLine.Substring(17, 8)
                                    Me.BatchSequenceNumber = TextLine.Substring(25, 4)
                                    Me.MicroStart = TextLine.Substring(29, 11)
                                    Me.MicroEnd = TextLine.Substring(40, 5)
                                    Me.MicroType = TextLine.Substring(45, 7)
                                    Me.GroupNumber = TextLine.Substring(53, 4)
                                    Me.ProviderNumber = TextLine.Substring(56, 6)
                                    Me.NumberOfClaims = TextLine.Substring(62, 5)
                                    Me.NumberOfRecords = TextLine.Substring(67, 6)
                                    Me.BatchProcessDate = TextLine.Substring(73, 8)
                                    Me.EditMessage = TextLine.Substring(81, 40)
                                    Me.ReservedForMOHUse = TextLine.Substring(121, 11)
                                    Me.Save(filename)

                            End Select
                        End If
                    Loop
                    objReader.Close()
                    If Not System.IO.Directory.Exists(processPath) Then
                        System.IO.Directory.CreateDirectory(processPath)
                    End If
                    Dim FileToCopy As String
                    Dim NewCopy As String

                    FileToCopy = strReturnFileFolder & filename
                    NewCopy = processPath & "\" & filename

                    If System.IO.File.Exists(FileToCopy) = True Then
                        System.IO.File.Copy(FileToCopy, NewCopy, True)
                        System.IO.File.Delete(FileToCopy)
                    End If

                Else
                    MsgBox("File Does Not Exist")
                End If

            Catch ex As Exception

            End Try
        End Sub

        Public Sub Save(ByVal filename As String)
            Dim sql As String
            Dim objDataset As New DataSet
            Try
                objConn.Open()
                sql = "Insert into batchedtreport"
                sql = sql & " ("
                sql = sql & "TransID,"
                sql = sql & "RecID,"
                sql = sql & "TecSpecReleaseID,"
                sql = sql & "BatchNumber,"
                sql = sql & "OperationNumber,"
                sql = sql & "BatchCreatedDate,"
                sql = sql & "BatchSequence,"
                sql = sql & "MicroStart,"
                sql = sql & "MicroEnd,"
                sql = sql & "MicroType,"
                sql = sql & "GroupNumber,"
                sql = sql & "ProviderNumber,"
                sql = sql & "NumberOfClaims,"
                sql = sql & "NumberOfRecords,"
                sql = sql & "BatchProcessDate,"
                sql = sql & "EditMessate,"
                sql = sql & "MOHUse"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & TransactionIdentifier & "',"
                sql = sql & "'" & RecordIdentifier & "',"
                sql = sql & "'" & TechSpecReleaseIdentifier & "',"
                sql = sql & "'" & BatchNumber & "',"
                sql = sql & "'" & OperatorNumber & "',"
                sql = sql & "'" & BatchCreatedDate & "',"
                sql = sql & "'" & BatchSequenceNumber & "',"
                sql = sql & "'" & MicroStart & "',"
                sql = sql & "'" & MicroEnd & "',"
                sql = sql & "'" & MicroType & "',"
                sql = sql & "'" & GroupNumber & "',"
                sql = sql & "'" & ProviderNumber & "',"
                sql = sql & "'" & NumberOfClaims & "',"
                sql = sql & "'" & NumberOfRecords & "',"
                sql = sql & "'" & BatchProcessDate & "',"
                sql = sql & "'" & EditMessage & "',"
                sql = sql & "'" & ReservedForMOHUse & "'"
                sql = sql & ")"

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                objConn.Close()

            Catch ex As Exception
                objConn.Close()
            End Try
        End Sub


    End Class

    Public Sub GetErrorReportFileList()

        OOFSL_main.BatchReportToolStripMenuItem.DropDownItems.Clear()
        If strReturnFileFolder = vbNullString Then
            strReturnFileFolder = currPath & "\InputFiles\"
        End If

        Dim objErrorReportData As New ErrorReportRecord
        Dim dir As New DirectoryInfo(strReturnFileFolder)
        For Each f As FileInfo In dir.GetFiles("E*.*")
            objErrorReportData.ProcessErrorFiles(f.Name)
        Next f

        If ErrorReport.ErrorReportDataGrid.ColumnCount = 0 Then
            ErrorReport.ErrorReportDataGrid.Columns.Add("ID", "ID")
            ErrorReport.ErrorReportDataGrid.Columns.Add("ClaimProcessDate", "Batch Process Date")
            ErrorReport.ErrorReportDataGrid.Columns("ClaimProcessDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        Dim sql As String
        Dim objErrorReportDataset As New DataSet

        sql = "Select distinct "
        sql = sql & "ErrorReportID,ClaimProcessDate"
        sql = sql & " from errorreporthx1 "
        sql = sql & "order by ClaimProcessDate desc"

        'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
        objDataAdapter = New MySqlDataAdapter(sql, objConn)
        objDataAdapter.Fill(objErrorReportDataset, "tblErrorItem")

        ErrorReport.ErrorReportDataGrid.Rows.Clear()
        ErrorReport.ErrorReportDataGrid.ReadOnly = True
        ErrorReport.ErrorReportDataGrid.AllowUserToAddRows = False
        ErrorReport.ErrorReportDataGrid.BackgroundColor = Color.LightGray
        ErrorReport.ErrorReportDataGrid.BorderStyle = BorderStyle.Fixed3D
        ErrorReport.ErrorReportDataGrid.AllowUserToAddRows = False
        ErrorReport.ErrorReportDataGrid.AllowUserToDeleteRows = False
        ErrorReport.ErrorReportDataGrid.AllowUserToOrderColumns = True
        ErrorReport.ErrorReportDataGrid.ReadOnly = True
        ErrorReport.ErrorReportDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ErrorReport.ErrorReportDataGrid.MultiSelect = False
        ErrorReport.ErrorReportDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        ErrorReport.ErrorReportDataGrid.AllowUserToResizeColumns = True
        ErrorReport.ErrorReportDataGrid.AllowUserToResizeRows = False
        ErrorReport.ErrorReportDataGrid.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        ErrorReport.ErrorReportDataGrid.DefaultCellStyle.SelectionForeColor = Color.Black
        ErrorReport.ErrorReportDataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        Dim i As Integer
        Dim BatchProcessDate As DateTime
        Dim iyear As Integer
        Dim imonth As Integer
        Dim iday As Integer

        For i = 0 To objErrorReportDataset.Tables("tblErrorItem").Rows.Count - 1

            iyear = System.Convert.ToInt32(objErrorReportDataset.Tables("tblErrorItem").Rows(i).Item("ClaimProcessDate").Substring(0, 4))
            imonth = System.Convert.ToInt32(objErrorReportDataset.Tables("tblErrorItem").Rows(i).Item("ClaimProcessDate").Substring(4, 2))
            iday = System.Convert.ToInt32(objErrorReportDataset.Tables("tblErrorItem").Rows(i).Item("ClaimProcessDate").Substring(6, 2))
            BatchProcessDate = New DateTime(iyear, imonth, iday)

            ErrorReport.ErrorReportDataGrid.Rows.Add()
            ErrorReport.ErrorReportDataGrid.Rows(i).Cells("ID").Value = objErrorReportDataset.Tables("tblErrorItem").Rows(i).Item("ErrorReportID")
            ErrorReport.ErrorReportDataGrid.Rows(i).Cells("ClaimProcessDate").Value = BatchProcessDate.ToString("d", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Next
        ErrorReport.ErrorReportDataGrid.Columns("ID").Visible = False

        Dim btn As New DataGridViewButtonColumn()
        If ErrorReport.ErrorReportDataGrid.ColumnCount = 2 Then
            ErrorReport.ErrorReportDataGrid.Columns.Add(btn)
        End If
        btn.HeaderText = " "
        btn.Text = "View Report"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
        ErrorReport.ErrorReportDataGrid.ReadOnly = True
        ErrorReport.ErrorReportDataGrid.AllowUserToAddRows = False

        '    objErrorReportData.GetReportData()
        ErrorReport.MdiParent = OOFSL_main
        ErrorReport.Show()


    End Sub

    Public NotInheritable Class ErrorReportRecord
        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter

        Public Sub ProcessErrorFiles(ByVal filename As String)

            Try
                Dim TextLine As String
                Dim ImportRecordType As String
                Dim processPath As String
                Dim provider As System.Globalization.CultureInfo = System.Globalization.CultureInfo.InvariantCulture
                Dim ErrorReportID As Integer
                Dim ErrorReportHeaderID As Integer
                processPath = strReturnFileFolder & "Error-Report-Processed-" & Today().ToString("MM/dd/yyyy", provider)
                processPath = processPath.Replace("/", "-")

                If System.IO.File.Exists(strReturnFileFolder & filename) = True Then
                    Dim objReader As New System.IO.StreamReader(strReturnFileFolder & filename)
                    Do While objReader.Peek() <> -1
                        Application.DoEvents()
                        TextLine = objReader.ReadLine()
                        ImportRecordType = TextLine.Substring(0, 3)
                        Select Case ImportRecordType
                            Case "HX1"
                                Dim objHX1 As New ErrorReportHX1
                                objHX1.TransactionIdentifier = TextLine.Substring(0, 2)
                                objHX1.RecordId = TextLine.Substring(2, 1)
                                objHX1.TechSpecRelease = TextLine.Substring(3, 3)
                                objHX1.MOHOfficeCode = TextLine.Substring(6, 1)
                                objHX1.ReservedForMOH = TextLine.Substring(7, 10)
                                objHX1.OperatorNumber = TextLine.Substring(17, 6)
                                objHX1.GroupNumber = TextLine.Substring(23, 4)
                                objHX1.ProviderNumber = TextLine.Substring(27, 6)
                                objHX1.SpecialtyCode = TextLine.Substring(33, 2)
                                objHX1.StationNumber = TextLine.Substring(35, 3)
                                objHX1.ClaimProcessDate = TextLine.Substring(38, 8)
                                objHX1.ReservedForMOH2 = TextLine.Substring(46, 33)
                                objHX1.save()
                                ErrorReportID = objHX1.ErrorReportID
                            Case "HXH"
                                Dim objHXH As New ErrorReportHXH
                                objHXH.ErrorReportID = ErrorReportID
                                objHXH.TransactionIdentifier = TextLine.Substring(0, 2)
                                objHXH.RecordId = TextLine.Substring(2, 1)
                                objHXH.HealthNumber = TextLine.Substring(3, 10)
                                objHXH.VersionCode = TextLine.Substring(13, 2)
                                objHXH.PatientBirthDate = TextLine.Substring(15, 8)
                                objHXH.AccountingNumber = TextLine.Substring(23, 8)
                                objHXH.PaymentProgram = TextLine.Substring(31, 3)
                                objHXH.Payee = TextLine.Substring(34, 1)
                                objHXH.ReferringProviderNumber = TextLine.Substring(35, 6)
                                objHXH.MasterNumber = TextLine.Substring(41, 4)
                                objHXH.PatientAdmissionDate = TextLine.Substring(45, 8)
                                objHXH.ReferringLabLicence = TextLine.Substring(53, 4)
                                objHXH.ServiceLocationIndicator = TextLine.Substring(57, 4)
                                objHXH.ReservedForMOH = TextLine.Substring(61, 3)
                                objHXH.ErrorCode1 = TextLine.Substring(64, 3)
                                objHXH.ErrorCode2 = TextLine.Substring(67, 3)
                                objHXH.ErrorCode3 = TextLine.Substring(70, 3)
                                objHXH.ErrorCode4 = TextLine.Substring(73, 3)
                                objHXH.ErrorCode5 = TextLine.Substring(76, 3)
                                ErrorReportHeaderID = objHXH.save()
                            Case "HXR"
                                Dim objHXR As New ErrorReportHXR
                                objHXR.ErrorReportID = ErrorReportID
                                objHXR.TransactionIdentifier = TextLine.Substring(0, 2)
                                objHXR.RecordId = TextLine.Substring(2, 1)
                                objHXR.RegistrationNumber = TextLine.Substring(3, 12)
                                objHXR.PatientsLastName = TextLine.Substring(15, 9)
                                objHXR.PatientsFirstName = TextLine.Substring(24, 5)
                                objHXR.PatientsSex = TextLine.Substring(29, 1)
                                objHXR.ProvinceCode = TextLine.Substring(30, 2)
                                objHXR.ReservedForMOH = TextLine.Substring(32, 32)
                                objHXR.ErrorCode1 = TextLine.Substring(64, 3)
                                objHXR.ErrorCode2 = TextLine.Substring(67, 3)
                                objHXR.ErrorCode3 = TextLine.Substring(70, 3)
                                objHXR.ErrorCode4 = TextLine.Substring(73, 3)
                                objHXR.ErrorCode5 = TextLine.Substring(76, 3)
                                ErrorReportHeaderID = objHXR.save()
                            Case "HXT"
                                Dim objHXT As New ErrorReportHXT
                                objHXT.ErrorReportID = ErrorReportID
                                objHXT.ErrorReportHeaderID = ErrorReportHeaderID
                                objHXT.TransactionIdentifier = TextLine.Substring(0, 2)
                                objHXT.RecordId = TextLine.Substring(2, 1)
                                objHXT.ServiceCode = TextLine.Substring(3, 5)
                                objHXT.ReservedForMOH = TextLine.Substring(8, 2)
                                objHXT.FeeSubmitted = TextLine.Substring(10, 6)
                                objHXT.NumberOfServices = TextLine.Substring(16, 2)
                                objHXT.ServiceDate = TextLine.Substring(18, 8)
                                objHXT.DiagnosticCode = TextLine.Substring(26, 4)
                                objHXT.ReservedForMOH2 = TextLine.Substring(30, 32)
                                objHXT.ExplanCode = TextLine.Substring(62, 2)
                                objHXT.ErrorCode1 = TextLine.Substring(64, 3)
                                objHXT.ErrorCode2 = TextLine.Substring(68, 3)
                                objHXT.ErrorCode3 = TextLine.Substring(70, 3)
                                objHXT.ErrorCode4 = TextLine.Substring(73, 3)
                                objHXT.ErrorCode5 = TextLine.Substring(76, 3)
                                objHXT.Save()
                            Case "HX8"
                                Dim objHX8 As New ErrorReportHX8
                                objHX8.ErrorReportID = ErrorReportID
                                objHX8.TransactionIdentifier = TextLine.Substring(0, 2)
                                objHX8.RecordID = TextLine.Substring(2, 1)
                                objHX8.ExplanCode = TextLine.Substring(3, 2)
                                objHX8.ExplanDescription = TextLine.Substring(5, 55)
                                objHX8.ReservedForMOH = TextLine.Substring(60, 19)
                                objHX8.Save()
                            Case "HX9"
                                Dim objHX9 As New ErrorReportHX9
                                objHX9.ErrorReportID = ErrorReportID
                                objHX9.TransactionIdentifier = TextLine.Substring(0, 2)
                                objHX9.RecordID = TextLine.Substring(2, 1)
                                objHX9.Header1Count = TextLine.Substring(3, 7)
                                objHX9.Header2Count = TextLine.Substring(10, 7)
                                objHX9.ItemCount = TextLine.Substring(17, 7)
                                objHX9.MessageCount = TextLine.Substring(24, 7)
                                objHX9.ReservedForMOH = TextLine.Substring(31, 48)
                                objHX9.Save()
                        End Select
                    Loop
                    objReader.Close()
                    If Not System.IO.Directory.Exists(processPath) Then
                        System.IO.Directory.CreateDirectory(processPath)
                    End If
                    Dim FileToCopy As String
                    Dim NewCopy As String

                    FileToCopy = strReturnFileFolder & filename
                    NewCopy = processPath & "\" & filename

                    If System.IO.File.Exists(FileToCopy) = True Then
                        System.IO.File.Copy(FileToCopy, NewCopy, True)
                        System.IO.File.Delete(FileToCopy)
                    End If

                Else
                    MsgBox("File Does Not Exist")
                End If

            Catch ex As Exception

            End Try

        End Sub
    End Class
    Public NotInheritable Class ErrorReportHX1
        Public Property ErrorReportID As Integer
        Public Property TransactionIdentifier As String
        Public Property RecordId As String
        Public Property TechSpecRelease As String
        Public Property MOHOfficeCode As String
        Public Property ReservedForMOH As String
        Public Property OperatorNumber As String
        Public Property GroupNumber As String
        Public Property ProviderNumber As String
        Public Property SpecialtyCode As String
        Public Property StationNumber As String
        Public Property ClaimProcessDate As String
        Public Property ReservedForMOH2 As String
        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter
        Public Sub save()
            Dim sql As String
            Dim objDataset As New DataSet
            Try
                objConn.Open()
                sql = "Insert into ErrorReportHX1"
                sql = sql & " ("
                sql = sql & "TransactionID,"
                sql = sql & "RecordId,"
                sql = sql & "TechSpecRelease,"
                sql = sql & "MOHOfficeCode,"
                sql = sql & "ReservedForMOH,"
                sql = sql & "OperatorNumber,"
                sql = sql & "GroupNumber,"
                sql = sql & "ProviderNumber,"
                sql = sql & "SpecialtyCode,"
                sql = sql & "StationNumber,"
                sql = sql & "ClaimProcessDate,"
                sql = sql & "ReservedForMOH2"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & TransactionIdentifier & "',"
                sql = sql & "'" & RecordId & "',"
                sql = sql & "'" & TechSpecRelease & "',"
                sql = sql & "'" & MOHOfficeCode & "',"
                sql = sql & "'" & ReservedForMOH & "',"
                sql = sql & "'" & OperatorNumber & "',"
                sql = sql & "'" & GroupNumber & "',"
                sql = sql & "'" & ProviderNumber & "',"
                sql = sql & "'" & SpecialtyCode & "',"
                sql = sql & "'" & StationNumber & "',"
                sql = sql & "'" & ClaimProcessDate & "',"
                sql = sql & "'" & ReservedForMOH2 & "'"
                sql = sql & ")"

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                sql = "select MAX(ErrorReportID) from ErrorReportHX1"
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                Dim id As Integer
                id = myCommand.ExecuteScalar()
                objConn.Close()
                ErrorReportID = id

            Catch ex As Exception

                objConn.Close()
            End Try
        End Sub

    End Class
    Public NotInheritable Class ErrorReportHXH
        Public Property ErrorReportID As Integer
        Public Property ErrorReportHeaderID As Integer
        Public Property TransactionIdentifier As String
        Public Property RecordId As String
        Public Property HealthNumber As String
        Public Property VersionCode As String
        Public Property PatientBirthDate As String
        Public Property AccountingNumber As String
        Public Property PaymentProgram As String
        Public Property Payee As String
        Public Property ReferringProviderNumber As String
        Public Property MasterNumber As String
        Public Property PatientAdmissionDate As String
        Public Property ReferringLabLicence As String
        Public Property ServiceLocationIndicator As String
        Public Property ReservedForMOH As String
        Public Property ErrorCode1 As String
        Public Property ErrorCode2 As String
        Public Property ErrorCode3 As String
        Public Property ErrorCode4 As String
        Public Property ErrorCode5 As String
        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter

        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter
        Public Function save() As Integer
            Dim sql As String
            Dim objDataset As New DataSet
            Try
                objConn.Open()
                sql = "Insert into ErrorReportHXH"
                sql = sql & " ("
                sql = sql & "ErrorReportID,"
                sql = sql & "TransactionID,"
                sql = sql & "RecordID,"
                sql = sql & "HealthNumber,"
                sql = sql & "VersionCode,"
                sql = sql & "PatientBirthDate,"
                sql = sql & "AccountingNumber,"
                sql = sql & "PaymentProgram,"
                sql = sql & "Payee,"
                sql = sql & "ReferringProviderNumber,"
                sql = sql & "MasterNumber,"
                sql = sql & "PatientAdmissionDate,"
                sql = sql & "ReferringLabLicence,"
                sql = sql & "ServiceLocationIndicator,"
                sql = sql & "ReservedForMOH,"
                sql = sql & "ErrorCode1,"
                sql = sql & "ErrorCode2,"
                sql = sql & "ErrorCode3,"
                sql = sql & "ErrorCode4,"
                sql = sql & "ErrorCode5"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & ErrorReportID & "',"
                sql = sql & "'" & TransactionIdentifier & "',"
                sql = sql & "'" & RecordId & "',"
                sql = sql & "'" & HealthNumber & "',"
                sql = sql & "'" & VersionCode & "',"
                sql = sql & "'" & PatientBirthDate & "',"
                sql = sql & "'" & AccountingNumber & "',"
                sql = sql & "'" & PaymentProgram & "',"
                sql = sql & "'" & Payee & "',"
                sql = sql & "'" & ReferringProviderNumber & "',"
                sql = sql & "'" & MasterNumber & "',"
                sql = sql & "'" & PatientAdmissionDate & "',"
                sql = sql & "'" & ReferringLabLicence & "',"
                sql = sql & "'" & ServiceLocationIndicator & "',"
                sql = sql & "'" & ReservedForMOH & "',"
                sql = sql & "'" & ErrorCode1 & "',"
                sql = sql & "'" & ErrorCode2 & "',"
                sql = sql & "'" & ErrorCode3 & "',"
                sql = sql & "'" & ErrorCode4 & "',"
                sql = sql & "'" & ErrorCode5 & "'"
                sql = sql & ")"

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                sql = "select MAX(HeaderID) from ErrorReportHXH"
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)

                Dim id As Integer
                id = myCommand.ExecuteScalar()
                objConn.Close()
                ErrorReportHeaderID = id

                objConn.Close()

                Return ErrorReportHeaderID

            Catch ex As Exception
                objConn.Close()
                Return 0
            End Try
        End Function

    End Class
    Public NotInheritable Class ErrorReportHXR
        Public Property ErrorReportID As Integer
        Public Property ErrorReportHeaderID As Integer
        Public Property TransactionIdentifier As String
        Public Property RecordId As String
        Public Property RegistrationNumber As String
        Public Property PatientsLastName As String
        Public Property PatientsFirstName As String
        Public Property PatientsSex As String
        Public Property ProvinceCode As String
        Public Property ReservedForMOH As String
        Public Property ErrorCode1 As String
        Public Property ErrorCode2 As String
        Public Property ErrorCode3 As String
        Public Property ErrorCode4 As String
        Public Property ErrorCode5 As String
        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter
        Public Function save() As Integer
            Dim sql As String
            Dim objDataset As New DataSet
            Try
                objConn.Open()
                sql = "Insert into ErrorReportHX1"
                sql = sql & " ("
                sql = sql & "ErrorReportID,"
                sql = sql & "TransactionID,"
                sql = sql & "RecordID,"
                sql = sql & "RetistrationNumber,"
                sql = sql & "PatientsLastName,"
                sql = sql & "PatientsFirstName,"
                sql = sql & "PatientsSex,"
                sql = sql & "ReservedForMOH,"
                sql = sql & "ErrorCode1,"
                sql = sql & "ErrorCode2,"
                sql = sql & "ErrorCode3,"
                sql = sql & "ErrorCode4,"
                sql = sql & "ErrorCode5"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & ErrorReportID & "',"
                sql = sql & "'" & TransactionIdentifier & "',"
                sql = sql & "'" & RecordId & "',"
                sql = sql & "'" & RegistrationNumber & "',"
                sql = sql & "'" & PatientsLastName & "',"
                sql = sql & "'" & PatientsFirstName & "',"
                sql = sql & "'" & PatientsSex & "',"
                sql = sql & "'" & ProvinceCode & "',"
                sql = sql & "'" & ReservedForMOH & "',"
                sql = sql & "'" & ErrorCode1 & "',"
                sql = sql & "'" & ErrorCode2 & "',"
                sql = sql & "'" & ErrorCode3 & "',"
                sql = sql & "'" & ErrorCode4 & "',"
                sql = sql & "'" & ErrorCode5 & "'"
                sql = sql & ")"

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                sql = "select MAX(HeaderID) from ErrorReportHXT"
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                Dim id As Integer
                id = myCommand.ExecuteScalar()
                objConn.Close()
                ErrorReportHeaderID = id

                objConn.Close()

                Return ErrorReportHeaderID

            Catch ex As Exception
                Return 0
                objConn.Close()
            End Try
        End Function
    End Class
    Public NotInheritable Class ErrorReportHXT
        Public Property ErrorReportID As Integer
        Public Property ErrorReportHeaderID As Integer
        Public Property TransactionIdentifier As String
        Public Property RecordId As String
        Public Property ServiceCode As String
        Public Property ReservedForMOH As String
        Public Property FeeSubmitted As String
        Public Property NumberOfServices As String
        Public Property ServiceDate As String
        Public Property DiagnosticCode As String
        Public Property ReservedForMOH2 As String
        Public Property ExplanCode As String
        Public Property ErrorCode1 As String
        Public Property ErrorCode2 As String
        Public Property ErrorCode3 As String
        Public Property ErrorCode4 As String
        Public Property ErrorCode5 As String
        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter

        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter

        Public Sub save()
            Dim sql As String
            Dim objDataset As New DataSet
            Try
                objConn.Open()
                sql = "Insert into ErrorReportHXT"
                sql = sql & " ("
                sql = sql & "ErrorReportID,"
                sql = sql & "HeaderID,"
                sql = sql & "TransactionID,"
                sql = sql & "RecordID,"
                sql = sql & "ServiceCode,"
                sql = sql & "ReservedForMOH,"
                sql = sql & "FeeSubmitted,"
                sql = sql & "NumberOfServices,"
                sql = sql & "ServiceDate,"
                sql = sql & "DiagnosticCode,"
                sql = sql & "ReservedForMOH2,"
                sql = sql & "ExplanCode,"
                sql = sql & "ErrorCode1,"
                sql = sql & "ErrorCode2,"
                sql = sql & "ErrorCode3,"
                sql = sql & "ErrorCode4,"
                sql = sql & "ErrorCode5"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & ErrorReportID & "',"
                sql = sql & "'" & ErrorReportHeaderID & "',"
                sql = sql & "'" & TransactionIdentifier & "',"
                sql = sql & "'" & RecordId & "',"
                sql = sql & "'" & ServiceCode & "',"
                sql = sql & "'" & ReservedForMOH & "',"
                sql = sql & "'" & FeeSubmitted & "',"
                sql = sql & "'" & NumberOfServices & "',"
                sql = sql & "'" & ServiceDate & "',"
                sql = sql & "'" & DiagnosticCode & "',"
                sql = sql & "'" & ReservedForMOH2 & "',"
                sql = sql & "'" & ExplanCode & "',"
                sql = sql & "'" & ErrorCode1 & "',"
                sql = sql & "'" & ErrorCode2 & "',"
                sql = sql & "'" & ErrorCode3 & "',"
                sql = sql & "'" & ErrorCode4 & "',"
                sql = sql & "'" & ErrorCode5 & "'"
                sql = sql & ")"

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()

                objConn.Close()

            Catch ex As Exception

                objConn.Close()
            End Try
        End Sub
    End Class
    Public NotInheritable Class ErrorReportHX8
        Public Property ErrorReportID As Integer
        Public Property TransactionIdentifier As String
        Public Property RecordID As String
        Public Property ExplanCode As String
        Public Property ExplanDescription As String
        Public Property ReservedForMOH As String
        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter

        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter
        Public Sub save()
            Dim sql As String
            Dim objDataset As New DataSet
            Try
                objConn.Open()
                sql = "Insert into ErrorReportHX8"
                sql = sql & " ("
                sql = sql & "ErrorReportID,"
                sql = sql & "TransactionID,"
                sql = sql & "RecordID,"
                sql = sql & "ExplanCode,"
                sql = sql & "ExplanDescription,"
                sql = sql & "ReservedForMOH"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & ErrorReportID & "',"
                sql = sql & "'" & TransactionIdentifier & "',"
                sql = sql & "'" & RecordID & "',"
                sql = sql & "'" & ExplanCode & "',"
                sql = sql & "'" & ExplanDescription & "',"
                sql = sql & "'" & ReservedForMOH & "'"
                sql = sql & ")"

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                objConn.Close()

            Catch ex As Exception
                objConn.Close()
            End Try
        End Sub

    End Class
    Public NotInheritable Class ErrorReportHX9
        Public Property ErrorReportID As Integer
        Public Property TransactionIdentifier As String
        Public Property RecordID As String
        Public Property Header1Count As String
        Public Property Header2Count As String
        Public Property ItemCount As String
        Public Property MessageCount As String
        Public Property ReservedForMOH As String
        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter

        Public Sub save()
            Dim sql As String
            Dim objDataset As New DataSet
            Try
                objConn.Open()
                sql = "Insert into ErrorReportHX9"
                sql = sql & " ("
                sql = sql & "ErrorReportID,"
                sql = sql & "TransactionID,"
                sql = sql & "RecordID,"
                sql = sql & "Header1Count,"
                sql = sql & "Header2Count,"
                sql = sql & "ItemCount,"
                sql = sql & "MessageCount,"
                sql = sql & "ReservedForMOH"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & ErrorReportID & "',"
                sql = sql & "'" & TransactionIdentifier & "',"
                sql = sql & "'" & RecordID & "',"
                sql = sql & "'" & Header1Count & "',"
                sql = sql & "'" & Header2Count & "',"
                sql = sql & "'" & ItemCount & "',"
                sql = sql & "'" & MessageCount & "',"
                sql = sql & "'" & ReservedForMOH & "'"
                sql = sql & ")"

                'MSAccess
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                objConn.Close()

            Catch ex As Exception
                objConn.Close()
            End Try
        End Sub
    End Class

    Public NotInheritable Class ReportViewerClass
        'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
        'Private myCommand As New System.Data.OleDb.OleDbCommand
        'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
        'Private myData As DataSet = New DataSet
        'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
        Private myCommand As New MySqlCommand
        Private myAdapter As MySqlDataAdapter
        Private myData As DataSet = New DataSet
        Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
        Private objDataAdapter As MySqlDataAdapter
        Public Sub ReportViewer(ByVal Id As Integer)
            Dim sql As String
            Dim objErrorReportDetailsDataset As New DataSet
            ' Declare new StringBuilder Dim
            Dim Reportbuilder As New System.Text.StringBuilder
            Dim BatchProcessDate As DateTime
            Dim ServiceDate As DateTime
            Dim iyear As Integer
            Dim imonth As Integer
            Dim iday As Integer

            sql = "Select * "
            sql = sql & "from errorreporthx1 "
            sql = sql & "where ErrorReportID = " & Id



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objErrorReportDetailsDataset, "tblerrorreporthx1")

            If objErrorReportDetailsDataset.Tables("tblerrorreporthx1").Rows.Count() > 0 Then
                For Each rs As DataRow In objErrorReportDetailsDataset.Tables("tblerrorreporthx1").Rows 'Loops through Rows
                    iyear = System.Convert.ToInt32(objErrorReportDetailsDataset.Tables("tblerrorreporthx1").Rows(0).Item("ClaimProcessDate").Substring(0, 4))
                    imonth = System.Convert.ToInt32(objErrorReportDetailsDataset.Tables("tblerrorreporthx1").Rows(0).Item("ClaimProcessDate").Substring(4, 2))
                    iday = System.Convert.ToInt32(objErrorReportDetailsDataset.Tables("tblerrorreporthx1").Rows(0).Item("ClaimProcessDate").Substring(6, 2))
                    BatchProcessDate = New DateTime(iyear, imonth, iday)

                    Reportbuilder.Append("Error Report for Batch Process Date :" & BatchProcessDate.ToString("d", System.Globalization.DateTimeFormatInfo.InvariantInfo))
                    Reportbuilder.AppendLine()

                    sql = "Select e.headerid,e.HealthNumber,e.errorcode1,e.errorcode2,e.errorcode3,e.errorcode4,e.errorcode5 "
                    sql = sql & "from errorreporthxh e "
                    sql = sql & "where e.ErrorReportID = " & Id




                    Dim objErrorReportDetailstblErrorreportHXHDataset As New DataSet
                    'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
                    objDataAdapter = New MySqlDataAdapter(sql, objConn)
                    objDataAdapter.Fill(objErrorReportDetailstblErrorreportHXHDataset, "tblerrorreporthxh")

                    If objErrorReportDetailstblErrorreportHXHDataset.Tables("tblerrorreporthxh").Rows.Count() > 0 Then
                        For Each rsh As DataRow In objErrorReportDetailstblErrorreportHXHDataset.Tables("tblerrorreporthxh").Rows 'Loops through Rows
                            Reportbuilder.AppendLine()
                            Reportbuilder.AppendLine()
                            Reportbuilder.Append("Health Card Number : " & rsh.Item("HealthNumber") & " ")
                            If rsh.Item("errorcode1").ToString.Trim <> "" Then
                                Reportbuilder.Append("Error : " & rsh.Item("errorcode1") & " ")
                                Reportbuilder.Append(":" & ErrorDescription(rsh.Item("errorcode1")))
                            End If
                            If rsh.Item("errorcode2").ToString.Trim <> "" Then
                                Reportbuilder.Append("Error : " & rsh.Item("errorcode2"))
                                Reportbuilder.Append(":" & ErrorDescription(rsh.Item("errorcode2")))
                            End If
                            If rsh.Item("errorcode3").ToString.Trim <> "" Then
                                Reportbuilder.Append("Error : " & rsh.Item("errorcode3"))
                                Reportbuilder.Append(":" & ErrorDescription(rsh.Item("errorcode3")))
                            End If
                            If rsh.Item("errorcode4").ToString.Trim <> "" Then
                                Reportbuilder.Append("Error : " & rsh.Item("errorcode4"))
                                Reportbuilder.Append(":" & ErrorDescription(rsh.Item("errorcode4")))
                            End If
                            If rsh.Item("errorcode5").ToString.Trim <> "" Then
                                Reportbuilder.Append("Error : " & rsh.Item("errorcode5"))
                                Reportbuilder.Append(":" & ErrorDescription(rsh.Item("errorcode5")))
                            End If

                            sql = "Select e.servicedate,e.servicecode,e.diagnosticcode,e.errorcode1,e.errorcode2,e.errorcode3,e.errorcode4,e.errorcode5  "
                            sql = sql & "from errorreporthxt e "
                            '  sql = sql & "where ErrorReportID = " & Id
                            sql = sql & "where headerid = " & rsh.Item("HeaderID")

                            Dim objErrorReportDetailstblErrorReportHXTDataset As New DataSet
                            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
                            objDataAdapter = New MySqlDataAdapter(sql, objConn)
                            objDataAdapter.Fill(objErrorReportDetailstblErrorReportHXTDataset, "tblerrorreporthxt")

                            If objErrorReportDetailstblErrorReportHXTDataset.Tables("tblerrorreporthxt").Rows.Count() > 0 Then
                                ' Reportbuilder.AppendLine()
                                Reportbuilder.AppendLine()
                                Dim ServiceDateColumnName As String = "Service Date"
                                Dim ServiceCodeColumnName As String = "Service Code"
                                Dim DiagnosticCodeColumnName As String = "Diagnostic Code"

                                Reportbuilder.Append(ServiceDateColumnName.PadRight(25, " "))
                                Reportbuilder.Append(ServiceCodeColumnName.PadRight(25, " "))
                                Reportbuilder.Append(DiagnosticCodeColumnName.PadRight(25, " "))


                                For Each rst As DataRow In objErrorReportDetailstblErrorReportHXTDataset.Tables("tblerrorreporthxt").Rows 'Loops through Rows
                                    Reportbuilder.AppendLine()

                                    iyear = System.Convert.ToInt32(objErrorReportDetailstblErrorReportHXTDataset.Tables("tblerrorreporthxt").Rows(0).Item("servicedate").Substring(0, 4))
                                    imonth = System.Convert.ToInt32(objErrorReportDetailstblErrorReportHXTDataset.Tables("tblerrorreporthxt").Rows(0).Item("servicedate").Substring(4, 2))
                                    iday = System.Convert.ToInt32(objErrorReportDetailstblErrorReportHXTDataset.Tables("tblerrorreporthxt").Rows(0).Item("servicedate").Substring(6, 2))
                                    ServiceDate = New DateTime(iyear, imonth, iday)
                                    Dim formatedDate As String = ServiceDate.ToString("d", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                                    Dim servicecode As String = rst.Item("servicecode")
                                    Dim diagnosticcode As String = rst.Item("diagnosticcode")
                                    Reportbuilder.Append(formatedDate.PadRight(25, " "))
                                    Reportbuilder.Append(servicecode.PadRight(28, " "))
                                    Reportbuilder.Append(diagnosticcode.PadRight(25, " "))
                                    If rst.Item("errorcode1").ToString.Trim <> "" Then
                                        Reportbuilder.Append("Error:" & rst.Item("errorcode1"))
                                        Reportbuilder.Append(":" & ErrorDescription(rst.Item("errorcode1")))
                                    End If
                                    If rst.Item("errorcode2").ToString.Trim <> "" Then
                                        Reportbuilder.Append("Error:" & rst.Item("errorcode2"))
                                        Reportbuilder.Append(":" & ErrorDescription(rst.Item("errorcode2")))
                                    End If
                                    If rst.Item("errorcode3").ToString.Trim <> "" Then
                                        Reportbuilder.Append("Error:" & rst.Item("errorcode3"))
                                        Reportbuilder.Append(":" & ErrorDescription(rst.Item("errorcode3")))
                                    End If
                                    If rst.Item("errorcode4").ToString.Trim <> "" Then
                                        Reportbuilder.Append("Error:" & rsh.Item("errorcode4"))
                                        Reportbuilder.Append(":" & ErrorDescription(rsh.Item("errorcode4")))
                                    End If
                                    If rst.Item("errorcode5").ToString.Trim <> "" Then
                                        Reportbuilder.Append("Error:" & rst.Item("errorcode5"))
                                        Reportbuilder.Append(":" & ErrorDescription(rst.Item("errorcode5")))
                                    End If

                                Next
                                Dim devideline As String = "_"
                                Reportbuilder.AppendLine()
                                Reportbuilder.Append(devideline.ToString.PadRight(79, "_"c))
                            End If
                        Next
                    End If
                Next

                Dim ErrorReportView As New MessageText
                ErrorReportView.MessageTextBox.Text = Reportbuilder.ToString
                ErrorReportView.Text = "Error Report"
                ErrorReportView.ShowDialog()
            End If



        End Sub


        Private Function ErrorDescription(ByVal errorcode As String) As String
            Dim sql As String
            Dim objErrorCodeDataSet As New DataSet
            Dim Description As String = ""
            sql = "Select * "
            sql = sql & "from errorcodes "
            sql = sql & "where code = '" & errorcode & "'"

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objErrorCodeDataSet, "tblerrorcode")

            For Each rsDescription As DataRow In objErrorCodeDataSet.Tables("tblerrorcode").Rows
                Description = rsDescription.Item("Description")
            Next
            'Loops through Rows

            Return Description

        End Function




    End Class
End Class
