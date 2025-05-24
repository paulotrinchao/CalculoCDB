import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InputMonetarioComponent } from './components/input-monetario/input-monetario.component';
import { InputPrazoComponent } from './components/input-prazo/input-prazo.component';
import { BotaoSimularComponent } from './components/botao-simular/botao-simular.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    InputMonetarioComponent,
    InputPrazoComponent,
    BotaoSimularComponent
  ],
  templateUrl: './app.component.html'
})
export class AppComponent {
  valorMonetario = 0;
  prazoMeses = 0;
  resultado: any = null;
  erro: string = '';
}
