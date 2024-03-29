using System.Diagnostics;
using NanaProject.Models;

namespace NanaProject.Interfaces;

public interface ICategoryService
{
    List<Category> GetCategories();
    void Save();
    void CreateCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(int id);
    Category GetById(int id);
}