import { Component, OnInit } from "@angular/core";
import { MatDialog, MatTableDataSource } from "@angular/material";
import { ActivatedRoute, Router } from "@angular/router";
import { Departament } from "../../models/departament.model";
import { DepartamentsFromDoctorListing } from "../../models/departaments-fromDoctor-listing.model";
import { Specialization } from "../../models/specialization.model";
import { SpecializationsFromDoctorListing } from "../../models/specializations-fromDoctor-listing.model";
import { AuthService } from "../../services/auth.service";
import { HospitalService } from "../../services/hospital.service";
import { FormControl } from "@angular/forms";

@Component({
  selector: "app-doctor",
  templateUrl: "./doctor.component.html",
  styleUrls: ["./doctor.component.css"]
})
export class DoctorComponent implements OnInit {

  departamentListing = new DepartamentsFromDoctorListing("", "", 0, []);
  specializationListing = new SpecializationsFromDoctorListing("", "", 0, []);
  dataSourceDep = new MatTableDataSource<Departament>();
  dataSourceSpec = new MatTableDataSource<Specialization>();
  isLoggedIn: boolean;
  displayedColumnsDep: string[] = ["name"];
  displayedColumnsSpec: string[] = ["name"];
  pageSize = 10;
  doctorId: string;

  hospitalId: string;

  
  departaments = new FormControl();
  departamentList = [];
  specializations = new FormControl();
  specializationList = [];
  hospitalList = [];

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.doctorId = this.route.snapshot.paramMap.get("id");
    //this.getDepartamentFromDoctor();
    //this.getSpecializationsFromDoctor();
    this.getHospitals(); 
    this.getSpecializations();
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

  getSpecializations() {
    this.hospitalService.getSpecialzations(0, 10).subscribe(result => {
      this.specializationList = result.specialization;
    });
  }

  addDepartamentToDoctor() {
    var depTable = [];
    depTable = this.departaments.value;
    console.log(depTable.map(x => x.id));  //mega zle
    
  }

 /* getDepartamentFromDoctor(pageNumber = 0, postsPerPage = 10) {

    this.hospitalService.getDepartamentsFromDoctor(this.doctorId, pageNumber, postsPerPage)
      .subscribe(result => {
        this.departamentListing = result;
        console.log(result);
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
  */
  
}
