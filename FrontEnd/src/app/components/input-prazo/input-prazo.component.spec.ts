import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputPrazoComponent } from './input-prazo.component';

describe('InputPrazoComponent', () => {
  let component: InputPrazoComponent;
  let fixture: ComponentFixture<InputPrazoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InputPrazoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputPrazoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
