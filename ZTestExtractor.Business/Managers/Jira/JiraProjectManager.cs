using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.Database;
using ZTestExtractor.Data.Repositories.Jira;
using ZTestExtractor.Models.Jira;

namespace ZTestExtractor.Business.Managers.Jira
{
    public class JiraProjectManager : IJiraProjectManager
    {
        private IJiraProjectRepository _projectRepository;

        public JiraProjectManager(IJiraProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IEnumerable<JiraProjectDisplayModel> GetAllDisplayModels()
        {
            return _projectRepository
                .GetAllDisplayModels();
        }


        public IEnumerable<JiraProjectVersionDisplayModel> GetVersionsForProject(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
