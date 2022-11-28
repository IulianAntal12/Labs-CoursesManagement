import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterFormComponent } from './register-form/register-form.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { SharedModule } from '../shared/shared.module';
import { CatalogComponent } from './catalog/catalog.component';
import { CatalogTabComponent } from './catalog/catalog-tab/catalog-tab.component';


@NgModule({
  declarations: [
    RegisterFormComponent,
    LoginFormComponent,
    CatalogComponent,
    CatalogTabComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports:[
    RegisterFormComponent,
    LoginFormComponent,
    CatalogComponent
  ]
})
export class FeaturesModule { }
