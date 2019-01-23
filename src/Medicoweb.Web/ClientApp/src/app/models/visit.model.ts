export class Visit {
  constructor(
    public id: string,
    public PatientName: string,
    public PatientSurname: string,
    public DoctorName: string,
    public DoctorSurname: string,
    public HospitalName: string,
    public HospitalAddress: string,
    public Date: Date,
    ) {
  }
}
