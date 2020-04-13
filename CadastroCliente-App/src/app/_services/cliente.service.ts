import { Injectable, Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../_models/Cliente';

@Injectable()
export class ClienteService {

baseURL = 'https://localhost:44316/api/Clientes';

// prod
// baseURL = 'http://diegomulet.eastus.cloudapp.azure.com/ProaAgilAPI/api/cliente';

constructor(private http: HttpClient) {}

getAllCliente(): Observable<Cliente[]>  {
   return this.http.get<Cliente[]>(this.baseURL);
}

getClienteById(id: number): Observable<Cliente>  {
  return this.http.get<Cliente>(`${this.baseURL}/${id}`);
}

postCliente(cliente: Cliente) {
  return this.http.post(this.baseURL, cliente);
}

putCliente(cliente: Cliente) {
  return this.http.put(`${this.baseURL}/${cliente.clienteId}`, cliente);
}

deleteCliente(id: string) {
  return this.http.delete(`${this.baseURL}/${id}`);
}

}
