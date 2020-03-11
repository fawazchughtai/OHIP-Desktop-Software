Module CommonVariables
    Public patient_frm_m As Boolean
    Public dates_frm_m As Boolean
    Public services_frm_m As Boolean
    Public referral_frm_m As Boolean
    Public Diagnosis_frm_m As Boolean
    Public current_patient As Integer
    Public current_service As Integer
    Public current_referral As Integer
    Public current_servicecode As Integer
    Public current_diagnosiscode As Integer
    Public currPath As String = Environment.CurrentDirectory()

    Public strBackupFolder As String = currPath & "\backup\BackupFolder\"
    Public strReturnFileFolder As String = currPath & "\inputFiles\"
    Public strSubmissionFileFolder As String = currPath & "\OutputFiles\"
    Public closeActivation As Boolean = False
    Public tabCancled As Boolean = False

End Module
