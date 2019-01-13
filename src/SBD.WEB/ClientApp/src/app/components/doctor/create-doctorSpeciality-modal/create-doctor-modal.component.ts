import { Component, Inject } from "@angular/core";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
import { HospitalService } from "../../../services/hospital.service";

@Component({
  selector: 'app-create-doctor-modal',
  templateUrl: './create-doctor-modal.component.html'
})
export class CreateDoctorModalComponent {
  newPostForm: FormGroup;
  message: string;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<CreateDoctorModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      name: [
        '',
        [Validators.required]
      ],
      surname: [
        '',
        [Validators.required]
      ]

    });
  }
  submit() {
    this.hospitalService
      .createDepartament(this.data.hospitalId, this.newPostForm.controls.name.value)
      .subscribe(result => {
        this.dialogRef.close("ok");
      }, error => this.message = "Wystąpił błąd");
  }
}
