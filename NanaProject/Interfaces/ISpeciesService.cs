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
    List<Species> Search(string key);
    Species GetById(int id);    
}