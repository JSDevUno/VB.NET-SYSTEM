Imports MySql.Data.MySqlClient

Public Class DBConnection
    Dim connectionString As String = "server=localhost;user=root;password=;database=system"
    Dim connection As New MySqlConnection(connectionString)

    Public Function open() As MySqlConnection
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox("Error opening database connection: " & ex.Message)
        End Try
        Return connection
    End Function

    Public Function close() As MySqlConnection
        Try
            connection.Close()
        Catch ex As Exception
            MsgBox("Error closing database connection: " & ex.Message)
        End Try
        Return connection
    End Function
End Class
