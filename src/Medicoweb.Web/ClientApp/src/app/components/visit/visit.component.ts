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
import { FormControl } from "@angular/forms";
import { Component } from "@angular/core";
import { toTypeScript } from "@angular/compiler";

@Component({
  selector: "app-visit",
  templateUrl: "./visit.component.html",
  
})
export class VisitComponent {

  isLoggedIn: boolean;

  patientId: string;
  departamentId: string;
  hospitalId: string;
  doctorId: string;
  date: string;
 
  departamentList = [];  
  hospitalList = [];
  doctorList = [];
  dateList = [];


  
  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private hospitalService: HospitalService,
  ) {
  }

  ngOnInit() {

    this.isLoggedIn = this.authService.isLoggedIn();
    this.getHospitals();
    this.patientId = this.route.snapshot.paramMap.get("id");

  }

  getHospitals(pageNumber = 0, postsPerPage = 10) {
    this.hospitalService.getHospitals(pageNumber, postsPerPage)
      .subscribe(result => {
        this.hospitalList = result.hospitals;
      });
  }

  getDepartaments(event) {
    this.hospitalId = event.value.id;
    this.hospitalService.getDepartaments(this.hospitalId, 0, 10).subscribe(result => {
      this.departamentList = result.departaments;
    });
  }
  
  getDoctor(event) {
    this.departamentId = event.value.id
    this.hospitalService.getDoctorsFromDep(this.departamentId, 0, 10)
      .subscribe(result => {
        this.doctorList = result.doctors;       
      });
  }

  getDays(event) {
    this.doctorId = event.value.id;
  }

  getHours(event) {
    this.date = 'ok';
    var dateSr = event.value.toDateString();    
    this.hospitalService.getHoursFromDay(dateSr).subscribe(result => {
      this.dateList = result; 
    });
  }

  myFilter = (d: Date): boolean => {
    const day = d.getDay();
    return day !== 0 && day !== 6;
  }

  saveTime(event) {
    this.date = event.value;
  }
  createVisit() {
    this.hospitalService.createVisit(this.hospitalId, this.doctorId, this.patientId, this.date).subscribe();
    this.router.navigateByUrl("");
  }


}
