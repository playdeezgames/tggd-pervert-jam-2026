Imports Metaphor.Persistence
Imports TGGD.Processing

Friend Module LocationInitializer
    Friend Function Initialize(context As IInitializationContext) As Persistence.LocationInitializer
        Return Sub(location)
                   context.Location = location
                   location.InitializeDimension(Dimensions.HEADING, RNG.FromRange(HEADING_MINIMUM, HEADING_MAXIMUM), HEADING_MINIMUM, HEADING_MAXIMUM)
                   location.InitializeDimension(Dimensions.SPEED, SPEED_AHEAD_TWO_THIRDS, SPEED_FULL_STOP, SPEED_AHEAD_FLANK)
                   location.InitializeDimension(Dimensions.LONGITUDE, context.WorldWidth / 2, 0.0, context.WorldWidth)
                   location.InitializeDimension(Dimensions.LATITUDE, context.WorldHeight / 2, 0.0, context.WorldHeight)
                   location.CreateCharacter(CharacterTypes.N00B, context.ChosenName, context.ChosenPronouns, $"{context.ChosenName}'s pronouns are {context.ChosenPronouns}.", InitializeAvatar(context))
               End Sub
    End Function

    Private Function InitializeAvatar(context As IInitializationContext) As CharacterInitializer
        Return Sub(character)
                   character.World.Avatar = character
                   character.InitializeCounter(Counters.FLESH_GRAMS, 454, 0, 454)
               End Sub
    End Function
End Module
