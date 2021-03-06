﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Models.Jira;
using NHibernate.FlowQuery;

namespace ZTestExtractor.Data.Repositories.Jira
{
    public class JiraProjectRepository : RepositoryBase<JiraProject>, IJiraProjectRepository
    {
        public JiraProjectRepository(ISession session) : base(session)
        { }

        public IEnumerable<JiraProjectDisplayModel> GetAllDisplayModels()
        {
            var result = Query
                .OrderBy(x => x.Name)
                .Select(x => new JiraProjectDisplayModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Key = x.Key
                });

            return result;
        }
    }
}
