import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-tea-item',
  templateUrl: './tea-item.component.html',
  styleUrls: ['./tea-item.component.scss']
})
export class TeaItemComponent implements OnInit {

  public tea: any;

  constructor(private route: ActivatedRoute, private api: ApiService) { }

  ngOnInit() {
    const id: Observable<string> = this.route.params.pipe(map(p => p.id));

    id.subscribe((i) => {
      this.api.get(+i).subscribe((tea) => {
        this.tea = tea;
      });
    });
  }

}
