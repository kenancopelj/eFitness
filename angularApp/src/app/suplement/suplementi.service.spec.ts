import { TestBed } from '@angular/core/testing';

import { SuplementiService } from './suplementi.service';

describe('SuplementiService', () => {
  let service: SuplementiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SuplementiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
