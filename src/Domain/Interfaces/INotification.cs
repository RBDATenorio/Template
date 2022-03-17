namespace Domain.Interfaces
{
    public interface INotificacao
    {
        void Notificar(string mensagem);
        bool TemNotificacoes();
        IList<string> ObterNotificacoes();
    }
}
