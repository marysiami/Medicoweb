import { AuthService } from "../../services/auth.service";
import { Router, ActivatedRoute } from "@angular/router";
import { Hospital } from "../../models/hospital.model";
import { MatTableDataSource } from "@angular/material";
import { HospitalListing } from "../../models/hospital-listing.model";
import { Departament } from "../../models/departament.model";
import { DepartamentListing } from "../../models/departament-listing.model";
import { Doctor } from "../../models/doctor.model";
import { DoctorListing } from "../../models/doctor-listing.model";
import { HospitalService } from "../../services/hospital.service";

export class VisitComponent {

  isLoggedIn: boolean;
  patientId: string;


  //SZPITAL
  hospitalListing: HospitalListing = new HospitalListing(0, []);
  displayedColumnsHos: string[] = ['name','address'];
  dataSourceHos = new MatTableDataSource<Hospital>();

  //Departament
  departamentListing: DepartamentListing = new DepartamentListing("", 0, []);
  displayedColumnsDep: string[] = ['name'];
  dataSourceDep = new MatTableDataSource<Departament>();

  //DOKTOR
  doctorListing: DoctorListing = new DoctorListing(0, []);
  displayedColumnsDoc: string[] = ['name','surname'];
  dataSourceDoc = new MatTableDataSource<Doctor>();

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private hospitalService: HospitalService,
    
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getHospitals();
    
  }

  getHospitals(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getHospitals(pageNumber, postsPerPage)
      .subscribe(result => {
        this.hospitalListing = result;
        this.dataSourceHos = new MatTableDataSource(result.hospitals);
      });
  }

  getDepartaments(hospitalId,pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDepartaments(hospitalId, pageNumber, postsPerPage)
      .subscribe(result => {
        this.departamentListing = result;
        this.dataSourceDep = new MatTableDataSource(result.departaments);
       });
  }
  getDoctors(departamentId,pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getDoctorsFromDep(departamentId,pageNumber, postsPerPage)
      .subscribe(result => {
        this.doctorListing = result;
        this.dataSourceDoc = new MatTableDataSource(result.doctors);
      }); 
  }
  createVisit() {
   
  }


}
