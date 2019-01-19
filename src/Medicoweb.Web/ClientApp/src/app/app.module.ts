import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from '@angular/router';
import { AppComponent } from "./app.component";
import { AdminHomeComponent } from './components/admin-home/admin-home.component';
import { DepartamentComponent } from './components/departament/departament.component';
import { DoctorListComponent } from './components/doctor-list/doctor-list.component';
import { CreateDoctorDepartamentnModalComponent } from './components/doctor/create-doctorDepartament-modal/create-doctorDep-modal.component';
import { CreateDoctorSpecializationModalComponent } from './components/doctor/create-doctorSpeciality-modal/create-doctorSpec-modal.component';
import { DoctorComponent } from './components/doctor/doctor.component';
import { CreateDrugModalComponent } from './components/drug/create-drug-modal/create-drug-modal.component';
import { DrugComponent } from './components/drug/drug.component';
import { HomeComponent } from "./components/home/home.component";
import { CreateHospitalModalComponent } from "./components/hospital-list/create-hospital-modal/create-hospital-modal.component";
import { HospitalListComponent } from './components/hospital-list/hospital-list.component';
import { CreateDepartamentModalComponent } from "./components/hospital/create-departament-modal/create-departament-modal.component";
import { HospitalComponent } from "./components/hospital/hospital.component";
import { LoginComponent } from './components/login/login.component';
import { NavMenuComponent } from "./components/nav-menu/nav-menu.component";
import { PatientHomeComponent } from './components/patient-home/patient-home.component';
import { PatientPrescriptionComponent } from './components/patient-prescription/patient-prescription.component';
import { PatientVisitComponent } from './components/patient-visits/patient-visits.component';
import { PatientListComponent } from './components/patient/patient-list.component';
import { RegisterComponent } from './components/register/register.component';
import { CreateSpecializationModalComponent } from './components/specialization/create-specialization -modal/create-specialization-modal.component';
import { SpecializationComponent } from './components/specialization/specialization.component';
import { VisitComponent } from './components/visit/visit.component';
import { MaterialModule } from './material.module';
import { AuthService } from "./services/auth.service";
import { HospitalService } from "./services/hospital.service";
import { JwtUtil } from "./utils/jwt.util";
import { EditDrugModalComponent } from './components/drug/edit-drug-modal/edit-drug-modal.component';
import { EditSpecializationModalComponent } from './components/specialization/edit-specialization-modal/edit-specialization-modal.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    HospitalListComponent,
    HospitalComponent,
    CreateHospitalModalComponent,
    CreateDepartamentModalComponent,
    DepartamentComponent,
    DoctorComponent,
    SpecializationComponent,
    PatientListComponent,
    DoctorListComponent,
    CreateSpecializationModalComponent,
    CreateDoctorSpecializationModalComponent,
    CreateDoctorDepartamentnModalComponent,
    AdminHomeComponent,
    PatientHomeComponent,
    DrugComponent,
    CreateDrugModalComponent,
    PatientVisitComponent,
    PatientPrescriptionComponent,
    EditDrugModalComponent,
    EditSpecializationModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent },
      { path: "adminpanel", component: AdminHomeComponent },
      { path: "patientpanel", component: PatientHomeComponent },
      { path: "hospitals", component: HospitalListComponent },
      { path: "hospital/:id", component: HospitalComponent },
      { path: "departament/:id", component: DepartamentComponent },
      { path: "specialization", component: SpecializationComponent },
      { path: "specialization/:id", component: SpecializationComponent },
      { path: "depdoctor/:id", component: CreateDoctorDepartamentnModalComponent },
      { path: "specdoctor/:id", component: CreateDoctorSpecializationModalComponent },
      { path: "patients", component: PatientListComponent },
      { path: "doctors", component: DoctorListComponent },
      { path: "doctor/:id", component: DoctorComponent },
      { path: "drugs", component: DrugComponent }
     // { path: "newVisit", component: VisitComponent },
      //{ path: "visits/:id", component: PatientVisitComponent },
      //{ path: "/prescriptions/:id", component: PatientPrescriptionComponent}
    ]),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [
    AuthService,
    JwtUtil,
    HospitalService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    CreateHospitalModalComponent,
    CreateDepartamentModalComponent,
    CreateSpecializationModalComponent,
    CreateDrugModalComponent,
    EditDrugModalComponent,
    EditSpecializationModalComponent
  ]
})
export class AppModule {
}
