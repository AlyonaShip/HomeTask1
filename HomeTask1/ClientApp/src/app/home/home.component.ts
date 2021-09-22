import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public url = 'https://localhost:44350/Home';
  public retPostData;
  public retGetData: User[];
  public retDeleteData;
  public retPutData;
  

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {    

  }  
  
  public PostData() {
    const body = { FirstName: 'Chuck ', LastName: 'Palahniuk' };
    this.http.post(this.url, body).subscribe(
      data => {
        this.retPostData = data;
      },
      err => {
        this.retPostData = err.message;
        console.log("POST Error")
      });
  }

  public GetData() {    
    this.http.get<any>(this.url).subscribe(
      data => {
        this.retGetData = data.returnObject;
      },
      err => {
        console.log("GET Error")
      });
  }

  public PutData() {
    const body = { FirstName: 'Chuck ', LastName: 'Palahniuk' };
    this.http.put<any>(this.url, body).subscribe(
      data => {
        this.retPutData = data.returnObject;
      },
      err => {
        this.retPutData = err.message;
        console.log("PUT Error")
      });
  }

  public DeleteData() {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        FirstName: 'Chuck ',
        LastName: 'Palahniuk'        
      },
    };    
    this.http.delete(this.url, options).subscribe(
      data => {
        this.retDeleteData = data;
      },        
      err => {        
        this.retDeleteData = err.message;               
      });
  }
}

class User {
  firstName: string;
  lastName: string;
}


