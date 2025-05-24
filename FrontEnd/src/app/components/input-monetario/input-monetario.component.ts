import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-input-monetario',
  imports: [CommonModule],
  templateUrl: './input-monetario.component.html',
})
export class InputMonetarioComponent {
  valor: string = '';
  valorValido: boolean = false;

  @Output() valorChange = new EventEmitter<number>();

  onValorChange(event: Event): void {
    this.valor = (event.target as HTMLInputElement).value.trim();


    const regex = /^(?:[1-9]\d*|0)?([,.]\d+)?$/;
    const separadores = (this.valor.match(/[,.]/g) || []).length;

    const isFormatoValido = regex.test(this.valor) && separadores <= 1;
    const numero = Number(this.valor.replace(',', '.'));

    this.valorValido = isFormatoValido && !isNaN(numero) && numero > 0;

    this.valorChange.emit(this.valorValido ? numero : 0);
  }
}
