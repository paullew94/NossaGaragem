CREATE TABLE categorias(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR (100)
);

CREATE TABLE veiculos(
id INT PRIMARY KEY IDENTITY(1,1),
id_categoria INT,
FOREIGN KEY (id_categoria) REFERENCES categorias (id),

modelo VARCHAR(200),
valor DECIMAL(8,2)
);
SELECT
veiculos.id AS'VeiculoId',
veiculos.modelo AS'VeiculoModelo',
veiculos.id_categoria AS 'VeiculoIdCategoria',
veiculos.valor AS'VeiculoValor',
categorias.nome AS'CategriaNome'
FROM veiculos
INNER JOIN categorias ON(veiculos.id_categoria=categorias.id)