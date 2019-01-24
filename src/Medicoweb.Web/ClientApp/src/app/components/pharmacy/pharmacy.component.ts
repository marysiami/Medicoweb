import { Component, ViewChild } from "@angular/core";
import { MatDialog, MatSort } from "@angular/material";
import { MatTableDataSource } from "@angular/material/table";
import { PharmacyListing } from "../../models/pharmacy-listing.model";
import { Pharmacy } from "../../models/Pharmacy.model";
import { HospitalService } from "../../services/hospital.service";
import { AuthService } from "./../../services/auth.service";
import { CreatePharmacyModalComponent } from "./create-pharmacy-modal/create-pharmacy-modal.component";
import { EditPharmacyModalComponent } from "./edit-pharmacy-modal/edit-pharmacy-modal.component";

@Component({
  selector: "app-pharmacy",
  templateUrl: "./pharmacy.component.html",
  
})
export class PharmacyComponent {

  @ViewChild(MatSort)
  sort: MatSort;
  pharmacyListing = new PharmacyListing([]);
  isLoggedIn: boolean;
  displayedColumns: string[] = ["name","address", "button"];
  pageSize = 10;
  dataSource = new MatTableDataSource<Pharmacy>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getPharmacies();
  }
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  openCreatePharmacyModal() {
    const dialogRef =
      this.dialog
        .open(CreatePharmacyModalComponent,
          {
            height: "auto",
            width: "400px",
          })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getPharmacies(0, this.pageSize);
          }
        });
  }


  getPharmacies(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getPharmacies(pageNumber, postsPerPage).subscribe(result => {
      this.pharmacyListing = result;
      this.dataSource.data = result.pharmacies;
    });
  }

  deletePharmacy(pharmacyId) {    
    this.hospitalService.deletePharmacy(pharmacyId).subscribe(result => this.getPharmacies(0, this.pageSize));
  }

  editPharmacy(pharmacyId) {
    const dialogRef =
      this.dialog
        .open(EditPharmacyModalComponent,
          {
            height: "auto",
            width: "400px",
            data: pharmacyId
          })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getPharmacies(0, this.pageSize);
          }
        });
  }

 
}
