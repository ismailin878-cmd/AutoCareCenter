using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AutoCare.DAL
{
    public class MusteriDAL
    {
        // نص الاتصال بالسيرفر المحلي - يمكنك تعديل كلمة المرور Pwd حسب إعدادات السيرفر لديك
        private string connectionString = "Server=localhost;Database=autocare_db;Uid=ismail_user;Pwd=1234;AllowUserVariables=True;";
        // 1. إجراء إضافة عميل جديد عن طريق استدعاء الـ Stored Procedure المتوافق مع شروط الواجب
        public bool MusteriEkle(string id, string ad, string soyad, string telefon, string email, string adres)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("autocare_sp_MusteriEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_id", id);
                    cmd.Parameters.AddWithValue("@p_ad", ad);
                    cmd.Parameters.AddWithValue("@p_soyad", soyad);
                    cmd.Parameters.AddWithValue("@p_tel", telefon);
                    cmd.Parameters.AddWithValue("@p_mail", email);
                    cmd.Parameters.AddWithValue("@p_adres", adres);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("DAL (MusteriEkle) Hatası: " + ex.Message);
                    }
                }
            }
        }

        // 2. إجراء جلب وعرض قائمة جميع العملاء من السيرفر
        public DataTable MusteriListele()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("autocare_sp_MusteriListele", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("DAL (MusteriListele) Hatası: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}