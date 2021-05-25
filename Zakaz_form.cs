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
    public partial class Zakaz_form : Form
    {
        BD bD = new BD();
        Client cl;
        List<string> special_and_materials = new List<string>();//это в особенности
        List<string> names_materials = new List<string>();//это в особенности
        List<double> mass_materials = new List<double>(); // масса
        public Zakaz_form(Client cl)
        {
            InitializeComponent();
            this.cl = cl;
        }

        private void Add_material_btn_Click(object sender, EventArgs e)
        {
            if (comboBoxMaterial1.Text.Length != 0)
            {
                if (textBoxMassaMat1.Value != 0)
                {
                    names_materials.Add(comboBoxMaterial1.Text);
                    mass_materials.Add((double)textBoxMassaMat1.Value);
                    view_materials_btn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Укажите массу изделия!");
                }
            }
            else
            {
                MessageBox.Show("Выберите хотя бы один материал!");
            }
        }

        private void zakaz_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTipIzd.Text.Length != 0)
                {
                    if (textBoxRazmeriSpecial.Text.Length != 0)
                    {
                        if (names_materials.Count != 0)
                        {
                            double stoim = 0;
                            int k = 0;
                            foreach (var i in names_materials)
                            {
                                foreach (var m in bD.Material)
                                {
                                    if (m.nameM == i)
                                    {
                                        stoim += m.price_one * Convert.ToDouble(mass_materials[k]);
                                        break;
                                    }
                                }//считаем себестоимость
                                stoim += Math.Round(stoim, 2);
                                k++;
                            }
                            stoim *= 1.55; //примерные наценки
                            stoim = Math.Round(stoim, 2);
                            string A = comboBoxTipIzd.Text;
                            string b = textBoxRazmeriSpecial.Text;
                            MessageBox.Show("Приблизительная стоимость готового изделия " + stoim + "₽");
                            Form_for_add_db add_Db = new Form_for_add_db(names_materials, mass_materials, A, b, stoim, cl);
                            Hide();
                            add_Db.ShowDialog();
                            if (add_Db.DialogResult == DialogResult.OK) Show();
                            else Close();
                        }
                        else
                        {
                            MessageBox.Show("Выберите хотя бы один материал!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Напишите размеры изделия и особенности!");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не написали тип изделия!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обработке данных: " + ex.Message);
            }
        }

        private void Zakaz_form_Load(object sender, EventArgs e)
        {
            foreach (var r in bD.Material)
            {
                comboBoxMaterial1.Items.Add(r.nameM);
            } // заполняем combobox
        }

        private void view_materials_btn_Click(object sender, EventArgs e)
        {
            string A = comboBoxTipIzd.Text;
            string b = textBoxRazmeriSpecial.Text;
            Finall_zakaz finall_Zakaz = new Finall_zakaz(ref A, ref b, names_materials, mass_materials);
            finall_Zakaz.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxTipIzd.Clear();
            comboBoxMaterial1.Items.Clear();
            foreach (var r in bD.Material)
            {
                comboBoxMaterial1.Items.Add(r.nameM);
            } // заполняем combobox
            textBoxRazmeriSpecial.Clear();
        }

        private void comboBoxMaterial1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_material_btn.Enabled = true;
        }
    }
}
