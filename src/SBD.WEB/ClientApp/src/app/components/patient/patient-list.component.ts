import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { MatTableDataSource } from '@angular/material/table';
import { PatientListing } from '../../models/patient-listing.model';
import { Patient } from '../../models/patient.model';
import { HospitalService } from '../../services/hospital.service';
import { AuthService } from './../../services/auth.service';


@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
 
})
export class PatientListComponent {
  patientListing: PatientListing = new PatientListing (0, []);
  isLoggedIn: boolean;
  displayedColumns: string[] = ['name', 'surname', 'pesel'];
  pageSize = 10;
  dataSource = new MatTableDataSource<Patient>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getPatients();
  }

  getPatients(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getPatients()
      .subscribe(result => {
        this.patientListing = result;
        this.dataSource = new MatTableDataSource(result.patients);
      });
  }

  pageChanged(pageEvent) {
    this.getPatients(pageEvent.pageIndex, this.pageSize);
  }
  //obok kazdego pacjent dodac button-> make me doctor
  //makeDoctor()
}