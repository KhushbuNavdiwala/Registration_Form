import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private apiUrl = 'https://localhost:7204/api/Company'; 

  constructor(private http: HttpClient) {}

  addCompany(company: any): Observable<any> {
    return this.http.post(this.apiUrl, company);
  }
}
