using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Services
{
    public interface IService
    {
        public void ProvjeriClanarine(CancellationToken token);
    }
}
