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
  public retPutData;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {    

  }  
  

  public PostData() {    
    const retVal = this.http.post(this.url, { FirstName: 'Tyler', LastName: 'Durden' }).subscribe(data => { this.retPostData = data; });
  }

  public GetData() {    
    this.http.get<User[]>(this.url).subscribe(
      data => {
        this.users = data;
      },
      err => {
        console.log("Error")
      });
  }

  public PutData() {
    const body = { FirstName: 'Tyler', LastName: 'Durden'};
    this.http.put(this.url, body).subscribe(data => this.retPutData = data);
  }

  public DeleteData() {    
    this.http.delete(this.url).subscribe(data => console.log(data), err => { console.log("Error") });
  }
}

interface User {
  firstname: string;
  lastname: string;
}


