using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.Extensions;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class TimVilenjakaService : ITimVilenjakaService
    {
        private readonly IDataLayer _dataLayer;

        public TimVilenjakaService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<TimVilenjakaDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<TimVilenjakaDTO>>.Failure("Nema konekcije sa bazom podataka!");
                
                var result = session.Query<TimVilenjaka>()
                    .Select(t => t.ToTimVilenjakaDTO()).ToList();

                return ServiceResult<IList<TimVilenjakaDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<TimVilenjakaDTO>>.Failure($"Greska pri pribavljanju timova vilenjaka: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<TimVilenjakaDTO> GetById(int id)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<TimVilenjakaDTO>.Failure("Nema konekcije sa bazom podataka!");

                var tim = session.Load<TimVilenjaka>(id);
                if(tim == null)
                    return ServiceResult<TimVilenjakaDTO>.Failure("Tim vilenjaka sa datim ID-jem ne postoji!");

                return ServiceResult<TimVilenjakaDTO>.Success(tim.ToTimVilenjakaDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<TimVilenjakaDTO>.Failure($"Greska pri pribavljanju tima vilenjaka: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Add(string naziv, string namena, int idRadnika)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                Radnik radnik = session.Load<Radnik>(idRadnika);
                if(radnik == null)
                    return ServiceResult<bool>.Failure("Radnik sa datim ID-jem ne postoji!");
                //bira se radnik iz liste radnika koji su u timovima sa preko 1 radnika

                TimVilenjaka newTim = new TimVilenjaka
                {
                    Naziv = naziv,
                    Namena = namena,
                    Koordinator = null,
                    Radnici = new List<Radnik>() { radnik }
                };

                session.SaveOrUpdate(newTim);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju tima vilenjaka: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> SetKoordinatora(TimVilenjakaDTO timVilenjakaDTO, int idRadnika)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                TimVilenjaka tim = session.Load<TimVilenjaka>(timVilenjakaDTO.IdTim);

                if(tim.Koordinator == null)
                {
                    Radnik radnik = session.Load<Radnik>(idRadnika);

                    if (radnik == null)
                        return ServiceResult<bool>.Failure("Radnik sa datim ID-jem ne postoji!");
                    
                    if (!tim.Radnici.Any(r => r.Id_vilenjak == idRadnika))
                        return ServiceResult<bool>.Failure("Radnik nije clan tima, ne moze biti koordinator!");

                    tim.Koordinator = radnik;
                    
                    session.SaveOrUpdate(tim);
                    session.Flush();
                    
                    return ServiceResult<bool>.Success(true);
                }
                else
                {
                    return ServiceResult<bool>.Failure("Tim vec ima koordinatora!");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri postavljanju koordinatora tima: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        //brise se samo ako nema vise radnika u timu
        public ServiceResult<bool> Delete(int timVilenjakaId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                TimVilenjaka tim = session.Load<TimVilenjaka>(timVilenjakaId);
                if(tim == null)
                    return ServiceResult<bool>.Failure("Tim vilenjaka sa datim ID-jem ne postoji!");
                if(tim.Radnici.Count > 0)
                    return ServiceResult<bool>.Failure("Tim vilenjaka ima radnike, ne moze biti obrisan!");
                session.Delete(tim);
                session.Flush();
                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju tima vilenjaka: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<TimVilenjakaDTO> GetByNaziv(string naziv)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<TimVilenjakaDTO>.Failure("Nema konekcije sa bazom podataka!");
                var tim = session.Query<TimVilenjaka>()
                    .FirstOrDefault(t => t.Naziv == naziv);
                if(tim == null)
                    return ServiceResult<TimVilenjakaDTO>.Failure("Tim vilenjaka sa datim nazivom ne postoji!");
                return ServiceResult<TimVilenjakaDTO>.Success(tim.ToTimVilenjakaDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<TimVilenjakaDTO>.Failure($"Greska pri pribavljanju tima vilenjaka po nazivu: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<IList<TimVilenjakaDTO>> GetByNamena(string namena)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<TimVilenjakaDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var tim = session.Query<TimVilenjaka>()
                    .Where(t => t.Namena == namena)
                    .Select(t => t.ToTimVilenjakaDTO())
                    .ToList();
                if(tim == null || tim.Count == 0)
                    return ServiceResult<IList<TimVilenjakaDTO>>.Failure("Ne postoji nijedan tim vilenjaka sa datom namenom!");
                
                return ServiceResult<IList<TimVilenjakaDTO>>.Success(tim);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<TimVilenjakaDTO>>.Failure($"Greska pri pribavljanju tima vilenjaka po nameni: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<int> GetNumberRadnika(TimVilenjakaDTO timVilenjakaDTO)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<int>.Failure("Nema konekcije sa bazom podataka!");
                TimVilenjaka tim = session.Load<TimVilenjaka>(timVilenjakaDTO.IdTim);
                
                var res = tim.Radnici.Count;

                return ServiceResult<int>.Success(res);
            }
            catch (Exception ex)
            {
                return ServiceResult<int>.Failure($"Greska pri pribavljanju broja radnika u timu: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        //dodeljuje listu dobijenu kao rezultat fje iz servisa PoklonService
        public ServiceResult<bool> DodeliPokloneTimu(TimVilenjakaDTO timVilenjakaDTO, IList<Poklon> pokloni)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                TimVilenjaka tim = session.Load<TimVilenjaka>(timVilenjakaDTO.IdTim);
                if(tim == null)
                    return ServiceResult<bool>.Failure("Tim vilenjaka sa datim ID-jem ne postoji!");
                foreach(var poklon in pokloni)
                {
                    if(poklon == null)
                        return ServiceResult<bool>.Failure("Poklon ne postoji!");
                    if(tim.Pokloni.Any(p => p.Id_poklon == poklon.Id_poklon))
                        return ServiceResult<bool>.Failure("Poklon je vec dodeljen timu!");
                    tim.Pokloni.Add(poklon);
                }
                session.SaveOrUpdate(tim);
                session.Flush();
                
                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodeljivanju poklona timu: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        //dodeljuje listu dobijenu kao rezultat fje iz servisa PoklonService
        public ServiceResult<bool> DodeliTovareTimu(TimVilenjakaDTO timVilenjakaDTO, IList<Tovar> tovari)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka!");

                TimVilenjaka tim = session.Load<TimVilenjaka>(timVilenjakaDTO.IdTim);
                if(tim == null)
                    return ServiceResult<bool>.Failure("Tim vilenjaka sa datim ID-jem ne postoji!");
                foreach(var tovar in tovari)
                {
                    if(tovar == null)
                        return ServiceResult<bool>.Failure("Tovar ne postoji!");
                    if(tim.Tovari.Any(t => t.Id_tovar == tovar.Id_tovar))
                        return ServiceResult<bool>.Failure("Tovar je vec dodeljen timu!");
                    tim.Tovari.Add(tovar);
                }
                session.SaveOrUpdate(tim);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodeljivanju tovara timu: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
    }
}
