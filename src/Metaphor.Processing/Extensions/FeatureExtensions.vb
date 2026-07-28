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
End Module
