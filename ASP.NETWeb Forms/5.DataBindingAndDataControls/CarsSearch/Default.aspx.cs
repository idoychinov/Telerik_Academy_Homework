using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace CarsSearch
{
    public partial class Default : System.Web.UI.Page
    {
        private List<Producer> producers = new List<Producer>()
            {
                new Producer(){Name = "BMW", Models = {"X3", "X5", "Z4"}},
                new Producer(){Name = "Mercedes", Models = {"S-Class", "CLS-Class", "SLK-Class","GLK-Class"}},
                new Producer(){Name = "Opel", Models = {"Corsa", "Tigra", "Astra","Vectra"}},
                new Producer(){Name = "Audi", Models = {"A3", "A4", "A6","A8"}}
            };

        private List<Extra> extrasList = new List<Extra>() { new Extra("Leather seats"), new Extra("Climatronic"), new Extra("ABS") };

        public void Producer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = this.Producer.SelectedValue;
            this.Model.DataSource = producers.Where(x => x.Name == selectedCategory).FirstOrDefault().Models;
            this.Model.DataBind();
        }

        public void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string extras=string.Empty;

            foreach (ListItem item in this.Extras.Items)
            {
                if(item.Selected)
                {
                    extras += item.Text + " ";
                }
            }
            
            this.Result.Text = this.Producer.SelectedValue + " " + this.Model.SelectedValue + " " + extras + this.EngineType.SelectedValue;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                return;
            }
            this.Producer.DataSource = producers;
            this.Producer.DataBind();
            this.Extras.DataSource = extrasList;
            this.Extras.DataBind();
            this.EngineType.DataSource = new string[] { "V6", "V8", "unknown" };
            this.EngineType.DataBind();
        }
    }
}