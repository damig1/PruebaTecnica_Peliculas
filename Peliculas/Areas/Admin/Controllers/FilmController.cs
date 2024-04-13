using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Areas.Admin.Controllers
{
    public class FilmController : Controller
    {
        [HttpGet]
        public ActionResult List(string firstLetter = null, bool clearFilter = true)
        {
            Models.Film.List model = new Models.Film.List();
            model.GenreList = new SelectList(Business.Genre.GetGenreList(), "GenreId", "Name", model.GenreList);
            try
            {
                if (!clearFilter)
                {
                    Common.Common.LoadFilter<Models.Film.List>(ref model);
                }
                else
                {
                    Common.Common.SaveFilter<Models.Film.List>(model);
                }

                if (!string.IsNullOrWhiteSpace(model.SearchFields.Keyword))
                {
                    model.FilmList = Business.Film.GetListDataSource(model.SearchFields.Keyword, model.SearchFields.GenreId, firstLetter);
                }
            }
            catch (Exception ex)
            {
                Common.Common.LogAndShowError(ex, "Error cargando página. Por favor intente nuevamente");
            }
            return View(model);
        }

        [HttpPost]
        public PartialViewResult List(Models.Film.List model, string firstLetter)
        {
            model.GenreList = new SelectList(Business.Genre.GetGenreList(), "GenreId", "Name", model.GenreList);
            try
            {
                model.FilmList = Business.Film.GetListDataSource(model.SearchFields.Keyword, model.SearchFields.GenreId, firstLetter);
            }
            catch (Exception ex)
            {
                Common.Common.LogAndShowError(ex, "Error cargando página, por favor intente nuevamente.");
            }
            return PartialView("List", model);
        }

        [HttpGet]
        public ActionResult Edit(int? filmId)
        {
            Models.Film.Edit model = new Models.Film.Edit();
            model.GenreList = new SelectList(Business.Genre.GetGenreList(), "GenreId", "Name", model.GenreId);
            try
            {
                model.Enabled = true;
                if (filmId != null)
                {
                    DTO.Film film = Business.Film.Load(filmId.Value);
                    model.SetFilm(film);
                }
            }
            catch (Exception ex)
            {
                Common.Common.LogAndShowError(ex, "Error cargando página, por favor intente nuevamente.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Film.Edit model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = string.Join("<br>", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    Common.Common.ShowErrorMessage(errors);
                    return View(model);
                }
                DTO.Film film = new DTO.Film();

                if (model.FilmId != 0)
                {
                    film = Business.Film.Load(model.FilmId);
                }

                model.GetFilm(ref film);

                if (Business.Film.FilmExistsByName(model.Name) && model.FilmId == 0)
                {
                    Common.Common.ShowErrorMessage("Una película con el mismo nombre ya existe");
                    return RedirectToAction("Edit", "Film", new { Area = "Admin" });
                }
                else
                {
                    film = Business.Film.Save(film);
                    Common.Common.ShowSuccessMessage("Pelicula guardada correctamente");
                    return RedirectToAction("List", "Film", new { Area = "Admin" });
                }   
            }
            catch (Exception ex)
            {
                Common.Common.LogAndShowError(ex, "Error cargando página, por favor intente nuevamente.");
            }
            return View(model);
        }

        public ActionResult Delete(int filmId)
        {
            try
            {
                Business.Film.DeleteFilm(filmId);
                Common.Common.ShowSuccessMessage("Pelicula eliminada correctamente");
            }
            catch (Exception ex)
            {
                Common.Common.LogAndShowError(ex, "Error cargando página, por favor intente nuevamente.");
            }
            return RedirectToAction("List", "Film", new { Area = "Admin"});
        }
    }
}