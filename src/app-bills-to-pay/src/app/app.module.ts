import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { SignupPageComponent } from './pages/account/signup-page/signup-page.component';
import { HomeComponent } from './pages/manager/home/home.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { FrameDashboardPageComponent } from './pages/master/frame-dashboard-page/frame-dashboard-page.component';
import { NavbarTopComponent } from './components/shared/navbar-top/navbar-top.component';
import { FooterDefaultComponent } from './components/shared/footer-default/footer-default.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,    
    SignupPageComponent, HomeComponent, NavbarComponent, FrameDashboardPageComponent, NavbarTopComponent, FooterDefaultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
