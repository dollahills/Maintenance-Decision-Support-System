Public Class FUTSEMT
    Private Sub SEMTBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles SEMTBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SEMTBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MTCEDATABASEDataSet)

    End Sub

    Private Sub FUTSEMT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'saved values
        SEMTLifeSpan.Text = My.Settings.SEMTLifeSpan
        SEMTAge.Text = My.Settings.SEMTAge
        SEMTRemainingLife.Text = My.Settings.SEMTRemainingLife
        SEMTAvConSurIndex.Text = My.Settings.SEMTAvCSI
        SEMTFundAllo.Text = My.Settings.SEMTFundAllo
        SEMTReplaceCost.Text = My.Settings.SEMTReplaceCost
        SEMTRepairCost.Text = My.Settings.SEMTRepairCost

        SEMTDataGridView.AllowUserToAddRows = False
        SEMTDataGridView.AllowUserToDeleteRows = True
        SEMTDataGridView.AllowUserToOrderColumns = True
        SEMTDataGridView.ReadOnly = False
        SEMTDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        SEMTDataGridView.MultiSelect = True
        SEMTDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        SEMTDataGridView.AllowUserToResizeColumns = True
        SEMTDataGridView.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        SEMTDataGridView.AllowUserToResizeRows = True
        SEMTDataGridView.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.EnableResizing



        'TODO: This line of code loads data into the 'MTCEDATABASEDataSet.SEMT' table. You can move, or remove it, as needed.
        Me.SEMTTableAdapter.Fill(Me.MTCEDATABASEDataSet.SEMT)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim avg As Decimal

        Dim total1 As String = 0
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        For i As Integer = 0 To SEMTDataGridView.RowCount - 1
            total1 += SEMTDataGridView.Rows(i).Cells(3).Value
            total2 += SEMTDataGridView.Rows(i).Cells(4).Value
            total3 += SEMTDataGridView.Rows(i).Cells(5).Value
            total4 += SEMTDataGridView.Rows(i).Cells(6).Value
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

        SEMTRemainingLife.Text = Val(SEMTLifeSpan.Text) - Val(SEMTAge.Text)

        avg = total1 / SEMTDataGridView.RowCount

        SEMTAvConSurIndex.Text = FormatNumber(avg)
        SEMTFundAllo.Text = total2
        SEMTReplaceCost.Text = total3
        SEMTRepairCost.Text = total4

        For i As Integer = 0 To SEMTDataGridView.Rows.Count - 1

            If SEMTDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SEMTDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SEMTDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SEMTDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.SEMTLifeSpan = SEMTLifeSpan.Text
        My.Settings.SEMTAge = SEMTAge.Text
        My.Settings.SEMTRemainingLife = SEMTRemainingLife.Text
        My.Settings.SEMTAvCSI = SEMTAvConSurIndex.Text
        My.Settings.SEMTFundAllo = SEMTFundAllo.Text
        My.Settings.SEMTReplaceCost = SEMTReplaceCost.Text
        My.Settings.SEMTRepairCost = SEMTRepairCost.Text
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub SEMTDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles SEMTDataGridView.CellEndEdit
        For i As Integer = 0 To SEMTDataGridView.Rows.Count - 1

            If SEMTDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SEMTDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SEMTDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SEMTDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub

    Private Sub SEMTDataGridView_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SEMTDataGridView.ColumnHeaderMouseClick
        For i As Integer = 0 To SEMTDataGridView.Rows.Count - 1

            If SEMTDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SEMTDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SEMTDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SEMTDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SEMTDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SEMTDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SEMTDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SEMTDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub
End Class