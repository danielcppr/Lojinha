import { TestBed } from '@angular/core/testing';

import { ControleFuncionariosService } from './controle-funcionarios.service';

describe('ControleFuncionariosService', () => {
  let service: ControleFuncionariosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ControleFuncionariosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
