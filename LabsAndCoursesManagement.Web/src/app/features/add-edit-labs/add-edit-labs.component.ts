import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
    });
  }

  submitEdit(index: number): void {
    this.labDto = this.formGroupArray[index].getRawValue();
    this.service.updateLab(this.labs[index].id, this.labDto).subscribe((lab: Lab) => this.labs[index] = lab);
  }
  submitAdd(): void {
    console.log(this.addFormGroup.getRawValue());
    this.labDto = this.addFormGroup.getRawValue();
    this.service
      .createLab(this.labDto)
      .subscribe((lab: Lab) => console.log(lab));
  }

  deleteLab(lab: Lab): void {
    this.service.deleteLab(lab.id).subscribe();
    delete this.labs[this.labs.indexOf(lab)];
  }
}
