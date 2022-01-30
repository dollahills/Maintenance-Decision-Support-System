Public Class FUTSAAT
    Private Sub SAATBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles SAATBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SAATBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MTCEDATABASEDataSet)

    End Sub

    Private Sub FUTSAAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'saved values
        SAATLifeSpan.Text = My.Settings.SAATLifeSpan
        SAATAge.Text = My.Settings.SAATAge
        SAATRemainingLife.Text = My.Settings.SAATremainingLife
        SAATAvConSurIndex.Text = My.Settings.SAATAvCSI
        SAATFundAllo.Text = My.Settings.SAATFundAllo
        SAATReplaceCost.Text = My.Settings.SAATReplaceCost
        SAATRepairCost.Text = My.Settings.SAATRepairCost

        SAATDataGridView.AllowUserToAddRows = False
        SAATDataGridView.AllowUserToDeleteRows = True
        SAATDataGridView.AllowUserToOrderColumns = True
        SAATDataGridView.ReadOnly = False
        SAATDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        SAATDataGridView.MultiSelect = True
        SAATDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        SAATDataGridView.AllowUserToResizeColumns = True
        SAATDataGridView.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        SAATDataGridView.AllowUserToResizeRows = True
        SAATDataGridView.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.EnableResizing



        'TODO: This line of code loads data into the 'MTCEDATABASEDataSet.SAAT' table. You can move, or remove it, as needed.
        Me.SAATTableAdapter.Fill(Me.MTCEDATABASEDataSet.SAAT)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click





        Dim avg As Decimal

        Dim total1 As String = 0
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        For i As Integer = 0 To SAATDataGridView.RowCount - 1
            total1 += SAATDataGridView.Rows(i).Cells(3).Value
            total2 += SAATDataGridView.Rows(i).Cells(4).Value
            total3 += SAATDataGridView.Rows(i).Cells(5).Value
            total4 += SAATDataGridView.Rows(i).Cells(6).Value
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

        SAATRemainingLife.Text = Val(SAATLifeSpan.Text) - Val(SAATAge.Text)

        avg = total1 / SAATDataGridView.RowCount

        SAATAvConSurIndex.Text = FormatNumber(avg)
        SAATFundAllo.Text = total2
        SAATReplaceCost.Text = total3
        SAATRepairCost.Text = total4

        For i As Integer = 0 To SAATDataGridView.Rows.Count - 1

            If SAATDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SAATDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SAATDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SAATDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.SAATLifeSpan = SAATLifeSpan.Text
        My.Settings.SAATAge = SAATAge.Text
        My.Settings.SAATremainingLife = SAATRemainingLife.Text
        My.Settings.SAATAvCSI = SAATAvConSurIndex.Text
        My.Settings.SAATFundAllo = SAATFundAllo.Text
        My.Settings.SAATReplaceCost = SAATReplaceCost.Text
        My.Settings.SAATRepairCost = SAATRepairCost.Text
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub SAATDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles SAATDataGridView.CellEndEdit

        For i As Integer = 0 To SAATDataGridView.Rows.Count - 1

            If SAATDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SAATDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SAATDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SAATDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub

    Private Sub SAATDataGridView_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SAATDataGridView.ColumnHeaderMouseClick

        For i As Integer = 0 To SAATDataGridView.Rows.Count - 1

            If SAATDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SAATDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SAATDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SAATDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SAATDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SAATDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SAATDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SAATDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub


End Class