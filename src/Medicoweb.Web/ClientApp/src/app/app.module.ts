import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";

import { DepartamentComponent } from "./components/departament/departament.component";
import { DoctorListComponent } from "./components/doctor-list/doctor-list.component";
import { DoctorComponent } from "./components/doctor/doctor.component";
import { CreateDrugModalComponent } from "./components/drug/create-drug-modal/create-drug-modal.component";
import { DrugComponent } from "./components/drug/drug.component";
import { EditDrugModalComponent } from "./components/drug/edit-drug-modal/edit-drug-modal.component";
import { HomeComponent } from "./components/home/home.component";
import { CreateHospitalModalComponent } from "./components/hospital-list/create-hospital-modal/create-hospital-modal.component";
import { EditHospitalModalComponent } from "./components/hospital-list/edit-hospital-modal/edit-hospital-modal.component";
import { HospitalListComponent } from "./components/hospital-list/hospital-list.component";
import { CreateDepartamentModalComponent } from "./components/hospital/create-departament-modal/create-departament-modal.component";
import { EditDepartamentModalComponent } from "./components/hospital/edit-departament-modal/edit-departament-modal.component";
import { HospitalComponent } from "./components/hospital/hospital.component";
import { LoginComponent } from "./components/login/login.component";
import { NavMenuComponent } from "./components/nav-menu/nav-menu.component";

import { PatientPrescriptionComponent } from "./components/patient-prescription/patient-prescription.component";
import { PatientVisitComponent } from "./components/patient-visits/patient-visits.component";
import { PatientListComponent } from "./components/patient/patient-list.component";
import { RegisterComponent } from "./components/register/register.component";
import { CreateSpecializationModalComponent } from "./components/specialization/create-specialization -modal/create-specialization-modal.component";
import { DetailsSpecializationModalComponent } from "./components/specialization/details-specialization-modal/details-specialization-modal.component";
import { EditSpecializationModalComponent } from "./components/specialization/edit-specialization-modal/edit-specialization-modal.component";
import { SpecializationComponent } from "./components/specialization/specialization.component";
import { MaterialModule } from "./material.module";
import { AuthService } from "./services/auth.service";
import { HospitalService } from "./services/hospital.service";
import { JwtUtil } from "./utils/jwt.util";
import { VisitComponent } from "./components/visit/visit.component";
import { Component } from '@angular/core';
import { MatDatepickerModule, MatNativeDateModule } from "@angular/material";
import { CreatePrescriptionComponent } from "./components/patient-visits/create-presccription/create-prescription.component";
import { VisitPrescriptionListComponent } from "./components/patient-visits/visit-prescription-list/visit-prescription-list.component";
import { PrescriptionDetailsComponent } from "./components/patient-visits/prescription-details/prescription-details.component";
import { CreatePharmacyModalComponent } from "./components/pharmacy/create-pharmacy-modal/create-pharmacy-modal.component";
import { DetailsPharmacyModalComponent } from "./components/pharmacy/details-specialization-modal/details-pharmacy-modal.component";
import { PharmacyComponent } from "./components/pharmacy/pharmacy.component";
import { EditPharmacyModalComponent } from "./components/pharmacy/edit-pharmacy-modal/edit-pharmacy-modal.component";


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
    DrugComponent,
    CreateDrugModalComponent,
    PatientVisitComponent,
    PatientPrescriptionComponent,
    EditDrugModalComponent,
    EditSpecializationModalComponent,
    EditHospitalModalComponent,
    EditDepartamentModalComponent,
    VisitComponent,
    DetailsSpecializationModalComponent,
    CreatePrescriptionComponent,
    VisitPrescriptionListComponent,
    PrescriptionDetailsComponent,
    DetailsPharmacyModalComponent,
    CreatePharmacyModalComponent,
    PharmacyComponent,
    EditPharmacyModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent },
      { path: "hospitals", component: HospitalListComponent },
      { path: "hospital/:id", component: HospitalComponent },
      { path: "departament/:id", component: DepartamentComponent },
      { path: "specialization", component: SpecializationComponent },
      { path: "specialization/:id", component: DetailsSpecializationModalComponent },
      { path: "patients", component: PatientListComponent },
      { path: "doctors", component: DoctorListComponent },
      { path: "doctor/:id", component: DoctorComponent },
      { path: "drugs", component: DrugComponent },
      { path: "newVisit/:id", component: VisitComponent },
      { path: "visits/:id", component: PatientVisitComponent },
      { path: "patientprescriptions/:id", component: PatientPrescriptionComponent },
      { path: "newprescription/:id", component: CreatePrescriptionComponent },
      { path: "prescriptions/:id", component: VisitPrescriptionListComponent },
      { path: "prescriptiondetails/:id", component: PrescriptionDetailsComponent },
      { path: "pharmacies", component: PharmacyComponent },
      { path: "pharmacy/:id", component: DetailsPharmacyModalComponent },

    ]),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    MatDatepickerModule,
    MatNativeDateModule
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
    EditSpecializationModalComponent,
    EditDepartamentModalComponent,
    EditHospitalModalComponent,
    DetailsSpecializationModalComponent,
    CreatePharmacyModalComponent,
    EditPharmacyModalComponent
  ]
})
export class AppModule {
}
