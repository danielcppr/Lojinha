import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cliente } from 'src/app/shared/models/Cliente';
import { Funcionario } from 'src/app/shared/models/Funcionario';
import { ItemVenda } from 'src/app/shared/models/ItemVenda';
import { Produto } from 'src/app/shared/models/Produto';
import { ControleClientesService } from 'src/app/shared/services/controle-clientes.service';
import { ControleFuncionariosService } from 'src/app/shared/services/controle-funcionarios.service';
import { ControleProdutosService } from 'src/app/shared/services/controle-produtos.service';


@Component({
  selector: 'app-cadastro-vendas',
  templateUrl: './cadastro-vendas.component.html',
  styleUrls: ['./cadastro-vendas.component.css']
})

export class CadastroVendasComponent implements AfterViewInit {
  public itens: ItemVenda[] = [];
  public novaVendaForm: FormGroup;
  public clientes: Cliente[];
  public vendedores: Funcionario[];
  public produtos: Produto[];

  constructor(private fb: FormBuilder,
    private clienteService: ControleClientesService,
    private funcionarioService: ControleFuncionariosService,
    private produtoService: ControleProdutosService
    ) { }


  displayedColumns = ['codigo', 'descricao', 'valor-unitario', 'quantidade'];

  ngAfterViewInit(): void {
    this.formGroupNovaVenda();
    this.getClientes();
    this.getFuncionarios();
    this.getProdutos();
    }

  formGroupNovaVenda(): void {
    this.novaVendaForm = this.fb.group({
      cliente: ['', [Validators.required]],
      vendedor: ['', [Validators.required]],
      produto: ['', [Validators.required]],
      quantidade: ['', [Validators.required]]
    });
  }

  addItem(): void {
    let produtoCod = this.novaVendaForm.value.produto;
    let qtde = this.novaVendaForm.value.quantidade;
    console.log("COD PRODUTO  =   " + produtoCod)
    let produto;
    let item;
    this.produtoService.getProdutoPorCodigo(produtoCod).subscribe(p => {
      produto = p ;
      item = new ItemVenda(qtde, produto, produtoCod);
      this.itens.push(item);
      this.ngAfterViewInit();
    });
  }

  getClientes(): void {
    this.clienteService.getTodosClientes().subscribe(c => {
      this.clientes = c;
    })
  }

  getFuncionarios(): void {
    this.funcionarioService.getTodosFuncionarios().subscribe(f => {
      this.vendedores = f;
    })
  }

  getProdutos(): void {
    this.produtoService.getTodosProdutos().subscribe(p => {
      this.produtos = p;
    })
  }
}





