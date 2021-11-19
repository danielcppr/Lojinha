export class Cliente {
  public constructor(init?: Partial<Cliente>) {
    Object.assign(this, init);
  }

  clienteId: number;
  nome: string;
  cpf: string;
  endereco: string;
  telefone: string;
}
