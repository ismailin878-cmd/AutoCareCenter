using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AutoCare.DAL
{
    public class AracDAL
    {
        // نص الاتصال الموحد بالمستخدم الجديد الذي أنشأناه
        private string connectionString = "Server=localhost;Database=autocare_db;Uid=ismail_user;Pwd=1234;AllowUserVariables=True;";

        // 1. إجراء إضافة سيارة جديدة عبر الـ Stored Procedure
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

        // 2. إجراء جلب قائمة السيارات وعرض اسم صاحبها عبر الـ Inner Join الموجود بالـ Procedure
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
    }
}