import { Prescription } from "./prescription.model";

export class PrescriptionListing {
  constructor(
    public totalCount: number,
    public prescriptions: Prescription[]) {
  }
}
