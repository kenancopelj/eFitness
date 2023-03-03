import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TreninziPanelComponent } from './treninzi-panel.component';

describe('TreninziPanelComponent', () => {
  let component: TreninziPanelComponent;
  let fixture: ComponentFixture<TreninziPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TreninziPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TreninziPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
