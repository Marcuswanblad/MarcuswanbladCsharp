using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;


namespace Uppgift3WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            List<Accommodation> bostonList = GetList("select * from boston where room_type = 'private room'");
            List<Accommodation> amsterdamList = GetList("select * from amsterdam where room_type = 'private room'");
            List<Accommodation> barcelonaList = GetList("select * from barcelona where room_type = 'private room'");

            List<Accommodation> bostonListclean = GetList("select * from boston where overall_satisfaction < 4.5");
            List<Accommodation> amsterdamListclean = GetList("select * from amsterdam where overall_satisfaction < 4.5");
            List<Accommodation> barcelonaListclean = GetList("select * from barcelona where overall_satisfaction < 4.5");


            //Skapa Cityobjekt
            City Boston = new City ( "Boston", 100000, 3000, bostonList);
            City Amsterdam = new City("Amsterdam", 200000, 3000, amsterdamList);
            City Barcelona = new City("Barcelona", 100000, 3000, barcelonaList);

            //Skapa Lista av Cities
            List<City> Cities = new List<City> { Boston, Amsterdam, Barcelona };

            //CSkapa CountryObjekt
            Country Spain = new Country("Spain", 30000000, 20000, Cities);
            Country Holland = new Country("Netherlands", 9000000, 50000, Cities);
            Country Usa = new Country("Spain", 30000000, 20000, Cities);

           

            chart1.Titles.Add ("Barcelona price");
            chart1.ChartAreas[0].AxisX.Title = "Room";
            chart1.ChartAreas[0].AxisY.Title = "Price";

            chart2.Titles.Add("Amsterdam price");
            chart2.ChartAreas[0].AxisX.Title = "Room";
            chart2.ChartAreas[0].AxisY.Title = "Price";
        
            chart3.Titles.Add("Boston price");
            chart3.ChartAreas[0].AxisX.Title = "Room";
            chart3.ChartAreas[0].AxisY.Title = "Price";

            chart4.Titles.Add("Barcelona price/overall satisfaction");
            chart4.ChartAreas[0].AxisX.Title = "Price";
            chart4.ChartAreas[0].AxisY.Title = "Overall Satisfation";

            chart5.Titles.Add("Amsterdam price/overall satisfaction");
            chart5.ChartAreas[0].AxisX.Title = "Price";
            chart6.ChartAreas[0].AxisY.Title = "Overall Satisfation";

            chart6.Titles.Add("Boston price/overall satisfaction");
            chart6.ChartAreas[0].AxisX.Title = "Price";
            chart6.ChartAreas[0].AxisY.Title = "Overall Satisfation";

            
            //Histogram 1,2 och 3
            foreach (Accommodation a in barcelonaList)
            {
               chart1.Series["Series1"].Points.AddY(a.Price);
                    }
                    
            
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
            

            foreach (Accommodation a in amsterdamList)
            {
                chart2.Series["Series1"].Points.AddY(a.Price);
            }

            chart2.Series["Series1"].ChartType = SeriesChartType.Column;

            foreach (Accommodation a in bostonList)
            {
                chart3.Series["Series1"].Points.AddY(a.Price);
            }

            chart3.Series["Series1"].ChartType = SeriesChartType.Column;

            //Scatterplott 1,2 och 3 
            foreach (Accommodation a in barcelonaListclean)
            {
                chart4.Series["Series1"].Points.AddXY(a.Price, a.Overall_satisfaction);
            }

            chart4.Series["Series1"].ChartType = SeriesChartType.Point;

            foreach (Accommodation a in amsterdamListclean)
            {
                chart5.Series["Series1"].Points.AddXY(a.Price, a.Overall_satisfaction);
            }

            chart5.Series["Series1"].ChartType = SeriesChartType.Point;

            foreach (Accommodation a in bostonListclean)
            {
                chart6.Series["Series1"].Points.AddXY(a.Price, a.Overall_satisfaction);
            }

            chart6.Series["Series1"].ChartType = SeriesChartType.Point;


        }
        //Metod för att fylla Accommodation från SQL
        private List<Accommodation> GetList(string inputQuerry)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-R2GCFSO\\SQL2017;Initial Catalog=Airbnbtest;Integrated Security=True";
            conn.Open();

            SqlCommand myQuerry = new SqlCommand(inputQuerry, conn);

            SqlDataReader MyReader = myQuerry.ExecuteReader();
            List<Accommodation> Accommodations = new List<Accommodation>();


            //Så länge det finns rader så läser den in dom.
            while (MyReader.Read())
            {

                int Room_id = Convert.ToInt32(MyReader["room_id"]);
                int Host_id = Convert.ToInt32(MyReader["host_id"]);
                string Room_type = (string)MyReader["Room_type"];
                string Borough = MyReader["borough"].ToString();
                string NeighborHood = (string)MyReader["neighborhood"];
                int Reviews = (int)MyReader["reviews"];
                double Overall_Satisfaction = double.TryParse(MyReader["Overall_Satisfaction"].ToString(), out double OSD) ? OSD : 0;
                int Accommodates = Convert.ToInt32(MyReader["accommodates"]);
                double Bedrooms = double.TryParse(MyReader["bedrooms"].ToString(), out double BedroomsI) ? BedroomsI : 0;
                double Price = double.TryParse(MyReader["Price"].ToString(), out double PriceI) ? PriceI : 0;
                double Minstay = double.TryParse(MyReader["minstay"].ToString(), out double MinstayI) ? MinstayI : 0;
                double Latitude = double.TryParse(MyReader["latitude"].ToString(), out double LatitudeD) ? LatitudeD : 0;
                double Longitude = double.TryParse(MyReader["longitude"].ToString(), out double LongitudeD) ? LongitudeD : 0;
                string Last_modified = MyReader["last_modified"].ToString();

                Accommodations.Add(new Accommodation(Room_id
                    , Host_id
                    , Room_type
                    , Borough
                    , NeighborHood
                    , Reviews
                    , Overall_Satisfaction
                    , Accommodates
                    , (int)Bedrooms
                    , (int)Price
                    , (int)Minstay
                    , Latitude
                    , Longitude
                    , Last_modified));
            }
            return Accommodations;
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
