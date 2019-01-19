import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { HospitalService } from '../../../services/hospital.service';

@Component({
  selector: 'app-create-specialization-modal',
  templateUrl: './create-specialization-modal.component.html'
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
        '',
        [Validators.required]
      ]
    });
  }
  submit() {
    this.hospitalService
      .createSpecialzation(this.newPostForm.controls.name.value)
      .subscribe(result => {
        this.dialogRef.close("ok");
      }, error => this.message = "Wystąpił błąd");
  }
}

