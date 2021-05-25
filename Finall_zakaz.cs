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
    public partial class Finall_zakaz : Form
    {
        List<string> names_materials;
        List<double> mass_materials;
        public Finall_zakaz(ref string tip_izd, ref string spec, List<string> names_materials, List<double> mass_materials)
        {
            InitializeComponent();
            this.names_materials = names_materials;
            this.mass_materials = mass_materials;
            labInfoIzd.Text =  $"Тип изделия: {tip_izd}\n Особенности изделия: {spec}.";
            Fill();
        }
        void Fill()
        {
            if(dvgMats.RowCount > 1)
            {
                dvgMats.RowCount = 1;
            }
            int count = 0;
            foreach (var i in names_materials)
            {
                dvgMats.RowCount++;
                dvgMats.Rows[count].Cells[0].Value = count;
                dvgMats.Rows[count].Cells[1].Value = i;
                dvgMats.Rows[count].Cells[2].Value = mass_materials[count];
                count++;
            }
        }
        private void del_btn_mat_Click(object sender, EventArgs e)
        {
            try
            {
                names_materials.Remove(names_materials[Convert.ToInt32(numMatNomer.Value)]);
                mass_materials.Remove(mass_materials[Convert.ToInt32(numMatNomer.Value)]);
                
                Fill();
                MessageBox.Show("Материал удалён.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при обработке данных: " + ex.Message);
            }
        }
    }
}
