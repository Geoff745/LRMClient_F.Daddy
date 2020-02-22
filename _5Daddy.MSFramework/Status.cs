using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;

namespace _5Daddy.MSFramework
{
    public partial class Status : UserControl
    {
        public Status()
        {
            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            DataTable dt = ConvertListToDataTable(LRM_Page.AltLS);

            //Get the DISTINCT Countries.
            List<string> countries = (from p in dt.AsEnumerable()
                                      select p.Field<string>("ShipCountry")).Distinct().ToList();

            //Remove the Default Series.
            if (Chart1.Series.Count() == 1)
            {
                Chart1.Series.Remove(Chart1.Series[0]);
            }

            //Loop through the Countries.
            foreach (string country in countries)
            {

                //Get the Year for each Country.
                int[] x = (from p in dt.AsEnumerable()
                           where p.Field<string>("ShipCountry") == country
                           orderby p.Field<int>("Year") ascending
                           select p.Field<int>("Year")).ToArray();

                //Get the Total of Orders for each Country.
                int[] y = (from p in dt.AsEnumerable()
                           where p.Field<string>("ShipCountry") == country
                           orderby p.Field<int>("Year") ascending
                           select p.Field<int>("Total")).ToArray();

                //Add Series to the Chart.
                Chart1.Series.Add(new Series(country));
                Chart1.Series[country].IsValueShownAsLabel = true;
                Chart1.Series[country].BorderWidth = 3;
                Chart1.Series[country].ChartType = SeriesChartType.Line;
                Chart1.Series[country].Points.DataBindXY(x, y);
            }

            Chart1.Legends[0].Enabled = true;
        }

        static DataTable ConvertListToDataTable(List<double[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }
    }
}
