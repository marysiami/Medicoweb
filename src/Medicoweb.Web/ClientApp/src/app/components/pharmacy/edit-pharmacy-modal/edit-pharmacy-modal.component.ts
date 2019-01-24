import { Component, Inject, Optional } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { HospitalService } from "../../../services/hospital.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-edit-pharmacy-modal",
  templateUrl: "./edit-pharmacy-modal.component.html"
})
export class EditPharmacyModalComponent {
  newPostForm: FormGroup;
  message: string;


  constructor(
    @Optional() @Inject(MAT_DIALOG_DATA) public data: string,
    private route: ActivatedRoute,
    public dialogRef: MatDialogRef<EditPharmacyModalComponent>,
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
    this.hospitalService.updatePharmacy(this.data, this.newPostForm.controls.name.value, this.newPostForm.controls.address.value)
      .subscribe(result => {
          this.dialogRef.close("ok");
        },
        error => this.message = "Wystąpił błąd");
  }
}
