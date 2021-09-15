using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CicloDeVidaIDController : ControllerBase
    {
        public readonly ISingleton _singleton1;
        public readonly ISingleton _singleton2;

        public readonly IScoped _scoped1;
        public readonly IScoped _scoped2;

        public readonly ITransient _transient1;
        public readonly ITransient _transient2;

        public CicloDeVidaIDController(ISingleton singleton1,
                                       ISingleton singleton2,
                                       IScoped scoped1,
                                       IScoped scoped2,
                                       ITransient transient1,
                                       ITransient transient2)
        {
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_singleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_singleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_scoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_scoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_transient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_transient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IGeral
    {
        public Guid Id { get; }
    }

    public interface ISingleton :IGeral
    { }

    public interface IScoped : IGeral
    { }

    public interface ITransient : IGeral
    { }

    public class CicloDeVida : ISingleton, IScoped, ITransient
    {
        private readonly Guid _guid;

        public CicloDeVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }

}
