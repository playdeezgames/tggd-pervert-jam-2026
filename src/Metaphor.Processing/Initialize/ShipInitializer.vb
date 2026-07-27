Imports Metaphor.Persistence
Imports TGGD.Processing

Friend Module ShipInitializer
    Friend Function Initialize(context As IInitializationContext) As Persistence.LocationInitializer
        Return Sub(ship)
                   context.Ship = ship
                   ship.InitializeDimension(Dimensions.HEADING, RNG.FromRange(HEADING_MINIMUM, HEADING_MAXIMUM), HEADING_MINIMUM, HEADING_MAXIMUM)
                   ship.InitializeDimension(Dimensions.SPEED, SPEED_AHEAD_TWO_THIRDS, SPEED_FULL_STOP, SPEED_AHEAD_FLANK)
                   ship.InitializeDimension(Dimensions.LONGITUDE, context.WorldWidth / 2, 0.0, context.WorldWidth)
                   ship.InitializeDimension(Dimensions.LATITUDE, context.WorldHeight / 2, 0.0, context.WorldHeight)
                   ship.SetDimension(Dimensions.VISIBILITY, 10.0)
                   ship.CreateVerb(VerbTypes.MOVE, "Move", "Steady as she goes.")
                   ship.CreateVerb(VerbTypes.DOCK, "Dock", "You moor the ship to the pier.")
                   ship.CreateVerb(VerbTypes.UNDOCK, "Undock", "You cast away from the pier.")
                   ship.CreateVerb(VerbTypes.SET_HEADING, "Set Heading", "You use the helm to set a new heading.")
                   ship.CreateVerb(VerbTypes.SET_SPEED, "Set Speed", "You use the sails to set a new speed.")
                   ship.CreateCharacter(CharacterTypes.N00B, context.ChosenName, context.ChosenPronouns, $"{context.ChosenName}'s pronouns are {context.ChosenPronouns}.", InitializeAvatar(context))
               End Sub
    End Function

    Private Function InitializeAvatar(context As IInitializationContext) As CharacterInitializer
        Return Sub(character)
                   character.World.Avatar = character
                   character.Ship = character.Location
                   character.InitializeCounter(Counters.FLESH_GRAMS, 454, 0, 454)
                   character.InitializeCounter(Counters.HEALTH, 100, 0, 100)
                   character.InitializeCounter(Counters.SATIETY, 100, 0, 100)
                   character.InitializeCounter(Counters.STOMACH, 0, 0, 50)
                   character.Inventory.CreateHardtack()
                   character.CreateVerb(VerbTypes.HEAD_FOR_KNOWN_ISLAND, "Head for known island...", String.Empty)
               End Sub
    End Function
End Module
