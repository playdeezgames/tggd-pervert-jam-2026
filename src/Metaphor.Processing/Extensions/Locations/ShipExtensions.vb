Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module ShipExtensions

    Friend Sub DescribeShip(ship As ILocation)
        Dim world = ship.World
        world.AddMessage($"Logitude: {ship.GetLongitude():f2}")
        world.AddMessage($"Latitude: {ship.GetLatitude():f2}")
        world.AddMessage($"Heading: {ship.GetHeading():f2}")
        world.AddMessage($"Speed: {ship.GetSpeed():f2}")
    End Sub
    <Extension>
    Friend Function GetLongitude(ship As ILocation) As Double
        Return ship.GetDimension(Dimensions.LONGITUDE)
    End Function
    <Extension>
    Friend Sub SetLongitude(ship As ILocation, longitude As Double)
        ship.SetDimension(Dimensions.LONGITUDE, longitude)
    End Sub
    <Extension>
    Friend Function GetLatitude(ship As ILocation) As Double
        Return ship.GetDimension(Dimensions.LATITUDE)
    End Function
    <Extension>
    Friend Sub SetLatitude(ship As ILocation, latitude As Double)
        ship.SetDimension(Dimensions.LATITUDE, latitude)
    End Sub
    <Extension>
    Friend Function GetHeading(ship As ILocation) As Double
        Return ship.GetDimension(Dimensions.HEADING)
    End Function
    <Extension>
    Friend Function GetSpeed(ship As ILocation) As Double
        Return ship.GetDimension(Dimensions.SPEED)
    End Function
    <Extension>
    Friend Sub SetHeading(ship As ILocation, heading As Double)
        ship.SetDimension(Dimensions.HEADING, heading)
    End Sub
    <Extension>
    Friend Sub SetSpeed(ship As ILocation, speed As Double)
        ship.SetDimension(Dimensions.SPEED, speed)
    End Sub

End Module
