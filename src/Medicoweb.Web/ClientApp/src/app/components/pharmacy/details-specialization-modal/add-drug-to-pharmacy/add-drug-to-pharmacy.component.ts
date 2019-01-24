import { Component, Optional, Inject } from "@angular/core";
import { AuthService } from "../../../../services/auth.service";
import { HospitalService } from "../../../../services/hospital.service";
import { ActivatedRoute } from "@angular/router";
import { FormGroup, FormBuilder } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";

@Component({
  selector: "app-add-drug-to-pharmacy",
  templateUrl: "./add-drug-to-pharmacy.component.html",

})
export class AddDrugToPharmacyModalComponent {

  message: string;
  drugList = [];
  drugId: string;
    
  constructor(
    @Optional() @Inject(MAT_DIALOG_DATA) public data: string,
    private route: ActivatedRoute,
    public dialogRef: MatDialogRef<AddDrugToPharmacyModalComponent>,
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder) {
  }
  ngOnInit() {
    this.getDrugs();
  }
  getDrugs() {
    this.hospitalService.getDrugs(0, 10)
      .subscribe(result => {
        this.drugList = result.drugs;
      });
  }
  getDrug(event) {

    this.drugId = event.value.id
  }
  submit() {
    this.hospitalService.addDrugToPharmacy(this.drugId,this.data)
      .subscribe(result => {
        this.dialogRef.close("Dodaj");
      },
        error => this.message = "Wystąpił błąd");
  }
}
