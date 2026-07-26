Public Interface IAvatarModel
    Sub ShowStatus()
    ReadOnly Property Inventory As IInventoryModel
    ReadOnly Property Verbs As IEnumerable(Of IVerbModel)
    Sub Look()
    ReadOnly Property Ship As IShipModel
#Region "Known Island"
    ReadOnly Property IsChoosingKnownIsland As Boolean
    Sub ChooseKnownIsland(islandModel As IIslandModel)
    ReadOnly Property KnownIslands As IEnumerable(Of IIslandModel)
#End Region
End Interface
