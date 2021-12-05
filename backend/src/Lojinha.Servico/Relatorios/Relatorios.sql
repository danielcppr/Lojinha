-- Clientes que realizaram compras

SELECT A.ClienteId, A.Cpf, A.Nome
FROM Clientes A
JOIN Vendas B
on B.ClienteId = A.ClienteId

-- Vendas Realizadas em período selecionado;

DECLARE @dataInicial DATETIME,
		@dataFinal DATETIME

SET @dataInicial = 2021-01-01
SET @dataFinal = 2021-12-30

SELECT A.VendaId, A.Data, A.ClienteId, A.FuncionarioMatricula, A.FormaPagamento
FROM Vendas A
WHERE A.Data BETWEEN @dataInicial AND @dataFinal

-- Produtos abaixo do estoque mínimo

SELECT A.Codigo, A.Nome, A.Descricao, A.EstoqueMinimo, A.QtdEstoque, A.Valor, A.Validade
FROM Produtos A
WHERE A.EstoqueMinimo < A.QtdEstoque

-- Produtos fora da data de validade

SELECT A.Codigo, A.Nome, A.Descricao, A.EstoqueMinimo, A.QtdEstoque, A.Valor, A.Validade
FROM Produtos A
WHERE A.Validade < getdate()