import { TestBed } from '@angular/core/testing';

import { ControleClientesService } from './controle-clientes.service';

describe('ControleClientesService', () => {
  let service: ControleClientesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ControleClientesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
