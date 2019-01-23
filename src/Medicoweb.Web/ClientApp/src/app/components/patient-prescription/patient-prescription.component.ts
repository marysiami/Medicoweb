import { Component } from "@angular/core";
import { AuthService } from "./../../services/auth.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-patient-prescription",
  templateUrl: "./patient-prescription.component.html"
})
export class PatientPrescriptionComponent {

  isLoggedIn: boolean;
  patientId: string;
  visitId: string;

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.patientId = this.route.snapshot.paramMap.get("id");
  }

 


}
