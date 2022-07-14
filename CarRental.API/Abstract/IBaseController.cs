using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.API.Abstract
{
    public interface IBaseController<T, TCreateDto>
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int Id);
        Task<IActionResult> Create(TCreateDto _object);
        Task<IActionResult> Update(T _object);
        Task<IActionResult> Delete(int Id);
    }
}
