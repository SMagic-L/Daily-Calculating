Module Module1
    Public ran As System.Random
    Sub Main()
        Try
            'Declaration and initialization
            Console.Title = "笔算天天练 By SMagic"
            ran = New System.Random


            'Get Input Choice
            Console.WriteLine("请选择模式，按回车键确认")
            Console.WriteLine("(1)四则运算")
            Console.WriteLine("(2)圆锥曲线-->椭圆联立直线-->方程、Δ、韦达定理")
            Console.WriteLine("(3)立体几何-->法向量")
            Console.WriteLine("(4)虚数四则运算-->虚数除法")

            Dim input As Integer = Console.ReadLine()
            Select Case input
                Case 1
                    Console.Clear()
                    M_Arithmatic()
                Case 2
                    Console.Clear()
                    M_ConicHardSolve()
                Case 3
                    Console.Clear()
                    M_SolidNormalVerctor()
                Case Else
                    MsgBox("暂未开放，敬请期待！",, "提示")
            End Select


        Catch ex As Exception
            MsgBox(ex.ToString,, "错误")
            End
        End Try
    End Sub

    Sub M_Arithmatic()

        'declaration 
        Dim numA, numB, numAnswer As Integer
        Dim questionString As String
        Dim arithType As Integer '输入的运算类型
        Dim numberLength(1) As Integer
        Dim t1, t2 As Date


        'select arithmatic type
        Console.WriteLine("请选择运算类型")
        Console.WriteLine("1. 加法")
        Console.WriteLine("2. 减法")
        Console.WriteLine("3. 乘法")
        Console.WriteLine("4. 除法")
        arithType = Console.ReadLine

        'select munber length
        Console.Clear()
        Console.WriteLine("请输入两个数字的位数(9以内)，分两行输入")
        Console.WriteLine("加法与乘法的两个位数指定问题的位数")
        Console.WriteLine("减法与除法的第一个位数指定答案的位数")

        numberLength(0) = Console.ReadLine
        numberLength(1) = Console.ReadLine


        'generate questions and answers
        Do
            Select Case arithType
                Case 1
                    numA = ran.Next(10 ^ (numberLength(0) - 1), 10 ^ numberLength(0) - 1)
                    numB = ran.Next(10 ^ (numberLength(1) - 1), 10 ^ numberLength(1) - 1)
                    numAnswer = numA + numB
                    questionString = numA.ToString & " + " & numB.ToString
                Case 2
                    numAnswer = ran.Next(10 ^ (numberLength(0) - 1), 10 ^ numberLength(0) - 1)
                    numB = ran.Next(10 ^ (numberLength(1) - 1), 10 ^ numberLength(1) - 1)
                    numA = numB + numAnswer
                    questionString = numA.ToString & " - " & numB.ToString
                Case 3
                    numA = ran.Next(10 ^ (numberLength(0) - 1), 10 ^ numberLength(0) - 1)
                    numB = ran.Next(10 ^ (numberLength(1) - 1), 10 ^ numberLength(1) - 1)
                    numAnswer = numA * numB
                    questionString = numA.ToString & " * " & numB.ToString
                Case 4
                    numAnswer = ran.Next(10 ^ (numberLength(0) - 1), 10 ^ numberLength(0) - 1)
                    numB = ran.Next(10 ^ (numberLength(1) - 1), 10 ^ numberLength(1) - 1)
                    numA = numAnswer * numB
                    questionString = numA.ToString & " / " & numB.ToString
                Case Else
                    MsgBox("输入错误",, "提示")
                    End
            End Select
            Console.WriteLine(questionString)
            t1 = Now
            MsgBox("点击确认显示答案",, "提示")
            t2 = Now
            Console.WriteLine(numAnswer.ToString & "  |  用时" & Math.Ceiling((t2 - t1).TotalSeconds) & "s")
            MsgBox("点击确认显示下一题",, "提示")
            Console.WriteLine()
        Loop


    End Sub   '四则运算

    Sub M_ConicHardSolve()
        'declaration
        Dim a, b, t As Integer
        Dim fA As String   '表示a2k2 + b2 的字符串
        Dim t1, t2 As Date
        Dim s As Double


        Do
            s = ran.NextDouble
            If s >= 0.5 Then
                a = ran.Next(1, 5) : b = ran.Next(1, 5) : t = ran.Next(-b, b)
                fA = "(" & (a * a) & "k^2 + " & (b * b) & ")"
                Console.WriteLine("y = kx + " & t.ToString)
                Console.WriteLine("x^2 / " & (a * a).ToString & " + y^2 / " & (b * b).ToString & " = 1")
                t1 = Now
                MsgBox("点击确认显示答案",, "提示")
                t2 = Now
                Console.WriteLine()
                Console.WriteLine(fA & "x^2 + " & (2 * t * a * a).ToString & "kx + " & (a * a * (t * t - b * b)).ToString & " = 0")
                Console.WriteLine("Δ = " & (4 * a * a * b * b) & "(" & (a * a) & "k^2 + " & (-t * t + b * b) & ")")
                Console.WriteLine("x1 + x2 = " & (-2 * a * a * t) & "k / " & fA)
                Console.WriteLine("x1 * x2 = " & (a * a * (t * t - b * b)).ToString & " / " & fA)
                Console.WriteLine("y1 + y2 = " & (2 * b * b * t) & " / " & fA)
                Console.WriteLine("y1 * y2 = " & (b * b) & "(" & (t * t).ToString & " + " & (-1 * a * a) & "k^2) / " & fA)
                Console.WriteLine()
                Console.WriteLine("用时" & Math.Ceiling((t2 - t1).TotalSeconds) & "s")
                Console.WriteLine("===================================")
                MsgBox("点击确认显示下一题",, "提示")
            Else
                a = ran.Next(1, 5) : b = ran.Next(1, 5) : t = ran.Next(-a, a)
                fA = "(" & (a * a) & "m^2 + " & (b * b) & ")"
                Console.WriteLine("x = my + " & t.ToString)
                Console.WriteLine("y^2 / " & (a * a).ToString & " + x^2 / " & (b * b).ToString & " = 1")
                t1 = Now
                MsgBox("点击确认显示答案",, "提示")
                t2 = Now
                Console.WriteLine()
                Console.WriteLine(fA & "y^2 + " & (2 * t * a * a).ToString & "my + " & (a * a * (t * t - b * b)).ToString & " = 0")
                Console.WriteLine("Δ = " & (4 * a * a * b * b) & "(" & (a * a) & "m^2 + " & (-t * t + b * b) & ")")
                Console.WriteLine("y1 + y2 = " & (-2 * a * a * t) & "m / " & fA)
                Console.WriteLine("y1 * y2 = " & (a * a * (t * t - b * b)).ToString & " / " & fA)
                Console.WriteLine("x1 + x2 = " & (2 * b * b * t) & " / " & fA)
                Console.WriteLine("x1 * x2 = " & (b * b) & "(" & (t * t).ToString & " + " & (-1 * a * a) & "m^2) / " & fA)
                Console.WriteLine()
                Console.WriteLine("用时" & Math.Ceiling((t2 - t1).TotalSeconds) & "s")
                Console.WriteLine("===================================")
                MsgBox("点击确认显示下一题",, "提示")
            End If
        Loop

    End Sub  '圆锥曲线硬解定理

    Sub M_SolidNormalVerctor()
        'deciaration
        Dim A(2), B(2), C(2) As Integer
        Dim i As Integer
        Dim x1, x2, y1, y2, z1, z2 As Integer
        Dim t1, t2 As Date

        Do
            For i = 0 To 2
                A(i) = ran.Next(1, 6)
                B(i) = ran.Next(1, 6)
                C(i) = ran.Next(1, 6)
            Next
            Console.WriteLine("A(" & A(0) & "," & A(1) & "," & A(2) & ")  " & "B(" & B(0) & "," & B(1) & "," & B(2) & ")  " & "C(" & C(0) & "," & C(1) & "," & C(2) & ")  ")
            x1 = B(0) - A(0) : y1 = B(1) - A(1) : z1 = B(2) - A(2)
            x2 = C(0) - A(0) : y2 = C(1) - A(1) : z2 = C(2) - A(2)
            t1 = Now
            MsgBox("点击确认显示答案",, "提示")
            t2 = Now
            Console.WriteLine()
            Console.WriteLine("AB = (" & x1 & "," & y1 & "," & z1 & ")")
            Console.WriteLine("AC = (" & x2 & "," & y2 & "," & z2 & ")")
            Console.WriteLine("CB = (" & (x1 - x1) & "," & (y1 - y2) & "," & (z1 - z2) & ")")
            Console.WriteLine("n = (" & (y1 * z2 - y2 * z1) & "," & (z1 * x2 - z2 * x1) & "," & (x1 * y2 - x2 * y1) & ")")
            Console.WriteLine()
            Console.WriteLine("用时" & Math.Ceiling((t2 - t1).TotalSeconds) & "s")
            Console.WriteLine("========================================")
            MsgBox("点击确认显示下一题",, "提示")
        Loop

    End Sub   '立体几何法向量

    Sub M_ImaginaryDivide()

    End Sub


End Module

