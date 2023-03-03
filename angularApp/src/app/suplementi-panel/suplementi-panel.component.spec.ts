import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuplementiPanelComponent } from './suplementi-panel.component';

describe('SuplementiPanelComponent', () => {
  let component: SuplementiPanelComponent;
  let fixture: ComponentFixture<SuplementiPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuplementiPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SuplementiPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
