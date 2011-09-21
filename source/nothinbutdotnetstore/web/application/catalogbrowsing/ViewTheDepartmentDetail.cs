using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentDetail : IOrchestrateAnApplicationFeature
    {
        IFindDepartments department_repository;
        IDisplayReports display_engine;

        public ViewTheDepartmentDetail(IFindDepartments department_repository, IDisplayReports display_engine)
        {
            this.department_repository = department_repository;
            this.display_engine = display_engine;
        }

        public ViewTheDepartmentDetail()
            : this(new StubDepartmentRepository(),
            new StubDisplayEngine())
        {
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(department_repository.get_the_department());
        }
    }
}
