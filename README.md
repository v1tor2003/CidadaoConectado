# API CidadaoConectado

Essa API é projetada para fornecer recursos de transparência e participação para os cidadãos para o projeto CidadaoConectado. Este projeto faz parte do **Hackathon Cepedi ResTic 36** e tem como objetivo melhorar o acesso a dados públicos, permitindo que os cidadãos se mantenham informados e se engajem com ações governamentais.

A API agrega dados de portais externos de transparência governamental e os apresenta em um formato padronizado para fácil integração ao projeto **CidadaoConectado**, que busca aumentar o engajamento dos cidadãos nos processos de governança.

## Ideação e Implementação do Projeto:

### Integrantes da Equipe
- **Adrielle Maria Alves Queiroz**, amaqueiroz.cic@uesc.br
- **Ezequiel Lobo Oliveira**, eloliveira.cic@uesc.br
- **Flávia Alessandra Santos de Jesus**, developerflavia@gmail.com
- **Gustavo Aragão Oliveira**, gaoliveira.cic@uesc.br
- **Hênio Pedro Silva Santana**, hpssantana.cic@uesc.br
- **João Pedro Correia da Silva Noberto**, jpcsnoberto@gmail.com
- **Mateus Silva Lisboa**, mslisboa.cic@uesc.br
- **Pedro Affonso Silva Marques**, pedroaffonsosilvamarques@gmail.com
- **Solana Bomfim Lemos**, solana.ametista@gmail.com
- **Vitor Pires Rocha**, vitor.pr04@hotmail.com

## Funcionalidades

- **Agregação de Dados**: Coleta dados de APIs governamentais de transparência e os fornece aos usuários em formato estruturado.
- **Transparência Pública**: Facilita o acesso e entendimento dos dados do setor público pelos cidadãos.
- **Governança Participativa**: Permite que os cidadãos interajam com os dados e participem de discussões e decisões.
- **Swagger UI (Modo de Desenvolvimento)**: Fornece uma interface de documentação interativa via Swagger, permitindo que os desenvolvedores explorem e testem os endpoints da API facilmente.

---

## Endpoints

### Valores de Renúncia

- **GET /api/v1/resigns**
  - Recupera uma lista das renúncias do portal de transparência governamental.

### Exemplo de Resposta:

```json
[
  {
    "ano": 2023,
    "valorRenunciado": 1500000,
    "tipoRenuncia": "Fiscal",
    "descricaoBeneficioFiscal": "Isenção de imposto de renda",
    "descricaoFundamentoLegal": "Artigo 5, Lei 123/2017",
    "tributo": "Imposto de Renda",
    "formaTributacao": "Progressiva",
    "cnpj": "12.345.678/0001-90",
    "razaoSocial": "Empresa X Ltda.",
    "nomeFantasia": "Empresa X",
    "cnaeCodigoGrupo": "47",
    "cnaeCodigoClasse": "4741",
    "cnaeCodigoSubClasse": "4741200",
    "cnaeNomeClasse": "Comércio Varejista",
    "cnaeDivisao": "47",
    "uf": "SP",
    "municipio": "São Paulo",
    "codigoIBGE": "3550308"
  }
]
```

- **GET /api/v1/resigns/{id}**
  - Recupera uma renúncia do portal de transparência governamental.

### Exemplo de Resposta:

```json

{
  "ano": 2023,
  "valorRenunciado": 1500000,
  "tipoRenuncia": "Fiscal",
  "descricaoBeneficioFiscal": "Isenção de imposto de renda",
  "descricaoFundamentoLegal": "Artigo 5, Lei 123/2017",
  "tributo": "Imposto de Renda",
  "formaTributacao": "Progressiva",
  "cnpj": "12.345.678/0001-90",
  "razaoSocial": "Empresa X Ltda.",
  "nomeFantasia": "Empresa X",
  "cnaeCodigoGrupo": "47",
  "cnaeCodigoClasse": "4741",
  "cnaeCodigoSubClasse": "4741200",
  "cnaeNomeClasse": "Comércio Varejista",
  "cnaeDivisao": "47",
  "uf": "SP",
  "municipio": "São Paulo",
  "codigoIBGE": "3550308"
}

```

### Emendas Parlamentares

- **GET /api/v1/adments**
  - Recupera emendas parlamentares do portal de transparência governamental.

### Exemplo de Resposta:

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

