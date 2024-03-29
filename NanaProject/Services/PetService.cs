using System.Diagnostics;
using NanaProject.Interfaces;
using NanaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace NanaProject.Services;

public class PetService : IPetService
{
    private readonly NanaDbContext _context;

    public PetService(NanaDbContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public List<Pet> GetPets()
    {
        return _context.Pets.ToList();
    }

    public void CreatePet (Pet pet)
    {
        _context.Add(pet);
    }

    public void UpdatePet (Pet pet)
    {
        _context.Pets.Update(pet);
    }

    public void DeletePet (int id)
    {
        Pet pet = GetById(id);
        _context.Pets.Remove(pet);
    }

    public Pet GetById (int id)
    {
        return _context.Pets.Where( p => p.Id == id).SingleOrDefault();
    }
}