Imports Metaphor.Processing
Imports TGGD.Presentation

Friend Module SetSpeedActivity
    Friend Function Launch(context As IDisplayContext, model As IWorldModel, previous As DialogSource, speed As Double) As DialogSource
        model.Avatar.SetSpeed(speed)
        Return InPlay.Launch(context, model, previous)
    End Function
End Module
