package main

import (
	// db
	_ "github.com/mattn/go-sqlite3"
	"database/sql"

	
	// misc
	"time"
	"fmt"
	"log"
	"net/http"
	"html/template"
	"github.com/gorilla/mux"
)

type User struct {
	user_id int
	username string
	email string
	pw_hash string
}

var (
	tmpl_layout, _ = template.ParseFiles("templates/layout_go.html")
	tmpl_timeline, _ = template.ParseFiles("templates/timeline_go.html")

	user *User
	username string
	database *sql.DB
)

const URL = "http://127.0.0.1:10000/"

func format_datetime(unix_timestamp int64) string {
	// Function returns date string in required format
	t := time.Unix(unix_timestamp,0)
	strDate := t.Format("2016-12-18 @ 18:18")
	return strDate
}

// Route: /
// Method: GET
func timeline(w http.ResponseWriter, r *http.Request) {
	/*
	Shows a users timeline or if no user is logged in it will
	redirect to the public timeline.  This timeline shows the user's
	messages as well as all the messages of followed users.
	*/
	fmt.Println("We got a visitor from: " + r.RemoteAddr)
	
	if user == nil {
		http.Redirect(w, r, URL + "/public", http.StatusPermanentRedirect)
	} else { 
		//data, _ := database.Query(...) TODO
		
		tmpl_layout.Execute(w, nil)
	}
}

// Route: /public
// Method: GET
func public_timeline(w http.ResponseWriter, r *http.Request) {
	/*Displays the latest messages of all users.*/
	// data, _ := database.Query(...) TODO
	
	tmpl_layout.Execute(w, nil)
}

// Route: /<username> 
// Method: GET
func user_timeline(w http.ResponseWriter, r *http.Request) {
	var profile_user *string = nil // = query_db(...) TODO
	if profile_user == nil {
		w.WriteHeader(http.StatusNotFound)
	}
	if user != nil {
		//followd = query_db() TODO
		// render template TODO
	}
}

// Route: '/login'
// Methods : GET, POST
func login(w http.ResponseWriter, r *http.Request) {

}


// Route: '/register'
// Methods: GET, POST
func register(w http.ResponseWriter, r *http.Request) {

}


// Route: '/logout'
func logout(w http.ResponseWriter, r *http.Request) {

}

func main() { 
  database, _ = sql.Open("sqlite3", "minitwit.db") // TODO: make it reference /tmp
	defer database.Close()
	
	row, _ := database.Query("select user_id from user")
	defer row.Close()
	for row.Next() {
		var id int
		row.Scan(&id)
		fmt.Println(id)
	}
  
	router := mux.NewRouter()
	// Handlefunc("<URL path>", <handler aka method aka controller>)
	router.HandleFunc("/", timeline)
	router.HandleFunc("/public", public_timeline)
	router.HandleFunc("/" + username, user_timeline)
	router.HandleFunc("/login", login).Methods("GET", "POST")
	router.HandleFunc("/register", register).Methods("GET", "POST")
	router.HandleFunc("/logout", logout)

	s := http.StripPrefix("/static/", http.FileServer(http.Dir("./static/")))
	router.PathPrefix("/static/").Handler(s)
	
	server := &http.Server {
		Handler: 	router,
		Addr: 		"127.0.0.1:10000",
		// TODO: enforce timeouts
	}
	
	http.Handle("/", router)
	
	fmt.Println("Opened server at: " + URL)
	log.Fatal(server.ListenAndServe())
}
