import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LawCase } from '../models/LawCase';

@Injectable({
  providedIn: 'root'
})
export class LawCaseService {
  private url = "LawCase"
  constructor(private http: HttpClient) { }
  
  public getLawCases() : Observable<LawCase[]>{
    return this.http.get<LawCase[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updateLawCase(lawCase: LawCase) : Observable<LawCase[]>{
    console.log(lawCase);
    return this.http.put<LawCase[]>(`${environment.apiUrl}/${this.url}`, lawCase);
  }

  public createLawCase(lawCase: LawCase){
    return this.http.post<LawCase[]>(`${environment.apiUrl}/${this.url}`, lawCase);
  }
  public deleteLawCase(lawCase: LawCase){
    return this.http.delete<LawCase[]>(`${environment.apiUrl}/${this.url}/${lawCase.id}`);
  }

  public searchByDocument(documentName: string){
    return this.http.get<LawCase[]>(`${environment.apiUrl}/${this.url}/search/${documentName}`);
  }
}
