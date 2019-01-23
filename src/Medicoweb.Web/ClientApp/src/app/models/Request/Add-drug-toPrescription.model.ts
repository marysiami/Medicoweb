export class AddDrugToPrescription {
  constructor(
    public drugId: string,
    public drugQuantity: number,
    public prescriptionId: string) {
}
}

