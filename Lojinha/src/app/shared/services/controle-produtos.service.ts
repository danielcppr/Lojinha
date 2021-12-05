import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from '../models/Produto';

@Injectable({
  providedIn: 'root'
})
export class ControleProdutosService {

  private apiUrl = 'https://localhost:5001/api/Produto'

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public getTodosProdutos(): Observable<Produto[]>{
    return this.httpClient.get<Produto[]>(this.apiUrl);
  }

  public getProdutoPorCodigo(cod: number): Observable<Produto>{
    return this.httpClient.get<Produto>(`${this.apiUrl}/cod/${cod}`)
  }
}
