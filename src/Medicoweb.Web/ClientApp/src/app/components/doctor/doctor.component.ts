import { Component, OnInit } from '@angular/core';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { Departament } from '../../models/departament.model';
import { DepartamentsFromDoctorListing } from '../../models/departaments-fromDoctor-listing.model';
import { Specialization } from '../../models/specialization.model';
import { SpecializationsFromDoctorListing } from '../../models/specializations-fromDoctor-listing.model';
import { AuthService } from '../../services/auth.service';
import { HospitalService } from '../../services/hospital.service';
import { CreateDoctorDepartamentnModalComponent } from './create-doctorDepartament-modal/create-doctorDep-modal.component';
import { CreateDoctorSpecializationModalComponent } from './create-doctorSpeciality-modal/create-doctorSpec-modal.component';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  departamentListing: DepartamentsFromDoctorListing = new DepartamentsFromDoctorListing("","",0, []);
  specializationListing: SpecializationsFromDoctorListing = new SpecializationsFromDoctorListing("","",0, []);
  isLoggedIn: boolean;
  displayedColumnsDep: string[] = ['departament'];
  displayedColumnsSpec: string[] = ['specialization'];
  pageSize = 10;
  doctorId : string;
 

  dataSourceDep = new MatTableDataSource<Departament>();
  dataSourceSpec = new MatTableDataSource<Specialization>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    //this.getDepartamentFromDoctor();
    //this.getSpecializationsFromDoctor();
    this.doctorId = this.route.snapshot.paramMap.get('id');
  }
  /*
  getDepartamentFromDoctor(pageNumber = 0, postsPerPage = 10) {
    console.log(this.doctorId);
    this.hospitalService.getDepartamentsFromDoctor(this.doctorId,pageNumber, postsPerPage)
      .subscribe(result => {
        this.departamentListing = result;
        this.dataSourceDep = new MatTableDataSource(result.departmanets);
      });
  }
  getSpecializationsFromDoctor(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getSpecializationsFromDoctor(this.doctorId, pageNumber, postsPerPage)
      .subscribe(result => {
        this.specializationListing = result;
        this.dataSourceSpec = new MatTableDataSource(result.specializations);
      });
  }
  openCreateDoctorDepModal() {
    this.router.navigateByUrl('/depdoctor/this.doctorId'); //dziala?
  }
  openCreateDoctorSpecModal() {
    this.router.navigateByUrl('/specdoctor/this.doctorId');
  }*/

}


