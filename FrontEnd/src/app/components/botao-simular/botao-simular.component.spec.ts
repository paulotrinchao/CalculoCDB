import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BotaoSimularComponent } from './botao-simular.component';

describe('BotaoSimularComponent', () => {
  let component: BotaoSimularComponent;
  let fixture: ComponentFixture<BotaoSimularComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BotaoSimularComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BotaoSimularComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
