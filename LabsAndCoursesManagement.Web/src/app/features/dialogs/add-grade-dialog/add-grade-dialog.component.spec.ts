import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGradeDialogComponent } from './add-grade-dialog.component';

describe('AddGradeDialogComponent', () => {
  let component: AddGradeDialogComponent;
  let fixture: ComponentFixture<AddGradeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddGradeDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddGradeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
