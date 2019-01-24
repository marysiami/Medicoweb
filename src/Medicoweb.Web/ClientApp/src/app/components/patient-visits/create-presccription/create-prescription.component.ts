
import { FormControl, Validators } from "@angular/forms";
import { Component } from "@angular/core";
import { toTypeScript } from "@angular/compiler";
import { AuthService } from "../../../services/auth.service";
import { ActivatedRoute, Router } from "@angular/router";
import { HospitalService } from "../../../services/hospital.service";
import { Prescription } from "../../../models/prescription.model";

@Component({
  selector: "app-create-prescription",
  templateUrl: "./create-prescription.component.html",

})
export class CreatePrescriptionComponent {

  isLoggedIn: boolean;
  drugList = [];
  visitId: string;
  drugId: string;
  drugQuantity: number;
  prescriptionId: string;
 

  commentFC = new FormControl('', [
    Validators.required,
    Validators.maxLength(3),
    Validators.pattern(/[0-9]/)
  ]); 
  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private hospitalService: HospitalService,
  ) {
  }

  ngOnInit() {

    this.isLoggedIn = this.authService.isLoggedIn();  
    this.visitId = this.route.snapshot.paramMap.get("id");
    this.createPrescription(); // na start tworze recepte
    this.getDrugs();
  }

  getDrugs() {
    this.hospitalService.getDrugs(0, 10)
      .subscribe(result => {
        this.drugList = result.drugs;
      });
    
  }
  getDrug(event) {
    
    this.drugId = event.value.id 
  }
  createPrescription() {
    this.hospitalService.createPrescription(this.visitId).subscribe(result => {
      this.prescriptionId = result.id;     
    });
  }

  addDrugToPrescription() {
    this.hospitalService.addDrugToPrescription(this.drugId, this.commentFC.value, this.prescriptionId).subscribe();
  }
  goBackToList() {
    this.router.navigateByUrl("prescriptions/" + this.visitId);
  }
  PrescriptionDetails() {
    this.router.navigateByUrl("prescriptionsdetails/" + this.prescriptionId);
  }
 

}
