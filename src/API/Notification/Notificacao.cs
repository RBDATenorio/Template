using Domain.Interfaces;

namespace API.Notification
{
    /* O padrão de notificações permite que possamos acumular erros de validações
     * e enviar na resposta da requisição uma lista de erros. Por que não usar
     * exceções? Bem, aí você estaria interrompendo a thread toda vez que encontrasse
     * um erro e pensando na experiência do usuário não seria melhor que ele 
     * soubesse de uma vez tudo o que precisa corrigir?
     */
    public class Notificacao : INotificacao
    {
        private readonly IList<string> Erros;

        public Notificacao()
        {
            Erros = new List<string>();
        }
        public void Notificar(string mensagem)
        {
            Erros.Add(mensagem);
        }

        public IList<string> ObterNotificacoes()
        {
            return Erros;
        }

        public bool TemNotificacoes()
        {
            return Erros.Any();
        }
    }
}
