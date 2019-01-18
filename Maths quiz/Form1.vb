Public Class Form1
    Private Const V1 As String = " seconds"
    Private Const V2 As Integer = 30

    ' Create a Random object called randomizer 
    ' to generate random numbers.
    Private randomizer As New Random

    ' These integer variables store the numbers 
    ' for the addition problem. 
    Private addend1 As Integer
    Private addend2 As Integer

    ' These integer variables store the numbers 
    ' for the subtraction problem. 
    Private minuend As Integer
    Private subtrahend As Integer

    'These integer variables store the numbers 
    ' for the multiplication problem. 
    Private multiplicand As Integer
    Private multiplier As Integer

    ' These integer variables store the numbers 
    ' for the division problem. 
    Private dividend As Integer
    Private divisor As Integer

    ' This integer variable keeps track of the 
    ' remaining time.
    Private timesleft As Integer

    ''' <summary>
    ''' Start the quiz by filling in all of the problem 
    ''' values and starting the timer. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartTheQuiz()

        ' Fill in the addition problem.
        ' Generate two random numbers to add.
        ' Store the values in the variables 'addend1' and 'addend2'.
        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)

        ' Convert the two randomly generated numbers
        ' into strings so that they can be displayed
        ' in the label controls.
        plusLeftLabel.Text = addend1.ToString()
        plusRightLabel.Text = addend2.ToString()

        ' 'sum' is the name of the NumericUpDown control.
        ' This step makes sure its value is zero before
        ' adding any values to it.
        Sum.Value = 0


        ' Fill in the subtraction problem.
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        minusLeftLabel.Text = minuend.ToString()
        minusRightLabel.Text = subtrahend.ToString()
        difference.Value = 0

        ' Fill in the multiplication problem.
        multiplicand = randomizer.Next(2, 11)
        multiplier = randomizer.Next(2, 11)
        timeleft.Text = multiplicand.ToString()
        timesRightLabel.Text = multiplier.ToString()
        product.Value = 0

        ' Fill in the division problem.
        divisor = randomizer.Next(2, 11)
        Dim temporaryQuotient As Integer = randomizer.Next(2, 11)
        dividend = divisor * temporaryQuotient
        dividedLeftLabel.Text = dividend.ToString()
        dividedRightLabel.Text = divisor.ToString()
        quotient.Value = 0


        ' Start the timer.

        timeLabel.Text = "30 seconds"
        Timer1.Start()

    End Sub


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles difference.ValueChanged

    End Sub

    Private Sub NumericUpDown1_ValueChanged_1(sender As Object, e As EventArgs) Handles product.ValueChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        ' Call the StartTheQuiz() method and enable
        ' the Start button. 

        StartTheQuiz()
        startButton.Enabled = False



    End Sub
    ''' <summary>
    ''' Check the answers to see if the user got everything right.
    ''' </summary>
    ''' <returns>True if the answer's correct, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function CheckTheAnswer() As Boolean

        If addend1 + addend2 = Sum.Value AndAlso
       minuend - subtrahend = difference.Value AndAlso
       multiplicand * multiplier = product.Value AndAlso
       dividend / divisor = quotient.Value Then


            Return True
        Else
            Return False
        End If

    End Function
    ''' <summary> 
    ''' Modify the behavior of the NumericUpDown control
    ''' to make it easier to enter numeric values for
    ''' the quiz.
    ''' </summary> 
    Private Sub answer_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sum.Enter, difference.Enter, product.Enter, quotient.Enter

        ' Select the whole answer in the NumericUpDown control.
        Dim answerBox = TryCast(sender, NumericUpDown)

        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If

    End Sub


    Private Sub Timer1_Tick() Handles Timer1.Tick

        If timesleft <= 0 Then
            ' If the user ran out of time, stop the timer, show
            ' a MessageBox, and fill in the answers.
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.", "Sorry!")
            Sum.Value = addend1 + addend2
            startButton.Enabled = True
        Else
            ' Display the new time left
            ' by updating the Time Left label.
            timesleft -= 1
            Dim timesleft1 As Object = timesleft
            timeLabel.Text = timesleft1 & " seconds"


            ' If the user ran out of time, stop the timer, show 
            ' a MessageBox, and fill in the answers.
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.", "Sorry!")
            Sum.Value = addend1 + addend2
            startButton.Enabled = True
        End If


        If CheckTheAnswer() Then
            ' If CheckTheAnswer() returns true, then the user 
            ' got the answer right. Stop the timer  
            ' and show a MessageBox.
            Timer1.Stop()
            MessageBox.Show("You got all of the answers right!", "Congratulations!")
            startButton.Enabled = True
        ElseIf timesleft > 0 Then
            ' If CheckTheAnswer() return false, keep counting
            ' down. Decrease the time left by one second and 
            ' display the new time left by updating the 
            ' Time Left label.
            timesleft -= 1
            timeLabel.Text = timesleft & " seconds"
        Else
            ' If the user ran out of time, stop the timer, show 
            ' a MessageBox, and fill in the answers.
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.", "Sorry!")
            Sum.Value = addend1 + addend2
            difference.Value = minuend - subtrahend
            startButton.Enabled = True
            product.Value = multiplicand * multiplier
            quotient.Value = dividend / divisor
        End If


    End Sub

End Class
