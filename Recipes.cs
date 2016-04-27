using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Recipe
    {
        private string name;
        private string description;
        private string instructions;
        private int cookTime;
        private string type;
        private string catagory;
        private int prepTime;
        private long recipeID;
        List<Ingredients> ingredient = new List<Ingredients>();
        //Find out why this is happening as it does not need to. One should be made for the inventory I believe but we shall see future self.

        public Recipe()
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Instructions
        {
            get { return instructions; }
            set { instructions = value; }
        }

        public int CookTime
        {
            get { return cookTime; }
            set { cookTime = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Catagory
        {
            get { return catagory; }
            set { catagory = value; }
        }

        public int PrepTime
        {
            get { return prepTime; }
            set { prepTime = value; }
        }

        public List<Ingredients> Ingredient//Don't know why this is needed.
        {
            get{ return ingredient; }
            set{ ingredient = value; }
        }

        public Ingredients addIngredient//don't know why this is needed.
        {
            set { Ingredients.Add(value); }
        }

        public long RecipeID
        {
            get { return recipeID; }
            set { recipeID = value; }
        }
    }