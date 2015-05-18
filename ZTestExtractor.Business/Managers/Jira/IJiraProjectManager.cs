using System;
using System.Collections.Generic;
using ZTestExtractor.Models.Jira;
namespace ZTestExtractor.Business.Managers.Jira
{
    public interface IJiraProjectManager : IManager
    {
        IEnumerable<JiraProjectDisplayModel> GetAllDisplayModels();

        IEnumerable<JiraProjectVersionDisplayModel> GetVersionsForProject(int projectId);
    }
}
