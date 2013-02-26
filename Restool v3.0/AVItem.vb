'####################################################
'This class stores a single anti-virus location
'####################################################

Public Class AVItem
    Private AVName As String
    Private AVis64 As Boolean
    Private AVPath As String
    Private AVPathToEXE As Boolean

    '####################################################
    'ACCESSOR PROPERTIES
    '####################################################
    Property Name As String
        Get
            Return AVName
        End Get
        Set(ByVal newName As String)
            AVName = newName
        End Set
    End Property
    Property is64 As Boolean
        Get
            Return AVis64
        End Get
        Set(ByVal value As Boolean)
            AVis64 = value
        End Set
    End Property
    Property Path As String
        Get
            Return AVPath
        End Get
        Set(ByVal newPath As String)
            AVPath = newPath
        End Set
    End Property
    Property PathToEXE As Boolean
        Get
            Return AVPathToEXE
        End Get
        Set(ByVal value As Boolean)
            AVPathToEXE = value
        End Set
    End Property

    Public Sub New(ByVal Name As String, ByVal Path As String, ByVal is64 As Boolean, ByVal PathToEXE As Boolean)
        AVName = Name
        AVPath = Path
        AVis64 = is64
        AVPathToEXE = PathToEXE
    End Sub

End Class
