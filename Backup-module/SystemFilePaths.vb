Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class SystemFilePaths
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

    Private Sub BackupBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupBtn.Click
        Try


            Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
            ' Description that displays above the dialog box control. 

            MyFolderBrowser.Description = "Select the Folder"
            ' Sets the root folder where the browsing starts from 
            MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
            Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

            If dlgResult = Windows.Forms.DialogResult.OK Then
                Me.BackupFolder.Text = MyFolderBrowser.SelectedPath
            End If

        Catch ex As Exception
            MsgBox("Error in module backup Error 1")
        End Try
    End Sub
    Private Sub SystemFilePaths_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackupFolder.Text = strBackupFolder
        Catch ex As Exception
            MsgBox("Error in module backup Error 1")
        End Try
    End Sub

    Private Sub Savebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Savebtn.Click
        Try


            strBackupFolder = Me.BackupFolder.Text


            Dim sql As String
            Try
                objConn.Open()

                sql = "UPDATE config SET config.fieldvalue ='" & strBackupFolder & "' where config.fieldname='backup_path'"

                myCommand.Connection = objConn
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Error Occured in backup module")
            Finally
                objConn.Close()
            End Try


            Me.Close()

        Catch ex As Exception
            MsgBox("Error in module backup Error 2")
        End Try

    End Sub

End Class