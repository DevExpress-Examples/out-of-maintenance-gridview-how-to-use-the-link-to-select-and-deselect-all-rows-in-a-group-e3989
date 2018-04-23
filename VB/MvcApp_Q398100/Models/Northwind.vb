Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections
Imports DevExpress.Web
Imports MvcApp_Q398100.Models

Public NotInheritable Class NorthwindDataProvider

	Private Sub New()
	End Sub

'INSTANT VB NOTE: The variable db was renamed since Visual Basic does not allow variables and other class members to have the same name:
	Private Shared db_Renamed As NorthwindDataContext
	Public Shared ReadOnly Property DB() As NorthwindDataContext
		Get
			If db_Renamed Is Nothing Then
				db_Renamed = New NorthwindDataContext()
			End If
			Return db_Renamed
		End Get
	End Property
	Public Shared Function GetProducts() As IEnumerable
		Return From product In DB.Products
		       Select product
	End Function
End Class
