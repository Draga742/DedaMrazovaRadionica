using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.Extensions;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.Data;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class IrvasarService : IIrvasarService
    {
        private readonly IDataLayer _dataLayer;

        public IrvasarService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<IrvasarDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<IrvasarDTO>>.Failure("Nema konekcije sa bazom podataka");

                var result = session.Query<Irvasar>()
                    .Select(i => i.ToIrvasarDTO()).ToList();

                return ServiceResult<IList<IrvasarDTO>>.Success(result); 
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<IrvasarDTO>>.Failure($"Greska pri pribavljanju irvasara: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IrvasarDTO> GetById(int id)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IrvasarDTO>.Failure("Nema konekcije sa bazom podataka!");

                var Irvasar = session.Load<Irvasar>(id);

                if (Irvasar == null)
                    return ServiceResult<IrvasarDTO>.Failure("Irvasar sa datim ID-jem ne postoji!");

                return ServiceResult<IrvasarDTO>.Success(Irvasar.ToIrvasarDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<IrvasarDTO>.Failure($"Greska pri pribavljanju irvasara: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Add(IrvasarDTO irvasarDTO, Irvas irvas)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka");

                var postojiIrvasar = session.Query<Irvas>()
                    .Any(i => i.Jed_ime == irvasarDTO.JedIme);
                if (postojiIrvasar)
                    return ServiceResult<bool>.Failure("Irvasar sa datim imenom vec postoji!");

                Irvasar newIrvasar = irvasarDTO.CreateNewEntity(irvas);

                session.SaveOrUpdate(newIrvasar);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju irvasara u bazu: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Delete(int irvasarId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka");

                var irvasar = session.Load<Irvasar>(irvasarId);
                if (irvasar == null)
                    return ServiceResult<bool>.Failure("Irvasar sa datim ID-jem ne postoji!");

                session.Delete(irvasar);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju irvasara: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IList<IrvasarDTO>> GetByIrvas(int irvasId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<IrvasarDTO>>.Failure("Nema konekcije sa bazom podataka");

                // treba da vrati sve irvasare koji brinu o irvasu sa idjem irvasId
                var result = session.Query<Irvasar>()
                    .Where(i => i.Irvas.Id_irvas == irvasId)
                    .Select(i => i.ToIrvasarDTO())
                    .ToList();

                return ServiceResult<IList<IrvasarDTO>>.Success(result);
            }
            catch(Exception ex)
            {
                return ServiceResult<IList<IrvasarDTO>>.Failure($"Greska pri pribavljanju irvasara koji brinu o irvasu: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

    }
}
