import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToDoService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  addItem(model: any) {
    return this.http.post(this.baseUrl + 'todolist/item', model);
  }

  deleteItem(itemId: number) {
    return this.http.delete(this.baseUrl + 'todolist/item/' + itemId);
  }
}
