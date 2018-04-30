package main

import (
	"fmt"
	"net"
	"net/http"
)

func main(){
	port:=8888
	http.HandleFunc("/",func(w http.ResponseWriter,r *http.Request){
		w.Header().Set("Content-Type","text/html; charset=utf-8")
		fmt.Fprintf(w,"Hello Go Server")
		fmt.Println(net.InterfaceAddrs())
	})

	fmt.Printf("Server Running Port:%d\n",port)
	err:=http.ListenAndServe(fmt.Sprintf(":%d",port),nil)

	if err!=nil {
		fmt.Println(err)
	}
}
