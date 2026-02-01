Imports System.Runtime.CompilerServices

''' <summary>
''' Extension methods for Control class.
''' </summary>
Public Module InvokeAsync
    <Extension>
    Public Function InvokeAsync(control As Control, action As Action) As Task

        ' Create a TaskCompletionSource to represent the asynchronous operation.
        Dim taskCompletionSrc As New TaskCompletionSource(Of Object)()

        ' Invoke the action on the control's thread.
        control.BeginInvoke(New Action(
            Sub()
                Try
                    ' Execute the action and set the result.
                    action()
                    ' Set nothing when the action completes successfully.
                    taskCompletionSrc.SetResult(Nothing)
                Catch ex As Exception
                    ' Set the exception if an error occurs.
                    taskCompletionSrc.SetException(ex)
                End Try
            End Sub))

        Return taskCompletionSrc.Task

    End Function

End Module