Public Delegate Sub CharacterInitializer(character As ICharacter)
Public Interface ICharacter
    Inherits IInventoriedEntity
    Property Location As ILocation
    ReadOnly Property Pronouns As String
    Property Ship As ILocation
End Interface
