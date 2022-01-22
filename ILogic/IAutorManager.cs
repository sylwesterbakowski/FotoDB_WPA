using FotoDB_WPA.Logic;
using FotoDB_WPA.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FotoDB_WPA.ILogic
{
    public interface IAutorManager
    {
        IEnumerable<SelectListItem> GetListKrajs();
        AutorManager AddAutor(AutorModel autorModel);
        AutorManager ChangeImie(int id, string newImie);
        AutorManager ChangeKraj(int id, int id_kraj);
        AutorManager ChangeNazwisko(int id, string newNazwisko);
        AutorModel GetAutor(int id);
        List<AutorModel> GetAutors();
        AutorManager RemoveAutor(int id);
        AutorManager UpdateAutor(AutorModel autorModel);
    }
}