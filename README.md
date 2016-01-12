# SharpNeedle
An Open Source .Net assembly injector

![Interface Image](http://i.imgur.com/Vab9Pup.png)

#Requirements
Visual Stuido 2013 or above (You can get VS2015 Community Edition for free here: https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)

#Usages
SharpNeedle can inject any .Net payload into any remote process quickly. It supports both dlls and exe assembiles and you don't need to give any more information other than the directory and the assembly name to in the injector.

Since C# dlls cannot have an EntryPoint or DLLMain(C++) most injectors require a TypeName, SharpNeedle however will look for a method with a [STAThread] Attribute and use that for your EntryPoint

So your payload dll should have ONE method like this:
```c#
using System;
using System.Windows.Forms;

namespace SharpPayload
{
    public class Main
    {
        /// <summary>
        /// The main entry point for the application.
        /// Unlike C++, C# does not have the ability to specify an EntryPoint. Therefore SharpDomain looks for a [STAThread] Attribute and uses that as an EntryPoint
        /// </summary>
        [STAThread]
        public static int Run(string arg)
        {
            MessageBox.Show("C#/.Net dll payload example");
            MessageBox.Show(arg.ToString());
            return 0;
        }
     }
}
```

Alternatively if your injecting an exe it would look like this:

```c#
using System;
using System.Windows.Forms;

namespace SharpPayloadWinForms
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Unlike C++, C# does not have the ability to specify an EntryPoint. Therefore SharpDomain looks for a [STAThread] Attribute and uses that as an EntryPoint
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

```

As an example for injecting you can call the following method (found in the SharpNeedle example applicaiton)

```c#
 PayloadInjector injector = new PayloadInjector(targetProcess, DomainDllDirectory, domainDllName, PayloadAssemblyDirectory, payloadAssemblyName, PayloadArguemtString);
 injector.InjectAndForget();
```
#Credits
http://binarysharp.com/ for their awesome MemorySharp & Fasm.Net

https://github.com/lolp1 for his PatchedDomainLoader which was partially used
