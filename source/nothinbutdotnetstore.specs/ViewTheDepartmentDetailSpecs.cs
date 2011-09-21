using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheDepartmentDetail))]
    public class ViewTheDepartmentDetailSpecs
    {
        public abstract class concern : Observes<IOrchestrateAnApplicationFeature,
                                            ViewTheDepartmentDetail>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                department_repository = depends.on<IFindDepartments>();
                the_department =  new Department() ;
                display_engine = depends.on<IDisplayReports>();

                request = fake.an<IContainRequestInformation>();

                department_repository.setup(x => x.get_the_department())
                    .Return(the_department);
            };

            Because b = () =>
                sut.process(request);

            It should_display_the_department_Detail = () =>
                display_engine.received(x => x.display(the_department));



            static IContainRequestInformation request;
            static IFindDepartments department_repository;
            static Department the_department;
            static IDisplayReports display_engine;
        }
    }
}