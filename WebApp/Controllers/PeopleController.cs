using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;
using Interfaces;
using DAL.Repositories;

namespace WebApp.Controllers
{
    public class PeopleController : Controller
    {
        //private CooperationContext db = new CooperationContext();
        //Selle asemel, et kutsuda välja andmebaasiühendus, kasutame siinkohal reposid
        //private IPersonRepository _personRepository = new PersonRepository(new CooperationContext());
        private readonly IUow _uow;
            //Sõltuvused

        public PeopleController(IUow uow)
        {
            _uow = uow;
        }
        // GET: People
        public ActionResult Index()
        {
            return View(_uow.People.All);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _uow.People.Find(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName,Gender,DateOfBirth,IdentificationNumber,Username,Password,EMailAddress")] Person person)
        {
            if (ModelState.IsValid)
            {
                _uow.People.Add(person);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _uow.People.Find(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,Gender,DateOfBirth,IdentificationNumber,Username,Password,EMailAddress")] Person person)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(person).State = EntityState.Modified;
                _uow.People.Update(person);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _uow.People.Find(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.People.Remove(id);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
