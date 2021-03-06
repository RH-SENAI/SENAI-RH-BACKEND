CREATE DATABASE SENAI_RH;
GO

USE SENAI_RH;
GO

--TIPO USUARIO
CREATE TABLE TIPOUSUARIO(
idTipoUsuario TINYINT PRIMARY KEY IDENTITY NOT NULL,
nomeTipoUsuario VARCHAR(256) UNIQUE NOT NULL
);
GO

--CEP
CREATE TABLE CEP (
idCep INT PRIMARY KEY IDENTITY NOT NULL,
cep CHAR(8) UNIQUE NOT NULL
);
GO

--BAIRRO
CREATE TABLE BAIRRO (
idBairro INT PRIMARY KEY IDENTITY NOT NULL,
nomeBairro VARCHAR(256) UNIQUE NOT NULL
);
GO

--LOGRADOURO
CREATE TABLE LOGRADOURO(
idLogradouro INT PRIMARY KEY IDENTITY NOT NULL,
nomeLogradouro VARCHAR(256) UNIQUE NOT NULL
);
GO

--CIDADE
CREATE TABLE CIDADE(
idCidade TINYINT PRIMARY KEY IDENTITY NOT NULL,
nomeCidade VARCHAR(256) UNIQUE NOT NULL
);
GO

--ESTADO
CREATE TABLE ESTADO(
idEstado TINYINT PRIMARY KEY IDENTITY NOT NULL,
nomeEstado VARCHAR(256) UNIQUE NOT NULL
);
GO

--LOCALIZACAO
CREATE TABLE LOCALIZACAO(
idLocalizacao INT PRIMARY KEY IDENTITY NOT NULL,
idCep INT FOREIGN KEY REFERENCES CEP(idCep) NOT NULL,
idBairro INT FOREIGN KEY REFERENCES BAIRRO(idBairro) NOT NULL,
idLogradouro INT FOREIGN KEY REFERENCES LOGRADOURO(idLogradouro) NOT NULL,
idCidade TINYINT FOREIGN KEY REFERENCES CIDADE(idCidade) NOT NULL,
idEstado TINYINT FOREIGN KEY REFERENCES ESTADO(idEstado) NOT NULL,
numero VARCHAR(100) NOT NULL
);
GO

--UNIDADE SENAI
CREATE TABLE UNIDADESENAI(
idUnidadeSenai INT PRIMARY KEY IDENTITY NOT NULL,
idLocalizacao INT FOREIGN KEY REFERENCES LOCALIZACAO(idLocalizacao),
nomeUnidadeSenai VARCHAR(256) UNIQUE NOT NULL,
mediaAvaliacaoUnidadeSenai DECIMAL(2,1) NOT NULL,
mediaSatisfacaoUnidadeSenai DECIMAL(2,1) NOT NULL,
telefoneUnidadeSenai VARCHAR(13) UNIQUE NOT NULL,
emailUnidadeSenai VARCHAR(256) UNIQUE NOT NULL
);
GO

--SETOR
CREATE TABLE SETOR(
idSetor TINYINT PRIMARY KEY IDENTITY NOT NULL,
nomeSetor VARCHAR(256) UNIQUE NOT NULL
);
GO

--CARGO
CREATE TABLE CARGO(
idCargo TINYINT PRIMARY KEY IDENTITY NOT NULL,
idSetor TINYINT FOREIGN KEY REFERENCES SETOR(idSetor) NOT NULL,
nomeCargo VARCHAR(256) NOT NULL,
cargaHoraria TINYINT NOT NULL
);
GO

--USUARIO
CREATE TABLE USUARIO(
idUsuario INT PRIMARY KEY IDENTITY NOT NULL,
idCargo TINYINT FOREIGN KEY REFERENCES CARGO(idCargo) NOT NULL,
idUnidadeSenai INT FOREIGN KEY REFERENCES UNIDADESENAI(idUnidadeSenai) NOT NULL,
idTipoUsuario TINYINT FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario) NOT NULL,
nome VARCHAR(50) NOT NULL,
email VARCHAR(256) UNIQUE NOT NULL,
senha VARCHAR(62) NOT NULL,
dataNascimento DATE NOT NULL,
vantagens SMALLINT NOT NULL,
nivelSatisfacao DECIMAL(2,1) NOT NULL,
cpf CHAR(11) UNIQUE NOT NULL,
saldoMoeda INT NOT NULL,
trofeus INT NOT NULL,
localizacaoUsuario VARCHAR(256) NOT NULL,
caminhoFotoPerfil VARCHAR(256) UNIQUE NOT NULL,
salario MONEY NOT NULL
);
GO

