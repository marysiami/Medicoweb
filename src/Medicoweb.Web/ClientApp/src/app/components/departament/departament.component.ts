import { Component, ViewChild } from "@angular/core";
import { MatDialog, MatPaginator, MatTableDataSource, MatSort } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { Departament } from "../../models/departament.model";
import { DoctorFromDepListing } from "../../models/doctor-fromDep-listing";
import { Doctor } from "../../models/doctor.model";
import { AuthService } from "./../../services/auth.service";
import { HospitalService } from "./../../services/hospital.service";

@Component({
  selector: "app-departament",
  templateUrl: "./departament.component.html",
  styleUrls: ["./departament.component.css"]
})
export class DepartamentComponent {
  @ViewChild(MatSort)
  sort: MatSort;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  message: string;
  isLoggedIn: boolean;
  displayNewDoctorButton: boolean;
  doctorListing = new DoctorFromDepListing("", 0, []);
  departamentId: string;
  displayedColumns: string[] = ["name", "surname", "pesel", "button"];
  pageSize = 10;
  departament: Departament[];
  dataSource = new MatTableDataSource<Doctor>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) {
  }
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.departamentId = this.route.snapshot.paramMap.get("id");
    this.getDoctors();
   
  }

  getDoctors(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDoctorsFromDep(this.departamentId, pageNumber, postsPerPage)
      .subscribe(result => {
      debugger;
        this.doctorListing = result;
        this.dataSource = new MatTableDataSource(result.doctors);
        this.dataSource.data = result.doctors;

      });
    
  }

  pageChanged(pageEvent) {
    this.getDoctors(pageEvent.pageIndex, this.pageSize);
  }

  calculateLastPageIndex(count) {
    const result = Math.floor((count + this.pageSize - 1) / (this.pageSize)) - 1;
    return result;
  }

  deleteDepartamentFromDoctor(id) {
    this.hospitalService.deleteDepartamentFromDoctor(id, this.departamentId).subscribe();
    this.getDoctors();
  }
}
