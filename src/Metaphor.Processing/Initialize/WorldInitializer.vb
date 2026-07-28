Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module WorldInitializer
    <Extension>
    Friend Sub Initialize(world As IWorld, context As IInitializationContext)
        world.Clear()
        world.CreateCommodity(CommodityTypes.GRAIN, "Grain", AddressOf InitializeGrain)
        world.CreateCommodity(CommodityTypes.LABOUR, "Labour", AddressOf InitializeLabour)
        IslandsInitializer.Initialize(world, context)
        world.CreateLocation(LocationTypes.SHIP, "The Blue Ship", "Yer on the Blue Ship.", ShipInitializer.Initialize(context))
        world.AddMessage("Avast!")
        world.Avatar.Look()
    End Sub

    Private Sub InitializeLabour(commodity As ICommodity)
        commodity.BasePrice = 0.5
        commodity.SupplyFactor = 0.01
        commodity.DemandFactor = 0.01
    End Sub

    Private Sub InitializeGrain(commodity As ICommodity)
        commodity.BasePrice = 0.1
        commodity.SupplyFactor = 0.01
        commodity.DemandFactor = 0.01
    End Sub
End Module
