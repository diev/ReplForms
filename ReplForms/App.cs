#region License
/*
Copyright 2022-2024 Dmitrii Evdokimov
Open source software

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
#endregion

using System.Reflection;

namespace Diev.Extensions.Info;

public static class App
{
    private static readonly Assembly _assembly = Assembly.GetEntryAssembly()!;
    private static readonly AssemblyName _assemblyName = _assembly.GetName();

    public static string Name =>
        _assemblyName.Name!;
    //Path.GetFileNameWithoutExtension(Environment.ProcessPath!);

    public static Version? Version =>
        _assemblyName.Version;

    public static string Company =>
        _assembly.GetCustomAttributes<AssemblyCompanyAttribute>()
        .FirstOrDefault()?.Company ?? "Diev";

    public static string Description =>
        _assembly.GetCustomAttributes<AssemblyDescriptionAttribute>()
        .FirstOrDefault()?.Description ?? "Application";

    public static string Ver =>
        //Version?.ToString(3) ?? "X.X";
        Version?.ToString() ?? "X.X";

    public static string Title =>
        Name + " v" + Ver;

    /// <summary>
    /// C:\Repos\{Solution}\{AppName}\bin\Debug\net8.0-windows8.0
    /// </summary>
    public static string Directory =>
        AppContext.BaseDirectory;
    //Path.GetDirectoryName(Environment.ProcessPath!);

    /// <summary>
    /// C:\ProgramData\{Company}
    /// </summary>
    public static string CompanyData =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            Company);

    /// <summary>
    /// C:\ProgramData\{Company}\{AppName}
    /// </summary>
    public static string ProgramData =>
        Path.Combine(CompanyData, Name);

    /// <summary>
    /// C:\Users\{UserName}\AppData\Local\{Company}\{AppName}
    /// </summary>
    public static string UserData =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Company, Name);
}
