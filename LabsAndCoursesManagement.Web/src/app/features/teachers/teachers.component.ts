import { Component, OnInit } from '@angular/core';
import { Teacher } from 'src/app/core/models/teacher.model';
import { TeachersService } from 'src/app/core/services/teachers.service';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.scss'],
})
export class TeachersComponent implements OnInit {
  displayedColumns = ['position', 'name', 'email', 'role', 'cabinet'];
  teachers: Teacher[] = [];
  dataSource: Teacher[];
  constructor(private readonly teachersService: TeachersService) {}
  ngOnInit(): void {
    this.teachersService.getTeachers().subscribe((data: Teacher[]) => {
      console.log(data);
      for (const teacher of data) {
        this.teachers.push(teacher);
      }
      this.dataSource = this.teachers;
    });
  }
}
