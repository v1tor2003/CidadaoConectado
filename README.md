# CidadaoConectado API

**CidadaoConectado** is an API designed to provide transparency and participatory features for citizens. This project is part of the **Cepedi ResTic 36 Hackathon** and aims to enhance access to public data, enabling citizens to stay informed and engage with governmental actions.

The API aggregates data from external government transparency portals and presents it in a standardized format for easy integration into the **CidadaoConectado** website, which aims to increase citizen engagement in governance processes.

## Project Ideation and Implementation:

### Team Members
- **Adrielle Maria Alves Queiroz**, amaqueiroz.cic@uesc.br
- **Ezequiel Lobo Oliveira**, eloliveira.cic@uesc.br
- **Flávia Alessandra Santos de Jesus**, developerflavia@gmail.com
- **Gustavo Aragão Oliveira**, gaoliveira.cic@uesc.br
- **Hênio Pedro Silva Santana** , hpssantana.cic@uesc.br
- **João Pedro Correia da Silva Noberto**, jpcsnoberto@gmail.com
- **Mateus Silva Lisboa**, mslisboa.cic@uesc.br
- **Pedro Affonso Silva Marques**, pedroaffonsosilvamarques@gmail.com
- **Solana Bomfim Lemos**, solana.ametista@gmail.com
- **Vitor Pires Rocha**, vitor.pr04@hotmail.com


## Features

- **Data Aggregation**: Collects data from governmental transparency APIs and provides it to users in a structured format.
- **Public Transparency**: Makes it easier for citizens to access and understand public sector data.
- **Participatory Governance**: Allows citizens to interact with the data and participate in discussions and decisions.
- **Swagger UI (Development Mode)**: Provides an interactive API documentation interface via Swagger, enabling developers to easily explore and test the API endpoints.

---

## Endpoints

### Resign Values

- **GET /api/v1/resigns**
  - Fetches resignation values from the government transparency portal.
  - Returns a list of resignation data points with details such as year, value, and various tax-related information.

### Example Response:

```json
[
  {
    "ano": 2023,
    "valorRenunciado": 1500000,
    "tipoRenuncia": "Fiscal",
    "descricaoBeneficioFiscal": "Exemption on income tax",
    "descricaoFundamentoLegal": "Article 5, Law 123/2017",
    "tributo": "Income Tax",
    "formaTributacao": "Progressive",
    "cnpj": "12.345.678/0001-90",
    "razaoSocial": "Empresa X Ltda.",
    "nomeFantasia": "Empresa X",
    "cnaeCodigoGrupo": "47",
    "cnaeCodigoClasse": "4741",
    "cnaeCodigoSubClasse": "4741200",
    "cnaeNomeClasse": "Retail trade",
    "cnaeDivisao": "47",
    "uf": "SP",
    "municipio": "São Paulo",
    "codigoIBGE": "3550308"
  }
]
```
### Parlamentary Adments

- **GET /api/v1/adments**
  - Fetches parlamentary adments from the government transparency portal.
  - Returns a list of adments data with details such as author, type, and various values-related information.

### Example Response:

```json
[
  {
    "codigoEmenda": "string",
    "ano": 0,
    "tipoEmenda": "string",
    "autor": "string",
    "nomeAutor": "string",
    "numeroEmenda": "string",
    "localidadeDoGasto": "string",
    "funcao": "string",
    "subfuncao": "string",
    "valorEmpenhado": "string",
    "valorLiquidado": "string",
    "valorPago": "string",
    "valorRestoInscrito": "string",
    "valorRestoCancelado": "string",
    "valorRestoPago": "string"
  }
]
```

### Brazilian Family Scholarships (Bolsa Familia)

- **GET /api/v1/family-scholarships**
  - Fetches family scholarships of a specified city from the government transparency portal.
  - Returns a list of family scholarships data with details such as reference date, type, and various city-related information.

### Example Response:

```json
[
  {
    "id": 0,
    "dataReferencia": "2024-11-24",
    "municipio": {
      "codigoIBGE": "string",
      "nomeIBGE": "string",
      "codigoRegiao": "string",
      "nomeRegiao": "string",
      "pais": "string",
      "uf": {
        "sigla": "string",
        "nome": "string"
      }
    },
    "tipo": {
      "id": 0,
      "descricao": "string",
      "descricaoDetalhada": "string"
    },
    "valor": 0,
    "quantidadeBeneficiados": 0
  }
]
```

---

## Configuration

The API relies on configuration stored in the `appsettings.json` file for connecting to external data sources:

```json
{
  "TransparencyApiSettings" : {
    "BaseUrl": "https://api.portaldatransparencia.gov.br/api-de-dados",
    "ApiKey": {
      "Name": "chave-api-dados",
      "Value": "your-api-key-here"
    }
  }
}
```

### Key Configuration Options:

- **BaseUrl**: URL for the external transparency API.
- **ApiKey**: The API key used to authenticate requests to the transparency API.

---

## Setup & Installation

To get the **CidadaoConectado API** up and running locally:

1. Clone this repository:

   ```bash
   git clone https://github.com/your-username/CidadaoConectado.git
   cd CidadaoConectado
   ```

2. Install dependencies using `dotnet`:

   ```bash
   dotnet restore
   ```

3. Add your API key and configure the base URL in the `appsettings.json` file (see above).

4. Run the application:

   ```bash
   dotnet run
   ```

   The API will start and listen on `http://localhost:5131` by default.

---

## Swagger Support

In **development mode**, the API supports Swagger for easy exploration and testing of the endpoints.

- **Swagger UI**: Access the interactive Swagger UI at the following URL:

  ```
  http://localhost:5131/swagger
  ```

  Here you can test the `/resigns` endpoint and other available API endpoints, view request/response schemas, and interact with the API.

---

## Testing

To test the API endpoints, you can use tools like **Postman** or **curl**:

```bash
curl http://localhost:5131/api/v1/resigns
```

This will fetch the resignation values from the configured external source.

---

## Contributing

If you would like to contribute to the **CidadaoConectado** project, please feel free to fork the repository and submit a pull request with your proposed changes.

Make sure to follow best practices for API development, such as:

- Proper error handling
- Writing unit and integration tests
- Keeping code clean and well-documented

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Acknowledgements

- This project was developed as part of the **Cepedi ResTic 36 Hackathon**.
- The external API data is provided by the **Portal da Transparência** of the Brazilian government.
