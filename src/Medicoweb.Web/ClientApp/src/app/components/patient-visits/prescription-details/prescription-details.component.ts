
import { FormControl, Validators } from "@angular/forms";
import { Component } from "@angular/core";
import { toTypeScript } from "@angular/compiler";
import { AuthService } from "../../../services/auth.service";
import { ActivatedRoute, Router } from "@angular/router";
import { HospitalService } from "../../../services/hospital.service";
import { Prescription } from "../../../models/prescription.model";
import { DrugPrescriptionListing } from "../../../models/drug-prescription-listing";
import { MatTableDataSource } from "@angular/material";

@Component({
  selector: "app-prescription-details",
  templateUrl: "./prescription-details.component.html",

})
export class PrescriptionDetailsComponent {

  isLoggedIn: boolean;
  prescriptionId: string;
  doctorName: string;
  doctorSurname: string;
  patientName: string;
  patientSurname: string;
 // drugListing = new DrugPrescriptionListing("", 0, []);
  drugList: DrugPrescriptionListing[];
  displayedColumns: string[] = ["Lek", "Firma", "Ilość"];
  dataSource = new MatTableDataSource<DrugPrescriptionListing>();
  
  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private hospitalService: HospitalService,
  ) {
  }

  ngOnInit() {

    this.isLoggedIn = this.authService.isLoggedIn();
    this.prescriptionId = this.route.snapshot.paramMap.get("id");   
    this.getPrescription();
  }
  getPrescription() {
    this.hospitalService.getPrescripion(this.prescriptionId).subscribe(result => {
    
      this.doctorName = result.doctorName;
      this.doctorSurname = result.doctorSurname;
      this.patientName = result.patientName;
      this.patientSurname = result.patientSurname;
      this.dataSource.data = result.drugs;

      });
}

 


}
