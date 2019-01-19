import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { HospitalService } from '../../../services/hospital.service';

@Component({
  selector: 'app-create-drug-modal',
  templateUrl: './create-drug-modal.component.html'
})
export class CreateDrugModalComponent {
  newPostForm: FormGroup;
  message: string;
  constructor(

    public dialogRef: MatDialogRef<CreateDrugModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      name: [
        '',
        [Validators.required]
      ],
      company: [
        '',
        [Validators.required]
      ]
    });
  }
  submit() {
    this.hospitalService
      .createDrug(this.newPostForm.controls.name.value, this.newPostForm.controls.company.value)
      .subscribe(result => {
        this.dialogRef.close("ok");
      }, error => this.message = "Wystąpił błąd");
  }
}

