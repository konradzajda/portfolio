# Templates

## Project template

### Include analyzers in non-production environments.
```xml
    <!-- Include analyzers in non-production environment only  -->
    <ItemGroup Condition="' $(Configuration)' != 'Release'">
        <!--   Stylecop     -->
        <AdditionalFiles Include="..\..\..\stylecop.json" />
        <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
            <PrivateAssets>all</PrivateAssets>
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
    
    </ItemGroup>

```