import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cliente } from 'src/app/shared/models/Cliente';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ControleClientesService } from 'src/app/shared/services/controle-clientes.service';

@Component({
  selector: 'app-form-cadastro-clientes',
  templateUrl: './form-cadastro-clientes.component.html',
  styleUrls: ['./form-cadastro-clientes.component.css']
})
export class FormCadastroClientesComponent implements OnInit {
  public clienteForm: FormGroup;

  constructor(private fb: FormBuilder,
              private controleClienteService: ControleClientesService,
              public dialogRef: MatDialogRef<FormCadastroClientesComponent>) {}


  formGroupCliente(): void{
    this.clienteForm = this.fb.group({
      nome: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      endereco: ['', [Validators.required]],
      telefone: ['', [Validators.required]]
    });
  }


  ngOnInit(): void {
    this.formGroupCliente();
  }

  adicionarCliente(): void {
    if(this.clienteForm.valid){
      let cliente = new Cliente(this.clienteForm.value);
      this.controleClienteService.adicionarCliente(cliente).subscribe( d => this.dialogRef.close("Cliente cadastrado com sucesso!") );
    }
  }

}
