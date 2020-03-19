using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPPizzas.Controllers
{
    public class PizzaController : Controller
    {
        private static List<Pizza> pizzas;
        public List<Pizza> Pizzas => pizzas ?? (pizzas = new List<Pizza>());

        public List<Pate> Pates = Pizza.PatesDisponibles;

        public List<Ingredient> Ingredients = Pizza.IngredientsDisponibles;

        // GET: Pizza
        public ActionResult Index()
        {
            return View(Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return RedirectToAction("Index");
            }

            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            var pizzaViewModel = new PizzaViewModel { Ingredients = Ingredients, Pates = Pates };
            return View(pizzaViewModel);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel pizzaViewModel)
        {
            try
            {
                Pizza pizza = new Pizza
                {
                    Id = pizzas.OrderByDescending(p => p.Id).Select(p => p.Id).FirstOrDefault() + 1,
                    Pate = Pates.FirstOrDefault(p => p.Id == pizzaViewModel.IdSelectedPate),
                    Nom = pizzaViewModel.Pizza.Nom
                };
                foreach (var idIngredient in pizzaViewModel.IdSelectedIngredients)
                {
                    pizza.Ingredients.Add(Ingredients.FirstOrDefault(i => i.Id == idIngredient));
                }

                pizzas.Add(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return RedirectToAction("Index");
            }

            var pizzaViewModel = 
                new PizzaViewModel { Pizza = pizza, Ingredients = Ingredients, Pates = Pates, IdSelectedIngredients = pizza.Ingredients.Select(i => i.Id).ToList() };
            return View(pizzaViewModel);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel pizzaViewModel)
        {
            try
            {
                var pizza = Pizzas.FirstOrDefault(p => p.Id == pizzaViewModel.Pizza.Id);
                if (pizza == null)
                {
                    return RedirectToAction("Index");
                }

                pizza.Ingredients.Clear();
                foreach (var idIngredient in pizzaViewModel.IdSelectedIngredients)
                {
                    pizza.Ingredients.Add(Ingredients.First(i => i.Id == idIngredient));
                }

                pizza.Pate = Pates.First(p => p.Id == pizzaViewModel.IdSelectedPate);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return RedirectToAction("Index");
            }

            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(Pizza pizza)
        {
            try
            {
                var oldPizza = Pizzas.FirstOrDefault(p => p.Id == pizza.Id);
                if (oldPizza != null)
                {
                    Pizzas.Remove(oldPizza);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
