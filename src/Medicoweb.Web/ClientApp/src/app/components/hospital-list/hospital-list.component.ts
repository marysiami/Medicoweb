import { Component, ViewChild } from "@angular/core";
import { MatDialog, MatSort } from "@angular/material";
import { MatTableDataSource } from "@angular/material/table";
import { HospitalListing } from "../../models/hospital-listing.model";
import { Hospital } from "../../models/hospital.model";
import { HospitalService } from "../../services/hospital.service";
import { AuthService } from "./../../services/auth.service";
import { CreateHospitalModalComponent } from "./create-hospital-modal/create-hospital-modal.component";
import { EditHospitalModalComponent } from "./edit-hospital-modal/edit-hospital-modal.component";

@Component({
  selector: "app-hospital-list",
  templateUrl: "./hospital-list.component.html",
  styleUrls: ["./hospital-list.component.css"]
})
export class HospitalListComponent {
  @ViewChild(MatSort)
  sort: MatSort;
  hospitalListing = new HospitalListing(0, []);
  isLoggedIn: boolean;
  displayedColumns: string[] = ["name", "address", "repliesCount","button"];
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
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
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
       // this.dataSource = new MatTableDataSource(result.hospitals);
        this.dataSource.data = result.hospitals;
      });
  }
  
  pageChanged(pageEvent) {
    this.getHospitals(pageEvent.pageIndex, this.pageSize);
  }
  deleteHospital(id) {
    this.hospitalService.deleteHospital(id)
      .subscribe(result => this.getHospitals(0, this.pageSize));
  }

  editHospital(id) {
    const dialogRef =
      this.dialog
        .open(EditHospitalModalComponent,
          {
            height: "auto",
            width: "400px",
            data: id
          })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getHospitals(0, this.pageSize);
          }
        });
  }
}
