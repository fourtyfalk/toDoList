using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toDoList
{
    public partial class toDoList : Form
    {
        private SqlConnection cn;

        public toDoList()
        {
            InitializeComponent();
        }

        private void toDoList_Load(object sender, EventArgs e)
        {
            //Datenbank wurden eingerichtet
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\guhde\source\repos\toDoList\toDoListe.mdf;Integrated Security=True");
            cn.Open();

            // Hier wurden zwei Tabellen aufgefüllt
            string insertBefehlEins = "INSERT INTO [dbo].[ErledigtTable] (Id, ErledigtJa, ErledigtNein) VALUES (@Id, @ErledigtJa, @ErledigtNein)";
            string insertBefehlZwei = "INSERT INTO [dbo].[OffenTable] (Id, OffenJa, OffenNein) VALUES (@Id, @OffenJa, @OffenNein)";
            string insertFilePath = "insertErledigtOffen.txt";

            // Hier wird mit der If-Abfrage mehrere Datei Erstellungen zu den Inserts abgefangen
            if (!File.Exists(insertFilePath))
            {
                using (SqlCommand insertCommandOne = new SqlCommand(insertBefehlEins, cn))
                {
                    insertCommandOne.Parameters.AddWithValue("@Id", 1);
                    insertCommandOne.Parameters.AddWithValue("@ErledigtJa", 0);
                    insertCommandOne.Parameters.AddWithValue("@ErledigtNein", 1);

                }
                using (SqlCommand insertCommandTwo = new SqlCommand(insertBefehlEins, cn))
                {
                    insertCommandTwo.Parameters.AddWithValue("@Id", 2);
                    insertCommandTwo.Parameters.AddWithValue("@ErledigtJa", 1);
                    insertCommandTwo.Parameters.AddWithValue("@ErledigtNein", 0);

                }
                using (SqlCommand insertCommandThree = new SqlCommand(insertBefehlZwei, cn))
                {
                    insertCommandThree.Parameters.AddWithValue("@Id", 1);
                    insertCommandThree.Parameters.AddWithValue("@OffenJa", 1);
                    insertCommandThree.Parameters.AddWithValue("@OffenNein", 0);

                }
                using (SqlCommand insertCommandFour = new SqlCommand(insertBefehlZwei, cn))
                {
                    insertCommandFour.Parameters.AddWithValue("@Id", 2);
                    insertCommandFour.Parameters.AddWithValue("@OffenJa", 0);
                    insertCommandFour.Parameters.AddWithValue("@OffenNein", 1);

                }
                File.WriteAllText(insertFilePath, "INSERTS wurden erfolgreich hinzugefügt.");
            }
            textBox1.KeyDown += textBox_PressEnter;
        }

        // Hier kann das ToDo auch mit der Entertaste hinzugefügt werden
        private void textBox_PressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                inserting.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
                textBox1.Clear();
            }
        }
        private void inserting_Click(object sender, EventArgs e)
        {
            // Hier wird der ToDo Text eingefügt ins GUI
            checkedListBox1.Items.Add(textBox1.Text);
            int eidee = 1;
            int offenId = 1;
            int erledigtId = 1;

            // Hier wird in der Datenbank für die Tabelle ToDoListTable Werte eingefügt
            SqlCommand cmdOne = new SqlCommand("INSERT INTO [dbo].[ToDoListTable] ([Id], [Aufgabe], [Erledigt_Id_Fk], [Offen_Id_Fk]) VALUES (@Id, @Aufgabe, @Erledigt_Id_Fk, @Offen_Id_Fk)", cn);
            
            // Hier wird abgefragt wie viele Werte in der Tabelle existieren
            SqlCommand cmdTwo = new SqlCommand("SELECT * FROM [dbo].[ToDoListTable]", cn);
            SqlDataReader redeLoewe = cmdTwo.ExecuteReader();

            // Hiermit wird eine neue Id generiert
            while (redeLoewe.Read())
            {
                eidee += 1;
            }
            
            //Hier wird der zweite Befehl beendet
            redeLoewe.Close();

            // Hier kommen die Werte für den Insert Befehl rein
            cmdOne.Parameters.AddWithValue("Id", eidee);
            cmdOne.Parameters.AddWithValue("Aufgabe", textBox1.Text);
            cmdOne.Parameters.AddWithValue("Erledigt_Id_Fk", erledigtId);
            cmdOne.Parameters.AddWithValue("Offen_Id_Fk", offenId);

            //Hier wird der erste Befehl ausgeführt
            cmdOne.ExecuteNonQuery();
            
        }

        // Hier gibts die zweite Möglichkeit die Anwendung zu beenden
        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }


        // Hier werden die ToDos gelöscht und auf eine Andere Ebene geschoben
        private void delete_Click(object sender, EventArgs e)
        {
            int foundId = 0;

            // Hier zählt er alle Elemente auf
            SqlCommand cmdfindId = new SqlCommand("SELECT * FROM [dbo].[ToDoListTable]", cn);

            // Hier zählt er alle aktuellen ToDos auf
            for (int findMe = 0; findMe < checkedListBox1.Items.Count; findMe++)
            {

                // Hier sucht er nachdem angekreuzten ToDos
                if (checkedListBox1.GetItemChecked(findMe))
                {

                    // Hier geht er die Liste in der Datenbank durch
                    SqlDataReader leseId = cmdfindId.ExecuteReader();
                    while (leseId.Read())
                    {
                        //Hier zählt er immer die eine gesuchte Id hoch  
                        foundId += 1;
                        string findMyId = leseId["Aufgabe"].ToString();


                        // Hier überprüft er das den ersten angekreuzten ToDo und das aktuell gesuchte
                        // Hier dürfen keine Duplikate direkt hintereinander stehen, sonst findet er nur den Ersten und löscht ausschließlich nur den Ersten
                        if (checkedListBox1.CheckedItems.Contains(findMyId) && checkedListBox1.GetItemChecked(findMe) )
                        {
                            break;
                        }
                    }

                    // Hier wird die Aufzählung aller Elemente beendet
                    leseId.Close();

                    // Hier werden die Foreign Keys ausgetauscht mit der Id, die angekreuzt wurden
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[ToDoListTable] SET [Erledigt_Id_Fk] = 2, [Offen_Id_Fk] = 2 WHERE [Id] = @Id", cn);
                    cmd.Parameters.AddWithValue("Id", foundId);
                    cmd.ExecuteNonQuery();

                    // Hier wird das angekreuzte ToDos aus der ToDo Liste gelöscht
                    checkedListBox1.Items.RemoveAt(findMe);

                    // Hier wird der Zähler um einen zurückgesetzt, weil sonst überspringt er den nächsten Angekreuzten ToDo
                    findMe -= 1;

                    // Hier wird die gesuchte Id wieder zurückgesetzt
                    foundId = 0;
                }
            }
        }


        // Ist dafür da um in der CheckedListBox Elemente auszuwählen und anzukreuzen
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // Hier werden alle aktiven ToDos angezeigt
        private void showAllToDosButton_Click(object sender, EventArgs e)
        {

            // Hier startet er die Auflistung von neu
            checkedListBox1.Items.Clear();

            // Mit dem Befehl sucht er nach den aktiven ToDos
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[ToDoListTable] WHERE  [Erledigt_Id_Fk] = 1 AND [Offen_Id_Fk] = 1", cn);
            SqlDataReader rede = cmd.ExecuteReader();

            // Hier geht er alle aktiven ToDos durch und zeigt Sie dir im GUI an
            while (rede.Read())
            {
                string toDoAufgaben = rede["Aufgabe"].ToString();
                checkedListBox1.Items.Add(toDoAufgaben);
            }

            // Hier beendet er das Durchlesen
            rede.Close();
        }
    }
}
