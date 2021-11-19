import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cliente } from 'src/app/shared/models/Cliente';
import { ControleClientesService } from 'src/app/shared/services/controle-clientes.service';

@Component({
  selector: 'app-form-edicao-cliente',
  templateUrl: './form-edicao-cliente.component.html',
  styleUrls: ['./form-edicao-cliente.component.css']
})
export class FormEdicaoClienteComponent implements OnInit {
  public clienteForm: FormGroup;

  constructor(@Inject(MAT_DIALOG_DATA) public clienteData: Cliente,
              private fb: FormBuilder,
              private controleClienteService: ControleClientesService,
              public dialogRef: MatDialogRef<FormEdicaoClienteComponent>) {}

  formGroupCliente(): void{
    this.clienteForm = this.fb.group({
      nome: [this.clienteData.nome, [Validators.required]],
      cpf: [{value: this.clienteData.cpf, disabled: true}, [Validators.required]],
      endereco: [this.clienteData.endereco, [Validators.required]],
      telefone: [this.clienteData.telefone, [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.formGroupCliente();
  }

  editarCliente(cpf: string): void {
    if(this.clienteForm.valid){
      let cliente = new Cliente(this.clienteForm.getRawValue());
      console.log(cliente);
      this.controleClienteService.editarCliente(cpf, cliente).subscribe( d => this.dialogRef.close(`Cliente ${cliente.nome}, CPF: ${cliente.cpf} editado com sucesso`) );
    }
  }

}
