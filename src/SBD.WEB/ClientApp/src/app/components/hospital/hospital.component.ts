import { Component, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatTableDataSource } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { DepartamentListing } from '../../models/departament-listing.model';
import { Hospital } from '../../models/hospital.model';
import { AuthService } from './../../services/auth.service';
import { HospitalService } from './../../services/hospital.service';
import { CreateDepartamentModalComponent } from './create-departament-modal/create-departament-modal.component';
import { Departament } from '../../models/departament.model';
import { Console } from '@angular/core/src/console';

@Component({
  selector: 'app-hospital',
  templateUrl: './hospital.component.html',
  styleUrls: ['./hospital.component.css']
})


export class HospitalComponent {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  message: string;
  isLoggedIn: boolean;
  displayNewDepartamentButton: boolean;
  departamentListing: DepartamentListing = new DepartamentListing("", 0, []);
  hospitalId: string;
  displayedColumns: string[] = ['name']
  pageSize = 10;
  hospitals: Hospital[];
  dataSource = new MatTableDataSource<Departament>();
  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.hospitalId = this.route.snapshot.paramMap.get('id');
    this.getDepartaments();
  }

  getDepartaments(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDepartaments(this.hospitalId, pageNumber, postsPerPage)
      .subscribe(result => {
        this.departamentListing = result;
        this.dataSource = new MatTableDataSource(result.departaments);
        console.log(result);
      });
  }

  pageChanged(pageEvent) {
    this.getDepartaments(pageEvent.pageIndex, this.pageSize);
  }

  openCreateDepartamentModal() {
    const dialogRef =
      this.dialog
        .open(CreateDepartamentModalComponent, {
          height: 'auto',
          width: '400px',
          data: {
            hospitalId: this.hospitalId
          }
        })
        .afterClosed()
        .subscribe(result => {
          if (result === "ok") {
            this.getDepartaments(this.calculateLastPageIndex(this.departamentListing.totalCount + 1), this.pageSize);
          }
        }
        );
  }
  calculateLastPageIndex(count) {
    let result = Math.floor((count + this.pageSize - 1) / (this.pageSize)) - 1;
    return result;
  }
  //openPatientsList() <- DODAĆ 
}

