import { Component, OnInit } from "@angular/core";
import { ContaCorrenteService } from "../services/conta-corrente.service";
import {
  Saldo,
  Extrato,
  TipoOperacao
} from "../types/conta-corrente.interface";
import { FormBuilder, Validators } from "@angular/forms";
import { OperacaoContaCorrenteService } from "../services/operacao-conta-corrente.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-conta-corrente",
  templateUrl: "./conta-corrente.component.html",
  styleUrls: ["./conta-corrente.component.scss"]
})
export class ContaCorrenteComponent implements OnInit {
  saldo: Saldo = null;
  extrato: Extrato[] = null;
  tipoOperacao = TipoOperacao;
  showOperacao = false;
  operacaoSelecionada = null;
  form;

  private ID_CONTA = 1;

  constructor(
    private contaCorrenteService: ContaCorrenteService,
    private operacaoContaCorrenteService: OperacaoContaCorrenteService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.form = this.formBuilder.group({
      valor: ["", [Validators.required, Validators.min(0.01)]],
      descricao: ""
    });

    this.obterInformacoesConta();
  }

  getLabelTipoOperacao(tipo: TipoOperacao) {
    switch (tipo) {
      case TipoOperacao.Deposito:
        return "Depósito";
      case TipoOperacao.Retirada:
        return "Saque";
      case TipoOperacao.Pagamento:
        return "Pagamento";
      default:
        return "";
    }
  }

  onClickOperacao(tipo: TipoOperacao) {
    this.showOperacao = true;
    this.operacaoSelecionada = tipo;
    this.form.reset();
  }

  onSubmit() {
    switch (this.operacaoSelecionada) {
      case TipoOperacao.Deposito:
        this.efetuarDeposito();
        return;
      case TipoOperacao.Retirada:
        this.efetuarRetirada();
        return;
      case TipoOperacao.Pagamento:
        this.efetuarPagamento();
        return;
      default:
        return;
    }
  }

  private obterInformacoesConta() {
    this.obterSaldo();
    this.obterExtrato();
  }

  private obterSaldo() {
    this.contaCorrenteService.obterSaldo(this.ID_CONTA).subscribe(saldo => {
      if (saldo) {
        this.saldo = saldo;
      }
    });
  }

  private obterExtrato() {
    this.contaCorrenteService.obterExtrato(this.ID_CONTA).subscribe(extrato => {
      if (extrato) {
        this.extrato = extrato;
      }
    });
  }

  private efetuarDeposito() {
    this.operacaoContaCorrenteService
      .efetuarDeposito(this.getDadosOperacao())
      .subscribe(response => {
        if (response) {
          this.toastr.error(response, "");
        } else {
          this.atualizarOperacaoEfetuada();
        }
      });
  }

  private efetuarRetirada() {
    this.operacaoContaCorrenteService
      .efetuarRetirada(this.getDadosOperacao())
      .subscribe(response => {
        if (response) {
          this.toastr.error(response, "");
        } else {
          this.atualizarOperacaoEfetuada();
        }
      });
  }

  private efetuarPagamento() {
    this.operacaoContaCorrenteService
      .efetuarPagamento(this.getDadosOperacao())
      .subscribe(response => {
        if (response) {
          this.toastr.error(response, "");
        } else {
          this.atualizarOperacaoEfetuada();
        }
      });
  }

  private atualizarOperacaoEfetuada() {
    this.toastr.success(
      `${this.getLabelTipoOperacao(
        this.operacaoSelecionada
      )} efetuado com sucesso!`,
      ""
    );
    this.limparDadosOperacao();
    this.obterInformacoesConta();
  }

  private getDadosOperacao() {
    return {
      idConta: this.ID_CONTA,
      valor: this.form.controls.valor.value,
      descricao: this.form.controls.descricao.value
    };
  }

  private limparDadosOperacao() {
    this.showOperacao = false;
    this.operacaoSelecionada = null;
    this.form.reset();
  }
}
