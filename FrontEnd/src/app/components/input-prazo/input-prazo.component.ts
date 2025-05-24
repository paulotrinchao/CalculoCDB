import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-input-prazo',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './input-prazo.component.html'
})
export class InputPrazoComponent {

  @Output() prazoChange = new EventEmitter<number>();

  prazoTexto: string = '';
  prazo: number = 0;
  prazoInvalido: boolean = false;

  onPrazoChange(event: Event): void {
    this.prazoTexto = (event.target as HTMLInputElement).value.trim();

    const parsed = Number(this.prazoTexto);
    const isValid = Number.isInteger(parsed) && parsed >= 2;

    this.prazoInvalido = !isValid;
    this.prazo = isValid ? parsed : 0;
    this.prazoChange.emit(this.prazo);
  }

}
