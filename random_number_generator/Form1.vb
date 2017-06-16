Public Class Form1

    Dim start_num As Double
    Dim end_num As Double
    Dim digit As Int16
    Dim total_nums As Int64
    Dim result As Double
    Dim i As Int16
    Dim temp As String
    Dim final As String
    Dim generate As Boolean

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        final = ""
        temp = ""

        generate = True

        'MsgBox(Val(ComboBox2.Text))
        start_num = Val(ComboBox2.Text)
        If ((start_num < 0) Or (start_num > 65535)) Then
            MsgBox("暂不支持的起始值：" & start_num)
            generate = False
        End If

        end_num = Val(ComboBox3.Text)
        If ((end_num <= 0) Or (end_num > 65535)) Then
            MsgBox("暂不支持的结束值：" & end_num)
            generate = False
        End If

        If (end_num <= start_num) Then
            MsgBox("请保证结束值大于起始值")
            generate = False
        End If

        digit = Val(ComboBox4.Text)
        If ((digit < 0) Or (digit > 4)) Then
            MsgBox("精度太高，臣妾做不到：" & digit)
            generate = False
        End If

        total_nums = Val(ComboBox1.Text)
        If ((total_nums <= 0) Or (total_nums > 65535)) Then
            MsgBox("我不会生成这么多：" & total_nums)
            generate = False
        End If

        If (generate = True) Then
            Randomize()
            For i = 0 To (total_nums - 1)
                result = ((start_num - end_num + 1) * Rnd() + end_num)
                'result = round(result,digit)
                If (digit = 0) Then
                    temp = Format(result, "#")
                ElseIf (digit = 1) Then
                    temp = Format(result, "#.0")
                ElseIf (digit = 2) Then
                    'MsgBox(Format(123.45, "0000.000"))
                    temp = Format(result, "#.00")
                    'MsgBox(result)
                ElseIf (digit = 3) Then
                    temp = Format(result, "#.000")
                ElseIf (digit = 4) Then
                    temp = Format(result, ".0000")
                End If

                If (i <> (total_nums - 1)) Then
                    final = final & temp & Chr(9)
                Else
                    final = final & temp
                End If
                'MsgBox(final)
            Next
            RichTextBox1.Text = final
        End If



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Clipboard.Clear()
        Clipboard.SetText(RichTextBox1.Text)
        MsgBox("生成框内内容已复制至剪切板，在目标位置粘贴即可")
    End Sub
End Class
