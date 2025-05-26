# 💰 Cálculo de Investimento em CDB

Projeto desenvolvido como parte de uma avaliação técnica para a Diretoria de Desenvolvimento de Sistemas de Middle e Back Office da B3. O objetivo é implementar uma aplicação capaz de calcular a rentabilidade bruta e líquida de um investimento em CDB, respeitando regras impostas no requisitos fornecidos.

---

## 📚 Objetivo do Projeto

O projeto permite ao usuário informar:

- **Valor inicial** do investimento (positivo e com até duas casas decimais).
- **Prazo em meses** (mínimo de 1 mês) para o resgate.

Com essas informações, a aplicação retorna:

- **Valor Bruto** do investimento após o prazo.
- **Valor Líquido**, com desconto de IR conforme a tabela informada.

---

## 🧰 Tecnologias Utilizadas

### Frontend

- Angular 9
- TypeScript
- Bootstrap 5

### Backend

- ASP.NET Core 8 (Web API)
- C#
- xUnit para testes

---

## ⚙️ Como Executar o Projeto

### 1. Clone o Repositório

```bash
git clone https://github.com/paulotrinchao/CalculoCDB.git
cd CalculoCDB
```

### 2. Executar a API (.NET 8)

```bash
cd WebApi
dotnet restore
dotnet run
```

A API será iniciada em:  
`https://localhost:44375`

### 3. Executar o Frontend (Angular 9)

```bash
cd frontend
npm install
ng serve
```

O frontend será iniciado em:  
`http://localhost:4200`

---

## 🧮 Lógica de Cálculo

### Fórmula para rendimento composto mensal:

```
VF = VI × [1 + (CDI × TB)] 
```

- **VF**: Valor Final  
- **VI**: Valor Inicial  
- **CDI**: 0,9% (fixo)  
- **TB**: 108% (fixo)  

### Tabela de IR:

| Prazo           | Alíquota |
|------------------|----------|
| Até 6 meses      | 22,5%    |
| Até 12 meses     | 20%      |
| Até 24 meses     | 17,5%    |
| Acima de 24 meses| 15%      |

---

## ✅ Testes

### Backend

- Cobertura superior a 90% na lógica de cálculo
- Para executar os testes:

```bash
cd Tests
dotnet test
```

---

## 🧪 Boas Práticas Adotadas

- Separação de responsabilidades (camadas distintas)
- Aplicação dos princípios **SOLID**
- Cobertura de testes no backend
- Análise estática via **SonarLint**
- Código limpo e sem *warnings* críticos

---

## 📄 Licença

Este projeto é de uso exclusivo para avaliação técnica pública.

---

## ✍️ Autor

Desenvolvido por **Paulo Trinchão**  
[GitHub](https://github.com/paulotrinchao) • [LinkedIn](https://www.linkedin.com/in/paulo-trinchao/)
