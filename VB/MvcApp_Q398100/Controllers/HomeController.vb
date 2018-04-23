Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Data

Namespace MvcApp_Q398100.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!"

			Return View(NorthwindDataProvider.GetProducts())
		End Function

		Public Function GridViewPartial() As ActionResult
			 Return PartialView("_GridViewPartial", NorthwindDataProvider.GetProducts())
		End Function
	End Class
End Namespace
