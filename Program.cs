namespace HelloWorld;

 public static class Program
 {
    //Using add-type this entry point is callable from powershell
    //[HelloWorld.Program]::Main()
     public static void Main(string[] args)
     {
         Console.WriteLine("Hello, World!");
     }
    
    //Using add-type this entry point is callable from powershell
    //[HelloWorld.Program]::TestMessage()
     public static string TestMessage() {
         return "Hello, World!";
     }
 }