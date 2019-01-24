import { Component, ViewChild } from "@angular/core";
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { DoctorsFromSpecialization } from "../../../models/doctors-fromSpecialization-listing.model";
import { HospitalService } from "../../../services/hospital.service";
import { Doctor } from "../../../models/doctor.model";
import { AuthService } from "../../../services/auth.service";
import { Drug } from "../../../models/drug.model";
import { DrugFromPharmacy } from "../../../models/drug-pharmacy.model";


@Component({
  selector: "app-details-pharmacy-modal",
  templateUrl: "./details-pharmacy-modal.component.html",
 
})
export class DetailsPharmacyModalComponent {
  @ViewChild(MatSort)
  sort: MatSort;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  message: string;
  isLoggedIn: boolean;
  displayNewDoctorButton: boolean;
  drugsListing = new DrugFromPharmacy("", 0, []);
  specializationId: string;
  displayedColumns: string[] = ["name", "company", "button"];
  pageSize = 10;
  dataSource = new MatTableDataSource<Drug>();

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
    this.getDrugs();

  }

  getDrugs(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDrugsFromPharmacy(this.specializationId, pageNumber, postsPerPage)
      .subscribe(result => {
        this.drugsListing = result;
        this.dataSource = new MatTableDataSource(result.drugs);
        this.dataSource.data = result.drugs;

      });

  }

  pageChanged(pageEvent) {
    this.getDrugs(pageEvent.pageIndex, this.pageSize);
  }

  calculateLastPageIndex(count) {
    const result = Math.floor((count + this.pageSize - 1) / (this.pageSize)) - 1;
    return result;
  }

  deleteDrugFromPharmacy(id) {    
    this.hospitalService.deleteDrugFromPharmacy(id, this.specializationId).subscribe();
    this.getDrugs();
  }
}
