using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.Extensions;
using DedaMrazovaRadionica.Data;
using System.Diagnostics.Eventing.Reader;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class RadnikService : IRadnikService
    {
        private readonly IDataLayer _dataLayer;

        public RadnikService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<RadnikDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession(); 

            try
            {
                if (session == null)
                    return ServiceResult<IList<RadnikDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Radnik>()
                    .Select(r => r.ToRadnikDTO()).ToList();

                return ServiceResult<IList<RadnikDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<RadnikDTO>>.Failure($"Greska pri pribavljanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<RadnikDTO> GetById(int id)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<RadnikDTO>.Failure("Nema konekcije sa bazom podataka!");
                
                var radnik = session.Get<Radnik>(id);
                if (radnik == null)
                    return ServiceResult<RadnikDTO>.Failure("Radnik sa datim ID-jem ne postoji!");
                
                return ServiceResult<RadnikDTO>.Success(radnik.ToRadnikDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<RadnikDTO>.Failure($"Greska pri pribavljanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
            
        public ServiceResult<bool> Add(RadnikDTO radnikDTO, TimVilenjaka tim, Mentor mentor, DeoRadionice radionica)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                //ako postoji radnik sa tim imenom ne moze da se doda novi

                var postojiRadnik = session.Query<Radnik>()
                           .Any(r => r.Jed_ime == radnikDTO.JedIme);
                if (postojiRadnik)
                    return ServiceResult<bool>.Failure("Radnik sa tim imenom vec postoji!");
                else 
                {
                    var radnik = new Radnik
                    {
                        Jed_ime = radnikDTO.JedIme,
                        Zemlja_porekla = radnikDTO.ZemljaPorekla,
                        Datum_zaposlenja = radnikDTO.DatumZaposlenja,
                        Koordinator_flag = 0,
                        Tip_m_specijalizacije = radnikDTO.TipMSpecijalizacije,
                        Duzina_obuke = radnikDTO.DuzinaObuke,
                        Krajnja_ocena = radnikDTO.KrajnjaOcena,
                        Tim_Vilenjaka = tim,
                        Mentor = mentor,
                        Deo_Radionice = radionica
                    };
                    
                    session.SaveOrUpdate(radnik);
                    session.Flush();
                    session.Close();

                    return ServiceResult<bool>.Success(true);
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Delete(int radnikId)
        {
            var session = _dataLayer.OpenSession();
            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                var radnik = session.Get<Radnik>(radnikId);
                if (radnik == null)
                    return ServiceResult<bool>.Failure("Radnik sa datim ID-jem ne postoji!");

                if(radnik.Deo_Radionice.Broj_vilenjaka < 2)
                    return ServiceResult<bool>.Failure("Radnik ne moze biti obrisan jer bi deo radionice ostao bez potrebnog broja vilenjaka!");
                //if(radnik.Tim_Vilenjaka.GetNumberRadnika() < 2)
                //    return ServiceResult<bool>.Failure("Radnik ne moze biti obrisan jer bi tim vilenjaka ostao bez potrebnog broja vilenjaka!");


                session.Delete(radnik);
                session.Flush();
                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<RadnikDTO> GetByJedIme(string jedIme)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<RadnikDTO>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Radnik>()
                    .Where(r => r.Jed_ime == jedIme)
                    .Select(r => r.ToRadnikDTO())
                    .FirstOrDefault();

                if(result == null)
                    return ServiceResult<RadnikDTO>.Failure("Radnik sa datim jedinstvenim imenom ne postoji!");
                return ServiceResult<RadnikDTO>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<RadnikDTO>.Failure($"Greska pri pribavljanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IList<RadnikDTO>> GetByDeoRadionice(int deoRadioniceId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<RadnikDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Radnik>()
                    .Where(r => r.Deo_Radionice.Id_radionica == deoRadioniceId)
                    .Select(r => r.ToRadnikDTO())
                    .ToList();

                return ServiceResult<IList<RadnikDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<RadnikDTO>>.Failure($"Greska pri pribavljanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IList<RadnikDTO>> GetByTim(int idTima)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<RadnikDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Radnik>()
                    .Where(r => r.Tim_Vilenjaka.Id_tim == idTima)
                    .Select(r => r.ToRadnikDTO())
                    .ToList();

                return ServiceResult<IList<RadnikDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<RadnikDTO>>.Failure($"Greska pri pribavljanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IList<RadnikDTO>> GetBySaturatedDeoRadionice()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<RadnikDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Radnik>()
                    .Where(r => r.Deo_Radionice.Broj_vilenjaka > 1)
                    .Select(r => r.ToRadnikDTO())
                    .ToList();
                return ServiceResult<IList<RadnikDTO>>.Success(result);
            }
            catch(Exception ex)
            {
                return ServiceResult<IList<RadnikDTO>>.Failure($"Greska pri pribavljanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
            
        public ServiceResult<IList<RadnikDTO>> GetBySaturatedTim()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<RadnikDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<Radnik>()
                    .Where(r => r.Tim_Vilenjaka.Radnici.Count > 1)
                    .Select(r => r.ToRadnikDTO())
                    .ToList();

                return ServiceResult<IList<RadnikDTO>>.Success(result);
            }
            catch
            (Exception ex)
            {
                return ServiceResult<IList<RadnikDTO>>.Failure($"Greska pri pribavljanju radnika: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

    }
}
