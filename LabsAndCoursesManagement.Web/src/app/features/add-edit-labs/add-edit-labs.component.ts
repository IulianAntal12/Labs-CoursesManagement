import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatAccordion } from '@angular/material/expansion';
import { Lab } from 'src/app/core/models/lab.model';
import { LabsService } from 'src/app/core/services/labs.service';

@Component({
  selector: 'app-add-edit-labs',
  templateUrl: './add-edit-labs.component.html',
  styleUrls: ['./add-edit-labs.component.scss'],
})
export class AddEditLabsComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion;
  labs: Lab[] = [];
  formGroupArray: FormGroup[] = [];
  addFormGroup: FormGroup;
  constructor(private readonly service: LabsService) {}

  ngOnInit(): void {
    this.service.getLabs().subscribe((data: Lab[]) => {
      for (const lab of data) {
        this.labs.push(lab);
        this.formGroupArray.push(this.initializeFormGroup());
      }
    });
    this.addFormGroup = this.initializeFormGroup();
  }

  initializeFormGroup(): FormGroup {
    return new FormGroup({
      name: new FormControl(''),
      group: new FormControl(''),
      description: new FormControl(''),
      year: new FormControl(''),
      semester: new FormControl(''),
      teacher: new FormControl('')
    })
  }

  submitEdit(index: number): void {
    console.log("test update")
  }
  submitAdd(): void {
    console.log("test add")
  }
}
