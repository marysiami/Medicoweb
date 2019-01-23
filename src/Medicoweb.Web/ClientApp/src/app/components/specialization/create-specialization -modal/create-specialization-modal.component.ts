import { Component } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MatDialogRef } from "@angular/material";
import { HospitalService } from "../../../services/hospital.service";

@Component({
  selector: "app-create-specialization-modal",
  templateUrl: "./create-specialization-modal.component.html"
})
export class CreateSpecializationModalComponent {
  newPostForm: FormGroup;
  message: string;

  constructor(
    public dialogRef: MatDialogRef<CreateSpecializationModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      name: [
        "",
        [Validators.required, Validators.pattern(/^[a-zA-Z0-9_.-]*$/), Validators.minLength(1)]
      ]
    });
  }

  submit() {
    this.hospitalService
      .createSpecialzation(this.newPostForm.controls.name.value)
      .subscribe(result => {
          this.dialogRef.close("ok");
        },
        error => this.message = "Wystąpił błąd");
  }
}
