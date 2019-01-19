import { Component } from "@angular/core";
import { MatDialog } from "@angular/material";
import { MatTableDataSource } from "@angular/material/table";
import { DoctorListing } from "../../models/doctor-listing.model";
import { HospitalService } from "../../services/hospital.service";
import { AuthService } from "./../../services/auth.service";
import { Doctor } from "../../models/doctor.model";

@Component({
  selector: "app-doctor-list",
  templateUrl: "./doctor-list.component.html"
})
export class DoctorListComponent {
  doctorListing = new DoctorListing(0, []);
  isLoggedIn: boolean;
  displayedColumns: string[] = ["name", "surname", "specialization ", "repliesCount"];
  pageSize = 10;
  dataSource = new MatTableDataSource<Doctor>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getDoctors();
  }

  getDoctors(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDoctors(pageNumber, postsPerPage)
      .subscribe(result => {
        this.doctorListing = result;
        this.dataSource = new MatTableDataSource(result.doctors);
      }); //JAK POBRAĆ DOKTORÓW Z KONKTRETNEGO SZPITALA?
  }

  pageChanged(pageEvent) {
    this.getDoctors(pageEvent.pageIndex, this.pageSize);
  }
}
