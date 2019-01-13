import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ["./login.component.css"]
})


export class LoginComponent {
  loginForm: FormGroup;
  message: string;

  constructor(private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router) {
    this.loginForm = this.formBuilder.group({
      username: [
        '',
        [Validators.required]
      ],
      password: [
        '',
        [Validators.required]
      ]
    });

  }

  submit() {
    this.authService
      .login(this.loginForm.controls.username.value, this.loginForm.controls.password.value)
      .subscribe(result => {
        localStorage.setItem('token', result);
        this.message = "";
        this.router.navigateByUrl('');
      }, error => this.message = "Username lub hasło jest niepoprawne.");
  }
}
