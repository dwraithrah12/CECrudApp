import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    baseUrl = 'http/localhost:5000/api/auth/';

    constructor(private httpClient: HttpClient){
    }

    login(signInInfo: any){
        return this.httpClient.post(this.baseUrl + 'login', signInInfo)
            .pipe(
                map((response: any) => {
                    const user = response;
                    if (user) {
                        localStorage.setItem('token', user.token);
                    }
                })
            );
    }
}