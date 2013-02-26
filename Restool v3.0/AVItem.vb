'####################################################
'This class stores a single anti-virus location
'####################################################

Public Class AVItem
    Public AVName As String            'Name of AV Program
    Public AVis64 As Boolean           'Is the program 64 bit
    Public AVPath As String            'Path to the program
    Public AVPathToEXE As Boolean      'Is the path to an EXE
    Public AVCheck As Boolean          'Should we check for this program
    Public AVInstalled As Boolean      'If the program is installed

    '####CONSTRUCTORS####
    Public Sub New(ByVal Name As String, ByVal Path As String, ByVal is64 As Boolean, ByVal PathToEXE As Boolean)
        AVName = Name
        AVPath = Path
        AVis64 = is64
        AVPathToEXE = PathToEXE
        AVCheck = True
        AVInstalled = False
    End Sub
    Public Sub New()
        AVName = ""
        AVPath = ""
        AVis64 = False
        AVPathToEXE = False
        AVCheck = False
        AVInstalled = False
    End Sub

    Public Function Print() As String
        Return AVName & ": " & AVInstalled.ToString & vbCrLf
    End Function



    ''####################################################
    ''ACCESSOR PROPERTIES
    ''####################################################
    'Property Name As String
    '    Get
    '        Return AVName
    '    End Get
    '    Set(ByVal newName As String)
    '        AVName = newName
    '    End Set
    'End Property
    'Property is64 As Boolean
    '    Get
    '        Return AVis64
    '    End Get
    '    Set(ByVal value As Boolean)
    '        AVis64 = value
    '    End Set
    'End Property
    'Property Path As String
    '    Get
    '        Return AVPath
    '    End Get
    '    Set(ByVal newPath As String)
    '        AVPath = newPath
    '    End Set
    'End Property
    'Property PathToEXE As Boolean
    '    Get
    '        Return AVPathToEXE
    '    End Get
    '    Set(ByVal value As Boolean)
    '        AVPathToEXE = value
    '    End Set
    'End Property
    'Property Check As Boolean
    '    Get
    '        Return AVCheck
    '    End Get
    '    Set(ByVal value As Boolean)
    '        AVCheck = value
    '    End Set
    'End Property
    'Property Installed As Boolean
    '    Get
    '        Return AVInstalled
    '    End Get
    '    Set(ByVal value As Boolean)
    '        AVInstalled = value
    '    End Set
    'End Property
End Class
