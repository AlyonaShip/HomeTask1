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
  public retPutData: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {    

  }  
  
  public PostData() {
    const body = { FirstName: 'Chuck ', LastName: 'Palahniuk' };
    this.http.post(this.url, body).subscribe(
      data => {
        this.retPostData = data;
      },
      err => {
        console.log("POST Error")
      });
  }

  public GetData() {    
    this.http.get<any>(this.url).subscribe(
      data => {
        this.retGetData = data;
      },
      err => {
        console.log("GET Error")
      });
  }

  public PutData() {
    const body = { FirstName: 'Chuck ', LastName: 'Palahniuk'};
    this.http.put<any>(this.url, body).subscribe(
      data => {
        this.retPutData = data
      },
      err => {
        console.log("PUT Error")
      });
  }

  public DeleteData() {    
    this.http.delete(this.url).subscribe(
      () => {
        this.retDeleteData = 'Delete successful'
      },        
      err => {        
        this.retDeleteData = err.message;
        console.log("DELETE Error")
      });
  }
}

class User {
  firstName: string;
  lastName: string;
}


