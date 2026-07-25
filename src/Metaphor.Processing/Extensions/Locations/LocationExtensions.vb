Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module LocationExtensions
    <Extension>
    Friend Sub Describe(location As ILocation)
        Select Case location.EntityType
            Case LocationTypes.SHIP
                DescribeShip(location)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub

    Private Sub DescribeShip(location As ILocation)
        Dim world = location.World
        world.AddMessage($"Logitude: {location.GetLongitude():f2}")
        world.AddMessage($"Latitude: {location.GetLatitude():f2}")
        world.AddMessage($"Heading: {location.GetHeading():f2}")
        world.AddMessage($"Speed: {location.GetSpeed():f2}")
    End Sub
    <Extension>
    Friend Function GetLongitude(location As ILocation) As Double
        Return location.GetDimension(Dimensions.LONGITUDE)
    End Function
    <Extension>
    Friend Function GetLatitude(location As ILocation) As Double
        Return location.GetDimension(Dimensions.LATITUDE)
    End Function
    <Extension>
    Friend Function GetHeading(location As ILocation) As Double
        Return location.GetDimension(Dimensions.HEADING)
    End Function
    <Extension>
    Friend Function GetSpeed(location As ILocation) As Double
        Return location.GetDimension(Dimensions.SPEED)
    End Function
End Module
