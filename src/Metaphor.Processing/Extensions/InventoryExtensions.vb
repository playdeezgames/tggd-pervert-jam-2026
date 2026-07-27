Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module InventoryExtensions
    <Extension>
    Friend Sub CreateHardtack(inventory As IInventory)
        inventory.CreateItem(ItemTypes.HARDTACK, "Hardtack", "This is food, technically.", AddressOf InitializeHardtack)
    End Sub

    Private Sub InitializeHardtack(item As IItem)
        item.SetCounter(Counters.STOMACH, 10)
        item.CreateVerb(VerbTypes.EAT, "Eat", $"You eat the {item.Name}.")
    End Sub
End Module
