import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public users: User[];

  public url = 'https://localhost:44350/Home';
  public retPostData;
  public retGetData;
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
        this.users = data;
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
    this.http.delete(this.url).subscribe(data => console.log(data), err => { console.log("Error") });
  }
}

class User {
  firstName: string;
  lastName: string;
}


