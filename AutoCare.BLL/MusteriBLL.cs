using System;
using System.Data;
using AutoCare.DAL;

namespace AutoCare.BLL
{
    public class MusteriBLL
    {
        private MusteriDAL _musteriDAL = new MusteriDAL();

        public bool MusteriKaydet(string ad, string soyad, string telefon, string email, string adres)
        {
            // توليد معرف فريد فريد (GUID) للعميل تلقائياً لحفظ النظام
            string uniqueId = Guid.NewGuid().ToString();

            // قاعدة عمل بسيطة: التأكد من عدم ترك خانة الاسم أو الهاتف فارغة
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(telefon))
            {
                throw new Exception("Ad ve Telefon alanları boş bırakılamaz!");
            }

            return _musteriDAL.MusteriEkle(uniqueId, ad, soyad, telefon, email, adres);
        }

        public DataTable TumMusterileriGetir()
        {
            return _musteriDAL.MusteriListele();
        }
    }
}