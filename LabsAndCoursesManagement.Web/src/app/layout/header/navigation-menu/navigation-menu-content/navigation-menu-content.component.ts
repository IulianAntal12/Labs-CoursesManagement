import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation-menu-content',
  templateUrl: './navigation-menu-content.component.html',
  styleUrls: ['./navigation-menu-content.component.scss']
})
export class NavigationMenuContentComponent {
  @Output() drawerToggle: EventEmitter<unknown> = new EventEmitter();
  constructor(private readonly router: Router) {
    
  }
  goToDashboard(): void {
    this.router.navigateByUrl('Dashboard/WelcomePage');
    this.drawerToggle.emit();
  }

  goToCatalog(): void {
    this.router.navigateByUrl('Dashboard/Catalog');
    this.drawerToggle.emit();
  }

  goToHomeworks(): void {
    this.router.navigateByUrl('Dashboard/Homeworks');
    this.drawerToggle.emit();
  }

  goToCourses(): void {
    this.router.navigateByUrl('Dashboard/Courses');
    this.drawerToggle.emit();
  }

  goToTeachers(): void {
    this.router.navigateByUrl('Dashboard/Teachers');
    this.drawerToggle.emit();
  }
}
