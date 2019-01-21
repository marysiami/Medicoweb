import { Component, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { MatDialog } from "@angular/material";
import { ActivatedRoute, Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";
import { HospitalService } from "../../services/hospital.service";
import { DepartamentsFromDoctorListing } from "../../models/departaments-fromDoctor-listing.model";

@Component({
  selector: "app-doctor",
  templateUrl: "./doctor.component.html",
  styleUrls: ["./doctor.component.css"]
})
export class DoctorComponent implements OnInit {
  isLoggedIn: boolean;
  doctorId: string;
  hospitalId: string;  
  departaments = new FormControl();
  departamentList = [];
  specializations = new FormControl();
  specializationList = [];
  hospitalList = [];
  departamentListing = new DepartamentsFromDoctorListing("", "", 0, []);

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,  
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.doctorId = this.route.snapshot.paramMap.get("id"); 
    this.getHospitals(); 
    this.getSpecializations();
    this.hospitalService.getDepartamentsFromDoctor(this.doctorId, 0, 10)
      .subscribe(result => {
        this.departamentListing = result;
      });
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

  addDepartamentToDoctor(event) {
    var tab = [];
    tab = event.map(x => x.id);
    for (var id in tab) {
      this.hospitalService.addDepartamentToDoctor(tab[id], this.doctorId).subscribe();
    }
  }
  addSpecializationToDoctor(event) {
    var tab = [];
    tab = event.map(x => x.id);
    for (var id in tab) {
      this.hospitalService.addSpecializationToDoctor(tab[id], this.doctorId).subscribe();
    }
  }
  openPatientsList() {
  this.router.navigateByUrl("/patients");   
  }
}
