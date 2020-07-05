# Microsserviços de aplicações financeiras

Prova de conceito que visa demonstrar como dois microsserviços podem interagir em um processo de cálculo de juros compostos.

## Insights

Para melhor explorar essa solução, é interessante que os itens abaixo lhe sejam familiares:

- .NET Core 3.1
- DDD
- TDD
- WebApi
- Flunt
- Moq
- Polly
- XUnit
- Swagger
- Docker

## Executando os serviços

### Com Docker

Para executar a aplicação basta executar o comando `docker-compose up -d` a partir da raíz do projeto.

Se for utilizada a instalação padrão do Docker, as APIs estarão disponíveis a partir dos seguintes endereços:
- Taxa de juros: `http://localhost:5000/`
- Cálculo de juros: `http://localhost:5002/`

Se for utilizado o Docker Toolbox, será necesário descobrir o IP da máquina Docker através do comando `docker-machine ip`. Após isso, utilize no lugar de `localhost` nos endereços acima listados para poder acessar as respectivas APIs.

### Sem Docker

Primeiramente, faça o download do kit de desenvolvimento (sdk) .NET Core 3.1 de acordo com a plataforma que planeja hospedar as APIs. Maiores detalhes podem ser encontrados em: https://dotnet.microsoft.com/download/dotnet-core/3.1

Após isso é necessário compilar e executar cada serviço. Pode ser feito a partir da pasta raíz desse projeto atrávés das seguintes linhas de comando:

#### Restaurar as dependências
```
dotnet restore .\taxaJuros\
dotnet restore .\calculaJuros\
```

#### Compilar as soluções
```
dotnet build .\taxaJuros\
dotnet build .\calculaJuros\
```

#### Executar cada solução
```
dotnet run -p .\taxaJuros\TaxaJuros.Api\
dotnet run -p .\calculaJuros\CalculaJuros.Api\
```

## Consultando a documentação

As duas APIs são autodocumentadas por meio do `Swagger`. Após serem iniciadas, é possível verificar suas respectivas documentações a partir da rota `/swagger` em cada uma delas.

`http://localhost:5000/swagger` => Documentação da API de taxa de juros

`http://localhost:5002/swagger` => Documentação da API de cálculo de juros
