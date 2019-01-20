import { Component, Inject, Optional } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { HospitalService } from "../../../services/hospital.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-edit-hospital-modal",
  templateUrl: "./edit-hospital-modal.component.html"
})
export class EditHospitalModalComponent {
  newPostForm: FormGroup;
  message: string;


  constructor(
    @Optional() @Inject(MAT_DIALOG_DATA) public data: string,
    private route: ActivatedRoute,
    public dialogRef: MatDialogRef<EditHospitalModalComponent>,
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
      .updateHospital(this.data, this.newPostForm.controls.name.value, this.newPostForm.controls.address.value)
      .subscribe(result => {
          this.dialogRef.close("ok");
        },
        error => this.message = "Wystąpił błąd");
  }
}
