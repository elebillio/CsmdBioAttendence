Public Class CsmdScroll

    Private Sub CsmdScroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = _Speed
    End Sub
    Dim k As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Select Case _Bool
            Case True
                M.Location = New Point(-k, 3)
                k -= 1
                If -k > Width Then
                    k = M.Width
                    M.Location = New Point(-k, 3)
                End If
            Case False
                M.Location = New Point(k, 3)
                k -= 1
                If -k > M.Width Then
                    M.Location = New Point(Width, 3)
                    k = Width
                End If
        End Select
        M.BackColor = _bColor
    End Sub
    Public _Bool As Boolean
    Public Property Bool() As Boolean
        Get
            Return _Bool
        End Get
        Set(ByVal value As Boolean)
            _Bool = value
        End Set
    End Property
    Public _bColor As Color
    Public Property bColor() As Color
        Get
            Return _bColor
        End Get
        Set(ByVal value As Color)
            _bColor = value
        End Set
    End Property
    Public _Speed As Integer = 10
    Public Property Speed() As Integer
        Get
            Return _Speed
        End Get
        Set(ByVal value As Integer)
            _Speed = value
        End Set
    End Property

    Private Sub M_Move(sender As Object, e As EventArgs) Handles M.Move
        Me.Height = M.Height
    End Sub
End Class
