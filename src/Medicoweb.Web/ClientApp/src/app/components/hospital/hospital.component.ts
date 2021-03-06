import { Component, ViewChild } from "@angular/core";
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { DepartamentListing } from "../../models/departament-listing.model";
import { Departament } from "../../models/departament.model";
import { Hospital } from "../../models/hospital.model";
import { AuthService } from "./../../services/auth.service";
import { HospitalService } from "./../../services/hospital.service";
import { CreateDepartamentModalComponent } from "./create-departament-modal/create-departament-modal.component";
import { EditDepartamentModalComponent } from "./edit-departament-modal/edit-departament-modal.component";


@Component({
  selector: "app-hospital",
  templateUrl: "./hospital.component.html",
  styleUrls: ["./hospital.component.css"]
})
export class HospitalComponent {
  @ViewChild(MatSort)
  sort: MatSort;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  message: string;
  isLoggedIn: boolean;
  displayNewDepartamentButton: boolean;
  departamentListing = new DepartamentListing("", 0, []);
  hospitalId: string;
  displayedColumns: string[] = ["name","button"];
  pageSize = 10;
  hospitals: Hospital[];
  dataSource = new MatTableDataSource<Departament>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.hospitalId = this.route.snapshot.paramMap.get("id");
    this.getDepartaments();
  }
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  getDepartaments(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDepartaments(this.hospitalId, pageNumber, postsPerPage)
      .subscribe(result => {
        this.departamentListing = result;
       // this.dataSource = new MatTableDataSource(result.departaments);
        this.dataSource.data = result.departaments;
        
      });
  }

  pageChanged(pageEvent) {
    this.getDepartaments(pageEvent.pageIndex, this.pageSize);
  }

  openCreateDepartamentModal() {
    const dialogRef =
      this.dialog
        .open(CreateDepartamentModalComponent,
          {
            height: "auto",
            width: "400px",
            data: {
              hospitalId: this.hospitalId
            }
          })
        .afterClosed()
        .subscribe(result => {
            if (result === "ok") {
              this.getDepartaments(this.calculateLastPageIndex(this.departamentListing.totalCount + 1), this.pageSize);
            }
          }
        );
  }

  calculateLastPageIndex(count) {
    const result = Math.floor((count + this.pageSize - 1) / (this.pageSize)) - 1;
    return result;
  }
  deleteDepartament(id) {
    this.hospitalService.deleteDepartament(id)
      .subscribe(result => this.getDepartaments(0, this.pageSize));
  }

  editDepartament(id) {
    const dialogRef =
      this.dialog
        .open(EditDepartamentModalComponent,
          {
            height: "auto",
            width: "400px",
            data: id
          })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getDepartaments(0, this.pageSize);
          }
        });
  }
}
