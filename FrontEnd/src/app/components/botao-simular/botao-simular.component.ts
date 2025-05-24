import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, provideHttpClient } from '@angular/common/http';

@Component({
  selector: 'app-botao-simular',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './botao-simular.component.html'
})
export class BotaoSimularComponent {
  @Input() valorMonetario: number = 0;
  @Input() prazoMeses: number = 0;
  @Input() disabled: boolean = false;

  @Output() resultadoEmitido = new EventEmitter<any>();
  @Output() erroEmitido = new EventEmitter<string>();

  carregando = false;

  constructor(private http: HttpClient) { }

  enviarRequisicao() {
    this.carregando = true;

    this.http.post<any>('https://localhost:44375/api/Rentabilidade/cdb', {
      valorMonetario: this.valorMonetario,
      prazoMeses: this.prazoMeses
    }).subscribe({
      next: (res) => {
        this.resultadoEmitido.emit(res);
        this.erroEmitido.emit('');
        this.carregando = false;
      },
      error: err => {
        this.erroEmitido.emit(err.error || 'Erro inesperado.');
        this.resultadoEmitido.emit(null);
        this.carregando = false;
      }
    });
  }
}
