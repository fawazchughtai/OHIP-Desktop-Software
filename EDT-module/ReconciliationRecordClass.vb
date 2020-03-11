Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class ReconciliationClass
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
    Private class_ImportPath As String
    Public Property ImportPath() As String
        Set(ByVal value As String)
            class_ImportPath = value.ToString
        End Set
        Get
            Return class_ImportPath
        End Get
    End Property
    Public Sub Process(ByVal filename As String)
        Dim counter As Integer = 0
        Dim TextLine As String
        Try

            Dim ImportRecordType As String
            Dim processPath As String
            Dim provider As System.Globalization.CultureInfo = System.Globalization.CultureInfo.InvariantCulture
            processPath = class_ImportPath & "\Reconciliation-Processed-" & FormatDateTime(Today(), DateFormat.ShortDate)
            processPath = processPath.Replace("/", "-")


            If System.IO.File.Exists(class_ImportPath & filename) = True Then
                Dim objReader As New System.IO.StreamReader(class_ImportPath & filename)
                Do While objReader.Peek() <> -1
                    counter = counter + 1


                    Application.DoEvents()
                    TextLine = objReader.ReadLine()
                    If Len(TextLine) >= 3 Then
                        ImportRecordType = TextLine.Substring(0, 3)
                    Else
                        ImportRecordType = "x"
                    End If

                    Select Case ImportRecordType
                        Case "HR1"
                            Dim objReconciliationHeaderRecord As New ReconciliationHeaderRecord
                            objReconciliationHeaderRecord.TransactionIdentifier = TextLine.Substring(0, 2)
                            objReconciliationHeaderRecord.RecordType = TextLine.Substring(2, 1)
                            objReconciliationHeaderRecord.TechSpecReleaseIdentifier = TextLine.Substring(3, 3)
                            objReconciliationHeaderRecord.ReservedForMOH_1 = TextLine.Substring(6, 1)
                            objReconciliationHeaderRecord.GroupNumberOrLabLicenceNo = TextLine.Substring(7, 4)
                            objReconciliationHeaderRecord.HealthCareProvider = TextLine.Substring(11, 6)
                            objReconciliationHeaderRecord.Specialty = TextLine.Substring(17, 2)
                            objReconciliationHeaderRecord.MOHOfficeCode = TextLine.Substring(19, 1)
                            objReconciliationHeaderRecord.RemmittanceAdviceDataSequence = TextLine.Substring(20, 1)
                            objReconciliationHeaderRecord.PaymentDate = TextLine.Substring(21, 8)
                            objReconciliationHeaderRecord.PayeeName = TextLine.Substring(29, 30)
                            objReconciliationHeaderRecord.TotalAmountPpayable = TextLine.Substring(59, 9)
                            objReconciliationHeaderRecord.TotalAmountPayableSign = TextLine.Substring(68, 1)
                            objReconciliationHeaderRecord.CheckNumber = TextLine.Substring(69, 8)
                            objReconciliationHeaderRecord.ReservedForMOHUse_2 = TextLine.Substring(77, 2)
                            objReconciliationHeaderRecord.save(filename)
                            Application.DoEvents()

                        Case "HR2"
                            Dim objReconciliationAddressRecordOne As New ReconciliationAddressRecordOne
                            objReconciliationAddressRecordOne.TransactionIdentifier = TextLine.Substring(0, 2)
                            objReconciliationAddressRecordOne.RecordType = TextLine.Substring(2, 1)
                            objReconciliationAddressRecordOne.BillingAgentName = TextLine.Substring(3, 30)
                            objReconciliationAddressRecordOne.AddressLineOne = TextLine.Substring(33, 25)
                            objReconciliationAddressRecordOne.ReservedForMOHUse_1 = TextLine.Substring(58, 21)
                            objReconciliationAddressRecordOne.save(filename)
                            Application.DoEvents()

                        Case "HR3"
                            Dim objReconciliationAddressRecordTwo As New ReconciliationAddressRecordTwo
                            objReconciliationAddressRecordTwo.TransactionIdentifier = TextLine.Substring(0, 2)
                            objReconciliationAddressRecordTwo.RecordType = TextLine.Substring(2, 1)
                            objReconciliationAddressRecordTwo.AddressLine2 = TextLine.Substring(3, 25)
                            objReconciliationAddressRecordTwo.AddressLine3 = TextLine.Substring(28, 25)
                            objReconciliationAddressRecordTwo.ReservedForMOHUse_1 = TextLine.Substring(53, 26)
                            objReconciliationAddressRecordTwo.save(filename)
                            Application.DoEvents()

                        Case "HR4"
                            Dim objReconciliationClaimHeader As New ReconciliationClaimHeader
                            objReconciliationClaimHeader.TransactionIdentifier = TextLine.Substring(0, 2)
                            objReconciliationClaimHeader.RecordType = TextLine.Substring(2, 1)
                            objReconciliationClaimHeader.ClaimNumber = TextLine.Substring(3, 11)
                            objReconciliationClaimHeader.TransactionType = TextLine.Substring(14, 1)
                            objReconciliationClaimHeader.HealthCareProvider = TextLine.Substring(15, 6)
                            objReconciliationClaimHeader.Specialty = TextLine.Substring(21, 2)
                            objReconciliationClaimHeader.AccountingNumber = TextLine.Substring(23, 8)
                            objReconciliationClaimHeader.PatientLastName = TextLine.Substring(31, 14)
                            objReconciliationClaimHeader.PatientFirstName = TextLine.Substring(45, 5)
                            objReconciliationClaimHeader.ProvinceCode = TextLine.Substring(50, 2)
                            objReconciliationClaimHeader.HealthRegistrationNumber = TextLine.Substring(52, 12)
                            objReconciliationClaimHeader.VersionCode = TextLine.Substring(64, 2)
                            objReconciliationClaimHeader.PaymentProgram = TextLine.Substring(66, 3)
                            objReconciliationClaimHeader.ServiceLocationIndicator = TextLine.Substring(69, 4)
                            objReconciliationClaimHeader.MOHGroupIdentifier = TextLine.Substring(73, 4)
                            objReconciliationClaimHeader.ReservedForMOHUse_1 = TextLine.Substring(77, 2)
                            objReconciliationClaimHeader.save(filename)
                            Application.DoEvents()

                        Case "HR5"
                            Dim objReconciliationClaimItem As New ReconciliationClaimItem
                            objReconciliationClaimItem.TransactionIdentifier = TextLine.Substring(0, 2)
                            objReconciliationClaimItem.RecordType = TextLine.Substring(2, 1)
                            objReconciliationClaimItem.ClaimNumber = TextLine.Substring(3, 11)
                            objReconciliationClaimItem.TransactionType = TextLine.Substring(14, 1)
                            objReconciliationClaimItem.ServiceDate = TextLine.Substring(15, 8)
                            objReconciliationClaimItem.NumberOfServices = TextLine.Substring(23, 2)
                            objReconciliationClaimItem.ServiceCode = TextLine.Substring(25, 5)
                            objReconciliationClaimItem.ReservedForMOHUse_1 = TextLine.Substring(30, 1)
                            objReconciliationClaimItem.AmountSubmitted = TextLine.Substring(31, 4) & "." & TextLine.Substring(35, 2)
                            objReconciliationClaimItem.AmountPaid = TextLine.Substring(37, 4) & "." & TextLine.Substring(41, 2)
                            objReconciliationClaimItem.AmountPaidSign = TextLine.Substring(43, 1)
                            objReconciliationClaimItem.ExplanatoryCode = TextLine.Substring(44, 2)
                            objReconciliationClaimItem.ReservedForMOHUse_2 = TextLine.Substring(46, 33)
                            objReconciliationClaimItem.save(filename)
                            Application.DoEvents()

                        Case "HR6"
                            Dim objReconciliationBalanceForward As New ReconciliationBalanceForward
                            objReconciliationBalanceForward.TransactionIdentifier = TextLine.Substring(0, 2)
                            objReconciliationBalanceForward.RecordType = TextLine.Substring(2, 1)
                            objReconciliationBalanceForward.AmountBroughtForward = TextLine.Substring(3, 9)
                            objReconciliationBalanceForward.AmountBroughtForwardSign = TextLine.Substring(12, 1)
                            objReconciliationBalanceForward.AmountBroughtForwardAdvances = TextLine.Substring(13, 9)
                            objReconciliationBalanceForward.AmountBroughtForwardAdvancesSign = TextLine.Substring(22, 1)
                            objReconciliationBalanceForward.AmountBroughtForwardReductions = TextLine.Substring(23, 9)
                            objReconciliationBalanceForward.AmountBroughtForwardReductionsSign = TextLine.Substring(32, 1)
                            objReconciliationBalanceForward.AmountBroughtForwardOtherDeductions = TextLine.Substring(33, 9)
                            objReconciliationBalanceForward.AmountBroughtForwardOtherDeductionsSign = TextLine.Substring(42, 1)
                            objReconciliationBalanceForward.ReservedForMOHUse_1 = TextLine.Substring(43, 36)
                            objReconciliationBalanceForward.save(filename)
                            Application.DoEvents()

                        Case "HR7"
                            Dim objReconciliationAccountingTransaction As New ReconciliationAccountingTransaction
                            objReconciliationAccountingTransaction.TransactionIdentifier = TextLine.Substring(0, 2)
                            objReconciliationAccountingTransaction.RecordType = TextLine.Substring(2, 1)
                            objReconciliationAccountingTransaction.TransactionCode = TextLine.Substring(3, 2)
                            objReconciliationAccountingTransaction.ChequeIndicator = TextLine.Substring(5, 1)
                            objReconciliationAccountingTransaction.TransactionDate = TextLine.Substring(6, 8)
                            objReconciliationAccountingTransaction.TransactionAmount = TextLine.Substring(14, 8)
                            objReconciliationAccountingTransaction.TransactionAmountSign = TextLine.Substring(22, 1)
                            objReconciliationAccountingTransaction.TransactionMessage = TextLine.Substring(23, 50)
                            objReconciliationAccountingTransaction.ReservedForMOHUse_1 = TextLine.Substring(73, 6)
                            objReconciliationAccountingTransaction.save(filename)
                            Application.DoEvents()

                        Case "HR8"
                            Dim objReconciliationMessageFacility As New ReconciliationMessageFacility
                            objReconciliationMessageFacility.TransactionIdentifier = TextLine.Substring(0, 2)
                            objReconciliationMessageFacility.RecordType = TextLine.Substring(2, 1)
                            objReconciliationMessageFacility.MessageText = TextLine.Substring(3, 70)
                            objReconciliationMessageFacility.ReservedForMOHUse_1 = TextLine.Substring(73, 6)
                            objReconciliationMessageFacility.save(filename)
                            Application.DoEvents()

                    End Select
                Loop
                objReader.Close()
                If Not System.IO.Directory.Exists(processPath) Then
                    System.IO.Directory.CreateDirectory(processPath)
                End If
                Dim FileToCopy As String
                Dim NewCopy As String

                FileToCopy = class_ImportPath & filename
                NewCopy = processPath & "\" & filename

                MOHMessages.process_reconciliation(filename)

                If System.IO.File.Exists(FileToCopy) = True Then
                    System.IO.File.Copy(FileToCopy, NewCopy, True)
                    System.IO.File.Delete(FileToCopy)
                End If

                If strReturnFileFolder = vbNullString Then
                    strReturnFileFolder = currPath & "\InputFiles\"
                End If

                Dim dir As New System.IO.DirectoryInfo(strReturnFileFolder)
                Dim i As Integer = 0
                Reconciliation.ReconciliationDataGrid.Rows.Clear()
                For Each f As System.IO.FileInfo In dir.GetFiles("P*.*")
                    Reconciliation.ReconciliationDataGrid.Rows.Add()
                    Reconciliation.ReconciliationDataGrid.Rows(i).Cells("filename").Value = f.Name
                    i = i + 1
                Next f

                Dim btn As New DataGridViewButtonColumn()
                btn.HeaderText = ""
                btn.Text = "Process Now"
                btn.Name = "Processbtn"
                btn.UseColumnTextForButtonValue = True
                If Reconciliation.ReconciliationDataGrid.ColumnCount = 1 Then
                    Reconciliation.ReconciliationDataGrid.Columns.Add(btn)
                End If

            Else
                MsgBox("File Does Not Exist")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ReconcileSubmissionRecords(ByVal filename As String)
        Dim sql As String
        Dim objClaimDataset As New DataSet
        Dim sqlUpdateSubmitions As String
        Dim AccountingNumber As String
        Dim ExplanatoryCode As String
        Dim AmountPaid As String
        Dim intsource_id As Integer

        objConn.Open()
        Try
            sql = "select claimheader.AccountingNumber, claimItem.AmountPaid,  claimItem.ExplanatoryCode from reconciliationclaimheader claimheader, reconciliationclaimitem claimItem  where claimItem.ClaimNumber = claimheader.ClaimNumber and claimItem.FileName = '" & filename & "'"
            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objClaimDataset, "tblclaimItem")
            If objClaimDataset.Tables(0).Rows.Count() > 0 Then
                For Each rs As DataRow In objClaimDataset.Tables("tblclaimItem").Rows 'Loops through Rows

                    AccountingNumber = rs.Item("AccountingNumber")
                    ExplanatoryCode = rs.Item("ExplanatoryCode")
                    AmountPaid = rs.Item("AmountPaid")
                    Try
                        intsource_id = Convert.ToInt32(AccountingNumber)
                        Try
                            sqlUpdateSubmitions = "update processed_service_record set "
                            sqlUpdateSubmitions = sqlUpdateSubmitions & "ExplanatoryCode ='" & ExplanatoryCode & "',"
                            sqlUpdateSubmitions = sqlUpdateSubmitions & "AmountPaid ='" & AmountPaid & "' "
                            sqlUpdateSubmitions = sqlUpdateSubmitions & "where source_id = " & intsource_id
                            myCommand.Connection = objConn
                            myCommand.CommandText = sqlUpdateSubmitions
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception

                        End Try

                    Catch ex As Exception

                    End Try
                Next
            End If
            objConn.Close()
        Catch ex As Exception
            objConn.Close()
        End Try

    End Sub
