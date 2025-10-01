using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.Extensions;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class IrvasService : IIrvasService
    {
        private readonly IDataLayer _dataLayer;

        public IrvasService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<IrvasDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<IrvasDTO>>.Failure("Nema konekcije sa bazom podataka");

                var result = session.Query<Irvas>()
                    .Select(i => i.ToIrvasDTO()).ToList();

                return ServiceResult<IList<IrvasDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<IrvasDTO>>.Failure($"Greska pri vracanju irvasa: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Add(IrvasDTO irvasDTO, Tovar tovar)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom!");

                var postojiIrvas = session.Query<Irvas>()
                    .Any(i => i.Jed_ime == irvasDTO.JedIme);
                if (postojiIrvas)
                    return ServiceResult<bool>.Failure("Irvas sa tim imenom vec postoji!");
                postojiIrvas = session.Query<Irvas>()
                    .Any(i => i.Nadimak == irvasDTO.Nadimak);
                if (postojiIrvas)
                    return ServiceResult<bool>.Failure("Irvas sa tim nadimkom vec postoji!");

                Irvas irvas = irvasDTO.CreateNewEntity(tovar);

                session.SaveOrUpdate(irvas);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju irvasa: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IList<IrvasDTO>> GetByTovar(int tovarId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<IrvasDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Irvas>()
                    .Where(i => i.Tovar.Id_tovar == tovarId)
                    .Select(i => i.ToIrvasDTO())
                    .ToList();

                return ServiceResult<IList<IrvasDTO>>.Success(result);
            }
            catch(Exception ex)
            {
                return ServiceResult<IList<IrvasDTO>>.Failure("Greska pri pribavljanju irvasa!");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IrvasDTO> GetByJedIme(string jedIme)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IrvasDTO>.Failure("Nema konekcije sa bazom podataka!");
                var irvas = session.Query<Irvas>()
                    .FirstOrDefault(i => i.Jed_ime == jedIme);

                if (irvas == null)
                    return ServiceResult<IrvasDTO>.Failure("Ne postoji irvas sa tim imenom!");
                return ServiceResult<IrvasDTO>.Success(irvas.ToIrvasDTO());
            }
            catch(Exception ex)
            {
                return ServiceResult<IrvasDTO>.Failure($"Greska pri pribavljanju irvasa: {ex.Message}");
            }
            finally { session?.Close(); }
        }

        public ServiceResult<IrvasDTO> GetByNadimak(string jedNadimak)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IrvasDTO>.Failure("Nema konekcije sa bazom podataka!");
                var irvas = session.Query<Irvas>()
                    .FirstOrDefault(i => i.Nadimak == jedNadimak);

                if (irvas == null)
                    return ServiceResult<IrvasDTO>.Failure("Ne postoji irvas sa tim nadimkom!");
                return ServiceResult<IrvasDTO>.Success(irvas.ToIrvasDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<IrvasDTO>.Failure($"Greska pri pribavljanju irvasa: {ex.Message}");
            }
            finally { session?.Close(); }
        }
    }
}
