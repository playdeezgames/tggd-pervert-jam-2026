Public Interface IAvatarModel
    Sub ShowStatus()
    ReadOnly Property Inventory As IInventoryModel
    ReadOnly Property Verbs As IEnumerable(Of IVerbModel)
    Sub Look()
    Sub SetHeading(heading As Double)
    ReadOnly Property IsSettingHeading As Boolean
    ReadOnly Property CurrentHeading As Double
    ReadOnly Property IsSettingSpeed As Boolean
    Sub SetSpeed(speed As Double)
    ReadOnly Property CurrentSpeed As Double
End Interface
