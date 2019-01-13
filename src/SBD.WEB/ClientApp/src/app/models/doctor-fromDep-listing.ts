import { Doctor } from "./doctor.model";

export class DoctorFromDepListing {
  constructor(
    public departamentName: string,
    public totalCount: number,
    public doctors: Doctor[]) { }
}
