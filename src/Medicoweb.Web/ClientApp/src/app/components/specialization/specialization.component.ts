import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { MatTableDataSource } from '@angular/material/table';
import { SpecializationListing } from '../../models/specialization-listing.model';
import { HospitalService } from '../../services/hospital.service';
import { AuthService } from './../../services/auth.service';
import { Specialization } from '../../models/specialization.model';
import { CreateSpecializationModalComponent } from './create-specialization -modal/create-specialization-modal.component';
import { EditSpecializationModalComponent } from './edit-specialization-modal/edit-specialization-modal.component';

@Component({
  selector: 'app-specialization',
  templateUrl: './specialization.component.html',
  styleUrls: ['./specialization.component.css']
})

export class SpecializationComponent  {

  specializationListing: SpecializationListing = new SpecializationListing(0, []);

  isLoggedIn: boolean;
  displayedColumns: string[] = ['name','buttonEdit'];
  pageSize = 10;
  dataSource = new MatTableDataSource<Specialization>();

  dataSourceSpec = new MatTableDataSource

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getSpecialization();
  }

  openCreateSpecialzationModal() {
    const dialogRef =
      this.dialog
        .open(CreateSpecializationModalComponent, {
          height: 'auto',
          width: '400px',
        })
        .afterClosed()
        .subscribe(result => this.getSpecialization(0, this.pageSize));       
  }

  getSpecialization(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getSpecialzations(pageNumber, postsPerPage).subscribe(result => {
      this.specializationListing = result;
      console.log(result);
      this.dataSource = new MatTableDataSource(result.specialization);

    })
  }
  deleteSpecialization(id) {
    this.hospitalService.deleteSpecialization(id);
    this.getSpecialization();
  }
  editSpecialization(specializationId){
    /*this.dialogConfig.data = {
      drugId: drugId,
      height: 'auto',
      width: '400px',
    };*/
    const dialogRef =
      this.dialog
        .open(EditSpecializationModalComponent)//, this.dialogConfig)
        .afterClosed()
        .subscribe(result => this.getSpecialization(0, this.pageSize));
  }
  pageChanged(pageEvent) {
    this.getSpecialization(pageEvent.pageIndex, this.pageSize);
  }
 }
