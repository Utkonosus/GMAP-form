using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Input;


namespace RiT_MAP_FORM
{
    public partial class Form1 : Form
    {

        double X0 = 0;
        double Y0 = 0;
        public Form1()
        {
            InitializeComponent();
        }
        GMap.NET.WindowsForms.GMapMarker marker1 = null;
        GMap.NET.WindowsForms.GMapMarker marker2 = null;
        GMap.NET.WindowsForms.GMapMarker marker3 = null;
        GMap.NET.WindowsForms.GMapMarker marker4 = null;
        GMap.NET.WindowsForms.GMapMarker marker5 = null;
        GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
        bool check = false;
        bool held1 = false;
        bool held2 = false;
        bool held3 = false;
        bool held4 = false;
        bool held5 = false;
        string servername = null;
        private void gMapControl1_Load(object sender, EventArgs e)
        {

            using (TextReader reader = File.OpenText("mapposition.config"))
            {
                X0 = Convert.ToDouble(reader.ReadLine());
                Y0 = Convert.ToDouble(reader.ReadLine());
                reader.Close();
            }
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            gMapControl1.Position = new GMap.NET.PointLatLng(X0, Y0);
            textBox1.Text = X0.ToString();
            textBox2.Text = Y0.ToString();



            this.gMapControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map_MouseDown);
            this.gMapControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.map_MouseUp);

