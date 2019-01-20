import { Component, ViewChild } from "@angular/core";
import { MatDialog, MatSort } from "@angular/material";
import { MatTableDataSource } from "@angular/material/table";
import { SpecializationListing } from "../../models/specialization-listing.model";
import { HospitalService } from "../../services/hospital.service";
import { AuthService } from "./../../services/auth.service";
import { Specialization } from "../../models/specialization.model";
import { CreateSpecializationModalComponent } from
  "./create-specialization -modal/create-specialization-modal.component";
import { EditSpecializationModalComponent } from "./edit-specialization-modal/edit-specialization-modal.component";

@Component({
  selector: "app-specialization",
  templateUrl: "./specialization.component.html",
  styleUrls: ["./specialization.component.css"]
})
export class SpecializationComponent {

  @ViewChild(MatSort)
  sort: MatSort;
  specializationListing = new SpecializationListing(0, []);
  isLoggedIn: boolean;
  displayedColumns: string[] = ["name", "button"];
  pageSize = 10;
  dataSource = new MatTableDataSource<Specialization>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getSpecialization();
  }
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  openCreateSpecialzationModal() {
    const dialogRef =
      this.dialog
        .open(CreateSpecializationModalComponent,
          {
            height: "auto",
            width: "400px",
          })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getSpecialization(0, this.pageSize);
          }
        });
  }


  getSpecialization(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getSpecialzations(pageNumber, postsPerPage).subscribe(result => {
      this.specializationListing = result;
      this.dataSource.data = result.specialization;
    });
  }

  deleteSpecialization(specializationId) {    
    this.hospitalService.deleteSpecialization(specializationId)
      .subscribe(result => this.getSpecialization(0, this.pageSize));
  }

  editSpecialization(specializationId) {
    const dialogRef =
      this.dialog
        .open(EditSpecializationModalComponent,
          {
            height: "auto",
            width: "400px",
            data: specializationId
          })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getSpecialization(0, this.pageSize);
          }
        });
  }

  pageChanged(pageEvent) {
    this.getSpecialization(pageEvent.pageIndex, this.pageSize);
  }
}
