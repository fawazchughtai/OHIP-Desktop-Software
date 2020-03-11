Public Class patient_obj
    Public firstname As String
    Public lastname As String
    Public health_num As String
    Public version_code As String
    Public sex As String
    Public dob As Date
    Public health_exp As Date
    Public health_issue As Date
    Public lang_pref As String

    Public Sub clear()
        firstname = Nothing
        lastname = Nothing
        health_exp = Nothing
        health_num = Nothing
        version_code = Nothing
        dob = Nothing
        sex = Nothing
        health_issue = Nothing
        lang_pref = Nothing
    End Sub
End Class
