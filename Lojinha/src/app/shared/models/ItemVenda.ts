import { Produto } from "./Produto";

export class ItemVenda {
  constructor(qtd: number, produto: Produto, cod: number) {
    this.quantidade = qtd;
    this.produto = produto;
    this.produtoCodigo = cod;
  }

  //itemVendaId: number;
  quantidade: number;
  //valorParcial: number;
  produtoCodigo: number;
  produto: Produto;
  //vendaId: number;
}
