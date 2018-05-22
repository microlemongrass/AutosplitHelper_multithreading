Public NotInheritable Class Validation

#Region "　IsNumeric メソッド (+1)　"


    Public Overloads Shared Function IsNumeric(ByVal stTarget As String) As Boolean
        Return Double.TryParse(
            stTarget,
            System.Globalization.NumberStyles.Any,
            Nothing,
            0#
        )
    End Function



    Public Overloads Shared Function IsNumeric(ByVal oTarget As Object) As Boolean
        Return IsNumeric(oTarget.ToString())
    End Function

#End Region

End Class