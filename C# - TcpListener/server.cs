using System;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

class Program{
	static void Main(){
		const int port=8888;
		var server=new TcpListener(IPAddress.Loopback,port);
		server.Start();
		Console.WriteLine($"Server Running Port:{port}");
		for(;;){
			using(var tcp=server.AcceptTcpClient())
			using(var stream=tcp.GetStream())
			using(var req=new StreamReader(stream))
			using(var res=new StreamWriter(stream)){
				Console.WriteLine(tcp.Client.RemoteEndPoint);
				string line;
				do{
					line=req.ReadLine();
				} while(!String.IsNullOrWhiteSpace(line));
				res.WriteLine("HTTP/1.0 200 OK");
				res.WriteLine("Content-Type: text/html; charset=UTF-8\n");
				res.Write("Hello C# Server");
			}
		}
	}
}
