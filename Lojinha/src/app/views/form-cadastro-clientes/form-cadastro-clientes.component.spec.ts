import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormCadastroClientesComponent } from './form-cadastro-clientes.component';

describe('FormCadastroClientesComponent', () => {
  let component: FormCadastroClientesComponent;
  let fixture: ComponentFixture<FormCadastroClientesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormCadastroClientesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormCadastroClientesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
