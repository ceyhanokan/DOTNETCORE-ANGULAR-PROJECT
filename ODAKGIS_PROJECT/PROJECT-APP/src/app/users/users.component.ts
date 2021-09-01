import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  constructor() { }

  user = {
    UserID: 1,
    TcNo: "22222222222",
    FullName: "Ceyhan Okan",
    UserName: 'ceyhan',
    Email: 'ceyhan@gmail.com',
    IsAdmin: 'Evet'
  }
  ngOnInit(): void {
  }

}
