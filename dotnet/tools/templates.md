# Templates

## Project templates

## Source project template

```{ProjectName}.csproj```
```xml

    <Project Sdk="Microsoft.NET.Sdk">
    
        <PropertyGroup>
            <TargetFramework>net5.0</TargetFramework>

            <GenerateDocumentationFile>true</GenerateDocumentationFile>
            <DocumentationFile>portfolio_{ProjectShortName}.xml</DocumentationFile>
        </PropertyGroup>
    
        <!-- Include analyzers in non-production environment only  -->
        <ItemGroup Condition="' $(Configuration)' != 'Release'">
            <!-- Stylecop -->
            <AdditionalFiles Include="..\..\..\stylecop.json" />
            <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
                <PrivateAssets>all</PrivateAssets>
                <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
            </PackageReference>
    
            <!-- Other analyzers-->
            <PackageReference Include="SonarAnalyzer.CSharp" Version="8.22.0.31243">
                <PrivateAssets>all</PrivateAssets>
                <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
            </PackageReference>
            
        </ItemGroup>
        
    </Project>

```

### Test project template

```{ProjectName}.Tests.csproj ```
```xml

<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>net5.0</TargetFramework>

        <IsPackable>false</IsPackable>
        <RootNamespace>{ProjectName}</RootNamespace>
    </PropertyGroup>
    
    <!-- Include analyzers in non-production environment only  -->
    <ItemGroup Condition="' $(Configuration)' != 'Release'">
        <!-- Stylecop -->
        <AdditionalFiles Include="..\..\..\stylecop.json" />
        <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
            <PrivateAssets>all</PrivateAssets>
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>

        <PackageReference Include="SonarAnalyzer.CSharp" Version="8.22.0.31243">
            <PrivateAssets>all</PrivateAssets>
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
        
    </ItemGroup>
    
    <ItemGroup>
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.7.1" />
        <PackageReference Include="NSubstitute" Version="4.2.2" />
        <PackageReference Include="xunit" Version="2.4.1" />
        <PackageReference Include="xunit.runner.visualstudio" Version="2.4.3">
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
            <PrivateAssets>all</PrivateAssets>
        </PackageReference>
        <PackageReference Include="coverlet.collector" Version="1.3.0">
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
            <PrivateAssets>all</PrivateAssets>
        </PackageReference>
    </ItemGroup>

</Project>

```

#### Include analyzers in non-production environments.
```xml
    <!-- Include analyzers in non-production environment only  -->
    <ItemGroup Condition="' $(Configuration)' != 'Release'">
        <!-- Stylecop -->
        <AdditionalFiles Include="..\..\..\stylecop.json" />
        <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
            <PrivateAssets>all</PrivateAssets>
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
    
        <!--   Other analyzers   -->
        <PackageReference Include="NSubstitute.Analyzers.CSharp" Version="1.0.14" />
        <PackageReference Include="SonarAnalyzer.CSharp" Version="8.22.0.31243">
            <PrivateAssets>all</PrivateAssets>
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
    
    </ItemGroup>

```