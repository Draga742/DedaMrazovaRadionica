using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.App.Extensions;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.Entities;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class PismoService : IPismoService
    {
        private readonly IDataLayer _dataLayer;

        public PismoService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public ServiceResult<IList<PismoDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<PismoDTO>>.Failure("Nema konekcije sa bazom podataka");

                var result = session.Query<Pismo>()
                    .Select(p => p.ToPismoDTO()).ToList();

                return ServiceResult<IList<PismoDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<PismoDTO>>.Failure($"Greska pri pribavljanju pisama: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        public ServiceResult<bool> Add(PismoDTO pismoDTO, Dete dete)
        {
            var session = _dataLayer.OpenSession();

            try 
            {
                if (session == null)
                {
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");
                }

                //ako postoji pismo za to dete, za tu godinu - ne moze se dodati novo pismo
                var existingPismo = session.Query<Pismo>()
                    .FirstOrDefault(p => p.Dete.Id_dete == dete.Id_dete && p.Datum_slanja.Year == DateTime.Now.Year);
                if (existingPismo != null)
                {
                    Pismo newPismo = pismoDTO.CreateNewEntity(dete);

                    session.SaveOrUpdate(newPismo);
                    session.Flush();

                    return ServiceResult<bool>.Success(true);
                }
                else
                {
                    return ServiceResult<bool>.Failure("Pismo za to dete za tekuću godinu već postoji.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju pisma: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        public ServiceResult<bool> Delete(int pismoId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka");

                var pismo = session.Get<Pismo>(pismoId);
                if(pismo == null)
                    return ServiceResult<bool>.Failure("Pismo nije pronadjeno");

                session.Delete(pismo);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju pisma: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        
        public ServiceResult<bool> GetPismoPoDetetu(int deteId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                var pismo = session.Query<Pismo>()
                    .FirstOrDefault(p => p.Dete.Id_dete == deteId);

                if (pismo == null)
                    return ServiceResult<bool>.Failure("Pismo nije pronadjeno!");

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri pribavljanju pisma deteta sa ID-jem {deteId} : {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IList<PismoDTO>> GetPoslataOdDo(DateTime datumOd, DateTime datumDo)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                        return ServiceResult<IList<PismoDTO>>.Failure("Nema konekcije sa bazom podataka");

                var result = session.Query<Pismo>()
                    .Where(p => p.Datum_slanja >= datumOd && p.Datum_slanja <= datumDo)
                    .Select(p => p.ToPismoDTO()).ToList();

                return ServiceResult<IList<PismoDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<PismoDTO>>.Failure($"Greska pri pribavljanju pisama poslatih od {datumOd} do {datumDo}: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        public ServiceResult<IList<PismoDTO>> GetPrimljenaOdDo(DateTime datumOd, DateTime datumDo)
        {
            var session = _dataLayer.OpenSession();

            try 
            {
                if(session == null)
                        return ServiceResult<IList<PismoDTO>>.Failure("Nema konekcije sa bazom podataka");

                var result = session.Query<Pismo>()
                    .Where(p => p.Datum_primanja != null && p.Datum_primanja >= datumOd && p.Datum_primanja <= datumDo)
                    .Select(p => p.ToPismoDTO()).ToList();

                return ServiceResult<IList<PismoDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<PismoDTO>>.Failure($"Greska pri pribavljanju pisama primljenih od {datumOd} do {datumDo}: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        public ServiceResult<IList<PismoDTO>> GetPoIndeksuDobrote(int indeksDobrote, int godina)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<PismoDTO>>.Failure("Nema konekcije sa bazom podataka");

                var result = session.Query<Pismo>()
                    .Where(p => p.Indeks_dobrote == indeksDobrote && p.Datum_slanja.Year == godina)
                    .Select(p => p.ToPismoDTO()).ToList();

                return ServiceResult<IList<PismoDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<PismoDTO>>.Failure($"Greska pri pribavljanju pisama sa indeksom dobrote {indeksDobrote}: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
    }
}
