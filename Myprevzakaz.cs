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
    public partial class Myprevzakaz : Form
    {
        BD bD = new BD();
        Client cl;
        public Myprevzakaz(Client cl)
        {
            InitializeComponent();
            this.cl = cl; 
        }

        private void Myprevzakaz_Load(object sender, EventArgs e)
        {
            this.Text = "Клиент: " + cl.FIO;
            // 2 запрос через linq
            var CLSALE = from cl in bD.Client.DefaultIfEmpty()
                         join zak in bD.Zakaz.DefaultIfEmpty() on cl.id_client equals zak.id_client
                         join izd in bD.Izdelie.DefaultIfEmpty() on zak.id_izdelia equals izd.id_izdelia
                         select new
                         {
                             id = izd.id_izdelia,
                             id_cl = cl.id_client,
                             tip = izd.tip_izd,
                             mas = izd.mass,
                             saleL = cl.saleL,
                             dt_sh = izd.data_shtampa,
                             prc = izd.price,
                             spec = izd.razmer_special_mess
                         };
            var CLSALEgrouped = CLSALE.GroupBy(a => a.id);
            var resclsale = CLSALEgrouped.ToList()
                .Select(eg => new
                {
                    id = eg.First().id,
                    mas = eg.First().mas,
                    prc = eg.First().prc,
                    spec = eg.First().spec,
                    tip = eg.First().tip,
                    prc_sale = eg.First().prc * eg.First().saleL,
                    id_client = eg.First().id_cl,
                    dt_sh = eg.First().dt_sh,
                });

            var zapros_full = from cl in resclsale
                     join pr in bD.Prodaga on cl.id equals pr.id_izdelia
                     join dost in bD.Dostavka on pr.id_prodaga equals dost.id_prodaga
                     where cl.id_client == this.cl.id_client
                     select new
                     {
                         id = cl.id,
                         mas = cl.mas,
                         prc = cl.prc,
                         spec = cl.spec,
                         tip = cl.tip,
                         prc_sale = cl.prc_sale,
                         dt_sh = cl.dt_sh,
                         dostav_sts = dost.status_dostv,
                         buy = cl.prc_sale * pr.sale,
                         dt_pr = pr.data_prod
                     };
            int num = 0;
            if (dvgZAKAZ_CL.RowCount > 1) dvgZAKAZ_CL.RowCount = 1;
      
            foreach (var f in zapros_full)
            {
                dvgZAKAZ_CL.RowCount++;
                dvgZAKAZ_CL.Rows[num].Cells[0].Value = f.tip.ToString();//тип изделия
                dvgZAKAZ_CL.Rows[num].Cells[1].Value = f.mas.ToString();//масса
                dvgZAKAZ_CL.Rows[num].Cells[2].Value = f.spec;//особенности и материалы
                dvgZAKAZ_CL.Rows[num].Cells[3].Value = Math.Round(f.prc,2).ToString();//цена
                dvgZAKAZ_CL.Rows[num].Cells[4].Value = Math.Round(f.prc_sale,2).ToString();//цена при клиентской скидке
                dvgZAKAZ_CL.Rows[num].Cells[5].Value = Math.Round(f.buy,2).ToString();//заплачен
                dvgZAKAZ_CL.Rows[num].Cells[6].Value = f.dostav_sts;//статус доставки
                dvgZAKAZ_CL.Rows[num].Cells[7].Value = f.dt_sh.ToString();//дата штампа у изделия
                dvgZAKAZ_CL.Rows[num].Cells[8].Value = f.dt_pr.ToString();// дата продажи
                num++;
            }//выводим запрос на экран
        }

        private void zakaz_button_Click(object sender, EventArgs e)
        {
            Zakaz_form zakaz_Form = new Zakaz_form(cl);
            Hide();
            zakaz_Form.ShowDialog();
            Myprevzakaz_Load(sender, e);
            Show();
        } //выполнить заказ

        private void button_formclient_Click(object sender, EventArgs e)
        {
            Form_for_client form_For_ = new Form_for_client();
            Hide();
            form_For_.ShowDialog();
            Show();
        }//посмотреть изделия

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Update_btn_cl_Click(object sender, EventArgs e)
        {
            FormUpdate up = new FormUpdate(cl);
            up.ShowDialog();
            Myprevzakaz_Load(sender, e);
            Close();
        }
    }
}
