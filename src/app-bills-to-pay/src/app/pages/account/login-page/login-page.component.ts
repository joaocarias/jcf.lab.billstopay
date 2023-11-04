import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserDataService } from 'src/app/services/account/user-data.service';
import { Security } from 'src/app/utils/security.util';

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
    const token = Security.getToken();
    if(token){
      this
      .service
      .refreshToken()
      .subscribe({
        next: (data: any) => {            
          this.setUser(new User(data.Id, data.name, data.userName, null, null, data.firstName), data.token); 
        },
        error: (err) => {
          Security.clear();
        }
      });       
    }    
  }

  submit() {    
     this
        .service
        .authenticate(this.form.value)
        .subscribe({
          next: (data: any) => {              
            this.setUser(new User(data.Id, data.name, data.userName, null, null, data.firstName), data.token); 
          },
          error: (err) => {
            Security.clear();
          }
        });        
  }

  setUser(user: User, token: string) {
    Security.set(user, token);    
    this.router.navigate(['/manager']);
  }
}
