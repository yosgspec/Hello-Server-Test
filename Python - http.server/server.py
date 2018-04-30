from http.server import HTTPServer,SimpleHTTPRequestHandler

port=8888
class server(SimpleHTTPRequestHandler):
	def do_GET(self):
		self.send_response(200)
		self.send_header("Content-type","text/html; charset=utf-8")
		self.end_headers()
		self.wfile.write(b"Hello Python Server")

print(f"Server Running Port:{port}")
HTTPServer(("localhost",port),server).serve_forever()
