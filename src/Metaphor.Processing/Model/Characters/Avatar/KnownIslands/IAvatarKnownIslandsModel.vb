Public Interface IAvatarKnownIslandsModel
    ReadOnly Property IsChoosingKnownIsland As Boolean
    Sub ChooseKnownIsland(islandModel As IIslandModel)
    ReadOnly Property LegacyKnownIslands As IEnumerable(Of IIslandModel)
End Interface
