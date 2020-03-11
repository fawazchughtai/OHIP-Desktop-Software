Imports System.Text
Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class CreateOHIPFile
    Private class_Year As String
    Private class_Month As String
    Private class_OHIP_Month As String
    Private class_HealthCareProvider As String
    Private class_OutputPath As String = currPath & "\OutputFiles\"
    Private class_FileName As String
    Private class_FileBatchInformation As String
    Private class_HeaderCount As Integer
    Private class_header2count As Integer
    Private class_ItemCount As Integer
    Private class_ClaimContent As String

    ' MSAccess
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

    Public Property Year() As String
        Set(ByVal value As String)
            class_Year = value.ToString
        End Set
        Get
            Return class_Year
        End Get

    End Property
    Public Property Month() As String
        Set(ByVal value As String)
            class_Month = value.ToString
            class_OHIP_Month = Me.MonthToOHIPAlpha(class_Month)
        End Set
        Get
            Return class_Month
        End Get
    End Property
    Public Property OutputPath() As String
        Set(ByVal value As String)
            class_OutputPath = value.ToString
        End Set
        Get
            Return class_OutputPath
        End Get
    End Property
    Public Function Save() As String

        Dim path As String
        If strSubmissionFileFolder = "" Then
            path = class_OutputPath & "Claim-Files-" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString

            If Not System.IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path & "\" & class_FileName
        Else

            path = strSubmissionFileFolder & "Claim-Files-" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString


            If Not System.IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path & "\" & class_FileName
        End If

        If System.IO.File.Exists(path) = False Then
            ' Create a file to write to.
            Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(path)
            sw.WriteLine(class_ClaimContent)
            sw.Flush()
            sw.Close()
        Else
            ' Create a file to write to.
            System.IO.File.Delete(path)
            Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(path)
            sw.WriteLine(class_ClaimContent)
            sw.Flush()
            sw.Close()
        End If


        Return path

    End Function
    Public Function CreateFile() As String
        Dim objDataset As New DataSet
        Dim StartDate As DateTime
        Dim EndDate As DateTime
        Dim FileName As String = ""
        Dim CurrentDate As Date = Now
        Dim CurrentMonth As String = MonthName(CurrentDate.Month)
        Dim provider As System.Globalization.CultureInfo = System.Globalization.CultureInfo.InvariantCulture

        Try

            If class_Month = CurrentMonth Then
                EndDate = Today.AddDays(-1)
                StartDate = DateAdd("D", -1.0 * DatePart("D", Today) + 1, DateAdd("m", -0, Today))
            Else
                Dim MyStringDate As String = "01 " & class_Month & " " & class_Year
                StartDate = DateTime.ParseExact(MyStringDate, "dd MMMM yyyy", provider)
                EndDate = StartDate.AddMonths(1).AddDays(-1)
            End If

            Me.GetHealthCareProvider()
            Me.CreateFileName()
            Me.CreateClaimInformation()

            Dim fn As String = Me.Save()
            If validatefile(fn) = False Then


            Else
                MsgBox("invalid file output call for support")
            End If



            Me.CreateUnsubmitedServiceList()
            Me.CreateSubmitedServiceList()

            objConn.Close()
            Return class_FileName
        Catch ex As Exception
            objConn.Close()

            MsgBox("Error Occured in CreateOHIPFile.CreateFile")
            Return ""
        End Try
    End Function
    Private Function MonthToOHIPAlpha(ByVal strMonth As String) As String
        Try

            Dim ReturnValue As String = ""
            Select Case strMonth
                Case "January"
                    ReturnValue = "A"
                Case "February"
                    ReturnValue = "B"
                Case "March"
                    ReturnValue = "C"
                Case "April"
                    ReturnValue = "D"
                Case "May"
                    ReturnValue = "E"
                Case "June"
                    ReturnValue = "F"
                Case "July"
                    ReturnValue = "G"
                Case "August"
                    ReturnValue = "H"
                Case "September"
                    ReturnValue = "I"
                Case "October"
                    ReturnValue = "J"
                Case "November"
                    ReturnValue = "K"
                Case "December"
                    ReturnValue = "L"
            End Select
            Return ReturnValue

        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in CreateOHIPFile.MonthToOHIPAlpha : " & ex.ToString)
            Return ""
        End Try
    End Function
    Private Function MonthTonNumber(ByVal strMonth As String) As String
        Try

            Dim ReturnValue As String = ""
            Select Case strMonth
                Case "January"
                    ReturnValue = "01"
                Case "February"
                    ReturnValue = "02"
                Case "March"
                    ReturnValue = "03"
                Case "April"
                    ReturnValue = "04"
                Case "May"
                    ReturnValue = "05"
                Case "June"
                    ReturnValue = "06"
                Case "July"
                    ReturnValue = "07"
                Case "August"
                    ReturnValue = "08"
                Case "September"
                    ReturnValue = "09"
                Case "October"
                    ReturnValue = "10"
                Case "November"
                    ReturnValue = "11"
                Case "December"
                    ReturnValue = "12"
            End Select
            Return ReturnValue

        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in CreateOHIPFile.MonthToOHIPAlpha : " & ex.ToString)
            Return ""
        End Try
    End Function

    Private Sub GetHealthCareProvider()
        Try
            Dim sql As String
            Dim objDataset As New DataSet

            objConn.Open()
            sql = "select OHIPBillingNumber from physicianinformation"

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblphysicianinformation")
            class_HealthCareProvider = objDataset.Tables("tblphysicianinformation").Rows(0).Item("OHIPBillingNumber")

            objConn.Close()
        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in CreateOHIPFile.GetHealthCareProvider : " & ex.ToString)
        End Try
    End Sub
    Private Sub CreateFileName()
        Try
            Dim sql As String
            Dim objDataset As New DataSet
            Dim FileName As String = "H" & class_OHIP_Month & class_HealthCareProvider
            Dim FileSequenceNumber As Integer

            objConn.Open()

            sql = "select sub_month, sub_counter from filenames "
            sql = sql & "where " 'sub_year ='" & class_Year & "' and "
            sql = sql & "sub_month ='" & class_Month & "' order by sub_counter desc"
            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblfilenames")

            If objDataset.Tables(0).Rows.Count = 0 Then
                FileSequenceNumber = 1
                FileName = FileName & "." & FileSequenceNumber.ToString.PadLeft(3, "0"c)
                sql = "Insert into filenames"
                sql = sql & " ("
                sql = sql & "filename,sub_year,sub_month,sub_counter"
                sql = sql & ")"
                sql = sql & " Values("
                sql = sql & "'" & FileName & "',"
                sql = sql & "'" & class_Year & "',"
                sql = sql & "'" & class_Month & "',"
                sql = sql & FileSequenceNumber
                sql = sql & ")"
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
            Else
                FileSequenceNumber = objDataset.Tables("tblfilenames").Rows(0).Item("sub_counter") + 1
                FileName = FileName & "." & FileSequenceNumber.ToString.PadLeft(3, "0"c)
                sql = "Update filenames"
                sql = sql & " Set filename = '" & FileName & "',"
                sql = sql & " sub_counter = " & FileSequenceNumber
                sql = sql & " where " 'sub_year ='" & class_Year & "' and"
                sql = sql & " sub_month ='" & class_Month & "'"
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
            End If

            objConn.Close()

            class_FileName = FileName

        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in CreateOHIPFile.CreateFileName : " & ex.ToString)
        End Try
    End Sub
    Public Sub CreateClaimInformation()
        Dim ClaimFileContent As String
        ClaimFileContent = CreateBatchHeaderRecord()
        ClaimFileContent = ClaimFileContent & CreateClaimHeaderAndItemRecord2()
        ClaimFileContent = ClaimFileContent & CreateBatchTrailerRecord()
        class_ClaimContent = ClaimFileContent
    End Sub
    Private Function CreateBatchHeaderRecord() As String
        Try

            Dim sql As String
            Dim objDataset As New DataSet
            Dim BatchHeader As String
            Dim TransactionIdentifier As String
            Dim RecordIdentification As String
            Dim TechSpecReleaseIdentifier As String
            Dim MOHOfficeCode As String
            Dim BatchIdentification As String
            Dim OperatorNumber As String
            Dim GroupNumber As String
            Dim HealthCareProvider As String
            Dim Specialty As String
            Dim MOHUseOnly As String

            objConn.Open()
            sql = "select * from physicianinformation"

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objDataset, "tblphysicianinformation")
            TransactionIdentifier = "HE"
            RecordIdentification = "B"
            TechSpecReleaseIdentifier = "V03"
            MOHOfficeCode = objDataset.Tables("tblphysicianinformation").Rows(0).Item("MOHOfficeCode")
            OperatorNumber = ""
            GroupNumber = objDataset.Tables("tblphysicianinformation").Rows(0).Item("GroupNumber")
            HealthCareProvider = objDataset.Tables("tblphysicianinformation").Rows(0).Item("OHIPBillingNumber")
            Specialty = objDataset.Tables("tblphysicianinformation").Rows(0).Item("Specialty")
            MOHUseOnly = ""
            BatchIdentification = DateTime.Now.ToString("yyyyMMdd")
            BatchIdentification = BatchIdentification & HealthCareProvider.Substring(HealthCareProvider.Length - 4, 4)

            objConn.Close()

            ' pad variables to Techinical Specification exact lenght
            TransactionIdentifier = TransactionIdentifier.ToString.PadRight(2, " "c)
            RecordIdentification = RecordIdentification.ToString.PadRight(1, " "c)
            TechSpecReleaseIdentifier = TechSpecReleaseIdentifier.ToString.PadRight(3, " "c)
            MOHOfficeCode = MOHOfficeCode.ToString.PadRight(1, " "c)
            BatchIdentification = BatchIdentification.ToString.PadRight(12, " "c)
            OperatorNumber = OperatorNumber.ToString.PadRight(6, "0"c)
            GroupNumber = GroupNumber.ToString.PadLeft(4, " "c)

            HealthCareProvider = HealthCareProvider.ToString.PadLeft(6, "0"c) ' Fixed to correct 5 digit provider #
            Specialty = Specialty.ToString.PadRight(2, " "c)
            MOHUseOnly = MOHUseOnly.ToString.PadRight(42, " "c)

            BatchHeader = TransactionIdentifier
            BatchHeader = BatchHeader & RecordIdentification
            BatchHeader = BatchHeader & TechSpecReleaseIdentifier
            BatchHeader = BatchHeader & MOHOfficeCode
            BatchHeader = BatchHeader & BatchIdentification
            BatchHeader = BatchHeader & OperatorNumber
            BatchHeader = BatchHeader & GroupNumber
            BatchHeader = BatchHeader & HealthCareProvider
            BatchHeader = BatchHeader & Specialty
            BatchHeader = BatchHeader & MOHUseOnly & vbCrLf

            Return BatchHeader
        Catch ex As Exception
            Return ""
            objConn.Close()
            MsgBox("Error Occured in CreateOHIPFile.GetHealthCareProvider : " & ex.ToString)
        End Try

    End Function
    Private Function CreateClaimHeaderAndItemRecord2() As String
        Try
            Dim sql As String
            Dim objDataset As New DataSet 'service item for each claim
            Dim objPhysicianDataset As New DataSet ' physician info
            Dim objClaims As New DataSet ' Claim records info
            Dim objClaimheader As New DataSet ' Claim header data
            Dim StartDate As String
            Dim EndDate As String
            Dim tempDate As DateTime
            Dim FileName As String = ""
            Dim CurrentDate As Date = Now
            Dim CurrentMonth As String = MonthName(CurrentDate.Month)

            Dim ClaimRecords As String

            Dim TransactionIdentifier As String
            Dim RecordIdentification As String
            Dim ServiceCode As String
            Dim MOHuSE As String
            Dim FeeSubmitted As String
            Dim NumberOfServices As String
            Dim ServiceDate As String
            Dim DiagnosticDode As String
            Dim ReservedForOOC As String
            Dim MOHUse2 As String
            Dim OptionalItems As String
            Dim ItemsCount As Integer = 0


            Dim ClaimHeaderTransactionIdentifier As String
            Dim ClaimHeaderRecordIdentification As String
            Dim ClaimHeaderHealthNumber As String
            Dim ClaimHeaderVersionCode As String
            Dim ClaimHeaderPatientBirthdate As String
            Dim ClaimHeaderAccountNumber As String
            Dim ClaimHeaderPaymentProgram As String
            Dim ClaimHeaderPayee As String
            Dim ClaimHeaderReferring As String
            Dim ClaimHeaderMarterNumber As String
            Dim ClaimHeaderInPatientAdmission As String
            Dim ClaimHeaderReferringLabratory As String
            Dim ClaimHeaderManualeReview As String
            Dim ClaimHeaderServiceLocationIndicator As String
            Dim ClaimHeaderReservedForOOC As String
            Dim ClaimHeaderMOHUse As String
            Dim ClaimHeaderHeaderCount As Integer = 0
            Dim RMB_header_count As Integer = 0 ' needed for rmb header count


            'If class_Month = CurrentMonth Then
            '    EndDate = Today
            '    StartDate = DateAdd("D", -1.0 * DatePart("D", Today) + 1, DateAdd("m", -0, Today))
            'Else
            'This year, this month, first day  
            StartDate = DateSerial(class_Year, MonthTonNumber(class_Month), 1)
            'This year, next month, 0th day is this month's last day  
            EndDate = DateSerial(class_Year, MonthTonNumber(class_Month) + 1, 0)
            'End If




            sql = "select * from physicianinformation"

            'MSAccess
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objPhysicianDataset, "tblphysicianinformation")


            'sql = ""
            'sql = "insert into processed_service_record (source_id,patient_id,service_date,service_code,referral,service_fee,num_serv,lc,dx,facility_num,adm_date,processed_file,status,processed_date)"
            'sql = sql + " SELECT id,patient_id,service_date,service_code,referral,service_fee,num_serv,lc,dx,facility_num,adm_date,'" & class_FileName & "',0,format(now(),'dd/MM/yyyy')"
            'sql = sql + " FROM service_record"
            'sql = sql + " WHERE service_record.[patient_id] <> -1"
            'sql = sql + " and service_record.service_date BETWEEN Format('" & StartDate & "', 'mmm/dd/yyyy') and Format('" & EndDate & "', 'mmm/dd/yyyy')"
            'sql = sql + " and service_record.status=0"
            'sql = sql + " ORDER BY id, service_record.service_date;"

            ''service_record.service_date >=format("1/12/2012",'dd/MM/yyyy');
            ''MSAccess
            'objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            'myCommand.ExecuteNonQuery()
            'objConn.Close()


            sql = ""

            sql = sql + "UPDATE processed_service_record SET processed_service_record.processed_file ='" & class_FileName & "'"
            sql = sql + " where status=0"


            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            sql = ""

            sql = sql + "UPDATE claims SET filename ='" & class_FileName & "'"
            sql = sql + " where status=0"


            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()




            sql = ""
            sql = "SELECT distinct p_serv.source_id,p_serv.patient_id , p_serv.service_date, patients.id, patients.ohip, patients.version, patients.dob, patients.sexe, patients.plan"
            'p_serv.referral,
            sql = sql + " from processed_service_record p_serv, patients"
            sql = sql + " WHERE p_serv.patient_id = patients.id "
            sql = sql + " and p_serv.processed_file='" & class_FileName & "' "
            sql = sql + " and status=0 "
            sql = sql + " ORDER BY p_serv.service_date;"



            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)
            objDataAdapter.Fill(objClaims, "tblclaims")



            ClaimRecords = ""

            For Each rs_claim As DataRow In objClaims.Tables("tblclaims").Rows




                ' for each claim get services (LOOP)
                'ITEM Service SQL

                sql = ""
                sql = "SELECT  p_serv.service_code, p_serv.service_fee, p_serv.num_serv, p_serv.service_date, p_serv.dx,p_serv.lc,p_serv.referral,p_serv.facility_num,p_serv.adm_date,mr,lab_num"
                sql = sql + " from processed_service_record p_serv"
                sql = sql + " WHERE "
                sql = sql + " p_serv.processed_file='" & class_FileName & "' "
                sql = sql + " and status=0 "
                sql = sql + " and p_serv.service_date=Format('" & rs_claim("service_date") & "', 'mmm/dd/yyyy') AND p_serv.patient_id=" & rs_claim("patient_id") & ""
                'sql = sql + " and p_serv.referral='" & rs_claim("referral") & "'"
                sql = sql + " ORDER BY p_serv.id asc, p_serv.service_date;"


                objDataset.Clear()
                'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
                objDataAdapter = New MySqlDataAdapter(sql, objConn)
                objDataAdapter.Fill(objDataset, "tblServices")



                Dim xi As Integer = 0
                For Each rs_item As DataRow In objDataset.Tables("tblServices").Rows

                    Application.DoEvents()
                    If xi = 0 Then

                        ' for each claim - get header set
                        'select * from patients as pat, claim_record as claim where pat.id=claim.patient_id and pat.id=28

                        ClaimHeaderTransactionIdentifier = "HE"
                        ClaimHeaderRecordIdentification = "H"

                        ClaimHeaderHealthNumber = Left(rs_claim.Item("ohip"), 10)
                        ClaimHeaderVersionCode = CStr("" & rs_claim.Item("version"))


                        tempDate = rs_claim.Item("dob")
                        ClaimHeaderPatientBirthdate = tempDate.ToString("yyyyMMdd")
                        'ClaimHeaderAccountNumber = class_Month.Substring(0, 3).ToUpper & ClaimHeaderHeaderCount.ToString.PadLeft(5, "0"c)

                        ' Generate new Claim_id and save 
                        ClaimHeaderAccountNumber = rs_claim.Item("source_id")
                        ClaimHeaderPaymentProgram = rs_claim.Item("plan")




                        ClaimHeaderPayee = objPhysicianDataset.Tables("tblphysicianinformation").Rows(0).Item("OptIn")
                        ClaimHeaderReferring = CStr("" & rs_item.Item("referral"))
                        ClaimHeaderMarterNumber = CStr("" & rs_item.Item("facility_num")) ' for Facility code
                        If IsDBNull(rs_item.Item("adm_date")) = False Then

                            tempDate = Nothing
                            tempDate = rs_item.Item("adm_date")
                            ClaimHeaderInPatientAdmission = tempDate.ToString("yyyyMMdd") ' for adminission date.

                        Else
                            ClaimHeaderInPatientAdmission = ""
                        End If


                        ClaimHeaderReferringLabratory = CStr("" & rs_item.Item("lab_num"))
                        ClaimHeaderManualeReview = CStr("" & rs_item.Item("mr"))
                        ClaimHeaderServiceLocationIndicator = CStr("" & rs_item.Item("lc"))
                        ClaimHeaderReservedForOOC = ""
                        ClaimHeaderMOHUse = ""



                        ' pad variables to Techinical Specification exact lenght
                        ClaimHeaderTransactionIdentifier = ClaimHeaderTransactionIdentifier.ToString.PadRight(2, " "c)
                        ClaimHeaderRecordIdentification = ClaimHeaderRecordIdentification.ToString.PadRight(1, " "c)
                        ClaimHeaderHealthNumber = ClaimHeaderHealthNumber.ToString.PadRight(10, " "c)
                        ClaimHeaderVersionCode = ClaimHeaderVersionCode.ToString.PadRight(2, " "c)
                        ClaimHeaderPatientBirthdate = ClaimHeaderPatientBirthdate.ToString.PadRight(8, " "c)
                        ClaimHeaderAccountNumber = ClaimHeaderAccountNumber.ToString.PadLeft(8, "0"c)
                        ClaimHeaderPaymentProgram = ClaimHeaderPaymentProgram.ToString.PadRight(3, " "c)
                        ClaimHeaderPayee = ClaimHeaderPayee.ToString.PadRight(1, " "c)
                        ClaimHeaderReferring = ClaimHeaderReferring.ToString.PadLeft(6, "0"c) ' fixed for 5 digit
                        ClaimHeaderMarterNumber = ClaimHeaderMarterNumber.ToString.PadRight(4, " "c)
                        ClaimHeaderInPatientAdmission = ClaimHeaderInPatientAdmission.ToString.PadRight(8, " "c)
                        ClaimHeaderReferringLabratory = ClaimHeaderReferringLabratory.ToString.PadRight(4, " "c)
                        ClaimHeaderManualeReview = ClaimHeaderManualeReview.ToString.PadRight(1, " "c)
                        ClaimHeaderServiceLocationIndicator = ClaimHeaderServiceLocationIndicator.ToString.PadRight(4, " "c)
                        ClaimHeaderReservedForOOC = ClaimHeaderReservedForOOC.ToString.PadRight(11, " "c)
                        ClaimHeaderMOHUse = ClaimHeaderMOHUse.ToString.PadRight(6, " "c)


                        ClaimRecords = ClaimRecords & ClaimHeaderTransactionIdentifier
                        ClaimRecords = ClaimRecords & ClaimHeaderRecordIdentification
                        ClaimRecords = ClaimRecords & ClaimHeaderHealthNumber
                        ClaimRecords = ClaimRecords & ClaimHeaderVersionCode
                        ClaimRecords = ClaimRecords & ClaimHeaderPatientBirthdate
                        ClaimRecords = ClaimRecords & ClaimHeaderAccountNumber
                        ClaimRecords = ClaimRecords & ClaimHeaderPaymentProgram
                        ClaimRecords = ClaimRecords & ClaimHeaderPayee
                        ClaimRecords = ClaimRecords & ClaimHeaderReferring
                        ClaimRecords = ClaimRecords & ClaimHeaderMarterNumber
                        ClaimRecords = ClaimRecords & ClaimHeaderInPatientAdmission
                        ClaimRecords = ClaimRecords & ClaimHeaderReferringLabratory
                        ClaimRecords = ClaimRecords & ClaimHeaderManualeReview
                        ClaimRecords = ClaimRecords & ClaimHeaderServiceLocationIndicator
                        ClaimRecords = ClaimRecords & ClaimHeaderReservedForOOC
                        ClaimRecords = ClaimRecords & ClaimHeaderMOHUse & vbCrLf

                        If ClaimHeaderPaymentProgram = "RMB" Then

                            ClaimRecords = ClaimRecords & RMB_header(rs_claim("patient_id"))
                            RMB_header_count = RMB_header_count + 1

                        End If

                        xi = 1
                    End If


                    TransactionIdentifier = "HE"
                    RecordIdentification = "T"
                    ServiceCode = rs_item.Item("service_code")
                    MOHuSE = ""

                    FeeSubmitted = CStr(FormatNumber(CDbl(rs_item.Item("service_fee") * rs_item.Item("num_serv")), 2, , , TriState.False))
                    FeeSubmitted = FeeSubmitted.Replace("$", "")
                    FeeSubmitted = FeeSubmitted.Replace(".", "")

                    NumberOfServices = CInt(rs_item.Item("num_serv"))
                    tempDate = rs_item.Item("service_date")
                    ServiceDate = tempDate.ToString("yyyyMMdd")
                    DiagnosticDode = rs_item.Item("DX")
                    ReservedForOOC = ""
                    MOHUse2 = ""
                    OptionalItems = ""

                    ' pad variables to Techinical Specification exact lenght
                    TransactionIdentifier = TransactionIdentifier.ToString.PadRight(2, " "c)
                    RecordIdentification = RecordIdentification.ToString.PadRight(1, " "c)
                    ServiceCode = ServiceCode.ToString.PadRight(5, " "c)
                    MOHuSE = MOHuSE.ToString.PadRight(2, " "c)
                    FeeSubmitted = FeeSubmitted.ToString.PadLeft(6, "0"c)
                    NumberOfServices = NumberOfServices.ToString.PadLeft(2, "0"c)
                    ServiceDate = ServiceDate.ToString.PadRight(8, " "c)
                    DiagnosticDode = DiagnosticDode.ToString.PadRight(4, " "c)
                    ReservedForOOC = ReservedForOOC.ToString.PadRight(10, " "c)
                    MOHUse2 = MOHUse2.ToString.PadRight(1, " "c)
                    OptionalItems = OptionalItems.ToString.PadRight(38, " "c)

                    ClaimRecords = ClaimRecords & TransactionIdentifier
                    ClaimRecords = ClaimRecords & RecordIdentification
                    ClaimRecords = ClaimRecords & ServiceCode
                    ClaimRecords = ClaimRecords & MOHuSE
                    ClaimRecords = ClaimRecords & FeeSubmitted
                    ClaimRecords = ClaimRecords & NumberOfServices
                    ClaimRecords = ClaimRecords & ServiceDate
                    ClaimRecords = ClaimRecords & DiagnosticDode
                    ClaimRecords = ClaimRecords & ReservedForOOC
                    ClaimRecords = ClaimRecords & MOHUse2
                    ClaimRecords = ClaimRecords & OptionalItems & vbCrLf




                    ItemsCount = ItemsCount + 1
                Next
                ClaimHeaderHeaderCount = ClaimHeaderHeaderCount + 1
            Next
            ' ''Next

            objConn.Close()

            sql = ""

            sql = sql + "UPDATE processed_service_record SET processed_service_record.Status = 1"
            sql = sql + " where processed_service_record.processed_file='" & class_FileName & "'"

            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            sql = ""

            sql = sql + "UPDATE claims SET status =1"
            sql = sql + " where filename='" & class_FileName & "'"


            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()


            class_ItemCount = ItemsCount
            class_HeaderCount = ClaimHeaderHeaderCount
            class_header2count = RMB_header_count

            Return ClaimRecords
        Catch ex As Exception
            objConn.Close()
            MsgBox("Error Occured in CreateOHIPFile.GetHealthCareProvider : " & ex.ToString)
            Return ""
        End Try
        Return ""
    End Function

    
    Private Function CreateBatchTrailerRecord() As String
        Try
            Dim BatchTrailer As String
            Dim TransactionIdentifier As String
            Dim RecordIdentification As String
            Dim Hcount As String
            Dim Rcount As String
            Dim Tcount As String
            Dim MOHUseOnly As String

            TransactionIdentifier = "HE"
            RecordIdentification = "E"
            Hcount = class_HeaderCount.ToString
            Rcount = class_header2count.ToString
            Tcount = class_ItemCount.ToString
            MOHUseOnly = ""

            ' pad variables to Techinical Specification exact lenght
            TransactionIdentifier = TransactionIdentifier.ToString.PadRight(2, " "c)
            RecordIdentification = RecordIdentification.ToString.PadRight(1, " "c)
            Hcount = Hcount.ToString.PadLeft(4, "0"c)
            Rcount = Rcount.ToString.PadLeft(4, "0"c)
            Tcount = Tcount.ToString.PadLeft(5, "0"c)
            MOHUseOnly = MOHUseOnly.ToString.PadRight(63, " "c)

            BatchTrailer = TransactionIdentifier
            BatchTrailer = BatchTrailer & RecordIdentification
            BatchTrailer = BatchTrailer & Hcount
            BatchTrailer = BatchTrailer & Rcount
            BatchTrailer = BatchTrailer & Tcount
            BatchTrailer = BatchTrailer & MOHUseOnly

            Return BatchTrailer

        Catch ex As Exception
            Return ""
            MsgBox("Error Occured in CreateOHIPFile.GetHealthCareProvider : " & ex.ToString)
        End Try

    End Function

    Public Function RMB_header(p_id As Integer) As String
        Try

        
        Dim sql As String


            'Dim myAdapter As System.Data.OleDb.OleDbDataAdapter
            'Dim myData As DataSet = New DataSet
            'Dim dbcn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)

            Dim myAdapter As MySqlDataAdapter
            Dim myData As DataSet = New DataSet
            Dim dbcn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)

            Dim TransactionIdentifier As String = "HE"
        Dim RecordIdentification As String = "R"
            Dim health_num As String = ""
            Dim lname As String = ""
            Dim fname As String = ""
            Dim sex As String = ""
            Dim prov_code As String = ""
            Dim ReservedForOOC As String = ""

        sql = "SELECT cdprovince.ProvCode as provcode, patients.fname as fname, patients.lname as lname, patients.ohip as health_num, patients.sexe as sex"
        sql = sql + " FROM cdprovince INNER JOIN patients ON cdprovince.ProvName = patients.province"
        sql = sql & " where id=" & p_id

            'myAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            myAdapter = New MySqlDataAdapter(sql, objConn)
            myAdapter.Fill(myData, "tblpatient")

            If myData.Tables("tblpatient").Rows.Count > 0 Then
                health_num = myData.Tables("tblpatient").Rows(0).Item("health_num")
                lname = myData.Tables("tblpatient").Rows(0).Item("lname")
                lname = lname.Replace("'", "")
                lname = lname.Replace("-", "")
                lname = Left(lname, 9)

                fname = myData.Tables("tblpatient").Rows(0).Item("fname")
                fname = fname.Replace("'", "")
                fname = fname.Replace("-", "")
                fname = Left(fname, 5)

                sex = myData.Tables("tblpatient").Rows(0).Item("sex")
                If sex = "M" Then
                    sex = 1
                ElseIf sex = "F" Then
                    sex = 2
                Else
                    sex = 0
                End If
                prov_code = myData.Tables("tblpatient").Rows(0).Item("provcode").ToString

            End If



            ' pad variables to Techinical Specification exact lenght
            TransactionIdentifier = TransactionIdentifier.ToString.PadRight(2, " "c)
        RecordIdentification = RecordIdentification.ToString.PadRight(1, " "c)
        health_num = health_num.ToString.PadRight(12, " "c)
        lname = lname.ToString.PadRight(9, " "c)
        fname = fname.ToString.PadRight(5, " "c)
        sex = sex.ToString.PadRight(1, "0"c)
        prov_code = prov_code.ToString.PadRight(2, " "c)
        ReservedForOOC = ReservedForOOC.ToString.PadRight(47, " "c)

        RMB_header = ""
        RMB_header = RMB_header & TransactionIdentifier
        RMB_header = RMB_header & RecordIdentification
        RMB_header = RMB_header & health_num
        RMB_header = RMB_header & lname
        RMB_header = RMB_header & fname
        RMB_header = RMB_header & sex
        RMB_header = RMB_header & prov_code
        RMB_header = RMB_header & ReservedForOOC & vbCrLf

            dbcn.Close()

            Return RMB_header.ToString
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
        End Try

    End Function
    

    Public Sub CreateDataViewHeaders()

        Submission.SubmitedDataGridView.Columns.Add("filePath", "filePath")
        ' Submission.SubmitedDataGridView.Columns.Add("month", "Month")
        ' Submission.SubmitedDataGridView.Columns("month").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' Submission.SubmitedDataGridView.Columns.Add("year", "Year")
        ' Submission.SubmitedDataGridView.Columns("year").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Submission.SubmitedDataGridView.Columns.Add("totalServices", "Total Service")
        Submission.SubmitedDataGridView.Columns("totalServices").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Submission.SubmitedDataGridView.Columns("totalServices").Visible = True
        Submission.SubmitedDataGridView.Columns.Add("totalfee", "Total Fees")
        Submission.SubmitedDataGridView.Columns("totalfee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Submission.SubmitedDataGridView.Columns.Add("filename", "File Name")
        Submission.SubmitedDataGridView.Columns("filename").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Submission.SubmitedDataGridView.RowHeadersVisible = False


        Submission.UnSubmitedDataGridView.Columns.Add("month", "Month")
        Submission.UnSubmitedDataGridView.Columns("month").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Submission.UnSubmitedDataGridView.Columns.Add("year", "Year")
        Submission.UnSubmitedDataGridView.Columns("year").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Submission.UnSubmitedDataGridView.Columns.Add("totalServices", "Total Service")
        Submission.UnSubmitedDataGridView.Columns("totalServices").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Submission.UnSubmitedDataGridView.Columns("totalServices").Visible = True
        Submission.UnSubmitedDataGridView.Columns.Add("totalfee", "Total Fees")
        Submission.UnSubmitedDataGridView.Columns("totalfee").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Submission.UnSubmitedDataGridView.RowHeadersVisible = False

    End Sub
    Public Sub CreateUnsubmitedServiceList()
        Dim sql As String
        Dim objDataset As New DataSet
        Dim i As Integer

        Try

            objConn.Open()
            sql = "select  "
            sql = sql & "  "
            sql = sql & " sum(rec.num_serv) AS totalServices, "
            sql = sql & " sum(Submitted_Fee) AS totalfee "

            'sql = sql & " filename "
            ' sql = sql & " processed_date "
            sql = sql & " from processed_service_record rec "
            sql = sql + " where rec.status=0"



            ' sql = sql & " rec.filename "
            ' sql = sql & " processed_date "

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblservices")
            Submission.UnSubmitedDataGridView.Rows.Clear()

            Submission.UnSubmitedDataGridView.ReadOnly = True
            Submission.UnSubmitedDataGridView.AllowUserToAddRows = False

            Submission.UnSubmitedDataGridView.BackgroundColor = Color.LightGray
            Submission.UnSubmitedDataGridView.BorderStyle = BorderStyle.Fixed3D

            ' Set property values appropriate for read-only display and 
            ' limited interactivity. 
            Submission.UnSubmitedDataGridView.AllowUserToAddRows = False
            Submission.UnSubmitedDataGridView.AllowUserToDeleteRows = False
            Submission.UnSubmitedDataGridView.AllowUserToOrderColumns = True
            Submission.UnSubmitedDataGridView.ReadOnly = True
            Submission.UnSubmitedDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Submission.UnSubmitedDataGridView.MultiSelect = False
            Submission.UnSubmitedDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            Submission.UnSubmitedDataGridView.AllowUserToResizeColumns = False
            'Patient_frm.PatientServiceHistoryDataGrid.ColumnHeadersHeightSizeMode = _
            '    DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Submission.UnSubmitedDataGridView.AllowUserToResizeRows = False
            'Patient_frm.PatientServiceHistoryDataGrid.RowHeadersWidthSizeMode = _
            '    DataGridViewRowHeadersWidthSizeMode.DisableResizing

            ' Set the selection background color for all the cells.
            Submission.UnSubmitedDataGridView.DefaultCellStyle.SelectionBackColor = Color.White
            Submission.UnSubmitedDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black

            ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            Submission.UnSubmitedDataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

            If FormatCurrency(objDataset.Tables("tblservices").Rows(i).Item("totalfee"), 2) <> "" Then


                For i = 0 To objDataset.Tables("tblservices").Rows.Count - 1
                    Submission.UnSubmitedDataGridView.Rows.Add()

                    Submission.UnSubmitedDataGridView.Rows(i).Cells("month").Value = MonthName(Today.Month)
                    Submission.UnSubmitedDataGridView.Rows(i).Cells("year").Value = Today.Year
                    Submission.UnSubmitedDataGridView.Rows(i).Cells("totalServices").Value = objDataset.Tables("tblservices").Rows(i).Item("totalServices")
                    Submission.UnSubmitedDataGridView.Rows(i).Cells("totalfee").Value = FormatCurrency(objDataset.Tables("tblservices").Rows(i).Item("totalfee"), 2)
                Next

                Dim btn As New DataGridViewButtonColumn()
                If Submission.UnSubmitedDataGridView.ColumnCount = 4 Then
                    Submission.UnSubmitedDataGridView.Columns.Add(btn)
                End If
                btn.HeaderText = "Create File"
                btn.Text = "Create"
                btn.Name = "btn"
                btn.UseColumnTextForButtonValue = True
                Submission.UnSubmitedDataGridView.ReadOnly = True
                Submission.UnSubmitedDataGridView.AllowUserToAddRows = False
            End If

            objConn.Close()
        Catch
            objConn.Close()
        End Try
    End Sub
    Public Sub CreateSubmitedServiceList()
        Dim sql As String
        Dim objDataset As New DataSet
        Dim i As Integer

        Try

            objConn.Open()
            sql = "select "
            sql = sql & " sum(rec.num_serv) AS totalServices, "
            sql = sql & " sum(Submitted_Fee) AS totalfee, "

            sql = sql & " processed_file as filename "
            ' sql = sql & " processed_date "
            sql = sql & " from processed_service_record rec "
            sql = sql + " where rec.status=1"

            sql = sql & " group by "
      

            sql = sql & " rec.processed_file "
            ' sql = sql & " processed_date "

            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)
            objDataAdapter = New MySqlDataAdapter(sql, objConn)

            objDataAdapter.Fill(objDataset, "tblservices")
            Submission.SubmitedDataGridView.Rows.Clear()

            Submission.SubmitedDataGridView.ReadOnly = True
            Submission.SubmitedDataGridView.AllowUserToAddRows = False

            Submission.SubmitedDataGridView.BackgroundColor = Color.LightGray
            Submission.SubmitedDataGridView.BorderStyle = BorderStyle.Fixed3D

            ' Set property values appropriate for read-only display and 
            ' limited interactivity. 
            Submission.SubmitedDataGridView.AllowUserToAddRows = False
            Submission.SubmitedDataGridView.AllowUserToDeleteRows = False
            Submission.SubmitedDataGridView.AllowUserToOrderColumns = True
            Submission.SubmitedDataGridView.ReadOnly = True
            Submission.SubmitedDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Submission.SubmitedDataGridView.MultiSelect = False
            Submission.SubmitedDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            Submission.SubmitedDataGridView.AllowUserToResizeColumns = False
            'Patient_frm.PatientServiceHistoryDataGrid.ColumnHeadersHeightSizeMode = _
            '    DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Submission.SubmitedDataGridView.AllowUserToResizeRows = False
            'Patient_frm.PatientServiceHistoryDataGrid.RowHeadersWidthSizeMode = _
            '    DataGridViewRowHeadersWidthSizeMode.DisableResizing

            ' Set the selection background color for all the cells.
            Submission.SubmitedDataGridView.DefaultCellStyle.SelectionBackColor = Color.White
            Submission.SubmitedDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black

            ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            Submission.SubmitedDataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty
            Dim path As String
            Dim provider As System.Globalization.CultureInfo = System.Globalization.CultureInfo.InvariantCulture
            Dim serviceDate As DateTime

            For i = 0 To objDataset.Tables("tblservices").Rows.Count - 1
                Submission.SubmitedDataGridView.Rows.Add()
                '   Claim-Files-06-18-2012
                'serviceDate = objDataset.Tables("tblservices").Rows(i).Item("processed_date")
                path = class_OutputPath & "Claim-Files-" & serviceDate.Month.ToString & "-" & serviceDate.Day.ToString & "-" & serviceDate.Year.ToString
                'serviceDate.ToString("MM-dd-yyyy", provider)
                '"Claim-Files-" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString
                'path = path.Replace("/", "-")
                'path = path & "\" & objDataset.Tables("tblservices").Rows(i).Item("processed_file")
                'Submission.SubmitedDataGridView.Rows(i).Cells("filePath").Value = path

                'Submission.SubmitedDataGridView.Rows(i).Cells("month").Value = MonthName(objDataset.Tables("tblservices").Rows(i).Item("xMonth"))
                'Submission.SubmitedDataGridView.Rows(i).Cells("year").Value = objDataset.Tables("tblservices").Rows(i).Item("xYear")
                Submission.SubmitedDataGridView.Rows(i).Cells("totalServices").Value = objDataset.Tables("tblservices").Rows(i).Item("totalServices")
                Submission.SubmitedDataGridView.Rows(i).Cells("totalfee").Value = FormatCurrency(objDataset.Tables("tblservices").Rows(i).Item("totalfee"), 2)

                Submission.SubmitedDataGridView.Rows(i).Cells("filename").Value = objDataset.Tables("tblservices").Rows(i).Item("filename")
            Next
            Submission.SubmitedDataGridView.Columns("filePath").Visible = False




            Dim Restorebtn As New DataGridViewButtonColumn()
            Restorebtn.HeaderText = "UnSubmit Claims"
            Restorebtn.Text = "Unsubmit"
            Restorebtn.Name = "Unsubmit"
            Restorebtn.UseColumnTextForButtonValue = True
            If Submission.SubmitedDataGridView.ColumnCount = 4 Then
                Submission.SubmitedDataGridView.Columns.Add(Restorebtn)
            End If

            Submission.SubmitedDataGridView.ReadOnly = True
            Submission.SubmitedDataGridView.AllowUserToAddRows = False

            ' for later use
            Dim Restorebtn2 As New DataGridViewButtonColumn()
            Restorebtn2.HeaderText = "Uploaded to MOH"
            Restorebtn2.Text = "Upload completed"
            Restorebtn2.Name = "Upload"
            Restorebtn2.UseColumnTextForButtonValue = True
            If Submission.SubmitedDataGridView.ColumnCount = 5 Then
                Submission.SubmitedDataGridView.Columns.Add(Restorebtn2)
            End If

            Submission.SubmitedDataGridView.ReadOnly = True
            Submission.SubmitedDataGridView.AllowUserToAddRows = False




            objConn.Close()
        Catch e As Exception
            objConn.Close()
        End Try
    End Sub


    Public Function validatefile(ByVal fn As String) As Boolean
        Dim FILE_NAME As String = fn

        Dim TextLine As String
        Dim textob As String = ""
        Dim error_fil As Boolean = False
        Dim line As Integer = 0
        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objReader As New System.IO.StreamReader(FILE_NAME)

            Do While objReader.Peek() <> -1

                TextLine = objReader.ReadLine()
                If TextLine.Length = 79 Then
                Else
                    error_fil = True

                End If
                line = line + 1

            Loop


            If error_fil = True Then
                MsgBox("File has errors - Please contact support@ohip-billing.com")
            Else
                ' MsgBox("File generated to MOH guidelines 100%")
            End If
        Else



        End If
        Return error_fil
    End Function



End Class
