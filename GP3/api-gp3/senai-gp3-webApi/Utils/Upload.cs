using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Utils
{
    public static class Upload
    {

        //Classe que nos possibilita pegar atributos do appsettings json
        public static IConfiguration _configuration { get; set; }

        /// <summary>
        /// Faz o upload do arquivo para o blob
        /// </summary>
        /// <param name="arquivo">Arquivo vindo de um formulário</param>
        /// <param name="extensoesPermitidas">Array com extensões permitidas apenas</param>
        /// <returns>Nome do arquivo salvo</returns>
        public static async Task<string> UploadFile(IFormFile arquivo, string[] extensoesPermitidas)
        {

            try
            {
                //String de conexão que recebemos do serviço no da AZURE
                var string_de_conexao = _configuration["ConnectionStrings:AzureConnectionString"];

                //Nome do container em que o blob está inserido
                var blob_container_name = _configuration["AzureStorageConfig:BlobContainerName"];

                // Permite que consigamos manipular um container
                BlobContainerClient blobContainerClient = new BlobContainerClient(string_de_conexao, blob_container_name);

                if (arquivo.Length > 0)
                {
                    //Pega a nome do IFormFile
                    var fileName = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');


                    //Valida a estensão 
                    if (ValidarExtensao(extensoesPermitidas, fileName))
                    {
                        var extensao = RetornarExtensao(fileName);

                        //Atribui um novo idenfificador baseado no nome do IFormFile + extensão
                        var novoNome = $"{Guid.NewGuid()}.{extensao}";

                        //Permite que consigamos manipular um blob
                        BlobClient blobClient = blobContainerClient.GetBlobClient(novoNome);

                        //Cria um novo block blob (arquivo)
                        await blobClient.UploadAsync(arquivo.OpenReadStream());

                        return novoNome;
                    }
                    return "Extensão não permitida";
                }
                return "";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        /// <summary>
        /// Valida o uso de enxtensões permitidas apenas
        /// </summary>
        /// <param name="extensoes">Array de extensões permitidas</param>
        /// <param name="nomeDoArquivo">Nome do arquivo</param>
        /// <returns>Verdadeiro/Falso</returns>
        public static bool ValidarExtensao(string[] extensoes, string nomeDoArquivo)
        {
            string[] dados = nomeDoArquivo.Split(".");
            string extensao = dados[dados.Length - 1];

            foreach (var item in extensoes)
            {
                if (extensao == item)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove um arquivo do servidor
        /// </summary>
        /// <param name="nomeDoArquivo">Nome do Arquivo</param>
        public static void RemoverArquivo(string nomeDoArquivo)
        {
            var pasta = Path.Combine("StaticFile", "Images");
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), pasta);
            var caminhoCompleto = Path.Combine(caminho, nomeDoArquivo);

            File.Delete(caminhoCompleto);
        }

        /// <summary>
        /// Retorna a extensão de um arquivo
        /// </summary>
        /// <param name="nomeDoArquivo">Nome do Arquivo</param>
        /// <returns>Retorna a extensão de um arquivo</returns>
        public static string RetornarExtensao(string nomeDoArquivo)
        {
            string[] dados = nomeDoArquivo.Split('.');
            return dados[dados.Length - 1];
        }
    }
}
