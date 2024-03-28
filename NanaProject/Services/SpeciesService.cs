using System.Diagnostics;
using NanaProject.Interfaces;
using NanaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace NanaProject.Services;

public class SpeciesService : ISpeciesService
{
    private readonly NanaDbContext _context;

    public SpeciesService(NanaDbContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public List<Species> GetSpecies()
    {
        return _context.Specieses.ToList();
    }

    public void CreateSpecies (Species species)
    {
        _context.Add(species);
        Save();
    }

    public void UpdateSpecies (Species species)
    {
        _context.Specieses.Update(species);
        Save();
    }

    public void DeleteSpecies (int id)
    {
        Species spec = GetById(id);
        _context.Specieses.Remove(spec);
        Save();
    }

    public Species GetById (int id)
    {
        return _context.Specieses.Where( s => s.SpecId == id).SingleOrDefault();
    }
}