            SqlConnection con = new SqlConnection();
            using (TextReader reader = File.OpenText("servername.config"))
            {
                servername = (reader.ReadLine());
                reader.Close();
                
            }
            con.ConnectionString = ("Server="+servername+";Database=Vehicle_loc1;" + "Trusted_Connection=True;");
            con.Open();
            SqlCommand Getvehiclename = new SqlCommand("SELECT * FROM Coordinates", con);
            SqlDataReader coReader = Getvehiclename.ExecuteReader();
            coReader.Read();
            label3.Text = coReader["VehicleName"].ToString();
            textBox3.Text = coReader["Latitude"].ToString();
            textBox4.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker1);
            }

            marker1 =
            new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);

            markers.Markers.Add(marker1);


            coReader.Read();
            label4.Text = coReader["VehicleName"].ToString();
            textBox5.Text = coReader["Latitude"].ToString();
            textBox6.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker2);
            }
            marker2 =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow_dot);


            markers.Markers.Add(marker2);


            coReader.Read();
            label5.Text = coReader["VehicleName"].ToString();
            textBox7.Text = coReader["Latitude"].ToString();
            textBox8.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker3);
            }
            marker3 =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green_dot);


            markers.Markers.Add(marker3);


            coReader.Read();
            label6.Text = coReader["VehicleName"].ToString();
            textBox9.Text = coReader["Latitude"].ToString();
            textBox10.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker4);
            }
            marker4 =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_dot);


            markers.Markers.Add(marker4);


            coReader.Read();
            label7.Text = coReader["VehicleName"].ToString();
            textBox11.Text = coReader["Latitude"].ToString();
            textBox12.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker5);
            }
            check = true;
            marker5 =
           new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
               new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
               GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple_dot);


            markers.Markers.Add(marker5);


            if (check)
            {

                gMapControl1.Overlays.Remove(markers);
                gMapControl1.Overlays.Add(markers);

            }
            else
            {
                gMapControl1.Overlays.Remove(markers);

            }
            con.Close();
            
        }

        private void gMapControl1_OnMapDrag()
        {
            textBox1.Text = Math.Round(gMapControl1.FromLocalToLatLng(313, 213).Lat, 6).ToString();
            textBox2.Text = Math.Round(gMapControl1.FromLocalToLatLng(313, 213).Lng, 6).ToString();

        }
        // WHERE VehicleID = 1"
        private void button1_Click(object sender, EventArgs e)
        {

           SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Server=" + servername + ";Database=Vehicle_loc1;" + "Trusted_Connection=True;");
            con.Open();
            SqlCommand Getvehiclename = new SqlCommand("SELECT * FROM Coordinates", con);
            SqlDataReader coReader = Getvehiclename.ExecuteReader();
            coReader.Read();
            label3.Text = coReader["VehicleName"].ToString();
            textBox3.Text = coReader["Latitude"].ToString();
            textBox4.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker1);
            }

            marker1 =
            new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);

            markers.Markers.Add(marker1);


            coReader.Read();
            label4.Text = coReader["VehicleName"].ToString();
            textBox5.Text = coReader["Latitude"].ToString();
            textBox6.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker2);
            }
            marker2 =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow_dot);


            markers.Markers.Add(marker2);


            coReader.Read();
            label5.Text = coReader["VehicleName"].ToString();
            textBox7.Text = coReader["Latitude"].ToString();
            textBox8.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker3);
            }
            marker3 =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green_dot);


            markers.Markers.Add(marker3);


            coReader.Read();
            label6.Text = coReader["VehicleName"].ToString();
            textBox9.Text = coReader["Latitude"].ToString();
            textBox10.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker4);
            }
            marker4 =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_dot);


            markers.Markers.Add(marker4);


            coReader.Read();
            label7.Text = coReader["VehicleName"].ToString();
            textBox11.Text = coReader["Latitude"].ToString();
            textBox12.Text = coReader["Longitude"].ToString();
            if (check)
            {
                markers.Markers.Remove(marker5);
            }
            check = true;
            marker5 =
           new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
               new GMap.NET.PointLatLng(Convert.ToDouble(coReader["Latitude"]), Convert.ToDouble(coReader["Longitude"])),
               GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple_dot);


            markers.Markers.Add(marker5);


            if (check)
            {

                gMapControl1.Overlays.Remove(markers);
                gMapControl1.Overlays.Add(markers);

            }
            else
            {
                gMapControl1.Overlays.Remove(markers);

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            markers.Markers.Clear();
            check = false;
        }
        
        private void gMapControl1_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, System.Windows.Forms.MouseEventArgs e)
        {
            
        }
     private void gMapControl1_OnMouseMove(GMap.NET.WindowsForms.GMapMarker item, System.Windows.Forms.MouseEventArgs e)
        {
           
        }
        private void map_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
           
             //   textBox1.Text = "OwO";
            if ((marker1.IsMouseOver)&&(e.Button == MouseButtons.Left))
            {
                held1 = true;
            }
            if ((marker2.IsMouseOver)&&(e.Button == MouseButtons.Left))
            {
                held2 = true;
            }
            if ((marker3.IsMouseOver)&&(e.Button == MouseButtons.Left))
            {
                held3 = true;
            }
            if ((marker4.IsMouseOver)&&(e.Button == MouseButtons.Left))
            {
                held4 = true;
            }
            if ((marker5.IsMouseOver)&&(e.Button == MouseButtons.Left))
            {
                held5 = true;
            }






        }
        private void map_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
          //  textBox1.Text = "UwU";
            if (held1)
            {
                markers.Markers.Remove(marker1);
                marker1 =
             new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                 new GMap.NET.PointLatLng(Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6), Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6)),
                 GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
                markers.Markers.Add(marker1);
                textBox3.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6).ToString();
                textBox4.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6).ToString();
                held1 = false;
            }
            if (held2)
            {
                markers.Markers.Remove(marker2);
                marker2 =
             new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                 new GMap.NET.PointLatLng(Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6), Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6)),
                 GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow_dot);
                markers.Markers.Add(marker2);
                textBox5.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6).ToString();
                textBox6.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6).ToString();
                held2 = false;
            }
            if (held3)
            {
                markers.Markers.Remove(marker3);
                marker3 =
             new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                 new GMap.NET.PointLatLng(Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6), Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6)),
                 GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green_dot);
                markers.Markers.Add(marker3);
                textBox7.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6).ToString();
                textBox8.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6).ToString();
                held3 = false;
            }
            if (held4)
            {
                markers.Markers.Remove(marker4);
                marker4 =
             new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                 new GMap.NET.PointLatLng(Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6), Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6)),
                 GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_dot);
                markers.Markers.Add(marker4);
                textBox9.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6).ToString();
                textBox10.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6).ToString();
                held4 = false;
            }
            if (held5)
            {
                markers.Markers.Remove(marker5);
                marker5 =
             new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                 new GMap.NET.PointLatLng(Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6), Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6)),
                 GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple_dot);
                markers.Markers.Add(marker5);
                textBox11.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat, 6).ToString();
                textBox12.Text = Math.Round(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng, 6).ToString();
                held5 = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Server=" + servername + ";Database=Vehicle_loc1;" + "Trusted_Connection=True;");
            con.Open();
            SqlCommand savecoor1 = new SqlCommand("UPDATE Coordinates SET Latitude= @Lat, Longitude = @Lng WHERE VehicleName = @VName", con);
            savecoor1.Parameters.AddWithValue("@Lat",textBox3.Text);
            savecoor1.Parameters.AddWithValue("@Lng", textBox4.Text);
            savecoor1.Parameters.AddWithValue("@VName", label3.Text);
            savecoor1.ExecuteNonQuery();
            savecoor1.Parameters.Clear();
            savecoor1.Parameters.AddWithValue("@Lat", textBox5.Text);
            savecoor1.Parameters.AddWithValue("@Lng", textBox6.Text);
            savecoor1.Parameters.AddWithValue("@VName", label4.Text);
            savecoor1.ExecuteNonQuery();
            savecoor1.Parameters.Clear();
            savecoor1.Parameters.AddWithValue("@Lat", textBox7.Text);
            savecoor1.Parameters.AddWithValue("@Lng", textBox8.Text);
            savecoor1.Parameters.AddWithValue("@VName", label5.Text);
            savecoor1.ExecuteNonQuery();
            savecoor1.Parameters.Clear();
            savecoor1.Parameters.AddWithValue("@Lat", textBox9.Text);
            savecoor1.Parameters.AddWithValue("@Lng", textBox10.Text);
            savecoor1.Parameters.AddWithValue("@VName", label6.Text);
            savecoor1.ExecuteNonQuery();
            savecoor1.Parameters.Clear();
            savecoor1.Parameters.AddWithValue("@Lat", textBox11.Text);
            savecoor1.Parameters.AddWithValue("@Lng", textBox12.Text);
            savecoor1.Parameters.AddWithValue("@VName", label7.Text);
            savecoor1.ExecuteNonQuery();
            savecoor1.Parameters.Clear();
            con.Close();
        }
    }
}