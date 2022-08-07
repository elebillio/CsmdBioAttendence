Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace ProgressBarSample
    Public Enum ProgressBarDisplayMode
        NoText
        Percentage
        CurrProgress
        CustomText
        TextAndPercentage
        TextAndCurrProgress
    End Enum

    Public Class TextProgressBar
        Inherits ProgressBar

        <Description("Font of the text on ProgressBar"), Category("Additional Options")>
        Public Property TextFont As Font = New Font(FontFamily.GenericSerif, 11, FontStyle.Bold Or FontStyle.Italic)
        Private _textColourBrush As SolidBrush = CType(Brushes.Black, SolidBrush)

        <Category("Additional Options")>
        Public Property TextColor As Color
            Get
                Return _textColourBrush.Color
            End Get
            Set(ByVal value As Color)
                _textColourBrush.Dispose()
                _textColourBrush = New SolidBrush(value)
            End Set
        End Property

        Private _progressColourBrush As SolidBrush = CType(Brushes.LightGreen, SolidBrush)

        <Category("Additional Options"), Browsable(True), EditorBrowsable(EditorBrowsableState.Always)>
        Public Property ProgressColor As Color
            Get
                Return _progressColourBrush.Color
            End Get
            Set(ByVal value As Color)
                _progressColourBrush.Dispose()
                _progressColourBrush = New SolidBrush(value)
            End Set
        End Property

        Private _visualMode As ProgressBarDisplayMode = ProgressBarDisplayMode.CurrProgress

        <Category("Additional Options"), Browsable(True)>
        Public Property VisualMode As ProgressBarDisplayMode
            Get
                Return _visualMode
            End Get
            Set(ByVal value As ProgressBarDisplayMode)
                _visualMode = value
                Invalidate()
            End Set
        End Property

        Private _text As String = String.Empty

        <Description("If it's empty, % will be shown"), Category("Additional Options"), Browsable(True), EditorBrowsable(EditorBrowsableState.Always)>
        Public Property CustomText As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
                Invalidate()
            End Set
        End Property

        Private Property _textToDraw As String
            Get
                Dim text As String = CustomText

                Select Case VisualMode
                    Case (ProgressBarDisplayMode.Percentage)
                        text = _percentageStr
                    Case (ProgressBarDisplayMode.CurrProgress)
                        text = _currProgressStr
                    Case (ProgressBarDisplayMode.TextAndCurrProgress)
                        text = $"{CustomText}: {_currProgressStr}"
                    Case (ProgressBarDisplayMode.TextAndPercentage)
                        text = $"{CustomText}: {_percentageStr}"
                End Select

                Return text
            End Get
            Set(ByVal value As String)
            End Set
        End Property

        Private ReadOnly Property _percentageStr As String
            Get
                Return $"{CInt((CSng(Value) - Minimum)) / (CSng(Maximum) - Minimum) * 100} %"
            End Get
        End Property

        Private ReadOnly Property _currProgressStr As String
            Get
                Return $"{Value}/{Maximum}"
            End Get
        End Property

        Public Sub New()
            Value = Minimum
            FixComponentBlinking()
        End Sub

        Private Sub FixComponentBlinking()
            SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            DrawProgressBar(g)
            DrawStringIfNeeded(g)
        End Sub

        Private Sub DrawProgressBar(ByVal g As Graphics)
            Dim rect As Rectangle = ClientRectangle
            ProgressBarRenderer.DrawHorizontalBar(g, rect)
            rect.Inflate(-3, -3)

            If Value > 0 Then
                Dim clip As Rectangle = New Rectangle(rect.X, rect.Y, CInt(Math.Round((CSng(Value) / Maximum) * rect.Width)), rect.Height)
                g.FillRectangle(_progressColourBrush, clip)
            End If
        End Sub

        Private Sub DrawStringIfNeeded(ByVal g As Graphics)
            If VisualMode <> ProgressBarDisplayMode.NoText Then
                Dim text As String = _textToDraw
                Dim len As SizeF = g.MeasureString(text, TextFont)
                Dim location As Point = New Point(((Width / 2) - CInt(len.Width) / 2), ((Height / 2) - CInt(len.Height) / 2))
                g.DrawString(text, TextFont, CType(_textColourBrush, Brush), location)
            End If
        End Sub

        Public Overloads Sub Dispose()
            _textColourBrush.Dispose()
            _progressColourBrush.Dispose()
            MyBase.Dispose()
        End Sub
    End Class
End Namespace
