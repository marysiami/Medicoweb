import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import "rxjs/add/operator/map"

import { JwtUtil } from "../utils/jwt.util";

import { LoginRequest } from "../models/request/login-request.model";
import { RegisterRequest } from "../models/request/register-request.model";
import { BaseService } from "./base.service";

@Injectable()
export class AuthService extends BaseService {

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string, private jwtUtil: JwtUtil) {
    super(http, baseUrl);
  }

  login(username, password) {
    const loginModel = new LoginRequest(username, password);
    const url = this.baseUrl + "Auth/Login";

    return this.http.post<string>(url, loginModel);
  }

  register(username, name, surname, pesel, password) {
    const registerModel = new RegisterRequest(username, name, surname, pesel, password);
    const url = this.baseUrl + "Auth/Register";

    return this.http.post<string>(url, registerModel);
  }

  isLoggedIn() {

    const token = localStorage.getItem("token");

    if (token != null) {
      const decodedToken = this.jwtUtil.decode(localStorage.getItem("token"));
      const currentUnixTimestamp = Math.round((new Date()).getTime() / 1000);

      if (decodedToken.exp > currentUnixTimestamp) {
        return true;
      }
    }
    return false;
  }
}
