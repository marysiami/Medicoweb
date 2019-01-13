import { Component, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatTableDataSource } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { Departament } from '../../models/departament.model';
import { DoctorFromDepListing } from '../../models/doctor-fromDep-listing';
import { AuthService } from './../../services/auth.service';
import { HospitalService } from './../../services/hospital.service';
import { Doctor } from '../../models/doctor.model';

@Component({
  selector: 'app-departament',
  templateUrl: './departament.component.html',
  styleUrls: ['./departament.component.css']
})
export class DepartamentComponent {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  message: string;
  isLoggedIn: boolean;
  displayNewDoctorButton: boolean;
  doctorListing: DoctorFromDepListing = new DoctorFromDepListing("",0, []);
  departamentId: string;
  displayedColumns: string[] = ['name', 'surname','pesel'];
  pageSize = 10;
  departament: Departament[];
  dataSource = new MatTableDataSource<Doctor>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) { }
  
  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.departamentId = this.route.snapshot.paramMap.get('id');
    this.getDoctors();
  }

  getDoctors(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDoctorsFromDep(this.departamentId, pageNumber, postsPerPage)
      .subscribe(result => {
      this.doctorListing = result;
      this.dataSource = new MatTableDataSource(result.doctors);
      });
  }
  //dodać sortowanie lekrzy po nazwisku i po imieniu


  pageChanged(pageEvent) {
    this.getDoctors(pageEvent.pageIndex, this.pageSize);
  }
  
  calculateLastPageIndex(count) {
    let result = Math.floor((count + this.pageSize - 1) / (this.pageSize)) - 1;
    return result;
  }
}

