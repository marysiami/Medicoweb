import { MatTableDataSource, MatDialog, MatSort } from "@angular/material";
import { AuthService } from "../../services/auth.service";
import { HospitalService } from "../../services/hospital.service";
import { Component, ViewChild } from "@angular/core";
import { DrugListing } from "../../models/drug-listing.model";
import { Drug } from "../../models/drug.model";
import { CreateDrugModalComponent } from "./create-drug-modal/create-drug-modal.component";
import { EditDrugModalComponent } from "./edit-drug-modal/edit-drug-modal.component";


@Component({
  selector: "app-drug",
  templateUrl: "./drug.component.html",
})
export class DrugComponent {

  @ViewChild(MatSort)
  sort: MatSort;
  drugListing = new DrugListing(0, []);

  isLoggedIn: boolean;
  displayedColumns: string[] = ["name", "company", "button"];
  pageSize = 10;
  dataSource = new MatTableDataSource<Drug>();

  dataSourceSpec = new MatTableDataSource;

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,   
  ) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getDrugs();
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  openCreateDrugModal() {
    const dialogRef =
      this.dialog
        .open(CreateDrugModalComponent,
          {
            height: "auto",
            width: "400px",
          })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getDrugs(0, this.pageSize);
          }
        });
  }

  getDrugs(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDrugs(pageNumber, postsPerPage).subscribe(result => {
      this.drugListing = result;
      this.dataSource.data = result.drugs;
    });
  }

  pageChanged(pageEvent) {
    this.getDrugs(pageEvent.pageIndex, this.pageSize);
  }

  deleteDrug(drugId) {
    this.hospitalService.deleteDrug(drugId).subscribe(result => this.getDrugs(0, this.pageSize));
  }

  openEditDrugModal(drugId) {
    const dialogRef =
      this.dialog
        .open(EditDrugModalComponent,
          {
            height: "auto",
            width: "400px",
            data: drugId
          })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getDrugs(0, this.pageSize);
          }
        });
  }
}
