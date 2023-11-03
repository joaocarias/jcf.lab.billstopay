import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SignupPageComponent } from './pages/account/signup-page/signup-page.component';
import { HomeComponent } from './pages/manager/home/home.component';
import { FrameDashboardPageComponent } from './pages/master/frame-dashboard-page/frame-dashboard-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { AuthService } from './services/account/auth.service';

const routes: Routes = [
  
  { path: '', component: LoginPageComponent },
  { path: 'login', component: LoginPageComponent },
  { path: 'signup', component: SignupPageComponent},

  {
    path: 'manager',    
    component: FrameDashboardPageComponent,
    canActivate: [AuthService],
    children: [
      { path: '', component: HomeComponent }
    ]
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
