export class UpdateHospitalRequest {
  constructor(
    public HospitalId: string,
    public Name: string,
    public Address: string) {
  }
}
