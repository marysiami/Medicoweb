import { Component, Inject, Optional } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { ActivatedRoute } from "@angular/router";
import { HospitalService } from "../../../services/hospital.service";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";

@Component({
  selector: "app-edit-drug-modal",
  templateUrl: "./edit-drug-modal.component.html"
})
export class EditDrugModalComponent {
  newPostForm: FormGroup;
  message: string;

  constructor(
    @Optional() @Inject(MAT_DIALOG_DATA) public data: string,
    private route: ActivatedRoute,
    @Optional() public dialogRef: MatDialogRef<EditDrugModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      name: [
        "",
        [Validators.required]
      ],
      company: [
        "",
        [Validators.required]
      ]
    });
  }

  submit() {
    this.hospitalService
      .updateDrug(this.data, this.newPostForm.controls.name.value, this.newPostForm.controls.company.value)
      .subscribe(result => {
          this.dialogRef.close("ok");
        },
        error => this.message = "Wystąpił błąd");
  }
}
