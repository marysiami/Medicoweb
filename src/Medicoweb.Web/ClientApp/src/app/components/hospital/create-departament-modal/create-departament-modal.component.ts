import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { HospitalService } from '../../../services/hospital.service';


@Component({
  selector: 'app-create-departament-modal',
  templateUrl: './create-departament-modal.component.html',
 })
export class CreateDepartamentModalComponent {
  newPostForm: FormGroup;
  message: string;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<CreateDepartamentModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      name: [
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
