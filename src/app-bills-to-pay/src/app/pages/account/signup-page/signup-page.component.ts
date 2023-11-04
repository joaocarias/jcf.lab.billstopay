import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserDataService } from 'src/app/services/account/user-data.service';

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html'
})
export class SignupPageComponent implements OnInit {
  public form: FormGroup;  

  constructor(
    private router: Router,
    private service: UserDataService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {
    this.form = this.fb.group({
      namefull: ['', Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(200),
        Validators.required   
      ])],
      email: ['', Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(200),
        Validators.email,
        Validators.required
      ])],
      password: ['', Validators.compose([
        Validators.minLength(8),
        Validators.maxLength(20),
        Validators.required   
      ])],
      password_check: ['', Validators.compose([
        Validators.minLength(8),
        Validators.maxLength(20),
        Validators.required   
      ])]
    });
  }
      
  ngOnInit(): void {
    
  }
  
  submit() {    
    this
      .service
      .create(this.form.value)
      .subscribe({
          next: (data: any) => {         
          this.toastr.success("Olá "+ data.name +", Cadastro realizado com sucesso!", 'Bem-vindo!');        
          this.router.navigate(['/login']);
        },
         error: (err) => {
          console.log(err);          
        }
      });
  }

}
