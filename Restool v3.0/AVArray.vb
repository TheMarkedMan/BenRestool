'####################################################
'This class stores an array of anti-virus locations
'####################################################
Public Class AVArray
    Private Array() As AVItem
    Private TotalItems As Integer

    '####DEFAULT CONSTRUCTOR####
    Public Sub New()
        TotalItems = 0
        ReDim Array(0 To TotalItems)
    End Sub

    '####ALTERNATE CONSTRUCTOR####
    Public Sub New(ByVal Name As String, ByVal Path As String, ByVal is64 As Boolean, ByVal PathToEXE As Boolean)
        TotalItems = 0
        ReDim Array(0 To TotalItems)
        Me.Add(Name, Path, is64, PathToEXE)
    End Sub

    '####SUBROUTINES####
    '##################################################################################
    '#           Add
    '# Use:      Will add an AVItem to the Array
    '##################################################################################
    Public Sub Add(ByVal Name As String, ByVal Path As String, ByVal is64 As Boolean, ByVal PathToEXE As Boolean)
        TotalItems += 1
        ReDim Array(0 To TotalItems)
        Array(TotalItems) = New AVItem(Name, Path, is64, PathToEXE)
    End Sub

    Public Property Path(ByVal i As Integer) As String
        Get
            Return Array(i).AVPath
        End Get
        Set(ByVal value As String)
            Array(i).AVPath = value
        End Set
    End Property

    Public Function Print(ByVal printAll As Boolean) As String
        'This will probably be replaced at somepoint
        Dim printVal As String = ""
        If printAll Then
            For index As Integer = 0 To TotalItems Step 1   'Print entire list of AVs
                printVal += Array(index).Print()
            Next
        Else
            For index As Integer = 0 To TotalItems Step 1
                If Array(index).AVInstalled Then            'Print only installed AVs
                    printVal += Array(index).Print()
                End If
            Next
        End If

        Return printVal
    End Function

End Class
