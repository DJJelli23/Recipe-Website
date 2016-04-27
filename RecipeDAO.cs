using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DAO;
using System.Collections;

    public class RecipeDAO : BaseDAO
    {
        SqlConnection con;
        String sql = "";

        public RecipeDAO()
        {

        }

        public ArrayList select(String sql)
        {
            con = connect("COOK_BOOK");
            this.sql = sql;
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader reader = com.ExecuteReader();
            ArrayList recNames = new ArrayList();
            Recipe c = null;
            while (reader.Read())
            {
                c = new Recipe();
                c.RecipeID = Convert.ToInt32(reader["recid"]);
                c.Name = Convert.ToString(reader["name"]);
                c.Description = Convert.ToString(reader["description"]);
                c.Instructions = Convert.ToString(reader["instruction"]);
                c.CookTime = Convert.ToInt32(reader["cooktime"]);
                c.Type = Convert.ToString(reader["type"]);
                c.Catagory = Convert.ToString(reader["catagory"]);
                c.PrepTime = Convert.ToInt32(reader["preptime"]);
                recNames.Add(c);
            }
            /*need to create a nested loop to input the ingredients capturing the parent and parent objects*/
            if (recNames.Count != 0)
            {

            }
            close();
            return recNames;
        }

        public int insert(Recipe c)
        {
            SqlParameter idParam = new SqlParameter("@recid", SqlDbType.BigInt, 10);
            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.Text, 50);
            SqlParameter descripParam = new SqlParameter("@description", SqlDbType.Text, 100);
            SqlParameter intruParam = new SqlParameter("@instruction", SqlDbType.Text, 1000);
            SqlParameter cookTiParam = new SqlParameter("@cookTime", SqlDbType.Int, 20);
            SqlParameter typeParam = new SqlParameter("@type", SqlDbType.Text, 20);
            SqlParameter cataParam = new SqlParameter("@catagory", SqlDbType.Text, 20);
            SqlParameter prepTiParam = new SqlParameter("@prepTime", SqlDbType.Int, 20);
            idParam.Value = c.RecipeID;
            nameParam.Value = c.Name;
            descripParam.Value = c.Description;
            intruParam.Value = c.Instructions;
            cookTiParam.Value = c.CookTime;
            typeParam.Value = c.Type;
            cataParam.Value = c.Catagory;
            prepTiParam.Value = c.PrepTime;
            con = connect("COOK_BOOK");
            sql = "insert into Recipes (name,description,instruction,cooktime,type,catagory,preptime) values (@name, @description, @instruction, @cooktime, @type, @catagory, @preptime)";
            SqlCommand com = new SqlCommand(null, con);
            com.CommandText = sql;
            com.Parameters.Add(idParam);
            com.Parameters.Add(nameParam);
            com.Parameters.Add(descripParam);
            com.Parameters.Add(intruParam);
            com.Parameters.Add(cookTiParam);
            com.Parameters.Add(typeParam);
            com.Parameters.Add(cataParam);
            com.Parameters.Add(prepTiParam);
            com.Prepare();
            int res = com.ExecuteNonQuery();
            close();
            return res;
        }

        public int update(Recipe c)
        {
            SqlParameter idParam = new SqlParameter("@recid", SqlDbType.BigInt, 10);
            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.Text, 50);
            SqlParameter descripParam = new SqlParameter("@description", SqlDbType.Text, 100);
            SqlParameter intruParam = new SqlParameter("@instruction", SqlDbType.Text, 1000);
            SqlParameter cookTiParam = new SqlParameter("@cookTime", SqlDbType.Int, 20);
            SqlParameter typeParam = new SqlParameter("@type", SqlDbType.Text, 20);
            SqlParameter cataParam = new SqlParameter("@catagory", SqlDbType.Text, 20);
            SqlParameter prepTiParam = new SqlParameter("@prepTime", SqlDbType.Int, 20);
            idParam.Value = c.RecipeID;
            nameParam.Value = c.Name;
            descripParam.Value = c.Description;
            intruParam.Value = c.Instructions;
            cookTiParam.Value = c.CookTime;
            typeParam.Value = c.Type;
            cataParam.Value = c.Catagory;
            prepTiParam.Value = c.PrepTime;
            con = connect("COOK_BOOK");
            sql = "update Recipes set name = @name where recid = @recid"; //description = @description, instruction = @instruction, cooktime = @cooktime, type = @type, catagory = @catagory, preptime = @preptime where recipeid = @recid";
            SqlCommand com = new SqlCommand(null, con);
            com.CommandText = sql;
            com.Parameters.Add(idParam);
            com.Parameters.Add(nameParam);
            com.Parameters.Add(descripParam);
            com.Parameters.Add(intruParam);
            com.Parameters.Add(cookTiParam);
            com.Parameters.Add(typeParam);
            com.Parameters.Add(cataParam);
            com.Parameters.Add(prepTiParam);
            com.Prepare();
            int res = com.ExecuteNonQuery();
            return res;
        }

        public long delete(long id)
        {
            SqlParameter idParam = new SqlParameter("@recid", SqlDbType.BigInt, 10);
            idParam.Value = id;
            con = connect("COOK_BOOK");
            sql = "delete from Recipes where recid = @recid";
            SqlCommand com = new SqlCommand(null, con);
            com.CommandText = sql;
            com.Parameters.Add(idParam);
            com.Prepare();
            int res = com.ExecuteNonQuery();
            com.CommandText = "select * from Recipes order by recid";
            close();
            return res;
        }

        public void cleanup()
        {
            if (con != null)
                con.Close();
        }
    }