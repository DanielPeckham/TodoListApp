import { Component, OnInit } from '@angular/core';
import { ToDoService } from '../services/to-do.service';

@Component({
  selector: 'app-todo-list-card',
  templateUrl: './todo-list-card.component.html',
  styleUrls: ['./todo-list-card.component.css']
})
export class TodoListCardComponent implements OnInit {
 

  constructor() { }

  ngOnInit() {
  }


}
