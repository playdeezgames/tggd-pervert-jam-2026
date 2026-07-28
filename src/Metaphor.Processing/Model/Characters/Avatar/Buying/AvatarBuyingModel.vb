Imports Metaphor.Persistence

Friend Class AvatarBuyingModel
    Implements IAvatarBuyingModel
    Private ReadOnly avatar As ICharacter

    Private Sub New(avatar As ICharacter)
        Me.avatar = avatar
    End Sub
    Public ReadOnly Property IsBuying As Boolean Implements IAvatarBuyingModel.IsBuying
        Get
            Return avatar.HasTag(Tags.BUYING)
        End Get
    End Property

    Public Sub CancelBuying() Implements IAvatarBuyingModel.CancelBuying
        avatar.ClearTag(Tags.BUYING)
    End Sub

    Friend Shared Function Create(avatar As ICharacter) As IAvatarBuyingModel
        Return New AvatarBuyingModel(avatar)
    End Function
End Class
