import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
    const invalidParent = !!(control && control.parent && control.parent.invalid && control.parent.dirty);

    return (invalidCtrl || invalidParent);
  }
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  isLinear = true;
  externalAuthForm: FormGroup;
  registerForm: FormGroup;
  message: string;
  matcher = new MyErrorStateMatcher();

  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) {
    this.registerForm = this.formBuilder.group({

      username: [
        '',
        [Validators.required]
      ],
     
      name: [
              '',
        [Validators.required]
      ],
      surname: [
        '',
        [Validators.required]
      ],
      pesel: [
        '',
        [Validators.required]
      ],
      password: [
        '',
        [Validators.required]
      ],
  
    });
  }

  submit() {
    this.authService
      .register(
        this.registerForm.controls.username.value,             
        this.registerForm.controls.name.value,
        this.registerForm.controls.surname.value,
        this.registerForm.controls.pesel.value,  
        this.registerForm.controls.password.value
      )
      .subscribe(result => {
        localStorage.setItem('token', result);
        this.message = "";
        this.router.navigateByUrl('');
      }, error => {
        console.log(error);
        this.message = "Nieprawidłowe dane rejestracji"
      });
  }
}
