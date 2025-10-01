using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.Data;
using DedaMrazovaRadionica.App.Extensions;

namespace DedaMrazovaRadionica.App.Services.Implementation
{
    public class DeoRadioniceService : IDeoRadioniceService
    {
        private readonly IDataLayer _dataLayer;

        public DeoRadioniceService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ServiceResult<IList<DeoRadioniceDTO>> GetAll()
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<IList<DeoRadioniceDTO>>.Failure("Nema konekcije sa bazom podataka!");

                var result = session.Query<DeoRadionice>()
                    .Select(dr => dr.ToDeoRadioniceDTO()).ToList();

                return ServiceResult<IList<DeoRadioniceDTO>>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IList<DeoRadioniceDTO>>.Failure($"Greska pri pribavljanju delova radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        public ServiceResult<DeoRadioniceDTO> GetById(int id)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<DeoRadioniceDTO>.Failure("Nema konekcije sa bazom podataka!");

                var deoRadionice = session.Load<DeoRadionice>(id);

                if(deoRadionice == null)
                    return ServiceResult<DeoRadioniceDTO>.Failure("Deo radionice sa datim ID-jem ne postoji!");

                return ServiceResult<DeoRadioniceDTO>.Success(deoRadionice.ToDeoRadioniceDTO());
            }
            catch (Exception ex)
            {
                return ServiceResult<DeoRadioniceDTO>.Failure($"Greska pri pribavljanju dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        public ServiceResult<bool> Add(string naziv, int idRadnika, int idSefa)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                Radnik radnik = session.Load<Radnik>(idRadnika);
                if(radnik == null)
                    return ServiceResult<bool>.Failure("Radnik sa datim ID-jem ne postoji!");
                radnik.Deo_Radionice = null; //otpusta se neki radnik iz prethodnog dela radionice
                //na frontendu treba da se omoguci izbor iz delova radionice koji imaju vise od 1 radnika

                Radnik sef = session.Load<Radnik>(idSefa);
                if(sef == null)
                    return ServiceResult<bool>.Failure("Radnik (sef) sa datim ID-jem ne postoji!");
                //biraju se radnici iz liste: radnici iz radionica koje imeju vise od 1 radnika

                DeoRadionice deoRadionice = new DeoRadionice
                {
                    Naziv = naziv,
                    Broj_vilenjaka = 0,
                    Radnici = new List<Radnik> { radnik },
                    Sef = new Sef
                    {
                        Id_vilenjak = sef.Id_vilenjak,
                        Jed_ime = sef.Jed_ime,
                        Zemlja_porekla = sef.Zemlja_porekla,
                        Datum_zaposlenja = sef.Datum_zaposlenja,
                        MagicneVestine = sef.MagicneVestine,
                        Datum_postavljanja = DateTime.Now
                    },
                    MagicneVestine = new List<MagicnaVestina>(),
                    TipoviIgracaka = new List<TipIgracke>()
                };
                session.Delete(sef);//brise se radnik koji je postao sef

                //treba dodati magicne vestine dela radionice i tipove igracaka

                session.SaveOrUpdate(deoRadionice);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> Delete(int deoRadioniceId)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                var deoRadionice = session.Get<DeoRadionice>(deoRadioniceId);
                if(deoRadionice == null)
                    return ServiceResult<bool>.Failure("Deo radionice sa datim ID-jem ne postoji!");

                if(deoRadionice.Broj_vilenjaka > 0)
                    return ServiceResult<bool>.Failure("Deo radionice ne moze biti obrisan jer ima zaposlenih radnika!");
                session.Delete(deoRadionice);//sa ovim se brise i sef
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> UpdateSef(DeoRadioniceDTO deoRadioniceDTO, Sef sef)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                DeoRadionice oldDeoRadionice = session.Load<DeoRadionice>(deoRadioniceDTO.IdRadionica);
                Sef oldSef = oldDeoRadionice.Sef;
                //cuvamo referencu na starog sefa da bismo mogli da ga obrisemo
                oldDeoRadionice.Sef = sef;
                session.Update(oldDeoRadionice);
                session.Delete(oldSef);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri izmeni sefa dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> UpdateNaziv(DeoRadioniceDTO deoRadioniceDTO, string novinaziv)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");
                DeoRadionice oldDeoRadionice = session.Load<DeoRadionice>(deoRadioniceDTO.IdRadionica);
                oldDeoRadionice.Naziv = novinaziv;
                session.Update(oldDeoRadionice);
                session.Flush();
                return ServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri izmeni naziva dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        //treba da moze da se doda tip iz postojece liste:
        public ServiceResult<bool> AddTipIgracke(DeoRadioniceDTO deoRadioniceDTO, TipIgracke tipigracke)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                DeoRadionice deoRadionice = session.Load<DeoRadionice>(deoRadioniceDTO.IdRadionica);
                deoRadionice.TipoviIgracaka.Add(tipigracke);
                session.Update(deoRadionice);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju tipa igracke delu radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        //treba da moze da se izbrise tip iz liste za tu radionicu:
        public ServiceResult<bool> RemoveTipIgracke(DeoRadioniceDTO deoRadioniceDTO, int idTipa)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                DeoRadionice deoRadionice = session.Load<DeoRadionice>(deoRadioniceDTO.IdRadionica);
                TipIgracke tipIgracke = session.Get<TipIgracke>(idTipa);
                if(tipIgracke == null)
                    return ServiceResult<bool>.Failure("Tip igracke sa datim ID-jem ne postoji!");
                deoRadionice.TipoviIgracaka.Remove(tipIgracke);
                session.Update(deoRadionice);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju tipa igracke iz dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> AddMagicnaVestina(DeoRadioniceDTO deoRadioniceDTO, MagicnaVestina magicnaVestina)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");

                DeoRadionice deoRadionice = session.Load<DeoRadionice>(deoRadioniceDTO.IdRadionica);
                deoRadionice.MagicneVestine.Add(magicnaVestina);
                session.Update(deoRadionice); 
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri dodavanju magicne vestine delu radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
        public ServiceResult<bool> RemoveMagicnaVestina(DeoRadioniceDTO deoRadioniceDTO, int idMagicnaVestina)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");
                DeoRadionice deoRadionice = session.Load<DeoRadionice>(deoRadioniceDTO.IdRadionica);
                MagicnaVestina magicnaVestina = session.Get<MagicnaVestina>(idMagicnaVestina);
                if(magicnaVestina == null)
                    return ServiceResult<bool>.Failure("Mag. vestina sa datim ID-jem ne postoji!");
                deoRadionice.MagicneVestine.Remove(magicnaVestina);
                session.Update(deoRadionice);
                session.Flush();

                return ServiceResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri brisanju magicne vestine iz dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> IsNullTipoviIgracaka(DeoRadioniceDTO deoRadioniceDTO)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if(session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");
                DeoRadionice deoRadionice = session.Load<DeoRadionice>(deoRadioniceDTO.IdRadionica);
                if(deoRadionice.TipoviIgracaka == null || deoRadionice.TipoviIgracaka.Count == 0)
                    return ServiceResult<bool>.Success(true);
                else
                    return ServiceResult<bool>.Success(false);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri proveri tipova igracaka dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }

        public ServiceResult<bool> IsNullMagicneVestine(DeoRadioniceDTO deoRadioniceDTO)
        {
            var session = _dataLayer.OpenSession();

            try
            {
                if (session == null)
                    return ServiceResult<bool>.Failure("Nema konekcije sa bazom podataka.");
                DeoRadionice deoRadionice = session.Load<DeoRadionice>(deoRadioniceDTO.IdRadionica);
                if (deoRadionice.MagicneVestine == null || deoRadionice.MagicneVestine.Count == 0)
                    return ServiceResult<bool>.Success(true);
                else
                    return ServiceResult<bool>.Success(false);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Greska pri proveri magicnih vestina dela radionice: {ex.Message}");
            }
            finally
            {
                session?.Close();
            }
        }
    }
}
