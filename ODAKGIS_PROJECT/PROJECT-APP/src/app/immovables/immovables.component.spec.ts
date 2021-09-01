import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImmovablesComponent } from './immovables.component';

describe('ImmovablesComponent', () => {
  let component: ImmovablesComponent;
  let fixture: ComponentFixture<ImmovablesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImmovablesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImmovablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