End Class
Public NotInheritable Class ReconciliationHeaderRecord
    Public Property TransactionIdentifier As String
    Public Property RecordType As String
    Public Property TechSpecReleaseIdentifier As String
    Public Property ReservedForMOH_1 As String
    Public Property GroupNumberOrLabLicenceNo As String
    Public Property HealthCareProvider As String
    Public Property Specialty As String
    Public Property MOHOfficeCode As String
    Public Property RemmittanceAdviceDataSequence As String
    Public Property PaymentDate As String
    Public Property PayeeName As String
    Public Property TotalAmountPpayable As String
    Public Property TotalAmountPayableSign As String
    Public Property CheckNumber As String
    Public Property ReservedForMOHUse_2 As String
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
    Public Sub save(ByVal filename As String)
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            sql = "Insert into ReconciliationHeaderRecord"
            sql = sql & " ("
            sql = sql & "FileName,"
            sql = sql & "TransactionIdentifier,"
            sql = sql & "RecordType,"
            sql = sql & "TechSpecReleaseIdentifier,"
            sql = sql & "ReservedForMOH_1,"
            sql = sql & "GroupNumberOrLabLicenceNo,"
            sql = sql & "HealthCareProvider,"
            sql = sql & "Specialty,"
            sql = sql & "MOHOfficeCode,"
            sql = sql & "RemmittanceAdviceDataSequence,"
            sql = sql & "PaymentDate,"
            sql = sql & "PayeeName,"
            sql = sql & "TotalAmountPpayable,"
            sql = sql & "TotalAmountPayableSign,"
            sql = sql & "CheckNumber,"
            sql = sql & "ReservedForMOHUse_2"
            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "'" & filename & "',"
            sql = sql & "'" & TransactionIdentifier & "',"
            sql = sql & "'" & RecordType & "',"
            sql = sql & "'" & TechSpecReleaseIdentifier & "',"
            sql = sql & "'" & ReservedForMOH_1 & "',"
            sql = sql & "'" & GroupNumberOrLabLicenceNo & "',"
            sql = sql & "'" & HealthCareProvider & "',"
            sql = sql & "'" & Specialty & "',"
            sql = sql & "'" & MOHOfficeCode & "',"
            sql = sql & "'" & RemmittanceAdviceDataSequence & "',"
            sql = sql & "'" & PaymentDate & "',"
            sql = sql & "'" & PayeeName & "',"
            sql = sql & "'" & TotalAmountPpayable & "',"
            sql = sql & "'" & TotalAmountPayableSign & "',"
            sql = sql & "'" & CheckNumber & "',"
            sql = sql & "'" & ReservedForMOHUse_2 & "'"
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
Public NotInheritable Class ReconciliationAddressRecordOne
    Public Property TransactionIdentifier As String
    Public Property RecordType As String
    Public Property BillingAgentName As String
    Public Property AddressLineOne As String
    Public Property ReservedForMOHUse_1 As String
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
    Public Sub save(ByVal filename As String)
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            sql = "Insert into ReconciliationAddressRecordOne"
            sql = sql & " ("
            sql = sql & "FileName,"
            sql = sql & "TransactionIdentifier,"
            sql = sql & "RecordType,"
            sql = sql & "BillingAgentName,"
            sql = sql & "AddressLineOne,"
            sql = sql & "ReservedForMOHUse_1"
            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "'" & filename & "',"
            sql = sql & "'" & TransactionIdentifier & "',"
            sql = sql & "'" & RecordType & "',"
            sql = sql & "'" & BillingAgentName & "',"
            sql = sql & "'" & AddressLineOne & "',"
            sql = sql & "'" & ReservedForMOHUse_1 & "'"
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
Public NotInheritable Class ReconciliationAddressRecordTwo
    Public Property TransactionIdentifier As String
    Public Property RecordType As String
    Public Property AddressLine2 As String
    Public Property AddressLine3 As String
    Public Property ReservedForMOHUse_1 As String
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
    Public Sub save(ByVal filename As String)
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            sql = "Insert into ReconciliationAddressRecordTwo"
            sql = sql & " ("
            sql = sql & "FileName,"
            sql = sql & "TransactionIdentifier,"
            sql = sql & "RecordType,"
            sql = sql & "AddressLine2,"
            sql = sql & "AddressLine3,"
            sql = sql & "ReservedForMOHUse_1"
            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "'" & filename & "',"
            sql = sql & "'" & TransactionIdentifier & "',"
            sql = sql & "'" & RecordType & "',"
            sql = sql & "'" & AddressLine2 & "',"
            sql = sql & "'" & AddressLine3 & "',"
            sql = sql & "'" & ReservedForMOHUse_1 & "'"
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
Public NotInheritable Class ReconciliationClaimHeader
    Public Property TransactionIdentifier As String
    Public Property RecordType As String
    Public Property ClaimNumber As String
    Public Property TransactionType As String
    Public Property HealthCareProvider As String
    Public Property Specialty As String
    Public Property AccountingNumber As String
    Public Property PatientLastName As String
    Public Property PatientFirstName As String
    Public Property ProvinceCode As String
    Public Property HealthRegistrationNumber As String
    Public Property VersionCode As String
    Public Property PaymentProgram As String
    Public Property ServiceLocationIndicator As String
    Public Property MOHGroupIdentifier As String
    Public Property ReservedForMOHUse_1 As String
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
    Public Sub save(ByVal filename As String)
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            sql = "Insert into ReconciliationClaimHeader"
            sql = sql & " ("
            sql = sql & "FileName,"
            sql = sql & "TransactionIdentifier,"
            sql = sql & "RecordType,"
            sql = sql & "ClaimNumber ,"
            sql = sql & "TransactionType,"
            sql = sql & "HealthCareProvider,"
            sql = sql & "Specialty,"
            sql = sql & "AccountingNumber,"
            sql = sql & "PatientLastName,"
            sql = sql & "PatientFirstName,"
            sql = sql & "ProvinceCode,"
            sql = sql & "HealthRegistrationNumber,"
            sql = sql & "VersionCode,"
            sql = sql & "PaymentProgram,"
            sql = sql & "ServiceLocationIndicator,"
            sql = sql & "MOHGroupIdentifier,"
            sql = sql & "ReservedForMOHUse_1"
            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "'" & filename & "',"
            sql = sql & "'" & TransactionIdentifier & "',"
            sql = sql & "'" & RecordType & "',"
            sql = sql & "'" & ClaimNumber & "',"
            sql = sql & "'" & TransactionType & "',"
            sql = sql & "'" & HealthCareProvider & "',"
            sql = sql & "'" & Specialty & "',"
            sql = sql & "'" & AccountingNumber & "',"
            sql = sql & "'" & PatientLastName & "',"
            sql = sql & "'" & PatientFirstName & "',"
            sql = sql & "'" & ProvinceCode & "',"
            sql = sql & "'" & HealthRegistrationNumber & "',"
            sql = sql & "'" & VersionCode & "',"
            sql = sql & "'" & PaymentProgram & "',"
            sql = sql & "'" & ServiceLocationIndicator & "',"
            sql = sql & "'" & MOHGroupIdentifier & "',"
            sql = sql & "'" & ReservedForMOHUse_1 & "'"
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
Public NotInheritable Class ReconciliationClaimItem
    Public Property TransactionIdentifier As String
    Public Property RecordType As String
    Public Property ClaimNumber As String
    Public Property TransactionType As String
    Public Property ServiceDate As String
    Public Property NumberOfServices As String
    Public Property ServiceCode As String
    Public Property ReservedForMOHUse_1 As String
    Public Property AmountSubmitted As String
    Public Property AmountPaid As String
    Public Property AmountPaidSign As String
    Public Property ExplanatoryCode As String
    Public Property ReservedForMOHUse_2 As String
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
    Public Sub save(ByVal filename As String)
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            sql = "Insert into ReconciliationClaimItem"
            sql = sql & " ("
            sql = sql & "FileName,"
            sql = sql & "TransactionIdentifier,"
            sql = sql & "RecordType,"
            sql = sql & "ClaimNumber,"
            sql = sql & "TransactionType,"
            sql = sql & "ServiceDate,"
            sql = sql & "NumberOfServices,"
            sql = sql & "ServiceCode,"
            sql = sql & "ReservedForMOHUse_1,"
            sql = sql & "AmountSubmitted,"
            sql = sql & "AmountPaid,"
            sql = sql & "AmountPaidSign,"
            sql = sql & "ExplanatoryCode,"
            sql = sql & "ReservedForMOHUse_2"
            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "'" & filename & "',"
            sql = sql & "'" & TransactionIdentifier & "',"
            sql = sql & "'" & RecordType & "',"
            sql = sql & "'" & ClaimNumber & "',"
            sql = sql & "'" & TransactionType & "',"
            sql = sql & "'" & ServiceDate & "',"
            sql = sql & "'" & NumberOfServices & "',"
            sql = sql & "'" & ServiceCode & "',"
            sql = sql & "'" & ReservedForMOHUse_1 & "',"
            sql = sql & "'" & AmountSubmitted & "',"
            sql = sql & "'" & AmountPaid & "',"
            sql = sql & "'" & AmountPaidSign & "',"
            sql = sql & "'" & ExplanatoryCode & "',"
            sql = sql & "'" & ReservedForMOHUse_2 & "'"
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
Public NotInheritable Class ReconciliationBalanceForward
    Public Property TransactionIdentifier As String
    Public Property RecordType As String
    Public Property AmountBroughtForward As String
    Public Property AmountBroughtForwardSign As String
    Public Property AmountBroughtForwardAdvances As String
    Public Property AmountBroughtForwardAdvancesSign As String
    Public Property AmountBroughtForwardReductions As String
    Public Property AmountBroughtForwardReductionsSign As String
    Public Property AmountBroughtForwardOtherDeductions As String
    Public Property AmountBroughtForwardOtherDeductionsSign As String
    Public Property ReservedForMOHUse_1 As String
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
    Public Sub save(ByVal filename As String)
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            sql = "Insert into ReconciliationBalanceForward"
            sql = sql & " ("
            sql = sql & "FileName,"
            sql = sql & "TransactionIdentifier,"
            sql = sql & "RecordType,"
            sql = sql & "AmountBroughtForward,"
            sql = sql & "AmountBroughtForwardSign,"
            sql = sql & "AmountBroughtForwardAdvances,"
            sql = sql & "AmountBroughtForwardAdvancesSign,"
            sql = sql & "AmountBroughtForwardReductions,"
            sql = sql & "AmountBroughtForwardReductionsSign,"
            sql = sql & "AmountBroughtForwardOtherDeductions,"
            sql = sql & "AmountBroughtForwardOtherDeductionsSign,"
            sql = sql & "ReservedForMOHUse_1"
            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "'" & filename & "',"
            sql = sql & "'" & TransactionIdentifier & "',"
            sql = sql & "'" & RecordType & "',"
            sql = sql & "'" & AmountBroughtForward & "',"
            sql = sql & "'" & AmountBroughtForwardSign & "',"
            sql = sql & "'" & AmountBroughtForwardAdvances & "',"
            sql = sql & "'" & AmountBroughtForwardAdvancesSign & "',"
            sql = sql & "'" & AmountBroughtForwardReductions & "',"
            sql = sql & "'" & AmountBroughtForwardReductionsSign & "',"
            sql = sql & "'" & AmountBroughtForwardOtherDeductions & "',"
            sql = sql & "'" & AmountBroughtForwardOtherDeductionsSign & "',"
            sql = sql & "'" & ReservedForMOHUse_1 & "'"
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
Public NotInheritable Class ReconciliationAccountingTransaction
    Public Property TransactionIdentifier As String
    Public Property RecordType As String
    Public Property TransactionCode As String
    Public Property ChequeIndicator As String
    Public Property TransactionDate As String
    Public Property TransactionAmount As String
    Public Property TransactionAmountSign As String
    Public Property TransactionMessage As String
    Public Property ReservedForMOHUse_1 As String
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
    Public Sub save(ByVal filename As String)
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            sql = "Insert into ReconciliationAccountingTransaction"
            sql = sql & " ("
            sql = sql & "FileName,"
            sql = sql & "TransactionIdentifier,"
            sql = sql & "RecordType,"
            sql = sql & "TransactionCode,"
            sql = sql & "ChequeIndicator,"
            sql = sql & "TransactionDate,"
            sql = sql & "TransactionAmount,"
            sql = sql & "TransactionAmountSign,"
            sql = sql & "TransactionMessage,"
            sql = sql & "ReservedForMOHUse_1"
            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "'" & filename & "',"
            sql = sql & "'" & TransactionIdentifier & "',"
            sql = sql & "'" & RecordType & "',"
            sql = sql & "'" & TransactionCode & "',"
            sql = sql & "'" & ChequeIndicator & "',"
            sql = sql & "'" & TransactionDate & "',"
            sql = sql & "'" & TransactionAmount & "',"
            sql = sql & "'" & TransactionAmountSign & "',"
            sql = sql & "'" & TransactionMessage & "',"
            sql = sql & "'" & ReservedForMOHUse_1 & "'"
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
Public NotInheritable Class ReconciliationMessageFacility
    Public Property TransactionIdentifier As String
    Public Property RecordType As String
    Public Property MessageText As String
    Public Property ReservedForMOHUse_1 As String
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
    Public Sub save(ByVal filename As String)
        Dim sql As String
        Dim objDataset As New DataSet
        Try
            objConn.Open()
            sql = "Insert into ReconciliationMessageFacility"
            sql = sql & " ("
            sql = sql & "FileName,"
            sql = sql & "TransactionIdentifier,"
            sql = sql & "RecordType,"
            sql = sql & "MessageText,"
            sql = sql & "ReservedForMOHUse_1,"
            sql = sql & "ImportDate"
            sql = sql & ")"
            sql = sql & " Values("
            sql = sql & "'" & filename & "',"
            sql = sql & "'" & TransactionIdentifier & "',"
            sql = sql & "'" & RecordType & "',"
            sql = sql & "'" & MessageText & "',"
            sql = sql & "'" & ReservedForMOHUse_1 & "',"
            sql = sql & "'" & Now() & "'"
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
