using _04_Cookies_Recipe_Assigment.DataAccess;
using _04_Cookies_Recipe_Assigment.FileAccess;

const FileFormat Format = FileFormat.Json;

IStringsRespository stringsRepository = Format == FileFormat.Json
    ? new StringsJsonRespository()
    : new StringsTextualRespository();

const string FileName = "recipes";
var fileMetaData = new FileMetaData(FileName, Format);

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipeApp = new CookiesRecipeApp(
    new RecipeReopository(stringsRepository, ingredientsRegister),
    new RecipeConsoleUserInteraction(ingredientsRegister));

cookiesRecipeApp.Run(fileMetaData.toPath());



