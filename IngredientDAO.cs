using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using DAO;

    public class IngredientDAO : BaseDAO
    {
        SqlConnection con;
        String sql = "";

        public IngredientDAO()
        {

        }

        public ArrayList select(String sql)
        {
            con = connect("COOK_BOOK");
            this.sql = sql;
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader reader = com.ExecuteReader();
            ArrayList ingNames = new ArrayList();
            Ingredients c = null;
            while (reader.Read())
            {
                c = new Ingredients();
                reader.Read();
                c.IngredientID = Convert.ToInt32(reader["ingid"]);
                c.Name = Convert.ToString(reader["name"]);
                c.Quanity = Convert.ToInt32(reader["quanity"]);
                c.Unit = Convert.ToString(reader["unit"]);
                ingNames.Add(c);
            }
            return ingNames;
        }

        public int insert(Ingredients i)
        {
            SqlParameter idParam = new SqlParameter("@ingid", SqlDbType.BigInt, 10);
            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.Text, 50);
            SqlParameter quanParam = new SqlParameter("@quanity", SqlDbType.Text, 100);
            SqlParameter unitParam = new SqlParameter("@unit", SqlDbType.Text, 1000);
            idParam.Value = i.IngredientID;
            nameParam.Value = i.Name;
            quanParam.Value = i.Quanity;
            unitParam.Value = i.Unit;
            con = connect("COOK_BOOK");
            sql = "insert into Ingredients (name,quanity,unit) values (@name, @quanity, @unit)";
            SqlCommand com = new SqlCommand(null, con);
            com.CommandText = sql;
            com.Parameters.Add(nameParam);
            com.Parameters.Add(quanParam);
            com.Parameters.Add(unitParam);
            com.Prepare();
            int res = com.ExecuteNonQuery();
            return res;
        }

        public int update(Ingredients i)
        {
            SqlParameter idParam = new SqlParameter("@ingid", SqlDbType.BigInt, 10);
            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.Text, 50);
            SqlParameter quanParam = new SqlParameter("@quanity", SqlDbType.Text, 100);
            SqlParameter unitParam = new SqlParameter("@unit", SqlDbType.Text, 1000);
            idParam.Value = i.IngredientID;
            nameParam.Value = i.Name;
            quanParam.Value = i.Quanity;
            unitParam.Value = i.Unit;
            con = connect("COOK_BOOK");
            sql = "update into Ingredients set name = @name, quanity = @quanity, unit = @unit where ingredientid = @ingid";
            SqlCommand com = new SqlCommand(null, con);
            com.CommandText = sql;
            com.Parameters.Add(nameParam);
            com.Parameters.Add(quanParam);
            com.Parameters.Add(unitParam);
            com.Prepare();
            int res = com.ExecuteNonQuery();
            return res;
        }

        public long delete(long id)
        {
            SqlParameter idParam = new SqlParameter("@ingid", SqlDbType.BigInt, 10);
            idParam.Value = id;
            con = connect("COOK_BOOK");
            sql = "delete from Ingredients where ingredientid=@ingid";
            SqlCommand com = new SqlCommand(null, con);
            com.CommandText = sql;
            com.Parameters.Add(idParam);
            com.Prepare();
            int res = com.ExecuteNonQuery();
            return res;
        }

        public void cleanup()
        {
            if (con != null)
                con.Close();
        }
    }