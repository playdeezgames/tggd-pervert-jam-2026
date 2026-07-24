Imports Metaphor.Persistence

Friend Module LocationInitializer
    Friend Function Initialize(context As IInitializationContext) As Persistence.LocationInitializer
        Return Sub(location)
                   context.Location = location
                   location.CreateCharacter(CharacterTypes.N00B, context.ChosenName, $"{context.ChosenName}'s pronouns are they/them. Knowing Finnish won't help here.", InitializeAvatar(context))
               End Sub
    End Function

    Private Function InitializeAvatar(context As IInitializationContext) As CharacterInitializer
        Return Sub(character)
                   character.SetPronouns(context.ChosenPronouns)
                   character.World.Avatar = character
               End Sub
    End Function
End Module
