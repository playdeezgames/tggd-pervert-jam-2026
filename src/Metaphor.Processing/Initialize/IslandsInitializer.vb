Imports Metaphor.Persistence
Imports TGGD.Processing

Friend Module IslandsInitializer
    Friend Sub Initialize(world As IWorld, context As IInitializationContext)
        Dim islandCoordinates = GenerateCoordinates(context)
        'TODO: generate names
        'TODO: generate visibility
        'TODO: make location
    End Sub

    Private Function GenerateCoordinates(context As IInitializationContext) As IEnumerable(Of (Longitude As Double, Latitude As Double))
        Dim result As New List(Of (Longitude As Double, Latitude As Double))
        Do Until Not GenerateCoordinate(result, context, 0)

        Loop
        Return result
    End Function

    Private Function GenerateCoordinate(
                                       coordinates As List(Of (Longitude As Double, Latitude As Double)),
                                       context As IInitializationContext,
                                       attempt As Integer) As Boolean
        If attempt >= context.IslandGenerationAttempts Then
            Return False
        End If
        Dim longitude = RNG.FromRange(0.0, context.WorldWidth)
        Dim latitude = RNG.FromRange(0.0, context.WorldHeight)
        If coordinates.All(Function(x) Utility.Distance(x, (longitude, latitude)) >= context.MinimumIslandDistance) Then
            coordinates.Add((longitude, latitude))
            Return True
        End If
        Return GenerateCoordinate(coordinates, context, attempt + 1)
    End Function
End Module
