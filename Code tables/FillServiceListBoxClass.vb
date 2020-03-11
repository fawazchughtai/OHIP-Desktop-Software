Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Public Class FillServiceListBoxClass

    Private ServiceDesc As String
    Private ServiceID As String

    Public Sub New(ByVal strServiceDescription As String, ByVal strServiceID As String)
        MyBase.New()
        Me.ServiceDesc = strServiceDescription
        Me.ServiceID = strServiceID
    End Sub

    Public ReadOnly Property listServiceDescription() As String
        Get
            Return ServiceDesc
        End Get
    End Property

    Public ReadOnly Property listServiceID() As String
        Get
            Return ServiceID
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.listServiceDescription & " - " & Me.listServiceID
    End Function

    Public Sub FillServiceListBox()

    End Sub
End Class


