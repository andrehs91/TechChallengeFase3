SELECT * FROM [TechChallenge].[Fase3].[Clientes]
SELECT * FROM [TechChallenge].[Fase3].[Itens]
SELECT * FROM [TechChallenge].[Fase3].[Pedidos]
SELECT * FROM [TechChallenge].[Fase3].[Produtos]

-- -----------------------------------------------------------------------------

INSERT INTO [TechChallenge].[Fase3].[Clientes]
    ([Nome], [Email])
VALUES
    ('André', 'andre@email.com'),
    ('Fábio', 'fabio@email.com'),
    ('Angelo', 'angelo@email.com'),
    ('Ricardo', 'ricardo@email.com')

-- -----------------------------------------------------------------------------

INSERT INTO [TechChallenge].[Fase3].[Produtos]
    ([Nome], [Descricao], [Preco])
VALUES
    ('Produto A', 'Lorem ipsum dolor sit amet consectetur adipisicing elit.', 100),
    ('Produto B', 'Lorem ipsum dolor sit amet consectetur adipisicing elit.', 200),
    ('Produto C', 'Lorem ipsum dolor sit amet consectetur adipisicing elit.', 300),
    ('Produto D', 'Lorem ipsum dolor sit amet consectetur adipisicing elit.', 400),
    ('Produto E', 'Lorem ipsum dolor sit amet consectetur adipisicing elit.', 500),
    ('Produto F', 'Lorem ipsum dolor sit amet consectetur adipisicing elit.', 600)
