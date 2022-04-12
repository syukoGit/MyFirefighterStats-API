// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="Program.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API;

/// <summary>
///     The entry class of the project.
/// </summary>
public static class Program
{
    /// <summary>
    ///     The entry point of the program.
    /// </summary>
    /// <param name="args">List of entered arguments.</param>
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    /// <summary>
    ///     Creates a host builder.
    /// </summary>
    /// <param name="args">List of entered arguments.</param>
    /// <returns></returns>
    private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
                                                                        .ConfigureWebHostDefaults(static webBuilder => webBuilder.UseStartup<Startup>());
}
