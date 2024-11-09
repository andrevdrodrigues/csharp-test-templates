using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTemplates._1___Unit.Interfaces;

namespace TestTemplates._1___Unit.Classes.Business
{
    class MyDataAccessClass
    {
        private IDbConnectionFactory connectionFactory;

        public MyDataAccessClass(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public void Insert(string firstname, string lastname)
        {
            var query = $"INSERT INTO `sakila`.`actor`(`first_name`,`last_name`) VALUES('" + firstname + "','" + lastname + "')";
            Console.WriteLine(query);
            using (var connection = connectionFactory.CreateConnection()) {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    Console.WriteLine("Established connection");
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Insert query succesfully executed.");
                    connection.Close();
                }
            }
        }

        public IList<Customer> selectAll()
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                const string sql = "SELECT Id, Name FROM Customer";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        IList<Customer> rows = new List<Customer>();
                        while (reader.Read())
                        {
                            rows.Add(new Customer
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            });
                        }
                        return rows;
                    }
                }
            }
        }

        public void Delete(int id)
        {
            var query = $"DELETE FROM `sakila`.`actor` WHERE `id`='"+id;
            Console.WriteLine(query);
            using (var connection = connectionFactory.CreateConnection())
            {

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    Console.WriteLine("Established connection");
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Delete query succesfully executed.");
                    connection.Close();
                }
            }
        }

        public void Update(int id, string firstname)
        {
            var query = $"UPDATE `sakila`.`actor` SET `first_name` = '" + firstname + "' WHERE `id`='" + id;
            Console.WriteLine(query);
            using (var connection = connectionFactory.CreateConnection())
            {

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    Console.WriteLine("Established connection");
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Update query succesfully executed.");
                    connection.Close();
                }
            }
        }

    }
}
