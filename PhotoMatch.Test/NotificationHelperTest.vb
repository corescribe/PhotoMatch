Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class NotificationHelperTests

    <TestMethod>
    Public Sub GetBackgroundColor_ReturnsExpectedColor_ForEachType()
        Assert.AreEqual(COLOR_BACKGROUND_NOTIFICATION_INFO, GetBackgroundColor(NotificationType.Info))
        Assert.AreEqual(COLOR_BACKGROUND_NOTIFICATION_SUCCESS, GetBackgroundColor(NotificationType.Success))
        Assert.AreEqual(COLOR_BACKGROUND_NOTIFICATION_WARNING, GetBackgroundColor(NotificationType.Warning))
        Assert.AreEqual(COLOR_BACKGROUND_NOTIFICATION_ERROR, GetBackgroundColor(NotificationType.Exception))
    End Sub

    <TestMethod>
    Public Sub GetBackgroundColor_ReturnsDefault_ForUnknownType()
        Dim unknownType As NotificationType = CType(-1, NotificationType)
        Assert.AreEqual(COLOR_BACKGROUND_NOTIFICATION_DEFAULT, GetBackgroundColor(unknownType))
    End Sub

    <TestMethod>
    Public Sub GetForeColor_ReturnsExpectedColor_ForEachType()
        Assert.AreEqual(COLOR_FONT_NOTIFICATION_INFO, GetForeColor(NotificationType.Info))
        Assert.AreEqual(COLOR_FONT_NOTIFICATION_SUCCESS, GetForeColor(NotificationType.Success))
        Assert.AreEqual(COLOR_FONT_NOTIFICATION_WARNING, GetForeColor(NotificationType.Warning))
        Assert.AreEqual(COLOR_FONT_NOTIFICATION_ERROR, GetForeColor(NotificationType.Exception))
    End Sub

    <TestMethod>
    Public Sub GetForeColor_ReturnsDefault_ForUnknownType()
        Dim unknownType As NotificationType = CType(-1, NotificationType)
        Assert.AreEqual(COLOR_FONT_NOTIFICATION_DEFAULT, GetForeColor(unknownType))
    End Sub

End Class