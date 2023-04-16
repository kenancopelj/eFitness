import { TestBed } from '@angular/core/testing';

import { GrupniTreningService } from './grupni-trening.service';

describe('GrupniTreningService', () => {
  let service: GrupniTreningService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GrupniTreningService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
