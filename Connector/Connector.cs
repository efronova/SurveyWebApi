using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Survey.Models;
namespace Survey.Connector
{
    public class Connect
    {
        private string connstring;
        public Connect()
        {
            connstring = @"server=127.0.0.1;uid=root; pwd=jokeasses; database=Surveys";
        }

        public List<SurveyClass> SurveyList()
        {

            List<SurveyClass> allSurveys = new List<SurveyClass>();

            using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {

                using (MySqlCommand cmdd = connMysql.CreateCommand())
                {


                    cmdd.CommandText = "Select * from survey";
                    cmdd.CommandType = System.Data.CommandType.Text;

                    cmdd.Connection = connMysql;

                    connMysql.Open();

                    using (MySqlDataReader reader = cmdd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            allSurveys.Add(new SurveyClass
                            {
                                id = reader.GetInt32(reader.GetOrdinal("id"))
                                                                        ,
                                name = reader.GetString(reader.GetOrdinal("name"))
                                                                       ,
                                description = reader.GetString(reader.GetOrdinal("description"))
                            });
                        }
                    }
                }

                connMysql.Close();
            }
            return allSurveys;
        }


        public void AddSurvey(SurveyClass newSurvey) {
            using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {
                connMysql.Open();
                MySqlCommand command = new MySqlCommand(null, connMysql);

                // Create and prepare an SQL statement.
                command.CommandText =
                    "INSERT INTO survey (id, name, description) " +
                    "VALUES (@id, @name, @description)";
                MySqlParameter idParam = new MySqlParameter("@id", MySqlDbType.Int32, 0);
                MySqlParameter nameParam =
                    new MySqlParameter("@name", MySqlDbType.Text, 20);
                MySqlParameter descriptionParam =
                    new MySqlParameter("@description", MySqlDbType.Text, 200);
                idParam.Value = newSurvey.id;
                nameParam.Value = newSurvey.name;
                descriptionParam.Value = newSurvey.description;
                command.Parameters.Add(idParam);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(descriptionParam);



                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                command.ExecuteNonQuery();

            }


            }

        public SurveyClass SurveyById(int id) {


            using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {
                    connMysql.Open();
                    MySqlCommand cmdd = new MySqlCommand(null, connMysql);

                SurveyClass survey = new SurveyClass();

                    cmdd.CommandText = "Select * from survey where id = @id";
                    cmdd.CommandType = System.Data.CommandType.Text;
                    MySqlParameter idParam = new MySqlParameter("@id", MySqlDbType.Int32, 0);

                    idParam.Value = id;
                    cmdd.Parameters.Add(idParam);
                    cmdd.Prepare();

                    using (MySqlDataReader reader = cmdd.ExecuteReader())
                    {

                        while (reader.Read())
                        {


                            survey.id = reader.GetInt32(reader.GetOrdinal("id"));
                                                                        
                                survey.name = reader.GetString(reader.GetOrdinal("name"));
                                                                       
                                survey.description = reader.GetString(reader.GetOrdinal("description"));
                            
                        }
                        
                    }
                    return survey;
                }

            
        }

        public void UpdateSurvey(int id, SurveyClass survey) {

            using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {
                Console.WriteLine(survey.description);

                connMysql.Open();
                MySqlCommand command = new MySqlCommand(null, connMysql);

                // Create and prepare an SQL statement.
                command.CommandText =
                    "UPDATE survey SET name=@name, description=@description WHERE id=@id";
              
                MySqlParameter idParam = new MySqlParameter("@id", MySqlDbType.Int32, 0);
                MySqlParameter nameParam =
                    new MySqlParameter("@name", MySqlDbType.Text, 20);
                MySqlParameter descriptionParam =
                    new MySqlParameter("@description", MySqlDbType.Text, 200);
                idParam.Value =id;
                if (survey.name != null)
                {
                    nameParam.Value = survey.name;
                }
                else {
                    nameParam.Value = "";
                }

                if (survey.description != null)
                {
                    descriptionParam.Value = survey.description;
                }
                else
                {
                    descriptionParam.Value = "";
                }
                
                command.Parameters.Add(idParam);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(descriptionParam);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                command.ExecuteNonQuery();

            }


        }

        public void DeleteSurvey(int id)
        {

            using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {
                connMysql.Open();
                MySqlCommand command = new MySqlCommand(null, connMysql);

                // Create and prepare an SQL statement.
                command.CommandText = "DELETE from survey where id =@id";
                MySqlParameter idParam = new MySqlParameter("@id", MySqlDbType.Int32, 0);
               
                idParam.Value = id;
                command.Parameters.Add(idParam);
                
                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                command.ExecuteNonQuery();

            }

        }


    }
}
