﻿using Contracts;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) => 
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
                .SingleOrDefault();

    }
}
