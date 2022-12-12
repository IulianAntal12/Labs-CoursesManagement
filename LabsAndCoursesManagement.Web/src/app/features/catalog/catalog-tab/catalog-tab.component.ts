import { Component, Input, OnInit } from '@angular/core';
import { Student } from 'src/app/core/models/student.model';

@Component({
  selector: 'app-catalog-tab',
  templateUrl: './catalog-tab.component.html',
  styleUrls: ['./catalog-tab.component.scss']
})
export class CatalogTabComponent implements OnInit{
  @Input() students: Student[];
  displayedColumns = ['position', 'name', 'year', 'identificationNumber', 'options'];
  dataSource: Student[];

  ngOnInit(): void {
    this.dataSource = this.students;
  }

}
