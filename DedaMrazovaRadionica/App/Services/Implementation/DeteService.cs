using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using DedaMrazovaRadionica.App.Extensions;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class DeteService : IDeteService
    {
        private readonly IDataLayer _dataLayer;

        public DeteService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<DeteDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                {
                    return ServiceResult<IList<DeteDTO>>.Failure("Nema konekcije sa bazom podataka!");
                }

                var result = session.Query<Dete>()
                    .Select(d => d.ToDeteDTO()).ToList();

                return ServiceResult<IList<DeteDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<DeteDTO>>.Failure($"Greska pri pribavljanju dece: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Add(DeteDTO deteDTO)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                {
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");
                }

                Dete newDete = deteDTO.CreateNewEntity();

                session.SaveOrUpdate(newDete);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju deteta: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Delete(int deteId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                {
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");
                }

                var dete = session.Load<Dete>(deteId);
                if(dete == null)
                {
                    return ServiceResult<bool>.Failure("Dete sa datim ID-jem ne postoji!");
                }

                session.Delete(dete);
                session.Flush();

                return ServiceResult<bool>.Success(true);

            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju deteta: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Update(DeteDTO deteDTO)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                {
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");
                }

                if(deteDTO == null)
                {
                    return ServiceResult<bool>.Failure("Dete ne sme biti null!");
                }

                //pribavljamo dete prema id-u
                Dete oldDete = session.Load<Dete>(deteDTO.IdDete);

                //azuriramo property-je:
                oldDete.Ime = deteDTO.Ime;
                oldDete.Prezime = deteDTO.Prezime;
                //datum rodjenja ne moze da se menja
                oldDete.Drzava = deteDTO.Drzava;
                oldDete.Grad = deteDTO.Grad;
                oldDete.Ulica = deteDTO.Ulica;
                oldDete.Broj = deteDTO.Broj;
                //ime oca i ime majke ne mogu da se menjaju isto

                session.Update(oldDete);
                session.Flush();

                return ServiceResult<bool>.Success(true);   
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri azuriranja deteta: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IList<DeteDTO>> GetByImeIPrezime(string ime, string prezime)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<IList<DeteDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var query = session.Query<Dete>().AsQueryable();

                // ako je ime prosledjeno (nije null/prazno), filtriraj po imenu
                if (!string.IsNullOrWhiteSpace(ime))
                    query = query.Where(d => d.Ime.Contains(ime));

                // ako je prezime prosledjeno (nije null/prazno), filtriraj po prezimenu
                if (!string.IsNullOrWhiteSpace(prezime))
                    query = query.Where(d => d.Prezime.Contains(prezime));

                var result = query
                    .Select(d => d.ToDeteDTO())
                    .ToList();

                return ServiceResult<IList<DeteDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<DeteDTO>>.Failure($"Greska pri pribavljanju dece: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
    }
}
