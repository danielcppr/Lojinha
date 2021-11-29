import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcionario } from '../models/Funcionario';

@Injectable({
  providedIn: 'root'
})
export class ControleFuncionariosService {

  private apiUrl = 'https://localhost:5001/api/Funcionario'

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public getTodosFuncionarios(): Observable<Funcionario[]>{
    return this.httpClient.get<Funcionario[]>(this.apiUrl);
  }

}
