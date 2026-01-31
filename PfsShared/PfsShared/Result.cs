using PfsShared.Errors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PfsShared
{
    public sealed class Result<T>
    {
        private Result(T valor)
        {
            Valor = valor;
        }

        private Result(Error erro)
        {
            Erro = erro;
        }

        public T Valor { get; private set; }
        public Error Erro { get; }
        public bool PossuiErro => Erro != null;

        public static implicit operator Result<T>(T valor) => new(valor);
        public static implicit operator Result<T>(Error erro) => new(erro);

    }

    public sealed class Result
    {
        public static readonly Result Sucesso = new();

        private Result()
        { }

        public Result(Error erro)
        {
            Erro = erro;
        }

        public Error Erro { get; }

        public bool PossuiErro => Erro != null;

        public static implicit operator Result(Error erro) => new(erro);
    }

    public class Error 
    {
        public Error(string code, string message) 
        {
            Code = code;
            Message = message;
        }

        public string Code { get; set; }
        public string Message { get; set; }

        public static Error Excecao(Exception ex) =>
          new(CodigosErros.SYS_EXCEPTION, ex.Message);

        public static Error Validacao(string code,string message) => new(code,message);

    }
}
