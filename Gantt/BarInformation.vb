Public Class BarInformation

    Private _rowText As String
    Private _fromTime As Date
    Private _toTime As Date
    Private _color As Color
    Private _hoverColor As Color
    Private _index As Integer
    Private _opdrachtID As Integer
    Private _klant As String
    Private _RitInstantieID As Integer
    Private _Ritnummer As Integer

    Public Property RitNummer() As Integer
        Get
            Return _Ritnummer
        End Get
        Set(ByVal value As Integer)
            _Ritnummer = value
        End Set
    End Property
    Public Property RitInstantieID() As Integer
        Get
            Return _RitInstantieID
        End Get
        Set(ByVal value As Integer)
            _RitInstantieID = value
        End Set
    End Property

    Public Property Klant() As String
        Get
            Return _klant
        End Get
        Set(ByVal value As String)
            _klant = value
        End Set
    End Property

    Public Property OpdrachtID() As Integer
        Get
            Return _opdrachtID
        End Get
        Set(ByVal value As Integer)
            _opdrachtID = value
        End Set
    End Property

    Public Property RowText() As String
        Get
            Return _rowText
        End Get
        Set(ByVal value As String)
            _rowText = value
        End Set
    End Property

    Public Property FromTime() As Date
        Get
            Return _fromTime
        End Get
        Set(ByVal value As Date)
            _fromTime = value
        End Set
    End Property

    Public Property ToTime() As Date
        Get
            Return _toTime
        End Get
        Set(ByVal value As Date)
            _toTime = value
        End Set
    End Property

    Public Property Color() As Color
        Get
            Return _color
        End Get
        Set(ByVal value As Color)
            _color = value
        End Set
    End Property

    Public Property HoverColor() As Color
        Get
            Return _hoverColor
        End Get
        Set(ByVal value As Color)
            _hoverColor = value
        End Set
    End Property

    Public Property Index() As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
        End Set
    End Property

    Public Sub New(ByVal rowText As String, ByVal fromTime As Date, ByVal totime As Date, ByVal color As Color, ByVal hoverColor As Color, ByVal index As Integer, ByVal opdrachtID As Integer, ByVal klant As String, ByVal ritinstantieID As Integer, ByVal ritnummer As Integer)
        Me.RowText = rowText
        Me.FromTime = fromTime
        Me.ToTime = totime
        Me.Color = color
        Me.HoverColor = hoverColor
        Me.Index = index
        Me.OpdrachtID = opdrachtID
        Me.Klant = klant
        Me.RitInstantieID = ritinstantieID
        Me.RitNummer = ritnummer
    End Sub

End Class