Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module CharacterExtensions
    <Extension>
    Private Function IsAvatar(character As ICharacter) As Boolean
        Return If(character.World.Avatar?.EntityId = character.EntityId, False)
    End Function
    <Extension>
    Friend Sub Look(character As ICharacter)
        Dim location = character.Location
        Dim world = location.World
        world.AddMessage(location.Flavor)
        ShowOtherCharacters(character)
        ShowFeatures(character)
        If location.Inventory.HasItems Then
            world.AddMessage("There are items on the ground.")
        End If
    End Sub

    <Extension>
    Friend Sub ShowOtherCharacters(character As ICharacter)
        Dim others = character.Location.GetOtherCharacters(character)
        If others.Any Then
            character.World.AddMessage("Characters:")
            For Each other In others
                character.World.AddMessage($"- {other.Name}")
            Next
        End If
    End Sub

    <Extension>
    Friend Sub ShowFeatures(character As ICharacter)
        Dim features = character.Location.Features
        If features.Any Then
            character.World.AddMessage($"Features:")
            For Each feature In features
                character.World.AddMessage($"- {feature.Name}")
            Next
        End If
    End Sub
    <Extension>
    Friend Sub ShowStatus(character As ICharacter)
        Dim world = character.World
        world.AddMessage($"{character.Name}'s Status:")
        world.AddMessage(character.Flavor)
    End Sub
End Module
