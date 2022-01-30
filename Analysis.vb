Public Class Analysis
    Private Sub Analysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'RankDataBaseDataSet.Rank' table. You can move, or remove it, as needed.
        Me.RankTableAdapter.Fill(Me.RankDataBaseDataSet.Rank)
        'TODO: This line of code loads data into the 'AnalysisDSSDataSet.Analysis' table. You can move, or remove it, as needed.
        Me.AnalysisTableAdapter.Fill(Me.DSSAnalysisDataSet.Analysis)
        'TODO: This line of code loads data into the 'DSSAnalysisDataSet.Analysis' table. You can move, or remove it, as needed.
        Me.AnalysisTableAdapter.Fill(Me.DSSAnalysisDataSet.Analysis)
        'TODO: This line of code loads data into the 'MTCEDATABASEDataSet.SEMT' table. You can move, or remove it, as needed.
        Me.SEMTTableAdapter.Fill(Me.MTCEDATABASEDataSet.SEMT)
        'TODO: This line of code loads data into the 'MTCEDATABASEDataSet.SAAT' table. You can move, or remove it, as needed.
        Me.SAATTableAdapter.Fill(Me.MTCEDATABASEDataSet.SAAT)


        'saved available fund
        AvailFund.Text = My.Settings.availableFund


        RankDataGridView.AllowUserToAddRows = False
        RankDataGridView.ReadOnly = True
        RankDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        RankDataGridView.MultiSelect = True
        RankDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        RankDataGridView.AllowUserToResizeColumns = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'SAAT

        For i As Integer = 0 To AnalysisDataGridView.Rows.Count - 1
            If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" Then
                AnalysisDataGridView.Rows(i).Cells(2).Value = My.Settings.SAATAvCSI
                AnalysisDataGridView.Rows(i).Cells(3).Value = My.Settings.SAATFundAllo
                AnalysisDataGridView.Rows(i).Cells(4).Value = My.Settings.SAATReplaceCost
                AnalysisDataGridView.Rows(i).Cells(5).Value = My.Settings.SAATRepairCost
                AnalysisDataGridView.Rows(i).Cells(6).Value = My.Settings.SAATLifeSpan
                AnalysisDataGridView.Rows(i).Cells(7).Value = My.Settings.SAATAge
                AnalysisDataGridView.Rows(i).Cells(8).Value = My.Settings.SAATRemainingLife
            End If

            If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" Then
                AnalysisDataGridView.Rows(i).Cells(2).Value = My.Settings.SETAvCSI
                AnalysisDataGridView.Rows(i).Cells(3).Value = My.Settings.SETFundAllo
                AnalysisDataGridView.Rows(i).Cells(4).Value = My.Settings.SETReplaceCost
                AnalysisDataGridView.Rows(i).Cells(5).Value = My.Settings.SETRepairCost
                AnalysisDataGridView.Rows(i).Cells(6).Value = My.Settings.SETLifeSpan
                AnalysisDataGridView.Rows(i).Cells(7).Value = My.Settings.SETAge
                AnalysisDataGridView.Rows(i).Cells(8).Value = My.Settings.SETRemainingLife
            End If

            If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" Then
                AnalysisDataGridView.Rows(i).Cells(2).Value = My.Settings.SEETAvCSI
                AnalysisDataGridView.Rows(i).Cells(3).Value = My.Settings.SEETFundAllo
                AnalysisDataGridView.Rows(i).Cells(4).Value = My.Settings.SEETReplaceCost
                AnalysisDataGridView.Rows(i).Cells(5).Value = My.Settings.SEETRepairCost
                AnalysisDataGridView.Rows(i).Cells(6).Value = My.Settings.SEETLifeSpan
                AnalysisDataGridView.Rows(i).Cells(7).Value = My.Settings.SEETAge
                AnalysisDataGridView.Rows(i).Cells(8).Value = My.Settings.SEETRemainingLife
            End If

            If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" Then
                AnalysisDataGridView.Rows(i).Cells(2).Value = My.Settings.SEMTAvCSI
                AnalysisDataGridView.Rows(i).Cells(3).Value = My.Settings.SEMTFundAllo
                AnalysisDataGridView.Rows(i).Cells(4).Value = My.Settings.SEMTReplaceCost
                AnalysisDataGridView.Rows(i).Cells(5).Value = My.Settings.SEMTRepairCost
                AnalysisDataGridView.Rows(i).Cells(6).Value = My.Settings.SEMTLifeSpan
                AnalysisDataGridView.Rows(i).Cells(7).Value = My.Settings.SEMTAge
                AnalysisDataGridView.Rows(i).Cells(8).Value = My.Settings.SEMTRemainingLife
            End If

            If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" Then
                AnalysisDataGridView.Rows(i).Cells(2).Value = My.Settings.SICTAvCSI
                AnalysisDataGridView.Rows(i).Cells(3).Value = My.Settings.SICTFundAllo
                AnalysisDataGridView.Rows(i).Cells(4).Value = My.Settings.SICTReplaceCost
                AnalysisDataGridView.Rows(i).Cells(5).Value = My.Settings.SICTRepairCost
                AnalysisDataGridView.Rows(i).Cells(6).Value = My.Settings.SICTLifeSpan
                AnalysisDataGridView.Rows(i).Cells(7).Value = My.Settings.SICTAge
                AnalysisDataGridView.Rows(i).Cells(8).Value = My.Settings.SICTRemainingLife
            End If
        Next


        'update the charts

        Chart1.Update()
        Chart2.Update()
        Chart3.Update()
        Chart4.Update()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        On Error GoTo saveErr
        'mAIN COMPUT..
        AnalysisBindingSource.EndEdit()
        AnalysisTableAdapter.Update(DSSAnalysisDataSet.Analysis)

        'RANK COMP...
        RankBindingSource.EndEdit()
        RankTableAdapter.Update(RankDataBaseDataSet.Rank)

        MsgBox("Data Saved Successfully!", MsgBoxStyle.Information, "Successful")
