import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserOwnershipListComponent } from './user-ownership-list.component';

describe('UserOwnershipListComponent', () => {
  let component: UserOwnershipListComponent;
  let fixture: ComponentFixture<UserOwnershipListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserOwnershipListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserOwnershipListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
