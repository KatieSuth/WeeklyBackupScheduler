<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblCopyPaths = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lstPathsToCopy = New System.Windows.Forms.ListBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.cmdBrowseCopy = New System.Windows.Forms.Button()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.cmdSchedule = New System.Windows.Forms.Button()
        Me.cmdBrowseLoc = New System.Windows.Forms.Button()
        Me.dtpTime = New System.Windows.Forms.DateTimePicker()
        Me.fdbGetFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.cbBackupNow = New System.Windows.Forms.CheckBox()
        Me.lblMaxCopies = New System.Windows.Forms.Label()
        Me.lblCopies = New System.Windows.Forms.Label()
        Me.numMaxCopies = New System.Windows.Forms.NumericUpDown()
        Me.icoNotify = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.grpOptions.SuspendLayout()
        CType(Me.numMaxCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(26, 18)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(91, 13)
        Me.lblLocation.TabIndex = 0
        Me.lblLocation.Text = "Backup Location:"
        '
        'lblCopyPaths
        '
        Me.lblCopyPaths.AutoSize = True
        Me.lblCopyPaths.Location = New System.Drawing.Point(5, 67)
        Me.lblCopyPaths.Name = "lblCopyPaths"
        Me.lblCopyPaths.Size = New System.Drawing.Size(112, 13)
        Me.lblCopyPaths.TabIndex = 1
        Me.lblCopyPaths.Text = "Paths of Files to Copy:"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(24, 44)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(93, 13)
        Me.lblTime.TabIndex = 3
        Me.lblTime.Text = "Time for Backups:"
        '
        'lstPathsToCopy
        '
        Me.lstPathsToCopy.FormattingEnabled = True
        Me.lstPathsToCopy.Location = New System.Drawing.Point(123, 67)
        Me.lstPathsToCopy.Name = "lstPathsToCopy"
        Me.lstPathsToCopy.Size = New System.Drawing.Size(366, 95)
        Me.lstPathsToCopy.Sorted = True
        Me.lstPathsToCopy.TabIndex = 5
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(123, 15)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(366, 20)
        Me.txtLocation.TabIndex = 6
        '
        'cmdBrowseCopy
        '
        Me.cmdBrowseCopy.Location = New System.Drawing.Point(495, 67)
        Me.cmdBrowseCopy.Name = "cmdBrowseCopy"
        Me.cmdBrowseCopy.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowseCopy.TabIndex = 7
        Me.cmdBrowseCopy.Text = "Browse"
        Me.cmdBrowseCopy.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(495, 139)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemove.TabIndex = 8
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'cmdSchedule
        '
        Me.cmdSchedule.Location = New System.Drawing.Point(224, 229)
        Me.cmdSchedule.Name = "cmdSchedule"
        Me.cmdSchedule.Size = New System.Drawing.Size(133, 23)
        Me.cmdSchedule.TabIndex = 9
        Me.cmdSchedule.Text = "Schedule"
        Me.cmdSchedule.UseVisualStyleBackColor = True
        '
        'cmdBrowseLoc
        '
        Me.cmdBrowseLoc.Location = New System.Drawing.Point(495, 13)
        Me.cmdBrowseLoc.Name = "cmdBrowseLoc"
        Me.cmdBrowseLoc.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowseLoc.TabIndex = 10
        Me.cmdBrowseLoc.Text = "Browse"
        Me.cmdBrowseLoc.UseVisualStyleBackColor = True
        '
        'dtpTime
        '
        Me.dtpTime.CustomFormat = "hh:mm tt"
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTime.Location = New System.Drawing.Point(123, 41)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(73, 20)
        Me.dtpTime.TabIndex = 11
        Me.dtpTime.Value = New Date(2018, 2, 9, 3, 0, 0, 0)
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.lblMaxCopies)
        Me.grpOptions.Controls.Add(Me.lblCopies)
        Me.grpOptions.Controls.Add(Me.numMaxCopies)
        Me.grpOptions.Controls.Add(Me.cbBackupNow)
        Me.grpOptions.Location = New System.Drawing.Point(123, 168)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(366, 55)
        Me.grpOptions.TabIndex = 17
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Options"
        '
        'cbBackupNow
        '
        Me.cbBackupNow.AutoSize = True
        Me.cbBackupNow.Checked = True
        Me.cbBackupNow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbBackupNow.Location = New System.Drawing.Point(210, 22)
        Me.cbBackupNow.Name = "cbBackupNow"
        Me.cbBackupNow.Size = New System.Drawing.Size(124, 17)
        Me.cbBackupNow.TabIndex = 17
        Me.cbBackupNow.Text = "Begin a backup now"
        Me.cbBackupNow.UseVisualStyleBackColor = True
        '
        'lblMaxCopies
        '
        Me.lblMaxCopies.AutoSize = True
        Me.lblMaxCopies.Location = New System.Drawing.Point(27, 22)
        Me.lblMaxCopies.Name = "lblMaxCopies"
        Me.lblMaxCopies.Size = New System.Drawing.Size(59, 13)
        Me.lblMaxCopies.TabIndex = 22
        Me.lblMaxCopies.Text = "Keep up to"
        '
        'lblCopies
        '
        Me.lblCopies.AutoSize = True
        Me.lblCopies.Location = New System.Drawing.Point(125, 22)
        Me.lblCopies.Name = "lblCopies"
        Me.lblCopies.Size = New System.Drawing.Size(38, 13)
        Me.lblCopies.TabIndex = 24
        Me.lblCopies.Text = "copies"
        '
        'numMaxCopies
        '
        Me.numMaxCopies.Location = New System.Drawing.Point(86, 19)
        Me.numMaxCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMaxCopies.Name = "numMaxCopies"
        Me.numMaxCopies.Size = New System.Drawing.Size(36, 20)
        Me.numMaxCopies.TabIndex = 23
        Me.numMaxCopies.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'icoNotify
        '
        Me.icoNotify.Icon = CType(resources.GetObject("icoNotify.Icon"), System.Drawing.Icon)
        Me.icoNotify.Text = "Weekly Backup Scheduler"
        Me.icoNotify.Visible = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 262)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.dtpTime)
        Me.Controls.Add(Me.cmdBrowseLoc)
        Me.Controls.Add(Me.cmdSchedule)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdBrowseCopy)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.lstPathsToCopy)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblCopyPaths)
        Me.Controls.Add(Me.lblLocation)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Weekly Backup Scheduler"
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        CType(Me.numMaxCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLocation As Label
    Friend WithEvents lblCopyPaths As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lstPathsToCopy As ListBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents cmdBrowseCopy As Button
    Friend WithEvents cmdRemove As Button
    Friend WithEvents cmdSchedule As Button
    Friend WithEvents cmdBrowseLoc As Button
    Friend WithEvents dtpTime As DateTimePicker
    Friend WithEvents fdbGetFolder As FolderBrowserDialog
    Friend WithEvents grpOptions As GroupBox
    Friend WithEvents cbBackupNow As CheckBox
    Friend WithEvents lblMaxCopies As Label
    Friend WithEvents lblCopies As Label
    Friend WithEvents numMaxCopies As NumericUpDown
    Friend WithEvents icoNotify As NotifyIcon
End Class
