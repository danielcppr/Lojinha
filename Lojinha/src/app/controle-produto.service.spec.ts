import { TestBed } from '@angular/core/testing';

import { ControleProdutoService } from './controle-produto.service';

describe('ControleProdutoService', () => {
  let service: ControleProdutoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ControleProdutoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
