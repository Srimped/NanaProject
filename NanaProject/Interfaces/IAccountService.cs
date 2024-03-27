using System.Diagnostics;
using NanaProject.Models;

namespace NanaProject.Interfaces;

public interface IAccountService
{
    List<Account> GetAccounts();
    void Save();
    void CreateAccount(Account account);
    void UpdateAccount(Account account);
    void DeleteAccount(int id);
    Account GetById(int id);
}