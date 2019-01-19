import { Doctor } from "./doctor.model";

export class DoctorListing {
  constructor(
    public totalCount: number,
    public doctors: Doctor[]) {
  }
}
