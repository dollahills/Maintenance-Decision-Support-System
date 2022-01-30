Public Class FUTSICT
    Private Sub SICTBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles SICTBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SICTBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MTCEDATABASEDataSet)

    End Sub

    Private Sub FUTSICT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'saved values
        SICTLifeSpan.Text = My.Settings.SICTLifeSpan
        SICTAge.Text = My.Settings.SICTAge
        SICTRemainingLife.Text = My.Settings.SICTRemainingLife
        SICTAvConSurIndex.Text = My.Settings.SICTAvCSI
        SICTFundAllo.Text = My.Settings.SICTFundAllo
        SICTReplaceCost.Text = My.Settings.SICTReplaceCost
        SICTRepairCost.Text = My.Settings.SICTRepairCost

        SICTDataGridView.AllowUserToAddRows = False
        SICTDataGridView.AllowUserToDeleteRows = True
        SICTDataGridView.AllowUserToOrderColumns = True
        SICTDataGridView.ReadOnly = False
        SICTDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        SICTDataGridView.MultiSelect = True
        SICTDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        SICTDataGridView.AllowUserToResizeColumns = True
        SICTDataGridView.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        SICTDataGridView.AllowUserToResizeRows = True
        SICTDataGridView.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.EnableResizing



        'TODO: This line of code loads data into the 'MTCEDATABASEDataSet.SICT' table. You can move, or remove it, as needed.
        Me.SICTTableAdapter.Fill(Me.MTCEDATABASEDataSet.SICT)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim avg As Decimal

        Dim total1 As String = 0
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        For i As Integer = 0 To SICTDataGridView.RowCount - 1
            total1 += SICTDataGridView.Rows(i).Cells(3).Value
            total2 += SICTDataGridView.Rows(i).Cells(4).Value
            total3 += SICTDataGridView.Rows(i).Cells(5).Value
            total4 += SICTDataGridView.Rows(i).Cells(6).Value
        Next


        If (total1 = 0) Then
            MsgBox("No data for building condition survey index")
            Exit Sub

        End If

        If (total2 = 0) Then
            MsgBox("No data for fund allocation")
            Exit Sub

        End If

        If (total3 = 0) Then
            MsgBox("No data for Replacement cost")
            Exit Sub
        End If

        If (total4 = 0) Then
            MsgBox("No data for Repair cost")
            Exit Sub
        End If

        avg = total1 / SICTDataGridView.RowCount

        SICTAvConSurIndex.Text = FormatNumber(avg)
        SICTFundAllo.Text = total2
        SICTReplaceCost.Text = total3
        SICTRepairCost.Text = total4

        SICTRemainingLife.Text = Val(SICTLifeSpan.Text) - Val(SICTAge.Text)

        For i As Integer = 0 To SICTDataGridView.Rows.Count - 1

            If SICTDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SICTDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SICTDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SICTDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.SICTLifeSpan = SICTLifeSpan.Text
        My.Settings.SICTAge = SICTAge.Text
        My.Settings.SICTRemainingLife = SICTRemainingLife.Text
        My.Settings.SICTAvCSI = SICTAvConSurIndex.Text
        My.Settings.SICTFundAllo = SICTFundAllo.Text
        My.Settings.SICTReplaceCost = SICTReplaceCost.Text
        My.Settings.SICTRepairCost = SICTRepairCost.Text
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub SICTDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles SICTDataGridView.CellEndEdit
        For i As Integer = 0 To SICTDataGridView.Rows.Count - 1

            If SICTDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SICTDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SICTDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SICTDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub

    Private Sub SICTDataGridView_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SICTDataGridView.ColumnHeaderMouseClick
        For i As Integer = 0 To SICTDataGridView.Rows.Count - 1

            If SICTDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SICTDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SICTDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SICTDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SICTDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SICTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SICTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SICTDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub
End Class