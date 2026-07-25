Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module LocationVerbExtensions
    Private Delegate Function CanPerformHandler(verb As IVerb, location As ILocation) As Boolean
    Private Delegate Sub PerformHandler(verb As IVerb, location As ILocation)

    Private ReadOnly canPerformTable As New Dictionary(Of String, CanPerformHandler) From
        {
        }

    <Extension>
    Friend Function CanPerform(verb As IVerb, location As ILocation) As Boolean
        Dim handler As CanPerformHandler = Nothing
        If canPerformTable.TryGetValue(verb.EntityType, handler) Then
            Return handler.Invoke(verb, location)
        End If
        Return True
    End Function

    Private ReadOnly performTable As New Dictionary(Of String, PerformHandler) From
        {
            {VerbTypes.SET_HEADING, AddressOf HandleSetHeading},
            {VerbTypes.SET_SPEED, AddressOf HandleSetSpeed}
        }

    Private Sub HandleSetSpeed(verb As IVerb, location As ILocation)
        verb.World.Avatar.SetTags(Tags.SETTING_SPEED)
    End Sub

    Private Sub HandleSetHeading(verb As IVerb, location As ILocation)
        verb.World.Avatar.SetTags(Tags.SETTING_HEADING)
    End Sub

    <Extension>
    Sub Perform(verb As IVerb, location As ILocation)
        Dim handler As PerformHandler = Nothing
        verb.World.AddMessage(verb.Flavor)
        If performTable.TryGetValue(verb.EntityType, handler) Then
            handler.Invoke(verb, location)
            Return
        End If
    End Sub

End Module
