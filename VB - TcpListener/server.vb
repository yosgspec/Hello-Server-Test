Option Strict On
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Module Program
	Sub Main
		const port=8888
		Dim server As New TcpListener(IPAddress.Loopback,port)
		server.Start()
		Console.WriteLine($"Server Running Port:{port}")
		Do
			Using tcp=server.AcceptTcpClient()
			Using stream=tcp.GetStream()
			Using req As New StreamReader(stream)
			Using res As New StreamWriter(stream)
				Console.WriteLine(tcp.Client.RemoteEndPoint)
				Dim line As String
				Do
					line=req.ReadLine()
				Loop While Not String.IsNullOrWhiteSpace(line)
				res.WriteLine("HTTP/1.0 200 OK")
				res.WriteLine($"Content-Type: text/html charset=UTF-8{vbLf}")
				res.Write("Hello VB Server")
			End Using:End Using:End Using:End Using
		Loop
	End Sub
End Module
