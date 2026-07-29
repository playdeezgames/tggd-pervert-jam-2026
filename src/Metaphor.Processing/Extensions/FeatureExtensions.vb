Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module FeatureExtensions
    <Extension>
    Friend Sub Examine(feature As IFeature)
        Dim world = feature.World
        world.ClearMessages()
        Dim character = world.Avatar
        world.AddMessage($"{character.Name} interacts with {feature.Name}.")
        world.AddMessage(feature.Flavor)
        Dim itemStacks = feature.Inventory.ItemStacks
        If itemStacks.Any Then
            world.AddMessage("Item Stacks:")
            For Each itemStack In itemStacks
                world.AddMessage($"- {itemStack.Top.Name}(x{itemStack.Count})")
            Next
        End If
    End Sub
    <Extension>
    Friend Function IsCargoHold(feature As IFeature) As Boolean
        Return feature.EntityType = FeatureTypes.CARGO_HOLD
    End Function
    Private ReadOnly itemTypeCommodityQuanitities As New Dictionary(Of String, Dictionary(Of String, Double)) From
        {
            {
                ItemTypes.HARDTACK,
                New Dictionary(Of String, Double) From
                {
                    {CommodityTypes.GRAIN, 0.1}
                }
            }
        }
    <Extension>
    Friend Function GetUnitPrice(feature As IFeature, itemType As String) As Double
        Dim commodityQuantities As Dictionary(Of String, Double) = Nothing
        If feature.EntityType <> FeatureTypes.MARKET OrElse Not itemTypeCommodityQuanitities.TryGetValue(itemType, commodityQuantities) Then
            Return 0.0
        End If
        Dim island = feature.Location
        Return commodityQuantities.Sum(Function(x) x.Value * island.IslandCommodities(x.Key).MarketPrice)
    End Function
    <Extension>
    Friend Sub Sell(feature As IFeature, itemType As String, quantity As Integer)
        Dim commodityQuantities As Dictionary(Of String, Double) = Nothing
        If feature.EntityType <> FeatureTypes.MARKET OrElse Not itemTypeCommodityQuanitities.TryGetValue(itemType, commodityQuantities) Then
            Return
        End If
        Dim island = feature.Location
        For Each entry In commodityQuantities
            island.IslandCommodities(entry.Key).Sell(quantity * entry.Value)
        Next
    End Sub
End Module
