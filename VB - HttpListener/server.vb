Option Strict On
Imports System.Threading.Tasks
Imports System.IO
Imports System.Net

Module Program
	Sub Main
		Const port=8888
		Dim server As New HttpListener()
		server.Prefixes.Add($"http://localhost:{port}/")
		server.Start()
		Console.WriteLine($"Server Running Port:{port}")

		Dim resWrite As Action(Of HttpListenerResponse,String)=Sub(res,resText)
			Dim resByte=System.Text.Encoding.UTF8.GetBytes(resText)
			res.OutputStream.Write(resByte,0,resByte.Length)
		End Sub

		Do
			Dim context=server.GetContext()
			Task.Run(Sub()
				Dim req=context.Request
				Dim res=context.Response
				Console.WriteLine(req.RemoteEndPoint)
				res.StatusCode=200
				res.ContentType="text/html"
				resWrite(res,"Hello VB Server")
				res.Close()
			End Sub)
		Loop
	End Sub
End Module
