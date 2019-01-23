import { Component } from "@angular/core";
import { AuthService } from "../../services/auth.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  isLoggedIn: boolean;
  admin: boolean;
  patient: boolean;
  doctor: boolean;
  id: string;

  constructor(
    private authService: AuthService,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();    
    this.routePage();
    this.id = this.authService.getUserId();
    
  }
  routePage() {
    if (this.authService.isInRole("Admin")) {
      this.admin = true;
      this.doctor = false;
      this.patient = false;
    }
    else if (this.authService.isInRole("Patient")) {
      this.admin = false;
      this.doctor = false;
      this.patient = true;
    }
    else if (this.authService.isInRole("Doctor")) {
      this.admin = false;
      this.doctor = true;
      this.patient = false;
    }
  }
  openHospital() {
    this.router.navigateByUrl("/hospitals");
  }

  openSpecialization() {
    this.router.navigateByUrl("/specialization");
  }

  openDrugs() {
    this.router.navigateByUrl("/drugs");
  }
  openPatients() {
    this.router.navigateByUrl("/patients");
  }
  openNewVisit() {
    this.router.navigateByUrl(`/newVisit/${this.id}`);
  }

  openMyPrescription() {
    this.router.navigateByUrl(`/prescriptions/${this.id}`);
  }

  openMyVisit() {
    this.router.navigateByUrl(`/visits/${this.id}`);
  }
  openMyVisitDoctor() {
    this.router.navigateByUrl(`/visits/${this.id}`);
  }


  
  
}
