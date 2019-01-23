import { Component, ViewChild } from "@angular/core";
import { MatDialog, MatSort } from "@angular/material";
import { MatTableDataSource } from "@angular/material/table";
import { Router } from "@angular/router";
import { PatientListing } from "../../models/patient-listing.model";
import { Patient } from "../../models/patient.model";
import { HospitalService } from "../../services/hospital.service";
import { AuthService } from "./../../services/auth.service";


@Component({
  selector: "app-patient-list",
  templateUrl: "./patient-list.component.html",

})
export class PatientListComponent {
  @ViewChild(MatSort)
  sort: MatSort;

  patientListing = new PatientListing(0, []);
  isLoggedIn: boolean;
  displayedColumns: string[] = ["name", "surname", "pesel", "button"];
  pageSize = 10;
  dataSource = new MatTableDataSource<Patient>();


  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,
    private router: Router
  ) {
  }
 
  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getPatients();
  }
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  getPatients(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getPatients()
      .subscribe(result => {
        this.patientListing = result;
       // this.dataSource = new MatTableDataSource(result.patients);
        this.dataSource.data = result.patients;
      });
  }

  CreateDoctor(patientId) {
    this.hospitalService.createDoctor(patientId).subscribe(result => this.router.navigateByUrl('/doctor/' + patientId));
  }

  pageChanged(pageEvent) {
    this.getPatients(pageEvent.pageIndex, this.pageSize);
  }
}
