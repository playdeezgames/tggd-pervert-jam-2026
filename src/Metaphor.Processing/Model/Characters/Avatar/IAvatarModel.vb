Public Interface IAvatarModel
    Sub ShowStatus()
    ReadOnly Property Inventory As IInventoryModel
    ReadOnly Property Verbs As IEnumerable(Of IVerbModel)
    Sub Look()
    ReadOnly Property Ship As IShipModel
    ReadOnly Property IsDead As Boolean
    ReadOnly Property CanStow As Boolean
    ReadOnly Property Selling As IAvatarSellingModel
    ReadOnly Property Buying As IAvatarBuyingModel
    ReadOnly Property KnownIslands As IAvatarKnownIslandsModel
#Region "Selling"
    ReadOnly Property IsSelling As Boolean
    Sub CancelSelling()
#End Region
#Region "Buying"
    ReadOnly Property IsBuying As Boolean
    Sub CancelBuying()
#End Region
#Region "Known Island"
    ReadOnly Property IsChoosingKnownIsland As Boolean
    Sub ChooseKnownIsland(islandModel As IIslandModel)
    ReadOnly Property LegacyKnownIslands As IEnumerable(Of IIslandModel)
#End Region
End Interface
