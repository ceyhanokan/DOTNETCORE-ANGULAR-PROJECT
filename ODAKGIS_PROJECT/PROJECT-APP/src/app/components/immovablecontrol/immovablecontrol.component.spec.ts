import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImmovablecontrolComponent } from './immovablecontrol.component';

describe('ImmovablecontrolComponent', () => {
  let component: ImmovablecontrolComponent;
  let fixture: ComponentFixture<ImmovablecontrolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImmovablecontrolComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImmovablecontrolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
