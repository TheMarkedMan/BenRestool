Module ExtraFunctions

    '##################################################################################
    '#           findArchitecture
    '# Use:      Detects if it's 32-bit or 64-bit.
    '# Returns:  Architecture type as an int.
    '##################################################################################

    Public Function findArchitecture()
        Dim bit As Integer = 0
        If IntPtr.Size() = 8 Then
            bit = 64
        Else
            bit = 32
        End If
        Return bit
    End Function

    '##################################################################################
    '#           isThisProgramInstalled
    '# Use:      Detects if a program is installed or not
    '# Returns:  Boolean. True if it finds the exe or folder
    '##################################################################################

    Public Function isThisProgramInstalled(ByVal programPath As String, ByVal isExe As Boolean) As Boolean
        If isExe = True Then
            If System.IO.File.Exists(programPath) = True Then           'Check for the exe file
                Return True                                     'Return true: Found EXE
            End If
        Else                                                            'A directory was passed in
            Dim dir As New IO.DirectoryInfo(programPath)
            If dir.Exists Then
                Return True                                     'Return true: Found directory
            End If
        End If
        Return False                                            'Return false: Didn't find the program or directory
    End Function

    '##################################################################################
    '#           checkAVInstalls
    '# Use:      Checks the computer for various AVs listed in an array.
    '# Returns:  Architecture type as an int.
    '##################################################################################

    Public Function checkAVInstalls(ByRef AVCount As Integer, ByRef AVInstalled As String) As Boolean
        Console.WriteLine("Starting AV Check")
        Dim programFiles32 As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) 'Program Files 32-bit machines
        Dim programFiles64 As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) 'Program Files 64-bit machine
        Dim programFiles As String = ""

        If findArchitecture() = 64 Then
            programFiles = programFiles64 'If it's 64-bit
        ElseIf findArchitecture() = 32 Then
            programFiles = programFiles32 ' If it's 32-bit
        Else
            Return False
        End If

        'Build two dimensional string array program name for isThisProgramInstalled in first column, path in second.
        'SAS only installs in 32 bit folder so it is easier to include programFiles in array than to add later

        Dim AVProgramsToCheck(5, 1) As String
        AVProgramsToCheck = {
            {"McAfee VirusScan Enterprise", programFiles & "\McAfee\VirusScan Enterprise\scan32.exe"},
            {"Microsoft Security Essentials", programFiles32 & "\Microsoft Security Client\msseces.exe"},
            {"Malwarebytes' Anti-Malware", programFiles & "\Malwarebytes' Anti-Malware\mbam.exe"},
            {"Spybot - Search & Destroy", programFiles & "\Spybot - Search & Destroy\SDMain.exe"},
            {"ESET Online Scanner", programFiles & "\ESET\ESET Online Scanner\OnlineScannerApp.exe"},
            {"Sophos Anti-Rootkit", programFiles & "\Sophos\Sophos Anti-Rootkit\sargui.exe"},
            {"Super Anti-Spyware", programFiles32 & "\SUPERAntiSpyware\RUNSAS.exe"}
        }


        'Loop through array and check installs
        For index As Integer = 0 To ((AVProgramsToCheck.Length / 2) - 1) Step 1
            If isThisProgramInstalled(AVProgramsToCheck(index, 1), True) Then
                AVCount += 1
                AVInstalled += AVProgramsToCheck(index, 0) & vbCrLf                            'Add name to AV list string
                Console.WriteLine("Found: " & AVProgramsToCheck(index, 0))
            End If
        Next

        'There is another McAfee program Security Scan that is seen often but it is in a folder that is named with a version number
        'so I'm not sure how to approach that yet - Ben

        Return True
    End Function

    '##################################################################################
    '#           findAvDir
    '# Use:      Finds the correct directory of an AV program
    '# Returns:  Ran correctly or not as boolean
    '##################################################################################

    Public Function findAvDir(ByRef programDir As String) As Boolean
        Dim folder As New IO.DirectoryInfo(programDir)
        If Not folder.Exists Then
            Return False                                     'Return false: Didn't find directory
        End If

        For Each Dir As String In IO.Directory.GetDirectories(programDir)
            Console.WriteLine(Dir)
        Next
    End Function

End Module
