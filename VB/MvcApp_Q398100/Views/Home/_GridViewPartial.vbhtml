@Imports DevExpress.Web.Mvc.UI
@Imports DevExpress.Web.Mvc
@Html.DevExpress().GridView(Sub(settings)
                                     settings.Name = "dxGridView"
                                     settings.KeyFieldName = "ProductID"
                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}
                                     settings.CustomActionRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewCustomAction"}
                                     settings.Columns.Add("ProductID")
                                     settings.Columns.Add("ProductName")
                                     settings.Columns.Add("CategoryID").GroupIndex = 0
                                     settings.Columns.Add("Discontinued", MVCxGridViewColumnType.CheckBox)
                                     settings.CommandColumn.Visible = True
                                     settings.CommandColumn.ShowSelectCheckbox = True
                                     settings.Settings.ShowGroupPanel = True
                                     settings.SetGroupRowContentTemplateContent(Sub(c)
                                                                                    Dim linkSelect = String.Format("<a onclick='SelectGroupedRows({0}, true);' href='javascript:void(0)'>Select All / </a>", c.VisibleIndex)
                                                                                    Dim linkUnselect = String.Format("<a onclick='SelectGroupedRows({1}, false);' href='javascript:void(0)'>Unselect All Rows: {0}</a>", c.GroupText, c.VisibleIndex)
                                                                                    Dim group = String.Format("{0}{1}", linkSelect, linkUnselect)
                                                                                    ViewContext.Writer.Write(group)
                                                                                End Sub)
                                     settings.BeforeGetCallbackResult = Sub(s, e)
                                                                            Dim grid As ASPxGridView = TryCast(s, ASPxGridView)
                                                                            If ViewData("data") Is Nothing Then
                                                                                Return
                                                                            End If
                                                                            Dim data() As String = CStr(ViewData("data")).Split("|"c)
                                                                            Dim index As Integer = Integer.Parse(data(0))
                                                                            Dim value As Boolean = Boolean.Parse(data(1))
                                                                            If data.Length = 2 Then
                                                                                Dim startLevel As Integer = grid.GetRowLevel(index)
                                                                                Dim count As Integer = grid.VisibleRowCount
                                                                                For i As Integer = 1 + index To count - 1
                                                                                    grid.Selection.SetSelection(i, value)
                                                                                    If grid.GetRowLevel(i) <= startLevel Then
                                                                                        Exit For
                                                                                    End If
                                                                                Next i
                                                                            End If
                                                                        End Sub
                                     settings.ClientSideEvents.BeginCallback = "onBeginCallback"
                                 End Sub).Bind(Model).GetHtml()