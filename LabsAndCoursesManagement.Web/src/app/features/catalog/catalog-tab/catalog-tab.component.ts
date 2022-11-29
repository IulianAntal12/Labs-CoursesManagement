import { AfterViewInit, Component, inject, Input, OnInit } from '@angular/core';
import { Lab } from 'src/app/core/models/lab.model';
import { Student } from 'src/app/core/models/student.model';
import { LabsService } from 'src/app/core/services/labs.service';

@Component({
  selector: 'app-catalog-tab',
  templateUrl: './catalog-tab.component.html',
  styleUrls: ['./catalog-tab.component.scss']
})
export class CatalogTabComponent implements OnInit{
  @Input() students: Student[];
  displayedColumns = ['position', 'name', 'year', 'identificationNumber'];
  dataSource: Student[];

  ngOnInit(): void {
    this.dataSource = this.students;
  }

}
