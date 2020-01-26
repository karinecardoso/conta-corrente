export interface Saldo {
    id: number;
    agencia: number;
    numero: number;
    digito: number;
    saldo: number;
}

export interface Extrato {
    id: number;
    tipo: TipoOperacao,
    valor: number;
    data: Date;
    descricao: string;
    idConta: number;
}

export interface DadosOperacao {
    valor: number;
    idConta: number;
    descricao: string;
}

export enum TipoOperacao {
    Deposito,
    Retirada,
    Pagamento
}