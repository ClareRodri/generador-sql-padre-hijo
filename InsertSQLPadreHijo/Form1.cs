using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsertSQLPadreHijo
{
    public partial class Form1 : Form
    {
        private const string _path = "List_padres.txt";
        private const string _pathTemp = "Temp.sql";
        private const string _estructuraInsert = "INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES (";
        private const string _estructuraUpdate = "UPDATE SEG_PERMISOS SET ";

        public Form1()
        {
            InitializeComponent();
        }


        private List<string> getListPadre()
        {
            List<string> data = new List<string>();
            try
            {
                using (StreamReader sw = new StreamReader(_path))
                {
                    string s = "";
                    while ((s = sw.ReadLine()) != null)
                    {
                        data.Add(s);
                    }
                }
            }
            catch (FileNotFoundException f)
            {
                data = new List<string>();
                using (FileStream fs = File.Create(_path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("----------- Permisos padres ------------\n");
                    fs.Write(info, 0, info.Length);
                }
            }
            return data;
        }

        private bool getExistenciaData(string codigo)
        {
            try
            {
                using (StreamReader sw = new StreamReader(_path))
                {
                    string s = string.Empty;
                    while ((s = sw.ReadLine()) != null)
                    {
                        if (codigo == s) return true;
                    }
                }
            }
            catch (FileNotFoundException f)
            {
                return false;
            }
            return false;
        }

        private void setPadre(string codigo)
        {
            if (!getExistenciaData(codigo))
            {
                try
                {
                    using (StreamWriter w = File.AppendText(_path))
                    {
                        setData(codigo, w);
                    }
                }
                catch (FileNotFoundException f)
                {
                    Console.WriteLine("No encontro el archivo");
                }
            }
        }

        private void setDataTemp(string sql)
        {
            try
            {
                using (StreamWriter w = File.AppendText(_pathTemp))
                {
                    setData(sql, w);
                }
            }
            catch (FileNotFoundException f)
            {
                using (FileStream fs = File.Create(_pathTemp))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(sql);
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        private void setData(string data, TextWriter w)
        {
            w.WriteLine(data);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clearFieldsGenerados()
        {
            codigo.Text = "";
            nombre.Text = "";
            descripcion.Text = "";
            checkBox1.Checked = false;
            checkBox5.Checked = false;
            checkBox4.Checked = false;
            checkBox2.Checked = false;
        }

        private void clearFieldsEliminados()
        {
            tAreaOut.Text = "";
            codigo.Text = "";
            nombre.Text = "";
            descripcion.Text = "";
            checkBox1.Checked = false;
            checkBox5.Checked = false;
            checkBox4.Checked = false;
            checkBox2.Checked = false;
        }

        /*-------- Eventos ------*/


        /* Hijo o Padre */
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label4.Visible = true;
                listBox1.Visible = true;
                IEnumerable<string> data = getListPadre();
                foreach (string newItem in data) listBox1.Items.Add(newItem);
            }
            else
            {
                label4.Visible = false;
                listBox1.Visible = false;
                listBox1.Items.Clear();
            }
        }

        /* Generar SQL */
        private void button1_Click(object sender, EventArgs e)
        {
            string query = string.Format("\r\n");
            string query_padre = "NULL";
            string query_hijo = "(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='" + codigo.Text + "')";

            if (checkBox1.Checked) query_padre = string.Format("{0}{1}{2}", "(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='", listBox1.SelectedItem, "')");
            
            // Update
            if (checkBox4.Checked) query += _estructuraUpdate + "ESTADO = 'Activo', PADRE_ID = " + query_padre + ", DESCRIPCION = '" + descripcion.Text + "' WHERE ID ="+query_hijo+";";
            // Both
            else if (checkBox5.Checked)
            {
                query += _estructuraInsert + "'" + codigo.Text + "','" + nombre.Text + "'," + query_padre + ",'" +
                         descripcion.Text + "', 'Activo');\r\n";
                query += _estructuraUpdate + "ESTADO = 'Activo', PADRE_ID = " + query_padre + ", DESCRIPCION = '" + descripcion.Text + "' WHERE ID ="+query_hijo+";";
            }
            // Insert
            else query += _estructuraInsert + "'" + codigo.Text + "','" + nombre.Text + "'," + query_padre + ",'" + descripcion.Text + "', 'Activo');";

           
            
            if (checkBox2.Checked) query = string.Format("{0}\r\n{1}", query, "COMMIT;");
            tAreaOut.Text = string.Format("{0}\r\n{1}", tAreaOut.Text, query);


            // ---------------------------

            setPadre(codigo.Text);
            setDataTemp(query);
            clearFieldsGenerados();
        }

        /* Descargar SQL */
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(_pathTemp))
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = nombre.Text + "_" + DateTime.Today.Minute + DateTime.Today.Second;
                saveFile.Filter = "Text files (*.sql)|*.sql";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sw = new StreamReader(_pathTemp))
                    {
                        string s = string.Empty;
                        while ((s = sw.ReadLine()) != null)
                        {
                            using (StreamWriter w = File.AppendText(saveFile.FileName))
                            {
                                setData(s, w);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay datos temporales",
                       "Guardar datos temporales",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
            }
        }

        /* Eliminar archivo temporal */
        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(_pathTemp))
            {
                try
                {
                    File.Delete(_pathTemp);
                    clearFieldsEliminados();
                    MessageBox.Show("Se elimino correctamene el archivo temporal",
                        "Eliminar temporal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                catch (IOException io)
                {
                    Console.WriteLine("------ Error al eliminar el temporal ------");
                    Console.WriteLine(io.Message);
                    MessageBox.Show("Error al eliminar temporal: " + io.Message,
                        "Eliminar temporal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists(_path))
            {
                try
                {
                    File.Delete(_path);
                    clearFieldsEliminados();
                    MessageBox.Show("Se elimino correctamene el archivo padres",
                        "Eliminar padres",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                catch (IOException io)
                {
                    Console.WriteLine("------ Error al eliminar el padres ------");
                    Console.WriteLine(io.Message);
                    MessageBox.Show("Error al eliminar padres: " + io.Message,
                        "Eliminar padres",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
