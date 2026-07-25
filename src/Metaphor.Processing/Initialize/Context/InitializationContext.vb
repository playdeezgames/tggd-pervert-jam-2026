Imports Metaphor.Persistence

Friend Class InitializationContext
    Implements IInitializationContext
    Private Sub New(chosenName As String, chosenPronouns As String)
        Me.ChosenName = chosenName
        Me.ChosenPronouns = chosenPronouns
    End Sub

    Public ReadOnly Property ChosenName As String Implements IInitializationContext.ChosenName

    Public Property Location As ILocation Implements IInitializationContext.Location

    Public ReadOnly Property ChosenPronouns As String Implements IInitializationContext.ChosenPronouns

    Public ReadOnly Property WorldWidth As Double Implements IInitializationContext.WorldWidth
        Get
            Return WORLD_WIDTH
        End Get
    End Property

    Public ReadOnly Property WorldHeight As Double Implements IInitializationContext.WorldHeight
        Get
            Return WORLD_HEIGHT
        End Get
    End Property

    Friend Shared Function Create(chosenName As String, chosenPronouns As String) As IInitializationContext
        Return New InitializationContext(chosenName, chosenPronouns)
    End Function
End Class
