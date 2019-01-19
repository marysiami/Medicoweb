export class RegisterRequest {
  constructor(
    public UserName: string,
    public Name: string,
    public Surname: string,
    public Pesel: string,
    public Password: string
  ) {
  }
}
