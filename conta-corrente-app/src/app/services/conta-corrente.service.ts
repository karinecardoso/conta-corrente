import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Saldo, Extrato } from '../types/conta-corrente.interface';
import { retry } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContaCorrenteService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  obterSaldo(idConta: number){
    return this.http.get<Saldo>(`${this.baseUrl}/${idConta}/saldo`).pipe(
      retry(1)
    );
  }

  obterExtrato(idConta: number){
    return this.http.get<Extrato[]>(`${this.baseUrl}/${idConta}/extrato`).pipe(
      retry(1)
    );
  }
}
