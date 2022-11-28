import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterFormComponent } from './register-form/register-form.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    RegisterFormComponent,
    LoginFormComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
  ],
  exports:[
    RegisterFormComponent,
    LoginFormComponent
  ]
})
export class FeaturesModule { }
