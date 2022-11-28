import { Component } from '@angular/core';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent {
  groups: string[] = ['A1','A2','A3','A4','A5','A6','B1', 'B2', 'B3', 'B4', 'B5', 'X1'];
}
