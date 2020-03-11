Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Public Class FillReferralListBoxClass
    Private PhysicianName As String
    Private ReferralCode As String

    Public Sub New(ByVal strPhysicianName As String, ByVal strReferralCode As String)
        MyBase.New()
        Me.PhysicianName = strPhysicianName
        Me.ReferralCode = strReferralCode
    End Sub

    Public ReadOnly Property listPhysicianName() As String
        Get
            Return PhysicianName
        End Get
    End Property

    Public ReadOnly Property listReferralCode() As String
        Get
            Return ReferralCode
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.listPhysicianName & " - " & Me.listReferralCode
    End Function
End Class
