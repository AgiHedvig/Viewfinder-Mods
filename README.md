# Important
If you want the projects to work you will have to use .net 6.0. Then open the game with melonloader at least once then go to Viewfinder\MelonLoader\Il2CppAssemblies and add every file as a reference in Visual Studio. 
Go to Viewfinder\MelonLoader\net6 and add MelonLoader.dll, 0Harmony.dll and Il2CppInterop.Runtime.dll as a reference.

When you build solution you can find the mod dll you have to add to the mods folder in ProjectName\bin\Debug\net6.0 and then its named ProjectName.dll.

You can use these files for making your own mods or if you just want to look at the projects.

Remember to change the AssemblyInfo1.cs if you are making a mod.

MelonLoader: https://github.com/LavaGang/MelonLoader/releases/tag/v0.7.1

.NET 6.0: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

You can find the mods here: link will be added soon

# Useful Modding Stuff
CinematicUnityExplorer is useful for looking at stuff ingame and testing mods/ideas: https://github.com/originalnicodr/CinematicUnityExplorer

You can go to Viewfinder\MelonLoader\Dependencies\Il2CppAssemblyGenerator\Cpp2IL\cpp2il_out and find ViewfinderAssembly.dll. You can open this with dnspy and look at methods, variables and other stuff in the code that you can modify with a harmony patch: https://github.com/dnSpy/dnSpy/releases/tag/v6.1.8
