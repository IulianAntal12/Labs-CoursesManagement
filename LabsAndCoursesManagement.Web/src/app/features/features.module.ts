import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterFormComponent } from './register-form/register-form.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { SharedModule } from '../shared/shared.module';
import { CatalogComponent } from './catalog/catalog.component';
import { CatalogTabComponent } from './catalog/catalog-tab/catalog-tab.component';
import { TeachersComponent } from './teachers/teachers.component';
import { AddEditLabsComponent } from './add-edit-labs/add-edit-labs.component';
import { AddEditTeachersComponent } from './add-edit-teachers/add-edit-teachers.component';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';


@NgModule({
  declarations: [
    RegisterFormComponent,
    LoginFormComponent,
    CatalogComponent,
    CatalogTabComponent,
    TeachersComponent,
    AddEditLabsComponent,
    AddEditTeachersComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports:[
    RegisterFormComponent,
    LoginFormComponent,
    CatalogComponent,
    TeachersComponent,
    AddEditLabsComponent,
    AddEditTeachersComponent
  ],
  providers: [HttpClient, FormBuilder]
})
export class FeaturesModule { }
