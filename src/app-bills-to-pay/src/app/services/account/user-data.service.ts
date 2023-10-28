import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserDataService{

    public url = 'https://localhost:7082';

    constructor(private http: HttpClient){

    }

    authenticate(data: any) {
        console.log(data);
        return this.http.post(`${this.url}/User/Login`, data);
    }
    
}