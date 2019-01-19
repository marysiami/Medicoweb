import { Component, Inject, Optional } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { HospitalService } from "../../../services/hospital.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-edit-specialization-modal",
  templateUrl: "./edit-specialization-modal.component.html"
})
export class EditSpecializationModalComponent {
  newPostForm: FormGroup;
  message: string;


  constructor(
    @Optional() @Inject(MAT_DIALOG_DATA) public data: string,
    private route: ActivatedRoute,
    public dialogRef: MatDialogRef<EditSpecializationModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      name: [
        "",
        [Validators.required]
      ]
    });
  }

  submit() {
    this.hospitalService
      .updateSpecialization(this.data, this.newPostForm.controls.name.value)
      .subscribe(result => {
          this.dialogRef.close("ok");
        },
        error => this.message = "Wystąpił błąd");
  }
}
