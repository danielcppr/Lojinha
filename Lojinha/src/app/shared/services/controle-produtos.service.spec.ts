import { TestBed } from '@angular/core/testing';

import { ControleProdutosService } from './controle-produtos.service';

describe('ControleProdutosService', () => {
  let service: ControleProdutosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ControleProdutosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
