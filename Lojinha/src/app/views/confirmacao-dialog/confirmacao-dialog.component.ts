import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmacao-dialog',
  templateUrl: './confirmacao-dialog.component.html',
  styleUrls: ['./confirmacao-dialog.component.css']
})
export class ConfirmacaoDialogComponent implements OnInit {
  mensagem: string = 'Tem certeza que deseja fazer isso?';

  constructor(public dialogRef: MatDialogRef<ConfirmacaoDialogComponent>) { }

  ngOnInit(): void {
  }

  confirmar(): void{
    this.dialogRef.close(true);
  }

  cancelar(): void {
    this.dialogRef.close(false);
  }


}
