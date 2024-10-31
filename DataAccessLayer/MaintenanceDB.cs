using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DomainEntities;


namespace DataAccessLayer
{
    public class MaintenanceDB
    {
        private readonly ConnectionClass _ConHelper;

        public MaintenanceDB(string connectionString)
        {
            _ConHelper = new ConnectionClass(connectionString);
        }



        public List<MaintenanceEntities> GetMaintenanceData(string storedProcedureName)
        {
            List<MaintenanceEntities> results = new List<MaintenanceEntities>();

            try
            {
                _ConHelper.OpenConnection();

                using (SqlCommand command = new SqlCommand(storedProcedureName, _ConHelper.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaintenanceEntities maintenance = new MaintenanceEntities
                            {
                                id = Convert.ToInt32(reader["id"]),
                                date = Convert.ToDateTime(reader["date"]),
                                description = reader["description"].ToString(),
                                type = reader["type"].ToString(),
                                notes = reader["notes"].ToString(),
                                model = reader["Model"].ToString(),
                                vehicleID = Convert.ToInt32(reader["vehicleID"])
                            };
                            results.Add(maintenance);
                        }
                    }
                }
            }
            finally
            {
                _ConHelper.CloseConnection();
            }

            return results;
        }

        public List<VehicleEntities> GetVehiclesData(string storedProcedureName)
        {
            List<VehicleEntities> results = new List<VehicleEntities>();

            try
            {
                _ConHelper.OpenConnection();

                using (SqlCommand command = new SqlCommand(storedProcedureName, _ConHelper.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VehicleEntities vehicles = new VehicleEntities
                            {
                                id = Convert.ToInt32(reader["id"]),

                                model = reader["model"].ToString(),
                                color = reader["color"].ToString(),
                                number = reader["number"].ToString(),
                              
                            };
                            results.Add(vehicles);
                        }
                    }
                }
            }
            finally
            {
                _ConHelper.CloseConnection();
            }

            return results;
        }


        public bool InsertMaintenanceData(MaintenanceEntities maintenance,string storedProcedureName)
        {
            try 
            {
                _ConHelper.OpenConnection();

                using (SqlCommand command = new SqlCommand(storedProcedureName, _ConHelper.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    command.Parameters.AddWithValue("@Id", maintenance.id);
                    command.Parameters.AddWithValue("@Date", maintenance.date);
                    command.Parameters.AddWithValue("@Description", maintenance.description);
                    command.Parameters.AddWithValue("@Notes", maintenance.notes);
                    command.Parameters.AddWithValue("@VehicleID", maintenance.vehicleID);
                    command.Parameters.AddWithValue("@Type", maintenance.type);

                    // Execute the command
                    command.ExecuteNonQuery();
                    return true; // Indicating success
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) as needed
                return false; // Indicating failure
            }
            finally
            {
                _ConHelper.CloseConnection();
            }
        }

        public bool DeleteMaintenanceRecord(int id, string storedProcedureName)
        {
            try
            {
                _ConHelper.OpenConnection();

                using (SqlCommand command = new SqlCommand(storedProcedureName, _ConHelper.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    command.Parameters.AddWithValue("@Id", id);
                   

                    // Execute the command
                    command.ExecuteNonQuery();
                    return true; // Indicating success
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) as needed
                return false; // Indicating failure
            }
            finally
            {
                _ConHelper.CloseConnection();
            }
        }
    }
}