- **GET /api/v1/adments/{id}**
  - Recupera uma emenda parlamentare do cache pelo seu id.

### Exemplo de Resposta:

```json

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

```

### Bolsa Família

- **GET /api/v1/family-scholarships/{ibgeCode}?yearMonth=AAAAMM**
  - Recupera dados de bolsas família de uma cidade específica a partir do portal de transparência governamental.

### Exemplo de Resposta:

```json

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

```

### Usuários

- **GET /api/v1/users**
  - Retorna uma lista de usuários cadastrados no sistema.

### Exemplo de Resposta:

```json
[
  {
    "id": "string",
    "name": "string",
    "email": "string",
    "avatar": "string"
  }
]
```

- **GET /api/v1/users/{id}**
  - Retorna um usuário pelo seu id.

### Exemplo de Resposta:

```json
{
  "id": "string",
  "name": "string",
  "email": "string",
  "avatar": "string"
}
```

- **POST /api/v1/users**
  - Registra novo usuário no sistema.

### Exemplo de Corpo da Requisição:

```json
{
  "id": "string",
  "name": "string",
  "email": "string",
  "avatar": "string"
}
```

### Posts

- **GET /api/v1/posts**
  - Retorna uma lista de posts realizados pelos usuários e seus detalhes.

### Exemplo de Resposta:

```json
[
  {
    "userId": "string",
    "title": "string",
    "desc": "string",
    "tags": "string",
    "pubDate": "string",
    "likesCount": 0
  }
]
```

- **GET /api/v1/posts/{id}**
  - Retorna um post pelo seu id.

### Exemplo de Resposta:

```json
{
  "userId": "string",
  "title": "string",
  "desc": "string",
  "tags": "string",
  "postImage":"string",
  "pubDate": "string",
  "likes": []
}

```

- **POST /api/v1/posts**
  - Cria um novo post no sistema.

### Exemplo de Corpo da Requisição:

```json
{
  "userId": "string",
  "title": "string",
  "desc": "string",
  "tags": "string",
  "image": "string"
}
```

- **PATCH /api/v1/posts/{id}/likes**
  - Relaciona like e seus detalhes ao post.

### Exemplo de Corpo da Requisição:

```json
{
  "userId": "string"
}
```

- **DELETE /api/v1/posts/{id}/likes/{likeId}**
  - Desrelaciona o like e seus detalhes ao post.


### Endpoint de uploads:

- **GET /api/v1/uploads/{fileName}**
  - Retorna imagens enviadas previamente a api pelo seu nome.
---

## Configuração e Instalação

Para rodar a **API CidadaoConectado** localmente:

1. Clone este repositório:

   ```bash
   git clone https://github.com/seu-usuario/CidadaoConectado.git
   cd CidadaoConectado
   ```

2. Instale as dependências usando `dotnet`:

   ```bash
   dotnet restore
   ```

3. Adicione sua chave de API e configure a URL base no arquivo `appsettings.json` (veja acima).

4. Execute a aplicação:

   ```bash
   dotnet run
   ```

   A API será iniciada e ficará disponível em `http://localhost:5131` por padrão.

---

## Suporte a Swagger

No **modo de desenvolvimento**, a API oferece suporte ao Swagger para fácil exploração e testes dos endpoints.

- **Swagger UI**: Acesse a interface interativa do Swagger no seguinte endereço:

  ```
  http://localhost:5131/swagger
  ```

  Aqui você pode testar o endpoint `/resigns` e outros disponíveis, visualizar esquemas de requisição/resposta e interagir com a API.

---

## Testes

Para testar os endpoints da API, você pode usar ferramentas como **Postman** ou **curl**:

```bash
curl http://localhost:5131/api/v1/resigns
```

Isso retornará os valores de renúncia do recurso externo configurado.

---

## Contribuição

Se desejar contribuir para o projeto **CidadaoConectado**, sinta-se à vontade para fazer um fork do repositório e enviar um pull request com suas mudanças propostas.

Certifique-se de seguir as melhores práticas de desenvolvimento de APIs, como:

- Tratamento adequado de erros
- Escrita de testes unitários e de integração
- Manter o código limpo e bem documentado

---

## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## Agradecimentos

- Este projeto foi desenvolvido como parte do **Hackathon Cepedi ResTic 36**.
- Os dados da API externa são fornecidos pelo **Portal da Transparência** do governo brasileiro.
