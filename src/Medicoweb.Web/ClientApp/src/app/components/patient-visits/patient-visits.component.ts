import { AuthService } from "../../services/auth.service";
import { HospitalService } from "../../services/hospital.service";
import { MatDialog, MatSort, MatTableDataSource } from "@angular/material";
import { Router, Route, ActivatedRoute } from "@angular/router";
import { Component, ViewChild } from "@angular/core";
import { Visit } from "../../models/visit.model";
import { VisitListing } from "../../models/visit-listing.model";


@Component({
  selector: "app-patient-visits",
  templateUrl: "./patient-visits.component.html"
})
export class PatientVisitComponent {

  @ViewChild(MatSort)
  sort: MatSort;
  visitListing = new VisitListing([]);
  userId: string;
  isLoggedIn: boolean;
  displayedColumns: string[] = ["Szpital", "Lekarz", "Pacjent","Data","Button"];
  dataSource = new MatTableDataSource<Visit>();
  isDoctor: boolean;


  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService, 
    private router: Router,
    private route: ActivatedRoute
  ) {
  }
  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.userId = this.route.snapshot.paramMap.get("id");
    this.getVisits(this.userId);
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }
  getVisits(id) {

    if (this.authService.isInRole("Patient")) {
      this.isDoctor = false;
      this.hospitalService.getVisitsFromPatient(id).subscribe(result => {
        this.visitListing = result;
        this.dataSource.data = result.visits;
      }
      );
    }
    else if (this.authService.isInRole("Doctor")) {
      this.isDoctor = true;
      this.hospitalService.getVisitsFromDoctor(id).subscribe(result => {
        this.visitListing = result;
        this.dataSource.data = result.visits;
        
      }
      );
    }
  }

  addPrescription(id) {
  }


    

  
}
