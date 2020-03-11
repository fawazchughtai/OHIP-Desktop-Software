Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Public Class FillDiagnosisListBoxClass
    Private DiagnosisDescription As String
    Private DiagnosisCode As String

    Public Sub New(ByVal strDescripton As String, ByVal strCode As String)
        MyBase.New()
        Me.DiagnosisDescription = strDescripton
        Me.DiagnosisCode = strCode
    End Sub

    Public ReadOnly Property listDiagnosisDescription() As String
        Get
            Return DiagnosisDescription
        End Get
    End Property

    Public ReadOnly Property listDiagnosisCode() As String
        Get
            Return DiagnosisCode
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.listDiagnosisCode & ": " & Me.listDiagnosisDescription
    End Function
End Class
