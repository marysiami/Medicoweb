import { AuthService } from "../../services/auth.service";
import { HospitalService } from "../../services/hospital.service";
import { MatDialog } from "@angular/material";
import { Router } from "@angular/router";
import { Component } from "@angular/core";


@Component({
  selector: "app-patient-visits",
  templateUrl: "./patient-visits.component.html",

})
export class PatientVisitComponent {

  isLoggedIn: boolean;
  displayedColumns: string[] = ["name", "surname", "pesel", "button"];
  pageSize = 10;
  // dataSource = new MatTableDataSource<>();

  constructor(
    private authService: AuthService,
    private hospitalService: HospitalService,
    private dialog: MatDialog,
    private router: Router
  ) {
  }
}
