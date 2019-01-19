import { Component } from "@angular/core";
import { MatDialog } from "@angular/material";
import { MatTableDataSource } from "@angular/material/table";
import { HospitalListing } from "../../models/hospital-listing.model";
import { Hospital } from "../../models/hospital.model";
import { HospitalService } from "../../services/hospital.service";
import { AuthService } from "./../../services/auth.service";
import { CreateHospitalModalComponent } from "./create-hospital-modal/create-hospital-modal.component";

@Component({
  selector: "app-hospital-list",
  templateUrl: "./hospital-list.component.html",
  styleUrls: ["./hospital-list.component.css"]
})
export class HospitalListComponent {
  hospitalListing = new HospitalListing(0, []);
  isLoggedIn: boolean;
  displayedColumns: string[] = ["name", "address", "repliesCount"];
  pageSize = 10;
  dataSource = new MatTableDataSource<Hospital>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getHospitals();
  }

  openCreateHospitalModal() {
    const dialogRef =
      this.dialog
        .open(CreateHospitalModalComponent,
          {
            height: "auto",
            width: "400px",
          })
        .afterClosed()
        .subscribe(result => this.getHospitals(0, this.pageSize));
  }

  getHospitals(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getHospitals(pageNumber, postsPerPage)
      .subscribe(result => {
        this.hospitalListing = result;
        this.dataSource = new MatTableDataSource(result.hospitals);
      });
  }
  /*getHospitalsByAddress(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getHospitalsByAddress(pageNumber, postsPerPage)
      .subscribe(result => {
        this.hospitalListing = result;
        this.dataSource = new MatTableDataSource(result.hospitals);
      });
  }*/


  pageChanged(pageEvent) {
    this.getHospitals(pageEvent.pageIndex, this.pageSize);
  }
}
