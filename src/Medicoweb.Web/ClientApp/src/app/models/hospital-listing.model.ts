import { Hospital } from "./hospital.model";

export class HospitalListing {
  constructor(
    public totalCount: number,
    public hospitals: Hospital[]) {
  }
}
