Module LogCounter

    ' Main
    '
    Sub Main(args As String())
        If CheckArgs(args) = False Then
            Console.WriteLine("Usage: LogCounter.exe [input file path]")
            Exit Sub
        End If
        Dim inputFile As String = args(0)

        Dim fields As String()
        Dim sumByDay As New SortedDictionary(Of String, Integer)
        Dim csvParser As FileIO.TextFieldParser = Nothing
        Try
            csvParser = New FileIO.TextFieldParser(inputFile, Text.Encoding.GetEncoding(932))
            With csvParser
                .TextFieldType = FileIO.FieldType.Delimited
                .SetDelimiters(",")
                .HasFieldsEnclosedInQuotes = True
                .TrimWhiteSpace = True
            End With
            While Not csvParser.EndOfData
                fields = csvParser.ReadFields()
                SumUp(fields(0).Substring(0, 8), sumByDay)
            End While
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Exit Sub
        Finally
            If Not csvParser Is Nothing Then
                csvParser.Close()
            End If
        End Try

        Dim directory As String = IO.Path.GetDirectoryName(inputFile)
        Dim fileName As String = IO.Path.GetFileName(inputFile)
        Output(directory & IO.Path.DirectorySeparatorChar & "sumByDay_" & fileName, sumByDay)
    End Sub

    ' CheckArgs
    '
    Private Function CheckArgs(args As String())
        If args.Length <> 1 Then
            CheckArgs = False
        ElseIf Not IO.File.Exists(args(0)) Then
            CheckArgs = False
        Else
            CheckArgs = True
        End If
    End Function

    ' SumUp
    '
    Private Sub SumUp(key As String, ByRef dict As SortedDictionary(Of String, Integer))
        If dict.ContainsKey(key) Then
            dict.Item(key) = dict.Item(key) + 1
        Else
            dict.Item(key) = 1
        End If
    End Sub

    ' Output
    '
    Private Sub Output(file As String, ByRef dict As SortedDictionary(Of String, Integer))
        Dim sw As IO.StreamWriter = Nothing
        Dim item As KeyValuePair(Of String, Integer)
        Try
            sw = New IO.StreamWriter(file, False, Text.Encoding.GetEncoding(932))
            For Each item In dict
                sw.WriteLine(item.Key & "," & item.Value)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return
        Finally
            If Not sw Is Nothing Then
                sw.Close()
            End If
        End Try
    End Sub

End Module
