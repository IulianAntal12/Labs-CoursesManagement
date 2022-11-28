import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { NavigationMenuComponent } from './header/navigation-menu/navigation-menu.component';
import { NavigationMenuContentComponent } from './header/navigation-menu/navigation-menu-content/navigation-menu-content.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    HeaderComponent,
    NavigationMenuComponent,
    NavigationMenuContentComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    HeaderComponent
  ]
})
export class LayoutModule { }
