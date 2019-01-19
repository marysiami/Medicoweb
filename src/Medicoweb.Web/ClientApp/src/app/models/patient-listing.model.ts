import { Patient } from "./patient.model";


export class PatientListing {
  constructor(
    public totalCount: number,
    public patients: Patient[]) {
  }
}
