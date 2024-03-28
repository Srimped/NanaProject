using System.Diagnostics;
using NanaProject.Models;

namespace NanaProject.Interfaces;

public interface ISpeciesService 
{
    List<Species> GetSpecies();
    void Save();
    void CreateSpecies(Species species);
    void UpdateSpecies(Species species);
    void DeleteSpecies(int id);
    Species GetById(int id);    
}