import { Component, Inject } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { MatDialogRef, MatTableDataSource, MAT_DIALOG_DATA } from "@angular/material";
import { SpecializationListing } from "../../../models/specialization-listing.model";
import { Specialization } from "../../../models/specialization.model";
import { AuthService } from "../../../services/auth.service";
import { HospitalService } from "../../../services/hospital.service";
import { ActivatedRoute } from "@angular/router";


@Component({
  selector: "app-create-doctorSpec-modal",
  templateUrl: "./create-doctorSpec-modal.component.html",
})
export class CreateDoctorSpecializationModalComponent {
  newPostForm: FormGroup;
  specializationListing = new SpecializationListing(0, []);
  message: string;
  isLoggedIn: boolean;
  doctorId: string;
  dataSource = new MatTableDataSource<Specialization>();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<CreateDoctorSpecializationModalComponent>,
    private hospitalService: HospitalService,
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getSpecializations();
    this.doctorId = this.route.snapshot.paramMap.get("id");
  }

  getSpecializations(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getSpecialzations(pageNumber, postsPerPage)
      .subscribe(result => {
        this.specializationListing = result;
        this.dataSource = new MatTableDataSource(result.specialization);
      });
  }

  AddToDoctor(specializationId) {
    this.hospitalService.addSpecializationToDoctor(specializationId, this.doctorId);
  }
}
