import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-input-monetario',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './input-monetario.component.html'
})
export class InputMonetarioComponent {
  valor = 0;

  @Output() valorChange = new EventEmitter<number>();

  onValorChange(event: any) {
    const rawInput = event.target.value;
    const normalizado = rawInput.replace(',', '.');

    const regex = /^\d+([,.]\d{0,2})?$/;

    if (regex.test(rawInput)) {
      const valor = parseFloat(normalizado);
      if (!isNaN(valor)) {
        this.valor = valor;
        this.valorChange.emit(parseFloat(valor.toFixed(2)));
      }
    }

    const valorVisivel = this.valor.toFixed(2).replace('.', ',');
    event.target.value = valorVisivel;
  }
}
