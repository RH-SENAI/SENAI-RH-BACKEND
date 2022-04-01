using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    interface IFeedbackRepository
    {
        List<Feedback> ListarFb();

        Feedback ListarFbPorId(int idFeedback);

        void AtualizarFb(int idFeedback, Feedback feedbackAtualizado);

        void CadastrarFb(Feedback novoFeedback);

        void DeletarFb(int idFeedback);

        Feedback VerificarFeedback(Feedback feedback);
        //Atribui os parametros de entrada em um Feedback
        void AvaliarDecisao(int idDecisaoAvaliada, decimal notaDecisao);

        //Recebe todos os feedbacks para calcular e devolver a media (Decisao ResultadoDecisao)
        decimal CalcularMediaFb(List<Feedback> todosFeedbacks);

    }
}
