Public Class frmMain

#Region "Variables Declarations"
    Dim dtNextBackup As New DateTime
    Dim strSettingsPath As String = System.IO.Path.Combine(System.Environment.SpecialFolder.ApplicationData, "WeeklyBackupScheduler", "settings.txt")
#End Region

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadSettings()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            icoNotify.Visible = True
            icoNotify.Icon = SystemIcons.Application
            icoNotify.BalloonTipIcon = ToolTipIcon.Info
            icoNotify.BalloonTipTitle = "Weekly Backup Scheduler"
            icoNotify.BalloonTipText = "Backup scheduled for: " & dtNextBackup.ToShortDateString()
            ShowInTaskbar = False
        End If
    End Sub

    Private Sub icoNotify_BalloonTipShown(sender As Object, e As EventArgs) Handles icoNotify.BalloonTipShown
        icoNotify.BalloonTipText = "Backup scheduled for: " & dtNextBackup.ToShortDateString()
    End Sub

    Private Sub icoNotify_Click(sender As Object, e As EventArgs) Handles icoNotify.Click
        Me.Show()
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        icoNotify.Visible = False
    End Sub

#Region "Button Methods"
    Private Sub cmdBrowseLoc_Click(sender As Object, e As EventArgs) Handles cmdBrowseLoc.Click
        Try
            If fdbGetFolder.ShowDialog() = DialogResult.OK Then
                txtLocation.Text = fdbGetFolder.SelectedPath
            End If
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub

    Private Sub cmdBrowseCopy_Click(sender As Object, e As EventArgs) Handles cmdBrowseCopy.Click
        Try
            If fdbGetFolder.ShowDialog() = DialogResult.OK Then
                lstPathsToCopy.Items.Add(fdbGetFolder.SelectedPath)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub

    Private Sub cmdRemove_Click(sender As Object, e As EventArgs) Handles cmdRemove.Click
        Try
            If lstPathsToCopy.SelectedItems.Count > 0 Then
                lstPathsToCopy.Items.Remove(lstPathsToCopy.SelectedItem)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub

    Private Sub cmdSchedule_Click(sender As Object, e As EventArgs) Handles cmdSchedule.Click
        Try
            If txtLocation.Text.Trim() <> "" And lstPathsToCopy.Items.Count > 0 Then
                If ConfirmSchedule() = True Then
                    Me.WindowState = FormWindowState.Minimized
                    Me.Hide()
                    WriteSettings()
                    Backup()
                End If
            Else
                MessageBox.Show("One or more of the fields has not been completed. Please make sure you've entered the path " &
                                "where you want your backup to go to ('Backup Location') and the paths to the files you want " &
                                "to copy.", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "Methods for Exceptions"
    Private Sub ShowErrorMessage(ByVal ex As Exception)
        Dim Trace As New System.Diagnostics.StackTrace(ex, True)
        Dim strMessage As String = ex.Message.ToString()
        Dim strFile As String = Trace.GetFrame(0).GetFileName()
        Dim strLine As String = Trace.GetFrame(0).GetFileLineNumber().ToString()

        MessageBox.Show("Error in file: " & strFile & " on line " & strLine & "." &
                        vbNewLine & vbNewLine & "Error Message:" & vbNewLine & strMessage,
                        "Error: Backup System", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
#End Region

#Region "Selection Changed"
    Private Sub lstPathsToCopy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPathsToCopy.SelectedIndexChanged
        Try
            If lstPathsToCopy.Items.Count > 0 Then
                cmdRemove.Enabled = True
            Else
                cmdRemove.Enabled = False
            End If
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub

    Private Sub numMaxCopies_ValueChanged(sender As Object, e As EventArgs) Handles numMaxCopies.ValueChanged
        Try
            If numMaxCopies.Value > 1 Then
                lblCopies.Text = "copies"
            Else
                lblCopies.Text = "copy"
            End If
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "Utility"
    Private Function ConfirmSchedule() As Boolean
        Try
            'Start with confirmation message
            Dim strMessage As String = "With these settings, all files specified in the paths listed will be copied to " & txtLocation.Text &
                                       " every week at " & dtpTime.Value.ToShortTimeString & ". Up to " & numMaxCopies.Value

            If numMaxCopies.Value > 1 Then
                strMessage = strMessage & " copies"
            Else
                strMessage = strMessage & " copy"
            End If

            strMessage = strMessage & " of your files will be kept as a backup at a time. Your first backup is scheduled to begin "

            If cbBackupNow.Checked = True Then
                strMessage = strMessage & "now. "
                dtNextBackup = New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day,
                                            dtpTime.Value.Hour, dtpTime.Value.Minute, 0)
            Else
                Dim intDays As Integer = (Convert.ToInt32(DayOfWeek.Sunday) - Convert.ToInt32(Date.Now.DayOfWeek) + 7) Mod 7
                dtNextBackup = New DateTime(Date.Now.AddDays(intDays).Year, Date.Now.AddDays(intDays).Month, Date.Now.AddDays(intDays).Day,
                                            dtpTime.Value.Hour, dtpTime.Value.Minute, 0)

                strMessage = strMessage & "on " & dtNextBackup.Date.ToShortDateString()
            End If

            strMessage = strMessage & vbNewLine & vbNewLine & "Confirm?"

            If MessageBox.Show(strMessage, "Confirm Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ShowErrorMessage(ex)
            Return False
        End Try
    End Function

    Private Sub Backup()
        Try
            While (True)
                If Date.Now >= dtNextBackup Then 'loop until we're at the next backup date
                    Dim diBackupLocation As New IO.DirectoryInfo(txtLocation.Text)
                    Dim listBackups As New List(Of IO.DirectoryInfo)

                    For Each folder As IO.DirectoryInfo In diBackupLocation.GetDirectories()
                        If folder.Name.StartsWith("BackupWBS_") Then
                            listBackups.Add(folder)
                        End If
                    Next

                    If listBackups.Count >= numMaxCopies.Value Then
                        Dim intOldestIndex As Integer = 0

                        For counter As Integer = 1 To listBackups.Count - 1
                            If listBackups(intOldestIndex).CreationTime > listBackups(counter).CreationTime Then
                                intOldestIndex = counter
                            End If
                        Next

                        System.IO.Directory.Delete(listBackups(intOldestIndex).FullName, True)
                    End If

                    Dim strNewFile As String = IO.Path.Combine(txtLocation.Text, "BackupWBS_" & Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day)

                    System.IO.Directory.CreateDirectory(strNewFile)

                    For Each path As String In lstPathsToCopy.Items
                        My.Computer.FileSystem.CopyDirectory(path, strNewFile)
                    Next

                    Dim intDays As Integer = (Convert.ToInt32(DayOfWeek.Sunday) - Convert.ToInt32(Date.Now.DayOfWeek) + 7) Mod 7
                    If intDays = 0 Then
                        intDays = 7
                    End If
                    dtNextBackup = New DateTime(Date.Now.AddDays(intDays).Year, Date.Now.AddDays(intDays).Month, Date.Now.AddDays(intDays).Day,
                                                dtpTime.Value.Hour, dtpTime.Value.Minute, 0)
                End If
            End While
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub

    Private Sub ReadSettings()
        Try
            Dim intCounter As Integer = 0

            If IO.File.Exists(strSettingsPath) Then
                Using fileReader As IO.StreamReader = New IO.StreamReader(strSettingsPath)
                    While Not fileReader.EndOfStream
                        Select Case intCounter
                            Case 0
                                txtLocation.Text = fileReader.ReadLine()
                            Case 1
                                dtpTime.Value = Convert.ToDateTime(fileReader.ReadLine())
                            Case 2
                                numMaxCopies.Value = Convert.ToInt32(fileReader.ReadLine())
                            Case 3
                                dtNextBackup = Convert.ToDateTime(fileReader.ReadLine())
                            Case Else
                                lstPathsToCopy.Items.Add(fileReader.ReadLine())
                        End Select

                        intCounter += 1
                    End While
                End Using
            End If
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub

    Private Sub WriteSettings()
        Try
            If Not IO.Directory.Exists(System.IO.Path.Combine(System.Environment.SpecialFolder.ApplicationData, "WeeklyBackupScheduler")) Then
                IO.Directory.CreateDirectory(System.IO.Path.Combine(System.Environment.SpecialFolder.ApplicationData, "WeeklyBackupScheduler"))
            End If

            Using fileWriter As IO.StreamWriter = New IO.StreamWriter(strSettingsPath, False)
                fileWriter.WriteLine(txtLocation.Text)
                fileWriter.WriteLine(dtpTime.Value.ToShortTimeString())
                fileWriter.WriteLine(numMaxCopies.Value)
                fileWriter.WriteLine(dtNextBackup)
                For Each item As String In lstPathsToCopy.Items
                    fileWriter.WriteLine(item)
                Next
            End Using
        Catch ex As Exception
            ShowErrorMessage(ex)
        End Try
    End Sub
#End Region

End Class
