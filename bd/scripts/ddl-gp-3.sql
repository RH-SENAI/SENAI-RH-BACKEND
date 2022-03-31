USE SENAI_RH;
GO

INSERT INTO	SETOR(nomeSetor)
VALUES('Administrativo'),
	  ('RH'),
	  ('Comercial')
GO

INSERT INTO CARGO(idSetor,nomeCargo,cargaHoraria)
VALUES (1, 'Analista Administrativo', 8),
	   (2, 'Gerente de RH', 8),
	   (3,'Vendedor', 6)

INSERT INTO CEP(cep)
VALUES('01320050'),
	  ('01230030'),
	  ('01243030')

INSERT INTO BAIRRO(nomeBairro)
VALUES('S�'),
	  ('Santa Cec�lia'),
	  ('Consola��o')
GO

INSERT INTO LOGRADOURO(nomeLogradouro)
VALUES('Rua Assembl�ia'),
	  ('Rua Azevedo Marques'),
	  ('Rua Avar�')
GO

INSERT INTO CIDADE(nomeCidade)
VALUES('S�o Paulo')
GO

INSERT INTO ESTADO(nomeEstado)
VALUES('S�o Paulo')
GO

SELECT * FROM CEP
SELECT * FROM ESTADO 
SELECT * FROM LOGRADOURO
SELECT * FROM BAIRRO
SELECT * FROM CIDADE
SELECT * FROM ESTADO



INSERT INTO LOCALIZACAO(idCep, idEstado, idCidade, idBairro, idLogradouro, numero )
VALUES(8,1,1,1, 256),
	  (8,1,1,1, 67)

