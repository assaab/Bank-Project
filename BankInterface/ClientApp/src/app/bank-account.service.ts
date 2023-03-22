import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BankAccountService {

  private apiUrl = 'https://7205/api/BankAccount';

  constructor(private http: HttpClient) { }

  openAccount(customerID: number, initialCredit: number): Observable<number> {
    return this.http.post<number>(`${this.apiUrl}/OpenAccount?customerID=${customerID}&initialCredit=${initialCredit}`, {});
  }

  getUserInfo(customerID: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/UserInfo/${customerID}`);
  }
}
