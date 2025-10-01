using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;

namespace DedaMrazovaRadionica.App.Services.Interfaces
{
    public interface ITimVilenjakaService
    {
        ServiceResult<IList<TimVilenjakaDTO>> GetAll();
        ServiceResult<TimVilenjakaDTO> GetById(int id);
        ServiceResult<bool> Add(string naziv, string namena, int idRadnika);
        ServiceResult<bool> SetKoordinatora(TimVilenjakaDTO timVilenjakaDTO, int idRadnika);
        ServiceResult<bool> Delete(int timVilenjakaId);//brise se samo ako nema vise radnika u timu
        ServiceResult<TimVilenjakaDTO> GetByNaziv(string naziv);
        ServiceResult<IList<TimVilenjakaDTO>> GetByNamena(string namena);
        ServiceResult<int> GetNumberRadnika(TimVilenjakaDTO timVilenjakaDTO);
        ServiceResult<bool> DodeliPokloneTimu(TimVilenjakaDTO timVilenjakaDTO, IList<Poklon> pokloni);
        ServiceResult<bool> DodeliTovareTimu(TimVilenjakaDTO timVilenjakaDTO, IList<Tovar> tovari);
        //prikaz vilenjaka za neki tim - taj servis je kod RadnikService-a
    }
}
