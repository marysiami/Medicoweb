import { Component, ViewChild } from "@angular/core";
import { MatSort, MatTableDataSource } from "@angular/material";
import { ActivatedRoute, Router } from "@angular/router";
import { AuthService } from "../../../services/auth.service";
import { HospitalService } from "../../../services/hospital.service";
import { PrescriptionListing } from "../../../models/prescription-listing.model";
import { Prescription } from "../../../models/prescription.model";



@Component({
  selector: "app-patient-visits",
  templateUrl: "./visit-prescription-list.component.html"
})
export class VisitPrescriptionListComponent {

  @ViewChild(MatSort)
  sort: MatSort;
  prescriptionListing = new PrescriptionListing(0,[]);
  visitId: string;
  isLoggedIn: boolean;
  displayedColumns: string[] = ["Prescription","Doctor","Pacient"];
  dataSource = new MatTableDataSource<Prescription>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }
  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.visitId = this.route.snapshot.paramMap.get("id");
    this.getPrescription();
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }
  getPrescription() {
    this.hospitalService.getPrescriptionsFromVisit(this.visitId).subscribe(result => {
      this.prescriptionListing = result;
      this.dataSource.data = result.prescriptions;   
    });
  }

  addPrescription() {
    this.router.navigateByUrl("newprescription/" + this.visitId);
  }





}
