Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class CommonClass
    ' MSAccess
    'Private OOFSL_main.sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & currPath & "\Db\oofsl.mdb"
    'Private myCommand As New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private myAdapter As System.Data.OleDb.OleDbDataAdapter
    'Private myData As DataSet = New DataSet
    'Private objConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(OOFSL_main.sConnectionString)
    'Private objDataAdapter As System.Data.OleDb.OleDbDataAdapter
    Private myCommand As New MySqlCommand
    Private myAdapter As MySqlDataAdapter
    Private myData As DataSet = New DataSet
    Private objConn As MySqlConnection = New MySqlConnection(OOFSL_main.sConnectionString)
    Private objDataAdapter As MySqlDataAdapter





    Public Function IsConnectionAvailable() As Boolean
        ' Returns True if connection is available 
        ' Replace www.yoursite.com with a site that
        ' is guaranteed to be online - perhaps your 
        ' corporate site, or microsoft.com
        Dim objUrl As New System.Uri("http://www.ohip-billing.com/")
        ' Setup WebRequest
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse
        Try
            ' Attempt to get response and return True
            objResp = objWebReq.GetResponse
            objResp.Close()
            objWebReq = Nothing
            Return True
        Catch ex As Exception
            ' Error, exit and return False
            objWebReq = Nothing
            Return False
        End Try
    End Function

End Class
