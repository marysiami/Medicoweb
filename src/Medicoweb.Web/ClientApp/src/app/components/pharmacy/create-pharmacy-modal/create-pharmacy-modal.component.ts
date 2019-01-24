import { Component } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MatDialogRef } from "@angular/material";
import { HospitalService } from "../../../services/hospital.service";

@Component({
  selector: "app-create-pharmacy-modal",
  templateUrl: "./create-pharmacy-modal.component.html"
})
export class CreatePharmacyModalComponent {
  newPostForm: FormGroup;
  message: string;

  constructor(
    public dialogRef: MatDialogRef<CreatePharmacyModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      name: [
        "",
        [Validators.required, Validators.pattern(/^[a-zA-Z0-9_.-]*$/), Validators.minLength(1)]
      ],
      address: [
        "",
        [Validators.required, Validators.pattern(/^[a-zA-Z0-9_.-]*$/), Validators.minLength(1)]
      ]
    });
  }

  submit() {
    this.hospitalService
      .createPharmacy(this.newPostForm.controls.name.value, this.newPostForm.controls.address.value)
      .subscribe(result => {
          this.dialogRef.close("ok");
        },
        error => this.message = "Wystąpił błąd");
  }
}
