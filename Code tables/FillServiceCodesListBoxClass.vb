Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Public Class FillServiceCodesBoxClass

    Private ServiceDesc As String
    Private ServiceCode As String

    Public Sub New(ByVal strServiceDescription As String, ByVal strServiceCode As String)
        MyBase.New()
        Me.ServiceDesc = strServiceDescription
        Me.ServiceCode = strServiceCode
    End Sub

    Public ReadOnly Property listServiceDescription() As String
        Get
            Return ServiceDesc
        End Get
    End Property

    Public ReadOnly Property listServiceCode() As String
        Get
            Return ServiceCode
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.listServiceDescription & " - " & Me.listServiceCode
    End Function

    Public Sub FillServiceListBox()

    End Sub
End Class

