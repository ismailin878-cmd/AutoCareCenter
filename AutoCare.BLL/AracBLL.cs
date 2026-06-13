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
            // التحقق من المدخلات (Business Rules)
            if (string.IsNullOrEmpty(plaka) || string.IsNullOrEmpty(marka))
            {
                throw new Exception("Plaka ve Marka alanları boş bırakılamaz!");
            }

            if (yil < 1900 || yil > 2027)
            {
                throw new Exception("Lütfen geçerli bir araç yılı giriniz (1900 - 2027)!");
            }

            // توليد معرف فريد تلقائي للسيارة
            string aracId = Guid.NewGuid().ToString();

            // تمرير البيانات المفلترة لطبقة الـ DAL للحفظ الفعلي
            return _aracDAL.AracEkle(aracId, musteriId, plaka.Trim(), marka.Trim(), model.Trim(), yil);
        }

        public DataTable TumAraclariGetir()
        {
            return _aracDAL.AracListele();
        }
    }
}