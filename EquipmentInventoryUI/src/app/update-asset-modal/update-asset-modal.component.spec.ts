import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAssetModalComponent } from './update-asset-modal.component';

describe('UpdateAssetModalComponent', () => {
  let component: UpdateAssetModalComponent;
  let fixture: ComponentFixture<UpdateAssetModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateAssetModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateAssetModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
