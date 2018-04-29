using System;
using System.Threading.Tasks;
using System.IO;
using System.Net;

class Program{
	static void Main(){
		const int port=8888;
		var server=new HttpListener();
		server.Prefixes.Add($"http://localhost:{port}/");
		server.Start();
		Console.WriteLine($"Server Running Port:{port}");

		Action<HttpListenerResponse,string> resWrite=(res,resText)=>{
			byte[] resByte=System.Text.Encoding.UTF8.GetBytes(resText);
			res.OutputStream.Write(resByte,0,resByte.Length);
		};

		for(;;){
			var context=server.GetContext();
			Task.Run(()=>{
				var req=context.Request;
				var res=context.Response;
				Console.WriteLine(req.RemoteEndPoint);
				res.StatusCode=200;
				res.ContentType="text/html";
				resWrite(res,"Hello C# Server");
				res.Close();
			});
		}
	}
}
