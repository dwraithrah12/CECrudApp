import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit, OnDestroy {
  users: any;
  getUserSubscription: Subscription;

  constructor(private httpClient: HttpClient ) {}

  ngOnInit() {
    this.getUsers();
  }

  getUsers(){
    this.getUserSubscription = this.httpClient.get('http://localhost:5000/api/users').subscribe(response => {
      this.users = response;
    }, error => {
      console.log('Something went wrong with retrieving the users.');
    });
  }

  ngOnDestroy(){
   this.getUserSubscription.unsubscribe();
  }
}
