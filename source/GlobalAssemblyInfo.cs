// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Reflection;
using System.Runtime.InteropServices;

#if DEBUG

[assembly: AssemblyConfiguration("DEBUG")]
#elif RELEASE
[assembly: AssemblyConfiguration("RELEASE")]
#endif

[assembly: AssemblyCompany("Novus Craft")]
[assembly: AssemblyCopyright("Copyright © Novus Craft 2011")]
[assembly: AssemblyProduct("Novus Craft Website")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("0.0.0.0")]