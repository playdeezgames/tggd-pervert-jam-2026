Imports Metaphor.Persistence

Friend Class AvatarKnownIslandsModel
    Implements IAvatarKnownIslandsModel
    Private ReadOnly avatar As ICharacter

    Private Sub New(avatar As ICharacter)
        Me.avatar = avatar
    End Sub

    Public ReadOnly Property IsChoosingKnownIsland As Boolean Implements IAvatarKnownIslandsModel.IsChoosingKnownIsland
        Get
            Return avatar.HasTag(Tags.CHOOSING_KNOWN_ISLAND)
        End Get
    End Property

    Public ReadOnly Property LegacyKnownIslands As IEnumerable(Of IIslandModel) Implements IAvatarKnownIslandsModel.LegacyKnownIslands
        Get
            Return avatar.KnownIslands.Select(AddressOf IslandModel.Create)
        End Get
    End Property

    Public Sub ChooseKnownIsland(islandModel As IIslandModel) Implements IAvatarKnownIslandsModel.ChooseKnownIsland
        avatar.ClearTag(Tags.CHOOSING_KNOWN_ISLAND)
        If islandModel IsNot Nothing Then
            islandModel.SetHeadingFor()
        End If
    End Sub

    Friend Shared Function Create(avatar As ICharacter) As IAvatarKnownIslandsModel
        Return New AvatarKnownIslandsModel(avatar)
    End Function
End Class
