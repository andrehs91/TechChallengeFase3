# FIAP - Tech Challenge (Fase 3)

Este repositório contêm o projeto desenvolvido para o Tech Challenge da terceira fase do curso **Arquitetura de Sistemas .NET com Azure**, desenvolvido pelos alunos:

- André Henrique dos Santos (RM351909)
- Angelo Ferreira Marques de Brito (RM350884)
- Fábio da Silva Duarte (RM352259)
- Ricardo Modesto dos Santos (RM352150)

### Estrutura do Projeto
A solução consiste em:
- Um **producer** (ASP.NET Core Web API) contendo uma interface Swagger para envio dos pedidos para processamento. Ele também possui *endpoints* para consulta aos clientes, aos produtos e aos pedidos;
- Um **broker** (RabbitMQ) para comunicação assíncrona entre os serviços;
- Um **consumer** (Worker Service) para processamento dos pedidos;
- Um **banco de dados** (SQL Server) para persistência dos dados.

### Regras de Negócio
O **producer** verifica apenas a quantidade de produtos cadastrados no pedido. Pedidos sem produtos ou com produtos cadastrados com a quantidade zero não serão aceitos.
A validação da existência do cliente e do(s) produto(s) é feita pelo **consumer**. Caso uma destas validações indique um problema, o pedido processado é enviado para uma das seguintes filas: "erro.clientenaoencontrado" ou "erro.produtonaoencontrado".
Caso o pedido atenda as regras definidas, ele é cadastrado no banco de dados.

### Como Executar este Projeto Localmente
> :warning: **Atenção:** A configuração padrão do projeto utiliza o banco de dados <u>SQL Server Express LocalDB</u>.
- (Opcional) Alterar a *Connection String* nos arquivos “appsettings.json” > “ConnectionStrings” > “SQLServer” de ambos os projetos (FIAP.Consumer e FIAP.Producer);
- Aplicar as *migrations*: ``` Update-Database -Project FIAP.Core -StartupProject FIAP.Consumer ```;
- Executar o script SQL “CargaDeDados.sql” no banco de dados “TechChallenge”;
- Inicializar um container do RabbitMQ: ``` docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management ```.
- Executar o projeto **FIAP.Consumer**;
- Executar o projeto **FIAP.Producer**;
> :heavy_exclamation_mark: O projeto possui suporte para Docker, mas localmente prefira executar de forma tradicional a fim de evitar mais configurações. Os arquivos Dockerfile estão preparados para o pipeline de CI/CD definido pelo arquivo *azure-pipelines.yml*.
