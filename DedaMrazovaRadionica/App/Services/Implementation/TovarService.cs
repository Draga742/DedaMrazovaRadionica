using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.Extensions;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class TovarService : ITovarService
    {
        private readonly IDataLayer _dataLayer;

        public TovarService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<TovarDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<TovarDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Tovar>()
                    .Select(t => t.ToTovarDTO()).ToList();

                return ServiceResult<IList<TovarDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<TovarDTO>>.Failure($"Greska pri pribavljanju timova vilenjaka: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Add(TovarDTO tovarDTO)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                var postojiTovar = session.Query<Tovar>()
                    .Any(t => t.Sifra == tovarDTO.Sifra);

                if (postojiTovar)
                    return ServiceResult<bool>.Failure("Tovar sa ovom sifrom vec postoji!");

                else
                {
                    var tovar = tovarDTO.CreateNewEntity();

                    session.SaveOrUpdate(tovar);
                    session.Flush();

                    return ServiceResult<bool>.Success(true);
                }
            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju tovara: {ex.Message}");
            }
            finally { session?.Close(); }
        }

        public ServiceResult<bool> AsignTeam(TovarDTO tovarDTO, int timId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                TimVilenjaka tim = session.Load<TimVilenjaka>(timId);
                if (tim == null)
                    return ServiceResult<bool>.Failure("Tim sa datim ID-jem je postoji!");
                Tovar tovar = session.Load<Tovar>(tovarDTO.IdTovar);
                tovar.TimoviVilenjaka.Add(tim);

                session.SaveOrUpdate(tovar);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska prilikom dodele tima!: {ex.Message}");
            }
            finally { session?.Close(); }
        }


        public ServiceResult<TovarDTO> GetBySifra(string sifra)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<TovarDTO>.Failure("Nema konekcije sa bazom podataka!");

                var tovar = session.Query<Tovar>()
                    .FirstOrDefault(t => t.Sifra == sifra);

                if (tovar == null)
                    return ServiceResult<TovarDTO>.Failure("Ne postoji tovar sa datim ID-jem");
                return ServiceResult<TovarDTO>.Success(tovar.ToTovarDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<TovarDTO>.Failure($"Greska prilikom pribavljanja tovara: {ex.Message}");
            }
            finally
            { session?.Close(); }
        }

        public ServiceResult<IList<TovarDTO>> GetByGrad(string grad)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<TovarDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Tovar>()
                    .Where(t => t.Grad == grad)
                    .Select(t => t.ToTovarDTO())
                    .ToList();

                if (result == null || result.Count == 0)
                    return ServiceResult<IList<TovarDTO>>.Failure("Ne postoji tovar sa datim ID-jem");
                return ServiceResult<IList<TovarDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<TovarDTO>>.Failure($"Greska prilikom pribavljanja tovara: {ex.Message}");
            }
            finally
            { session?.Close(); }
        }
    }
}
