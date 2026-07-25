Imports Metaphor.Persistence

Friend Class AvatarModel
    Implements IAvatarModel

    Private ReadOnly avatar As ICharacter

    Private Sub New(avatar As ICharacter)
        Me.avatar = avatar
    End Sub

    Public ReadOnly Property Inventory As IInventoryModel Implements IAvatarModel.Inventory
        Get
            Return InventoryModel.Create(avatar.Inventory)
        End Get
    End Property

    Public ReadOnly Property Verbs As IEnumerable(Of IVerbModel) Implements IAvatarModel.Verbs
        Get
            Return avatar.Verbs.Select(Function(x) CharacterVerbModel.Create(avatar, x))
        End Get
    End Property

    Public ReadOnly Property IsSettingHeading As Boolean Implements IAvatarModel.IsSettingHeading
        Get
            Return avatar.HasTag(Tags.SETTING_HEADING)
        End Get
    End Property

    Public ReadOnly Property CurrentHeading As Double Implements IAvatarModel.CurrentHeading
        Get
            Return avatar.Ship.GetHeading()
        End Get
    End Property

    Public ReadOnly Property IsSettingSpeed As Boolean Implements IAvatarModel.IsSettingSpeed
        Get
            Return avatar.HasTag(Tags.SETTING_SPEED)
        End Get
    End Property

    Public ReadOnly Property CurrentSpeed As Double Implements IAvatarModel.CurrentSpeed
        Get
            Return avatar.Ship.GetSpeed()
        End Get
    End Property

    Public Sub ShowStatus() Implements IAvatarModel.ShowStatus
        avatar.World.ClearMessages()
        avatar.ShowStatus()
    End Sub

    Public Sub Look() Implements IAvatarModel.Look
        avatar.World.ClearMessages()
        avatar.Look()
    End Sub

    Public Sub SetHeading(heading As Double) Implements IAvatarModel.SetHeading
        avatar.Ship.SetHeading(heading)
        avatar.ClearTag(Tags.SETTING_HEADING)
        avatar.Look()
    End Sub

    Public Sub SetSpeed(speed As Double) Implements IAvatarModel.SetSpeed
        avatar.Ship.SetSpeed(speed)
        avatar.ClearTag(Tags.SETTING_SPEED)
        avatar.Look()
    End Sub

    Friend Shared Function Create(avatar As ICharacter) As IAvatarModel
        Return New AvatarModel(avatar)
    End Function
End Class
