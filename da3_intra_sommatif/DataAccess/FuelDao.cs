using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace da3_intra_sommatif.DataAccess
{
    public class FuelDao
    {
        private SqlConnection connexion;
        private DataTable table;
        private SqlDataAdapter dataAdapter;
        private String tableName = "Fuels";


        public FuelDao() 
        {
            this.connexion=DbConnexionManager.GetConnection();  
            this.dataAdapter=this.CreateDataAdapter();
            this.table=new DataTable(tableName);
        }

        public DataTable GetData() 
        {
            return this.table;
        }

        public void ReloadDataTable() 
        {
           
                this.table.Clear();
                this.dataAdapter.Fill(this.table);
           
            DataColumn idCol=this.table.Columns["Id"]??throw new Exception("'Id' introuvable");
            DataColumn nameCol=this.table.Columns["Name"]??throw new Exception("'Name' introuvable");
            DataColumn usageCol=this.table.Columns["UsageDescription"] ??throw new Exception("'UsageDescription' introuvable");
            DataColumn joulesPerKgCol=this.table.Columns["JoulesPerKg"] ??throw new Exception("'JoulesPerKg' introuvable");
            DataColumn DateCreatedCol=this.table.Columns["DateCreated"]??throw new Exception("'DateCreated' introuvable");

            idCol.AutoIncrement = true;
            idCol.AutoIncrementSeed= -1;
            idCol.AutoIncrementStep= -1;
            idCol.ReadOnly = true;
            
            DateCreatedCol.ReadOnly = true;

            nameCol.AllowDBNull = false;
            usageCol.AllowDBNull = false;
            joulesPerKgCol.AllowDBNull = false;

        }

        public void SaveChanges() 
        {
            if(this.connexion.State!=ConnectionState.Open) 
            {
                this.connexion.Open();
            }
            this.dataAdapter.Update(this.table);
        }

        public SqlDataAdapter CreateDataAdapter() 
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            //selectCommand
            SqlCommand selectCommand = this.connexion.CreateCommand();
            selectCommand.CommandText = $"SELECT * FROM {tableName} ;";
            adapter.SelectCommand = selectCommand;

            //insertCommand
            SqlCommand insertCommand = this.connexion.CreateCommand();
            insertCommand.CommandText = $"INSERT INTO {this.tableName} (Name, UsageDescription, JoulesPerKg) " +
                $"VALUES (@name, @usageDescription, @joulesPerKg ) ;SELECT * FROM {this.tableName} WHERE Id = SCOPE_IDENTITY(); ";
            insertCommand.Parameters.Add("@name",SqlDbType.NVarChar,32,"Name");
            insertCommand.Parameters.Add("@usageDescription",SqlDbType.NVarChar,32,"UsageDescription");
            insertCommand.Parameters.Add("@joulesPerKg", SqlDbType.NVarChar,32, "JoulesPerKg");

            insertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            adapter.InsertCommand = insertCommand;


            //updateCommand
            SqlCommand updateCommand = this.connexion.CreateCommand();
            updateCommand.CommandText = $"UPDATE {this.tableName} SET " +
                $"Name= @name ," +
                $"UsageDescription = @usageDescription , " +
                $"JoulesPerKg = @joulesPerKg " +
                $"WHERE Id= @id " +
                $" AND Name = @oldName " +
                $"AND UsageDescription = @oldUsageDescription " +
                $"AND JoulesPerKg = @oldJoulesPerKg ;";

            updateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 32, "Name");
            updateCommand.Parameters.Add("@usageDescription", SqlDbType.NVarChar, 255, "UsageDescription");
            updateCommand.Parameters.Add("@joulesPerKg", SqlDbType.BigInt, 64, "JoulesPerKg");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            updateCommand.Parameters.Add("@oldName", SqlDbType.NVarChar, 32, "Name").SourceVersion = DataRowVersion.Original;
            updateCommand.Parameters.Add("@oldUsageDescription", SqlDbType.NVarChar, 255, "UsageDescription").SourceVersion = DataRowVersion.Original;
            updateCommand.Parameters.Add("@oldJoulesPerKg", SqlDbType.BigInt, 0, "JoulesPerKg").SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = updateCommand;



            //deleteCommand
            SqlCommand deleteCommand = this.connexion.CreateCommand();
            deleteCommand.CommandText = $"DELETE FROM {this.tableName} " +
                $"WHERE Id = @id ;";

            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            adapter.DeleteCommand = deleteCommand;


            return adapter;
        }

    }
}
