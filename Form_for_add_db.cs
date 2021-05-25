using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proga
{
    public partial class Form_for_add_db : Form
    {
        List<string> names_materials;
        List<double> mass_materials;
        string spec, tip;
        double price;
        Client cl;
        BD bd = new BD();
        public Form_for_add_db(List<string> names_materials, List<double> mass_materials,string tip, string spec, double price, Client cl)
        {
            InitializeComponent();
            this.tip = tip;
            this.spec = spec;
            this.cl = cl;
            this.price = price;
            this.mass_materials = mass_materials;
            this.names_materials = names_materials;
            textBox1.Text = "Тип изделия: " + tip + ".\n";
            textBox1.Text += "Размер и особенности изделия: " + spec + ".\n";
            label3.Text = "Приблизетельная цена изделия: " + price + "Р.";
        }

        private void zkz_btn_Click(object sender, EventArgs e)
        {
            try
            {
                
                double mass = 0;
                int count = 0;
                foreach (var s in mass_materials)
                {
                    mass += s;
                    spec += "\n"+names_materials[count]+ "- масса - "+s+";\n";
                    count++;
                }
                
                double price1 = Math.Round(price *cl.saleL,2);
                
                Izdelie izdelie = new Izdelie(tip,mass,price1,spec,bd.ProbPalata.Find(1));
                bd.Izdelie.Add(izdelie);
                bd.SaveChanges();

                Zakaz zakaz = new Zakaz(DateTime.Now, bd.Client.Find(cl.id_client), izdelie);
                bd.Zakaz.Add(zakaz);
                bd.SaveChanges();


                double sale = 1;
                var count_iz = from z in bd.Zakaz
                           join c in bd.Client on z.id_client equals c.id_client
                               select z.id_izdelia;
                if (count_iz.Count() >= 3) sale = 0.85;
                Prodaga prodaga = new Prodaga(sale,bd.Client.Find(cl.id_client),izdelie,zakaz);
                bd.Prodaga.Add(prodaga);
                bd.SaveChanges();

                
                double price2 = Math.Round(izdelie.price * prodaga.sale + 500,2);
               
                Dostavka dostavka = new Dostavka(price2, cl.address, "не доставлено",bd.Dostavchik.Find(1),prodaga);
                bd.Dostavka.Add(dostavka);
                bd.SaveChanges();

                MessageBox.Show("Заказ успешно выполнен!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обработке данных: " + ex.Message);
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_for_add_db_Load(object sender, EventArgs e)
        {
            if (dvgMats.RowCount > 1)
            {
                dvgMats.RowCount = 1;
            }
            int count = 0;
            foreach (var i in names_materials)
            {
                dvgMats.RowCount++;
                dvgMats.Rows[count].Cells[0].Value = i;
                dvgMats.Rows[count].Cells[1].Value = mass_materials[count];
                count++;
            }
        }
    }
}
