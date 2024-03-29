﻿Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class Form1
#Region "Declares"
    Dim connect As New DBConnection
    Dim adapter As New MySqlDataAdapter
    Dim dataTable As DataTable
    Private dragging As Boolean
    Private offsetX, offsetY As Integer

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel1.MouseDown, labelTitle.MouseDown
        If e.Button = MouseButtons.Left Then
            dragging = True
            offsetX = e.X
            offsetY = e.Y
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Panel1.MouseMove, labelTitle.MouseMove
        If dragging Then
            Dim newLocation As New Point(Me.Left + e.X - offsetX, Me.Top + e.Y - offsetY)
            Me.Location = newLocation
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Panel1.MouseUp, labelTitle.MouseUp
        If e.Button = MouseButtons.Left Then
            dragging = False
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        adapter = New MySqlDataAdapter("SELECT * FROM user WHERE email='" & TextBoxEmail.Text & "' AND password='" & TextBoxPassword.Text & "'", connect.openDB)
        dataTable = New DataTable
        dataTable.Clear()
        adapter.Fill(dataTable)
        If TextBoxEmail.Text = "Enter Email..." OrElse TextBoxPassword.Text = "Enter Password..." Then
            MsgBox("Email or Password field is empty")
        Else
            If dataTable.Rows.Count() <= 0 Then
                MsgBox("Email or Password is Wrong!")
                connect.closeDB()
            Else
                Me.Hide()
                Dim dashboard As New Dashboard()
                dashboard.Show()
            End If
        End If
    End Sub

    Private Sub ButtonLog_Paint(sender As Object, e As PaintEventArgs) Handles ButtonLogin.Paint
        Dim path As New GraphicsPath()
        Dim rect As Rectangle = ButtonLogin.ClientRectangle
        Dim radius As Integer = 40
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        ButtonLogin.Region = New Region(path)
    End Sub
    Private Sub ButtonReg_Paint(sender As Object, e As PaintEventArgs) Handles Register.Paint
        Dim path As New GraphicsPath()
        Dim rect As Rectangle = Register.ClientRectangle
        Dim radius As Integer = 20
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        Register.Region = New Region(path)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, 20, 20, 180, 90)
        path.AddArc(Me.Width - 20, 0, 20, 20, 270, 90)
        path.AddArc(Me.Width - 20, Me.Height - 20, 20, 20, 0, 90)
        path.AddArc(0, Me.Height - 20, 20, 20, 90, 90)
        Me.Region = New Region(path)

        closeButton.Image = My.Resources.close_window_30px
        minimizeButton.Image = My.Resources.minus_30px
    End Sub

    Private Sub TextBoxEmail_Enter(sender As Object, e As EventArgs) Handles TextBoxEmail.Enter
        If TextBoxEmail.Text = "Enter Email..." Then
            TextBoxEmail.Text = ""
            TextBoxEmail.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBoxEmail_Leave(sender As Object, e As EventArgs) Handles TextBoxEmail.Leave
        If TextBoxEmail.Text = "" Then
            TextBoxEmail.Text = "Enter Email..."
            TextBoxEmail.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Register.Click
        Dim registerForm As New Register()
        registerForm.Show()
        Me.Hide()
    End Sub

    Private Sub TextBoxPassword_Enter(sender As Object, e As EventArgs) Handles TextBoxPassword.Enter
        If TextBoxPassword.Text = "Enter Password..." Then
            TextBoxPassword.Text = ""
            TextBoxPassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBoxPassword_Leave(sender As Object, e As EventArgs) Handles TextBoxPassword.Leave
        If TextBoxPassword.Text = "" Then
            TextBoxPassword.Text = "Enter Password..."
            TextBoxPassword.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub minimizeButton_Click(sender As Object, e As EventArgs) Handles minimizeButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TextBoxEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEmail.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBoxPassword.Focus()
        End If
    End Sub

#End Region
End Class
