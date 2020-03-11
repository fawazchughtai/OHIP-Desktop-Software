Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Public Class FillSpecialtyListBoxClass
    Private SpecialtyDescription As String
    Private SpecialtyCode As String

    Public Sub New(ByVal strDescripton As String, ByVal strCode As String)
        MyBase.New()
        Me.SpecialtyDescription = strDescripton
        Me.SpecialtyCode = strCode
    End Sub

    Public ReadOnly Property listSpecialtyDescription() As String
        Get
            Return SpecialtyDescription
        End Get
    End Property

    Public ReadOnly Property listSpecialtyCode() As String
        Get
            Return SpecialtyCode
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.listSpecialtyCode & ": " & Me.listSpecialtyDescription
    End Function
End Class
