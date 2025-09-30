using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.Extensions;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class ListaZeljaService : IListaZeljaService
    {
        private readonly IDataLayer _dataLayer;

        public ListaZeljaService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<ListaZeljaDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<ListaZeljaDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<ListaZelja>()
                    .Select(lz => lz.ToListaZeljaDTO()).ToList();

                return ServiceResult<IList<ListaZeljaDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<ListaZeljaDTO>>.Failure($"Greska pri pribavljanju lista zelja: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<ListaZeljaDTO> GetById(int id)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<ListaZeljaDTO>.Failure("Nema konekcije sa bazom podataka!");

                var listaZelja = session.Get<ListaZelja>(id);

                if(listaZelja == null)
                    return ServiceResult<ListaZeljaDTO>.Failure("Lista zelja sa datim ID-jem ne postoji!");
                return ServiceResult<ListaZeljaDTO>.Success(listaZelja.ToListaZeljaDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<ListaZeljaDTO>.Failure($"Greska pri pribavljanju liste zelja: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Add(ListaZeljaDTO listaZeljaDTO, Pismo pismo, IList<Zelja> zelje)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                ListaZelja newLista = listaZeljaDTO.CreateNewEntity(pismo, zelje);

                session.SaveOrUpdate(newLista);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju liste zelja: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        public ServiceResult<bool> Delete(int listaZeljaId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                var listaZelja = session.Get<ListaZelja>(listaZeljaId);
                if (listaZelja == null)
                {
                    return ServiceResult<bool>.Failure("Lista zelja sa datim ID-jem ne postoji!");
                }

                session.Delete(listaZelja);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju liste zelja: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
       
        
    }
}
