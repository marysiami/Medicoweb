import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-patient-home',
  templateUrl: './patient-home.component.html'
})
export class PatientHomeComponent {

  isLoggedIn: boolean;
  patientId: string;

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn()
    this.patientId = this.route.snapshot.paramMap.get('id');
  }

  openNewVisit() {
    this.router.navigateByUrl('/newVisit');
  }
  openMyPrescription() {
    this.router.navigateByUrl('/prescriptions/'+this.patientId);
  }
  openMyVisit() {
    this.router.navigateByUrl('/visits/' + this.patientId);
  }

}
