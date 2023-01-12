import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrupniTreningComponent } from './grupni-trening.component';

describe('GrupniTreningComponent', () => {
  let component: GrupniTreningComponent;
  let fixture: ComponentFixture<GrupniTreningComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GrupniTreningComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GrupniTreningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
