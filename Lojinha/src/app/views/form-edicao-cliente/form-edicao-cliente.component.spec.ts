import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormEdicaoClienteComponent } from './form-edicao-cliente.component';

describe('FormEdicaoClienteComponent', () => {
  let component: FormEdicaoClienteComponent;
  let fixture: ComponentFixture<FormEdicaoClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormEdicaoClienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormEdicaoClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
