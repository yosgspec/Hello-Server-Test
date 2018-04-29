from wsgiref.simple_server import make_server

port=8888
def server(environ,start_response):
	status="200 OK"
	headers=[
		 ("Content-Type","text/html; charset=utf-8")
	]
	start_response(status,headers)

	return [b"Hello Python Server"]

print(f"Server Running Port:{port}")
make_server("",port,server).serve_forever()

