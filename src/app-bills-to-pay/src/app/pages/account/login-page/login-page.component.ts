import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserDataService } from 'src/app/services/account/user-data.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html' 
})
export class LoginPageComponent implements  OnInit  {
  public form: FormGroup;  

  constructor(
    private router: Router,
    private service: UserDataService,
    private fb: FormBuilder
  ) {
    this.form = this.fb.group({
      username: ['', Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(200),
        Validators.required        
      ])],
      password: ['', Validators.compose([
        Validators.minLength(6),
        Validators.maxLength(20),
        Validators.required
      ])]
    });
  }

  ngOnInit(): void {
   console.log("Olá Mundo");
  }

  submit() {    
     this
        .service
        .authenticate(this.form.value)
        .subscribe(
          (data) => {
            console.log(data);
          },
          (err) => {
            console.log(err);
          }
        );
        
  }

}
