using System.Diagnostics;
using NanaProject.Models;
using NanaProject.ViewModels;

namespace NanaProject.Interfaces;

public interface IPetService 
{
    List<Pet> GetPets();
    void Save();
    void CreatePet(Pet pet);
    void UpdatePet(Pet pet);
    void DeletePet(int id);
    public Pet GetById(int id);   
    public PetCreateEditViewModel GetByIdSpec (int id); 
}