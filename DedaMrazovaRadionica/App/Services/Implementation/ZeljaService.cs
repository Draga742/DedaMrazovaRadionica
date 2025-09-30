using DedaMrazovaRadionica.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.Extensions;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class ZeljaService : IZeljaService
    {
        private readonly IDataLayer _dataLayer;
        public ZeljaService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<ZeljaDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<ZeljaDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Zelja>()
                    .Select(z => z.ToZeljaDTO()).ToList();

                return ServiceResult<IList<ZeljaDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<ZeljaDTO>>.Failure($"Greska pri pribavljanju zelja: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<ZeljaDTO> GetByIdListe(int id)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<ZeljaDTO>.Failure("Nema konekcije sa bazom podataka!");

                var zelja = session.Get<Zelja>(id);
                if(zelja == null)
                    return ServiceResult<ZeljaDTO>.Failure($"Zelja sa ID-jem {id} ne postoji!");

                return ServiceResult<ZeljaDTO>.Success(zelja.ToZeljaDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<ZeljaDTO>.Failure($"Greska pri pribavljanju zelje sa ID-jem {id} : {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Add(ZeljaDTO zeljaDTO, TipIgracke tip, ListaZelja lista)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                Zelja zelja = zeljaDTO.CreateNewEntity(tip, lista);

                session.SaveOrUpdate(zelja);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju zelje: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Delete(int zeljaId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                var zelja = session.Get<Zelja>(zeljaId);
                if(zelja == null)
                    return ServiceResult<bool>.Failure("Zelja sa datim ID-jem ne postoji!");

                session.Delete(zelja);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju zelje: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
    }
}
