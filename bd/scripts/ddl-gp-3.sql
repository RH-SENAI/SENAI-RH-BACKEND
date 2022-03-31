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
VALUES('Sé'),
	  ('Santa Cecília'),
	  ('Consolação')
GO

INSERT INTO LOGRADOURO(nomeLogradouro)
VALUES('Rua Assembléia'),
	  ('Rua Azevedo Marques'),
	  ('Rua Avaré')
GO

INSERT INTO CIDADE(nomeCidade)
VALUES('São Paulo')
GO

INSERT INTO ESTADO(nomeEstado)
VALUES('São Paulo')
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

