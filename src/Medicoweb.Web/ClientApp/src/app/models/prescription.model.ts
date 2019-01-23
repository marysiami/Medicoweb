import { DrugPrescriptionListing } from "./drug-prescription-listing";

export class Prescription {
  constructor(
    public id: string,
    public patientName: string,
    public patientSurname: string,    
    public doctorName: string,
    public doctorSurname: string,
    public drugs: DrugPrescriptionListing[]  ) {
  }
}
