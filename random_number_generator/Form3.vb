Imports System.ComponentModel

Public Class Form3
    Private _check_stat As Boolean




    Public Property Check_stat As Boolean
        Get
            Return _check_stat
        End Get
        Set(value As Boolean)
            _check_stat = value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Check_stat = CheckBox1.CheckState
        Visible = False
    End Sub
End Class