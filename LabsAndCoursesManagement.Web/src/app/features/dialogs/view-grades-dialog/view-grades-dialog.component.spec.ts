import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewGradesDialogComponent } from './view-grades-dialog.component';

describe('ViewGradesDialogComponent', () => {
  let component: ViewGradesDialogComponent;
  let fixture: ComponentFixture<ViewGradesDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewGradesDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewGradesDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
