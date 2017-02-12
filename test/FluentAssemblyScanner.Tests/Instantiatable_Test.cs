using System;
using System.Collections.Generic;
using System.Reflection;

using FluentAssemblyScanner.Tests.SpecClasses;

using FluentAssertions;

using Xunit;

namespace FluentAssemblyScanner.Tests
{
    public class Instantiatable_Test
    {
        [Fact]
        public void FromAssembly_should_be_instantiatable_by_passing_an_assembly()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssembly(thisAssembly);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }

        [Fact]
        public void FromAssemblyContaining_should_be_instantiatable_by_given_type()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            Type type = typeof(ISecurityService);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyContaining(type);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }

        [Fact]
        public void FromAssemblyContaining_should_be_instantiatable_by_given_t_generic()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyContaining<ISecurityService>();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }

        [Fact]
        public void FromAssemblyInDirectory_should_be_instantiatable_by_given_AssemblyFilter()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var assemblyFilter = new AssemblyFilter("bin");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInDirectory(assemblyFilter);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }

        [Fact]
        public void FromAssemblyInThisApplication_should_be_instantiatable()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplication();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }

        [Fact]
        public void FromAssemblyMatchingNamed_should_be_instantiatable_with_assemblyPrefix_and_assemblyFilter()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            const string assemblyPrefix = "Fluent";
            var assemblyFilter = new AssemblyFilter("bin");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyMatchingNamed(assemblyPrefix, assemblyFilter);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }

        [Fact]
        public void FromAssemblyNamed_should_be_instantiatable_with_assemblyName()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            const string assemblyName = "FluentAssemblyScanner.Tests";

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyNamed(assemblyName);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }

        [Fact]
        public void FromAssemblies_should_be_instantiatable_with_given_assemblies()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            IEnumerable<Assembly> assemblies = new Assembly[]
            {
                Assembly.GetExecutingAssembly()
            };

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblies(assemblies);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }

        [Fact]
        public void FromThisAssembly_should_be_instantiatable()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromThisAssembly();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.Should().NotBeNull();
        }
    }
}