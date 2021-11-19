import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/Cliente'

@Injectable({
  providedIn: 'root'
})
export class ControleClientesService {
  private apiUrl = 'https://localhost:5001/api/Cliente'

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public getTodosClientes(): Observable<Cliente[]>{
    return this.httpClient.get<Cliente[]>(this.apiUrl);
  }

  public removeCliente(clienteId: number): Observable<Cliente>{
    return this.httpClient.delete<Cliente>(`${this.apiUrl}/id/${clienteId}`)
  }

  public adicionarCliente(cliente: Cliente): Observable<Cliente>{
    return this.httpClient.post<Cliente>(this.apiUrl, cliente, this.httpOptions);
  }

  public editarCliente(clienteCpf: string, cliente: Cliente): Observable<Cliente>{
    return this.httpClient.put<Cliente>(`${this.apiUrl}/cpf/${clienteCpf}`, cliente, this.httpOptions);
  }

}
