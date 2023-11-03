import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SignupPageComponent } from './pages/account/signup-page/signup-page.component';
import { HomeComponent } from './pages/manager/home/home.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { FrameDashboardPageComponent } from './pages/master/frame-dashboard-page/frame-dashboard-page.component';
import { NavbarTopComponent } from './components/shared/navbar-top/navbar-top.component';
import { FooterDefaultComponent } from './components/shared/footer-default/footer-default.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { LoadingComponent } from './components/shared/loading/loading.component';
import { UserDataService } from './services/account/user-data.service';
import { AuthService } from './services/account/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,    
    SignupPageComponent, HomeComponent, NavbarComponent, FrameDashboardPageComponent, NavbarTopComponent, FooterDefaultComponent, LoadingComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), //https://www.npmjs.com/package/ngx-toastr
    AppRoutingModule
  ],
  providers: [
    UserDataService, 
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
