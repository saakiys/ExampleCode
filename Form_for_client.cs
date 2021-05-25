using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace proga
{
    public partial class Form_for_client : Form
    {
        BD bD = new BD();
        public Form_for_client()
        {
            InitializeComponent();
            this.Text= "Изделия компании";
        }

        private void Form_for_client_Load(object sender, EventArgs e)
        {
            // 1 запрос через linq
            var sqlcatalog = from izd in bD.Izdelie.DefaultIfEmpty()
                             join izgot in bD.Izgotovlenie.DefaultIfEmpty() on izd.id_izdelia equals izgot.id_izdelia
                             join vyd in bD.Vydacha.DefaultIfEmpty() on izgot.id_izgot equals vyd.id_izgot
                             join m in bD.Material.DefaultIfEmpty() on vyd.id_material equals m.id_material
                             orderby izd.id_izdelia
                             select  new 
                             {   id = izd.id_izdelia,
                                 tip = izd.tip_izd,
                                 mas = izd.mass, 
                                 mats = m.nameM, 
                                 prc = izd.price,
                                 spec = izd.razmer_special_mess
                             };
            var groupedResult = sqlcatalog.GroupBy(a => a.id);
            var result = groupedResult.ToList()
                .Select(eg => new
                {
                    id = eg.Key,
                    mas = eg.First().mas,
                    prc = eg.First().prc,
                    spec = eg.First().spec,
                    tip = eg.First().tip,
                    mats = string.Join(", ", eg.Select(i => i.mats))
                });

            int rowNum = 0;
            foreach (var row in result)
            {
                dvgCatalog_izdel.RowCount++;
                dvgCatalog_izdel.Rows[rowNum].Cells[0].Value = row.tip.ToString();
                dvgCatalog_izdel.Rows[rowNum].Cells[1].Value = row.mats.ToString();
                dvgCatalog_izdel.Rows[rowNum].Cells[2].Value = row.mas.ToString();
                dvgCatalog_izdel.Rows[rowNum].Cells[3].Value = row.prc.ToString();
                dvgCatalog_izdel.Rows[rowNum].Cells[4].Value = row.spec;
                rowNum++;
            } //выводим запрос на экран
        }


        private void Form_for_client_KeyDown(object sender, KeyEventArgs e)
        {
           
          
        }
    }
}
