'####################################################
'This class stores an array of anti-virus locations
'####################################################
Public Class AVArray
    Private Array() As AVItem
    Private TotalItems As Integer

    Public Sub New()
        TotalItems = 0
        ReDim Array(0 To TotalItems)
    End Sub

    Public Sub New(ByVal Name As String, ByVal Path As String, ByVal is64 As Boolean, ByVal PathToEXE As Boolean)
        TotalItems = 0
        ReDim Array(0 To TotalItems)
        Me.Add(Name, Path, is64, PathToEXE)
    End Sub

    Public Function Add(ByVal Name As String, ByVal Path As String, ByVal is64 As Boolean, ByVal PathToEXE As Boolean) As Boolean
        TotalItems += 1
        ReDim Array(0 To TotalItems)
        Array(TotalItems) = New AVItem(Name, Path, is64, PathToEXE)
    End Function

End Class
