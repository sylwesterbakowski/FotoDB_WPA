using FotoDB_WPA.Logic;
using FotoDB_WPA.Models;
using System.Collections.Generic;

namespace FotoDB_WPA.ILogic
{
    public interface IKrajManager
    {
        KrajManager AddKraj(KrajModel krajModel);
        KrajManager ChangeNazwa(int id, string newNazwa);
        KrajModel GetKraj(int id);
        List<KrajModel> GetKrajs();
        KrajManager RemoveKraj(int id);
        KrajManager UpdateKraj(KrajModel krajModel);
    }
}