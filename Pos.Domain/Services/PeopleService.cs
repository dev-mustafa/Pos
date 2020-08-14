﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;

namespace Pos.Domain.Services
{
    public interface IPeopleService : IInitializer
    {
        Task<bool> AddPerson(Person person);
        Task<bool?> UpdatePerson(Person person);
        Task<bool?> DeletePerson(int personId, bool removeRelatedEntities = false);
        Task<Person> FindPerson(int personId);
        Task<List<Person>> GetAllPeople();
        Task<List<Person>> GetPeople(bool isCustomer);
    }
    public class PeopleService : ServicesBase, IPeopleService
    {
        async Task<bool> IPeopleService.AddPerson(Person person)
        {
            return await CrudService.Add(person, c => c.Name == person.Name);
        }

        async Task<bool?> IPeopleService.UpdatePerson(Person person)
        {
            return await CrudService.Update(person, person.Id, c => c.Name == person.Name && c.Id != person.Id);
        }

        async Task<bool?> IPeopleService.DeletePerson(int personId, bool removeRelatedEntities)
        {
            var person = Context.People.Include(u => u.Transactions).FirstOrDefault(c => c.Id == personId);
            if (person == null) return false;
            if (removeRelatedEntities)
                Context.Transactions.RemoveRange(Context.Transactions.Where(t => t.PersonId == person.Id));
            else
                if (person.Transactions.Count > 0) return null;
            Context.People.Remove(person);
            await Context.SaveChangesAsync();
            return true;
        }

        async Task<Person> IPeopleService.FindPerson(int personId)
        {
            return await Context.People.FindAsync(personId);
        }

        async Task<List<Person>> IPeopleService.GetAllPeople()
        {
            return await Context.People.ToListAsync();
        }
        async Task<List<Person>> IPeopleService.GetPeople(bool isCustomer)
        {
            var type = isCustomer ? Enums.PersonType.Supplier : Enums.PersonType.Customer;
            return await Context.People.Where(p => p.PersonType != type ).ToListAsync();
        }
    }


}
