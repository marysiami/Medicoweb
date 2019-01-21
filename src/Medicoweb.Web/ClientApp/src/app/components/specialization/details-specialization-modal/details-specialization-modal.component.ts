import { Component, ViewChild } from "@angular/core";
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { DoctorsFromSpecialization } from "../../../models/doctors-fromSpecialization-listing.model";
import { HospitalService } from "../../../services/hospital.service";
import { Doctor } from "../../../models/doctor.model";
import { AuthService } from "../../../services/auth.service";


@Component({
  selector: "app-details-specialization-modal",
  templateUrl: "./details-specialization-modal.component.html",
 
})
export class DetailsSpecializationModalComponent {
  @ViewChild(MatSort)
  sort: MatSort;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  message: string;
  isLoggedIn: boolean;
  displayNewDoctorButton: boolean;
  doctorListing = new DoctorsFromSpecialization("", 0, []);
  specializationId: string;
  displayedColumns: string[] = ["name", "surname", "pesel", "button"];
  pageSize = 10;
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
    this.specializationId = this.route.snapshot.paramMap.get("id");
    this.getDoctors();

  }

  getDoctors(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDoctorsFromSpeciaization(this.specializationId, pageNumber, postsPerPage)
      .subscribe(result => {
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
    this.hospitalService.deleteSpecializationFromDoctor(id, this.specializationId).subscribe();
    this.getDoctors();
  }
}
