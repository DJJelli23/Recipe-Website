using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

    public class Ingredients
    {
        private string name;
        private double quanity;
        private int ingredientID;
        /*
         * Have check boxes available for the different types of incredients checking for 
         * if the item needs to be diced minced or if it is a dry ingredient.
         * Have them have additional ways that the items can be used in cooking and a way to make the choice
         * disappear when done with the ingredient but a way to edit it if they feel they did it wrong.
         */
        public double Quanity
        {
            get { return quanity; }
            set { quanity = value; }
        }
        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Ingredients()
        {
            
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int IngredientID
        {
            get { return ingredientID; }
            set { ingredientID = value; }
        }

        internal static void Add(Ingredients value)
        {
            throw new NotImplementedException();
        }
    }