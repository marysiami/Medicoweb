import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { MatTableDataSource } from '@angular/material/table';
import { PatientListing } from '../../models/patient-listing.model';
import { Patient } from '../../models/patient.model';
import { HospitalService } from '../../services/hospital.service';
import { AuthService } from './../../services/auth.service';



@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',

})
export class AdminHomeComponent {
  
  isLoggedIn: boolean;
  constructor(
    private authService: AuthService    
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn()    
  }
  
  
    
}
