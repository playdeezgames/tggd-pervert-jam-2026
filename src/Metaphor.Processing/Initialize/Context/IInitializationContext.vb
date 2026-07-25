Imports Metaphor.Persistence

Friend Interface IInitializationContext
    ReadOnly Property ChosenName As String
    ReadOnly Property ChosenPronouns As String
    ReadOnly Property WorldWidth As Double
    ReadOnly Property WorldHeight As Double
    Property Location As ILocation
End Interface
