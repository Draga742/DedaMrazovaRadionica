using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Entities;

namespace DedaMrazovaRadionica.App.Services.Interfaces
{
    public interface IPismoService
    {
        ServiceResult<IList<PismoDTO>> GetAll();
        ServiceResult<bool> Add(PismoDTO pismoDTO, Dete dete);
        ServiceResult<bool> Delete(int pismoId);
        ServiceResult<bool> GetPismoPoDetetu(int deteId);
        ServiceResult<IList<PismoDTO>> GetPoslataOdDo(DateTime datumOd, DateTime datumDo);
        ServiceResult<IList<PismoDTO>> GetPrimljenaOdDo(DateTime datumOd, DateTime datumDo);
        //po indeksu dobrote za datu godinu:
        ServiceResult<IList<PismoDTO>> GetPoIndeksuDobrote(int indeksDobrote, int godina);
    }
}

