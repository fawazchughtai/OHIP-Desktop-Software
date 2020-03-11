Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class VerifySQLScript
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

    Public Sub RunScript()
        Dim strScriptFilder As String
        strScriptFilder = currPath & "\Scripts\"

        Dim dir As New System.IO.DirectoryInfo(strScriptFilder)
        Dim i As Integer = 0
        Dim strFileNameAndPath As String
        Dim strSQLCommand As String
        Dim processPath As String
        Dim provider As System.Globalization.CultureInfo = System.Globalization.CultureInfo.InvariantCulture
        Dim FileToCopy As String
        Dim NewCopy As String
        Dim logFile As String

        processPath = strScriptFilder & "Processed-Script-" & Today().ToString("MM/dd/yyyy", provider)
        processPath = processPath.Replace("/", "-")

        logFile = strScriptFilder & "Processed-Script-" & Today().ToString("MM/dd/yyyy", provider) & "\ScriptErrorLog.log"
        logFile = logFile.Replace("/", "-")






        If System.IO.File.Exists(strScriptFilder & "update.txt") Then

            OOFSL_main.update_status()
            Application.DoEvents()


            If Not System.IO.Directory.Exists(processPath) Then
                System.IO.Directory.CreateDirectory(processPath)
            End If

            Dim objWriter As New System.IO.StreamWriter(logFile)

            objConn.Open()
            myCommand.Connection = objConn
            For Each f As System.IO.FileInfo In dir.GetFiles("M*.sql")

                strFileNameAndPath = currPath & "\Scripts\" & f.Name
                Dim objReader As New System.IO.StreamReader(strFileNameAndPath)
                strSQLCommand = objReader.ReadToEnd()
                myCommand.CommandText = strSQLCommand
                Try
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objWriter.WriteLine(ex.Message)
                End Try
                objReader.Close()

                FileToCopy = strFileNameAndPath
                NewCopy = processPath & "\" & f.Name

                If System.IO.File.Exists(FileToCopy) = True Then
                    System.IO.File.Copy(FileToCopy, NewCopy, True)
                    System.IO.File.Delete(FileToCopy)
                End If

            Next f
            objConn.Close()
            If System.IO.File.Exists(strScriptFilder & "av_srv.txt") Then

                System.IO.File.Delete(strScriptFilder & "av_srv.txt")

                import_av_srv()

            End If

            If System.IO.File.Exists(strScriptFilder & "prov.txt") Then

                System.IO.File.Delete(strScriptFilder & "prov.txt")

                import_province()

            End If


            If System.IO.File.Exists(strScriptFilder & "clean.txt") Then

                System.IO.File.Delete(strScriptFilder & "clean.txt")

                clean_duplicates()

            End If

            If System.IO.File.Exists(strScriptFilder & "upgrade.txt") Then

                System.IO.File.Delete(strScriptFilder & "upgrade.txt")

                clean_duplicates()

                process_reconciliation_all()

                upgrade_7()

            End If

            If System.IO.File.Exists(strScriptFilder & "upgrade_fix.txt") Then

                System.IO.File.Delete(strScriptFilder & "upgrade_fix.txt")

                'clean_duplicates()

                'process_reconciliation_all()

                fix_upgrade()

            End If

            objConn.Open()
            myCommand.Connection = objConn
            For Each f As System.IO.FileInfo In dir.GetFiles("I*.sql")

                strFileNameAndPath = currPath & "\Scripts\" & f.Name
                Dim objReader As New System.IO.StreamReader(strFileNameAndPath)
                strSQLCommand = objReader.ReadToEnd()
                myCommand.CommandText = strSQLCommand
                Try
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objWriter.WriteLine(ex.Message)
                End Try
                objReader.Close()

                FileToCopy = strFileNameAndPath
                NewCopy = processPath & "\" & f.Name

                If System.IO.File.Exists(FileToCopy) = True Then
                    System.IO.File.Copy(FileToCopy, NewCopy, True)
                    System.IO.File.Delete(FileToCopy)
                End If

            Next f
            objConn.Close()


            objWriter.Close()



            System.IO.File.Delete(strScriptFilder & "update.txt")

            sys_update_status.Close()
        End If





    End Sub

    Public Sub import_av_srv()
        ' open connection to db 1 into dataset
        ' open connection to db 2
        Try


            Dim sdataset As New DataSet

            Dim sql As String
            Dim i As Integer
            Dim t_cn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\db\osys.mdb"


            Dim myCommand As OleDb.OleDbCommand

            Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(t_cn)
            Dim objConn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
            Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter

            'MSAccess
            objConn.Open()
            sql = "select * from available_services"
            objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)

            objDataAdapter.Fill(sdataset, "tblav_srv")

            objConn.Close()
            objConn2.Open()

            sql = "DELETE available_services.* FROM available_services;"

            myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand.ExecuteNonQuery()

            For i = 0 To sdataset.Tables("tblav_srv").Rows.Count - 1

                With sdataset.Tables("tblav_srv").Rows(i)
                    'MSAccess
                    sql = "insert into available_services (Description,ServiceCode,servicefee,Referalrequired,num_services,diagnosis,adm,facility)"
                    sql = sql + " values('" & .Item("Description").ToString.Replace("'", "''") & "',"
                    sql = sql + " '" & .Item("ServiceCode").ToString & "',"
                    sql = sql + " '" & .Item("servicefee").ToString & "',"
                    sql = sql + " '" & .Item("Referalrequired").ToString & "',"
                    sql = sql + " '" & .Item("num_services").ToString & "',"
                    sql = sql + " '" & .Item("diagnosis").ToString & "',"
                    sql = sql + " '" & .Item("adm").ToString & "',"
                    sql = sql + " '" & .Item("facility").ToString & "')"
                End With

                myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
                myCommand.ExecuteNonQuery()

            Next
            objConn2.Close()


            'update services codes with defaults
            sql = "UPDATE services INNER JOIN available_services ON services.ServiceCode = available_services.ServiceCode SET services.Description = [available_services].[Description], services.servicefee = [available_services].[servicefee], services.Referalrequired = [available_services].[Referalrequired], services.num_services = [available_services].[num_services], services.diagnosis = [available_services].[diagnosis], services.adm = [available_services].[adm], services.facility = [available_services].[facility];"
            'service_record.service_date >=format("1/12/2012",'dd/MM/yyyy');
            'MSAccess
            objConn2.Open()
            myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand.ExecuteNonQuery()
            objConn2.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub import_province()
        ' open connection to db 1 into dataset
        ' open connection to db 2
        Dim sdataset As New DataSet

        Dim sql As String
        Dim i As Integer
        Dim t_cn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\db\osys.mdb"


        Dim myCommand As OleDb.OleDbCommand

        Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(t_cn)
        Dim objConn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter

        'MSAccess
        objConn.Open()
        sql = "select * from province_lkup"
        objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)

        objDataAdapter.Fill(sdataset, "tblprov")

        objConn.Close()
        objConn2.Open()

        sql = "DELETE * FROM cdprovince;"

        myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
        myCommand.ExecuteNonQuery()

        For i = 0 To sdataset.Tables("tblprov").Rows.Count - 1

            With sdataset.Tables("tblprov").Rows(i)
                'MSAccess
                sql = "insert into cdprovince (provname,provcode)"
                sql = sql + " values('" & .Item("provname").ToString & "',"
                sql = sql + " '" & .Item("provcode").ToString & "')"
            End With

            myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand.ExecuteNonQuery()

        Next
        objConn2.Close()
    End Sub

    Public Sub import_status()
        ' open connection to db 1 into dataset
        ' open connection to db 2
        Dim sdataset As New DataSet

        Dim sql As String
        Dim i As Integer
        Dim t_cn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\db\osys.mdb"


        Dim myCommand As OleDb.OleDbCommand

        Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(t_cn)
        Dim objConn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter

        'MSAccess
        objConn.Open()
        sql = "select * from status_lkup"
        objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)

        objDataAdapter.Fill(sdataset, "tblstatus")

        objConn.Close()
        objConn2.Open()

        sql = "DELETE * FROM status_lkup"

        myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
        myCommand.ExecuteNonQuery()

        For i = 0 To sdataset.Tables("tblstatus").Rows.Count - 1

            With sdataset.Tables("tblstatus").Rows(i)
                'MSAccess
                sql = "insert into status_lkup (status,status_desc)"
                sql = sql + " values('" & .Item("status").ToString & "',"
                sql = sql + " '" & .Item("status_desc").ToString & "')"
            End With

            myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand.ExecuteNonQuery()

        Next
        objConn2.Close()
    End Sub

    Public Sub import_error()
        ' open connection to db 1 into dataset
        ' open connection to db 2
        Dim sdataset As New DataSet

        Dim sql As String
        Dim i As Integer
        Dim t_cn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\db\osys.mdb"


        Dim myCommand As OleDb.OleDbCommand

        Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(t_cn)
        Dim objConn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
        Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter

        'MSAccess
        objConn.Open()
        sql = "select * from error_lkup"
        objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql, objConn)

        objDataAdapter.Fill(sdataset, "tblerror")

        objConn.Close()
        objConn2.Open()

        sql = "DELETE * FROM errorcodes"

        myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
        myCommand.ExecuteNonQuery()

        For i = 0 To sdataset.Tables("tblerror").Rows.Count - 1

            With sdataset.Tables("tblerror").Rows(i)
                'MSAccess
                sql = "insert into errorcodes (code,description)"
                sql = sql + " values('" & .Item("code").ToString & "',"
                sql = sql + " '" & .Item("description").ToString & "')"
            End With

            myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand.ExecuteNonQuery()

        Next
        objConn2.Close()
    End Sub

    Public Sub clean_duplicates()

        Dim objDataset As New DataSet

        Dim sql As String

        objConn.Close()
        Try
            'Archive old records past 6 month



            'sql = "UPDATE processed_service_record SET status = 6 where status <6 and service_date<#" & Format(DateAdd(DateInterval.Month, -6, Today()), "dd/MM/yyyy") & "#"
            sql = "UPDATE processed_service_record SET status = 6 where status <6 and service_date<'" & Format(DateAdd(DateInterval.Month, -6, Today()), "yyyy-MM-dd") & "'"


            'SELECT * FROM MyTable  Format(Service_picker.Value, "dd/MMM/yyyy")
            'WHERE MyDate < DateAdd(Month, -2, GETDATE())

            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            Claim_management.Refresh_tree()

        Catch ex As Exception
            objConn.Close()
        End Try

    End Sub

    Public Sub upgrade_7()
        Dim objDataset As New DataSet

        Dim sql As String

        Try

            If OOFSL_main.backup_db() = True Then

                ' move old service to processed services
                sql = ""
                sql = "insert into processed_service_record (source_id,patient_id,service_date,service_code,referral,service_fee,num_serv,lc,dx,facility_num,adm_date,status,processed_date)"
                sql = sql + " SELECT id,patient_id,service_date,service_code,referral,service_fee,num_serv,lc,dx,facility_num,adm_date,0,format(now(),'dd/MM/yyyy')"
                sql = sql + " FROM service_record  "
                sql = sql + " WHERE status=0 and service_record.[patient_id] <> -1"
                sql = sql + " ORDER BY id, service_record.service_date;"

                'service_record.service_date >=format("1/12/2012",'dd/MM/yyyy');
                'MSAccess
                objConn.Open()
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                objConn.Close()


                sql = ""
                sql = "drop table service_record"

                'service_record.service_date >=format("1/12/2012",'dd/MM/yyyy');
                'MSAccess
                objConn.Open()
                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
                myCommand = New MySqlCommand(sql, objConn)
                myCommand.ExecuteNonQuery()
                objConn.Close()





            End If

            'update services codes with defaults
            sql = "UPDATE services INNER JOIN available_services ON services.ServiceCode = available_services.ServiceCode SET services.Description = [available_services].[Description], services.servicefee = [available_services].[servicefee], services.Referalrequired = [available_services].[Referalrequired], services.num_services = [available_services].[num_services], services.diagnosis = [available_services].[diagnosis], services.adm = [available_services].[adm], services.facility = [available_services].[facility];"
            'service_record.service_date >=format("1/12/2012",'dd/MM/yyyy');
            'MSAccess
            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()



            ' update totals
            sql = ""
            sql = "UPDATE processed_service_record SET processed_service_record.Submitted_Fee = cdbl(processed_service_record.service_fee*processed_service_record.num_serv);"

            'service_record.service_date >=format("1/12/2012",'dd/MM/yyyy');
            'MSAccess
            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()


            ' remove deleted patient & services
            sql = ""
            sql = "UPDATE processed_service_record LEFT JOIN patients ON processed_service_record.patient_id = patients.id SET processed_service_record.status = 7 WHERE patients.id Is Null;"

            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()


            ' create claims that are not deleted filename,   processed_service_record.processed_file AS filename,  processed_service_record.processed_file,
            sql = ""
            sql = "INSERT INTO claims ( p_id, service_date,filename,  total_services, total_submitted, status )"
            sql = sql + " SELECT DISTINCT processed_service_record.patient_id AS p_id, processed_service_record.service_date AS service_date,processed_service_record.processed_file AS filename,  Sum(processed_service_record.num_serv) AS total_services, Sum(processed_service_record.Submitted_Fee) AS total_submitted, processed_service_record.status AS status"
            sql = sql + " FROM processed_service_record where status<6"
            sql = sql + " GROUP BY processed_service_record.patient_id, processed_service_record.service_date, processed_service_record.processed_file, processed_service_record.status;"

            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()




            'update processed with claim_id
            sql = ""
            sql = "UPDATE Claims INNER JOIN processed_service_record ON (Claims.Status = processed_service_record.status) AND (Claims.p_id = processed_service_record.patient_id) AND (Claims.service_date = processed_service_record.service_date) SET processed_service_record.source_id = [claims].[ID];"

            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()



            ' removed deleted claims if patients where deleted
            sql = "UPDATE Claims LEFT JOIN patients ON Claims.p_id = patients.id SET Claims.Status = 7 WHERE (((patients.id) Is Null));"
            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()





            import_province()

            import_error()

            import_status()


        Catch ex As Exception
            objConn.Close()
        End Try
    End Sub

    Public Sub fix_upgrade()
        Dim objDataset As New DataSet

        Dim sql As String

        Try

            'Delete claims and re-generate
            sql = "delete * from claims"
            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()


            ' update totals
            sql = ""
            sql = "UPDATE processed_service_record SET processed_service_record.source_id = null, processed_service_record.Submitted_Fee = cdbl(processed_service_record.service_fee*processed_service_record.num_serv);"

            'service_record.service_date >=format("1/12/2012",'dd/MM/yyyy');
            'MSAccess
            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()


            ' remove deleted patient & services
            sql = ""
            sql = "UPDATE processed_service_record LEFT JOIN patients ON processed_service_record.patient_id = patients.id SET processed_service_record.status = 7 WHERE patients.id Is Null;"

            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()


            ' create claims that are not deleted filename,   processed_service_record.processed_file AS filename,  processed_service_record.processed_file,
            sql = ""
            sql = "INSERT INTO claims ( p_id, service_date, processed_srv_header_id, status )"
            sql = sql + " SELECT processed_service_record.patient_id, processed_service_record.service_date,processed_service_record.id, processed_service_record.status "
            sql = sql + " FROM processed_service_record"
            'sql = sql + " GROUP BY processed_service_record.patient_id, processed_service_record.service_date, processed_service_record.processed_file, processed_service_record.status;"

            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()




            'update processed with claim_id
            sql = ""


            sql = "UPDATE claims INNER JOIN processed_service_record ON claims.processed_srv_header_id = "
            sql = sql & " processed_service_record.id SET processed_service_record.source_id = [claims].[id];"

            objConn.Open()
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            myCommand.ExecuteNonQuery()
            objConn.Close()


            import_province()

            import_error()

            import_status()


        Catch ex As Exception
            MsgBox("Error in update please contact OHIP-BILLING Tech-support 1-877-358-7339 ext 2")
            objConn.Close()
        End Try
    End Sub

    Public Sub process_reconciliation_all()
        Dim objDataset As New DataSet

        Dim sql As String

        objConn.Close()
        Try

            sql = " UPDATE reconciliationheaderrecord SET reconciliationheaderrecord.status = null"

            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()

            Claim_management.Refresh_tree()

        Catch ex As Exception
            objConn.Close()
        End Try



    End Sub

    Private Sub all_reprocess()
        Try
            'Dim myCommand As New System.Data.OleDb.OleDbCommand

            'Dim myData As DataSet = New DataSet
            'Dim objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
            'Dim objConn2 As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
            'Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter

            Dim myCommand As New MySqlCommand
            Dim myData As DataSet = New DataSet
            Dim objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
            Dim objConn2 As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
            Dim objDataAdapter As MySqlDataAdapter

            Dim sql2 As String = ""
            Dim sql As String = ""

            Dim mydata1 As New DataSet

            sql = " UPDATE reconciliationheaderrecord SET reconciliationheaderrecord.status = null"

            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn)
            myCommand = New MySqlCommand(sql, objConn)
            objConn.Open()
            myCommand.ExecuteNonQuery()
            objConn.Close()


            'sql to tie reconcilliation
            sql2 = "SELECT distinct processed_service_record.id as p_id,cdbl('0' & reconciliationclaimitem.AmountPaid) as amt_paid, reconciliationclaimitem.ExplanatoryCode as error, reconciliationclaimitem.claimnumber as claim_num"
            sql2 = sql2 + " FROM reconciliationheaderrecord, ReconciliationClaimHeader, ReconciliationClaimItem, processed_service_record, patients"
            sql2 = sql2 + " WHERE ReconciliationClaimHeader.ClaimNumber = [ReconciliationClaimItem].[ClaimNumber]"
            sql2 = sql2 + " and patients.id=processed_service_record.patient_id"
            sql2 = sql2 + " and processed_service_record.service_date=cdate(Left([reconciliationclaimitem.ServiceDate],4) & ' / ' & Mid([reconciliationclaimitem.ServiceDate],5,2) & ' / ' & Right([reconciliationclaimitem.ServiceDate],2) )"
            sql2 = sql2 + " and processed_service_record.service_code = ReconciliationClaimItem.ServiceCode"
            sql2 = sql2 + " and patients.ohip = ReconciliationClaimHeader.HealthRegistrationNumber"
            sql2 = sql2 + " and patients.Version = ReconciliationClaimHeader.VersionCode"
            sql2 = sql2 + " and ReconciliationClaimItem.filename = ReconciliationClaimHeader.FileName"
            sql2 = sql2 + " and reconciliationheaderrecord.filename=ReconciliationClaimHeader.FileName"
            sql2 = sql2 + " and processed_service_record.Status in (1,2,4,5,6)"

            objConn.Open()
            'objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sql2, objConn)
            objDataAdapter = New MySqlDataAdapter(sql2, objConn)
            objDataAdapter.Fill(mydata1, "tblrecon")



            For Each R1 As DataRow In mydata1.Tables("tblrecon").Rows


                'if explanatorycode="" and amt_paid>0 then paid Reconciled (Status=3)

                'SQL to update processed record - Paid
                If R1("error").ToString = "35" Or R1("amt_paid").ToString > 0 Then
                    sql = "UPDATE processed_service_record SET Status = 3, AmountPaid='" & R1("amt_paid").ToString & "', ExplanatoryCode='" & R1("error").ToString & "',claim_num='" & R1("claim_num").ToString & "'"
                    sql = sql + " where processed_service_record.id=" & R1("p_id").ToString
                Else
                    sql = "UPDATE processed_service_record SET Status = 4, AmountPaid='" & R1("amt_paid").ToString & "', ExplanatoryCode='" & R1("error").ToString & "',claim_num='" & R1("claim_num").ToString & "'"
                    sql = sql + " where processed_service_record.id=" & R1("p_id").ToString

                End If

                'else possible error Error (Status=4)



                'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
                myCommand = New MySqlCommand(sql, objConn2)
                objConn2.Open()
                myCommand.ExecuteNonQuery()
                objConn2.Close()
                ' update processed_Record status with error(3)

            Next

            'update claim record
            sql = "UPDATE claims INNER JOIN processed_service_record ON claims.id = processed_service_record.source_id SET claims.status = [processed_service_record].[status];"
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand = New MySqlCommand(sql, objConn2)
            objConn2.Open()
            myCommand.ExecuteNonQuery()
            objConn2.Close()

            objConn.Close()

            'header update
            sql = "UPDATE reconciliationheaderrecord SET Status = 1"
            'myCommand = New System.Data.OleDb.OleDbCommand(sql, objConn2)
            myCommand = New MySqlCommand(sql, objConn2)
            objConn2.Open()
            myCommand.ExecuteNonQuery()
            objConn2.Close()

            objConn.Close()
            Claim_management.Refresh_tree()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
End Class
