import { ItemVenda } from "./ItemVenda";

export class Venda {
  vendaId: number;
  valorTotal: number;
  formaPagamento: string;
  clienteId: number;
  funcionarioMatricula: number;

  itens: ItemVenda[];
}
