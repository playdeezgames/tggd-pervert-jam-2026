Imports Metaphor.Persistence

Friend Class ItemTypeModel
    Implements IItemTypeModel

    Private ReadOnly market As IFeature
    Private ReadOnly itemType As String

    Private Sub New(market As IFeature, itemType As String)
        Me.market = market
        Me.itemType = itemType
    End Sub

    Public ReadOnly Property Name As String Implements IItemTypeModel.Name
        Get
            Return market.GetItemTypeName(itemType)
        End Get
    End Property

    Public ReadOnly Property UnitBuyPrice As Double Implements IItemTypeModel.UnitBuyPrice
        Get
            Return market.GetUnitBuyPrice(itemType)
        End Get
    End Property

    Public Sub Buy(quantity As Integer) Implements IItemTypeModel.Buy
        Dim avatar = market.World.Avatar
        quantity = Math.Clamp(quantity, 0, CInt(avatar.GetJools() / UnitBuyPrice))
        avatar.ChangeDimension(Dimensions.JOOLS, -quantity * UnitBuyPrice)
        market.Buy(itemType, quantity)
        Utility.Repeat(quantity, Sub()
                                     avatar.Ship.GetCargoHold().Inventory.CreateItemOfType(itemType)
                                 End Sub)
    End Sub

    Friend Shared Function Create(market As IFeature, itemType As String) As IItemTypeModel
        Return New ItemTypeModel(market, itemType)
    End Function
End Class
