using NetArchTest.Rules;

namespace SCMS.ArchitectureTests.ArchitectureTests
{
    public class ArchitectureTests
    {
        [Fact]
        public void Domain_Should_Not_Depend_On_Application_Or_Infrastructure()
        {
            var domainNamespace = "SCMS.Domain";
            var forbiddenNamespaces = new[] { "SCMS.Application", "SCMS.Infrastructure" };

            var result = Types.InNamespace(domainNamespace)
                .ShouldNot()
                .HaveDependencyOnAny(forbiddenNamespaces)
                .GetResult();

            Assert.True(result.IsSuccessful, "Domain layer should not depend on Application or Infrastructure layers.");
        }

        [Fact] 
        public void Application_Should_Not_Depend_On_Infrastructure()
        {
            var domainNamespace = "SCMS.Application";
            var forbiddenNamespaces = new[] { "SCMS.Infrastructure" };

            var result = Types.InNamespace(domainNamespace)
                .ShouldNot()
                .HaveDependencyOnAny(forbiddenNamespaces)
                .GetResult();

            Assert.True(result.IsSuccessful, "Application layer should not depend on Infrastructure layers.");
        }

        [Fact]
        public void Infrastructure_Should_Depend_On_Domain()
        {
            var domainNamespace = "SCMS.Infrastructure";
            var allowedNamespaces = new[] { "SCMS.Domain" };

            var result = Types.InNamespace(domainNamespace)
                .Should()
                .HaveDependencyOnAny(allowedNamespaces)
                .GetResult();

            Assert.True(result.IsSuccessful, "Infrastructure layer should depend on Domain layers.");
        }
    }
}
