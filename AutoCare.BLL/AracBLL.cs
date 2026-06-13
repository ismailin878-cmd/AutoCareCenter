using System;
using System.Data;
using AutoCare.DAL;

namespace AutoCare.BLL
{
    public class AracBLL
    {
        private AracDAL _aracDAL = new AracDAL();

        public bool AracKaydet(string musteriId, string plaka, string marka, string model, int yil)
        {
            // İş Kuralları (Business Rules)
            if (string.IsNullOrEmpty(plaka) || string.IsNullOrEmpty(marka))
            {
                throw new Exception("Plaka ve Marka alanları boş bırakılamaz!");
            }

            // تم تعديل الشرط إلى 2026 ليتطابق مع تريجر الأمان بالسيرفر
            if (yil < 1900 || yil > 2026)
            {
                throw new Exception("Lütfen geçerli bir araç yılı giriniz (1900 - 2026)!");
            }

            string aracId = Guid.NewGuid().ToString();

            return _aracDAL.AracEkle(aracId, musteriId, plaka.Trim(), marka.Trim(), model.Trim(), yil);
        }

        public DataTable TumAraclariGetir()
        {
            return _aracDAL.AracListele();
        }

        public bool AracGuncelle(string aracId, string plaka, string marka, string model, int yil, string musteriId)
        {
            if (string.IsNullOrEmpty(plaka) || string.IsNullOrEmpty(marka))
            {
                throw new Exception("Plaka ve Marka alanları boş bırakılamaz!");
            }

            if (yil < 1900 || yil > 2026)
            {
                throw new Exception("Lütfen geçerli bir araç yılı giriniz (1900 - 2026)!");
            }

            return _aracDAL.AracGuncelle(aracId, plaka.Trim(), marka.Trim(), model.Trim(), yil, musteriId);
        }

        public bool AracSil(string aracId)
        {
            if (string.IsNullOrEmpty(aracId)) return false;
            return _aracDAL.AracSil(aracId);
        }
    }
}