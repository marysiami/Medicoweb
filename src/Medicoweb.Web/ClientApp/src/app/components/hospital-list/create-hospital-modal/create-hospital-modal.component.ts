import { Component } from "@angular/core";
import { HospitalService } from "../../../services/hospital.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MatDialogRef } from "@angular/material";

@Component({
  selector: "app-create-hospital-modal",
  templateUrl: "./create-hospital-modal.component.html"
})
export class CreateHospitalModalComponent {
  newPostForm: FormGroup;
  message: string;

  constructor(
    public dialogRef: MatDialogRef<CreateHospitalModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      name: [
        "",
        [Validators.required]
      ],
      address: [
        "",
        [Validators.required]
      ]
    });
  }

  submit() {
    this.hospitalService
      .createHospital(this.newPostForm.controls.name.value, this.newPostForm.controls.address.value)
      .subscribe(result => {
          this.dialogRef.close();
        },
        error => this.message = "Wystąpił błąd");
  }
}
