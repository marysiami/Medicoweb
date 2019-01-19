import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',


})
export class AdminHomeComponent {
  
  isLoggedIn: boolean;

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn()    
  }

  openHospital() {
    this.router.navigateByUrl('/hospitals');
  }
  openSpecialization() {
    this.router.navigateByUrl('/specialization');
  }
  openDrugs() {
    this.router.navigateByUrl('/drugs')
  }
  
    
}
