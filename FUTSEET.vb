Public Class FUTSEET
    Private Sub SEETBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles SEETBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SEETBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MTCEDATABASEDataSet)

    End Sub

    Private Sub FUTSEET_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'saved values
        SEETLifeSpan.Text = My.Settings.SEETLifeSpan
        SEETAge.Text = My.Settings.SEETAge
        SEETRemainingLife.Text = My.Settings.SEETRemainingLife
        SEETAvConSurIndex.Text = My.Settings.SEETAvCSI
        SEETFundAllo.Text = My.Settings.SEETFundAllo
        SEETReplaceCost.Text = My.Settings.SEETReplaceCost
        SEETRepairCost.Text = My.Settings.SEETRepairCost

        SEETDataGridView.AllowUserToAddRows = False
        SEETDataGridView.AllowUserToDeleteRows = True
        SEETDataGridView.AllowUserToOrderColumns = True
        SEETDataGridView.ReadOnly = False
        SEETDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        SEETDataGridView.MultiSelect = True
        SEETDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        SEETDataGridView.AllowUserToResizeColumns = True
        SEETDataGridView.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        SEETDataGridView.AllowUserToResizeRows = True
        SEETDataGridView.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.EnableResizing


        'TODO: This line of code loads data into the 'MTCEDATABASEDataSet.SEET' table. You can move, or remove it, as needed.
        Me.SEETTableAdapter.Fill(Me.MTCEDATABASEDataSet.SEET)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim avg As Decimal

        Dim total1 As String = 0
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        For i As Integer = 0 To SEETDataGridView.RowCount - 1
            total1 += SEETDataGridView.Rows(i).Cells(3).Value
            total2 += SEETDataGridView.Rows(i).Cells(4).Value
            total3 += SEETDataGridView.Rows(i).Cells(5).Value
            total4 += SEETDataGridView.Rows(i).Cells(6).Value
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

        SEETRemainingLife.Text = Val(SEETLifeSpan.Text) - Val(SEETAge.Text)

        avg = total1 / SEETDataGridView.RowCount

        SEETAvConSurIndex.Text = FormatNumber(avg)
        SEETFundAllo.Text = total2
        SEETReplaceCost.Text = total3
        SEETRepairCost.Text = total4

        For i As Integer = 0 To SEETDataGridView.Rows.Count - 1

            If SEETDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SEETDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SEETDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SEETDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.SEETLifeSpan = SEETLifeSpan.Text
        My.Settings.SEETAge = SEETAge.Text
        My.Settings.SEETRemainingLife = SEETRemainingLife.Text
        My.Settings.SEETAvCSI = SEETAvConSurIndex.Text
        My.Settings.SEETFundAllo = SEETFundAllo.Text
        My.Settings.SEETReplaceCost = SEETReplaceCost.Text
        My.Settings.SEETRepairCost = SEETRepairCost.Text
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub SEETDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles SEETDataGridView.CellEndEdit
        For i As Integer = 0 To SEETDataGridView.Rows.Count - 1

            If SEETDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SEETDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SEETDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SEETDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub


    Private Sub SEETDataGridView_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SEETDataGridView.ColumnHeaderMouseClick
        For i As Integer = 0 To SEETDataGridView.Rows.Count - 1

            If SEETDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SEETDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SEETDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SEETDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SEETDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SEETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SEETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.WhiteSmoke
                SEETDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub
End Class