using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using DAO;
using System.Collections;

    public class RecipeDS : RecipeDSInterface
    {
        private RecipeDAO recDao;

        public RecipeDS()
        {
            recDao = new RecipeDAO();
        }

        public int insertRecipe(Recipe r)
        {
            return recDao.insert(r);
        }

        public long deleteRecipe(Recipe r)
        {
            return recDao.delete(r.RecipeID);
        }

        public int updateRecipe(Recipe r)
        {
            return recDao.update(r);
        }

        public ArrayList findRecipeByName(Recipe r)
        {
            String sql = "select * from Recipes where name like '%" + r.Name + "%'";
            return recDao.select(sql);
        }
    }
