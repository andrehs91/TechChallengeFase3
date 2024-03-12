-- DELETE FROM [Fase3].[Itens]
-- DELETE FROM [Fase3].[Pedidos]

-- -----------------------------------------------------------------------------

SELECT * FROM [Fase3].[Clientes]
SELECT * FROM [Fase3].[Itens]
SELECT * FROM [Fase3].[Pedidos]
SELECT * FROM [Fase3].[Produtos]

-- -----------------------------------------------------------------------------

INSERT INTO [Fase3].[Clientes]
    ([Nome], [Email])
VALUES
    ('André', 'andre@email.com'),
    ('Fábio', 'fabio@email.com'),
    ('Ângelo', 'angelo@email.com'),
    ('Ricardo', 'ricardo@email.com')

-- -----------------------------------------------------------------------------

INSERT INTO [Fase3].[Produtos]
    ([Nome], [Descricao], [Preco])
VALUES
    ('Produto A', 'Descrição do produto A.', 100),
    ('Produto B', 'Descrição do produto B.', 200),
    ('Produto C', 'Descrição do produto C.', 300),
    ('Produto D', 'Descrição do produto D.', 400),
    ('Produto E', 'Descrição do produto E.', 500),
    ('Produto F', 'Descrição do produto F.', 600)
