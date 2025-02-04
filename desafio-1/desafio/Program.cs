
using desafio;

#region 1
//var declaration = new Declaration();
const string valueStart = "ABCPTX";
var existValue = valueStart.Contains("PTX");

Console.WriteLine("Existe o valor 'PTX'? " + existValue);
Console.WriteLine("------------");
#endregion

#region 2

var index = valueStart?.IndexOf("PTX");
Console.WriteLine("o PTX começa no index " + index);
var findArray = new List<char>();

for (var i = 0; i < valueStart.Length; i++)
{
    if (i != index)
    {
        findArray.Add(valueStart[i]);
        Console.WriteLine(valueStart[i]);
    }
}
var index2 = valueStart.IndexOf('X');
findArray.RemoveAt(index2 -1);

Console.WriteLine("------------");
#endregion

#region 3

var orderedEnumerable = findArray.OrderBy(c => c);
foreach (var element in orderedEnumerable)
{
    Console.WriteLine(element);
}
Console.WriteLine("------------");

var filterList = new List<char>();
foreach (var find in findArray.Select(element => valueStart.First(c => c == element)))
{
    filterList.Add(find);
    Console.WriteLine(find);
}
Console.WriteLine("------------");
#endregion


#region 4
    const string stringInteiro = "5";
    int inteiro = 0;
    Console.WriteLine(int.TryParse(stringInteiro, out inteiro) ? "é inteiro" : "não é inteiro, não é possível converter");

    double doubleDois = 3.14d;
    float floatDois = 3.14f;
    decimal decimalDois = 3.14m;

    const string stringInteiroDois = "3,14";
    const string stringDoubleDois = "3,14";
    const string stringFloatDois = "3,14";
    Console.WriteLine(decimal.TryParse(stringInteiroDois,out _) ? "é decimal" : "não é decimal, não é possível converter");
    Console.WriteLine(double.TryParse(stringDoubleDois,out _) ? "é double" : "não é double, não é possível converter");
    Console.WriteLine(float.TryParse(stringFloatDois,out _) ? "é float" : "não é float, não é possível converter");
    Console.WriteLine("------------");
#endregion

#region 6
    int convertInt(string value){
        return int.Parse(value);
    }
    decimal convertDecimal(string value){
        return decimal.Parse(value);
    }
    double convertDouble(string value){
        return double.Parse(value);
    }
    float convertFloat(string value){
        return float.Parse(value);
    }

    Console.WriteLine(convertInt(stringInteiro));
    Console.WriteLine(convertDecimal(stringInteiroDois));
    Console.WriteLine(convertDouble(stringInteiroDois));
    Console.WriteLine(convertFloat(stringInteiroDois));
    Console.WriteLine("------------");
#endregion

#region 7
    var listTypes = new List<Types>();
    

    listTypes.Add(new Types{Value1 = 3, Value2 = 43, Value3 = 4.4, Value4 = 7});
    listTypes.Add(new Types{Value1 = 4, Value2 = 56, Value3 = 6.6, Value4 = 8});

    Console.WriteLine("FOREACH");
    foreach (var type in listTypes)
    {
        Console.WriteLine(type.Value1);
        Console.WriteLine(type.Value2);
        Console.WriteLine(type.Value3);
        Console.WriteLine(type.Value4);
    }
    Console.WriteLine("------------"); 
    Console.WriteLine("FOR");
    for (var i = 0; i < listTypes.Count; i++)
    {
        Console.WriteLine(listTypes[i].Value1);
        Console.WriteLine(listTypes[i].Value2);
        Console.WriteLine(listTypes[i].Value3);
        Console.WriteLine(listTypes[i].Value4);
    }

    Console.WriteLine("------------");
    Console.WriteLine("WHILE");
    while (listTypes.Count > 0)
    {
        Console.WriteLine(listTypes.First().Value1);
        Console.WriteLine(listTypes.First().Value2);
        Console.WriteLine(listTypes.First().Value3);
        Console.WriteLine(listTypes.First().Value4);
        listTypes.RemoveAt(0);
    }

#endregion

#region 9
    Console.WriteLine("------------");
    Console.WriteLine(PessoasEnum.Jose);
    Console.WriteLine(PessoasEnum.Maria);
    Console.WriteLine(PessoasEnum.Patricia);

    Console.WriteLine("------------");
    Console.WriteLine((int)PessoasEnum.Jose);
    Console.WriteLine((int)PessoasEnum.Maria);
    Console.WriteLine((int)PessoasEnum.Patricia);
    var pessoa = 2;
    switch (pessoa)
    {
        case (int)PessoasEnum.Jose:
            Console.WriteLine("A pessoa é Jose");
            break;
        case (int)PessoasEnum.Maria:
            Console.WriteLine("A pessoa é Maria");
            break;
        case (int)PessoasEnum.Patricia:
            Console.WriteLine("A pessoa é Patricia");
            break;
    }
#endregion