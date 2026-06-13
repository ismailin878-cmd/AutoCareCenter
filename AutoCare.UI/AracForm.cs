using System;
using System.Windows.Forms;
using AutoCare.BLL;

namespace AutoCare.UI
{
    public partial class AracForm : Form
    {
        private AracBLL _aracBLL = new AracBLL();
        private MusteriBLL _musteriBLL = new MusteriBLL();

        public AracForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AracForm_Load);
            cmbMusteriler.DropDown += new System.EventHandler(this.CmbMusteriler_DropDown);
        }

        private void CmbMusteriler_DropDown(object sender, EventArgs e)
        {
            MusteriListesiniYukle();
        }

        private void AracForm_Load(object sender, EventArgs e)
        {
            MusteriListesiniYukle();
            AracListesiniYukle();
        }

        private void MusteriListesiniYukle()
        {
            try
            {
                System.Data.DataTable dt = _musteriBLL.TumMusterileriGetir();

                if (!dt.Columns.Contains("AdSoyadGoster"))
                {
                    dt.Columns.Add("AdSoyadGoster", typeof(string), "ad + ' ' + soyad");
                }

                cmbMusteriler.DataSource = dt;
                cmbMusteriler.DisplayMember = "AdSoyadGoster";
                cmbMusteriler.ValueMember = "musteri_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri listesi yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AracListesiniYukle()
        {
            try
            {
                dgvAraclar.DataSource = _aracBLL.TumAraclariGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araç listesi yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة الحفظ المربوطة فعلياً بالزر ونشطة في التصميم
        private void btnAracKaydet_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbMusteriler.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen bir müşteri seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string secilenMusteriId = cmbMusteriler.SelectedValue.ToString();

                int aracYili = 0;
                int.TryParse(txtYil.Text, out aracYili);

                bool sonuc = _aracBLL.AracKaydet(
                    secilenMusteriId,
                    txtPlaka.Text,
                    txtMarka.Text,
                    txtModel.Text,
                    aracYili
                );

                if (sonuc)
                {
                    MessageBox.Show("Araç başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtPlaka.Clear();
                    txtMarka.Clear();
                    txtModel.Clear();
                    txtYil.Clear();

                    AracListesiniYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AracForm_Load_1(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dgvAraclar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}