import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MatTableDataSource, MAT_DIALOG_DATA } from "@angular/material";
import { ActivatedRoute } from '@angular/router';
import { DepartamentListing } from '../../../models/departament-listing.model';
import { Departament } from '../../../models/departament.model';
import { AuthService } from '../../../services/auth.service';
import { HospitalService } from '../../../services/hospital.service';


@Component({
  selector: 'app-create-doctorDep-modal',
  templateUrl: './create-doctorDep-modal.component.html',
})
export class CreateDoctorDepartamentnModalComponent {
  
  newPostForm: FormGroup;
  message: string;
  displayedColumnsDep: string[] = ['specialization'];
  departamentListing: DepartamentListing = new DepartamentListing("",0, []);
  isLoggedIn: boolean;
  doctorId: string;
  dataSource = new MatTableDataSource<Departament>();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<CreateDoctorDepartamentnModalComponent>,
    private hospitalService: HospitalService,
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getDepartaments();
    this.doctorId = this.route.snapshot.paramMap.get('id');
  }

  getDepartaments(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDepartaments(pageNumber, postsPerPage)
      .subscribe(result => {
        this.departamentListing = result;
        this.dataSource = new MatTableDataSource(result.departaments);
      });
  }
  AddToDoctor(departamentId) {
    this.hospitalService.addDepartamentToDoctor(this.doctorId, departamentId);
  }
}
