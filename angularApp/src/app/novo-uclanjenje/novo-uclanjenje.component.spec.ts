import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoUclanjenjeComponent } from './novo-uclanjenje.component';

describe('NovoUclanjenjeComponent', () => {
  let component: NovoUclanjenjeComponent;
  let fixture: ComponentFixture<NovoUclanjenjeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NovoUclanjenjeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NovoUclanjenjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
