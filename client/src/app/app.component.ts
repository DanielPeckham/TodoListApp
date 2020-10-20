import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'My Todo List';
  items: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getListItems();
  }

  getListItems() {
    this.http.get('https://localhost:5001/api/todolist').subscribe(response => {
      this.items = response;
    }, error => {
      console.log(error);
    }
    );
  }
}
