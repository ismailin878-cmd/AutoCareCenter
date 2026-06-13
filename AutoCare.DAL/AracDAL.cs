using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AutoCare.DAL
{
    public class AracDAL
    {
        private string connectionString = "Server=localhost;Database=autocare_db;Uid=ismail_user;Pwd=1234;AllowUserVariables=True;";

        // 1. إجراء إضافة سيارة جديدة
        public bool AracEkle(string aracId, string musteriId, string plaka, string marka, string model, int yil)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("autocare_sp_AracEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_id", aracId);
                    cmd.Parameters.AddWithValue("@p_m_id", musteriId);
                    cmd.Parameters.AddWithValue("@p_plaka", plaka);
                    cmd.Parameters.AddWithValue("@p_marka", marka);
                    cmd.Parameters.AddWithValue("@p_model", model);
                    cmd.Parameters.AddWithValue("@p_yil", yil);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // 2. إجراء جلب قائمة السيارات
        public DataTable AracListele()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("autocare_sp_AracListele", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 3. إجراء تعديل سيارة (تم تحديث الاسم ليتطابق مع السيرفر الحقيقي)
        public bool AracGuncelle(string aracId, string plaka, string marka, string model, int yil, string musteriId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("abc_AracGuncelle", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_arac_id", aracId);
                        cmd.Parameters.AddWithValue("@p_plaka", plaka);
                        cmd.Parameters.AddWithValue("@p_marka", marka);
                        cmd.Parameters.AddWithValue("@p_model", model);
                        cmd.Parameters.AddWithValue("@p_yil", yil);
                        cmd.Parameters.AddWithValue("@p_musteri_id", musteriId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch { return false; }
        }

        // 4. إجراء حذف سيارة (تم تحديث الاسم ليتطابق مع السيرفر الحقيقي)
        public bool AracSil(string aracId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("abc_AracSil", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_arac_id", aracId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch { return false; }
        }
    }
}