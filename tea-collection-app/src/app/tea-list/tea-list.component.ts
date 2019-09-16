import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-tea-list',
  templateUrl: './tea-list.component.html',
  styleUrls: ['./tea-list.component.scss']
})
export class TeaListComponent implements OnInit {

  public list: any[];

  constructor(private api: ApiService) { }

  ngOnInit() {
    this.api.getList().subscribe((list) => {
      this.list = list;
    });
  }

}
