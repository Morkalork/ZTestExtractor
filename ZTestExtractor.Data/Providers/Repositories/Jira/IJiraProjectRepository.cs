using System;
using System.Collections.Generic;
using ZTestExtractor.Core.Interfaces.Data;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Models.Jira;
namespace ZTestExtractor.Data.Repositories.Jira
{
    public interface IJiraProjectRepository : IRepository<JiraProject>
    {
        IEnumerable<JiraProjectDisplayModel> GetAllDisplayModels();
    }
}
