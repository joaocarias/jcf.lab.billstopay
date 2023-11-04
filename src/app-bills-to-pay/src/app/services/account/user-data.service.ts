import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Security } from 'src/app/utils/security.util';
import { User } from 'src/app/models/user.model';

@Injectable({
    providedIn: 'root'
})
export class UserDataService{

    public url = 'https://localhost:7082';

    constructor(private http: HttpClient){

    }

    public composeHeaders(){
        const token = Security.getToken();
        const headers = new HttpHeaders().set('Authorization', `bearer ${token}`);
        return headers;
    }

    authenticate(data: any) {       
        return this.http.post(`${this.url}/User/Login`, data);
    }

    refreshToken(){
        return this.http.post(
            `${this.url}/User/RefreshToken`, 
            null,
            { headers: this.composeHeaders() });
    }

    create(data: any) {
        var user = new User(null, data.namefull, data.email, data.email, data.password);
        return this.http.post(`${this.url}/User/Create`, user);
    }
    
}