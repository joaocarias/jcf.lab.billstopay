import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { Security } from 'src/app/utils/security.util';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit{
  public user?: User | null;
  constructor(private router: Router){

  }

  ngOnInit(): void {
     this.user = Security.getUser();
  }

  logout(): void{
    Security.clear();
    this.router.navigate(['/login']);
  }


}
