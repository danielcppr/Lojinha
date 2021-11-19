import { AfterViewInit, Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cliente } from 'src/app/shared/models/Cliente';
import { ControleClientesService } from 'src/app/shared/services/controle-clientes.service';
import { ConfirmacaoDialogComponent } from '../confirmacao-dialog/confirmacao-dialog.component';
import { FormCadastroClientesComponent } from '../form-cadastro-clientes/form-cadastro-clientes.component';
import { FormEdicaoClienteComponent } from '../form-edicao-cliente/form-edicao-cliente.component';

@Component({
  selector: 'app-controle-clientes',
  templateUrl: './controle-clientes.component.html',
  styleUrls: ['./controle-clientes.component.css']
})

export class ControleClientesComponent implements AfterViewInit {
  public clientes: Cliente[];
  public sucessoMessage: string = '';

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'nome', 'cpf', 'endereco', 'telefone', 'opcoes'];

  constructor(private controleClienteService: ControleClientesService, public dialog: MatDialog)
  {}

  cadastrarClienteDialog() {
    const dialogRef = this.dialog.open(FormCadastroClientesComponent);

    dialogRef.afterClosed().subscribe(result => {
      this.sucessoMessage = result;
      setTimeout(() => {this.sucessoMessage = ''}, 3000);
      this.ngAfterViewInit();
    });
  }

  removeClienteDialog(id: number): void {
    const dialogRef = this.dialog.open(ConfirmacaoDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if(result)
      {
        this.removeCliente(id);
        this.sucessoMessage = "Cliente removido com sucesso!";
        setTimeout(() => {this.sucessoMessage = ''}, 3000);
        this.ngAfterViewInit();
      }
    });
  }

  editarClienteDialog(cliente: Cliente){
    const dialogRef = this.dialog.open(FormEdicaoClienteComponent, {
      data: cliente
    });

    dialogRef.afterClosed().subscribe(result => {
      this.sucessoMessage = result;
      setTimeout(() => {this.sucessoMessage = ''}, 3000);
      this.ngAfterViewInit();
    });
  }


  // openDialog() {
  //   this.dialog.open(FormCadastroClientesComponent, {
  //     data: {
  //       animal: 'panda',
  //     },
  //   });
  // }

  //

  ngAfterViewInit(): void {
    this.getClientes();
  }

  getClientes(): void {
    this.controleClienteService.getTodosClientes().subscribe(c => {
      this.clientes = c;
      console.log(this.clientes);
    })
  }

  removeCliente(id: number): void {
    this.controleClienteService.removeCliente(id).subscribe(data => {
      this.ngAfterViewInit();
    });
  }
}
