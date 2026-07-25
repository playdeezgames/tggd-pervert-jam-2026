Friend Module Utility
    Friend Function Distance(fromPosition As (Longitude As Double, Latitude As Double), toPosition As (Longitude As Double, Latitude As Double)) As Double
        Return Math.Sqrt((fromPosition.Longitude - toPosition.Longitude) * (fromPosition.Longitude - toPosition.Longitude) + (fromPosition.Latitude - toPosition.Latitude) * (fromPosition.Latitude - toPosition.Latitude))
    End Function
End Module
