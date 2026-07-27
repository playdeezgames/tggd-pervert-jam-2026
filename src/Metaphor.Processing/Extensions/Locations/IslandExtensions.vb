Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module IslandExtensions
    Friend Sub DescribeIsland(island As ILocation)
        Dim world = island.World
        world.AddMessage($"Island: {island.Name}")
    End Sub

    <Extension>
    Function IsVisibleTo(fromLocation As ILocation, toLocation As ILocation) As Boolean
        Return fromLocation.DistanceTo(toLocation) <= Math.Min(fromLocation.GetVisibility(), toLocation.GetVisibility())
    End Function
    <Extension>
    Function DistanceTo(fromLocation As ILocation, toLocation As ILocation) As Double
        Return Utility.Distance(
            (fromLocation.GetLongitude(), fromLocation.GetLatitude()),
            (toLocation.GetLongitude(), toLocation.GetLatitude()))
    End Function
    <Extension>
    Function HeadingTo(fromLocation As ILocation, toLocation As ILocation) As Double
        Dim deltaX = toLocation.GetLongitude() - fromLocation.GetLongitude()
        Dim deltaY = toLocation.GetLatitude() - fromLocation.GetLatitude()
        Dim heading = Math.Atan2(deltaY, deltaX) * 360.0 / Math.PI / 2
        Return If(heading < 0.0, heading + 360.0, heading)
    End Function
    <Extension>
    Function GetIslandName(island As ILocation) As String
        Return If(island.HasTag(Tags.KNOWN), island.Name, "UNKNOWN ISLAND")
    End Function
End Module
