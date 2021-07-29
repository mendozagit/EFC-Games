using EFC_Games.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFC_Games
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var db = new AppdbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();



            //Entities
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    var entity = new Entity()
                    {
                        MoralPerson = new MoralPerson()
                        {
                            Name = $"Empresa {i} S.A. DE C.V.",
                        }
                    };
                    db.Add(entity);
                }
                else
                {
                    var entity = new Entity()
                    {
                        PhysicalPerson = new PhysicalPerson()
                        {
                            Name = $"Persona Fisica {i}",
                        }
                    };
                    db.Add(entity);
                }

            }

            //Concepts
            for (int i = 0; i < 100; i++)
            {

                if (i % 2 == 0)
                {
                    var concept = new Concept()
                    {

                        Product = new Product()
                        {
                            Name = $"PRODUCT {i}"
                        }
                    };
                    db.Add(concept);
                }
                else
                {

                    var concept = new Concept()
                    {

                        Service = new Service()
                        {
                            Name = $"SERVICE {i}"
                        }
                    };
                    db.Add(concept);

                }

            }

            db.SaveChanges();


            Random r = new Random();

            var sales = new List<Sale>();

            for (int i = 0; i < 100; i++)
            {

                var randoId = r.Next(1, 100);

                var sale = new Sale()
                {
                    Entity = db.Entities.FirstOrDefault(x => x.EntityId == randoId)
                };


                var items = new List<SaleItem>();
                for (int j = 0; j < 5; j++)
                {

                    var randoItemId = r.Next(1, 100);
                    var concept = db.Concepts.FirstOrDefault(x => x.ConceptId == randoItemId);

                    var item = new SaleItem()
                    {
                        Concept = concept,
                        Desription = concept?.Product?.Name ?? concept?.Service?.Name,
                        Qty = randoItemId,
                        UnitPrice = randoItemId * 2
                    };

                    items.Add(item);

                }

                sale.SaleItems = items;
                sales.Add(sale);
            }

            try
            {
                var saleItemsList = new List<SaleItem>();

                foreach (var sale in sales)
                {
                    foreach (var saleItem in sale.SaleItems)
                    {
                        saleItemsList.Add(saleItem);
                    }
                }

                var itemsError = saleItemsList.Where(x => x.Concept == null).ToList();



                db.AddRange(sales);
                db.SaveChanges();
                MessageBox.Show("ok");
            }
            catch (Exception ex)
            {

                richTextBox1.Text = ex.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs ev)
        {
            var db = new AppdbContext();


            var sale = db.Sales.FirstOrDefault();

            var entity = sale.Entity;

            var moral = entity?.MoralPerson;
            var fisica = entity?.PhysicalPerson;

            var saleItems = sale.SaleItems;
            var sale2 = saleItems.FirstOrDefault()?.Sale;



            var q =
               from s in db.Sales
               join i in db.SaleItems on s.SaleId equals i.SaleId
               join e in db.Entities on s.EntityId equals e.EntityId
               join m in db.MoralPersons on e.EntityId equals m.MoralPersonId
               join f in db.PhysicalPersons on e.EntityId equals f.PhysicalPersonId into result
               from p in result.DefaultIfEmpty()
               select new { s.SaleId, Entity = p == null ? "(No products)" : p.Name };

        }
    }
}
