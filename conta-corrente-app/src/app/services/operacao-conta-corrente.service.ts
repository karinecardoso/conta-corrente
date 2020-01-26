import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { DadosOperacao } from "../types/conta-corrente.interface";
import { Observable, of } from "rxjs";
import { retry, map, catchError } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class OperacaoContaCorrenteService {
  baseUrl = environment.baseUrl;

  httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json"
    })
  };

  constructor(private http: HttpClient) {}

  efetuarDeposito(dadosOperacao: DadosOperacao): Observable<any> {
    return this.efetuarOperacao(dadosOperacao, "deposito");
  }

  efetuarRetirada(dadosOperacao: DadosOperacao): Observable<any> {
    return this.efetuarOperacao(dadosOperacao, "retirada");
  }

  efetuarPagamento(dadosOperacao: DadosOperacao): Observable<any> {
    return this.efetuarOperacao(dadosOperacao, "pagamento");
  }

  private efetuarOperacao(dadosOperacao: DadosOperacao, tipoOperacao: string) {
    return this.http
      .post(
        `${this.baseUrl}/${tipoOperacao}`,
        JSON.stringify(dadosOperacao),
        this.httpOptions
      )
      .pipe(
        retry(1),
        catchError(err => {
          return of(this.getErrorMessage(err));
        })
      );
  }

  private getErrorMessage(error) {
    debugger;
    if (error.error instanceof ErrorEvent) {
      return error.error.message;
    }

    if (error.error instanceof ProgressEvent) {
      return;
    }

    return error.error;
  }
}
