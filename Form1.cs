using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataBajuApp
{
    public partial class Form1 : Form
    {
        private List<Baju> daftarBaju = new List<Baju>();
        private int selectedIndex = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvBaju.AutoGenerateColumns = true;
            dgvBaju.DataSource = null;
            dgvBaju.DataSource = daftarBaju;
        }

        private void ClearForm()
        {
            txtNama.Text = "";
            txtUkuran.Text = "";
            txtWarna.Text = "";
            txtHarga.Text = "";
            selectedIndex = -1;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtUkuran.Text) ||
                string.IsNullOrWhiteSpace(txtWarna.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text))
            {
                MessageBox.Show("Semua field harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Baju baju = new Baju
            {
                Nama = txtNama.Text,
                Ukuran = txtUkuran.Text,
                Warna = txtWarna.Text,
                Harga = decimal.TryParse(txtHarga.Text, out decimal h) ? h : 0
            };

            daftarBaju.Add(baju);
            RefreshGrid();
            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedIndex >= 0)
            {
                daftarBaju[selectedIndex].Nama = txtNama.Text;
                daftarBaju[selectedIndex].Ukuran = txtUkuran.Text;
                daftarBaju[selectedIndex].Warna = txtWarna.Text;
                daftarBaju[selectedIndex].Harga = decimal.TryParse(txtHarga.Text, out decimal h) ? h : 0;

                RefreshGrid();
                ClearForm();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedIndex >= 0)
            {
                daftarBaju.RemoveAt(selectedIndex);
                RefreshGrid();
                ClearForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvBaju_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedIndex = e.RowIndex;
                var baju = daftarBaju[selectedIndex];

                txtNama.Text = baju.Nama;
                txtUkuran.Text = baju.Ukuran;
                txtWarna.Text = baju.Warna;
                txtHarga.Text = baju.Harga.ToString();
            }
        }
    }
}
