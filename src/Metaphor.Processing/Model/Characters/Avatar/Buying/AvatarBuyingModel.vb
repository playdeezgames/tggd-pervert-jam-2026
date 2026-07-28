Imports Metaphor.Persistence

Friend Class AvatarBuyingModel
    Implements IAvatarBuyingModel
    Private ReadOnly avatar As ICharacter

    Private Sub New(avatar As ICharacter)
        Me.avatar = avatar
    End Sub
    Public ReadOnly Property Active As Boolean Implements IAvatarBuyingModel.Active
        Get
            Return avatar.HasTag(Tags.BUYING)
        End Get
    End Property

    Public Sub Cancel() Implements IAvatarBuyingModel.Cancel
        avatar.ClearTag(Tags.BUYING)
    End Sub

    Friend Shared Function Create(avatar As ICharacter) As IAvatarBuyingModel
        Return New AvatarBuyingModel(avatar)
    End Function
End Class
