using DedaMrazovaRadionica.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.Services.Interfaces
{
    public interface IDeteService
    {
        ServiceResult<IList<DeteDTO>> GetAll();
        ServiceResult<bool> Add(DeteDTO deteDTO);
        ServiceResult<bool> Delete(int deteId);
        ServiceResult<bool> Update(DeteDTO deteDTO);
        ServiceResult<IList<DeteDTO>> GetByImeIPrezime(string ime, string prezime);
    }
}