saveErr:
        Exit Sub
    End Sub

    Private Sub AvailFund_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AvailFund.Validating
        If (AvailFund.Text.Trim().Length = 0) Then
            AvailFund.BackColor = Color.Yellow
            ErrorProvider1.SetError(AvailFund, "No Data for Available Fund")
            AvailFund.Focus()
        Else
            AvailFund.BackColor = Color.White
            ErrorProvider1.SetError(AvailFund, "")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'to calculate DSS index

        For i As Integer = 0 To RankDataGridView.RowCount - 1

            RankDataGridView.Rows(i).Cells(6).Value = ((RankDataGridView.Rows(i).Cells(5).Value) + (RankDataGridView.Rows(i).Cells(4).Value) + (RankDataGridView.Rows(i).Cells(3).Value) + (RankDataGridView.Rows(i).Cells(2).Value)) / (RankDataGridView.ColumnCount - 3)

        Next

        RankDataGridView.Columns(6).DefaultCellStyle.Format = "N2"

        RankDataGridView.Sort(RankDataGridView.Columns(6), System.ComponentModel.ListSortDirection.Ascending)


        '***********************************color yayoooooooooooooo*****************************************
        '*******************************************************SORTING AND RANKING TO DATAGRID********************************************

        'color
        If RankDataGridView.Rows(0).Cells(2).Value = 1 Then
                RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.Green
                RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(0).Cells(2).Value = 2 Then
                RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.GreenYellow
                RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(0).Cells(2).Value = 3 Then
                RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.Yellow
                RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(0).Cells(2).Value = 4 Then
                RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.PaleVioletRed
                RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(0).Cells(2).Value = 5 Then
                RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.Red
                RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.White
            End If




            'color
            If RankDataGridView.Rows(1).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.White
                    End If




        'color
        If RankDataGridView.Rows(2).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.White
                    End If


        'color
        If RankDataGridView.Rows(3).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.White
                    End If


        'color
        If RankDataGridView.Rows(4).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.White
                    End If



            '************************REPLACE SECTION***************************

            'color
            If RankDataGridView.Rows(0).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.White
                    End If


            'color
            If RankDataGridView.Rows(1).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.White
                    End If


            'color
            If RankDataGridView.Rows(2).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.White
                    End If


            'color
            If RankDataGridView.Rows(3).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.White
                    End If



            'color
            If RankDataGridView.Rows(4).Cells(3).Value = 1 Then
                RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.Green
                RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(4).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.White
                    End If






            'Repair cost

            'color
            If RankDataGridView.Rows(0).Cells(4).Value = 1 Then
                RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.Green
                RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(0).Cells(4).Value = 2 Then
                RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.GreenYellow
                RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(0).Cells(4).Value = 3 Then
                RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.Yellow
                RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(0).Cells(4).Value = 4 Then
                RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.PaleVioletRed
                RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(0).Cells(4).Value = 5 Then
                RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.Red
                RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.White
            End If



            'color
            If RankDataGridView.Rows(1).Cells(4).Value = 1 Then
                RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.Green
                RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(1).Cells(4).Value = 2 Then
                RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.GreenYellow
                RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(1).Cells(4).Value = 3 Then
                RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.Yellow
                RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(1).Cells(4).Value = 4 Then
                RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.PaleVioletRed
                RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(1).Cells(4).Value = 5 Then
                RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.Red
                RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.White
            End If




            'color
            If RankDataGridView.Rows(2).Cells(4).Value = 1 Then
                RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.Green
                RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(2).Cells(4).Value = 2 Then
                RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.GreenYellow
                RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(2).Cells(4).Value = 3 Then
                RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.Yellow
                RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(2).Cells(4).Value = 4 Then
                RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.PaleVioletRed
                RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(2).Cells(4).Value = 5 Then
                RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.Red
                RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.White
            End If



            'color
            If RankDataGridView.Rows(3).Cells(4).Value = 1 Then
                RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.Green
                RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(3).Cells(4).Value = 2 Then
                RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.GreenYellow
                RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(3).Cells(4).Value = 3 Then
                RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.Yellow
                RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(3).Cells(4).Value = 4 Then
                RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.PaleVioletRed
                RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(3).Cells(4).Value = 5 Then
                RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.Red
                RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.White
            End If




            'color
            If RankDataGridView.Rows(4).Cells(4).Value = 1 Then
                RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.Green
                RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(4).Cells(4).Value = 2 Then
                RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.GreenYellow
                RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(4).Cells(4).Value = 3 Then
                RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.Yellow
                RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(4).Cells(4).Value = 4 Then
                RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.PaleVioletRed
                RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(4).Cells(4).Value = 5 Then
                RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.Red
                RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.White
            End If




            'Remaining Life
            'color
            If RankDataGridView.Rows(0).Cells(5).Value = 1 Then
                RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.Green
                RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(0).Cells(5).Value = 2 Then
                RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.GreenYellow
                RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(0).Cells(5).Value = 3 Then
                RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.Yellow
                RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(0).Cells(5).Value = 4 Then
                RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.PaleVioletRed
                RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(0).Cells(5).Value = 5 Then
                RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.Red
                RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.White
            End If




            'color
            If RankDataGridView.Rows(1).Cells(5).Value = 1 Then
                    RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.Green
                    RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.White
                End If
                If RankDataGridView.Rows(1).Cells(5).Value = 2 Then
                    RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.GreenYellow
                    RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.Black
                End If
                If RankDataGridView.Rows(1).Cells(5).Value = 3 Then
                    RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.Yellow
                    RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.Black
                End If
                If RankDataGridView.Rows(1).Cells(5).Value = 4 Then
                    RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.PaleVioletRed
                    RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.White
                End If
                If RankDataGridView.Rows(1).Cells(5).Value = 5 Then
                    RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.Red
                    RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.White
                End If





                'color
                If RankDataGridView.Rows(2).Cells(5).Value = 1 Then
                    RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.Green
                    RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.White
                End If
                If RankDataGridView.Rows(2).Cells(5).Value = 2 Then
                    RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.GreenYellow
                    RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.Black
                End If
                If RankDataGridView.Rows(2).Cells(5).Value = 3 Then
                    RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.Yellow
                    RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.Black
                End If
                If RankDataGridView.Rows(2).Cells(5).Value = 4 Then
                    RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.PaleVioletRed
                    RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.White
                End If
                If RankDataGridView.Rows(2).Cells(5).Value = 5 Then
                    RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.Red
                    RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.White
                End If



                'color
                If RankDataGridView.Rows(3).Cells(5).Value = 1 Then
                    RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.Green
                    RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.White
                End If
                If RankDataGridView.Rows(3).Cells(5).Value = 2 Then
                    RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.GreenYellow
                    RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.Black
                End If
                If RankDataGridView.Rows(3).Cells(5).Value = 3 Then
                    RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.Yellow
                    RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.Black
                End If
                If RankDataGridView.Rows(3).Cells(5).Value = 4 Then
                    RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.PaleVioletRed
                    RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.White
                End If
                If RankDataGridView.Rows(3).Cells(5).Value = 5 Then
                    RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.Red
                    RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.White
                End If


            'color
            If RankDataGridView.Rows(4).Cells(5).Value = 1 Then
                RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.Green
                RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(4).Cells(5).Value = 2 Then
                RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.GreenYellow
                RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(4).Cells(5).Value = 3 Then
                RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.Yellow
                RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.Black
            End If
            If RankDataGridView.Rows(4).Cells(5).Value = 4 Then
                RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.PaleVioletRed
                RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.White
            End If
            If RankDataGridView.Rows(4).Cells(5).Value = 5 Then
                RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.Red
                RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.White
            End If





            '****************************************************************************************************************************
            'Decision Base on Physical State
            FirstChoice.Text = RankDataGridView.Rows(0).Cells(1).Value
        SecondChoice.Text = RankDataGridView.Rows(1).Cells(1).Value
        ThirdChoice.Text = RankDataGridView.Rows(2).Cells(1).Value
        FourthChoice.Text = RankDataGridView.Rows(3).Cells(1).Value
        FifthChoice.Text = RankDataGridView.Rows(4).Cells(1).Value

        'Decision Base on fund available
        CheckBox1.Text = RankDataGridView.Rows(0).Cells(1).Value
        CheckBox2.Text = RankDataGridView.Rows(1).Cells(1).Value
        CheckBox3.Text = RankDataGridView.Rows(2).Cells(1).Value
        CheckBox4.Text = RankDataGridView.Rows(3).Cells(1).Value
        CheckBox5.Text = RankDataGridView.Rows(4).Cells(1).Value

        GroupBox4.Visible = True

        GroupBox5.Visible = True



    End Sub

    Private Sub AnalyzeButton_Click(sender As Object, e As EventArgs) Handles AnalyzeButton.Click
        '*******************************************************SORTING AND RANKING TO DATAGRID********************************************
        If BCSI.Checked = True Then

            For i As Integer = 0 To AnalysisDataGridView.Rows.Count - 1
                AnalysisDataGridView.Sort(AnalysisDataGridView.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
                'BICS
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" Then
                    RankDataGridView.Rows(0).Cells(2).Value = i + 1
                    'color
                    If RankDataGridView.Rows(0).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(0).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(0).Cells(2).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" Then
                    RankDataGridView.Rows(1).Cells(2).Value = i + 1
                    'color
                    If RankDataGridView.Rows(1).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(1).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(1).Cells(2).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" Then
                    RankDataGridView.Rows(2).Cells(2).Value = i + 1
                    'color
                    If RankDataGridView.Rows(2).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(2).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(2).Cells(2).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" Then
                    RankDataGridView.Rows(3).Cells(2).Value = i + 1
                    'color
                    If RankDataGridView.Rows(3).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(3).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(3).Cells(2).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" Then
                    RankDataGridView.Rows(4).Cells(2).Value = i + 1
                    'color
                    If RankDataGridView.Rows(4).Cells(2).Value = 1 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.Green
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(2).Value = 2 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(2).Value = 3 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(2).Value = 4 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(2).Value = 5 Then
                        RankDataGridView.Rows(4).Cells(2).Style.BackColor = Color.Red
                        RankDataGridView.Rows(4).Cells(2).Style.ForeColor = Color.White
                    End If
                End If



            Next

        End If


        '************************REPLACE SECTION***************************
        If ReplaceCost.Checked = True Then

            For i As Integer = 0 To AnalysisDataGridView.Rows.Count - 1
                AnalysisDataGridView.Sort(AnalysisDataGridView.Columns(4), System.ComponentModel.ListSortDirection.Ascending)
                'Replacement cost
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" Then
                    RankDataGridView.Rows(0).Cells(3).Value = i + 1
                    'color
                    If RankDataGridView.Rows(0).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(0).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(0).Cells(3).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" Then
                    RankDataGridView.Rows(1).Cells(3).Value = i + 1
                    'color
                    If RankDataGridView.Rows(1).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(1).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(1).Cells(3).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" Then
                    RankDataGridView.Rows(2).Cells(3).Value = i + 1
                    'color
                    If RankDataGridView.Rows(2).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(2).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(2).Cells(3).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" Then
                    RankDataGridView.Rows(3).Cells(3).Value = i + 1
                    'color
                    If RankDataGridView.Rows(3).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(3).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(3).Cells(3).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" Then
                    RankDataGridView.Rows(4).Cells(3).Value = i + 1
                    'color
                    If RankDataGridView.Rows(4).Cells(3).Value = 1 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.Green
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(3).Value = 2 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(3).Value = 3 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(3).Value = 4 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(3).Value = 5 Then
                        RankDataGridView.Rows(4).Cells(3).Style.BackColor = Color.Red
                        RankDataGridView.Rows(4).Cells(3).Style.ForeColor = Color.White
                    End If
                End If
            Next


        End If



        If RepairCost.Checked = True Then

            For i As Integer = 0 To AnalysisDataGridView.Rows.Count - 1
                AnalysisDataGridView.Sort(AnalysisDataGridView.Columns(5), System.ComponentModel.ListSortDirection.Ascending)
                'Repair cost
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" Then
                    RankDataGridView.Rows(0).Cells(4).Value = i + 1
                    'color
                    If RankDataGridView.Rows(0).Cells(4).Value = 1 Then
                        RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.Green
                        RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(4).Value = 2 Then
                        RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(4).Value = 3 Then
                        RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(4).Value = 4 Then
                        RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(4).Value = 5 Then
                        RankDataGridView.Rows(0).Cells(4).Style.BackColor = Color.Red
                        RankDataGridView.Rows(0).Cells(4).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" Then
                    RankDataGridView.Rows(1).Cells(4).Value = i + 1
                    'color
                    If RankDataGridView.Rows(1).Cells(4).Value = 1 Then
                        RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.Green
                        RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(4).Value = 2 Then
                        RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(4).Value = 3 Then
                        RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(4).Value = 4 Then
                        RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(4).Value = 5 Then
                        RankDataGridView.Rows(1).Cells(4).Style.BackColor = Color.Red
                        RankDataGridView.Rows(1).Cells(4).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" Then
                    RankDataGridView.Rows(2).Cells(4).Value = i + 1
                    'color
                    If RankDataGridView.Rows(2).Cells(4).Value = 1 Then
                        RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.Green
                        RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(4).Value = 2 Then
                        RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(4).Value = 3 Then
                        RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(4).Value = 4 Then
                        RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(4).Value = 5 Then
                        RankDataGridView.Rows(2).Cells(4).Style.BackColor = Color.Red
                        RankDataGridView.Rows(2).Cells(4).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" Then
                    RankDataGridView.Rows(3).Cells(4).Value = i + 1
                    'color
                    If RankDataGridView.Rows(3).Cells(4).Value = 1 Then
                        RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.Green
                        RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(4).Value = 2 Then
                        RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(4).Value = 3 Then
                        RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(4).Value = 4 Then
                        RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(4).Value = 5 Then
                        RankDataGridView.Rows(3).Cells(4).Style.BackColor = Color.Red
                        RankDataGridView.Rows(3).Cells(4).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" Then
                    RankDataGridView.Rows(4).Cells(4).Value = i + 1
                    'color
                    If RankDataGridView.Rows(4).Cells(4).Value = 1 Then
                        RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.Green
                        RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(4).Value = 2 Then
                        RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(4).Value = 3 Then
                        RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(4).Value = 4 Then
                        RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(4).Value = 5 Then
                        RankDataGridView.Rows(4).Cells(4).Style.BackColor = Color.Red
                        RankDataGridView.Rows(4).Cells(4).Style.ForeColor = Color.White
                    End If
                End If
            Next

        End If



        If RemainingLife.Checked = True Then

            For i As Integer = 0 To AnalysisDataGridView.Rows.Count - 1
                AnalysisDataGridView.Sort(AnalysisDataGridView.Columns(6), System.ComponentModel.ListSortDirection.Ascending)
                'Remaining Life
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" Then
                    RankDataGridView.Rows(0).Cells(5).Value = i + 1
                    'color
                    If RankDataGridView.Rows(0).Cells(5).Value = 1 Then
                        RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.Green
                        RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(5).Value = 2 Then
                        RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(5).Value = 3 Then
                        RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(0).Cells(5).Value = 4 Then
                        RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(0).Cells(5).Value = 5 Then
                        RankDataGridView.Rows(0).Cells(5).Style.BackColor = Color.Red
                        RankDataGridView.Rows(0).Cells(5).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" Then
                    RankDataGridView.Rows(1).Cells(5).Value = i + 1
                    'color
                    If RankDataGridView.Rows(1).Cells(5).Value = 1 Then
                        RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.Green
                        RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(5).Value = 2 Then
                        RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(5).Value = 3 Then
                        RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(1).Cells(5).Value = 4 Then
                        RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(1).Cells(5).Value = 5 Then
                        RankDataGridView.Rows(1).Cells(5).Style.BackColor = Color.Red
                        RankDataGridView.Rows(1).Cells(5).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" Then
                    RankDataGridView.Rows(2).Cells(5).Value = i + 1
                    'color
                    If RankDataGridView.Rows(2).Cells(5).Value = 1 Then
                        RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.Green
                        RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(5).Value = 2 Then
                        RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(5).Value = 3 Then
                        RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(2).Cells(5).Value = 4 Then
                        RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(2).Cells(5).Value = 5 Then
                        RankDataGridView.Rows(2).Cells(5).Style.BackColor = Color.Red
                        RankDataGridView.Rows(2).Cells(5).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" Then
                    RankDataGridView.Rows(3).Cells(5).Value = i + 1
                    'color
                    If RankDataGridView.Rows(3).Cells(5).Value = 1 Then
                        RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.Green
                        RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(5).Value = 2 Then
                        RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(5).Value = 3 Then
                        RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(3).Cells(5).Value = 4 Then
                        RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(3).Cells(5).Value = 5 Then
                        RankDataGridView.Rows(3).Cells(5).Style.BackColor = Color.Red
                        RankDataGridView.Rows(3).Cells(5).Style.ForeColor = Color.White
                    End If
                End If

                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" Then
                    RankDataGridView.Rows(4).Cells(5).Value = i + 1
                    'color
                    If RankDataGridView.Rows(4).Cells(5).Value = 1 Then
                        RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.Green
                        RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(5).Value = 2 Then
                        RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.GreenYellow
                        RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(5).Value = 3 Then
                        RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.Yellow
                        RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.Black
                    End If
                    If RankDataGridView.Rows(4).Cells(5).Value = 4 Then
                        RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.PaleVioletRed
                        RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.White
                    End If
                    If RankDataGridView.Rows(4).Cells(5).Value = 5 Then
                        RankDataGridView.Rows(4).Cells(5).Style.BackColor = Color.Red
                        RankDataGridView.Rows(4).Cells(5).Style.ForeColor = Color.White
                    End If
                End If

            Next


        End If


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If RadioButton1.Checked Then

            '****************CHECKBOX 1**********************************

            For i As Integer = 0 To AnalysisDataGridView.Rows.Count - 1
                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox1.Text = "SET" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox1.Text = "SEET" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox1.Text = "SEMT" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox1.Text = "SICT" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox1.Text = "SAAT" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                '**********************CHECKBOX2********************************************

                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox2.Text = "SET" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox2.Text = "SEET" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox2.Text = "SEMT" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox2.Text = "SICT" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox2.Text = "SAAT" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                '**********************cHECKBOX 3****************************

                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox3.Text = "SET" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox3.Text = "SEET" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox3.Text = "SEMT" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox3.Text = "SICT" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox3.Text = "SAAT" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If



                '**********************cHECKBOX 4****************************

                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox4.Text = "SET" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox4.Text = "SEET" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox4.Text = "SEMT" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox4.Text = "SICT" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox4.Text = "SAAT" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If


                '**********************cHECKBOX 5****************************

                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox5.Text = "SET" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox5.Text = "SEET" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox5.Text = "SEMT" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox5.Text = "SICT" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox5.Text = "SAAT" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(4).Value
                End If

            Next



            Dim total As Single
            If CheckBox1.Checked = True Then
                total += Val(FirstChoice1.Text)

            End If

            If CheckBox2.Checked = True Then
                total += Val(SecondChoice1.Text)

            End If

            If CheckBox3.Checked = True Then
                total += Val(ThirdChoice1.Text)

            End If

            If CheckBox4.Checked = True Then
                total += Val(FourthChoice1.Text)

            End If

            If CheckBox5.Checked = True Then
                total += Val(FifthChoice1.Text)

            End If

            TextBox1.Text = (total)

            TextBox2.Text = (Val(AvailFund.Text) - Val(TextBox1.Text))

            If Val(TextBox2.Text) < 0 Then
                TextBox2.BackColor = Color.Red
                TextBox2.ForeColor = Color.White
            Else
                TextBox2.BackColor = Color.White
                TextBox2.ForeColor = Color.Black
            End If
        End If





        If RadioButton2.Checked Then

            '****************CHECKBOX 1**********************************

            For i As Integer = 0 To AnalysisDataGridView.Rows.Count - 1
                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox1.Text = "SET" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox1.Text = "SEET" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox1.Text = "SEMT" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox1.Text = "SICT" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox1.Text = "SAAT" Then
                    FirstChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                '**********************CHECKBOX2********************************************

                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox2.Text = "SET" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox2.Text = "SEET" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox2.Text = "SEMT" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox2.Text = "SICT" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox2.Text = "SAAT" Then
                    SecondChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                '**********************cHECKBOX 3****************************

                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox3.Text = "SET" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox3.Text = "SEET" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox3.Text = "SEMT" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox3.Text = "SICT" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox3.Text = "SAAT" Then
                    ThirdChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If



                '**********************cHECKBOX 4****************************

                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox4.Text = "SET" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox4.Text = "SEET" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox4.Text = "SEMT" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox4.Text = "SICT" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox4.Text = "SAAT" Then
                    FourthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If


                '**********************cHECKBOX 5****************************

                'SET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SET" And CheckBox5.Text = "SET" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEET
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEET" And CheckBox5.Text = "SEET" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SEMT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SEMT" And CheckBox5.Text = "SEMT" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SICT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SICT" And CheckBox5.Text = "SICT" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

                'SAAT
                If AnalysisDataGridView.Rows(i).Cells(1).Value = "SAAT" And CheckBox5.Text = "SAAT" Then
                    FifthChoice1.Text = AnalysisDataGridView.Rows(i).Cells(5).Value
                End If

            Next



            Dim total As Single
            If CheckBox1.Checked = True Then
                total += Val(FirstChoice1.Text)

            End If

            If CheckBox2.Checked = True Then
                total += Val(SecondChoice1.Text)

            End If

            If CheckBox3.Checked = True Then
                total += Val(ThirdChoice1.Text)

            End If

            If CheckBox4.Checked = True Then
                total += Val(FourthChoice1.Text)

            End If

            If CheckBox5.Checked = True Then
                total += Val(FifthChoice1.Text)

            End If

            TextBox1.Text = (total)

            TextBox2.Text = (Val(AvailFund.Text) - Val(TextBox1.Text))

            If Val(TextBox2.Text) < 0 Then
                TextBox2.BackColor = Color.Red
                TextBox2.ForeColor = Color.White
            Else
                TextBox2.BackColor = Color.White
                TextBox2.ForeColor = Color.Black
            End If
        End If


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'update the charts

        Chart1.Update()
        Chart2.Update()
        Chart3.Update()
        Chart4.Update()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        My.Settings.availableFund = AvailFund.Text
    End Sub


End Class