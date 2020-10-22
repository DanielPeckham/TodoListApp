import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToDoService } from '../services/to-do.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {
  model: any = {};
  items: any;
  itemAdded: boolean;

  constructor(
    private http: HttpClient,
    private service: ToDoService) { }

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

  addItem() {
    this.service.addItem(this.model).subscribe(response => {
      this.itemAdded = true;
      this.getListItems();
      this.model.itemContent = '';
    }, error => {
      console.log(error);
    }
    );
  }

  deleteItem(itemId: number) {
    this.service.deleteItem(itemId).subscribe(response => {
      this.getListItems();
    }, error => {
      console.log(error);
    });
  }

}
