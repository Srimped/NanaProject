using System.Diagnostics;
using NanaProject.Models;

namespace NanaProject.Interfaces;

public interface IPetService 
{
    List<Pet> GetPets();
    void Save();
    void CreatePet(Pet pet);
    void UpdatePet(Pet pet);
    void DeletePet(int id);
    Pet GetById(int id);    
}