Public Interface IAvatarModel
    Sub ShowStatus()
    ReadOnly Property Inventory As IInventoryModel
    ReadOnly Property Verbs As IEnumerable(Of IVerbModel)
    Sub Look()
    ReadOnly Property Ship As IShipModel
    ReadOnly Property IsDead As Boolean
    ReadOnly Property CanStow As Boolean
    ReadOnly Property IsSelling As Boolean
    ReadOnly Property IsBuying As Boolean
    Sub CancelSelling()
    Sub CancelBuying()
#Region "Known Island"
    ReadOnly Property IsChoosingKnownIsland As Boolean
    Sub ChooseKnownIsland(islandModel As IIslandModel)
    ReadOnly Property KnownIslands As IEnumerable(Of IIslandModel)
#End Region
End Interface