--ATIVIDADE
CREATE TABLE ATIVIDADE(
idAtividade INT PRIMARY KEY IDENTITY NOT NULL,
nomeAtividade VARCHAR(256) NOT NULL,
dataInicio DATE NOT NULL,
dataConclusao DATE NOT NULL,
recompensaMoeda INT NOT NULL,
recompensaTrofeu INT NOT NULL,
descricaoAtividade VARCHAR(256) NOT NULL,
necessarioValidar BIT NOT NULL
);
GO

--SITUACAO ATIVIDADE
CREATE TABLE SITUACAOATIVIDADE(
idSituacaoAtividade TINYINT PRIMARY KEY IDENTITY NOT NULL,
nomeSituacaoAtividade VARCHAR(256) NOT NULL
);
GO

--MINHAS ATIVIDADES
CREATE TABLE MINHASATIVIDADES (
idMinhasAtividades INT PRIMARY KEY IDENTITY NOT NULL,
idSituacaoAtividade TINYINT FOREIGN KEY REFERENCES SITUACAOATIVIDADE(idSituacaoAtividade) NOT NULL,
idAtividade INT FOREIGN KEY REFERENCES ATIVIDADE(idAtividade) NOT NULL,
idSetor TINYINT FOREIGN KEY REFERENCES SETOR(idSetor) NOT NULL,
idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario) NOT NULL
);
GO

--DECISAO
CREATE TABLE DECISAO(
idDecisao INT PRIMARY KEY IDENTITY NOT NULL,
idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario) NOT NULL,
descricaoDecisao VARCHAR(300) NOT NULL,
dataDecisao DATE NOT NULL,
prazoDeAvaliacao DATE NOT NULL,
resultadoDecisao DECIMAL(2,1) NOT NULL
);
GO

--FEEDBACK
CREATE TABLE FEEDBACK(
idFeedBack INT PRIMARY KEY IDENTITY NOT NULL,
idDecisao INT FOREIGN KEY REFERENCES DECISAO(idDecisao) NOT NULL,
idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario) NOT NULL,
comentarioFeedBack VARCHAR(256) NOT NULL,
notaDecisao DECIMAL(2,1) NOT NULL,
dataPublicacao DATE NOT NULL,
valorMoedas INT NOT NULL
);
GO

--AVALIACAO USUARIO
CREATE TABLE AVALIACAOUSUARIO (
idAvaliacaoUsuario INT PRIMARY KEY IDENTITY NOT NULL,
idUsuarioAvaliado INT FOREIGN KEY REFERENCES USUARIO(idUsuario) NOT NULL,
idUsuarioAvaliador INT FOREIGN KEY REFERENCES USUARIO(idUsuario) NOT NULL,
avaliacaoUsuario VARCHAR(256) NOT NULL,
valorMoedas INT NOT NULL 
);
GO

--EMPRESA
CREATE TABLE EMPRESA(
idEmpresa INT PRIMARY KEY IDENTITY NOT NULL,
idLocalizacao INT FOREIGN KEY REFERENCES LOCALIZACAO(idLocalizacao) NOT NULL,
nomeEmpresa VARCHAR(256) NOT NULL,
emailEmpresa VARCHAR(256) UNIQUE NOT NULL,
telefoneEmpresa VARCHAR(13) UNIQUE NOT NULL,
caminhoImagemEmpresa VARCHAR(256) NOT NULL,
);
GO

--CURSO
CREATE TABLE CURSO(
idCurso INT PRIMARY KEY IDENTITY NOT NULL, 
idEmpresa INT FOREIGN KEY REFERENCES EMPRESA(idEmpresa) NOT NULL,
nomeCurso VARCHAR(256) NOT NULL,
descricaoCurso VARCHAR(256) NOT NULL,
siteCurso VARCHAR(256) NOT NULL,
modalidadeCurso BIT NOT NULL,
caminhoImagemCurso VARCHAR(256) NOT NULL,
cargaHoraria INT NOT NULL,
dataFinalizacao DATE NOT NULL,
mediaAvaliacaoCurso DECIMAL(2,1) NOT NULL
);
GO

--DESCONTO
CREATE TABLE DESCONTO(
idDesconto INT PRIMARY KEY IDENTITY NOT NULL, 
idEmpresa INT FOREIGN KEY REFERENCES EMPRESA(idEmpresa) NOT NULL,
nomeDesconto VARCHAR(256) NOT NULL,
descricaoDesconto VARCHAR(256) NOT NULL,
caminhoImagemDesconto VARCHAR(256) NOT NULL,
validadeDesconto DATE NOT NULL,
valorDesconto INT NOT NULL,
numeroCupom VARCHAR(20) NOT NULL,
mediaAvaliacaoDesconto DECIMAL(2,1) NOT NULL
);
GO
