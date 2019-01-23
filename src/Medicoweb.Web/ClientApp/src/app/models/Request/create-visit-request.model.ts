export class CreateVisitRequest {
  constructor (
   public hospitalId: string,
    public doctorId: string,
    public patientId: string,
    public date: string
    ) {  }
}


