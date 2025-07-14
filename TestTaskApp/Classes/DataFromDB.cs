using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestTaskApp.Classes
{
    internal class DataFromDB
    {
        public Warehouse LoadData()
        {
            Warehouse warehouse = new Warehouse();
            Pallet pallet = new Pallet();
            Box box = new Box();
            int countRows;
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            try
            {
                connection.Open();
                string queryGetCount = "GetCountRowPallet";
                SqlCommand sqlCommandCount = new SqlCommand(queryGetCount, connection);
                sqlCommandCount.CommandType = System.Data.CommandType.StoredProcedure;
                countRows = Convert.ToInt32(sqlCommandCount.ExecuteScalar());
                for (int i = 1; i <= countRows; i++)
                {
                    string queryGetPallet = "GetPalletById";
                    SqlCommand sqlCommandPallet = new SqlCommand(queryGetPallet, connection);
                    sqlCommandPallet.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommandPallet.Parameters.AddWithValue("@id_pal", i);
                    SqlDataReader readerPallet = sqlCommandPallet.ExecuteReader();
                    if(readerPallet.HasRows)
                    {
                        while (readerPallet.Read())
                        {
                            pallet = new Pallet
                            {
                                Id = Convert.ToInt32(readerPallet[0]),
                                Width = Convert.ToDouble(readerPallet[1]),
                                Height = Convert.ToDouble(readerPallet[2]),
                                Deep = Convert.ToInt32(readerPallet[3])
                            };
                        }
                    }
                    readerPallet.Close();
                    string queryGetBox = "GetBoxesInPallet";
                    SqlCommand sqlCommandBox = new SqlCommand(queryGetBox, connection);
                    sqlCommandBox.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommandBox.Parameters.AddWithValue("@id_pal", i);
                    SqlDataReader readerBox = sqlCommandBox.ExecuteReader();
                    if (readerBox.HasRows)
                    {
                        while (readerBox.Read())
                        {
                            box = new Box
                            {
                                Id = Convert.ToInt32(readerBox[0]),
                                Width = Convert.ToDouble(readerBox[1]),
                                Height = Convert.ToDouble(readerBox[2]),
                                Deep = Convert.ToDouble(readerBox[3]),
                                Weight = Convert.ToDouble(readerBox[4]),
                                ProductionDate = Convert.ToDateTime(readerBox[5]),
                                ExpirationDate = Convert.ToDateTime(readerBox[5]).AddDays(100)
                            };
                            pallet.AddBox(box);
                        }
                    }
                    warehouse.AddPallet(pallet);
                    readerBox.Close();
                }
                return warehouse;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return warehouse;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
