import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { HospitalService } from '../../../services/hospital.service';

@Component({
  selector: 'app-edit-specialization-modal',
  templateUrl: './edit-specialization-modal.component.html'
})
export class EditSpecializationModalComponent {
  newPostForm: FormGroup;
  message: string;
  specializationId: string;

  constructor(
    public dialogRef: MatDialogRef<EditSpecializationModalComponent>,
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
      .updateSpecialization(this.specializationId,this.newPostForm.controls.name.value)
      .subscribe(result => {
        this.dialogRef.close("ok");
      }, error => this.message = "Wystąpił błąd");
  }
}

