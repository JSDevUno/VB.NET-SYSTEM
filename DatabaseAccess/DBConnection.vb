Imports MySql.Data.MySqlClient

Public Class DBConnection
    Dim connectionString As String = "server=localhost;user=root;password=;database=system"
    Dim connection As New MySqlConnection(connectionString)

    Public Function openDB() As MySqlConnection
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
        Catch ex As Exception
            MsgBox("Error opening database connection: " & ex.Message)
        End Try
        Return connection
    End Function

    Public Sub closeDB()
        Try
            If connection.State <> ConnectionState.Closed Then
                connection.Close()
            End If
        Catch ex As Exception
            MsgBox("Error closing database connection: " & ex.Message)
        End Try
    End Sub
End Class
