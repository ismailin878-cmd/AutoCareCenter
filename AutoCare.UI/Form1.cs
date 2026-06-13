using System;
using System.Windows.Forms;
using AutoCare.BLL;

namespace AutoCare.UI
{
    public partial class Form1 : Form
    {
        // استدعاء طبقة قواعد العمل (Business Logic Layer) كوسيط شرعي وحيد بناءً على المعمارية المطلوبة
        private MusteriBLL _musteriBLL = new MusteriBLL();

        public Form1()
        {
            InitializeComponent();
        }

        // حدث يتم تنفيذه تلقائياً بمجرد فتح الشاشة لجلب البيانات وعرضها بالجدول
        private void Form1_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        // حدث يتم تنفيذه عند الضغط على زر الحفظ
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // إرسال البيانات المكتوبة في الصناديق البرمجية إلى طبقة الـ BLL
                bool sonuc = _musteriBLL.MusteriKaydet(
                    txtAd.Text,
                    txtSoyad.Text,
                    txtTelefon.Text,
                    "", // البريد الإلكتروني (يمكن تركه فارغاً)
                    ""  // العنوان الافتراضي للعميل
                );

                if (sonuc)
                {
                    // رسالة نجاح مخصصة لتأكيد إدخال البيانات في السيرفر
                    MessageBox.Show("Müşteri başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تفريغ الصناديق النصية فوراً بعد نجاح العملية
                    txtAd.Clear();
                    txtSoyad.Clear();
                    txtTelefon.Clear();

                    // تحديث الجدول ليعرض العميل الجديد تلقائياً
                    VerileriYukle();
                }
            }
            catch (Exception ex)
            {
                // التقاط أخطاء الشروط أو أخطاء قاعدة البيانات (مثل الـ Triggers) وعرضها للمستخدم
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة مخصصة لسحب البيانات من الـ BLL وتغذية الجدول بها برمجياً
        private void VerileriYukle()
        {
            /*try
            {
                dgvMusteriler.DataSource = _musteriBLL.TumMusterileriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            try
            {
                dgvMusteriler.DataSource = _musteriBLL.TumMusterileriGetir();

                // إخفاء الأعمدة الزائدة برمجياً لتنظيف مظهر الجدول أمام الدكتور
                if (dgvMusteriler.Columns.Contains("email")) dgvMusteriler.Columns["email"].Visible = false;
                if (dgvMusteriler.Columns.Contains("adres")) dgvMusteriler.Columns["adres"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // حدث زر الانتقال إلى شاشة السيارات (تمت ترقيته ليصبح حواراً مشروطاً يُحدّث البيانات تلقائياً)
        private void button1_Click(object sender, EventArgs e)
        {
            // إخفاء شاشة العملاء مؤقتاً لتجنب التضارب
            this.Hide();

            AracForm aracForm = new AracForm();
            aracForm.ShowDialog(); // فتح الشاشة كحوار صارم يركز عليه السيرفر

            // بمجرد إغلاق شاشة السيارات، تعود شاشة العملاء وتجلب البيانات الجديدة فوراً
            this.Show();
            VerileriYukle();
        }
    }
}