Imports System.Runtime.CompilerServices
Imports Metaphor.Persistence

Friend Module EntityExtensions
    <Extension>
    Friend Sub InitializeCounter(entity As IMetaphorEntity, counterId As String, value As Integer, minimum As Integer, maximum As Integer)
        entity.SetCounterMinimum(counterId, minimum)
        entity.SetCounterMaximum(counterId, maximum)
        entity.SetCounter(counterId, value)
    End Sub
    <Extension>
    Friend Function GetCounterPercentage(entity As IMetaphorEntity, counterId As String) As String
        Return $"{entity.GetCounter(counterId) * 100 \ entity.GetCounterMaximum(counterId)}%"
    End Function
    <Extension>
    Friend Sub InitializeDimension(
                                  entity As IMetaphorEntity,
                                  dimensionId As String,
                                  value As Double,
                                  minimum As Double,
                                  maximum As Double)
        entity.SetDimensionMaximum(dimensionId, maximum)
        entity.SetDimensionMinimum(dimensionId, minimum)
        entity.SetDimension(dimensionId, value)
    End Sub
End Module
