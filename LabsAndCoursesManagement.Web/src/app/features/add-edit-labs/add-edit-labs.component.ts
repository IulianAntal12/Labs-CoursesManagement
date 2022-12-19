import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAccordion } from '@angular/material/expansion';
import { LabDto } from 'src/app/core/models/lab-dto.model';
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
  labDto: LabDto;
  constructor(private readonly service: LabsService) {}

  ngOnInit(): void {
    this.getLabs();
    this.addFormGroup = this.initializeFormGroup();
  }

  public getLabs() {
    this.labs = [];
    this.formGroupArray = [];
    this.service.getLabs().subscribe((data: Lab[]) => {
      for (const lab of data) {
        this.labs.push(lab);
        this.formGroupArray.push(this.initializeFormGroup());
      }
    });
  }

  initializeFormGroup(): FormGroup {
    return new FormGroup({
      name: new FormControl('', Validators.required),
      group: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      year: new FormControl('', Validators.required),
      semester: new FormControl('', Validators.required),
    });
  }

  submitEdit(index: number): void {
    this.labDto = this.formGroupArray[index].getRawValue();
    console.log(this.formGroupArray[index].getRawValue());
    this.labDto.teacherId = '179dd456-8d56-4993-821a-b09e596cc7ed';
    this.service
      .updateLab(this.labs[index].id, this.labDto)
      .subscribe((lab: Lab) =>{
        console.log(lab);
        this.labs[index] = lab;
      } );
  }
  submitAdd(): void {
    this.labDto = this.addFormGroup.getRawValue();
    this.labDto.teacherId ='179dd456-8d56-4993-821a-b09e596cc7ed';
    console.log(this.addFormGroup.getRawValue());
    this.service.createLab(this.labDto).subscribe((lab: Lab) => {
      console.log(lab);
      this.labs.push(lab);
      this.formGroupArray.push(this.initializeFormGroup());
    });
  }

  deleteLab(lab: Lab): void {
    this.service.deleteLab(lab.id).subscribe();
    const index = this.labs.indexOf(lab);
    this.labs.splice(index, 1);
    this.formGroupArray.splice(index, 1);
  }
}
