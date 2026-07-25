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
End Module
