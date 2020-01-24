﻿using System.Linq;

using FluentAssemblyScanner.Test.AdditionalAssembly;
using FluentAssemblyScanner.Tests.SpecClasses;

using FluentAssertions;

using Xunit;

namespace FluentAssemblyScanner.Tests
{
    public class ExcludeAssemblyContainingTests
    {
        [Fact]
        public void AllTypes_should_return_count_greater_than_zero()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyContaining<IAdditionalAssemblyService>()
                    .GetAllTypes()
                    .Count()
                    .Should()
                    .BeGreaterThan(0);
        }

        [Fact]
        public void should_work_as_expected()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyContaining<IAdditionalAssemblyService>()
                    .GetAllTypes()
                    .Should()
                    .Contain(typeof(AbstractDbContext));
        }

        [Fact]
        public void should_work_on_not_wanted_assemblies()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyContaining<IAdditionalAssemblyService>()
                    .GetAllTypes()
                    .Should()
                    .NotContain(typeof(AdditionalAssemblyService));
        }

        [Fact]
        public void should_not_contains_private_classes_when_nonpublictypes_is_not_included()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyContaining<IAdditionalAssemblyService>()
                    .GetAllTypes()
                    .Should().NotContain(typeof(SomePrivateClass));
        }

        [Fact]
        public void should_contains_private_classes_when_nonpublictypes_included()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyContaining<IAdditionalAssemblyService>()
                    .IncludeNonPublicTypes()
                    .GetAllTypes()
                    .Should().Contain(typeof(SomePrivateClass));
        }

        [Fact]
        public void should_not_find_any_type_from_excluded_assembly()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyContaining<IAdditionalAssemblyService>()
                    .BasedOn<AdditionalAssemblyService>()
                    .Filter()
                    .Scan()
                    .Count.Should().Be(0);
        }

        [Fact]
        public void should_not_find_any_type_from_excluded_assembly_with_full_named()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyFullNamed("FluentAssemblyScanner.Test.AdditionalAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                    .BasedOn<IAdditionalAssemblyService>()
                    .Filter()
                    .Scan()
                    .Count.Should().Be(0);
        }

        [Fact]
        public void should_not_find_any_type_from_excluded_assembly_with_name_starts_with()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyNameStartsWith("FluentAssemblyScanner.Test.Ad")
                    .BasedOn<IAdditionalAssemblyService>()
                    .Filter()
                    .Scan()
                    .Count.Should().Be(0);
        }

        [Fact]
        public void should_not_find_any_type_from_excluded_assembly_with_name_ends_with()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyNameEndsWith("embly")
                    .BasedOn<IAdditionalAssemblyService>()
                    .Filter()
                    .Scan()
                    .Count.Should().Be(0);
        }

        [Fact]
        public void should_not_find_any_type_from_excluded_assembly_with_name()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyNamed("FluentAssemblyScanner.Test.AdditionalAssembly")
                    .BasedOn<IAdditionalAssemblyService>()
                    .Filter()
                    .Scan()
                    .Count.Should().Be(0);
        }

        [Fact]
        public void should_not_find_any_type_from_excluded_assembly_with_name_contains()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyNameContains("AdditionalAssembly")
                    .BasedOn<IAdditionalAssemblyService>()
                    .Filter()
                    .Scan()
                    .Count.Should().Be(0);
        }

        [Fact]
        public void should_not_find_any_type_from_excluded_assembly_should_work_on_ignored_dynamic_assemblies()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------

            // None.

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssemblyInThisApplicationDirectory();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.ExcludeAssemblyContaining<IAdditionalAssemblyService>()
                    .IgnoreDynamicAssemblies()
                    .BasedOn<AdditionalAssemblyService>()
                    .Filter()
                    .Scan()
                    .Count.Should().Be(0);
        }

        private class SomePrivateClass
        {
        }
    }
}
