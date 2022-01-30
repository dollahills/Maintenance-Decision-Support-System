Public Class FUTSET
    Private Sub SETBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles SETBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SETBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MTCEDATABASEDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'saved values
        SETLifeSpan.Text = My.Settings.SETLifeSpan
        SETAge.Text = My.Settings.SETAge
        SETAvConSurIndex.Text = My.Settings.SETAvCSI
        SETFundAllo.Text = My.Settings.SETFundAllo
        SETReplaceCost.Text = My.Settings.SETReplaceCost
        SETRepairCost.Text = My.Settings.SETRepairCost
        SETRemainingLife.Text = My.Settings.SETRemainingLife
        SETDataGridView.AllowUserToAddRows = False
        SETDataGridView.AllowUserToDeleteRows = True
        SETDataGridView.AllowUserToOrderColumns = True
        SETDataGridView.ReadOnly = False
        SETDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        SETDataGridView.MultiSelect = True
        SETDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        SETDataGridView.AllowUserToResizeColumns = True
        SETDataGridView.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        SETDataGridView.AllowUserToResizeRows = True
        SETDataGridView.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.EnableResizing

        'TODO: This line of code loads data into the 'MTCEDATABASEDataSet._SET' table. You can move, or remove it, as needed.
        Me.SETTableAdapter.Fill(Me.MTCEDATABASEDataSet._SET)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim avg As Decimal

        Dim total1 As String = 0
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        For i As Integer = 0 To SETDataGridView.RowCount - 1
            total1 += SETDataGridView.Rows(i).Cells(3).Value
            total2 += SETDataGridView.Rows(i).Cells(4).Value
            total3 += SETDataGridView.Rows(i).Cells(5).Value
            total4 += SETDataGridView.Rows(i).Cells(6).Value
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

        avg = total1 / SETDataGridView.RowCount

        SETAvConSurIndex.Text = FormatNumber(avg)
        SETFundAllo.Text = total2
        SETReplaceCost.Text = total3
        SETRepairCost.Text = total4

        SETRemainingLife.Text = Val(SETLifeSpan.Text) - Val(SETAge.Text)

        For i As Integer = 0 To SETDataGridView.Rows.Count - 1

            If SETDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SETDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SETDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SETDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next

    End Sub

    Private Sub SETDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles SETDataGridView.CellEndEdit

        For i As Integer = 0 To SETDataGridView.Rows.Count - 1

            If SETDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SETDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SETDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SETDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.SETLifeSpan = SETLifeSpan.Text
        My.Settings.SETAge = SETAge.Text
        My.Settings.SETAvCSI = SETAvConSurIndex.Text
        My.Settings.SETFundAllo = SETFundAllo.Text
        My.Settings.SETReplaceCost = SETReplaceCost.Text
        My.Settings.SETRepairCost = SETRepairCost.Text
        My.Settings.SETRemainingLife = SETRemainingLife.Text
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub SETDataGridView_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SETDataGridView.ColumnHeaderMouseClick
        For i As Integer = 0 To SETDataGridView.Rows.Count - 1

            If SETDataGridView.Rows(i).Cells(3).Value.ToString = "" Then
                SETDataGridView.Rows(i).Cells(3).Value = 0.00
            End If

            If SETDataGridView.Rows(i).Cells(3).Value <= 1 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Green
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Excellent"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.94 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Good"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.74 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Yellow
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.Black
                SETDataGridView.Rows(i).Cells(7).Value = "Fair"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.49 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.OrangeRed
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Poor"
            End If
            If SETDataGridView.Rows(i).Cells(3).Value <= 0.19 Then
                SETDataGridView.Rows(i).Cells(7).Style.BackColor = Color.Red
                SETDataGridView.Rows(i).Cells(7).Style.ForeColor = Color.White
                SETDataGridView.Rows(i).Cells(7).Value = "Very Poor"
            End If
        Next
    End Sub
End Class
