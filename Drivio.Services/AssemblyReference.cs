using System.Reflection;

namespace Drivio.Services;

public static class AssemblyReference
{
    public static Assembly Reference => Assembly.GetExecutingAssembly();
}