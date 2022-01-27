import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnershipQueryComponent } from './ownership-query.component';

describe('OwnershipQueryComponent', () => {
  let component: OwnershipQueryComponent;
  let fixture: ComponentFixture<OwnershipQueryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnershipQueryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnershipQueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
