using System.Diagnostics;
using NanaProject.Interfaces;
using NanaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace NanaProject.Services;

public class AccountService : IAccountService
{
    private readonly NanaDbContext _context;

    public AccountService(NanaDbContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public List<Account> GetAccounts()
    {
        return _context.Accounts.ToList();
    }

    public void CreateAccount (Account account)
    {
        _context.Add(account);
        Save();
    }

    public void UpdateAccount (Account account)
    {
        _context.Accounts.Update(account);
        Save();
    }

    public void DeleteAccount (int id)
    {
        Account acc = GetById(id);
        _context.Accounts.Remove(acc);
        Save();
    }

    public Account GetById (int id)
    {
        return _context.Accounts.Where( a => a.AccId == id).SingleOrDefault();
    }
}