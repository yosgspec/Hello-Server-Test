var http=require("http");

const port=8888;
const server=http.createServer((req,res)=>{
	console.log(req.headers["x-forwarded-for"]
		|| req.connection? req.connection.remoteAddress:null
		|| req.connection.socket? req.connection.socket.remoteAddress:null
		|| req.socket.remoteAddress? req.socket.remoteAddress:null
		|| "0.0.0.0"
	);
	res.writeHead(200,{"Content-Type":"text/html; charset=utf-8"});
	res.write("Hello Node Server");
	res.end();
});
server.listen(port);

console.log(`Server Running Port:${port}`);
