import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledPacijentiComponent } from './pregled-pacijenti.component';

describe('PregledPacijentiComponent', () => {
  let component: PregledPacijentiComponent;
  let fixture: ComponentFixture<PregledPacijentiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledPacijentiComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PregledPacijentiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
