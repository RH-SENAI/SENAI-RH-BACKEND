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
VALUES('02977000'),
	  ('01202000'),
	  ('01202901')