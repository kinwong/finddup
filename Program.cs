using System;
using CommandDotNet;

namespace finddup
{
    class Program
    {
        static int Main(string[] args) => new AppRunner<FindDup>().Run(args);
    }
}
